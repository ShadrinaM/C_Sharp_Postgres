namespace AtelierPro.AddEditFormForTables
{
    partial class AddEditSupplierForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelSupplierName;
        private TextBox txtSupplierName;
        private Label labelContactPerson;
        private TextBox txtContactPerson;
        private Label labelPhone;
        private TextBox txtPhone;
        private Label labelEmail;
        private TextBox txtEmail;
        private Label labelAddress;
        private TextBox txtAddress;
        private Label labelNotes;
        private TextBox txtNotes;
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
            labelSupplierName = new Label();
            txtSupplierName = new TextBox();
            labelContactPerson = new Label();
            txtContactPerson = new TextBox();
            labelPhone = new Label();
            txtPhone = new TextBox();
            labelEmail = new Label();
            txtEmail = new TextBox();
            labelAddress = new Label();
            txtAddress = new TextBox();
            labelNotes = new Label();
            txtNotes = new TextBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelSupplierName
            // 
            labelSupplierName.AutoSize = true;
            labelSupplierName.Font = new Font("Segoe UI", 12F);
            labelSupplierName.Location = new Point(12, 77);
            labelSupplierName.Name = "labelSupplierName";
            labelSupplierName.Size = new Size(166, 28);
            labelSupplierName.TabIndex = 0;
            labelSupplierName.Text = "Имя поставщика";
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(197, 81);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(250, 27);
            txtSupplierName.TabIndex = 1;
            // 
            // labelContactPerson
            // 
            labelContactPerson.AutoSize = true;
            labelContactPerson.Font = new Font("Segoe UI", 12F);
            labelContactPerson.Location = new Point(12, 117);
            labelContactPerson.Name = "labelContactPerson";
            labelContactPerson.Size = new Size(170, 28);
            labelContactPerson.TabIndex = 2;
            labelContactPerson.Text = "Контактное лицо";
            // 
            // txtContactPerson
            // 
            txtContactPerson.Location = new Point(197, 121);
            txtContactPerson.Name = "txtContactPerson";
            txtContactPerson.Size = new Size(250, 27);
            txtContactPerson.TabIndex = 3;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 12F);
            labelPhone.Location = new Point(12, 157);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(91, 28);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Телефон";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(197, 161);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 27);
            txtPhone.TabIndex = 5;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 12F);
            labelEmail.Location = new Point(12, 197);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(59, 28);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(197, 201);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 7;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 12F);
            labelAddress.Location = new Point(12, 237);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(67, 28);
            labelAddress.TabIndex = 8;
            labelAddress.Text = "Адрес";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(197, 241);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Size = new Size(250, 60);
            txtAddress.TabIndex = 9;
            // 
            // labelNotes
            // 
            labelNotes.AutoSize = true;
            labelNotes.Font = new Font("Segoe UI", 12F);
            labelNotes.Location = new Point(12, 307);
            labelNotes.Name = "labelNotes";
            labelNotes.Size = new Size(129, 28);
            labelNotes.TabIndex = 10;
            labelNotes.Text = "Примечание";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(197, 311);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(250, 60);
            txtNotes.TabIndex = 11;
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
            labelTitle.Size = new Size(381, 41);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Добавление поставщика";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveCaptionText;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(268, 388);
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
            btnOK.Location = new Point(12, 388);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(179, 44);
            btnOK.TabIndex = 21;
            btnOK.Text = "ОК";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // AddEditSupplierForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 446);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(panelHeader);
            Controls.Add(txtNotes);
            Controls.Add(labelNotes);
            Controls.Add(txtAddress);
            Controls.Add(labelAddress);
            Controls.Add(txtEmail);
            Controls.Add(labelEmail);
            Controls.Add(txtPhone);
            Controls.Add(labelPhone);
            Controls.Add(txtContactPerson);
            Controls.Add(labelContactPerson);
            Controls.Add(txtSupplierName);
            Controls.Add(labelSupplierName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditSupplierForm";
            Text = "Поставщик";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}