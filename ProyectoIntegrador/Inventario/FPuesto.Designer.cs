
namespace ProyectoIntegrador.Inventario
{
    partial class FPuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPuesto));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            textBoxCodigoPues = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcionPues = new MaterialSkin.Controls.MaterialTextBox();
            textBoxSueldoPues = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(490, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(48, 157);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Codigo:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(49, 210);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(88, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Descripcion:";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(48, 263);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(54, 19);
            materialLabel3.TabIndex = 12;
            materialLabel3.Text = "Sueldo:";
            // 
            // textBoxCodigoPues
            // 
            textBoxCodigoPues.AnimateReadOnly = false;
            textBoxCodigoPues.BorderStyle = BorderStyle.None;
            textBoxCodigoPues.Depth = 0;
            textBoxCodigoPues.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoPues.LeadingIcon = null;
            textBoxCodigoPues.Location = new Point(161, 138);
            textBoxCodigoPues.MaxLength = 50;
            textBoxCodigoPues.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoPues.Multiline = false;
            textBoxCodigoPues.Name = "textBoxCodigoPues";
            textBoxCodigoPues.Size = new Size(130, 50);
            textBoxCodigoPues.TabIndex = 13;
            textBoxCodigoPues.Text = "";
            textBoxCodigoPues.TrailingIcon = null;
            // 
            // textBoxDescripcionPues
            // 
            textBoxDescripcionPues.AnimateReadOnly = false;
            textBoxDescripcionPues.BorderStyle = BorderStyle.None;
            textBoxDescripcionPues.Depth = 0;
            textBoxDescripcionPues.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionPues.LeadingIcon = null;
            textBoxDescripcionPues.Location = new Point(161, 194);
            textBoxDescripcionPues.MaxLength = 50;
            textBoxDescripcionPues.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionPues.Multiline = false;
            textBoxDescripcionPues.Name = "textBoxDescripcionPues";
            textBoxDescripcionPues.Size = new Size(255, 50);
            textBoxDescripcionPues.TabIndex = 14;
            textBoxDescripcionPues.Text = "";
            textBoxDescripcionPues.TrailingIcon = null;
            // 
            // textBoxSueldoPues
            // 
            textBoxSueldoPues.AnimateReadOnly = false;
            textBoxSueldoPues.BorderStyle = BorderStyle.None;
            textBoxSueldoPues.Depth = 0;
            textBoxSueldoPues.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxSueldoPues.LeadingIcon = null;
            textBoxSueldoPues.Location = new Point(161, 250);
            textBoxSueldoPues.MaxLength = 50;
            textBoxSueldoPues.MouseState = MaterialSkin.MouseState.OUT;
            textBoxSueldoPues.Multiline = false;
            textBoxSueldoPues.Name = "textBoxSueldoPues";
            textBoxSueldoPues.Size = new Size(130, 50);
            textBoxSueldoPues.TabIndex = 15;
            textBoxSueldoPues.Text = "";
            textBoxSueldoPues.TrailingIcon = null;
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(294, 145);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 16;
            // 
            // FPuesto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 342);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxSueldoPues);
            Controls.Add(textBoxDescripcionPues);
            Controls.Add(textBoxCodigoPues);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Name = "FPuesto";
            Text = "FPuesto";
            Load += FEstadoSala_Load_1;
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigoPues, 0);
            Controls.SetChildIndex(textBoxDescripcionPues, 0);
            Controls.SetChildIndex(textBoxSueldoPues, 0);
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoPues;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionPues;
        private MaterialSkin.Controls.MaterialTextBox textBoxSueldoPues;
        private Utilidades.Controles.BBuscar bBuscar1;
    }
}