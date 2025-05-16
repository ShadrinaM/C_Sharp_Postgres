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

namespace PochitaikinLibrary
{
    public partial class ReturnBook : Form
    {
        private NpgsqlConnection connection;
        private Menu mainForm;

        public ReturnBook(NpgsqlConnection conn, Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += WinForm_FormClosed;
            connection = conn;
        }

        private void WinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            // Загрузка данных при открытии формы
            LoadUniversities();
        }

        // Загрузка списка университетов
        private void LoadUniversities()
        {
            try
            {
                string query = "SELECT university_id, name FROM universities ORDER BY name";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        comboBoxUniversities.Items.Clear();
                        while (reader.Read())
                        {
                            comboBoxUniversities.Items.Add(new KeyValuePair<int, string>(
                                reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
                comboBoxUniversities.DisplayMember = "Value";
                comboBoxUniversities.ValueMember = "Key";

                if (comboBoxUniversities.Items.Count > 0)
                    comboBoxUniversities.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке университетов: {ex.Message}");
            }
        }

        // Обработчик изменения выбранного университета
        private void comboBoxUniversities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUniversities.SelectedItem is KeyValuePair<int, string> selectedUniv)
            {
                LoadStudents(selectedUniv.Key);
            }
        }

        // Загрузка студентов выбранного университета
        private void LoadStudents(int universityId)
        {
            try
            {
                string query = "SELECT student_id, full_name FROM students WHERE university_id = @universityId ORDER BY full_name";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@universityId", universityId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        comboBoxStudents.Items.Clear();
                        while (reader.Read())
                        {
                            comboBoxStudents.Items.Add(new KeyValuePair<int, string>(
                                reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
                comboBoxStudents.DisplayMember = "Value";
                comboBoxStudents.ValueMember = "Key";

                if (comboBoxStudents.Items.Count > 0)
                    comboBoxStudents.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке студентов: {ex.Message}");
            }
        }

        // Обработчик изменения выбранного студента
        private void comboBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem is KeyValuePair<int, string> selectedStudent)
            {
                LoadStudentBooks(selectedStudent.Key);
            }
        }

        // Загрузка книг выбранного студента
        private void LoadStudentBooks(int studentId)
        {
            try
            {
                string query = @"SELECT b.book_id, b.title, l.issue_date, l.due_date 
                                FROM loans l
                                JOIN books b ON l.book_id = b.book_id
                                WHERE l.student_id = @studentId AND l.return_date IS NULL
                                ORDER BY l.due_date";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewBook.DataSource = dt;

                        // Настройка заголовков столбцов
                        if (dataGridViewBook.Columns.Count > 0)
                        {
                            dataGridViewBook.Columns["book_id"].HeaderText = "ID книги";
                            dataGridViewBook.Columns["title"].HeaderText = "Название";
                            dataGridViewBook.Columns["issue_date"].HeaderText = "Дата выдачи";
                            dataGridViewBook.Columns["due_date"].HeaderText = "Срок возврата";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке книг студента: {ex.Message}");
            }
        }




    }
}
