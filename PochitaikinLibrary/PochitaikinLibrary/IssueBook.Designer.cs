namespace PochitaikinLibrary
{
    partial class IssueBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueBook));
            panelHeader = new Panel();
            btnBack = new PictureBox();
            label1 = new Label();
            btnIssueBook = new Button();
            comboBoxUniversities = new ComboBox();
            label6 = new Label();
            comboBoxStudents = new ComboBox();
            label2 = new Label();
            comboBoxBooks = new ComboBox();
            label3 = new Label();
            dtpIssueDate = new DateTimePicker();
            label4 = new Label();
            dtpDueDate = new DateTimePicker();
            label5 = new Label();
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
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(9, 8, 9, 8);
            panelHeader.Size = new Size(440, 73);
            panelHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(9, 11);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(61, 52);
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
            label1.Location = new Point(76, 19);
            label1.Name = "label1";
            label1.Size = new Size(203, 37);
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
            btnIssueBook.Location = new Point(18, 322);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(405, 33);
            btnIssueBook.TabIndex = 12;
            btnIssueBook.Text = "Выдать книгу";
            btnIssueBook.UseVisualStyleBackColor = false;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // comboBoxUniversities
            // 
            comboBoxUniversities.FormattingEnabled = true;
            comboBoxUniversities.Location = new Point(123, 89);
            comboBoxUniversities.Name = "comboBoxUniversities";
            comboBoxUniversities.Size = new Size(300, 23);
            comboBoxUniversities.TabIndex = 1;
            comboBoxUniversities.SelectedIndexChanged += comboBoxUniversities_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F);
            label6.Location = new Point(18, 89);
            label6.Name = "label6";
            label6.Size = new Size(52, 24);
            label6.TabIndex = 2;
            label6.Text = "ВУЗ:";
            // 
            // comboBoxStudents
            // 
            comboBoxStudents.FormattingEnabled = true;
            comboBoxStudents.Location = new Point(123, 122);
            comboBoxStudents.Name = "comboBoxStudents";
            comboBoxStudents.Size = new Size(300, 23);
            comboBoxStudents.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F);
            label2.Location = new Point(18, 122);
            label2.Name = "label2";
            label2.Size = new Size(91, 24);
            label2.TabIndex = 4;
            label2.Text = "Студент:";
            // 
            // comboBoxBooks
            // 
            comboBoxBooks.FormattingEnabled = true;
            comboBoxBooks.Location = new Point(123, 160);
            comboBoxBooks.Name = "comboBoxBooks";
            comboBoxBooks.Size = new Size(300, 23);
            comboBoxBooks.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F);
            label3.Location = new Point(18, 159);
            label3.Name = "label3";
            label3.Size = new Size(68, 24);
            label3.TabIndex = 6;
            label3.Text = "Книга:";
            // 
            // dtpIssueDate
            // 
            dtpIssueDate.Location = new Point(123, 207);
            dtpIssueDate.Name = "dtpIssueDate";
            dtpIssueDate.Size = new Size(300, 23);
            dtpIssueDate.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F);
            label4.Location = new Point(18, 193);
            label4.Name = "label4";
            label4.Size = new Size(82, 48);
            label4.TabIndex = 8;
            label4.Text = "Дата \r\nвыдачи:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(123, 262);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(300, 23);
            dtpDueDate.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F);
            label5.Location = new Point(18, 250);
            label5.Name = "label5";
            label5.Size = new Size(99, 48);
            label5.TabIndex = 10;
            label5.Text = "Срок \r\nвозврата:";
            // 
            // IssueBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(440, 374);
            Controls.Add(btnIssueBook);
            Controls.Add(label5);
            Controls.Add(dtpDueDate);
            Controls.Add(label4);
            Controls.Add(dtpIssueDate);
            Controls.Add(label3);
            Controls.Add(comboBoxBooks);
            Controls.Add(label2);
            Controls.Add(comboBoxStudents);
            Controls.Add(label6);
            Controls.Add(comboBoxUniversities);
            Controls.Add(panelHeader);
            Name = "IssueBook";
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
        private ComboBox comboBoxUniversities;
        private Label label6;
        private ComboBox comboBoxStudents;
        private Label label2;
        private ComboBox comboBoxBooks;
        private Label label3;
        private DateTimePicker dtpIssueDate;
        private Label label4;
        private DateTimePicker dtpDueDate;
        private Label label5;
    }
}