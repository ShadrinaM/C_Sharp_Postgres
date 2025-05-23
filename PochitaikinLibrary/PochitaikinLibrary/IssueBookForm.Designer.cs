namespace PochitaikinLibrary
{
    partial class IssueBookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueBookForm));
            panelHeader = new Panel();
            btnBack = new PictureBox();
            label1 = new Label();
            btnIssueBook = new Button();
            lblUniversityInfo = new Label();
            lblStudentInfo = new Label();
            comboBoxBooks = new ComboBox();
            label3 = new Label();
            dtpIssueDate = new DateTimePicker();
            label4 = new Label();
            dtpDueDate = new DateTimePicker();
            label5 = new Label();
            lblStudentName = new Label();
            lblUniversityName = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBack).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveBorder;
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(10, 11, 10, 11);
            panelHeader.Size = new Size(725, 97);
            panelHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(10, 15);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(70, 69);
            btnBack.SizeMode = PictureBoxSizeMode.Zoom;
            btnBack.TabIndex = 16;
            btnBack.TabStop = false;
            btnBack.Click += btnBack_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(87, 25);
            label1.Name = "label1";
            label1.Size = new Size(252, 46);
            label1.TabIndex = 15;
            label1.Text = "Выдача книги";
            // 
            // btnIssueBook
            // 
            btnIssueBook.BackColor = SystemColors.ControlDarkDark;
            btnIssueBook.FlatAppearance.BorderSize = 0;
            btnIssueBook.FlatStyle = FlatStyle.Flat;
            btnIssueBook.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnIssueBook.ForeColor = Color.White;
            btnIssueBook.Location = new Point(21, 429);
            btnIssueBook.Margin = new Padding(3, 4, 3, 4);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(684, 44);
            btnIssueBook.TabIndex = 12;
            btnIssueBook.Text = "Выдать книгу";
            btnIssueBook.UseVisualStyleBackColor = false;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // lblUniversityInfo
            // 
            lblUniversityInfo.AutoSize = true;
            lblUniversityInfo.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblUniversityInfo.Location = new Point(21, 119);
            lblUniversityInfo.Name = "lblUniversityInfo";
            lblUniversityInfo.Size = new Size(67, 29);
            lblUniversityInfo.TabIndex = 2;
            lblUniversityInfo.Text = "ВУЗ:";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new Font("Microsoft Sans Serif", 14.25F);
            lblStudentInfo.Location = new Point(21, 163);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new Size(114, 29);
            lblStudentInfo.TabIndex = 4;
            lblStudentInfo.Text = "Студент:";
            // 
            // comboBoxBooks
            // 
            comboBoxBooks.FormattingEnabled = true;
            comboBoxBooks.Location = new Point(141, 213);
            comboBoxBooks.Margin = new Padding(3, 4, 3, 4);
            comboBoxBooks.Name = "comboBoxBooks";
            comboBoxBooks.Size = new Size(564, 28);
            comboBoxBooks.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F);
            label3.Location = new Point(21, 212);
            label3.Name = "label3";
            label3.Size = new Size(89, 29);
            label3.TabIndex = 6;
            label3.Text = "Книга:";
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Location = new Point(141, 276);
            dtpIssueDate.Margin = new Padding(3, 4, 3, 4);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(564, 27);
            dtpIssueDate.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F);
            label4.Location = new Point(21, 257);
            label4.Name = "label4";
            label4.Size = new Size(105, 58);
            label4.TabIndex = 8;
            label4.Text = "Дата \r\nвыдачи:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(141, 349);
            dtpDueDate.Margin = new Padding(3, 4, 3, 4);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(564, 27);
            dtpDueDate.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F);
            label5.Location = new Point(21, 333);
            label5.Name = "label5";
            label5.Size = new Size(124, 58);
            label5.TabIndex = 10;
            label5.Text = "Срок \r\nвозврата:";
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.Font = new Font("Microsoft Sans Serif", 11F);
            lblStudentName.Location = new Point(141, 168);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(134, 24);
            lblStudentName.TabIndex = 14;
            lblStudentName.Text = "Имя студента";
            // 
            // lblUniversityName
            // 
            lblUniversityName.AutoSize = true;
            lblUniversityName.Font = new Font("Microsoft Sans Serif", 11F);
            lblUniversityName.Location = new Point(141, 124);
            lblUniversityName.Name = "lblUniversityName";
            lblUniversityName.Size = new Size(149, 24);
            lblUniversityName.TabIndex = 13;
            lblUniversityName.Text = "Название ВУЗа";
            // 
            // IssueBookForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(725, 488);
            Controls.Add(lblStudentName);
            Controls.Add(lblUniversityName);
            Controls.Add(btnIssueBook);
            Controls.Add(label5);
            Controls.Add(dtpDueDate);
            Controls.Add(label4);
            Controls.Add(dtpIssueDate);
            Controls.Add(label3);
            Controls.Add(comboBoxBooks);
            Controls.Add(lblStudentInfo);
            Controls.Add(lblUniversityInfo);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "IssueBookForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выдача книги";
            Load += IssueBook_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnBack).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Button btnIssueBook;
        private PictureBox btnBack;
        private Label label1;
        private Label lblUniversityInfo;
        private Label lblStudentInfo;
        private ComboBox comboBoxBooks;
        private Label label3;
        private DateTimePicker dtpIssueDate;
        private Label label4;
        private DateTimePicker dtpDueDate;
        private Label label5;
        private Label lblStudentName;
        private Label lblUniversityName;
    }
}