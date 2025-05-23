using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace PochitaikinLibrary
{
    public partial class BooksStatusReport : Form
    {
        private NpgsqlConnection connection;
        private Form mainForm;

        public BooksStatusReport(NpgsqlConnection conn, Form mainForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = mainForm;
            connection = conn;
            this.FormClosed += BooksStatusReport_FormClosed;
        }
        
        // Закрытие формы по крестику
        private void BooksStatusReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }
        
        // Закрытие формы по кнопке
        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        // Преднастройка формы
        private void BooksStatusReport_Load(object sender, EventArgs e)
        {
            checkedListBoxUniversities.CheckOnClick = true;
            dateTimePickerStart.Value = new DateTime(1941, 6, 22);
            dateTimePickerEnd.Value = DateTime.Today;
            LoadUniversities();
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Загрузка университетов в checkedListBoxUniversities
        private void LoadUniversities()
        {
            try
            {
                string query = "SELECT name FROM universities ORDER BY name";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    checkedListBoxUniversities.Items.Clear();

                    while (reader.Read())
                    {
                        checkedListBoxUniversities.Items.Add(reader["name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке списка вузов: {ex.Message}");
            }
        }

        // Обработчик кнопки сгенерировать отчёт
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (checkedListBoxUniversities.CheckedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один ВУЗ.");
                return;
            }

            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания.");
                return;
            }

            try
            {
                var selectedUniversities = new List<string>();
                foreach (var item in checkedListBoxUniversities.CheckedItems)
                {
                    selectedUniversities.Add(item.ToString());
                }

                string query = @"
                WITH 
                issued_books AS (
                    SELECT 
                        u.name AS university_name,
                        COUNT(*) AS issued_count
                    FROM 
                        loans l
                        JOIN students s ON l.student_id = s.student_id
                        JOIN universities u ON s.university_id = u.university_id
                    WHERE 
                        l.issue_date BETWEEN @startDate AND @endDate
                        AND u.name = ANY(@selectedUniversities)
                    GROUP BY u.name
                ),
                overdue_books AS (
                    SELECT 
                        u.name AS university_name,
                        COUNT(*) AS overdue_count
                    FROM 
                        loans l
                        JOIN students s ON l.student_id = s.student_id
                        JOIN universities u ON s.university_id = u.university_id
                    WHERE 
                        l.return_date IS NULL
                        AND l.issue_date BETWEEN @startDate AND @endDate
                        AND u.name = ANY(@selectedUniversities)
                    GROUP BY u.name
                ),
                lost_books AS (
                    SELECT 
                        u.name AS university_name,
                        COUNT(*) AS lost_count
                    FROM 
                        lost_books lb
                        JOIN students s ON lb.student_id = s.student_id
                        JOIN universities u ON s.university_id = u.university_id
                    WHERE 
                        lb.lost_date BETWEEN @startDate AND @endDate
                        AND u.name = ANY(@selectedUniversities)
                    GROUP BY u.name
                )
                SELECT 
                    u.name AS ""ВУЗ"",
                    COALESCE(ib.issued_count, 0) AS ""Выдано книг"",
                    COALESCE(ob.overdue_count, 0) AS ""Невозвращено"",
                    COALESCE(lb.lost_count, 0) AS ""Утеряно"",
                    COALESCE(ib.issued_count, 0) - COALESCE(ob.overdue_count, 0) - COALESCE(lb.lost_count, 0) AS ""Возвращено""
                FROM 
                    universities u
                    LEFT JOIN issued_books ib ON u.name = ib.university_name
                    LEFT JOIN overdue_books ob ON u.name = ob.university_name
                    LEFT JOIN lost_books lb ON u.name = lb.university_name
                WHERE 
                    u.name = ANY(@selectedUniversities)
                ORDER BY 
                    u.name";

                using (var cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("startDate", startDate);
                    cmd.Parameters.AddWithValue("endDate", endDate);
                    cmd.Parameters.AddWithValue("selectedUniversities", selectedUniversities.ToArray());

                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView.DataSource = dt;

                        // Форматирование заголовков
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}");
            }
        }
    }
}