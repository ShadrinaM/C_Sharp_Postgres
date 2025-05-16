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
            btnBack = new PictureBox();
            picLogo = new PictureBox();
            comboBoxTables = new ComboBox();
            dataGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            EditTableToolStripMenuItem = new ToolStripMenuItem();
            AddElementToolStripMenuItem = new ToolStripMenuItem();
            ChangeItemToolStripMenuItem = new ToolStripMenuItem();
            RemoveElementToolStripMenuItem = new ToolStripMenuItem();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBack).BeginInit();
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
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(774, 68);
            panelHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Image = (Image)resources.GetObject("btnBack.Image");
            btnBack.Location = new Point(9, 8);
            btnBack.Margin = new Padding(3, 2, 3, 2);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(61, 52);
            btnBack.SizeMode = PictureBoxSizeMode.Zoom;
            btnBack.TabIndex = 6;
            btnBack.TabStop = false;
            btnBack.Click += btnBack_Click;
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(700, 8);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(61, 52);
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
            comboBoxTables.Location = new Point(75, 20);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(620, 33);
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
            dataGridView.Location = new Point(9, 96);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(751, 309);
            dataGridView.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { EditTableToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(774, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // EditTableToolStripMenuItem
            // 
            EditTableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddElementToolStripMenuItem, ChangeItemToolStripMenuItem, RemoveElementToolStripMenuItem });
            EditTableToolStripMenuItem.Name = "EditTableToolStripMenuItem";
            EditTableToolStripMenuItem.Size = new Size(147, 20);
            EditTableToolStripMenuItem.Text = "Редактировать таблицу";
            // 
            // AddElementToolStripMenuItem
            // 
            AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            AddElementToolStripMenuItem.Size = new Size(180, 22);
            AddElementToolStripMenuItem.Text = "Добавить элемент";
            AddElementToolStripMenuItem.Click += AddElementToolStripMenuItem_Click;
            // 
            // ChangeItemToolStripMenuItem
            // 
            ChangeItemToolStripMenuItem.Name = "ChangeItemToolStripMenuItem";
            ChangeItemToolStripMenuItem.Size = new Size(180, 22);
            ChangeItemToolStripMenuItem.Text = "Изменить элемент";
            ChangeItemToolStripMenuItem.Click += ChangeElementToolStripMenuItem_Click;
            // 
            // RemoveElementToolStripMenuItem
            // 
            RemoveElementToolStripMenuItem.Name = "RemoveElementToolStripMenuItem";
            RemoveElementToolStripMenuItem.Size = new Size(180, 22);
            RemoveElementToolStripMenuItem.Text = "Удалить элемент";
            RemoveElementToolStripMenuItem.Click += RemoveElementToolStripMenuItem_Click;
            // 
            // ViewData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(774, 421);
            Controls.Add(dataGridView);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            MinimumSize = new Size(790, 460);
            Name = "ViewData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр данных библиотеки";
            Load += ViewData_Load;
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnBack).EndInit();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem EditTableToolStripMenuItem;
        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem ChangeItemToolStripMenuItem;
        private ToolStripMenuItem RemoveElementToolStripMenuItem;
        private PictureBox btnBack;
    }
}