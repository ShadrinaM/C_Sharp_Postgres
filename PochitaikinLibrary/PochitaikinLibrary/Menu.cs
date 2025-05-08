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

                // �������� ����������
                if (con.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("���������� � ����� ������ �����������", "�����",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"������ ����������� � ���� ������:\n{ex.Message}", "������",
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
            // �� ���
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            // ������ ��� ���������� ������ �����
            // TODO: ����������� �������� ����� ���������� ������ �����
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            // ������ ��� ���������� �������� �����
            // TODO: ����������� �������� ����� ���������� �������� �����
        }

        private void btnDebtorsReport_Click(object sender, EventArgs e)
        {
            // ������ ��� ������ �� ���������
            // TODO: ����������� ������������ � ����������� ������ �� ���������
        }

        private void btnBooksStatusReport_Click(object sender, EventArgs e)
        {
            // ������ ��� ������ �� ��������� ����
            // TODO: ����������� ������������ � ����������� ������ �� ��������� ����
        }


    }
}