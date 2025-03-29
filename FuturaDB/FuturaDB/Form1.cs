using Npgsql;
namespace FuturaDB
{
    public partial class Form1 : Form
    {
        public NpgsqlConnection con;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            con = new NpgsqlConnection("Server=localhost;Port=5432;UserID=postgres;Password=24072012;Database=Future_DB_PG");
            con.Open();
        }

    }
}
