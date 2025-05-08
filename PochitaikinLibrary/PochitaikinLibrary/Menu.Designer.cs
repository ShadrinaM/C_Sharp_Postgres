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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            lblTitle = new Label();
            btnViewData = new Button();
            btnIssueBook = new Button();
            btnReturnBook = new Button();
            btnDebtorsReport = new Button();
            btnBooksStatusReport = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial Rounded MT Bold", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(166, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(557, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Библиотека Почитайкин";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnViewData
            // 
            btnViewData.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnViewData.Location = new Point(166, 107);
            btnViewData.Name = "btnViewData";
            btnViewData.Size = new Size(557, 75);
            btnViewData.TabIndex = 1;
            btnViewData.Text = "Просмотр данных";
            btnViewData.UseVisualStyleBackColor = true;
            btnViewData.Click += btnViewData_Click;
            // 
            // btnIssueBook
            // 
            btnIssueBook.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnIssueBook.Location = new Point(166, 188);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(557, 75);
            btnIssueBook.TabIndex = 2;
            btnIssueBook.Text = "Оформить выдачу книги";
            btnIssueBook.UseVisualStyleBackColor = true;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnReturnBook.Location = new Point(166, 273);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(557, 75);
            btnReturnBook.TabIndex = 3;
            btnReturnBook.Text = "Оформить возврат книги";
            btnReturnBook.UseVisualStyleBackColor = true;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnDebtorsReport
            // 
            btnDebtorsReport.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnDebtorsReport.Location = new Point(166, 354);
            btnDebtorsReport.Name = "btnDebtorsReport";
            btnDebtorsReport.Size = new Size(557, 75);
            btnDebtorsReport.TabIndex = 4;
            btnDebtorsReport.Text = "Отчёт по должникам";
            btnDebtorsReport.UseVisualStyleBackColor = true;
            btnDebtorsReport.Click += btnDebtorsReport_Click;
            // 
            // btnBooksStatusReport
            // 
            btnBooksStatusReport.Font = new Font("Arial Rounded MT Bold", 22.2F);
            btnBooksStatusReport.Location = new Point(166, 435);
            btnBooksStatusReport.Name = "btnBooksStatusReport";
            btnBooksStatusReport.Size = new Size(557, 75);
            btnBooksStatusReport.TabIndex = 5;
            btnBooksStatusReport.Text = "Отчёт по состоянию книг";
            btnBooksStatusReport.UseVisualStyleBackColor = true;
            btnBooksStatusReport.Click += btnBooksStatusReport_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(148, 532);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(729, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(148, 532);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(882, 553);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnBooksStatusReport);
            Controls.Add(btnDebtorsReport);
            Controls.Add(btnReturnBook);
            Controls.Add(btnIssueBook);
            Controls.Add(btnViewData);
            Controls.Add(lblTitle);
            Name = "Menu";
            Text = "Библиотека - Главное меню";
            Load += Menu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnViewData;
        private Button btnIssueBook;
        private Button btnReturnBook;
        private Button btnDebtorsReport;
        private Button btnBooksStatusReport;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}