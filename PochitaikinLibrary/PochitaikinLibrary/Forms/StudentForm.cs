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

namespace PochitaikinLibrary.Forms
{
    public partial class StudentForm : Form
    {
        private readonly NpgsqlConnection connection;
        private readonly bool isEditMode;
        private readonly int studentId;
        private Dictionary<int, string> universities = new Dictionary<int, string>();

        public StudentForm(NpgsqlConnection conn, bool editMode = false, int existingStudentId = 0)
        {
            InitializeComponent();
            this.connection = conn;
            this.isEditMode = editMode;
            this.studentId = existingStudentId;

            this.StartPosition = FormStartPosition.CenterScreen;
            LoadUniversities();
            ConfigureForm();

            if (isEditMode)
                LoadExistingStudent();
        }

        private void ConfigureForm()
        {
            this.Text = isEditMode ? "Редактирование студента" : "Добавление студента";
            btnOK.Text = isEditMode ? "Сохранить изменения" : "Добавить";
        }

        private void LoadUniversities()
        {
            try
            {
                comboBoxUniversity.Items.Clear();
                universities.Clear();

                string query = "SELECT university_id, name FROM Universities ORDER BY name";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        universities.Add(id, name);
                        comboBoxUniversity.Items.Add(new KeyValuePair<int, string>(id, name));
                    }
                }

                comboBoxUniversity.DisplayMember = "Value";
                comboBoxUniversity.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки университетов: " + ex.Message);
            }
        }

        private void LoadExistingStudent()
        {
            try
            {
                string query = @"SELECT full_name, university_id 
                                 FROM students 
                                 WHERE student_id = @studentId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxFullName.Text = reader.GetString(0);
                            int universityId = reader.GetInt32(1);

                            // Выбор университета в ComboBox
                            for (int i = 0; i < comboBoxUniversity.Items.Count; i++)
                            {
                                var item = (KeyValuePair<int, string>)comboBoxUniversity.Items[i];
                                if (item.Key == universityId)
                                {
                                    comboBoxUniversity.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных студента: " + ex.Message);
                this.Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFullName.Text) || comboBoxUniversity.SelectedItem == null)
            {
                MessageBox.Show("Заполните обязательные поля: ФИО и университет.");
                return;
            }

            try
            {
                string fullName = textBoxFullName.Text;
                int universityId = ((KeyValuePair<int, string>)comboBoxUniversity.SelectedItem).Key;

                if (isEditMode)
                    UpdateStudent(fullName, universityId);
                else
                    InsertStudent(fullName, universityId);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void InsertStudent(string fullName, int universityId)
        {
            string query = @"INSERT INTO students (full_name, university_id)
                             VALUES (@fullName, @universityId)";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@universityId", universityId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Студент добавлен успешно.");
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateStudent(string fullName, int universityId)
        {
            string query = @"UPDATE students 
                             SET full_name = @fullName, 
                                 university_id = @universityId
                             WHERE student_id = @studentId";

            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@fullName", fullName);
                cmd.Parameters.AddWithValue("@universityId", universityId);
                cmd.Parameters.AddWithValue("@studentId", studentId);
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
