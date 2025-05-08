namespace AtelierPro
{
    partial class AddEditProductForm
    {
        private System.ComponentModel.IContainer components = null;

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
            panelHeader = new Panel();
            TitleReport = new Label();
            labelOrder = new Label();
            comboBoxOrders = new ComboBox();
            labelName = new Label();
            textBoxName = new TextBox();
            labelSize = new Label();
            textBoxSize = new TextBox();
            labelPrice = new Label();
            textBoxPrice = new TextBox();
            labelComplexity = new Label();
            numericUpDownComplexity = new NumericUpDown();
            labelNotes = new Label();
            textBoxNotes = new TextBox();
            btnCancel = new Button();
            btnOK = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownComplexity).BeginInit();
            SuspendLayout();
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
            TitleReport.Size = new Size(327, 41);
            TitleReport.TabIndex = 5;
            TitleReport.Text = "Добавление изделия";
            // 
            // labelOrder
            // 
            labelOrder.AutoSize = true;
            labelOrder.Font = new Font("Segoe UI", 12F);
            labelOrder.Location = new Point(12, 77);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(95, 28);
            labelOrder.TabIndex = 0;
            labelOrder.Text = "Заказчик";
            // 
            // comboBoxOrders
            // 
            comboBoxOrders.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrders.FormattingEnabled = true;
            comboBoxOrders.Location = new Point(197, 81);
            comboBoxOrders.Name = "comboBoxOrders";
            comboBoxOrders.Size = new Size(250, 28);
            comboBoxOrders.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F);
            labelName.Location = new Point(12, 117);
            labelName.Name = "labelName";
            labelName.Size = new Size(180, 28);
            labelName.TabIndex = 2;
            labelName.Text = "Название изделия";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(197, 121);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(250, 27);
            textBoxName.TabIndex = 3;
            // 
            // labelSize
            // 
            labelSize.AutoSize = true;
            labelSize.Font = new Font("Segoe UI", 12F);
            labelSize.Location = new Point(12, 157);
            labelSize.Name = "labelSize";
            labelSize.Size = new Size(78, 28);
            labelSize.TabIndex = 4;
            labelSize.Text = "Размер";
            // 
            // textBoxSize
            // 
            textBoxSize.Location = new Point(197, 161);
            textBoxSize.Name = "textBoxSize";
            textBoxSize.Size = new Size(250, 27);
            textBoxSize.TabIndex = 5;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Font = new Font("Segoe UI", 12F);
            labelPrice.Location = new Point(12, 197);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(138, 28);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Базовая цена:";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(197, 201);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(250, 27);
            textBoxPrice.TabIndex = 7;
            // 
            // labelComplexity
            // 
            labelComplexity.AutoSize = true;
            labelComplexity.Font = new Font("Segoe UI", 12F);
            labelComplexity.Location = new Point(12, 237);
            labelComplexity.Name = "labelComplexity";
            labelComplexity.Size = new Size(160, 28);
            labelComplexity.TabIndex = 8;
            labelComplexity.Text = "Сложность (1-5)";
            // 
            // numericUpDownComplexity
            // 
            numericUpDownComplexity.Location = new Point(197, 241);
            numericUpDownComplexity.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownComplexity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownComplexity.Name = "numericUpDownComplexity";
            numericUpDownComplexity.Size = new Size(250, 27);
            numericUpDownComplexity.TabIndex = 9;
            numericUpDownComplexity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelNotes
            // 
            labelNotes.AutoSize = true;
            labelNotes.Font = new Font("Segoe UI", 12F);
            labelNotes.Location = new Point(12, 277);
            labelNotes.Name = "labelNotes";
            labelNotes.Size = new Size(129, 28);
            labelNotes.TabIndex = 10;
            labelNotes.Text = "Примечание";
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(197, 281);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.ScrollBars = ScrollBars.Vertical;
            textBoxNotes.Size = new Size(250, 60);
            textBoxNotes.TabIndex = 11;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveCaptionText;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(268, 358);
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
            btnOK.Location = new Point(12, 358);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(179, 44);
            btnOK.TabIndex = 21;
            btnOK.Text = "ОК";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // AddEditProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 416);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(textBoxNotes);
            Controls.Add(labelNotes);
            Controls.Add(numericUpDownComplexity);
            Controls.Add(labelComplexity);
            Controls.Add(textBoxPrice);
            Controls.Add(labelPrice);
            Controls.Add(textBoxSize);
            Controls.Add(labelSize);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(comboBoxOrders);
            Controls.Add(labelOrder);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Изделие";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownComplexity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label TitleReport;
        private Label labelOrder;
        private ComboBox comboBoxOrders;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelSize;
        private TextBox textBoxSize;
        private Label labelPrice;
        private TextBox textBoxPrice;
        private Label labelComplexity;
        private NumericUpDown numericUpDownComplexity;
        private Label labelNotes;
        private TextBox textBoxNotes;
        private Button btnCancel;
        private Button btnOK;
    }
}