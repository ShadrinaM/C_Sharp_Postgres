using Npgsql;
using System.Data;

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
            //чё-то до загрузки сделать
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
    }
}