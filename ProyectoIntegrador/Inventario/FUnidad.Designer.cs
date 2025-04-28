namespace ProyectoIntegrador.Inventario
{
    partial class FUnidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUnidad));
            ButtonBuscar = new Utilidades.Controles.BBuscar();
            textBoxCodigoUnidad = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            textBoxDescripcionUnidad = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(496, 5);
            // 
            // ButtonBuscar
            // 
            ButtonBuscar.AutoSize = true;
            ButtonBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonBuscar.Image = (Image)resources.GetObject("ButtonBuscar.Image");
            ButtonBuscar.Location = new Point(255, 152);
            ButtonBuscar.Margin = new Padding(0);
            ButtonBuscar.Name = "ButtonBuscar";
            ButtonBuscar.Size = new Size(38, 38);
            ButtonBuscar.TabIndex = 12;
            ButtonBuscar.Click += bBuscar1_Click;
            // 
            // textBoxCodigoUnidad
            // 
            textBoxCodigoUnidad.AnimateReadOnly = false;
            textBoxCodigoUnidad.BorderStyle = BorderStyle.None;
            textBoxCodigoUnidad.Depth = 0;
            textBoxCodigoUnidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoUnidad.LeadingIcon = null;
            textBoxCodigoUnidad.Location = new Point(126, 146);
            textBoxCodigoUnidad.MaxLength = 50;
            textBoxCodigoUnidad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoUnidad.Multiline = false;
            textBoxCodigoUnidad.Name = "textBoxCodigoUnidad";
            textBoxCodigoUnidad.Size = new Size(126, 50);
            textBoxCodigoUnidad.TabIndex = 14;
            textBoxCodigoUnidad.Text = "";
            textBoxCodigoUnidad.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(18, 163);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 13;
            materialLabel3.Text = "Código:";
            // 
            // textBoxDescripcionUnidad
            // 
            textBoxDescripcionUnidad.AnimateReadOnly = false;
            textBoxDescripcionUnidad.BorderStyle = BorderStyle.None;
            textBoxDescripcionUnidad.Depth = 0;
            textBoxDescripcionUnidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionUnidad.LeadingIcon = null;
            textBoxDescripcionUnidad.Location = new Point(126, 202);
            textBoxDescripcionUnidad.MaxLength = 50;
            textBoxDescripcionUnidad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionUnidad.Multiline = false;
            textBoxDescripcionUnidad.Name = "textBoxDescripcionUnidad";
            textBoxDescripcionUnidad.Size = new Size(354, 50);
            textBoxDescripcionUnidad.TabIndex = 10;
            textBoxDescripcionUnidad.Text = "";
            textBoxDescripcionUnidad.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(18, 219);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(88, 19);
            materialLabel1.TabIndex = 11;
            materialLabel1.Text = "Descripción:";
            materialLabel1.Click += materialLabel1_Click;
            // 
            // FUnidad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 319);
            Controls.Add(ButtonBuscar);
            Controls.Add(textBoxCodigoUnidad);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxDescripcionUnidad);
            Controls.Add(materialLabel1);
            Name = "FUnidad";
            Text = "FUnidad";
            Load += FUnidad_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxDescripcionUnidad, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigoUnidad, 0);
            Controls.SetChildIndex(ButtonBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Utilidades.Controles.BBuscar ButtonBuscar;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoUnidad;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionUnidad;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}