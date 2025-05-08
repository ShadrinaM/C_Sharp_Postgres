using Npgsql;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AtelierPro
{
    public partial class Invoices : Form
    {
        private NpgsqlConnection connection;
        private Menu mainForm;

        public Invoices(NpgsqlConnection conn, Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            connection = conn;
            this.FormClosed += WinForm_FormClosed;
            this.mainForm = mainForm;
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
        /// Установка значений по умолчанию
        /// </summary>
        private void Invoices_Load(object sender, EventArgs e)
        {
            // Заполнение ComboBox вариантами отчетов
            comboBoxInvoices.Items.AddRange(new string[]
            {
            "Приходная накладная",
            "Расходная накладная"
            });

            // Установка значения по умолчанию
            comboBoxInvoices.SelectedIndex = 0;
            Fill_dataGridViewInvoices();
        }

        /// <summary>
        /// Отбработчик выбора типа накладной в comboBoxTables
        /// </summary>
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {

            Fill_dataGridViewInvoices();

        }

        /// <summary>
        /// Отображение всех накладных в dataGridViewInvoices + возможность ткнуть
        /// </summary>
        private void Fill_dataGridViewInvoices()
        {
            try
            {
                if (comboBoxInvoices.SelectedIndex == -1) return;

                // Определяем таблицу на основе выбранного типа накладной
                string selectedType = comboBoxInvoices.SelectedItem.ToString();

                string query;
                DataTable dt = new DataTable();

                if (selectedType == "Приходная накладная")
                {
                    query = @"
                SELECT                         
                    ii.invoice_id,
                    ii.invoice_number AS ""Номер накладной"",
                    s.supplier_name AS ""Поставщик"",
                    ii.invoice_date AS ""Дата накладной"",
                    ii.delivery_date AS ""Дата поставки"",
                    ii.notes AS ""Примечания""
                FROM 
                    IncomingInvoices ii
                    JOIN Suppliers s ON ii.supplier_id = s.supplier_id
                ORDER BY 
                    ii.invoice_date DESC";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    dataGridViewInvoices.DataSource = dt;

                    // Скрываем invoice_id (он нужен только для запросов)
                    dataGridViewInvoices.Columns["invoice_id"].Visible = false;

                    // Устанавливаем порядок столбцов
                    dataGridViewInvoices.Columns["Номер накладной"].DisplayIndex = 0;
                    dataGridViewInvoices.Columns["Поставщик"].DisplayIndex = 1;
                    dataGridViewInvoices.Columns["Дата накладной"].DisplayIndex = 2;
                    dataGridViewInvoices.Columns["Дата поставки"].DisplayIndex = 3;
                    dataGridViewInvoices.Columns["Примечания"].DisplayIndex = 4;
                }
                else // Расходная накладная
                {
                    query = @"
                SELECT 
                    oi.outgoing_id,
                    oi.invoice_number AS ""Номер накладной"",
                    o.customer_name AS ""Заказчик"",
                    oi.invoice_date AS ""Дата накладной"",
                    oi.notes AS ""Примечания""
                FROM 
                    OutgoingInvoices oi
                    JOIN Orders o ON oi.order_id = o.order_id
                ORDER BY 
                    oi.invoice_date DESC";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }

                    dataGridViewInvoices.DataSource = dt;

                    // Скрываем outgoing_id (он нужен только для запросов)
                    dataGridViewInvoices.Columns["outgoing_id"].Visible = false;

                    // Устанавливаем порядок столбцов
                    dataGridViewInvoices.Columns["Номер накладной"].DisplayIndex = 0;
                    dataGridViewInvoices.Columns["Заказчик"].DisplayIndex = 1;
                    dataGridViewInvoices.Columns["Дата накладной"].DisplayIndex = 2;
                    dataGridViewInvoices.Columns["Примечания"].DisplayIndex = 3;
                }

                // Форматирование дат
                foreach (DataGridViewColumn column in dataGridViewInvoices.Columns)
                {
                    if (column.ValueType == typeof(DateTime))
                    {
                        column.DefaultCellStyle.Format = "dd.MM.yyyy";
                    }
                }

                dataGridViewInvoices.AutoResizeColumns();
                dataGridViewInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Настройка выделения строк
                dataGridViewInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewInvoices.MultiSelect = false;
                dataGridViewInvoices.CellClick += DataGridViewInvoices_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке накладных: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отбработчик тыка в dataGridViewInvoices
        /// </summary>
        private void DataGridViewInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Fill_dataGridViewInvoicesItems(sender, e);
        }

        /// <summary>
        /// Отображение элементов накладной в dataGridViewInvoicesItems по тыкнутой в dataGridViewInvoices накладной
        /// </summary>
        private void Fill_dataGridViewInvoicesItems(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Если кликнули по заголовку

            try
            {
                string selectedType = comboBoxInvoices.SelectedItem.ToString();
                DataGridViewRow row = dataGridViewInvoices.Rows[e.RowIndex];

                string query;
                if (selectedType == "Приходная накладная")
                {
                    int invoiceId = Convert.ToInt32(row.Cells["invoice_id"].Value);
                    query = @"
                    SELECT 
                        m.material_name AS ""Материал"",
                        ii.quantity AS ""Количество"",
                        m.unit AS ""Единица измерения"",
                        ii.unit_price AS ""Цена за единицу"",
                        (ii.quantity * ii.unit_price) AS ""Сумма""
                    FROM 
                        IncomingItems ii
                        JOIN Material m ON ii.material_id = m.material_id
                    WHERE 
                        ii.invoice_id = @invoiceId";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewInvoicesItems.DataSource = dt;
                        }
                    }
                }
                else // Расходная накладная
                {
                    int outgoingId = Convert.ToInt32(row.Cells["outgoing_id"].Value);
                    query = @"
                    SELECT 
                        m.material_name AS ""Материал"",
                        oi.quantity AS ""Количество"",
                        m.unit AS ""Единица измерения"",
                        oi.unit_price AS ""Цена за единицу"",
                        (oi.quantity * oi.unit_price) AS ""Сумма""
                    FROM 
                        OutgoingItems oi
                        JOIN Material m ON oi.material_id = m.material_id
                    WHERE 
                        oi.outgoing_id = @outgoingId";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@outgoingId", outgoingId);
                        using (var adapter = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewInvoicesItems.DataSource = dt;
                        }
                    }
                }

                // Форматирование числовых столбцов
                foreach (DataGridViewColumn column in dataGridViewInvoicesItems.Columns)
                {
                    if (column.Name == "Цена за единицу" || column.Name == "Сумма")
                    {
                        column.DefaultCellStyle.Format = "N2";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else if (column.Name == "Количество")
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                dataGridViewInvoicesItems.AutoResizeColumns();
                dataGridViewInvoicesItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Настройка выделения строк
                dataGridViewInvoicesItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewInvoicesItems.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке состава накладной: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление элемента из накладной
        /// </summary>
        private void AddItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выделенная строка в dataGridViewInvoices
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите накладную для добавления элемента.", "Информация",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Получаем выбранную строку
            DataGridViewRow selectedRow = dataGridViewInvoices.SelectedRows[0];
            string invoiceType = comboBoxInvoices.SelectedItem.ToString();

            try
            {
                if (invoiceType == "Приходная накладная")
                {
                    // Получаем ID приходной накладной
                    int invoiceId = Convert.ToInt32(selectedRow.Cells["invoice_id"].Value);

                    // Создаем и показываем форму для добавления элемента приходной накладной
                    AddEditInvoiceItemForm addForm = new AddEditInvoiceItemForm(connection, invoiceId, true);
                    addForm.ShowDialog();
                }
                else // Расходная накладная
                {
                    // Получаем ID расходной накладной
                    int outgoingId = Convert.ToInt32(selectedRow.Cells["outgoing_id"].Value);

                    // Создаем и показываем форму для добавления элемента расходной накладной
                    AddEditInvoiceItemForm addForm = new AddEditInvoiceItemForm(connection, outgoingId, false);
                    addForm.ShowDialog();
                }

                // Обновляем список элементов накладной после добавления
                if (dataGridViewInvoices.SelectedRows.Count > 0)
                {
                    Fill_dataGridViewInvoicesItems(dataGridViewInvoices,
                        new DataGridViewCellEventArgs(0, dataGridViewInvoices.SelectedRows[0].Index));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы добавления элемента: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Изменение элемента из накладной
        /// </summary>
        private void ChangeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выделенная строка в dataGridViewInvoices (накладная)
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите накладную.", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Проверяем, есть ли выделенный элемент в dataGridViewInvoicesItems
            if (dataGridViewInvoicesItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите элемент накладной для редактирования.", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string invoiceType = comboBoxInvoices.SelectedItem.ToString();
            DataGridViewRow selectedInvoiceRow = dataGridViewInvoices.SelectedRows[0];
            DataGridViewRow selectedItemRow = dataGridViewInvoicesItems.SelectedRows[0];

            try
            {
                if (invoiceType == "Приходная накладная")
                {
                    int invoiceId = Convert.ToInt32(selectedInvoiceRow.Cells["invoice_id"].Value);

                    // Получаем ID элемента накладной (нужно добавить этот столбец в запрос)
                    string materialName = selectedItemRow.Cells["Материал"].Value.ToString();
                    string quantity = selectedItemRow.Cells["Количество"].Value.ToString();

                    // Запрос для получения item_id выбранного элемента
                    string query = @"SELECT ii.item_id 
                            FROM IncomingItems ii
                            JOIN Material m ON ii.material_id = m.material_id
                            WHERE ii.invoice_id = @invoiceId 
                            AND m.material_name = @materialName
                            AND ii.quantity = @quantity";

                    int itemId = 0;
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                        cmd.Parameters.AddWithValue("@materialName", materialName);
                        cmd.Parameters.AddWithValue("@quantity", decimal.Parse(quantity));

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            itemId = Convert.ToInt32(result);
                        }
                    }

                    if (itemId == 0)
                    {
                        MessageBox.Show("Не удалось найти ID элемента для редактирования.", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Открываем форму в режиме редактирования
                    AddEditInvoiceItemForm editForm = new AddEditInvoiceItemForm(connection, invoiceId, true, true, itemId);
                    editForm.ShowDialog();
                }
                else // Расходная накладная
                {
                    int outgoingId = Convert.ToInt32(selectedInvoiceRow.Cells["outgoing_id"].Value);

                    // Получаем ID элемента накладной (нужно добавить этот столбец в запрос)
                    string materialName = selectedItemRow.Cells["Материал"].Value.ToString();
                    string quantity = selectedItemRow.Cells["Количество"].Value.ToString();

                    // Запрос для получения item_id выбранного элемента
                    string query = @"SELECT oi.item_id 
                            FROM OutgoingItems oi
                            JOIN Material m ON oi.material_id = m.material_id
                            WHERE oi.outgoing_id = @outgoingId 
                            AND m.material_name = @materialName
                            AND oi.quantity = @quantity";

                    int itemId = 0;
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@outgoingId", outgoingId);
                        cmd.Parameters.AddWithValue("@materialName", materialName);
                        cmd.Parameters.AddWithValue("@quantity", decimal.Parse(quantity));

                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            itemId = Convert.ToInt32(result);
                        }
                    }

                    if (itemId == 0)
                    {
                        MessageBox.Show("Не удалось найти ID элемента для редактирования.", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Открываем форму в режиме редактирования
                    AddEditInvoiceItemForm editForm = new AddEditInvoiceItemForm(connection, outgoingId, false, true, itemId);
                    editForm.ShowDialog();
                }

                // Обновляем список элементов накладной после редактирования
                if (dataGridViewInvoices.SelectedRows.Count > 0)
                {
                    Fill_dataGridViewInvoicesItems(dataGridViewInvoices,
                        new DataGridViewCellEventArgs(0, dataGridViewInvoices.SelectedRows[0].Index));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы редактирования элемента: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление элемента из накладной
        /// </summary>
        private void RemoveItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выделенная строка в dataGridViewInvoices (накладная)
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите накладную.", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Проверяем, есть ли выделенный элемент в dataGridViewInvoicesItems
            if (dataGridViewInvoicesItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите элемент накладной для удаления.", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Запрашиваем подтверждение удаления
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранный элемент?", "Подтверждение удаления",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                return;
            }

            string invoiceType = comboBoxInvoices.SelectedItem.ToString();
            DataGridViewRow selectedInvoiceRow = dataGridViewInvoices.SelectedRows[0];
            DataGridViewRow selectedItemRow = dataGridViewInvoicesItems.SelectedRows[0];

            try
            {
                if (invoiceType == "Приходная накладная")
                {
                    int invoiceId = Convert.ToInt32(selectedInvoiceRow.Cells["invoice_id"].Value);
                    string materialName = selectedItemRow.Cells["Материал"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(selectedItemRow.Cells["Количество"].Value);

                    // Получаем ID элемента для удаления
                    string getItemIdQuery = @"SELECT ii.item_id 
                                   FROM IncomingItems ii
                                   JOIN Material m ON ii.material_id = m.material_id
                                   WHERE ii.invoice_id = @invoiceId 
                                   AND m.material_name = @materialName
                                   AND ii.quantity = @quantity";

                    int itemId;
                    using (var cmd = new NpgsqlCommand(getItemIdQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                        cmd.Parameters.AddWithValue("@materialName", materialName);
                        cmd.Parameters.AddWithValue("@quantity", quantity);

                        itemId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Удаляем элемент
                    string deleteQuery = "DELETE FROM IncomingItems WHERE item_id = @itemId";
                    using (var cmd = new NpgsqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@itemId", itemId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else // Расходная накладная
                {
                    int outgoingId = Convert.ToInt32(selectedInvoiceRow.Cells["outgoing_id"].Value);
                    string materialName = selectedItemRow.Cells["Материал"].Value.ToString();
                    decimal quantity = Convert.ToDecimal(selectedItemRow.Cells["Количество"].Value);

                    // Получаем ID элемента для удаления
                    string getItemIdQuery = @"SELECT oi.item_id 
                                   FROM OutgoingItems oi
                                   JOIN Material m ON oi.material_id = m.material_id
                                   WHERE oi.outgoing_id = @outgoingId 
                                   AND m.material_name = @materialName
                                   AND oi.quantity = @quantity";

                    int itemId;
                    using (var cmd = new NpgsqlCommand(getItemIdQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@outgoingId", outgoingId);
                        cmd.Parameters.AddWithValue("@materialName", materialName);
                        cmd.Parameters.AddWithValue("@quantity", quantity);

                        itemId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Удаляем элемент
                    string deleteQuery = "DELETE FROM OutgoingItems WHERE item_id = @itemId";
                    using (var cmd = new NpgsqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@itemId", itemId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Обновляем список элементов накладной после удаления
                Fill_dataGridViewInvoicesItems(dataGridViewInvoices,
                    new DataGridViewCellEventArgs(0, dataGridViewInvoices.SelectedRows[0].Index));

                MessageBox.Show("Элемент успешно удален.", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении элемента: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Добавление накладной
        /// </summary>
        private void AddInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string invoiceType = comboBoxInvoices.SelectedItem.ToString();

            try
            {
                if (invoiceType == "Приходная накладная")
                {
                    AddEditInvoiceForm form = new AddEditInvoiceForm(connection, true);
                    form.ShowDialog();                    
                }
                else
                {
                    AddEditInvoiceForm form = new AddEditInvoiceForm(connection, false);
                    form.ShowDialog();                    
                }

                Fill_dataGridViewInvoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении накладной: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Изменение накладной
        /// </summary>
        private void ChangeInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите накладную для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string invoiceType = comboBoxInvoices.SelectedItem.ToString();
            DataGridViewRow selectedRow = dataGridViewInvoices.SelectedRows[0];

            try
            {
                if (invoiceType == "Приходная накладная")
                {
                    int invoiceId = Convert.ToInt32(selectedRow.Cells["invoice_id"].Value);
                    AddEditInvoiceForm form = new AddEditInvoiceForm(connection, true, true, invoiceId);
                    form.ShowDialog();
                }
                else
                {
                    int outgoingId = Convert.ToInt32(selectedRow.Cells["outgoing_id"].Value);
                    AddEditInvoiceForm form = new AddEditInvoiceForm(connection, false, true, outgoingId);
                    form.ShowDialog();
                }

                Fill_dataGridViewInvoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании накладной: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление накладной
        /// </summary>
        private void RemoveInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите накладную для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную накладную?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            string invoiceType = comboBoxInvoices.SelectedItem.ToString();
            DataGridViewRow selectedRow = dataGridViewInvoices.SelectedRows[0];

            try
            {
                if (invoiceType == "Приходная накладная")
                {
                    int invoiceId = Convert.ToInt32(selectedRow.Cells["invoice_id"].Value);
                    string deleteItems = "DELETE FROM IncomingItems WHERE invoice_id = @id";
                    string deleteInvoice = "DELETE FROM IncomingInvoices WHERE invoice_id = @id";

                    using (var cmd = new NpgsqlCommand(deleteItems, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", invoiceId);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new NpgsqlCommand(deleteInvoice, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", invoiceId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    int outgoingId = Convert.ToInt32(selectedRow.Cells["outgoing_id"].Value);
                    string deleteItems = "DELETE FROM OutgoingItems WHERE outgoing_id = @id";
                    string deleteInvoice = "DELETE FROM OutgoingInvoices WHERE outgoing_id = @id";

                    using (var cmd = new NpgsqlCommand(deleteItems, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", outgoingId);
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new NpgsqlCommand(deleteInvoice, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", outgoingId);
                        cmd.ExecuteNonQuery();
                    }
                }

                Fill_dataGridViewInvoices();
                dataGridViewInvoicesItems.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении накладной: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}