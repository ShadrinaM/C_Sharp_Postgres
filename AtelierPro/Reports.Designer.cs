namespace AtelierPro
{
    partial class Reports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reports));
            panelHeader = new Panel();
            btnBack = new Button();
            lblTitle = new Label();
            picLogo = new PictureBox();
            label1 = new Label();
            comboBox = new ComboBox();
            dataGridView = new DataGridView();
            DataStart = new Label();
            DataEnd = new Label();
            dateTimePickerStart = new DateTimePicker();
            dateTimePickerEnd = new DateTimePicker();
            checkedListBox = new CheckedListBox();
            selectedMaterial = new Label();
            btnGenerateReport = new Button();
            btnExportExcel = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(29, 29, 27);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(comboBox);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
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
            btnBack.Location = new Point(10, 14);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(33, 69);
            btnBack.TabIndex = 18;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += this.btnBack_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(560, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 62);
            lblTitle.TabIndex = 17;
            lblTitle.Text = "AtelierPro";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(814, 16);
            picLogo.Margin = new Padding(3, 4, 3, 4);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(155, 66);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 16;
            picLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 10);
            label1.Name = "label1";
            label1.Size = new Size(152, 35);
            label1.TabIndex = 15;
            label1.Text = "Тип отчёта:";
            // 
            // comboBox
            // 
            comboBox.BackColor = Color.Black;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Font = new Font("Segoe UI", 14F);
            comboBox.ForeColor = SystemColors.Control;
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(49, 46);
            comboBox.Margin = new Padding(3, 4, 3, 4);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(486, 39);
            comboBox.TabIndex = 14;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
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
            dataGridView.Location = new Point(15, 301);
            dataGridView.Margin = new Padding(3, 4, 3, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(955, 339);
            dataGridView.TabIndex = 2;
            // 
            // DataStart
            // 
            DataStart.AutoSize = true;
            DataStart.Font = new Font("Microsoft Sans Serif", 14.25F);
            DataStart.Location = new Point(10, 105);
            DataStart.Name = "DataStart";
            DataStart.Size = new Size(162, 29);
            DataStart.TabIndex = 5;
            DataStart.Text = "Дата начала:";
            // 
            // DataEnd
            // 
            DataEnd.AutoSize = true;
            DataEnd.Font = new Font("Microsoft Sans Serif", 14.25F);
            DataEnd.Location = new Point(10, 142);
            DataEnd.Name = "DataEnd";
            DataEnd.Size = new Size(148, 29);
            DataEnd.TabIndex = 6;
            DataEnd.Text = "Дата конца:";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(178, 107);
            dateTimePickerStart.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(362, 27);
            dateTimePickerStart.TabIndex = 7;
            dateTimePickerStart.Value = new DateTime(2022, 1, 1);
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(178, 144);
            dateTimePickerEnd.Margin = new Padding(3, 4, 3, 4);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(362, 27);
            dateTimePickerEnd.TabIndex = 8;
            // 
            // checkedListBox
            // 
            checkedListBox.FormattingEnabled = true;
            checkedListBox.Location = new Point(178, 179);
            checkedListBox.Margin = new Padding(3, 4, 3, 4);
            checkedListBox.Name = "checkedListBox";
            checkedListBox.Size = new Size(362, 114);
            checkedListBox.TabIndex = 9;
            // 
            // selectedMaterial
            // 
            selectedMaterial.AutoSize = true;
            selectedMaterial.Font = new Font("Microsoft Sans Serif", 14.25F);
            selectedMaterial.Location = new Point(10, 179);
            selectedMaterial.Name = "selectedMaterial";
            selectedMaterial.Size = new Size(152, 29);
            selectedMaterial.TabIndex = 10;
            selectedMaterial.Text = "Материалы:";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = SystemColors.ActiveCaptionText;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(727, 249);
            btnGenerateReport.Margin = new Padding(3, 4, 3, 4);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(242, 44);
            btnGenerateReport.TabIndex = 12;
            btnGenerateReport.Text = "Сформировать отчёт";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = SystemColors.ActiveCaptionText;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(727, 197);
            btnExportExcel.Margin = new Padding(3, 4, 3, 4);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(242, 44);
            btnExportExcel.TabIndex = 13;
            btnExportExcel.Text = "Экспортировать Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Visible = false;
            btnExportExcel.Click += btnExportExel_Click;
            // 
            // Reports
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 653);
            Controls.Add(btnExportExcel);
            Controls.Add(btnGenerateReport);
            Controls.Add(selectedMaterial);
            Controls.Add(checkedListBox);
            Controls.Add(dateTimePickerEnd);
            Controls.Add(dateTimePickerStart);
            Controls.Add(DataEnd);
            Controls.Add(DataStart);
            Controls.Add(dataGridView);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 700);
            Name = "Reports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Составление отчёта";
            Load += Reports_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private DataGridView dataGridView;
        private Button btnBack;
        private Label DataStart;
        private Label DataEnd;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private CheckedListBox checkedListBox;
        private Label selectedMaterial;
        private Button btnGenerateReport;
        private Button btnExportExcel;
        private ComboBox comboBox;
        private Label label1;
        private Label lblTitle;
        private PictureBox picLogo;
    }
}