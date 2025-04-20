namespace AtelierPro
{
    partial class ReportsMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsMaterial));
            panelHeader = new Panel();
            TitleReport = new Label();
            lblTitle = new Label();
            picLogo = new PictureBox();
            dataGridView = new DataGridView();
            btnBack = new Button();
            DataStart = new Label();
            DataEnd = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            checkedListBox1 = new CheckedListBox();
            selectedMaterial = new Label();
            btnGenerateReport = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaptionText;
            panelHeader.Controls.Add(TitleReport);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(picLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 100);
            panelHeader.TabIndex = 0;
            // 
            // TitleReport
            // 
            TitleReport.AutoSize = true;
            TitleReport.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TitleReport.ForeColor = Color.White;
            TitleReport.Location = new Point(12, 53);
            TitleReport.Name = "TitleReport";
            TitleReport.Size = new Size(492, 32);
            TitleReport.TabIndex = 2;
            TitleReport.Text = "Отчёт по материалам (их поставщикам)";
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
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.GridColor = SystemColors.Control;
            dataGridView.Location = new Point(12, 288);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.Size = new Size(876, 300);
            dataGridView.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.ActiveCaptionText;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(788, 106);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 33);
            btnBack.TabIndex = 3;
            btnBack.Text = "Выход";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // DataStart
            // 
            DataStart.AutoSize = true;
            DataStart.Font = new Font("Microsoft Sans Serif", 14.25F);
            DataStart.Location = new Point(13, 103);
            DataStart.Name = "DataStart";
            DataStart.Size = new Size(120, 24);
            DataStart.TabIndex = 5;
            DataStart.Text = "Дата начала";
            // 
            // DataEnd
            // 
            DataEnd.AutoSize = true;
            DataEnd.Font = new Font("Microsoft Sans Serif", 14.25F);
            DataEnd.Location = new Point(13, 138);
            DataEnd.Name = "DataEnd";
            DataEnd.Size = new Size(111, 24);
            DataEnd.TabIndex = 6;
            DataEnd.Text = "Дата конца";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(139, 106);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(139, 139);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 8;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(139, 173);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(317, 94);
            checkedListBox1.TabIndex = 9;
            // 
            // selectedMaterial
            // 
            selectedMaterial.AutoSize = true;
            selectedMaterial.Font = new Font("Microsoft Sans Serif", 14.25F);
            selectedMaterial.Location = new Point(13, 173);
            selectedMaterial.Name = "selectedMaterial";
            selectedMaterial.Size = new Size(112, 24);
            selectedMaterial.TabIndex = 10;
            selectedMaterial.Text = "Материалы";
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = SystemColors.ActiveCaptionText;
            btnGenerateReport.FlatAppearance.BorderSize = 0;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(676, 234);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(212, 33);
            btnGenerateReport.TabIndex = 12;
            btnGenerateReport.Text = "Сформировать отчёт";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // ReportsMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(900, 600);
            Controls.Add(btnGenerateReport);
            Controls.Add(selectedMaterial);
            Controls.Add(checkedListBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(DataEnd);
            Controls.Add(DataStart);
            Controls.Add(btnBack);
            Controls.Add(dataGridView);
            Controls.Add(panelHeader);
            MinimumSize = new Size(916, 639);
            Name = "ReportsMaterial";
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
        private Label lblTitle;
        private PictureBox picLogo;
        private DataGridView dataGridView;
        private Button btnBack;
        private Label DataStart;
        private Label DataEnd;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private CheckedListBox checkedListBox1;
        private Label selectedMaterial;
        private Button btnGenerateReport;
        private Label TitleReport;
    }
}