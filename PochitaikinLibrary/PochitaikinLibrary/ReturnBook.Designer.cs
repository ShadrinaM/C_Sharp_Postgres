namespace PochitaikinLibrary
{
    partial class ReturnBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReturnBook));
            btnBack = new PictureBox();
            label1 = new Label();
            panelHeader = new Panel();
            menuStrip1 = new MenuStrip();
            выдатьКнигуToolStripMenuItem = new ToolStripMenuItem();
            EditTableToolStripMenuItem = new ToolStripMenuItem();
            ReturnStripMenuItem = new ToolStripMenuItem();
            LostStripMenuItem = new ToolStripMenuItem();
            RemoveStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            comboBoxStudents = new ComboBox();
            label6 = new Label();
            comboBoxUniversities = new ComboBox();
            dataGridViewBook = new DataGridView();
            dataGridViewBookInfo = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)btnBack).BeginInit();
            panelHeader.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBook).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookInfo).BeginInit();
            SuspendLayout();
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
            label1.Font = new Font("Segoe UI", 29F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(76, 11);
            label1.Name = "label1";
            label1.Size = new Size(487, 52);
            label1.TabIndex = 15;
            label1.Text = "Выдача и возврат книги";
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
            panelHeader.Size = new Size(920, 73);
            panelHeader.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { выдатьКнигуToolStripMenuItem, EditTableToolStripMenuItem });
            menuStrip1.Location = new Point(0, 73);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(920, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // выдатьКнигуToolStripMenuItem
            // 
            выдатьКнигуToolStripMenuItem.BackColor = Color.White;
            выдатьКнигуToolStripMenuItem.ForeColor = Color.Black;
            выдатьКнигуToolStripMenuItem.Name = "выдатьКнигуToolStripMenuItem";
            выдатьКнигуToolStripMenuItem.Size = new Size(92, 20);
            выдатьКнигуToolStripMenuItem.Text = "Выдать книгу";
            выдатьКнигуToolStripMenuItem.Click += IssueABbookToolStripMenuItem_Click;
            // 
            // EditTableToolStripMenuItem
            // 
            EditTableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ReturnStripMenuItem, LostStripMenuItem, RemoveStripMenuItem });
            EditTableToolStripMenuItem.ForeColor = Color.Black;
            EditTableToolStripMenuItem.Name = "EditTableToolStripMenuItem";
            EditTableToolStripMenuItem.Size = new Size(212, 20);
            EditTableToolStripMenuItem.Text = "Установить новое состояние книги";
            // 
            // ReturnStripMenuItem
            // 
            ReturnStripMenuItem.Name = "ReturnStripMenuItem";
            ReturnStripMenuItem.Size = new Size(312, 22);
            ReturnStripMenuItem.Text = "Книга возвращена";
            ReturnStripMenuItem.Click += ReturnStripMenuItem_Click;
            // 
            // LostStripMenuItem
            // 
            LostStripMenuItem.Name = "LostStripMenuItem";
            LostStripMenuItem.Size = new Size(312, 22);
            LostStripMenuItem.Text = "Книга утеряна";
            LostStripMenuItem.Click += LostStripMenuItem_Click;
            // 
            // RemoveStripMenuItem
            // 
            RemoveStripMenuItem.Name = "RemoveStripMenuItem";
            RemoveStripMenuItem.Size = new Size(312, 22);
            RemoveStripMenuItem.Text = "Удалить книгу из списка выданных суденту";
            RemoveStripMenuItem.Click += RemoveStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F);
            label2.Location = new Point(15, 147);
            label2.Name = "label2";
            label2.Size = new Size(91, 24);
            label2.TabIndex = 10;
            label2.Text = "Студент:";
            // 
            // comboBoxStudents
            // 
            comboBoxStudents.FormattingEnabled = true;
            comboBoxStudents.Location = new Point(120, 147);
            comboBoxStudents.Name = "comboBoxStudents";
            comboBoxStudents.Size = new Size(300, 23);
            comboBoxStudents.TabIndex = 9;
            comboBoxStudents.SelectedIndexChanged += comboBoxStudents_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 14.25F);
            label6.Location = new Point(15, 114);
            label6.Name = "label6";
            label6.Size = new Size(52, 24);
            label6.TabIndex = 8;
            label6.Text = "ВУЗ:";
            // 
            // comboBoxUniversities
            // 
            comboBoxUniversities.FormattingEnabled = true;
            comboBoxUniversities.Location = new Point(120, 114);
            comboBoxUniversities.Name = "comboBoxUniversities";
            comboBoxUniversities.Size = new Size(300, 23);
            comboBoxUniversities.TabIndex = 7;
            comboBoxUniversities.SelectedIndexChanged += comboBoxUniversities_SelectedIndexChanged;
            // 
            // dataGridViewBook
            // 
            dataGridViewBook.AllowUserToAddRows = false;
            dataGridViewBook.AllowUserToDeleteRows = false;
            dataGridViewBook.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewBook.BackgroundColor = Color.White;
            dataGridViewBook.BorderStyle = BorderStyle.None;
            dataGridViewBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBook.GridColor = SystemColors.Control;
            dataGridViewBook.Location = new Point(15, 187);
            dataGridViewBook.Name = "dataGridViewBook";
            dataGridViewBook.ReadOnly = true;
            dataGridViewBook.RowHeadersWidth = 51;
            dataGridViewBook.Size = new Size(893, 144);
            dataGridViewBook.TabIndex = 11;
            dataGridViewBook.SelectionChanged += dataGridViewBook_SelectionChanged;
            // 
            // dataGridViewBookInfo
            // 
            dataGridViewBookInfo.AllowUserToAddRows = false;
            dataGridViewBookInfo.AllowUserToDeleteRows = false;
            dataGridViewBookInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewBookInfo.BackgroundColor = Color.White;
            dataGridViewBookInfo.BorderStyle = BorderStyle.None;
            dataGridViewBookInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBookInfo.GridColor = SystemColors.Control;
            dataGridViewBookInfo.Location = new Point(15, 349);
            dataGridViewBookInfo.Name = "dataGridViewBookInfo";
            dataGridViewBookInfo.ReadOnly = true;
            dataGridViewBookInfo.RowHeadersWidth = 51;
            dataGridViewBookInfo.Size = new Size(893, 198);
            dataGridViewBookInfo.TabIndex = 12;
            // 
            // ReturnBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 559);
            Controls.Add(dataGridViewBookInfo);
            Controls.Add(dataGridViewBook);
            Controls.Add(label2);
            Controls.Add(comboBoxStudents);
            Controls.Add(label6);
            Controls.Add(comboBoxUniversities);
            Controls.Add(menuStrip1);
            Controls.Add(panelHeader);
            Name = "ReturnBook";
            Text = "ReturnBook";
            Load += ReturnBook_Load;
            ((System.ComponentModel.ISupportInitialize)btnBack).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBook).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookInfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btnBack;
        private Label label1;
        private Panel panelHeader;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem EditTableToolStripMenuItem;
        private ToolStripMenuItem ReturnStripMenuItem;
        private ToolStripMenuItem LostStripMenuItem;
        private ToolStripMenuItem RemoveStripMenuItem;
        private Label label2;
        private ComboBox comboBoxStudents;
        private Label label6;
        private ComboBox comboBoxUniversities;
        private DataGridView dataGridViewBook;
        private DataGridView dataGridViewBookInfo;
        private ToolStripMenuItem выдатьКнигуToolStripMenuItem;
    }
}