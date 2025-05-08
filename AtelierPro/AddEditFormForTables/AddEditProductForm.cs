using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AtelierPro
{
    public partial class AddEditProductForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int productId;

        public AddEditProductForm(NpgsqlConnection conn, bool editMode = false, int existingProductId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.productId = existingProductId;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureForm();
            LoadOrders();

            if (isEditMode)
                LoadExistingProduct();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование изделия" : "Добавление изделия";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
        }

        private void LoadOrders()
        {
            try
            {
                comboBoxOrders.Items.Clear();

                string query = "SELECT order_id, customer_name FROM Orders ORDER BY order_id DESC";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxOrders.Items.Add(new KeyValuePair<int, string>(
                            reader.GetInt32(0),
                            $"#{reader.GetInt32(0)} - {reader.GetString(1)}"));
                    }
                }

                comboBoxOrders.DisplayMember = "Value";
                comboBoxOrders.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки заказов: " + ex.Message);
            }
        }

        private void LoadExistingProduct()
        {
            try
            {
                string query = @"SELECT order_id, product_name, size, base_price, complexity_level, notes 
                                 FROM Products 
                                 WHERE product_id = @productId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int orderId = reader.GetInt32(0);
                            textBoxName.Text = reader.GetString(1);
                            textBoxSize.Text = reader.GetString(2);
                            textBoxPrice.Text = reader.GetDecimal(3).ToString();
                            numericUpDownComplexity.Value = reader.GetInt32(4);
                            textBoxNotes.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);

                            // Выбор заказа в ComboBox
                            for (int i = 0; i < comboBoxOrders.Items.Count; i++)
                            {
                                var item = (KeyValuePair<int, string>)comboBoxOrders.Items[i];
                                if (item.Key == orderId)
                                {
                                    comboBoxOrders.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изделия: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxOrders.SelectedItem == null || string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Заполните обязательные поля: заказ и название изделия.");
                return;
            }

            try
            {
                int orderId = ((KeyValuePair<int, string>)comboBoxOrders.SelectedItem).Key;
                string name = textBoxName.Text;
                string size = textBoxSize.Text;
                decimal price = decimal.Parse(textBoxPrice.Text);
                int complexity = (int)numericUpDownComplexity.Value;
                string notes = textBoxNotes.Text;

                if (isEditMode)
                    UpdateProduct(orderId, name, size, price, complexity, notes);
                else
                    InsertProduct(orderId, name, size, price, complexity, notes);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertProduct(int orderId, string name, string size, decimal price, int complexity, string notes)
        {
            string query = @"INSERT INTO Products (order_id, product_name, size, base_price, complexity_level, notes)
                             VALUES (@orderId, @name, @size, @price, @complexity, @notes)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@complexity", complexity);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Изделие добавлено успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateProduct(int orderId, string name, string size, decimal price, int complexity, string notes)
        {
            string query = @"UPDATE Products 
                             SET order_id = @orderId, 
                                 product_name = @name,
                                 size = @size,
                                 base_price = @price,
                                 complexity_level = @complexity,
                                 notes = @notes
                             WHERE product_id = @productId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@orderId", orderId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@complexity", complexity);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Изменения успешно сохранены.");
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
