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

namespace AtelierPro
{
    public partial class AddInvoiceItemForm : Form
    {
        private NpgsqlConnection connection;
        private int invoiceId;
        private bool isIncoming;

        public AddInvoiceItemForm(NpgsqlConnection conn, int id, bool incoming)
        {
            InitializeComponent();
            connection = conn;
            invoiceId = id;
            isIncoming = incoming;
            this.StartPosition = FormStartPosition.CenterScreen;
            // Загрузка доступных материалов в ComboBox
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            // Загрузка списка материалов из базы данных
            string query = "SELECT material_id, material_name FROM Material ORDER BY material_name";

            using (var cmd = new NpgsqlCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    comboBoxMaterials.Items.Add(new KeyValuePair<int, string>(
                        reader.GetInt32(0),
                        reader.GetString(1)));
                }
            }

            comboBoxMaterials.DisplayMember = "Value";
            comboBoxMaterials.ValueMember = "Key";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверка введенных данных
            if (comboBoxMaterials.SelectedItem == null ||
                string.IsNullOrWhiteSpace(textBoxQuantity.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Получаем выбранный материал
                var selectedMaterial = (KeyValuePair<int, string>)comboBoxMaterials.SelectedItem;
                int materialId = selectedMaterial.Key;

                decimal quantity = decimal.Parse(textBoxQuantity.Text);
                decimal price = decimal.Parse(textBoxPrice.Text);

                // Вставляем запись в соответствующую таблицу
                string query;
                if (isIncoming)
                {
                    query = @"INSERT INTO IncomingItems (invoice_id, material_id, quantity, unit_price)
                          VALUES (@invoiceId, @materialId, @quantity, @price)";
                }
                else
                {
                    query = @"INSERT INTO OutgoingItems (outgoing_id, material_id, quantity, unit_price)
                          VALUES (@invoiceId, @materialId, @quantity, @price)";
                }

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                    cmd.Parameters.AddWithValue("@materialId", materialId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Элемент успешно добавлен в накладную.", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении элемента: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
