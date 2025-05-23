using System;
using System.Windows.Forms;

namespace PochitaikinLibrary
{
    public partial class PaymentForm : Form
    {
        public bool PaymentCompleted { get; private set; } = false;
        private decimal requiredAmount;

        public PaymentForm(decimal amount)
        {
            InitializeComponent();
            this.requiredAmount = amount;
            lblAmount.Text = $"Верните {amount} рублей";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false; // Убираем кнопки закрытия/свертывания
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Обработчик клика по btnPay
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPayment.Text, out decimal enteredAmount) &&
                enteredAmount == requiredAmount)
            {
                PaymentCompleted = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Введена некорректная сумма. Пожалуйста, введите точную сумму для оплаты.",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPayment.Focus();
            }
        }

        // Запрещаем закрытие формы через
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                // Игнорируем команду закрытия
                return;
            }
            base.WndProc(ref m);
        }
    }
}