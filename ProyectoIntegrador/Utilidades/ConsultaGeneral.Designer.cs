namespace ProyectoIntegrador.Utilidades
{
    partial class ConsultaGeneral
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
            consultauc1 = new Controles.ConsultaUC();
            SuspendLayout();
            // 
            // consultauc1
            // 
            consultauc1.AscDefaultOrder = false;
            consultauc1.DefaultColumnOrder = null;
            consultauc1.Dock = DockStyle.Fill;
            consultauc1.Location = new Point(3, 64);
            consultauc1.Name = "consultauc1";
            consultauc1.Size = new Size(794, 383);
            consultauc1.TabIndex = 0;
            // 
            // ConsultaGeneral
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(consultauc1);
            Name = "ConsultaGeneral";
            Text = "ConsultaGeneral";
            ResumeLayout(false);
        }

        #endregion

        private Controles.ConsultaUC consultauc1;
    }
}