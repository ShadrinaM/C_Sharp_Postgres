using Npgsql;
using System;
using System.Windows.Forms;

namespace PochitaikinLibrary.Forms
{
    public partial class UniversityForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int universityId;

        public UniversityForm(NpgsqlConnection conn, bool editMode = false, int existingUniversityId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.universityId = existingUniversityId;

            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigureForm();

            if (isEditMode)
                LoadExistingUniversity();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование университета" : "Добавление университета";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
            labelHeader.Text = isEditMode ? "Редактирование университета" : "Добавление университета";
        }

        private void LoadExistingUniversity()
        {
            try
            {
                string query = @"SELECT name FROM universities WHERE university_id = @universityId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@universityId", universityId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxName.Text = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных университета: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Заполните обязательное поле: Название.");
                return;
            }

            try
            {
                string name = textBoxName.Text.Trim();

                if (isEditMode)
                    UpdateUniversity(name);
                else
                    InsertUniversity(name);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertUniversity(string name)
        {
            string query = @"INSERT INTO universities (name) VALUES (@name)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Университет добавлен успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateUniversity(string name)
        {
            string query = @"UPDATE universities SET name = @name WHERE university_id = @universityId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@universityId", universityId);
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