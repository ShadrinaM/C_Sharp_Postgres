using Npgsql;
using System;
using System.Windows.Forms;

namespace AtelierPro.AddEditFormForTables
{
    public partial class AddEditSupplierForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int supplierId;

        public AddEditSupplierForm(NpgsqlConnection conn, bool editMode = false, int existingSupplierId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.supplierId = existingSupplierId;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureForm();

            if (isEditMode)
                LoadExistingSupplier();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование поставщика" : "Добавление поставщика";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
        }

        private void LoadExistingSupplier()
        {
            try
            {
                string query = @"SELECT supplier_name, contact_person, phone, email, address, notes 
                                 FROM Suppliers 
                                 WHERE supplier_id = @supplierId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@supplierId", supplierId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtSupplierName.Text = reader.GetString(0);
                            txtContactPerson.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            txtPhone.Text = reader.IsDBNull(2) ? "" : reader.GetString(2);
                            txtEmail.Text = reader.IsDBNull(3) ? "" : reader.GetString(3);
                            txtAddress.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                            txtNotes.Text = reader.IsDBNull(5) ? "" : reader.GetString(5);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных поставщика: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Название поставщика является обязательным полем.");
                return;
            }

            try
            {
                string name = txtSupplierName.Text;
                string contactPerson = txtContactPerson.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string address = txtAddress.Text;
                string notes = txtNotes.Text;

                if (isEditMode)
                    UpdateSupplier(name, contactPerson, phone, email, address, notes);
                else
                    InsertSupplier(name, contactPerson, phone, email, address, notes);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertSupplier(string name, string contactPerson, string phone, string email, string address, string notes)
        {
            string query = @"INSERT INTO Suppliers (supplier_name, contact_person, phone, email, address, notes)
                             VALUES (@name, @contactPerson, @phone, @email, @address, @notes)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@contactPerson", (object)contactPerson ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", (object)phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@address", (object)address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Поставщик добавлен успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateSupplier(string name, string contactPerson, string phone, string email, string address, string notes)
        {
            string query = @"UPDATE Suppliers 
                             SET supplier_name = @name, 
                                 contact_person = @contactPerson,
                                 phone = @phone,
                                 email = @email,
                                 address = @address,
                                 notes = @notes
                             WHERE supplier_id = @supplierId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@contactPerson", (object)contactPerson ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", (object)phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@address", (object)address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@notes", (object)notes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@supplierId", supplierId);
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