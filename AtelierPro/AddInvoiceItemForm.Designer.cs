namespace AtelierPro
{
    partial class AddInvoiceItemForm
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
            comboBoxMaterials = new ComboBox();
            textBoxPrice = new TextBox();
            textBoxQuantity = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panelHeader = new Panel();
            TitleReport = new Label();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxMaterials
            // 
            comboBoxMaterials.BackColor = Color.Black;
            comboBoxMaterials.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaterials.Font = new Font("Segoe UI", 14F);
            comboBoxMaterials.ForeColor = SystemColors.Control;
            comboBoxMaterials.FormattingEnabled = true;
            comboBoxMaterials.Location = new Point(125, 180);
            comboBoxMaterials.Margin = new Padding(3, 4, 3, 4);
            comboBoxMaterials.Name = "comboBoxMaterials";
            comboBoxMaterials.Size = new Size(340, 39);
            comboBoxMaterials.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(125, 260);
            textBoxPrice.Margin = new Padding(3, 4, 3, 4);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(340, 27);
            textBoxPrice.TabIndex = 3;
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new Point(125, 327);
            textBoxQuantity.Margin = new Padding(3, 4, 3, 4);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new Size(340, 27);
            textBoxQuantity.TabIndex = 4;
            // 
            // btnOK
            // 
            btnOK.BackColor = SystemColors.ActiveCaptionText;
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(125, 365);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(167, 44);
            btnOK.TabIndex = 14;
            btnOK.Text = "ОК";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveCaptionText;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(298, 365);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(167, 44);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(125, 148);
            label1.Name = "label1";
            label1.Size = new Size(107, 28);
            label1.TabIndex = 16;
            label1.Text = "Материал:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(125, 228);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 17;
            label2.Text = "Цена:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(125, 295);
            label3.Name = "label3";
            label3.Size = new Size(124, 28);
            label3.TabIndex = 18;
            label3.Text = "Количество:";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = SystemColors.ActiveCaptionText;
            panelHeader.Controls.Add(TitleReport);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(584, 133);
            panelHeader.TabIndex = 19;
            // 
            // TitleReport
            // 
            TitleReport.AutoSize = true;
            TitleReport.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            TitleReport.ForeColor = Color.White;
            TitleReport.Location = new Point(14, 15);
            TitleReport.Name = "TitleReport";
            TitleReport.Size = new Size(603, 46);
            TitleReport.TabIndex = 5;
            TitleReport.Text = "Добавление позиции в накладную";
            // 
            // AddInvoiceItemForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 441);
            Controls.Add(panelHeader);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(textBoxQuantity);
            Controls.Add(textBoxPrice);
            Controls.Add(comboBoxMaterials);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddInvoiceItemForm";
            Text = "AddInvoiceItemForm";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxMaterials;
        private TextBox textBoxPrice;
        private TextBox textBoxQuantity;
        private Button btnOK;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panelHeader;
        private Label TitleReport;
    }
}