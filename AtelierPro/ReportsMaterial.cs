using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace AtelierPro
{
    public partial class ReportsMaterial : Form
    {
        private NpgsqlConnection connection;

        public ReportsMaterial(NpgsqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            checkedListBox1.CheckOnClick = true; // Убедитесь, что это свойство установлено
            LoadMaterials();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //сфорормировать отчёт
        }

        private void btnExportExel_Click(object sender, EventArgs e)
        {
            //экспортировать в эксель
        }

        private void LoadMaterials()
        {
            try
            {
                string query = "SELECT material_name FROM Material ORDER BY material_name";
                using (var cmd = new NpgsqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    checkedListBox1.Items.Clear(); // Очищаем список перед заполнением

                    while (reader.Read())
                    {
                        checkedListBox1.Items.Add(reader["material_name"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке материалов: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}