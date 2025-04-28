namespace ProyectoIntegrador.Inventario
{
    partial class FFacturar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFacturar));
            groupBox1 = new GroupBox();
            textBoxDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarVenta = new Utilidades.Controles.BBuscar();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(683, 5);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxDescripcion);
            groupBox1.Controls.Add(bBuscarVenta);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(683, 88);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ventas:";
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.AnimateReadOnly = false;
            textBoxDescripcion.BorderStyle = BorderStyle.None;
            textBoxDescripcion.Depth = 0;
            textBoxDescripcion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcion.LeadingIcon = null;
            textBoxDescripcion.Location = new Point(111, 26);
            textBoxDescripcion.MaxLength = 50;
            textBoxDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcion.Multiline = false;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.ReadOnly = true;
            textBoxDescripcion.Size = new Size(531, 50);
            textBoxDescripcion.TabIndex = 15;
            textBoxDescripcion.Text = "";
            textBoxDescripcion.TrailingIcon = null;
            // 
            // bBuscarVenta
            // 
            bBuscarVenta.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bBuscarVenta.Image = (Image)resources.GetObject("bBuscarVenta.Image");
            bBuscarVenta.ImageAlign = ContentAlignment.MiddleLeft;
            bBuscarVenta.Location = new Point(10, 27);
            bBuscarVenta.Name = "bBuscarVenta";
            bBuscarVenta.Size = new Size(95, 48);
            bBuscarVenta.TabIndex = 14;
            bBuscarVenta.Text = "Buscar";
            bBuscarVenta.TextAlign = ContentAlignment.MiddleRight;
            bBuscarVenta.UseVisualStyleBackColor = true;
            bBuscarVenta.Click += bBuscarVenta_Click;
            // 
            // FFacturar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 229);
            Controls.Add(groupBox1);
            Name = "FFacturar";
            Text = "FFacturar";
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcion;
        private Utilidades.Controles.BBuscar bBuscarVenta;
    }
}