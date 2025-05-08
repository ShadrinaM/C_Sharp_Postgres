namespace AtelierPro.AddEditFormForTables
{
    partial class AddEditOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelCustomerName;
        private TextBox textBoxCustomerName;
        private Label labelOrderDate;
        private DateTimePicker dateTimePickerOrderDate;
        private Label labelDeliveryDate;
        private DateTimePicker dateTimePickerDeliveryDate;
        private Label labelStatus;
        private ComboBox comboBoxStatus;
        private Label labelNotes;
        private TextBox textBoxNotes;
        private Panel panelHeader;
        private Label labelTitle;
        private Button btnCancel;
        private Button btnOK;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelCustomerName = new Label();
            textBoxCustomerName = new TextBox();
            labelOrderDate = new Label();
            dateTimePickerOrderDate = new DateTimePicker();
            labelDeliveryDate = new Label();
            dateTimePickerDeliveryDate = new DateTimePicker();
            labelStatus = new Label();
            comboBoxStatus = new ComboBox();
            labelNotes = new Label();
            textBoxNotes = new TextBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelCustomerName
            // 
            labelCustomerName.AutoSize = true;
            labelCustomerName.Font = new Font("Segoe UI", 12F);
            labelCustomerName.Location = new Point(12, 77);
            labelCustomerName.Name = "labelCustomerName";
            labelCustomerName.Size = new Size(95, 28);
            labelCustomerName.TabIndex = 0;
            labelCustomerName.Text = "Заказчик";
            // 
            // textBoxCustomerName
            // 
            textBoxCustomerName.Location = new Point(197, 81);
            textBoxCustomerName.Name = "textBoxCustomerName";
            textBoxCustomerName.Size = new Size(250, 27);
            textBoxCustomerName.TabIndex = 1;
            // 
            // labelOrderDate
            // 
            labelOrderDate.AutoSize = true;
            labelOrderDate.Font = new Font("Segoe UI", 12F);
            labelOrderDate.Location = new Point(12, 117);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new Size(117, 28);
            labelOrderDate.TabIndex = 2;
            labelOrderDate.Text = "Дата заказа";
            // 
            // dateTimePickerOrderDate
            // 
            dateTimePickerOrderDate.Location = new Point(197, 121);
            dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            dateTimePickerOrderDate.Size = new Size(250, 27);
            dateTimePickerOrderDate.TabIndex = 3;
            // 
            // labelDeliveryDate
            // 
            labelDeliveryDate.AutoSize = true;
            labelDeliveryDate.Font = new Font("Segoe UI", 12F);
            labelDeliveryDate.Location = new Point(12, 157);
            labelDeliveryDate.Name = "labelDeliveryDate";
            labelDeliveryDate.Size = new Size(142, 28);
            labelDeliveryDate.TabIndex = 4;
            labelDeliveryDate.Text = "Дата доставки";
            // 
            // dateTimePickerDeliveryDate
            // 
            dateTimePickerDeliveryDate.Location = new Point(197, 161);
            dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            dateTimePickerDeliveryDate.Size = new Size(250, 27);
            dateTimePickerDeliveryDate.TabIndex = 5;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 12F);
            labelStatus.Location = new Point(12, 197);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(69, 28);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Статус";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Items.AddRange(new object[] { "Новый", "В работе", "Выполнен", "Отменен" });
            comboBoxStatus.Location = new Point(197, 201);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(250, 28);
            comboBoxStatus.TabIndex = 7;
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
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(463, 64);
            panelHeader.TabIndex = 20;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(12, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(298, 41);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Добавление заказа";
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
            btnOK.Click += btnOK_Click;
            // 
            // AddEditOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 376);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(panelHeader);
            Controls.Add(textBoxNotes);
            Controls.Add(labelNotes);
            Controls.Add(comboBoxStatus);
            Controls.Add(labelStatus);
            Controls.Add(dateTimePickerDeliveryDate);
            Controls.Add(labelDeliveryDate);
            Controls.Add(dateTimePickerOrderDate);
            Controls.Add(labelOrderDate);
            Controls.Add(textBoxCustomerName);
            Controls.Add(labelCustomerName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditOrderForm";
            Text = "Заказ";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}