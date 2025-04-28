namespace ProyectoIntegrador.Inventario
{
    partial class FTipoSala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTipoSala));
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            textBoxNombre = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(508, 5);
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(247, 144);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 13;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(118, 138);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(126, 50);
            textBoxCodigo.TabIndex = 16;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(36, 159);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 15;
            materialLabel3.Text = "Código:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.AnimateReadOnly = false;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Depth = 0;
            textBoxNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNombre.LeadingIcon = null;
            textBoxNombre.Location = new Point(118, 194);
            textBoxNombre.MaxLength = 50;
            textBoxNombre.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombre.Multiline = false;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(354, 50);
            textBoxNombre.TabIndex = 10;
            textBoxNombre.Text = "";
            textBoxNombre.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(36, 215);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(61, 19);
            materialLabel1.TabIndex = 12;
            materialLabel1.Text = "Nombre:";
            // 
            // FTipoSala
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 319);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxCodigo);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxNombre);
            Controls.Add(materialLabel1);
            Name = "FTipoSala";
            Text = "FEstadoSala";
            Load += FEstadoSala_Load_1;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxNombre, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigo, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox textBoxNombre;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}