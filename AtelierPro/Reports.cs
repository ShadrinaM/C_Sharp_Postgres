using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace AtelierPro
{
    public partial class Reports : Form
    {
        private NpgsqlConnection connection;
        private Menu mainForm;

        public Reports(NpgsqlConnection conn, Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            connection = conn;
            this.FormClosed += WinForm_FormClosed;
        }

        /// <summary>
        /// Закрытие окна по крестику
        /// </summary>
        private void WinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Показываем главное окно при закрытии текущего
            mainForm.Show();
        }

        /// <summary>
        /// Закрытие окна по кнопке btnBack
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Показываем главное окно
            mainForm.Show();
            // Закрываем текущее окно
            this.Close();
        }



        /// <summary>
        /// Донастройка значений по умолчанию
        /// </summary>
        private void Reports_Load(object sender, EventArgs e)
        {
            // Настройка checkedListBoxMaterial
            checkedListBox.CheckOnClick = true;

            // Заполнение ComboBox вариантами отчетов
            comboBox.Items.AddRange(new string[]
            {
                "Отчёт по материалам (поставщикам)",
                "Отчёт по изделиям (материалам)"
            });

            // Установка значения по умолчанию
            comboBox.SelectedIndex = 0;
            // Убирает дуратское выделение синим
            comboBox.Enter += comboBox_Enter;
            // Заполнение checkedListBox по умолчанию
            LoadMaterials();
        }

        /// <summary>
        /// Убирает выделение синим comboBox
        /// </summary>
        private void comboBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate {
                comboBox.Select(0, 0);
            });
        }



        /// <summary>
        /// Обновление checkedListBox по изменению comboBox
        /// </summary>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                LoadMaterials();
                btnExportExcel.Visible = false;
                selectedMaterial.Text = "Материалы:";
            }
            else
            {
                LoadProducts();
                btnExportExcel.Visible = true;
                selectedMaterial.Text = "Изделия:";
            }
        }

        /// <summary>
        /// Заполнение checkedListBox из Materials
        /// </summary>
        private void LoadMaterials()
        {
            try
            {
                string query = "SELECT material_name FROM Material ORDER BY material_name";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    checkedListBox.Items.Clear(); // Очищаем список перед заполнением

                    while (reader.Read())
                    {
                        checkedListBox.Items.Add(reader["material_name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке материалов: {ex.Message}");
            }
        }

        /// <summary>
        /// Заполнение checkedListBox из Products
        /// </summary>
        private void LoadProducts()
        {
            try
            {
                string query = "SELECT product_name FROM Products ORDER BY product_name";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    checkedListBox.Items.Clear(); // Очищаем список перед заполнением

                    while (reader.Read())
                    {
                        checkedListBox.Items.Add(reader["product_name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изделий: {ex.Message}");
            }
        }

        /// <summary>
        /// Заполнение dataGridView для отчёта по Materials или Products
        /// </summary>
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                try
                {
                    // Проверяем, что выбраны материалы
                    if (checkedListBox.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Пожалуйста, выберите хотя бы один материал.");
                        return;
                    }

                    // Получаем выбранные материалы
                    var selectedMaterials = new List<string>();
                    foreach (var item in checkedListBox.CheckedItems)
                    {
                        selectedMaterials.Add(item.ToString());
                    }

                    // Получаем даты из dateTimePicker
                    DateTime startDate = dateTimePickerStart.Value.Date;
                    DateTime endDate = dateTimePickerEnd.Value.Date;

                    // SQL-запрос
                    string query = @"
                    SELECT 
                        s.supplier_name AS Поставщик,
                        m.material_name AS Материал,
                        SUM(ii.quantity) AS Количество,
                        m.unit AS ""Единица измерения"",
                        ROUND(SUM(ii.quantity * ii.unit_price), 2) AS ""Сумма выкупа""
                    FROM 
                        IncomingItems ii
                        JOIN IncomingInvoices inv ON ii.invoice_id = inv.invoice_id
                        JOIN Suppliers s ON inv.supplier_id = s.supplier_id
                        JOIN Material m ON ii.material_id = m.material_id
                    WHERE 
                        m.material_name = ANY(@selectedMaterials)
                        AND inv.invoice_date BETWEEN @startDate AND @endDate
                    GROUP BY 
                        s.supplier_name, m.material_name, m.unit
                    ORDER BY 
                        s.supplier_name, m.material_name";

                    // Заполнение запроса данными из формы
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        cmd.Parameters.AddWithValue("selectedMaterials", selectedMaterials.ToArray());
                        cmd.Parameters.AddWithValue("startDate", startDate);
                        cmd.Parameters.AddWithValue("endDate", endDate);

                        // Создаем адаптер и заполняем DataTable
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);

                            // Привязываем DataTable к DataGridView
                            dataGridView.DataSource = dt;

                            // Настраиваем заголовки столбцов
                            dataGridView.AutoResizeColumns();
                            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}");
                }
            } else
            {
                try
                {
                    // Проверяем, что выбраны изделия
                    if (checkedListBox.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Пожалуйста, выберите хотя бы одно изделие.");
                        return;
                    }

                    // Получаем выбранные изделия
                    var selectedProducts = new List<string>();
                    foreach (var item in checkedListBox.CheckedItems)
                    {
                        selectedProducts.Add(item.ToString());
                    }

                    // Получаем даты из dateTimePicker
                    DateTime startDate = dateTimePickerStart.Value.Date;
                    DateTime endDate = dateTimePickerEnd.Value.Date;

                    // SQL-запрос для получения материалов по выбранным изделиям
                    string query = @"
                    SELECT 
                        p.product_name AS Изделие,
                        m.material_name AS Материал,
                        SUM(mu.quantity) AS Количество,
                        m.unit AS ""Единица измерения"",
                        ROUND((SELECT AVG(ii.unit_price) 
                         FROM IncomingItems ii 
                         WHERE ii.material_id = m.material_id),2) AS ""Средняя цена"",
                        ROUND(SUM(mu.quantity) * (SELECT AVG(ii.unit_price) 
                                           FROM IncomingItems ii 
                                           WHERE ii.material_id = m.material_id),2) AS ""Общая стоимость""
                    FROM 
                        Products p
                        JOIN Orders o ON p.order_id = o.order_id
                        JOIN MaterialUsage mu ON p.usage_id = mu.usage_id
                        JOIN Material m ON mu.material_id = m.material_id
                    WHERE 
                        p.product_name = ANY(@selectedProducts)
                        AND o.order_date BETWEEN @startDate AND @endDate
                    GROUP BY 
                        p.product_name, m.material_name, m.unit, m.material_id
                    ORDER BY 
                        p.product_name, m.material_name";

                    // Заполнение запроса данными из формы
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        cmd.Parameters.AddWithValue("selectedProducts", selectedProducts.ToArray());
                        cmd.Parameters.AddWithValue("startDate", startDate);
                        cmd.Parameters.AddWithValue("endDate", endDate);

                        // Создаем адаптер и заполняем DataTable
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            adapter.Fill(dt);

                            // Привязываем DataTable к DataGridView
                            dataGridView.DataSource = dt;

                            // Настраиваем заголовки столбцов
                            dataGridView.AutoResizeColumns();
                            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}");
                }
            }

        }
        
        /// <summary>
        /// Экспорт в эксель для отчёта по Изделиям
        /// </summary>
        private void btnExportExel_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, есть ли данные для экспорта
                if (dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта!");
                    return;
                }

                // Создаем диалог сохранения файла
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Сохранить Excel файл";
                saveFileDialog.FileName = "Отчет_по_изделиям_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Создаем приложение Excel
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;

                    // Создаем новую книгу
                    Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
                    worksheet.Name = "Отчет по изделиям";

                    // Записываем заголовки столбцов
                    for (int i = 1; i <= dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                        // Форматируем заголовки
                        worksheet.Cells[1, i].Font.Bold = true;
                        worksheet.Cells[1, i].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightGray;
                    }

                    // Записываем данные
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            if (dataGridView.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // Автонастройка ширины столбцов
                    worksheet.Columns.AutoFit();

                    // Форматирование числовых столбцов (если есть)
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Columns[j].HeaderText.Contains("Сумма") ||
                            dataGridView.Columns[j].HeaderText.Contains("Цена") ||
                            dataGridView.Columns[j].HeaderText.Contains("Стоимость"))
                        {
                            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Columns[j + 1];
                            range.NumberFormat = "#,##0.00";
                        }
                    }

                    // Сохраняем файл
                    workbook.SaveAs(saveFileDialog.FileName,
                                  Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
                    workbook.Close();
                    excelApp.Quit();

                    // Освобождаем ресурсы
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    MessageBox.Show("Экспорт в Excel завершен успешно!", "Экспорт данных",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }          
    }
}