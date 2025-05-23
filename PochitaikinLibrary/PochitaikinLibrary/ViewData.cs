using Npgsql;
using PochitaikinLibrary.Forms;
using System.Data;
using System.Windows.Forms;

namespace PochitaikinLibrary
{
    public partial class ViewData : Form
    {
        private NpgsqlConnection connection;
        private Menu mainForm;

        public ViewData(NpgsqlConnection conn, Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            connection = conn;
            this.FormClosed += WinForm_FormClosed;
        }

        // Закрытие формы по крестику
        private void WinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }
                
        // Закрытие формы по кнопке
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Преднастройка элементов формы и заполнение comboBoxTables
        private void ViewData_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> tableNames = new Dictionary<string, string>
            {
                {"Университеты", "Университеты"},
                {"Студенты", "Студенты"},
                {"Книги", "Книги"},
                // Ниже две таблицы в которые мы не добавляем в этой форме, просто что бы можно было прочекать содержимое
                //{"Выдачи книг", "Выдачи книг"},
                //{"Утерянные книги", "Утерянные книги"},
                // Эти две просто по приколу
                //{"Текущие выданные книги", "Текущие выданные книги"},
                //{"Статистика по университетам", "Статистика по университетам"}
            };

            foreach (var kvp in tableNames)
            {
                comboBoxTables.Items.Add($"{kvp.Key} ({kvp.Value})");
            }

            if (comboBoxTables.Items.Count > 0)
            {
                comboBoxTables.SelectedIndex = 0;
            }

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
        }

        // Обработчик выбора таблицы в comboBoxTables
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            int startIndex = selectedTable.IndexOf('(') + 1;
            int endIndex = selectedTable.IndexOf(')', startIndex);
            string viewName = selectedTable.Substring(startIndex, endIndex - startIndex);

            try
            {
                RefreshDataGridView(viewName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки представления: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Заполнение dataGridView выбранным представлением
        private void RefreshDataGridView(string viewName)
        {
            try
            {
                dataGridView.DataSource = null;

                string query = $"SELECT * FROM \"{viewName}\"";
                using (var adapter = new NpgsqlDataAdapter(query, connection))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView.DataSource = dataTable;

                    HideIdColumns(viewName);
                }

                dataGridView.Refresh();
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
            }
        }

        // Скрытие id для всех View
        private void HideIdColumns(string viewName)
        {
            var idColumns = new Dictionary<string, string>
            {
                {"Университеты", "ID университета"},
                {"Студенты", "ID студента"},
                {"Книги", "ID книги"},
                {"Выдачи книг", "ID выдачи"},
                {"Утерянные книги", "ID утери"}
            };

            if (idColumns.TryGetValue(viewName, out var columnName))
            {
                if (dataGridView.Columns.Contains(columnName))
                {
                    dataGridView.Columns[columnName].Visible = false;
                }
            }
        }

        // для Universities
        private bool IsUniversitiesTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("Университеты");
        }

        private void AddUniversity()
        {
            var addForm = new UniversityForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("Университеты");
            }
        }

        private void EditUniversity()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите университет для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int universityId = Convert.ToInt32(selectedRow.Cells["ID университета"].Value);

            var editForm = new UniversityForm(connection, true, universityId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("Университеты");
            }
        }

        private void DeleteUniversity()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите университет для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int universityId = Convert.ToInt32(selectedRow.Cells["ID университета"].Value);
            string universityName = selectedRow.Cells["Название университета"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить университет \"{universityName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM universities WHERE university_id = @universityId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@universityId", universityId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Университет успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridView("Университеты");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении университета: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // для Students
        private bool IsStudentsTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("Студенты");
        }

        private void AddStudent()
        {
            var addForm = new StudentForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("Студенты");
            }
        }

        private void EditStudent()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int studentId = Convert.ToInt32(selectedRow.Cells["ID студента"].Value);

            var editForm = new StudentForm(connection, true, studentId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("Студенты");
            }
        }

        private void DeleteStudent()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите студента для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int studentId = Convert.ToInt32(selectedRow.Cells["ID студента"].Value);
            string studentName = selectedRow.Cells["ФИО студента"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить студента \"{studentName}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM students WHERE student_id = @studentId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@studentId", studentId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Студент успешно удален", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridView("Студенты");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении студента: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // для Books
        private bool IsBooksTableSelected()
        {
            if (comboBoxTables.SelectedItem == null) return false;
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            return selectedTable.Contains("Книги");
        }

        private void AddBook()
        {
            var addForm = new BookForm(connection);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("Книги");
            }
        }

        private void EditBook()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int bookId = Convert.ToInt32(selectedRow.Cells["ID книги"].Value);

            var editForm = new BookForm(connection, true, bookId);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGridView("Книги");
            }
        }

        private void DeleteBook()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            int bookId = Convert.ToInt32(selectedRow.Cells["ID книги"].Value);
            string bookTitle = selectedRow.Cells["Название книги"].Value.ToString();

            if (MessageBox.Show($"Вы уверены, что хотите удалить книгу \"{bookTitle}\"?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM books WHERE book_id = @bookId";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Книга успешно удалена", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridView("Книги");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении книги: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Обработчики StripMenu
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsUniversitiesTableSelected())
            {
                AddUniversity();
            }
            else if (IsStudentsTableSelected())
            {
                AddStudent();
            }
            else if (IsBooksTableSelected())
            {
                AddBook();
            }
            else
            {
                MessageBox.Show("Функция добавления для этого представления не реализована", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ChangeElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsUniversitiesTableSelected())
            {
                EditUniversity();
            }
            else if (IsStudentsTableSelected())
            {
                EditStudent();
            }
            else if (IsBooksTableSelected())
            {
                EditBook();
            }
            else
            {
                MessageBox.Show("Функция редактирования для этого представления не реализована", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsUniversitiesTableSelected())
            {
                DeleteUniversity();
            }
            else if (IsStudentsTableSelected())
            {
                DeleteStudent();
            }
            else if (IsBooksTableSelected())
            {
                DeleteBook();
            }
            else
            {
                MessageBox.Show("Функция удаления для этого представления не реализована", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}