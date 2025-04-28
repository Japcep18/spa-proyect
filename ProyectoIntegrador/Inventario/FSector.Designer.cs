namespace ProyectoIntegrador.Inventario
{
    partial class FSector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSector));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigoSector = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcionSector = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigoCiudad = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigoMunicipio = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar2 = new Utilidades.Controles.BBuscar();
            bBuscar3 = new Utilidades.Controles.BBuscar();
            textBoxDescripcionCiudad = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcionMuni = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(581, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(12, 198);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Ciudad:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(12, 251);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(75, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Municipio:";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(12, 139);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(50, 19);
            materialLabel3.TabIndex = 12;
            materialLabel3.Text = "Sector:";
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(218, 128);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(45, 47);
            bBuscar1.TabIndex = 14;
            bBuscar1.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoSector
            // 
            textBoxCodigoSector.AnimateReadOnly = false;
            textBoxCodigoSector.BorderStyle = BorderStyle.None;
            textBoxCodigoSector.Depth = 0;
            textBoxCodigoSector.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoSector.LeadingIcon = null;
            textBoxCodigoSector.Location = new Point(104, 125);
            textBoxCodigoSector.MaxLength = 50;
            textBoxCodigoSector.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoSector.Multiline = false;
            textBoxCodigoSector.Name = "textBoxCodigoSector";
            textBoxCodigoSector.Size = new Size(108, 50);
            textBoxCodigoSector.TabIndex = 0;
            textBoxCodigoSector.Text = "";
            textBoxCodigoSector.TrailingIcon = null;
            // 
            // textBoxDescripcionSector
            // 
            textBoxDescripcionSector.AnimateReadOnly = false;
            textBoxDescripcionSector.BorderStyle = BorderStyle.None;
            textBoxDescripcionSector.Depth = 0;
            textBoxDescripcionSector.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionSector.LeadingIcon = null;
            textBoxDescripcionSector.Location = new Point(269, 125);
            textBoxDescripcionSector.MaxLength = 50;
            textBoxDescripcionSector.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionSector.Multiline = false;
            textBoxDescripcionSector.Name = "textBoxDescripcionSector";
            textBoxDescripcionSector.Size = new Size(294, 50);
            textBoxDescripcionSector.TabIndex = 3;
            textBoxDescripcionSector.Text = "";
            textBoxDescripcionSector.TrailingIcon = null;
            // 
            // textBoxCodigoCiudad
            // 
            textBoxCodigoCiudad.AnimateReadOnly = false;
            textBoxCodigoCiudad.BorderStyle = BorderStyle.None;
            textBoxCodigoCiudad.Depth = 0;
            textBoxCodigoCiudad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoCiudad.LeadingIcon = null;
            textBoxCodigoCiudad.Location = new Point(104, 181);
            textBoxCodigoCiudad.MaxLength = 50;
            textBoxCodigoCiudad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoCiudad.Multiline = false;
            textBoxCodigoCiudad.Name = "textBoxCodigoCiudad";
            textBoxCodigoCiudad.Size = new Size(108, 50);
            textBoxCodigoCiudad.TabIndex = 15;
            textBoxCodigoCiudad.Text = "";
            textBoxCodigoCiudad.TrailingIcon = null;
            // 
            // textBoxCodigoMunicipio
            // 
            textBoxCodigoMunicipio.AnimateReadOnly = false;
            textBoxCodigoMunicipio.BorderStyle = BorderStyle.None;
            textBoxCodigoMunicipio.Depth = 0;
            textBoxCodigoMunicipio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoMunicipio.LeadingIcon = null;
            textBoxCodigoMunicipio.Location = new Point(104, 237);
            textBoxCodigoMunicipio.MaxLength = 50;
            textBoxCodigoMunicipio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoMunicipio.Multiline = false;
            textBoxCodigoMunicipio.Name = "textBoxCodigoMunicipio";
            textBoxCodigoMunicipio.Size = new Size(108, 50);
            textBoxCodigoMunicipio.TabIndex = 16;
            textBoxCodigoMunicipio.Text = "";
            textBoxCodigoMunicipio.TrailingIcon = null;
            // 
            // bBuscar2
            // 
            bBuscar2.Image = (Image)resources.GetObject("bBuscar2.Image");
            bBuscar2.Location = new Point(218, 188);
            bBuscar2.Name = "bBuscar2";
            bBuscar2.Size = new Size(45, 43);
            bBuscar2.TabIndex = 17;
            bBuscar2.UseVisualStyleBackColor = true;
            // 
            // bBuscar3
            // 
            bBuscar3.Image = (Image)resources.GetObject("bBuscar3.Image");
            bBuscar3.Location = new Point(218, 237);
            bBuscar3.Name = "bBuscar3";
            bBuscar3.Size = new Size(45, 46);
            bBuscar3.TabIndex = 18;
            bBuscar3.UseVisualStyleBackColor = true;
            // 
            // textBoxDescripcionCiudad
            // 
            textBoxDescripcionCiudad.AnimateReadOnly = false;
            textBoxDescripcionCiudad.BorderStyle = BorderStyle.None;
            textBoxDescripcionCiudad.Depth = 0;
            textBoxDescripcionCiudad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionCiudad.LeadingIcon = null;
            textBoxDescripcionCiudad.Location = new Point(269, 181);
            textBoxDescripcionCiudad.MaxLength = 50;
            textBoxDescripcionCiudad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionCiudad.Multiline = false;
            textBoxDescripcionCiudad.Name = "textBoxDescripcionCiudad";
            textBoxDescripcionCiudad.Size = new Size(294, 50);
            textBoxDescripcionCiudad.TabIndex = 19;
            textBoxDescripcionCiudad.Text = "";
            textBoxDescripcionCiudad.TrailingIcon = null;
            // 
            // textBoxDescripcionMuni
            // 
            textBoxDescripcionMuni.AnimateReadOnly = false;
            textBoxDescripcionMuni.BorderStyle = BorderStyle.None;
            textBoxDescripcionMuni.Depth = 0;
            textBoxDescripcionMuni.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionMuni.LeadingIcon = null;
            textBoxDescripcionMuni.Location = new Point(269, 237);
            textBoxDescripcionMuni.MaxLength = 50;
            textBoxDescripcionMuni.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionMuni.Multiline = false;
            textBoxDescripcionMuni.Name = "textBoxDescripcionMuni";
            textBoxDescripcionMuni.Size = new Size(294, 50);
            textBoxDescripcionMuni.TabIndex = 20;
            textBoxDescripcionMuni.Text = "";
            textBoxDescripcionMuni.TrailingIcon = null;
            // 
            // FSector
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 325);
            Controls.Add(textBoxDescripcionMuni);
            Controls.Add(textBoxDescripcionCiudad);
            Controls.Add(bBuscar3);
            Controls.Add(bBuscar2);
            Controls.Add(textBoxCodigoMunicipio);
            Controls.Add(textBoxCodigoCiudad);
            Controls.Add(textBoxDescripcionSector);
            Controls.Add(textBoxCodigoSector);
            Controls.Add(bBuscar1);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Name = "FSector";
            Text = "FSector";
            Load += FSector_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(textBoxCodigoSector, 0);
            Controls.SetChildIndex(textBoxDescripcionSector, 0);
            Controls.SetChildIndex(textBoxCodigoCiudad, 0);
            Controls.SetChildIndex(textBoxCodigoMunicipio, 0);
            Controls.SetChildIndex(bBuscar2, 0);
            Controls.SetChildIndex(bBuscar3, 0);
            Controls.SetChildIndex(textBoxDescripcionCiudad, 0);
            Controls.SetChildIndex(textBoxDescripcionMuni, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoSector;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionSector;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoCiudad;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoMunicipio;
        private Utilidades.Controles.BBuscar bBuscar2;
        private Utilidades.Controles.BBuscar bBuscar3;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionCiudad;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionMuni;
    }
}