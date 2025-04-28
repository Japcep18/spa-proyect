namespace ProyectoIntegrador.Inventario
{
    partial class FTipoCliente
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
            textBoxCodigoTCli = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcionTCli = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            ButtonBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Size = new Size(384, 5);
            // 
            // textBoxCodigoTCli
            // 
            textBoxCodigoTCli.AnimateReadOnly = false;
            textBoxCodigoTCli.BorderStyle = BorderStyle.None;
            textBoxCodigoTCli.Depth = 0;
            textBoxCodigoTCli.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoTCli.LeadingIcon = null;
            textBoxCodigoTCli.Location = new Point(23, 156);
            textBoxCodigoTCli.MaxLength = 50;
            textBoxCodigoTCli.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoTCli.Multiline = false;
            textBoxCodigoTCli.Name = "textBoxCodigoTCli";
            textBoxCodigoTCli.Size = new Size(214, 50);
            textBoxCodigoTCli.TabIndex = 1;
            textBoxCodigoTCli.Text = "";
            textBoxCodigoTCli.TrailingIcon = null;
            // 
            // textBoxDescripcionTCli
            // 
            textBoxDescripcionTCli.AnimateReadOnly = false;
            textBoxDescripcionTCli.BorderStyle = BorderStyle.None;
            textBoxDescripcionTCli.Depth = 0;
            textBoxDescripcionTCli.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionTCli.LeadingIcon = null;
            textBoxDescripcionTCli.Location = new Point(23, 262);
            textBoxDescripcionTCli.MaxLength = 50;
            textBoxDescripcionTCli.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionTCli.Multiline = false;
            textBoxDescripcionTCli.Name = "textBoxDescripcionTCli";
            textBoxDescripcionTCli.Size = new Size(332, 50);
            textBoxDescripcionTCli.TabIndex = 2;
            textBoxDescripcionTCli.Text = "";
            textBoxDescripcionTCli.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(28, 128);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(51, 19);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Codigo";
            materialLabel1.Click += materialLabel1_Click;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(23, 228);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(84, 19);
            materialLabel2.TabIndex = 4;
            materialLabel2.Text = "Descripcion";
            // 
            // ButtonBuscar
            // 
            ButtonBuscar.FlatStyle = FlatStyle.Popup;
            ButtonBuscar.Image = Properties.Resources.search_48;
            ButtonBuscar.Location = new Point(266, 156);
            ButtonBuscar.Name = "ButtonBuscar";
            ButtonBuscar.Size = new Size(52, 50);
            ButtonBuscar.TabIndex = 8;
            ButtonBuscar.UseVisualStyleBackColor = true;
            // 
            // FTipoCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 381);
            Controls.Add(ButtonBuscar);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(textBoxDescripcionTCli);
            Controls.Add(textBoxCodigoTCli);
            Name = "FTipoCliente";
            Text = "Form1";
            Load += FTipoCliente_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(textBoxCodigoTCli, 0);
            Controls.SetChildIndex(textBoxDescripcionTCli, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(ButtonBuscar, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoTCli;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionTCli;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private Button ButtonBuscar;
    }
}