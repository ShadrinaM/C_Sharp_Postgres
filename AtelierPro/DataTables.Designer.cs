namespace AtelierPro
{
    partial class DataTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataTables));
            panelHeader = new Panel();
            btnBack = new Button();
            lblTitle = new Label();
            picLogo = new PictureBox();
            comboBoxTables = new ComboBox();
            dataGridView = new DataGridView();
            EditTableToolStripMenuItem = new ToolStripMenuItem();
            AddElementToolStripMenuItem = new ToolStripMenuItem();
            ChangeItemToolStripMenuItem = new ToolStripMenuItem();
            RemoveElementToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(29, 29, 27);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Controls.Add(comboBoxTables);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 30);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(10);
            panelHeader.Size = new Size(982, 97);
            panelHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(29, 29, 27);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(12, 14);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(33, 66);
            btnBack.TabIndex = 3;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(560, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 62);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "AtelierPro";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(814, 14);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(155, 66);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // comboBoxTables
            // 
            comboBoxTables.BackColor = Color.White;
            comboBoxTables.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTables.Font = new Font("Segoe UI", 14F);
            comboBoxTables.ForeColor = SystemColors.MenuText;
            comboBoxTables.FormattingEnabled = true;
            comboBoxTables.Location = new Point(51, 33);
            comboBoxTables.Margin = new Padding(3, 4, 3, 4);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(499, 39);
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
            dataGridView.Location = new Point(12, 135);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(958, 505);
            dataGridView.TabIndex = 2;
            // 
            // EditTableToolStripMenuItem
            // 
            EditTableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddElementToolStripMenuItem, ChangeItemToolStripMenuItem, RemoveElementToolStripMenuItem });
            EditTableToolStripMenuItem.ForeColor = Color.Black;
            EditTableToolStripMenuItem.Name = "EditTableToolStripMenuItem";
            EditTableToolStripMenuItem.Size = new Size(185, 24);
            EditTableToolStripMenuItem.Text = "Редактировать таблицу";
            // 
            // AddElementToolStripMenuItem
            // 
            AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            AddElementToolStripMenuItem.Size = new Size(224, 26);
            AddElementToolStripMenuItem.Text = "Добавить элемент";
            AddElementToolStripMenuItem.Click += AddElementToolStripMenuItem_Click;
            // 
            // ChangeItemToolStripMenuItem
            // 
            ChangeItemToolStripMenuItem.Name = "ChangeItemToolStripMenuItem";
            ChangeItemToolStripMenuItem.Size = new Size(224, 26);
            ChangeItemToolStripMenuItem.Text = "Изменить элемент";
            ChangeItemToolStripMenuItem.Click += ChangeElementToolStripMenuItem_Click;
            // 
            // RemoveElementToolStripMenuItem
            // 
            RemoveElementToolStripMenuItem.Name = "RemoveElementToolStripMenuItem";
            RemoveElementToolStripMenuItem.Size = new Size(224, 26);
            RemoveElementToolStripMenuItem.Text = "Удалить элемент";
            RemoveElementToolStripMenuItem.Click += RemoveElementToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { EditTableToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(982, 30);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // DataTables
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 653);
            Controls.Add(dataGridView);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 700);
            Name = "DataTables";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр таблиц";
            Load += DataTables_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private PictureBox picLogo;
        private ComboBox comboBoxTables;
        private DataGridView dataGridView;
        private Button btnBack;
        private ToolStripMenuItem EditTableToolStripMenuItem;
        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem ChangeItemToolStripMenuItem;
        private ToolStripMenuItem RemoveElementToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}