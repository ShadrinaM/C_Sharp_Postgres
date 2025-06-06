﻿namespace AtelierPro
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
            btnBack = new Button();
            lblTitle = new Label();
            picLogo = new PictureBox();
            TitleReport = new Label();
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
            panelHeader.BackColor = Color.FromArgb(29, 29, 27);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Controls.Add(TitleReport);
            panelHeader.Controls.Add(comboBoxInvoices);
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
            btnBack.Location = new Point(7, 10);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(33, 74);
            btnBack.TabIndex = 8;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(560, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 62);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "AtelierPro";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(814, 17);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(155, 66);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 6;
            picLogo.TabStop = false;
            // 
            // TitleReport
            // 
            TitleReport.AutoSize = true;
            TitleReport.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            TitleReport.ForeColor = Color.White;
            TitleReport.Location = new Point(44, 10);
            TitleReport.Name = "TitleReport";
            TitleReport.Size = new Size(204, 35);
            TitleReport.TabIndex = 5;
            TitleReport.Text = "Тип накладной:";
            // 
            // comboBoxInvoices
            // 
            comboBoxInvoices.BackColor = Color.Black;
            comboBoxInvoices.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxInvoices.Font = new Font("Segoe UI", 14F);
            comboBoxInvoices.ForeColor = SystemColors.Control;
            comboBoxInvoices.FormattingEnabled = true;
            comboBoxInvoices.Location = new Point(46, 44);
            comboBoxInvoices.Margin = new Padding(3, 4, 3, 4);
            comboBoxInvoices.Name = "comboBoxInvoices";
            comboBoxInvoices.Size = new Size(399, 39);
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
            dataGridViewInvoices.Location = new Point(14, 135);
            dataGridViewInvoices.Margin = new Padding(3, 4, 3, 4);
            dataGridViewInvoices.Name = "dataGridViewInvoices";
            dataGridViewInvoices.ReadOnly = true;
            dataGridViewInvoices.RowHeadersWidth = 51;
            dataGridViewInvoices.Size = new Size(956, 233);
            dataGridViewInvoices.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.ForeColor = Color.White;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { EditTableToolStripMenuItem, редактироватьЭлементToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(982, 30);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // EditTableToolStripMenuItem
            // 
            EditTableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddElementToolStripMenuItem, ChangeItemToolStripMenuItem, RemoveElementToolStripMenuItem });
            EditTableToolStripMenuItem.ForeColor = Color.Black;
            EditTableToolStripMenuItem.Name = "EditTableToolStripMenuItem";
            EditTableToolStripMenuItem.Size = new Size(205, 24);
            EditTableToolStripMenuItem.Text = "Редактировать накладную";
            // 
            // AddElementToolStripMenuItem
            // 
            AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            AddElementToolStripMenuItem.Size = new Size(241, 26);
            AddElementToolStripMenuItem.Text = "Добавить накладную";
            AddElementToolStripMenuItem.Click += AddInvoiceToolStripMenuItem_Click;
            // 
            // ChangeItemToolStripMenuItem
            // 
            ChangeItemToolStripMenuItem.Name = "ChangeItemToolStripMenuItem";
            ChangeItemToolStripMenuItem.Size = new Size(241, 26);
            ChangeItemToolStripMenuItem.Text = "Изменить накладную";
            ChangeItemToolStripMenuItem.Click += ChangeInvoiceToolStripMenuItem_Click;
            // 
            // RemoveElementToolStripMenuItem
            // 
            RemoveElementToolStripMenuItem.Name = "RemoveElementToolStripMenuItem";
            RemoveElementToolStripMenuItem.Size = new Size(241, 26);
            RemoveElementToolStripMenuItem.Text = "Удалить накладную";
            RemoveElementToolStripMenuItem.Click += RemoveInvoiceToolStripMenuItem_Click;
            // 
            // редактироватьЭлементToolStripMenuItem
            // 
            редактироватьЭлементToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьЭлементToolStripMenuItem, изменитьЭлементToolStripMenuItem, удалитьЭлементToolStripMenuItem });
            редактироватьЭлементToolStripMenuItem.ForeColor = Color.Black;
            редактироватьЭлементToolStripMenuItem.Name = "редактироватьЭлементToolStripMenuItem";
            редактироватьЭлементToolStripMenuItem.Size = new Size(186, 24);
            редактироватьЭлементToolStripMenuItem.Text = "Редактировать элемент";
            // 
            // добавитьЭлементToolStripMenuItem
            // 
            добавитьЭлементToolStripMenuItem.Name = "добавитьЭлементToolStripMenuItem";
            добавитьЭлементToolStripMenuItem.Size = new Size(224, 26);
            добавитьЭлементToolStripMenuItem.Text = "Добавить элемент";
            добавитьЭлементToolStripMenuItem.Click += AddItemToolStripMenuItem_Click;
            // 
            // изменитьЭлементToolStripMenuItem
            // 
            изменитьЭлементToolStripMenuItem.Name = "изменитьЭлементToolStripMenuItem";
            изменитьЭлементToolStripMenuItem.Size = new Size(224, 26);
            изменитьЭлементToolStripMenuItem.Text = "Изменить элемент";
            изменитьЭлементToolStripMenuItem.Click += ChangeItemToolStripMenuItem_Click;
            // 
            // удалитьЭлементToolStripMenuItem
            // 
            удалитьЭлементToolStripMenuItem.Name = "удалитьЭлементToolStripMenuItem";
            удалитьЭлементToolStripMenuItem.Size = new Size(224, 26);
            удалитьЭлементToolStripMenuItem.Text = "Удалить элемент";
            удалитьЭлементToolStripMenuItem.Click += RemoveItemToolStripMenuItem_Click;
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
            dataGridViewInvoicesItems.Location = new Point(12, 376);
            dataGridViewInvoicesItems.Margin = new Padding(3, 4, 3, 4);
            dataGridViewInvoicesItems.Name = "dataGridViewInvoicesItems";
            dataGridViewInvoicesItems.ReadOnly = true;
            dataGridViewInvoicesItems.RowHeadersWidth = 51;
            dataGridViewInvoicesItems.Size = new Size(955, 264);
            dataGridViewInvoicesItems.TabIndex = 5;
            // 
            // Invoices
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 653);
            Controls.Add(dataGridViewInvoicesItems);
            Controls.Add(dataGridViewInvoices);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 700);
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
        private Label lblTitle;
        private PictureBox picLogo;
        private Button btnBack;
    }
}