namespace PochitaikinLibrary
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAmount.Location = new System.Drawing.Point(30, 30);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(120, 20);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Верните N руб.";
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtPayment.Location = new System.Drawing.Point(34, 70);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(200, 26);
            this.txtPayment.TabIndex = 1;
            this.txtPayment.Font = new Font("Segoe UI", 12F);
            // 
            // btnPay
            // 
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPay.Location = new System.Drawing.Point(34, 120);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(200, 40);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Оплатить";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            this.btnPay.BackColor = SystemColors.ActiveBorder;
            this.btnPay.FlatAppearance.BorderSize = 0;
            this.btnPay.FlatStyle = FlatStyle.Flat;
            this.btnPay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnPay.ForeColor = Color.Black;
            this.btnPay.Margin = new Padding(3, 2, 3, 2);
            this.btnPay.UseVisualStyleBackColor = false;
            // 
            // PaymentForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.lblAmount);
            this.Name = "PaymentForm";
            this.Text = "Оплата за утерянную книгу";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        Button btnPay;
        TextBox txtPayment;
        Label lblAmount;

        #endregion
    }
}