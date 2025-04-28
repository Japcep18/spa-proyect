
namespace ProyectoIntegrador.Inventario
{
    partial class FEstadoCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEstadoCita));
            ButtonBuscar = new Utilidades.Controles.BBuscar();
            textBoxCodigoEstadoCita = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            textBoxDescripcionEstadoCita = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(563, 5);
            // 
            // ButtonBuscar
            // 
            ButtonBuscar.AutoSize = true;
            ButtonBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ButtonBuscar.Image = (Image)resources.GetObject("ButtonBuscar.Image");
            ButtonBuscar.Location = new Point(257, 139);
            ButtonBuscar.Margin = new Padding(0);
            ButtonBuscar.Name = "ButtonBuscar";
            ButtonBuscar.Size = new Size(38, 38);
            ButtonBuscar.TabIndex = 17;
            ButtonBuscar.Click += ButtonBuscar_Click;
            // 
            // textBoxCodigoEstadoCita
            // 
            textBoxCodigoEstadoCita.AnimateReadOnly = false;
            textBoxCodigoEstadoCita.BorderStyle = BorderStyle.None;
            textBoxCodigoEstadoCita.Depth = 0;
            textBoxCodigoEstadoCita.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoEstadoCita.LeadingIcon = null;
            textBoxCodigoEstadoCita.Location = new Point(128, 133);
            textBoxCodigoEstadoCita.MaxLength = 50;
            textBoxCodigoEstadoCita.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoEstadoCita.Multiline = false;
            textBoxCodigoEstadoCita.Name = "textBoxCodigoEstadoCita";
            textBoxCodigoEstadoCita.Size = new Size(126, 50);
            textBoxCodigoEstadoCita.TabIndex = 19;
            textBoxCodigoEstadoCita.Text = "";
            textBoxCodigoEstadoCita.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(20, 150);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 18;
            materialLabel3.Text = "Código:";
            // 
            // textBoxDescripcionEstadoCita
            // 
            textBoxDescripcionEstadoCita.AnimateReadOnly = false;
            textBoxDescripcionEstadoCita.BorderStyle = BorderStyle.None;
            textBoxDescripcionEstadoCita.Depth = 0;
            textBoxDescripcionEstadoCita.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionEstadoCita.LeadingIcon = null;
            textBoxDescripcionEstadoCita.Location = new Point(128, 189);
            textBoxDescripcionEstadoCita.MaxLength = 50;
            textBoxDescripcionEstadoCita.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionEstadoCita.Multiline = false;
            textBoxDescripcionEstadoCita.Name = "textBoxDescripcionEstadoCita";
            textBoxDescripcionEstadoCita.Size = new Size(354, 50);
            textBoxDescripcionEstadoCita.TabIndex = 15;
            textBoxDescripcionEstadoCita.Text = "";
            textBoxDescripcionEstadoCita.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(20, 206);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(88, 19);
            materialLabel1.TabIndex = 16;
            materialLabel1.Text = "Descripción:";
            // 
            // FEstadoCita
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 295);
            Controls.Add(ButtonBuscar);
            Controls.Add(textBoxCodigoEstadoCita);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxDescripcionEstadoCita);
            Controls.Add(materialLabel1);
            Name = "FEstadoCita";
            Text = "FEstadoCita";
            Load += FEstadoCita_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxDescripcionEstadoCita, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigoEstadoCita, 0);
            Controls.SetChildIndex(ButtonBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Utilidades.Controles.BBuscar ButtonBuscar;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoEstadoCita;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionEstadoCita;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}