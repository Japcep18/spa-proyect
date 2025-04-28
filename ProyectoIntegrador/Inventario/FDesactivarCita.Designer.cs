namespace ProyectoIntegrador.Inventario
{
    partial class FDesactivarCita
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDesactivarCita));
            groupBox1 = new GroupBox();
            textBoxDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarCita = new Utilidades.Controles.BBuscar();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(676, 5);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxDescripcion);
            groupBox1.Controls.Add(bBuscarCita);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(676, 92);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Citas:";
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
            textBoxDescripcion.Size = new Size(536, 50);
            textBoxDescripcion.TabIndex = 15;
            textBoxDescripcion.Text = "";
            textBoxDescripcion.TrailingIcon = null;
            // 
            // bBuscarCita
            // 
            bBuscarCita.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bBuscarCita.Image = (Image)resources.GetObject("bBuscarCita.Image");
            bBuscarCita.ImageAlign = ContentAlignment.MiddleLeft;
            bBuscarCita.Location = new Point(10, 27);
            bBuscarCita.Name = "bBuscarCita";
            bBuscarCita.Size = new Size(95, 48);
            bBuscarCita.TabIndex = 14;
            bBuscarCita.Text = "Buscar";
            bBuscarCita.TextAlign = ContentAlignment.MiddleRight;
            bBuscarCita.UseVisualStyleBackColor = true;
            bBuscarCita.Click += bBuscarCita_Click;
            // 
            // FDesactivarCita
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 233);
            Controls.Add(groupBox1);
            Name = "FDesactivarCita";
            Text = "Desactivar Cita";
            Load += FDesactivarCita_Load;
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
        private Utilidades.Controles.BBuscar bBuscarCita;
    }
}