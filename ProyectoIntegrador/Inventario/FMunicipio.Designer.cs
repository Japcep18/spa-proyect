namespace ProyectoIntegrador.Inventario
{
    partial class FMunicipio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMunicipio));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            textBoxCodigoMuni = new MaterialSkin.Controls.MaterialTextBox();
            textBoxAbreviaturaMuni = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcionMuni = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigoCiudad = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar2 = new Utilidades.Controles.BBuscar();
            textBoxDescripcionCiudad = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(563, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(27, 200);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(59, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Ciudad: ";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(27, 142);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(55, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Codigo:";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(27, 251);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(75, 19);
            materialLabel4.TabIndex = 13;
            materialLabel4.Text = "Municipio:";
            materialLabel4.Click += materialLabel4_Click;
            // 
            // textBoxCodigoMuni
            // 
            textBoxCodigoMuni.AnimateReadOnly = false;
            textBoxCodigoMuni.BorderStyle = BorderStyle.None;
            textBoxCodigoMuni.Depth = 0;
            textBoxCodigoMuni.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoMuni.LeadingIcon = null;
            textBoxCodigoMuni.Location = new Point(127, 122);
            textBoxCodigoMuni.MaxLength = 50;
            textBoxCodigoMuni.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoMuni.Multiline = false;
            textBoxCodigoMuni.Name = "textBoxCodigoMuni";
            textBoxCodigoMuni.Size = new Size(137, 50);
            textBoxCodigoMuni.TabIndex = 0;
            textBoxCodigoMuni.Text = "";
            textBoxCodigoMuni.TrailingIcon = null;
            // 
            // textBoxAbreviaturaMuni
            // 
            textBoxAbreviaturaMuni.AnimateReadOnly = false;
            textBoxAbreviaturaMuni.BorderStyle = BorderStyle.None;
            textBoxAbreviaturaMuni.Depth = 0;
            textBoxAbreviaturaMuni.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxAbreviaturaMuni.LeadingIcon = null;
            textBoxAbreviaturaMuni.Location = new Point(315, 122);
            textBoxAbreviaturaMuni.MaxLength = 50;
            textBoxAbreviaturaMuni.MouseState = MaterialSkin.MouseState.OUT;
            textBoxAbreviaturaMuni.Multiline = false;
            textBoxAbreviaturaMuni.Name = "textBoxAbreviaturaMuni";
            textBoxAbreviaturaMuni.Size = new Size(230, 50);
            textBoxAbreviaturaMuni.TabIndex = 2;
            textBoxAbreviaturaMuni.Text = "";
            textBoxAbreviaturaMuni.TrailingIcon = null;
            // 
            // textBoxDescripcionMuni
            // 
            textBoxDescripcionMuni.AnimateReadOnly = false;
            textBoxDescripcionMuni.BorderStyle = BorderStyle.None;
            textBoxDescripcionMuni.Depth = 0;
            textBoxDescripcionMuni.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionMuni.LeadingIcon = null;
            textBoxDescripcionMuni.Location = new Point(127, 234);
            textBoxDescripcionMuni.MaxLength = 50;
            textBoxDescripcionMuni.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionMuni.Multiline = false;
            textBoxDescripcionMuni.Name = "textBoxDescripcionMuni";
            textBoxDescripcionMuni.Size = new Size(418, 50);
            textBoxDescripcionMuni.TabIndex = 3;
            textBoxDescripcionMuni.Text = "";
            textBoxDescripcionMuni.TrailingIcon = null;
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(270, 131);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(39, 37);
            bBuscar1.TabIndex = 18;
            bBuscar1.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoCiudad
            // 
            textBoxCodigoCiudad.AnimateReadOnly = false;
            textBoxCodigoCiudad.BorderStyle = BorderStyle.None;
            textBoxCodigoCiudad.Depth = 0;
            textBoxCodigoCiudad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoCiudad.LeadingIcon = null;
            textBoxCodigoCiudad.Location = new Point(127, 178);
            textBoxCodigoCiudad.MaxLength = 50;
            textBoxCodigoCiudad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoCiudad.Multiline = false;
            textBoxCodigoCiudad.Name = "textBoxCodigoCiudad";
            textBoxCodigoCiudad.Size = new Size(137, 50);
            textBoxCodigoCiudad.TabIndex = 19;
            textBoxCodigoCiudad.Text = "";
            textBoxCodigoCiudad.TrailingIcon = null;
            // 
            // bBuscar2
            // 
            bBuscar2.Image = (Image)resources.GetObject("bBuscar2.Image");
            bBuscar2.Location = new Point(270, 181);
            bBuscar2.Name = "bBuscar2";
            bBuscar2.Size = new Size(39, 38);
            bBuscar2.TabIndex = 20;
            bBuscar2.UseVisualStyleBackColor = true;
            // 
            // textBoxDescripcionCiudad
            // 
            textBoxDescripcionCiudad.AnimateReadOnly = false;
            textBoxDescripcionCiudad.BorderStyle = BorderStyle.None;
            textBoxDescripcionCiudad.Depth = 0;
            textBoxDescripcionCiudad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionCiudad.LeadingIcon = null;
            textBoxDescripcionCiudad.Location = new Point(315, 178);
            textBoxDescripcionCiudad.MaxLength = 50;
            textBoxDescripcionCiudad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionCiudad.Multiline = false;
            textBoxDescripcionCiudad.Name = "textBoxDescripcionCiudad";
            textBoxDescripcionCiudad.Size = new Size(230, 50);
            textBoxDescripcionCiudad.TabIndex = 21;
            textBoxDescripcionCiudad.Text = "";
            textBoxDescripcionCiudad.TrailingIcon = null;
            // 
            // FMunicipio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 329);
            Controls.Add(textBoxDescripcionCiudad);
            Controls.Add(bBuscar2);
            Controls.Add(textBoxCodigoCiudad);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxDescripcionMuni);
            Controls.Add(textBoxAbreviaturaMuni);
            Controls.Add(textBoxCodigoMuni);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Name = "FMunicipio";
            Text = "FMunicipio";
            Load += FMunicipio_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(materialLabel4, 0);
            Controls.SetChildIndex(textBoxCodigoMuni, 0);
            Controls.SetChildIndex(textBoxAbreviaturaMuni, 0);
            Controls.SetChildIndex(textBoxDescripcionMuni, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(textBoxCodigoCiudad, 0);
            Controls.SetChildIndex(bBuscar2, 0);
            Controls.SetChildIndex(textBoxDescripcionCiudad, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoMuni;
        private MaterialSkin.Controls.MaterialTextBox textBoxAbreviaturaMuni;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionMuni;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoCiudad;
        private Utilidades.Controles.BBuscar bBuscar2;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionCiudad;
    }
}