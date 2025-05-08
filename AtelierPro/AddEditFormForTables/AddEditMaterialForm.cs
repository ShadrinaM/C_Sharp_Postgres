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
    public partial class AddEditMaterialForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int materialId;

        public AddEditMaterialForm(NpgsqlConnection conn, bool editMode = false, int existingMaterialId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.materialId = existingMaterialId;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureForm();
            LoadMaterialTypes();

            if (isEditMode)
                LoadExistingMaterial();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование материала" : "Добавление материала";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
        }

        private void LoadMaterialTypes()
        {
            comboBoxMaterialType.Items.AddRange(new object[] { "ткань", "фурнитура", "прочее" });
        }

        private void LoadExistingMaterial()
        {
            try
            {
                string query = @"SELECT material_name, material_type, unit, notes 
                                FROM Material 
                                WHERE material_id = @materialId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@materialId", materialId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxMaterialName.Text = reader.GetString(0);
                            comboBoxMaterialType.SelectedItem = reader.GetString(1);
                            textBoxUnit.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            textBoxNotes.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки материала: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxMaterialName.Text))
            {
                MessageBox.Show("Название материала является обязательным полем.");
                return;
            }

            try
            {
                string name = textBoxMaterialName.Text;
                string type = comboBoxMaterialType.SelectedItem?.ToString();
                string unit = textBoxUnit.Text;
                string notes = textBoxNotes.Text;

                if (isEditMode)
                    UpdateMaterial(name, type, unit, notes);
                else
                    InsertMaterial(name, type, unit, notes);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertMaterial(string name, string type, string unit, string notes)
        {
            string query = @"INSERT INTO Material (material_name, material_type, unit, notes)
                             VALUES (@name, @type, @unit, @notes)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", (object)type ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@unit", (object)unit ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Материал добавлен успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateMaterial(string name, string type, string unit, string notes)
        {
            string query = @"UPDATE Material 
                             SET material_name = @name, 
                                 material_type = @type,
                                 unit = @unit,
                                 notes = @notes
                             WHERE material_id = @materialId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", (object)type ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@unit", (object)unit ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@materialId", materialId);
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
