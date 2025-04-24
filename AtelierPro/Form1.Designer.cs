namespace AtelierPro
{
    partial class Form1
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
            menuStrip1 = new MenuStrip();
            выбратьТипОтчётаToolStripMenuItem = new ToolStripMenuItem();
            материалыToolStripMenuItem = new ToolStripMenuItem();
            изделияToolStripMenuItem = new ToolStripMenuItem();
            изменитьЭлементToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { выбратьТипОтчётаToolStripMenuItem, изменитьЭлементToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // выбратьТипОтчётаToolStripMenuItem
            // 
            выбратьТипОтчётаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { материалыToolStripMenuItem, изделияToolStripMenuItem });
            выбратьТипОтчётаToolStripMenuItem.Name = "выбратьТипОтчётаToolStripMenuItem";
            выбратьТипОтчётаToolStripMenuItem.Size = new Size(127, 20);
            выбратьТипОтчётаToolStripMenuItem.Text = "Выбрать тип отчёта";
            // 
            // материалыToolStripMenuItem
            // 
            материалыToolStripMenuItem.Name = "материалыToolStripMenuItem";
            материалыToolStripMenuItem.Size = new Size(180, 22);
            материалыToolStripMenuItem.Text = "материалы";
            // 
            // изделияToolStripMenuItem
            // 
            изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            изделияToolStripMenuItem.Size = new Size(180, 22);
            изделияToolStripMenuItem.Text = "изделия";
            // 
            // изменитьЭлементToolStripMenuItem
            // 
            изменитьЭлементToolStripMenuItem.Name = "изменитьЭлементToolStripMenuItem";
            изменитьЭлементToolStripMenuItem.Size = new Size(122, 20);
            изменитьЭлементToolStripMenuItem.Text = "Изменить элемент";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem выбратьТипОтчётаToolStripMenuItem;
        private ToolStripMenuItem материалыToolStripMenuItem;
        private ToolStripMenuItem изделияToolStripMenuItem;
        private ToolStripMenuItem изменитьЭлементToolStripMenuItem;
    }
}