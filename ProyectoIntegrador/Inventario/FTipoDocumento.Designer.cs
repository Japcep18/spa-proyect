namespace ProyectoIntegrador.Inventario
{
    partial class FTipoDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTipoDocumento));
            textBoxCodigoTdoc = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcionTdoc = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Size = new Size(539, 5);
            // 
            // textBoxCodigoTdoc
            // 
            textBoxCodigoTdoc.AnimateReadOnly = false;
            textBoxCodigoTdoc.BorderStyle = BorderStyle.None;
            textBoxCodigoTdoc.Depth = 0;
            textBoxCodigoTdoc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoTdoc.LeadingIcon = null;
            textBoxCodigoTdoc.Location = new Point(139, 157);
            textBoxCodigoTdoc.MaxLength = 50;
            textBoxCodigoTdoc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoTdoc.Multiline = false;
            textBoxCodigoTdoc.Name = "textBoxCodigoTdoc";
            textBoxCodigoTdoc.Size = new Size(125, 50);
            textBoxCodigoTdoc.TabIndex = 10;
            textBoxCodigoTdoc.Text = "";
            textBoxCodigoTdoc.TrailingIcon = null;
            // 
            // textBoxDescripcionTdoc
            // 
            textBoxDescripcionTdoc.AnimateReadOnly = false;
            textBoxDescripcionTdoc.BorderStyle = BorderStyle.None;
            textBoxDescripcionTdoc.Depth = 0;
            textBoxDescripcionTdoc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionTdoc.LeadingIcon = null;
            textBoxDescripcionTdoc.Location = new Point(139, 213);
            textBoxDescripcionTdoc.MaxLength = 50;
            textBoxDescripcionTdoc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionTdoc.Multiline = false;
            textBoxDescripcionTdoc.Name = "textBoxDescripcionTdoc";
            textBoxDescripcionTdoc.Size = new Size(317, 50);
            textBoxDescripcionTdoc.TabIndex = 11;
            textBoxDescripcionTdoc.Text = "";
            textBoxDescripcionTdoc.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(26, 174);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 12;
            materialLabel1.Text = "Codigo:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(26, 229);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(88, 19);
            materialLabel2.TabIndex = 13;
            materialLabel2.Text = "Descripcion:";
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(270, 157);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(45, 50);
            bBuscar1.TabIndex = 14;
            bBuscar1.UseVisualStyleBackColor = true;
            // 
            // FTipoDocumento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 360);
            Controls.Add(bBuscar1);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(textBoxDescripcionTdoc);
            Controls.Add(textBoxCodigoTdoc);
            Name = "FTipoDocumento";
            Text = "FTipoDocumento";
            Load += FTipoDocumento_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(textBoxCodigoTdoc, 0);
            Controls.SetChildIndex(textBoxDescripcionTdoc, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoTdoc;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionTdoc;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private Utilidades.Controles.BBuscar bBuscar1;
    }
}