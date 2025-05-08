namespace PochitaikinLibrary
{
    partial class ViewData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewData));
            panelHeader = new Panel();
            picLogo = new PictureBox();
            comboBoxTables = new ComboBox();
            dataGridView = new DataGridView();
            btnBack = new Button();
            menuStrip1 = new MenuStrip();
            EditTableToolStripMenuItem = new ToolStripMenuItem();
            AddElementToolStripMenuItem = new ToolStripMenuItem();
            ChangeItemToolStripMenuItem = new ToolStripMenuItem();
            RemoveElementToolStripMenuItem = new ToolStripMenuItem();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveBorder;
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Controls.Add(comboBoxTables);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 30);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(882, 84);
            panelHeader.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(710, 4);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(160, 75);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // comboBoxTables
            // 
            comboBoxTables.BackColor = Color.White;
            comboBoxTables.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTables.Font = new Font("Segoe UI", 14F);
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Items.AddRange(new object[] { "Университеты (universities)", "Студенты (students)", "Книги (books)", "Выдачи книг (loans)", "Утерянные книги (lost_books)" });
            comboBoxTables.Location = new Point(55, 27);
            comboBoxTables.Margin = new Padding(3, 4, 3, 4);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(649, 39);
            comboBoxTables.TabIndex = 1;
            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.GridColor = SystemColors.Control;
            dataGridView.Location = new Point(12, 122);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(858, 418);
            dataGridView.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ActiveBorder;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnBack.ForeColor = Color.Black;
            btnBack.Location = new Point(3, 4);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(46, 75);
            btnBack.TabIndex = 3;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { EditTableToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(882, 30);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // EditTableToolStripMenuItem
            // 
            EditTableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddElementToolStripMenuItem, ChangeItemToolStripMenuItem, RemoveElementToolStripMenuItem });
            EditTableToolStripMenuItem.Name = "EditTableToolStripMenuItem";
            EditTableToolStripMenuItem.Size = new Size(185, 24);
            EditTableToolStripMenuItem.Text = "Редактировать таблицу";
            // 
            // AddElementToolStripMenuItem
            // 
            AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            AddElementToolStripMenuItem.Size = new Size(222, 26);
            AddElementToolStripMenuItem.Text = "Добавить элемент";
            // 
            // ChangeItemToolStripMenuItem
            // 
            ChangeItemToolStripMenuItem.Name = "ChangeItemToolStripMenuItem";
            ChangeItemToolStripMenuItem.Size = new Size(222, 26);
            ChangeItemToolStripMenuItem.Text = "Изменить элемент";
            // 
            // RemoveElementToolStripMenuItem
            // 
            RemoveElementToolStripMenuItem.Name = "RemoveElementToolStripMenuItem";
            RemoveElementToolStripMenuItem.Size = new Size(222, 26);
            RemoveElementToolStripMenuItem.Text = "Удалить элемент";
            // 
            // ViewData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(882, 553);
            Controls.Add(dataGridView);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(900, 600);
            Name = "ViewData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр данных библиотеки";
            Load += ViewData_Load;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private PictureBox picLogo;
        private ComboBox comboBoxTables;
        private DataGridView dataGridView;
        private Button btnBack;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem EditTableToolStripMenuItem;
        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem ChangeItemToolStripMenuItem;
        private ToolStripMenuItem RemoveElementToolStripMenuItem;
    }
}