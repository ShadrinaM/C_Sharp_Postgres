namespace PochitaikinLibrary.Forms
{
    partial class StudentForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelFullName;
        private TextBox textBoxFullName;
        private Label labelUniversity;
        private ComboBox comboBoxUniversity;
        private Button btnOK;
        private Button btnCancel;
        private Panel panelHeader;
        private Label labelTitle;

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
            labelFullName = new Label();
            textBoxFullName = new TextBox();
            labelUniversity = new Label();
            comboBoxUniversity = new ComboBox();
            btnOK = new Button();
            btnCancel = new Button();
            panelHeader = new Panel();
            labelTitle = new Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelFullName
            // 
            labelFullName.AutoSize = true;
            labelFullName.Font = new Font("Segoe UI", 12F);
            labelFullName.Location = new Point(10, 58);
            labelFullName.Name = "labelFullName";
            labelFullName.Size = new Size(46, 21);
            labelFullName.TabIndex = 0;
            labelFullName.Text = "ФИО";
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(172, 61);
            textBoxFullName.Margin = new Padding(3, 2, 3, 2);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(219, 23);
            textBoxFullName.TabIndex = 1;
            // 
            // labelUniversity
            // 
            labelUniversity.AutoSize = true;
            labelUniversity.Font = new Font("Segoe UI", 12F);
            labelUniversity.Location = new Point(10, 88);
            labelUniversity.Name = "labelUniversity";
            labelUniversity.Size = new Size(100, 21);
            labelUniversity.TabIndex = 2;
            labelUniversity.Text = "Университет";
            // 
            // comboBoxUniversity
            // 
            comboBoxUniversity.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUniversity.FormattingEnabled = true;
            comboBoxUniversity.Location = new Point(172, 91);
            comboBoxUniversity.Margin = new Padding(3, 2, 3, 2);
            comboBoxUniversity.Name = "comboBoxUniversity";
            comboBoxUniversity.Size = new Size(219, 23);
            comboBoxUniversity.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveBorder;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOK.ForeColor = Color.Black;
            btnOK.Location = new Point(10, 126);
            btnOK.Margin = new Padding(3, 2, 3, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(157, 33);
            btnOK.TabIndex = 4;
            btnOK.Text = "ОК";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveBorder;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(234, 126);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(157, 33);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveBorder;
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(405, 48);
            panelHeader.TabIndex = 6;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(10, 7);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(269, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Добавление студента";
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 168);
            Controls.Add(panelHeader);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(comboBoxUniversity);
            Controls.Add(labelUniversity);
            Controls.Add(textBoxFullName);
            Controls.Add(labelFullName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StudentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Студент";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}