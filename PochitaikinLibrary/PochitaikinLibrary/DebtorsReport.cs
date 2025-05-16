using Npgsql;
using System.Data;

namespace PochitaikinLibrary
{
    public partial class DebtorsReport : Form
    {
        private NpgsqlConnection connection;
        private Form mainForm;
        public DebtorsReport(NpgsqlConnection conn, Form mainForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = mainForm;
            connection = conn;
            this.FormClosed += OverdueBooksReport_FormClosed;
        }

        private void OverdueBooksReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        private void LoadUniversities()
        {
            try
            {
                string query = "SELECT name FROM universities ORDER BY name";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    checkedListBoxUniversities.Items.Clear();

                    while (reader.Read())
                    {
                        checkedListBoxUniversities.Items.Add(reader["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка вузов: {ex.Message}");
            }
        }

        private void OverdueBooksReport_Load(object sender, EventArgs e)
        {
            // Выбор по одному клику
            checkedListBoxUniversities.CheckOnClick = true;

            // Настройка DateTimePicker - оставляем только одну дату
            dateTimePickerStart.Value = DateTime.Today;

            // Переименовываем подпись
            DataStart.Text = "Дата проверки:";

            // Загрузка списка вузов
            LoadUniversities();

            // Настройка DataGridView
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (checkedListBoxUniversities.CheckedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один ВУЗ.");
                return;
            }

            DateTime checkDate = dateTimePickerStart.Value.Date;

            try
            {
                // Получаем выбранные вузы
                var selectedUniversities = new List<string>();
                foreach (var item in checkedListBoxUniversities.CheckedItems)
                {
                    selectedUniversities.Add(item.ToString());
                }

                string query = @"
                SELECT 
                    u.name AS ""ВУЗ"",
                    s.full_name AS ""ФИО студента"",
                    b.title AS ""Название книги"",
                    b.cost AS ""Стоимость книги"",
                    l.issue_date AS ""Дата выдачи"",
                    l.due_date AS ""Срок возврата"",
                    EXTRACT(DAY FROM (@checkDate - l.due_date))::integer AS ""Дней просрочки""
                FROM 
                    loans l
                    JOIN students s ON l.student_id = s.student_id
                    JOIN universities u ON s.university_id = u.university_id
                    JOIN books b ON l.book_id = b.book_id
                WHERE 
                    l.return_date IS NULL
                    AND l.due_date < @checkDate
                    AND u.name = ANY(@selectedUniversities)
                ORDER BY 
                    u.name, s.full_name, l.due_date";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("checkDate", checkDate);
                    cmd.Parameters.AddWithValue("selectedUniversities", selectedUniversities.ToArray());

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView.DataSource = dt;

                        // Форматирование столбцов
                        if (dataGridView.Columns.Contains("Стоимость книги"))
                        {
                            dataGridView.Columns["Стоимость книги"].DefaultCellStyle.Format = "N2";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}");
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта!");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Сохранить отчет о должниках";
                saveFileDialog.FileName = $"Должники_на_{dateTimePickerStart.Value:dd.MM.yyyy}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = false;

                    Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
                    worksheet.Name = "Должники";

                    int currentRow = 1;

                    // Метаданные отчета
                    var reportTitleCell = worksheet.Cells[currentRow, 1];
                    reportTitleCell.Value = "Отчет о должниках на " + dateTimePickerStart.Value.ToString("dd.MM.yyyy");
                    var titleRange = worksheet.Range[$"A{currentRow}:G{currentRow}"];
                    titleRange.Merge();
                    titleRange.Font.Bold = true;
                    titleRange.Font.Size = 14;
                    titleRange.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightBlue;
                    currentRow++;

                    // Заголовок "ВУЗы:"
                    worksheet.Cells[currentRow, 1] = "ВУЗы:";

                    // Список выбранных вузов (каждый на новой строке)
                    var selectedUniversities = new List<string>();
                    for (int i = 0; i < checkedListBoxUniversities.Items.Count; i++)
                    {
                        if (checkedListBoxUniversities.GetItemChecked(i))
                        {
                            worksheet.Cells[currentRow, 2] = checkedListBoxUniversities.Items[i].ToString();
                            currentRow++;
                        }
                    }

                    currentRow++; 

                    // Заголовки столбцов
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cells[currentRow, i + 1] = dataGridView.Columns[i].HeaderText;
                        worksheet.Cells[currentRow, i + 1].Font.Bold = true;
                        worksheet.Cells[currentRow, i + 1].Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbLightBlue;
                    }
                    currentRow++;

                    // Данные
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            if (dataGridView.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[currentRow, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                        currentRow++;
                    }

                    // Форматирование
                    worksheet.Columns.AutoFit();

                    // Числовые форматы
                    Microsoft.Office.Interop.Excel.Range costColumn = worksheet.Columns[4];
                    costColumn.NumberFormat = "#,##0.00";

                    Microsoft.Office.Interop.Excel.Range dateColumns = worksheet.Range[
                        worksheet.Cells[currentRow - dataGridView.Rows.Count, 5],
                        worksheet.Cells[currentRow - 1, 6]];
                    dateColumns.NumberFormat = "dd.mm.yyyy";

                    // Сохранение файла
                    workbook.SaveAs(saveFileDialog.FileName);
                    workbook.Close();
                    excelApp.Quit();

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                    MessageBox.Show("Отчет экспортирован в Excel!", "Экспорт завершен",
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
