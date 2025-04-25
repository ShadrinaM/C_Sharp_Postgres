namespace AtelierPro
{
    partial class Invoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Invoices));
            panelHeader = new Panel();
            TitleReport = new Label();
            lblTitle = new Label();
            picLogo = new PictureBox();
            comboBoxInvoices = new ComboBox();
            dataGridViewInvoices = new DataGridView();
            menuStrip1 = new MenuStrip();
            EditTableToolStripMenuItem = new ToolStripMenuItem();
            AddElementToolStripMenuItem = new ToolStripMenuItem();
            ChangeItemToolStripMenuItem = new ToolStripMenuItem();
            RemoveElementToolStripMenuItem = new ToolStripMenuItem();
            редактироватьЭлементToolStripMenuItem = new ToolStripMenuItem();
            добавитьЭлементToolStripMenuItem = new ToolStripMenuItem();
            изменитьЭлементToolStripMenuItem = new ToolStripMenuItem();
            удалитьЭлементToolStripMenuItem = new ToolStripMenuItem();
            dataGridViewInvoicesItems = new DataGridView();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoices).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoicesItems).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaptionText;
            panelHeader.Controls.Add(TitleReport);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Controls.Add(comboBoxInvoices);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 100);
            panelHeader.TabIndex = 0;
            // 
            // TitleReport
            // 
            TitleReport.AutoSize = true;
            TitleReport.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            TitleReport.ForeColor = Color.White;
            TitleReport.Location = new Point(12, 11);
            TitleReport.Name = "TitleReport";
            TitleReport.Size = new Size(225, 37);
            TitleReport.TabIndex = 5;
            TitleReport.Text = "Тип накладной:";
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
            // comboBoxInvoices
            // 
            comboBoxInvoices.BackColor = Color.Black;
            comboBoxInvoices.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInvoices.Font = new Font("Segoe UI", 14F);
            comboBoxInvoices.ForeColor = SystemColors.Control;
            comboBoxInvoices.FormattingEnabled = true;
            comboBoxInvoices.Location = new Point(12, 51);
            comboBoxInvoices.Name = "comboBoxInvoices";
            comboBoxInvoices.Size = new Size(350, 33);
            comboBoxInvoices.TabIndex = 1;
            comboBoxInvoices.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
            // 
            // dataGridViewInvoices
            // 
            dataGridViewInvoices.AllowUserToAddRows = false;
            dataGridViewInvoices.AllowUserToDeleteRows = false;
            dataGridViewInvoices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInvoices.BackgroundColor = Color.White;
            dataGridViewInvoices.BorderStyle = BorderStyle.None;
            dataGridViewInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInvoices.GridColor = SystemColors.ActiveCaptionText;
            dataGridViewInvoices.Location = new Point(12, 130);
            dataGridViewInvoices.Name = "dataGridViewInvoices";
            dataGridViewInvoices.ReadOnly = true;
            dataGridViewInvoices.Size = new Size(876, 186);
            dataGridViewInvoices.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Items.AddRange(new ToolStripItem[] { EditTableToolStripMenuItem, редактироватьЭлементToolStripMenuItem });
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
            EditTableToolStripMenuItem.Size = new Size(163, 20);
            EditTableToolStripMenuItem.Text = "Редактировать накладную";
            // 
            // AddElementToolStripMenuItem
            // 
            AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            AddElementToolStripMenuItem.Size = new Size(192, 22);
            AddElementToolStripMenuItem.Text = "Добавить накладную";
            // 
            // ChangeItemToolStripMenuItem
            // 
            ChangeItemToolStripMenuItem.Name = "ChangeItemToolStripMenuItem";
            ChangeItemToolStripMenuItem.Size = new Size(192, 22);
            ChangeItemToolStripMenuItem.Text = "Изменить накладную";
            // 
            // RemoveElementToolStripMenuItem
            // 
            RemoveElementToolStripMenuItem.Name = "RemoveElementToolStripMenuItem";
            RemoveElementToolStripMenuItem.Size = new Size(192, 22);
            RemoveElementToolStripMenuItem.Text = "Удалить накладную";
            // 
            // редактироватьЭлементToolStripMenuItem
            // 
            редактироватьЭлементToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьЭлементToolStripMenuItem, изменитьЭлементToolStripMenuItem, удалитьЭлементToolStripMenuItem });
            редактироватьЭлементToolStripMenuItem.ForeColor = Color.Black;
            редактироватьЭлементToolStripMenuItem.Name = "редактироватьЭлементToolStripMenuItem";
            редактироватьЭлементToolStripMenuItem.Size = new Size(148, 20);
            редактироватьЭлементToolStripMenuItem.Text = "Редактировать элемент";
            // 
            // добавитьЭлементToolStripMenuItem
            // 
            добавитьЭлементToolStripMenuItem.Name = "добавитьЭлементToolStripMenuItem";
            добавитьЭлементToolStripMenuItem.Size = new Size(180, 22);
            добавитьЭлементToolStripMenuItem.Text = "Добавить элемент";
            добавитьЭлементToolStripMenuItem.Click += добавитьЭлементToolStripMenuItem_Click;
            // 
            // изменитьЭлементToolStripMenuItem
            // 
            изменитьЭлементToolStripMenuItem.Name = "изменитьЭлементToolStripMenuItem";
            изменитьЭлементToolStripMenuItem.Size = new Size(180, 22);
            изменитьЭлементToolStripMenuItem.Text = "Изменить элемент";
            // 
            // удалитьЭлементToolStripMenuItem
            // 
            удалитьЭлементToolStripMenuItem.Name = "удалитьЭлементToolStripMenuItem";
            удалитьЭлементToolStripMenuItem.Size = new Size(180, 22);
            удалитьЭлементToolStripMenuItem.Text = "Удалить элемент";
            // 
            // dataGridViewInvoicesItems
            // 
            dataGridViewInvoicesItems.AllowUserToAddRows = false;
            dataGridViewInvoicesItems.AllowUserToDeleteRows = false;
            dataGridViewInvoicesItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInvoicesItems.BackgroundColor = Color.White;
            dataGridViewInvoicesItems.BorderStyle = BorderStyle.None;
            dataGridViewInvoicesItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInvoicesItems.GridColor = SystemColors.ActiveCaptionText;
            dataGridViewInvoicesItems.Location = new Point(12, 322);
            dataGridViewInvoicesItems.Name = "dataGridViewInvoicesItems";
            dataGridViewInvoicesItems.ReadOnly = true;
            dataGridViewInvoicesItems.Size = new Size(876, 266);
            dataGridViewInvoicesItems.TabIndex = 5;
            // 
            // Invoices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 600);
            Controls.Add(dataGridViewInvoicesItems);
            Controls.Add(dataGridViewInvoices);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            MinimumSize = new Size(916, 639);
            Name = "Invoices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Просмотр таблиц";
            Load += Invoices_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoices).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInvoicesItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private PictureBox picLogo;
        private ComboBox comboBoxInvoices;
        private DataGridView dataGridViewInvoices;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem EditTableToolStripMenuItem;
        private ToolStripMenuItem AddElementToolStripMenuItem;
        private ToolStripMenuItem ChangeItemToolStripMenuItem;
        private ToolStripMenuItem RemoveElementToolStripMenuItem;
        private ToolStripMenuItem редактироватьЭлементToolStripMenuItem;
        private ToolStripMenuItem добавитьЭлементToolStripMenuItem;
        private ToolStripMenuItem изменитьЭлементToolStripMenuItem;
        private ToolStripMenuItem удалитьЭлементToolStripMenuItem;
        private Label TitleReport;
        private DataGridView dataGridViewInvoicesItems;
    }
}