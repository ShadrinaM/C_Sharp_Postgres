using Npgsql;
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

        private void WinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }

        private void ViewData_Load(object sender, EventArgs e)
        {
            // Словарь с русскими названиями таблиц
            Dictionary<string, string> tableNames = new Dictionary<string, string>
            {
                {"Университеты", "universities"},
                {"Студенты", "students"},
                {"Книги", "books"},
                {"Выдачи книг", "loans"},
                {"Утерянные книги", "lost_books"}
            };

            // Заполняем комбобокс русскими названиями таблиц
            foreach (var table in tableNames)
            {
                comboBoxTables.Items.Add($"{table.Key} ({table.Value})");
            }

            // Предварительно загружаем первую таблицу
            if (comboBoxTables.Items.Count > 0)
            {
                comboBoxTables.SelectedIndex = 0;
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedItem == null) return;

            string selectedItem = comboBoxTables.SelectedItem.ToString();
            string tableName = selectedItem.Split('(', ')')[1].Trim();

            try
            {
                LoadTableData(tableName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблицы: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTableData(string tableName)
        {
            string query = $"SELECT * FROM \"{tableName}\"";

            // Для сложных таблиц добавляем JOIN'ы
            switch (tableName.ToLower())
            {
                case "students":
                    query = @"SELECT s.student_id, s.full_name, u.name as university 
                             FROM students s
                             JOIN universities u ON s.university_id = u.university_id";
                    break;

                case "loans":
                    query = @"SELECT l.loan_id, s.full_name as student, b.title as book, 
                                    l.issue_date, l.due_date, l.return_date
                             FROM loans l
                             JOIN students s ON l.student_id = s.student_id
                             JOIN books b ON l.book_id = b.book_id";
                    break;

                case "lost_books":
                    query = @"SELECT lb.lost_id, s.full_name as student, b.title as book, 
                                    lb.lost_date, b.cost
                             FROM lost_books lb
                             JOIN students s ON lb.student_id = s.student_id
                             JOIN books b ON lb.book_id = b.book_id";
                    break;
            }

            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                dataGridView.AutoResizeColumns();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource == null)
            {
                MessageBox.Show("Нет данных для экспорта", "Информация",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Реализовать экспорт в Excel
            MessageBox.Show("Экспорт в Excel будет реализован здесь");
        }
    }
}