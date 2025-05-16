namespace PochitaikinLibrary.Forms
{
    partial class UniversityForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelName;
        private TextBox textBoxName;
        private Button btnOK;
        private Button btnCancel;
        private Panel panelHeader;
        private Label labelHeader;

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
            labelName = new Label();
            textBoxName = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            panelHeader = new Panel();
            labelHeader = new Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F);
            labelName.Location = new Point(10, 58);
            labelName.Name = "labelName";
            labelName.Size = new Size(76, 21);
            labelName.TabIndex = 0;
            labelName.Text = "Название";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(172, 61);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(219, 23);
            textBoxName.TabIndex = 1;
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
            btnOK.TabIndex = 2;
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
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveBorder;
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(405, 48);
            panelHeader.TabIndex = 4;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelHeader.ForeColor = Color.Black;
            labelHeader.Location = new Point(10, 7);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(298, 32);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Добавление университета";
            // 
            // UniversityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 168);
            Controls.Add(panelHeader);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UniversityForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Университет";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}