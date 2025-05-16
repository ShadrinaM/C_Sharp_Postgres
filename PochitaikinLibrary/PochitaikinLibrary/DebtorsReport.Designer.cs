namespace PochitaikinLibrary
{
    partial class DebtorsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebtorsReport));
            panelHeader = new Panel();
            btnGenerateReport = new Button();
            btnBack = new PictureBox();
            label1 = new Label();
            btnExportExcel = new Button();
            dataGridView = new DataGridView();
            DataStart = new Label();
            dateTimePickerStart = new DateTimePicker();
            checkedListBoxUniversities = new CheckedListBox();
            selectedMaterial = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnBack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveBorder;
            panelHeader.Controls.Add(btnGenerateReport);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(btnExportExcel);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(9, 8, 9, 8);
            panelHeader.Size = new Size(861, 73);
            panelHeader.TabIndex = 0;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = SystemColors.ControlDarkDark;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(459, 23);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(192, 33);
            btnGenerateReport.TabIndex = 12;
            btnGenerateReport.Text = "Сформировать отчёт";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
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
            label1.Size = new Size(298, 37);
            label1.TabIndex = 15;
            label1.Text = "Отчёт по должникам";
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = SystemColors.ControlDarkDark;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(657, 23);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(192, 33);
            btnExportExcel.TabIndex = 13;
            btnExportExcel.Text = "Экспортировать Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
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
            dataGridView.Location = new Point(13, 226);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(836, 254);
            dataGridView.TabIndex = 2;
            // 
            // DataStart
            // 
            DataStart.AutoSize = true;
            DataStart.Font = new Font("Microsoft Sans Serif", 14.25F);
            DataStart.Location = new Point(9, 79);
            DataStart.Name = "DataStart";
            DataStart.Size = new Size(150, 24);
            DataStart.TabIndex = 5;
            DataStart.Text = "Дата проверки:";
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(165, 79);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(299, 23);
            dateTimePickerStart.TabIndex = 7;
            // 
            // checkedListBoxUniversities
            // 
            checkedListBoxUniversities.FormattingEnabled = true;
            checkedListBoxUniversities.Location = new Point(165, 133);
            checkedListBoxUniversities.Name = "checkedListBoxUniversities";
            checkedListBoxUniversities.Size = new Size(299, 76);
            checkedListBoxUniversities.TabIndex = 9;
            // 
            // selectedMaterial
            // 
            selectedMaterial.AutoSize = true;
            selectedMaterial.Font = new Font("Microsoft Sans Serif", 14.25F);
            selectedMaterial.Location = new Point(94, 133);
            selectedMaterial.Name = "selectedMaterial";
            selectedMaterial.Size = new Size(65, 24);
            selectedMaterial.TabIndex = 10;
            selectedMaterial.Text = "ВУЗы:";
            // 
            // DebtorsReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(861, 496);
            Controls.Add(selectedMaterial);
            Controls.Add(checkedListBoxUniversities);
            Controls.Add(dateTimePickerStart);
            Controls.Add(DataStart);
            Controls.Add(dataGridView);
            Controls.Add(panelHeader);
            MinimumSize = new Size(877, 535);
            Name = "DebtorsReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчет о просроченных книгах";
            Load += OverdueBooksReport_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnBack).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private DataGridView dataGridView;
        private Label DataStart;
        private DateTimePicker dateTimePickerStart;
        private CheckedListBox checkedListBoxUniversities;
        private Label selectedMaterial;
        private Button btnGenerateReport;
        private Button btnExportExcel;
        private Label label1;
        private PictureBox btnBack;
    }
}