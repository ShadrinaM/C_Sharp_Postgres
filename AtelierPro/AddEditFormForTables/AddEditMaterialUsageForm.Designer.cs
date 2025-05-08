namespace AtelierPro.AddEditFormForTables
{
    partial class AddEditMaterialUsageForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label labelProduct;
        private ComboBox comboBoxProducts;
        private Label labelMaterial;
        private ComboBox comboBoxMaterials;
        private Label labelQuantity;
        private NumericUpDown numericUpDownQuantity;
        private Button btnOK;
        private Button btnCancel;

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
            this.labelProduct = new Label();
            this.comboBoxProducts = new ComboBox();
            this.labelMaterial = new Label();
            this.comboBoxMaterials = new ComboBox();
            this.labelQuantity = new Label();
            this.numericUpDownQuantity = new NumericUpDown();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            this.SuspendLayout();

            // labelProduct
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(12, 15);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(50, 13);
            this.labelProduct.TabIndex = 0;
            this.labelProduct.Text = "Изделие:";

            // comboBoxProducts
            this.comboBoxProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(120, 12);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(250, 21);
            this.comboBoxProducts.TabIndex = 1;

            // labelMaterial
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.Location = new System.Drawing.Point(12, 45);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(60, 13);
            this.labelMaterial.TabIndex = 2;
            this.labelMaterial.Text = "Материал:";

            // comboBoxMaterials
            this.comboBoxMaterials.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxMaterials.FormattingEnabled = true;
            this.comboBoxMaterials.Location = new System.Drawing.Point(120, 42);
            this.comboBoxMaterials.Name = "comboBoxMaterials";
            this.comboBoxMaterials.Size = new System.Drawing.Size(250, 21);
            this.comboBoxMaterials.TabIndex = 3;

            // labelQuantity
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Location = new System.Drawing.Point(12, 75);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(69, 13);
            this.labelQuantity.TabIndex = 4;
            this.labelQuantity.Text = "Количество:";

            // numericUpDownQuantity
            this.numericUpDownQuantity.DecimalPlaces = 2;
            this.numericUpDownQuantity.Location = new System.Drawing.Point(120, 73);
            this.numericUpDownQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownQuantity.TabIndex = 5;

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(120, 110);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Добавить";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(230, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddEditMaterialUsageForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 151);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.comboBoxMaterials);
            this.Controls.Add(this.labelMaterial);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.labelProduct);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditMaterialUsageForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавление расхода материала";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}