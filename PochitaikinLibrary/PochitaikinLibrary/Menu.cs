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

        private void Menu_Load(object sender, EventArgs e)
        {
            

            try
            {
                con = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=24072012;Database=PochitaikinLibraryDB");
                con.Open();

                // Проверка соединения
                if (con.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Соединение с базой данных установлено", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnViewData_Click(object sender, EventArgs e)
        {
            ViewData ViewDataForm = new ViewData(con, this);
            ViewDataForm.Show();
            this.Hide();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            // чё это
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            // Логика для оформления выдачи книги
            // TODO: Реализовать открытие формы оформления выдачи книги
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            // Логика для оформления возврата книги
            // TODO: Реализовать открытие формы оформления возврата книги
        }

        private void btnDebtorsReport_Click(object sender, EventArgs e)
        {
            // Логика для отчёта по должникам
            // TODO: Реализовать формирование и отображение отчёта по должникам
        }

        private void btnBooksStatusReport_Click(object sender, EventArgs e)
        {
            // Логика для отчёта по состоянию книг
            // TODO: Реализовать формирование и отображение отчёта по состоянию книг
        }


    }
}