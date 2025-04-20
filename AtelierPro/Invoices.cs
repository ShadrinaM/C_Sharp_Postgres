using Npgsql;
using System.Data;

namespace AtelierPro
{
    public partial class Invoices : Form
    {
        private NpgsqlConnection connection;

        public Invoices(NpgsqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void DataTables_Load(object sender, EventArgs e)
        {
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