using Npgsql;
using System.Data;

namespace AtelierPro
{
    public partial class DataTables : Form
    {
        private NpgsqlConnection connection;
        private Menu mainForm;

        public DataTables(NpgsqlConnection conn, Menu menushka)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.mainForm = menushka;
            connection = conn;
            this.FormClosed += WinForm_FormClosed;
            this.mainForm = mainForm;
        }

        /// <summary>
        /// Закрытие окна по крестику
        /// </summary>
        private void WinForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Показываем главное окно при закрытии текущего
            mainForm.Show();
        }


        private void DataTables_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> tableNames = new Dictionary<string, string>
            {
                {"Изделия", "products"},
                {"Поставщики", "suppliers"},
                {"Заказы", "orders"},
                {"Приходные накладные", "incominginvoices"},
                {"Расходные накладные", "outgoinginvoices"},
                {"Материалы", "material"},
                {"Материалы на изделие", "materialforproduct"},
                {"Позиции приходных накладных", "incomingitems"},
                {"Позиции расходных накладных", "outgoingitems"}
            };

            // Получаем список таблиц из базы данных
            string query = @"
                SELECT table_name 
                FROM information_schema.tables 
                WHERE table_schema = 'public' 
                AND table_type = 'BASE TABLE'
                ORDER BY table_name";

            using (var cmd = new NpgsqlCommand(query, connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string dbTableName = reader.GetString(0).ToLower();

                    // Находим русское название по имени таблицы из БД
                    var russianName = tableNames.FirstOrDefault(x =>
                        x.Value.Equals(dbTableName, StringComparison.OrdinalIgnoreCase));

                    if (russianName.Key != null)
                    {
                        // Добавляем в формате "Русское название (table_name)"
                        comboBoxTables.Items.Add($"{russianName.Key} ({dbTableName})");
                    }
                    else
                    {
                        // Если нет в словаре, добавляем просто имя таблицы
                        comboBoxTables.Items.Add(dbTableName);
                    }
                }
            }

            // Предварительно загружает первую таблицу
            if (comboBoxTables.Items.Count > 0)
            {
                comboBoxTables.SelectedIndex = 0;
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBoxTables.SelectedItem.ToString();
            int startIndex = selectedTable.IndexOf('(') + 1;
            int endIndex = selectedTable.IndexOf(')', startIndex);
            string tableName = selectedTable.Substring(startIndex, endIndex - startIndex).ToLower();

            try
            {
                string query = $"SELECT * FROM \"{tableName}\"";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
                dataGridView.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки таблицы: {ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}