namespace AtelierPro
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            btnData = new Button();
            btnInvoices = new Button();
            btnReports = new Button();
            panelHeader = new Panel();
            lblTitle = new Label();
            picLogo = new PictureBox();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // btnData
            // 
            btnData.BackColor = SystemColors.ActiveCaptionText;
            btnData.FlatAppearance.BorderSize = 0;
            btnData.FlatStyle = FlatStyle.Flat;
            btnData.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnData.ForeColor = Color.White;
            btnData.ImageAlign = ContentAlignment.MiddleLeft;
            btnData.Location = new Point(250, 150);
            btnData.Name = "btnData";
            btnData.Padding = new Padding(10, 0, 0, 0);
            btnData.Size = new Size(300, 60);
            btnData.TabIndex = 0;
            btnData.Text = "Данные";
            btnData.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnData.UseVisualStyleBackColor = false;
            btnData.Click += btnData_Click;
            // 
            // btnInvoices
            // 
            btnInvoices.BackColor = SystemColors.ActiveCaptionText;
            btnInvoices.FlatAppearance.BorderSize = 0;
            btnInvoices.FlatStyle = FlatStyle.Flat;
            btnInvoices.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnInvoices.ForeColor = Color.White;
            btnInvoices.ImageAlign = ContentAlignment.MiddleLeft;
            btnInvoices.Location = new Point(250, 230);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Padding = new Padding(10, 0, 0, 0);
            btnInvoices.Size = new Size(300, 60);
            btnInvoices.TabIndex = 1;
            btnInvoices.Text = "Накладные";
            btnInvoices.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInvoices.UseVisualStyleBackColor = false;
            btnInvoices.Click += btnInvoices_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = SystemColors.ActiveCaptionText;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnReports.ForeColor = Color.White;
            btnReports.ImageAlign = ContentAlignment.MiddleLeft;
            btnReports.Location = new Point(250, 310);
            btnReports.Name = "btnReports";
            btnReports.Padding = new Padding(10, 0, 0, 0);
            btnReports.Size = new Size(300, 60);
            btnReports.TabIndex = 2;
            btnReports.Text = "Отчёты";
            btnReports.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaptionText;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(800, 100);
            panelHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(88, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(213, 54);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "AtelierPro";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(12, 15);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(70, 70);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(panelHeader);
            Controls.Add(btnReports);
            Controls.Add(btnInvoices);
            Controls.Add(btnData);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AtelierPro - Главное меню";
            Load += Menu_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnData;
        private Button btnInvoices;
        private Button btnReports;
        private Panel panelHeader;
        private Label lblTitle;
        private PictureBox picLogo;
    }
}
