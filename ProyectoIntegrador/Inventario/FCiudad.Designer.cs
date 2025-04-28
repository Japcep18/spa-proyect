namespace ProyectoIntegrador.Inventario
{
    partial class FCiudad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCiudad));
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            textBoxAbr = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            textBoxDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(596, 5);
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(284, 148);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 2;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(155, 142);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(126, 50);
            textBoxCodigo.TabIndex = 0;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(34, 163);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 15;
            materialLabel3.Text = "Código:";
            // 
            // textBoxAbr
            // 
            textBoxAbr.AnimateReadOnly = false;
            textBoxAbr.BorderStyle = BorderStyle.None;
            textBoxAbr.Depth = 0;
            textBoxAbr.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxAbr.LeadingIcon = null;
            textBoxAbr.Location = new Point(155, 198);
            textBoxAbr.MaxLength = 50;
            textBoxAbr.MouseState = MaterialSkin.MouseState.OUT;
            textBoxAbr.Multiline = false;
            textBoxAbr.Name = "textBoxAbr";
            textBoxAbr.Size = new Size(167, 50);
            textBoxAbr.TabIndex = 0;
            textBoxAbr.Text = "";
            textBoxAbr.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(34, 219);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(86, 19);
            materialLabel2.TabIndex = 13;
            materialLabel2.Text = "Abreviatura:";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.AnimateReadOnly = false;
            textBoxDescripcion.BorderStyle = BorderStyle.None;
            textBoxDescripcion.Depth = 0;
            textBoxDescripcion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcion.LeadingIcon = null;
            textBoxDescripcion.Location = new Point(155, 254);
            textBoxDescripcion.MaxLength = 50;
            textBoxDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcion.Multiline = false;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(376, 50);
            textBoxDescripcion.TabIndex = 1;
            textBoxDescripcion.Text = "";
            textBoxDescripcion.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(34, 275);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(88, 19);
            materialLabel1.TabIndex = 11;
            materialLabel1.Text = "Descripción:";
            // 
            // FCiudad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 370);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxCodigo);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxAbr);
            Controls.Add(materialLabel2);
            Controls.Add(textBoxDescripcion);
            Controls.Add(materialLabel1);
            Name = "FCiudad";
            Text = "Ciudad";
            Load += FCiudad_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxDescripcion, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(textBoxAbr, 0);
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
        private MaterialSkin.Controls.MaterialTextBox textBoxAbr;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcion;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}