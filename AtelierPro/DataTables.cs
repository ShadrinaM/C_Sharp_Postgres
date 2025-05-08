using AtelierPro.AddEditFormForTables;
using Npgsql;
using System.Data;

namespace AtelierPro
{
    public partial class DataTables : Form
    {
        private NpgsqlConnection connection;
        private Menu mainForm;

        public DataTables(NpgsqlConnection conn, Menu menushka)
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
            mainForm.Show();
        }

        /// <summary>
        /// Закрытие окна по кнопке btnBack
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        /// <summary>
        /// Преднастройка формы 
        /// </summary>
        private void DataTables_Load(object sender, EventArgs e)
        {
            // Заполнение и преднастройка comboBoxTables
            Dictionary<string, string> tableNames = new Dictionary<string, string>
            {
                {"Изделия", "view_products"},
                {"Поставщики", "view_suppliers"},
                {"Заказы", "view_orders"},
                {"Материалы", "view_materials"},
                {"Приходные накладные", "view_incominginvoices"},
                {"Расходные накладные", "view_outgoinginvoices"},
                {"Материалы на изделие", "view_materialforproduct"},
                {"Позиции приходных накладных", "view_incomingitems"},
                {"Позиции расходных накладных", "view_outgoingitems"}
            };
            foreach (var kvp in tableNames)
            {
                comboBoxTables.Items.Add($"{kvp.Key} ({kvp.Value})");
            }
            if (comboBoxTables.Items.Count > 0)
            {
                comboBoxTables.SelectedIndex = 0;
            }
            // Предзагрузка dataGridView
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
        }

        /// <summary>
        /// Обработчик выбора таблицы в comboBoxTables
        /// </summary>
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            int startIndex = selectedTable.IndexOf('(') + 1;
            int endIndex = selectedTable.IndexOf(')', startIndex);
            string viewName = selectedTable.Substring(startIndex, endIndex - startIndex).ToLower();

