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

namespace AtelierPro.AddEditFormForTables
{
    public partial class AddEditMaterialUsageForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int usageId;

        public AddEditMaterialUsageForm(NpgsqlConnection conn, bool editMode = false, int existingUsageId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.usageId = existingUsageId;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureForm();
            LoadProducts();
            LoadMaterials();

            if (isEditMode)
                LoadExistingUsage();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование расхода материала" : "Добавление расхода материала";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
        }

        private void LoadProducts()
        {
            try
            {
                comboBoxProducts.Items.Clear();

                string query = "SELECT product_id, product_name FROM Products ORDER BY product_name";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxProducts.Items.Add(new KeyValuePair<int, string>(
                            reader.GetInt32(0),
                            reader.GetString(1)));
                    }
                }

                comboBoxProducts.DisplayMember = "Value";
                comboBoxProducts.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изделий: " + ex.Message);
            }
        }

        private void LoadMaterials()
        {
            try
            {
                comboBoxMaterials.Items.Clear();

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
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки материалов: " + ex.Message);
            }
        }

        private void LoadExistingUsage()
        {
            try
            {
                string query = @"SELECT product_id, material_id, quantity 
                                 FROM MaterialForProduct 
                                 WHERE usage_id = @usageId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@usageId", usageId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            numericUpDownQuantity.Value = Convert.ToDecimal(reader.GetDouble(2));

                            // Выбор продукта
                            int productId = reader.GetInt32(0);
                            for (int i = 0; i < comboBoxProducts.Items.Count; i++)
                            {
                                var item = (KeyValuePair<int, string>)comboBoxProducts.Items[i];
                                if (item.Key == productId)
                                {
                                    comboBoxProducts.SelectedIndex = i;
                                    break;
                                }
                            }

                            // Выбор материала
                            int materialId = reader.GetInt32(1);
                            for (int i = 0; i < comboBoxMaterials.Items.Count; i++)
                            {
                                var item = (KeyValuePair<int, string>)comboBoxMaterials.Items[i];
                                if (item.Key == materialId)
                                {
                                    comboBoxMaterials.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных расхода: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboBoxProducts.SelectedItem == null || comboBoxMaterials.SelectedItem == null)
            {
                MessageBox.Show("Выберите изделие и материал.");
                return;
            }

            try
            {
                int productId = ((KeyValuePair<int, string>)comboBoxProducts.SelectedItem).Key;
                int materialId = ((KeyValuePair<int, string>)comboBoxMaterials.SelectedItem).Key;
                decimal quantity = numericUpDownQuantity.Value;

                if (isEditMode)
                    UpdateUsage(productId, materialId, quantity);
                else
                    InsertUsage(productId, materialId, quantity);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertUsage(int productId, int materialId, decimal quantity)
        {
            string query = @"INSERT INTO MaterialForProduct (product_id, material_id, quantity)
                             VALUES (@productId, @materialId, @quantity)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@materialId", materialId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Расход материала добавлен успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateUsage(int productId, int materialId, decimal quantity)
        {
            string query = @"UPDATE MaterialForProduct 
                             SET product_id = @productId, 
                                 material_id = @materialId,
                                 quantity = @quantity
                             WHERE usage_id = @usageId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@materialId", materialId);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@usageId", usageId);
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
