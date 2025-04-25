using Npgsql;
using System.Windows.Forms;

namespace AtelierPro
{
    // Свернуть всё(все регионы, методы, классы в файле):
    // Ctrl + M, Ctrl + O
    // Развернуть всё:
    // Ctrl + M, Ctrl + L
    public partial class Menu : Form
    {
        public NpgsqlConnection con;

        public Menu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Обработчик события Load
        /// </summary>
        private void Menu_Load(object sender, System.EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            //try
            //{
            con = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=24072012;Database=AtelierProDB");
            con.Open();

            //    // Проверка соединения
            //    if (con.State == System.Data.ConnectionState.Open)
            //    {
            //        MessageBox.Show("Соединение с базой данных установлено", "Успех",
            //                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (NpgsqlException ex)
            //{
            //    MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}", "Ошибка",
            //                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// Закрыть соединение при закрытии формы
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            DataTables dataTablesForm = new DataTables(con, this);
            dataTablesForm.Show();
            this.Hide();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            Invoices invoicesForm = new Invoices(con, this);
            invoicesForm.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports ReportsForm = new Reports(con, this);
            ReportsForm.Show();
            this.Hide();
        }
    }
}