namespace AtelierPro.AddEditFormForTables
{
    partial class AddEditMaterialForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelMaterialName;
        private TextBox textBoxMaterialName;
        private Label labelMaterialType;
        private ComboBox comboBoxMaterialType;
        private Label labelUnit;
        private TextBox textBoxUnit;
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
            labelMaterialName = new Label();
            textBoxMaterialName = new TextBox();
            labelMaterialType = new Label();
            comboBoxMaterialType = new ComboBox();
            labelUnit = new Label();
            textBoxUnit = new TextBox();
            labelNotes = new Label();
            textBoxNotes = new TextBox();
            panelHeader = new Panel();
            labelTitle = new Label();
            btnCancel = new Button();
            btnOK = new Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // labelMaterialName
            // 
            labelMaterialName.AutoSize = true;
            labelMaterialName.Font = new Font("Segoe UI", 12F);
            labelMaterialName.Location = new Point(12, 77);
            labelMaterialName.Name = "labelMaterialName";
            labelMaterialName.Size = new Size(151, 28);
            labelMaterialName.TabIndex = 0;
            labelMaterialName.Text = "Наименование";
            // 
            // textBoxMaterialName
            // 
            textBoxMaterialName.Location = new Point(197, 81);
            textBoxMaterialName.Name = "textBoxMaterialName";
            textBoxMaterialName.Size = new Size(250, 27);
            textBoxMaterialName.TabIndex = 1;
            // 
            // labelMaterialType
            // 
            labelMaterialType.AutoSize = true;
            labelMaterialType.Font = new Font("Segoe UI", 12F);
            labelMaterialType.Location = new Point(12, 117);
            labelMaterialType.Name = "labelMaterialType";
            labelMaterialType.Size = new Size(148, 28);
            labelMaterialType.TabIndex = 2;
            labelMaterialType.Text = "Тип материала";
            // 
            // comboBoxMaterialType
            // 
            comboBoxMaterialType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaterialType.FormattingEnabled = true;
            comboBoxMaterialType.Location = new Point(197, 121);
            comboBoxMaterialType.Name = "comboBoxMaterialType";
            comboBoxMaterialType.Size = new Size(250, 28);
            comboBoxMaterialType.TabIndex = 3;
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Font = new Font("Segoe UI", 12F);
            labelUnit.Location = new Point(12, 157);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(143, 28);
            labelUnit.TabIndex = 4;
            labelUnit.Text = "Ед. измерения";
            // 
            // textBoxUnit
            // 
            textBoxUnit.Location = new Point(197, 161);
            textBoxUnit.Name = "textBoxUnit";
            textBoxUnit.Size = new Size(250, 27);
            textBoxUnit.TabIndex = 5;
            // 
            // labelNotes
            // 
            labelNotes.AutoSize = true;
            labelNotes.Font = new Font("Segoe UI", 12F);
            labelNotes.Location = new Point(12, 197);
            labelNotes.Name = "labelNotes";
            labelNotes.Size = new Size(129, 28);
            labelNotes.TabIndex = 6;
            labelNotes.Text = "Примечание";
            // 
            // textBoxNotes
            // 
            textBoxNotes.Location = new Point(197, 201);
            textBoxNotes.Multiline = true;
            textBoxNotes.Name = "textBoxNotes";
            textBoxNotes.ScrollBars = ScrollBars.Vertical;
            textBoxNotes.Size = new Size(250, 100);
            textBoxNotes.TabIndex = 7;
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
            labelTitle.Size = new Size(362, 41);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Добавление материала";
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
            // AddEditMaterialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 376);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(panelHeader);
            Controls.Add(textBoxNotes);
            Controls.Add(labelNotes);
            Controls.Add(textBoxUnit);
            Controls.Add(labelUnit);
            Controls.Add(comboBoxMaterialType);
            Controls.Add(labelMaterialType);
            Controls.Add(textBoxMaterialName);
            Controls.Add(labelMaterialName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEditMaterialForm";
            Text = "Материал";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}