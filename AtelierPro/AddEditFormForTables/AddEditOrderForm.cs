using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AtelierPro.AddEditFormForTables
{
    public partial class AddEditOrderForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int orderId;

        public AddEditOrderForm(NpgsqlConnection conn, bool editMode = false, int existingOrderId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.orderId = existingOrderId;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureForm();

            if (isEditMode)
                LoadExistingOrder();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование заказа" : "Добавление заказа";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
        }

        private void LoadExistingOrder()
        {
            try
            {
                string query = @"SELECT customer_name, order_date, delivery_date, status, notes 
                                 FROM Orders 
                                 WHERE order_id = @orderId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxCustomerName.Text = reader.GetString(0);
                            dateTimePickerOrderDate.Value = reader.GetDateTime(1);
                            dateTimePickerDeliveryDate.Value = reader.GetDateTime(2);
                            comboBoxStatus.SelectedItem = reader.GetString(3);
                            textBoxNotes.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных заказа: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCustomerName.Text))
            {
                MessageBox.Show("Имя заказчика является обязательным полем.");
                return;
            }

            try
            {
                string customerName = textBoxCustomerName.Text;
                DateTime orderDate = dateTimePickerOrderDate.Value;
                DateTime deliveryDate = dateTimePickerDeliveryDate.Value;
                string status = comboBoxStatus.SelectedItem?.ToString() ?? "Новый";
                string notes = textBoxNotes.Text;

                if (isEditMode)
                    UpdateOrder(customerName, orderDate, deliveryDate, status, notes);
                else
                    InsertOrder(customerName, orderDate, deliveryDate, status, notes);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertOrder(string customerName, DateTime orderDate, DateTime deliveryDate, string status, string notes)
        {
            string query = @"INSERT INTO Orders (customer_name, order_date, delivery_date, status, notes)
                             VALUES (@customerName, @orderDate, @deliveryDate, @status, @notes)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@customerName", customerName);
                cmd.Parameters.AddWithValue("@orderDate", orderDate);
                cmd.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Заказ добавлен успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateOrder(string customerName, DateTime orderDate, DateTime deliveryDate, string status, string notes)
        {
            string query = @"UPDATE Orders 
                             SET customer_name = @customerName, 
                                 order_date = @orderDate,
                                 delivery_date = @deliveryDate,
                                 status = @status,
                                 notes = @notes
                             WHERE order_id = @orderId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@customerName", customerName);
                cmd.Parameters.AddWithValue("@orderDate", orderDate);
                cmd.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@orderId", orderId);
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
