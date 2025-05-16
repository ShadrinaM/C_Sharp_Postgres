namespace PochitaikinLibrary.Forms
{
    partial class BookForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelTitle;
        private TextBox textBoxTitle;
        private Label labelCost;
        private NumericUpDown numericCost;
        private CheckBox checkBoxAvailable;
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
            labelTitle = new Label();
            textBoxTitle = new TextBox();
            labelCost = new Label();
            numericCost = new NumericUpDown();
            checkBoxAvailable = new CheckBox();
            btnOK = new Button();
            btnCancel = new Button();
            panelHeader = new Panel();
            labelHeader = new Label();
            ((System.ComponentModel.ISupportInitialize)(numericCost)).BeginInit();
            //panelHeader.BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F);
            labelTitle.Location = new Point(10, 58);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(76, 21);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Название";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(172, 61);
            textBoxTitle.Margin = new Padding(3, 2, 3, 2);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(219, 23);
            textBoxTitle.TabIndex = 1;
            // 
            // labelCost
            // 
            labelCost.AutoSize = true;
            labelCost.Font = new Font("Segoe UI", 12F);
            labelCost.Location = new Point(10, 88);
            labelCost.Name = "labelCost";
            labelCost.Size = new Size(93, 21);
            labelCost.TabIndex = 2;
            labelCost.Text = "Стоимость";
            // 
            // numericCost
            // 
            numericCost.DecimalPlaces = 2;
            numericCost.Location = new Point(172, 91);
            numericCost.Margin = new Padding(3, 2, 3, 2);
            numericCost.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            numericCost.Name = "numericCost";
            numericCost.Size = new Size(219, 23);
            numericCost.TabIndex = 3;
            // 
            // checkBoxAvailable
            // 
            checkBoxAvailable.AutoSize = true;
            checkBoxAvailable.Font = new Font("Segoe UI", 12F);
            checkBoxAvailable.Location = new Point(172, 118);
            checkBoxAvailable.Margin = new Padding(3, 2, 3, 2);
            checkBoxAvailable.Name = "checkBoxAvailable";
            checkBoxAvailable.Size = new Size(175, 25);
            checkBoxAvailable.TabIndex = 4;
            checkBoxAvailable.Text = "Доступна для выдачи";
            checkBoxAvailable.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveBorder;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOK.ForeColor = Color.Black;
            btnOK.Location = new Point(10, 156);
            btnOK.Margin = new Padding(3, 2, 3, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(157, 33);
            btnOK.TabIndex = 5;
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
            btnCancel.Location = new Point(234, 156);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(157, 33);
            btnCancel.TabIndex = 6;
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
            panelHeader.TabIndex = 7;
            // 
            // labelHeader
            // 
            labelHeader.AutoSize = true;
            labelHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelHeader.ForeColor = Color.Black;
            labelHeader.Location = new Point(10, 7);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(223, 32);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Добавление книги";
            // 
            // BookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 198);
            Controls.Add(panelHeader);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(checkBoxAvailable);
            Controls.Add(numericCost);
            Controls.Add(labelCost);
            Controls.Add(textBoxTitle);
            Controls.Add(labelTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Книга";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(numericCost)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}