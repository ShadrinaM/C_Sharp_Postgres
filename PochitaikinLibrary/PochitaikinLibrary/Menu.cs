using Npgsql;
using System.Data;
using System.Drawing;

namespace PochitaikinLibrary
{
    public partial class Menu : Form
    {
        public NpgsqlConnection con;
        public Menu()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        // Преднастройка формы
        private void Menu_Load(object sender, EventArgs e)
        {
            // Подключение к БД
            try
            {
                con = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=24072012;Database=PochitaikinLibraryDB");
                con.Open();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчики кнопок и открытие соответствующих форм
        private void btnViewData_Click(object sender, EventArgs e)
        {
            ViewData ViewDataForm = new ViewData(con, this);
            ViewDataForm.Show();
            this.Hide();
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            ReturnBook ReturnBookForm = new ReturnBook(con, this);
            ReturnBookForm.Show();
            this.Hide();
        }
        private void btnDebtorsReport_Click(object sender, EventArgs e)
        {
            DebtorsReport DebtorsReportForm = new DebtorsReport(con, this);
            DebtorsReportForm.Show();
            this.Hide();
        }
        private void btnBooksStatusReport_Click(object sender, EventArgs e)
        {
            BooksStatusReport BooksStatusReportForm = new BooksStatusReport(con, this);
            BooksStatusReportForm.Show();
            this.Hide();
        }
    }
}