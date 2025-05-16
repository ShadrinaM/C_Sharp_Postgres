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
    public partial class IssueBook : Form
    {
        private NpgsqlConnection connection;
        private Menu mainForm;

        public IssueBook(NpgsqlConnection conn, Menu menushka)
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


        private void IssueBook_Load(object sender, EventArgs e)
        {
            // Установка дат по умолчанию
            dtpIssueDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddMonths(1);

            // Загрузка данных при открытии формы
            LoadUniversities();
            LoadAvailableBooks();
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

        // Загрузка доступных книг
        private void LoadAvailableBooks()
        {
            try
            {
                string query = "SELECT book_id, title FROM books WHERE is_available = TRUE ORDER BY title";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        comboBoxBooks.Items.Clear();
                        while (reader.Read())
                        {
                            comboBoxBooks.Items.Add(new KeyValuePair<int, string>(
                                reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
                comboBoxBooks.DisplayMember = "Value";
                comboBoxBooks.ValueMember = "Key";

                if (comboBoxBooks.Items.Count > 0)
                    comboBoxBooks.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке книг: {ex.Message}");
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

        // Обработчик нажатия кнопки "Выдать книгу"
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem == null || comboBoxBooks.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите студента и книгу");
                return;
            }

            var selectedStudent = (KeyValuePair<int, string>)comboBoxStudents.SelectedItem;
            var selectedBook = (KeyValuePair<int, string>)comboBoxBooks.SelectedItem;

            try
            {
                string query = @"INSERT INTO loans (student_id, book_id, issue_date, due_date, return_date) 
                                VALUES (@studentId, @bookId, @issueDate, @dueDate, NULL)";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", selectedStudent.Key);
                    cmd.Parameters.AddWithValue("@bookId", selectedBook.Key);
                    cmd.Parameters.AddWithValue("@issueDate", dtpIssueDate.Value.Date);
                    cmd.Parameters.AddWithValue("@dueDate", dtpDueDate.Value.Date);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Книга успешно выдана");
                        LoadAvailableBooks(); // Обновляем список доступных книг
                    }
                    else
                    {
                        MessageBox.Show("Не удалось выдать книгу");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выдаче книги: {ex.Message}");
            }
        }
    }
}
