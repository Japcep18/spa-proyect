namespace ProyectoIntegrador
{
    partial class FConfiguracion
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
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            checkBoxPermitirCitasSinArticulos = new MaterialSkin.Controls.MaterialCheckbox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            materialTabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 151);
            progressBar.Size = new Size(794, 5);
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Upper;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Dock = DockStyle.Top;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(3, 111);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(794, 40);
            materialTabSelector1.TabIndex = 11;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(3, 151);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(794, 317);
            materialTabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(786, 284);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "General";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(checkBoxPermitirCitasSinArticulos);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(786, 284);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Citas";
            // 
            // checkBoxPermitirCitasSinArticulos
            // 
            checkBoxPermitirCitasSinArticulos.AutoSize = true;
            checkBoxPermitirCitasSinArticulos.Depth = 0;
            checkBoxPermitirCitasSinArticulos.Location = new Point(18, 20);
            checkBoxPermitirCitasSinArticulos.Margin = new Padding(0);
            checkBoxPermitirCitasSinArticulos.MouseLocation = new Point(-1, -1);
            checkBoxPermitirCitasSinArticulos.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxPermitirCitasSinArticulos.Name = "checkBoxPermitirCitasSinArticulos";
            checkBoxPermitirCitasSinArticulos.ReadOnly = false;
            checkBoxPermitirCitasSinArticulos.Ripple = true;
            checkBoxPermitirCitasSinArticulos.Size = new Size(218, 37);
            checkBoxPermitirCitasSinArticulos.TabIndex = 0;
            checkBoxPermitirCitasSinArticulos.Text = "Permitir citas sin artículos";
            checkBoxPermitirCitasSinArticulos.UseVisualStyleBackColor = true;
            // 
            // FConfiguración
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 493);
            Controls.Add(materialTabControl1);
            Controls.Add(materialTabSelector1);
            Name = "FConfiguración";
            Text = "FConfiguración";
            Controls.SetChildIndex(materialTabSelector1, 0);
            Controls.SetChildIndex(materialTabControl1, 0);
            Controls.SetChildIndex(progressBar, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            materialTabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxPermitirCitasSinArticulos;
    }
}