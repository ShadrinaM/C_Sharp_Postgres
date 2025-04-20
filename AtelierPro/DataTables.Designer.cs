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
            lblTitle = new Label();
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
            panelHeader.BackColor = SystemColors.ActiveCaptionText;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 100);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(599, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(213, 54);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "AtelierPro";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(818, 15);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(70, 70);
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
            comboBoxTables.Items.AddRange(new object[] { "Изделия (Products)", "Поставщики (Suppliers)", "Заказы (Orders)", "Приходные накладные (IncomingInvoices)", "Расходные накладные (OutgoingInvoices)", "Материалы (Material)", "Нормы расхода (MaterialUsage)" });
            comboBoxTables.Location = new Point(12, 140);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(350, 33);
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
            dataGridView.Location = new Point(12, 179);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(876, 409);
            dataGridView.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ActiveCaptionText;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(788, 140);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 33);
            btnBack.TabIndex = 3;
            btnBack.Text = "Выход";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Items.AddRange(new ToolStripItem[] { EditTableToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // EditTableToolStripMenuItem
            // 
            EditTableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddElementToolStripMenuItem, ChangeItemToolStripMenuItem, RemoveElementToolStripMenuItem });
            EditTableToolStripMenuItem.ForeColor = Color.Black;
            EditTableToolStripMenuItem.Name = "EditTableToolStripMenuItem";
            EditTableToolStripMenuItem.Size = new Size(147, 20);
            EditTableToolStripMenuItem.Text = "Редактировать таблицу";
            // 
            // AddElementToolStripMenuItem
            // 
            AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            AddElementToolStripMenuItem.Size = new Size(180, 22);
            AddElementToolStripMenuItem.Text = "Добавить элемент";
            // 
            // ChangeItemToolStripMenuItem
            // 
            ChangeItemToolStripMenuItem.Name = "ChangeItemToolStripMenuItem";
            ChangeItemToolStripMenuItem.Size = new Size(180, 22);
            ChangeItemToolStripMenuItem.Text = "Изменить элемент";
            // 
            // RemoveElementToolStripMenuItem
            // 
            RemoveElementToolStripMenuItem.Name = "RemoveElementToolStripMenuItem";
            RemoveElementToolStripMenuItem.Size = new Size(180, 22);
            RemoveElementToolStripMenuItem.Text = "Удалить элемент";
            // 
            // DataTables
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 600);
            Controls.Add(btnBack);
            Controls.Add(dataGridView);
            Controls.Add(comboBoxTables);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            MinimumSize = new Size(916, 639);
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem EditTableToolStripMenuItem;
        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem ChangeItemToolStripMenuItem;
        private ToolStripMenuItem RemoveElementToolStripMenuItem;
    }
}