            try
            {
                RefreshDataGridView(viewName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки представления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление DataGridView
        /// </summary>
        private void RefreshDataGridView(string viewName)
        {
            try
            {
                // Очищаем текущий источник данных
                dataGridView.DataSource = null;

                string query = $"SELECT * FROM \"{viewName}\"";
                using (var adapter = new NpgsqlDataAdapter(query, connection))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;

                    // Скрываем столбцы с ID после привязки данных
                    HideIdColumns(viewName);
                }

                // Принудительное обновление
                dataGridView.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        /// <summary>
        /// Скрытие id полей для каждого представления из DataGridView
        /// </summary>
        private void HideIdColumns(string viewName)
        {
            // Словарь соответствия имен представлений и названий столбцов ID
            var idColumns = new Dictionary<string, string>
            {
                {"view_products", "product_id"},
                {"view_incominginvoices", "invoice_id"},
                {"view_outgoinginvoices", "outgoing_id"},
                {"view_incomingitems", "item_id"},
                {"view_outgoingitems", "item_id"},
                {"view_materialforproduct", "usage_id"},
                {"view_suppliers", "supplier_id"},
                {"view_orders", "order_id"},
                {"view_materials", "material_id"}
            };

            if (idColumns.TryGetValue(viewName, out var columnName))
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns[columnName].Visible = false;
                }
            }
        }


        // CRUD для Product
        private bool IsProductsTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;

            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("view_products");
        }
        private void AddProduct()
        {
            var addForm = new AddEditProductForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_products"); // Обновляем текущее выбранное представление
            }
        }
        private void EditProduct()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите изделие для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);

            var editForm = new AddEditProductForm(connection, true, productId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // Обновляем данные после редактирования
                RefreshDataGridView("view_products");
            }
        }
        private void DeleteProduct()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите изделие для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);
            string productName = selectedRow.Cells["изделие"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить изделие \"{productName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM products WHERE product_id = @productId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productId", productId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Изделие успешно удалено", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем данные после удаления
                    RefreshDataGridView("view_products");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении изделия: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // CRUD для Suppliers
        private bool IsSuppliersTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;

            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("view_suppliers");
        }
        private void AddSupplier()
        {
            var addForm = new AddEditSupplierForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_suppliers");
            }
        }
        private void EditSupplier()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите поставщика для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int supplierId = Convert.ToInt32(selectedRow.Cells["supplier_id"].Value);

            var editForm = new AddEditSupplierForm(connection, true, supplierId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_suppliers");
            }
        }
        private void DeleteSupplier()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите поставщика для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int supplierId = Convert.ToInt32(selectedRow.Cells["supplier_id"].Value);
            string supplierName = selectedRow.Cells["Наименование"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить поставщика \"{supplierName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Suppliers WHERE supplier_id = @supplierId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@supplierId", supplierId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Поставщик успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataGridView("view_suppliers");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении поставщика: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // CRUD для Materials
        private bool IsMaterialsTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;

            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("view_materials");
        }
        private void AddMaterial()
        {
            var addForm = new AddEditMaterialForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_materials");
            }
        }
        private void EditMaterial()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите материал для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int materialId = Convert.ToInt32(selectedRow.Cells["material_id"].Value);

            var editForm = new AddEditMaterialForm(connection, true, materialId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_materials");
            }
        }
        private void DeleteMaterial()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите материал для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int materialId = Convert.ToInt32(selectedRow.Cells["material_id"].Value);
            string materialName = selectedRow.Cells["Наименование"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить материал \"{materialName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Material WHERE material_id = @materialId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@materialId", materialId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Материал успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataGridView("view_materials");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении материала: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // CRUD для MaterialUsage
        private bool IsMaterialUsageTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;

            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("view_materialforproduct");
        }
        private void AddMaterialUsage()
        {
            var addForm = new AddEditMaterialUsageForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_materialforproduct");
            }
        }
        private void EditMaterialUsage()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись о расходе для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int usageId = Convert.ToInt32(selectedRow.Cells["usage_id"].Value);

            var editForm = new AddEditMaterialUsageForm(connection, true, usageId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_materialforproduct");
            }
        }
        private void DeleteMaterialUsage()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись о расходе для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int usageId = Convert.ToInt32(selectedRow.Cells["usage_id"].Value);
            string productName = selectedRow.Cells["Изделие"].Value.ToString();
            string materialName = selectedRow.Cells["Материал"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить запись о расходе материала \"{materialName}\" для изделия \"{productName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM MaterialForProduct WHERE usage_id = @usageId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usageId", usageId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Запись о расходе материала успешно удалена", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataGridView("view_materialforproduct");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении записи: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // CRUD для Order
        private bool IsOrdersTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;

            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("view_orders");
        }
        private void AddOrder()
        {
            var addForm = new AddEditOrderForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_orders");
            }
        }
        private void EditOrder()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int orderId = Convert.ToInt32(selectedRow.Cells["order_id"].Value);

            var editForm = new AddEditOrderForm(connection, true, orderId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("view_orders");
            }
        }
        private void DeleteOrder()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int orderId = Convert.ToInt32(selectedRow.Cells["order_id"].Value);
            string customerName = selectedRow.Cells["Заказчик"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить заказ от \"{customerName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM Orders WHERE order_id = @orderId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Заказ успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataGridView("view_orders");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении заказа: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Обработчики StripMenu
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsProductsTableSelected())
            {
                AddProduct();
            }
            else if (IsSuppliersTableSelected())
            {
                AddSupplier();
            }
            else if (IsMaterialsTableSelected())
            {
                AddMaterial();
            }
            else if (IsOrdersTableSelected())
            {
                AddOrder();
            }
            else if (IsMaterialUsageTableSelected())
            {
                AddMaterialUsage();
            }
            else
            {
                MessageBox.Show("Функция добавления для этой таблицы реализована в разделе Накладные", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ChangeElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsProductsTableSelected())
            {
                EditProduct();
            }
            else if (IsSuppliersTableSelected())
            {
                EditSupplier();
            }
            else if (IsMaterialsTableSelected())
            {
                EditMaterial();
            }
            else if (IsOrdersTableSelected())
            {
                EditOrder();
            }
            else if (IsMaterialUsageTableSelected())
            {
                EditMaterialUsage();
            }
            else
            {
                MessageBox.Show("Функция редактирования для этой таблицы реализована в разделе Накладные", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void RemoveElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsProductsTableSelected())
            {
                DeleteProduct();
            }
            else if (IsSuppliersTableSelected())
            {
                DeleteSupplier();
            }
            else if (IsMaterialsTableSelected())
            {
                DeleteMaterial();
            }
            else if (IsOrdersTableSelected())
            {
                DeleteOrder();
            }
            else if (IsMaterialUsageTableSelected())
            {
                DeleteMaterialUsage();
            }
            else
            {
                MessageBox.Show("Функция удаления для этой таблицы реализована в разделе Накладные", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}