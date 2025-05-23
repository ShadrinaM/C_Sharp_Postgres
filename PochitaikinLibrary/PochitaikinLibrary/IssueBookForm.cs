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
    public partial class IssueBookForm : Form
    {
        private NpgsqlConnection connection;
        private ReturnBook mainForm;
        private int userId; // Добавлено поле для хранения ID пользователя

        // Модифицированный конструктор, принимающий userId
        public IssueBookForm(NpgsqlConnection conn, ReturnBook menushka, int userId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            this.FormClosed += WinForm_FormClosed;
            this.connection = conn;
            this.userId = userId; // Сохраняем переданный userId
        }

        // Закрытие окна по крестику
        private void WinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            mainForm.Show();
        }

        // Закрытие окна по кнопке
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Преднастройка элементов формы
        private void IssueBook_Load(object sender, EventArgs e)
        {
            // Установка дат по умолчанию
            dtpIssueDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddMonths(1);

            // Загрузка данных при открытии формы
            LoadStudentInfo(); // Загружаем информацию о студенте по userId
            LoadAvailableBooks();
        }

        // Загрузка информации о студенте по его ID
        private void LoadStudentInfo()
        {
            try
            {
                string query = @"SELECT s.student_id, s.full_name, u.name 
                                FROM students s 
                                JOIN universities u ON s.university_id = u.university_id
                                WHERE s.student_id = @userId";
                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Отображаем информацию о студенте
                            lblStudentName.Text = $"{reader.GetString(1)}";
                            lblUniversityName.Text = $"{reader.GetString(2)}";
                        }
                        else
                        {
                            MessageBox.Show("Студент не найден");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке информации о студенте: {ex.Message}");
                this.Close();
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

        // Обработчик нажатия кнопки "Выдать книгу"
        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (comboBoxBooks.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу");
                return;
            }

            var selectedBook = (KeyValuePair<int, string>)comboBoxBooks.SelectedItem;

            try
            {
                string query = @"INSERT INTO loans (student_id, book_id, issue_date, due_date, return_date) 
                                VALUES (@studentId, @bookId, @issueDate, @dueDate, NULL)";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", userId); // Используем сохраненный userId
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