namespace ProyectoIntegrador.Utilidades.Controles
{
    partial class Alerta
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
            flowLayoutPanelButtons = new FlowLayoutPanel();
            panel1 = new Panel();
            textBoxMensaje = new TextBox();
            pictureBoxImage = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.BackColor = SystemColors.Control;
            flowLayoutPanelButtons.Dock = DockStyle.Bottom;
            flowLayoutPanelButtons.Location = new Point(3, 202);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(614, 45);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxMensaje);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(154, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(463, 138);
            panel1.TabIndex = 3;
            // 
            // textBoxMensaje
            // 
            textBoxMensaje.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxMensaje.BackColor = Color.FromArgb(255, 255, 255);
            textBoxMensaje.BorderStyle = BorderStyle.None;
            textBoxMensaje.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxMensaje.ForeColor = Color.FromArgb(222, 0, 0, 0);
            textBoxMensaje.Location = new Point(6, 8);
            textBoxMensaje.Margin = new Padding(10);
            textBoxMensaje.Multiline = true;
            textBoxMensaje.Name = "textBoxMensaje";
            textBoxMensaje.ReadOnly = true;
            textBoxMensaje.Size = new Size(453, 124);
            textBoxMensaje.TabIndex = 2;
            textBoxMensaje.TabStop = false;
            // 
            // pictureBoxImage
            // 
            pictureBoxImage.Dock = DockStyle.Left;
            pictureBoxImage.Location = new Point(3, 64);
            pictureBoxImage.Name = "pictureBoxImage";
            pictureBoxImage.Size = new Size(151, 138);
            pictureBoxImage.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxImage.TabIndex = 0;
            pictureBoxImage.TabStop = false;
            // 
            // Alerta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 250);
            Controls.Add(panel1);
            Controls.Add(pictureBoxImage);
            Controls.Add(flowLayoutPanelButtons);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(620, 250);
            MinimizeBox = false;
            MinimumSize = new Size(620, 250);
            Name = "Alerta";
            ShowInTaskbar = false;
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alerta";
            TopMost = true;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Panel panel1;
        private TextBox textBoxMensaje;
        private PictureBox pictureBoxImage;
    }
}