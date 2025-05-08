namespace AtelierPro
{
    partial class AddEditInvoiceForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelInvoiceNumber;
        private System.Windows.Forms.TextBox textBoxInvoiceNumber;
        private System.Windows.Forms.Label labelInvoiceDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerInvoiceDate;
        private System.Windows.Forms.Label labelDeliveryDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryDate;
        private System.Windows.Forms.Label labelClientOrSupplier;
        private System.Windows.Forms.ComboBox comboBoxClientOrSupplier;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox textBoxNotes;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelInvoiceNumber = new Label();
            textBoxInvoiceNumber = new TextBox();
            labelInvoiceDate = new Label();
            dateTimePickerInvoiceDate = new DateTimePicker();
            labelDeliveryDate = new Label();
            dateTimePickerDeliveryDate = new DateTimePicker();
            labelClientOrSupplier = new Label();
            comboBoxClientOrSupplier = new ComboBox();
            labelNotes = new Label();
            textBoxNotes = new TextBox();
            panelHeader = new Panel();
            TitleReport = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelInvoiceNumber
            // 
            labelInvoiceNumber.AutoSize = true;
            labelInvoiceNumber.Font = new Font("Segoe UI", 12F);
            labelInvoiceNumber.Location = new Point(12, 77);
            labelInvoiceNumber.Name = "labelInvoiceNumber";
            labelInvoiceNumber.Size = new Size(179, 28);
            labelInvoiceNumber.TabIndex = 0;
            labelInvoiceNumber.Text = "Номер накладной";
            // 
            // textBoxInvoiceNumber
            // 
            textBoxInvoiceNumber.Location = new Point(197, 81);
            textBoxInvoiceNumber.Name = "textBoxInvoiceNumber";
            textBoxInvoiceNumber.Size = new Size(250, 27);
            textBoxInvoiceNumber.TabIndex = 1;
            // 
            // labelInvoiceDate
            // 
            labelInvoiceDate.AutoSize = true;
            labelInvoiceDate.Font = new Font("Segoe UI", 12F);
            labelInvoiceDate.Location = new Point(12, 117);
            labelInvoiceDate.Name = "labelInvoiceDate";
            labelInvoiceDate.Size = new Size(159, 28);
            labelInvoiceDate.TabIndex = 2;
            labelInvoiceDate.Text = "Дата накладной";
            // 
            // dateTimePickerInvoiceDate
            // 
            dateTimePickerInvoiceDate.Location = new Point(197, 119);
            dateTimePickerInvoiceDate.Name = "dateTimePickerInvoiceDate";
            dateTimePickerInvoiceDate.Size = new Size(250, 27);
            dateTimePickerInvoiceDate.TabIndex = 3;
            // 
            // labelDeliveryDate
            // 
            labelDeliveryDate.AutoSize = true;
            labelDeliveryDate.Font = new Font("Segoe UI", 12F);
            labelDeliveryDate.Location = new Point(12, 157);
            labelDeliveryDate.Name = "labelDeliveryDate";
            labelDeliveryDate.Size = new Size(143, 28);
            labelDeliveryDate.TabIndex = 4;
            labelDeliveryDate.Text = "Дата поставки";
            // 
            // dateTimePickerDeliveryDate
            // 
            dateTimePickerDeliveryDate.Location = new Point(197, 159);
            dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            dateTimePickerDeliveryDate.Size = new Size(250, 27);
            dateTimePickerDeliveryDate.TabIndex = 5;
            // 
            // labelClientOrSupplier
            // 
            labelClientOrSupplier.AutoSize = true;
            labelClientOrSupplier.Font = new Font("Segoe UI", 12F);
            labelClientOrSupplier.Location = new Point(12, 197);
            labelClientOrSupplier.Name = "labelClientOrSupplier";
            labelClientOrSupplier.Size = new Size(118, 28);
            labelClientOrSupplier.TabIndex = 6;
            labelClientOrSupplier.Text = "Поставщик:";
            // 
            // comboBoxClientOrSupplier
            // 
            comboBoxClientOrSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClientOrSupplier.FormattingEnabled = true;
            comboBoxClientOrSupplier.Location = new Point(197, 201);
            comboBoxClientOrSupplier.Name = "comboBoxClientOrSupplier";
            comboBoxClientOrSupplier.Size = new Size(250, 28);
            comboBoxClientOrSupplier.TabIndex = 7;
            // 
            // labelNotes
            // 
            labelNotes.AutoSize = true;
            labelNotes.Font = new Font("Segoe UI", 12F);
            labelNotes.Location = new Point(12, 237);
            labelNotes.Name = "labelNotes";
            labelNotes.Size = new Size(129, 28);
            labelNotes.TabIndex = 8;
            labelNotes.Text = "Примечание";
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(197, 241);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.ScrollBars = ScrollBars.Vertical;
            textBoxNotes.Size = new Size(250, 60);
            textBoxNotes.TabIndex = 9;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaptionText;
            panelHeader.Controls.Add(TitleReport);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(463, 64);
            panelHeader.TabIndex = 20;
            // 
            // TitleReport
            // 
            TitleReport.AutoSize = true;
            TitleReport.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TitleReport.ForeColor = Color.White;
            TitleReport.Location = new Point(12, 9);
            TitleReport.Name = "TitleReport";
            TitleReport.Size = new Size(364, 41);
            TitleReport.TabIndex = 5;
            TitleReport.Text = "Добавление накладной";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveCaptionText;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(268, 318);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(179, 44);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveCaptionText;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(12, 318);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(179, 44);
            btnOK.TabIndex = 21;
            btnOK.Text = "ОК";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnSave_Click;
            // 
            // AddEditInvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 376);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(panelHeader);
            Controls.Add(textBoxNotes);
            Controls.Add(labelNotes);
            Controls.Add(comboBoxClientOrSupplier);
            Controls.Add(labelClientOrSupplier);
            Controls.Add(dateTimePickerDeliveryDate);
            Controls.Add(labelDeliveryDate);
            Controls.Add(dateTimePickerInvoiceDate);
            Controls.Add(labelInvoiceDate);
            Controls.Add(textBoxInvoiceNumber);
            Controls.Add(labelInvoiceNumber);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditInvoiceForm";
            Text = "Накладная";
            Load += AddEditInvoiceForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label TitleReport;
        private Button btnCancel;
        private Button btnOK;
    }
}
