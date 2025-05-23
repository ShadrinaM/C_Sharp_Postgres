namespace PochitaikinLibrary
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
            lblTitle = new Label();
            btnViewData = new Button();
            btnReturnBook = new Button();
            btnDebtorsReport = new Button();
            btnBooksStatusReport = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = SystemColors.ControlLight;
            lblTitle.Font = new Font("Arial Rounded MT Bold", 30F);
            lblTitle.Location = new Point(107, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(509, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Библиотека \"Почитайкин\"";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnViewData
            // 
            btnViewData.BackColor = SystemColors.ControlLight;
            btnViewData.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnViewData.Location = new Point(107, 130);
            btnViewData.Margin = new Padding(3, 2, 3, 2);
            btnViewData.Name = "btnViewData";
            btnViewData.Size = new Size(564, 56);
            btnViewData.TabIndex = 1;
            btnViewData.Text = "Управление данными";
            btnViewData.UseVisualStyleBackColor = false;
            btnViewData.Click += btnViewData_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = SystemColors.ControlLight;
            btnReturnBook.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnReturnBook.Location = new Point(107, 191);
            btnReturnBook.Margin = new Padding(3, 2, 3, 2);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(564, 56);
            btnReturnBook.TabIndex = 3;
            btnReturnBook.Text = "Выдача и возврат книги";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnDebtorsReport
            // 
            btnDebtorsReport.BackColor = SystemColors.ControlLight;
            btnDebtorsReport.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnDebtorsReport.Location = new Point(107, 252);
            btnDebtorsReport.Margin = new Padding(3, 2, 3, 2);
            btnDebtorsReport.Name = "btnDebtorsReport";
            btnDebtorsReport.Size = new Size(564, 56);
            btnDebtorsReport.TabIndex = 4;
            btnDebtorsReport.Text = "Отчёт по должникам";
            btnDebtorsReport.UseVisualStyleBackColor = false;
            btnDebtorsReport.Click += btnDebtorsReport_Click;
            // 
            // btnBooksStatusReport
            // 
            btnBooksStatusReport.BackColor = SystemColors.ControlLight;
            btnBooksStatusReport.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnBooksStatusReport.Location = new Point(107, 313);
            btnBooksStatusReport.Margin = new Padding(3, 2, 3, 2);
            btnBooksStatusReport.Name = "btnBooksStatusReport";
            btnBooksStatusReport.Size = new Size(564, 56);
            btnBooksStatusReport.TabIndex = 5;
            btnBooksStatusReport.Text = "Отчёт по статусу книг";
            btnBooksStatusReport.UseVisualStyleBackColor = false;
            btnBooksStatusReport.Click += btnBooksStatusReport_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(772, 415);
            Controls.Add(btnBooksStatusReport);
            Controls.Add(btnDebtorsReport);
            Controls.Add(btnReturnBook);
            Controls.Add(btnViewData);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Menu";
            Text = "Библиотека - Главное меню";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnViewData;
        private Button btnReturnBook;
        private Button btnDebtorsReport;
        private Button btnBooksStatusReport;
    }
}