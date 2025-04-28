namespace ProyectoIntegrador.Inventario
{
    partial class FITBIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FITBIS));
            textBoxITBIS = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(316, 5);
            // 
            // textBoxITBIS
            // 
            textBoxITBIS.AnimateReadOnly = false;
            textBoxITBIS.BorderStyle = BorderStyle.None;
            textBoxITBIS.Depth = 0;
            textBoxITBIS.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxITBIS.LeadingIcon = null;
            textBoxITBIS.Location = new Point(94, 137);
            textBoxITBIS.MaxLength = 50;
            textBoxITBIS.MouseState = MaterialSkin.MouseState.OUT;
            textBoxITBIS.Multiline = false;
            textBoxITBIS.Name = "textBoxITBIS";
            textBoxITBIS.Size = new Size(134, 50);
            textBoxITBIS.TabIndex = 10;
            textBoxITBIS.Text = "";
            textBoxITBIS.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(36, 149);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(43, 19);
            materialLabel1.TabIndex = 11;
            materialLabel1.Text = "ITBIS:";
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(234, 137);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(46, 41);
            bBuscar1.TabIndex = 12;
            bBuscar1.UseVisualStyleBackColor = true;
            bBuscar1.Click += bBuscar1_Click;
            // 
            // FITBIS
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 244);
            Controls.Add(bBuscar1);
            Controls.Add(materialLabel1);
            Controls.Add(textBoxITBIS);
            Name = "FITBIS";
            Text = "FITBIS";
            Load += FITBIS_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(textBoxITBIS, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxITBIS;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Utilidades.Controles.BBuscar bBuscar1;
    }
}