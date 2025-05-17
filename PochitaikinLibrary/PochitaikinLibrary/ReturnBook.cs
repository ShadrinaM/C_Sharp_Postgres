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

            dataGridViewBook.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBook.MultiSelect = false;
            dataGridViewBookInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBookInfo.MultiSelect = false;
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
                //string query = @"SELECT b.book_id, b.title, l.issue_date, l.due_date 
                //                FROM loans l
                //                JOIN books b ON l.book_id = b.book_id
                //                WHERE l.student_id = @studentId AND l.return_date IS NULL
                //                ORDER BY l.due_date";

                string query = @"SELECT b.book_id, b.title, l.issue_date, l.due_date 
                                FROM loans l
                                JOIN books b ON l.book_id = b.book_id
                                WHERE l.student_id = @studentId
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
                            //dataGridViewBook.Columns["book_id"].HeaderText = "ID книги";
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

        // Обработчик изменения выбора в grid с выданными книгами
        private void dataGridViewBook_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count == 0)
            {
                dataGridViewBookInfo.DataSource = null;
                return;
            }

            // Предполагаем, что в Columns["book_id"] содержится идентификатор
            var row = dataGridViewBook.SelectedRows[0];
            if (row.Cells["book_id"].Value is int bookId)
            {
                LoadBookInfo(bookId);
            }
        }

        // Метод, который загружает полную информацию по книге и показывает в dataGridViewBookInfo
        private void LoadBookInfo(int bookId)
        {
            try
            {
                const string query = @"
                SELECT 
                    book_id,
                    title,
                    cost,
                    is_available
                FROM books
                WHERE book_id = @bookId";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@bookId", bookId);

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        var dtInfo = new DataTable();
                        adapter.Fill(dtInfo);
                        dataGridViewBookInfo.DataSource = dtInfo;

                        // Переименовать заголовки, если нужно
                        if (dataGridViewBookInfo.Columns.Count > 0)
                        {
                            dataGridViewBookInfo.Columns["title"].HeaderText = "Название";
                            dataGridViewBookInfo.Columns["cost"].HeaderText = "Стоимость";
                            dataGridViewBookInfo.Columns["is_available"].HeaderText = "Доступна";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке информации о книге: {ex.Message}");
            }
        }

        //private void LostStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    // реализуй в этой функции по выбраной в dataGridViewBook книге добавление книги в lost_books 
        //    /* 
        //        CREATE TABLE lost_books (
        //        lost_id SERIAL PRIMARY KEY,
        //        student_id INTEGER NOT NULL REFERENCES students(student_id) ON DELETE CASCADE,
        //        book_id INTEGER NOT NULL REFERENCES books(book_id),
        //        lost_date DATE NOT NULL
        //        ); 
        //    */
        //}

        //private void ReturnStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    /* реализуй в этой функции по выбраной в dataGridViewBook книге добавление return_date 

        //    CREATE TABLE loans (
        //    loan_id SERIAL PRIMARY KEY,
        //    student_id INTEGER NOT NULL REFERENCES students(student_id) ON DELETE CASCADE,
        //    book_id INTEGER NOT NULL REFERENCES books(book_id),
        //    issue_date DATE NOT NULL,
        //    due_date DATE NOT NULL,
        //    return_date DATE,
        //    CHECK (return_date IS NULL OR return_date >= issue_date)
        //    );

        //    */
        //}

        //private void RemoveStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    /* реализуй в этой функции по выбраной в dataGridViewBook книге удаление соответсвующей записи из loans

        //    CREATE TABLE loans (
        //    loan_id SERIAL PRIMARY KEY,
        //    student_id INTEGER NOT NULL REFERENCES students(student_id) ON DELETE CASCADE,
        //    book_id INTEGER NOT NULL REFERENCES books(book_id),
        //    issue_date DATE NOT NULL,
        //    due_date DATE NOT NULL,
        //    return_date DATE,
        //    CHECK (return_date IS NULL OR return_date >= issue_date)
        //    );

        //    */
        //}


        private void LostStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для отметки как утерянная");
                return;
            }

            var row = dataGridViewBook.SelectedRows[0];
            if (!(row.Cells["book_id"].Value is int bookId) ||
                !(comboBoxStudents.SelectedItem is KeyValuePair<int, string> selectedStudent))
            {
                MessageBox.Show("Ошибка при получении данных о книге или студенте");
                return;
            }

            try
            {
                // Добавляем запись в таблицу lost_books
                string insertQuery = @"INSERT INTO lost_books (student_id, book_id, lost_date) 
                             VALUES (@studentId, @bookId, CURRENT_DATE)";

                // Обновляем статус книги как недоступной
                string updateQuery = @"UPDATE books SET is_available = false WHERE book_id = @bookId";

                // Удаляем запись из loans (или можно добавить return_date - зависит от логики)
                string deleteLoanQuery = @"DELETE FROM loans 
                                 WHERE student_id = @studentId AND book_id = @bookId AND return_date IS NULL";

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Добавляем в lost_books
                        using (var cmd = new NpgsqlCommand(insertQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@studentId", selectedStudent.Key);
                            cmd.Parameters.AddWithValue("@bookId", bookId);
                            cmd.ExecuteNonQuery();
                        }

                        // Обновляем статус книги
                        using (var cmd = new NpgsqlCommand(updateQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@bookId", bookId);
                            cmd.ExecuteNonQuery();
                        }

                        // Удаляем из loans
                        using (var cmd = new NpgsqlCommand(deleteLoanQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@studentId", selectedStudent.Key);
                            cmd.Parameters.AddWithValue("@bookId", bookId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Книга успешно отмечена как утерянная");

                        // Обновляем данные
                        LoadStudentBooks(selectedStudent.Key);
                        LoadBookInfo(bookId);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отметке книги как утерянной: {ex.Message}");
            }
        }

        private void ReturnStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для возврата");
                return;
            }

            var row = dataGridViewBook.SelectedRows[0];
            if (!(row.Cells["book_id"].Value is int bookId) ||
                !(comboBoxStudents.SelectedItem is KeyValuePair<int, string> selectedStudent))
            {
                MessageBox.Show("Ошибка при получении данных о книге или студенте");
                return;
            }

            try
            {
                // Обновляем запись в loans, добавляя return_date
                string updateLoanQuery = @"UPDATE loans 
                                 SET return_date = CURRENT_DATE 
                                 WHERE student_id = @studentId AND book_id = @bookId AND return_date IS NULL";

                // Обновляем статус книги как доступной
                string updateBookQuery = @"UPDATE books SET is_available = true WHERE book_id = @bookId";

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Обновляем loans
                        using (var cmd = new NpgsqlCommand(updateLoanQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@studentId", selectedStudent.Key);
                            cmd.Parameters.AddWithValue("@bookId", bookId);
                            cmd.ExecuteNonQuery();
                        }

                        // Обновляем статус книги
                        using (var cmd = new NpgsqlCommand(updateBookQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@bookId", bookId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Книга успешно возвращена");

                        // Обновляем данные
                        LoadStudentBooks(selectedStudent.Key);
                        LoadBookInfo(bookId);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при возврате книги: {ex.Message}");
            }
        }

        private void RemoveStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewBook.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления записи");
                return;
            }

            var row = dataGridViewBook.SelectedRows[0];
            if (!(row.Cells["book_id"].Value is int bookId) ||
                !(comboBoxStudents.SelectedItem is KeyValuePair<int, string> selectedStudent))
            {
                MessageBox.Show("Ошибка при получении данных о книге или студенте");
                return;
            }

            try
            {
                string deleteQuery = @"DELETE FROM loans 
                             WHERE student_id = @studentId AND book_id = @bookId AND return_date IS NULL";

                using (var cmd = new NpgsqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@studentId", selectedStudent.Key);
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись о выдаче книги успешно удалена");
                        LoadStudentBooks(selectedStudent.Key);
                        LoadBookInfo(bookId);
                    }
                    else
                    {
                        MessageBox.Show("Не найдено записей для удаления");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи о выдаче книги: {ex.Message}");
            }
        }
    }
}
