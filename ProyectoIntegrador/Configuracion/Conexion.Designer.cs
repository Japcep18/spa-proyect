namespace ProyectoIntegrador.Configuracion
{
    partial class Conexion
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
            textBoxServidor = new MaterialSkin.Controls.MaterialTextBox();
            label1 = new Label();
            groupBoxUsuario = new GroupBox();
            label3 = new Label();
            textBoxClave = new MaterialSkin.Controls.MaterialTextBox();
            label2 = new Label();
            textBoxUsuario = new MaterialSkin.Controls.MaterialTextBox();
            checkBoxIntegrada = new MaterialSkin.Controls.MaterialCheckbox();
            groupBox2 = new GroupBox();
            checkBoxCertificate = new MaterialSkin.Controls.MaterialCheckbox();
            buttonProbar = new MaterialSkin.Controls.MaterialButton();
            buttonGuardar = new MaterialSkin.Controls.MaterialButton();
            label5 = new Label();
            textBoxBaseDatos = new MaterialSkin.Controls.MaterialTextBox();
            groupBoxUsuario.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxServidor
            // 
            textBoxServidor.AnimateReadOnly = false;
            textBoxServidor.BorderStyle = BorderStyle.None;
            textBoxServidor.Depth = 0;
            textBoxServidor.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxServidor.LeadingIcon = null;
            textBoxServidor.Location = new Point(177, 136);
            textBoxServidor.MaxLength = 50;
            textBoxServidor.MouseState = MaterialSkin.MouseState.OUT;
            textBoxServidor.Multiline = false;
            textBoxServidor.Name = "textBoxServidor";
            textBoxServidor.Size = new Size(456, 50);
            textBoxServidor.TabIndex = 0;
            textBoxServidor.Text = "";
            textBoxServidor.TrailingIcon = Properties.Resources.close_48;
            textBoxServidor.TrailingIconClick += textBoxServidor_TrailingIconClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 145);
            label1.Name = "label1";
            label1.Size = new Size(90, 28);
            label1.TabIndex = 1;
            label1.Text = "Servidor:";
            // 
            // groupBoxUsuario
            // 
            groupBoxUsuario.Controls.Add(label3);
            groupBoxUsuario.Controls.Add(textBoxClave);
            groupBoxUsuario.Controls.Add(label2);
            groupBoxUsuario.Controls.Add(textBoxUsuario);
            groupBoxUsuario.Location = new Point(35, 192);
            groupBoxUsuario.Name = "groupBoxUsuario";
            groupBoxUsuario.Size = new Size(613, 152);
            groupBoxUsuario.TabIndex = 2;
            groupBoxUsuario.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(7, 93);
            label3.Name = "label3";
            label3.Size = new Size(63, 28);
            label3.TabIndex = 7;
            label3.Text = "Clave:";
            // 
            // textBoxClave
            // 
            textBoxClave.AnimateReadOnly = false;
            textBoxClave.BorderStyle = BorderStyle.None;
            textBoxClave.Depth = 0;
            textBoxClave.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxClave.LeadingIcon = null;
            textBoxClave.Location = new Point(142, 82);
            textBoxClave.MaxLength = 50;
            textBoxClave.MouseState = MaterialSkin.MouseState.OUT;
            textBoxClave.Multiline = false;
            textBoxClave.Name = "textBoxClave";
            textBoxClave.Password = true;
            textBoxClave.Size = new Size(456, 50);
            textBoxClave.TabIndex = 6;
            textBoxClave.Text = "";
            textBoxClave.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(7, 37);
            label2.Name = "label2";
            label2.Size = new Size(83, 28);
            label2.TabIndex = 5;
            label2.Text = "Usuario:";
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.AnimateReadOnly = false;
            textBoxUsuario.BorderStyle = BorderStyle.None;
            textBoxUsuario.Depth = 0;
            textBoxUsuario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxUsuario.LeadingIcon = null;
            textBoxUsuario.Location = new Point(142, 26);
            textBoxUsuario.MaxLength = 50;
            textBoxUsuario.MouseState = MaterialSkin.MouseState.OUT;
            textBoxUsuario.Multiline = false;
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(456, 50);
            textBoxUsuario.TabIndex = 4;
            textBoxUsuario.Text = "";
            textBoxUsuario.TrailingIcon = null;
            // 
            // checkBoxIntegrada
            // 
            checkBoxIntegrada.AutoSize = true;
            checkBoxIntegrada.Depth = 0;
            checkBoxIntegrada.Location = new Point(3, 12);
            checkBoxIntegrada.Margin = new Padding(0);
            checkBoxIntegrada.MouseLocation = new Point(-1, -1);
            checkBoxIntegrada.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxIntegrada.Name = "checkBoxIntegrada";
            checkBoxIntegrada.ReadOnly = false;
            checkBoxIntegrada.Ripple = true;
            checkBoxIntegrada.Size = new Size(178, 37);
            checkBoxIntegrada.TabIndex = 3;
            checkBoxIntegrada.Text = "Seguridad Integrada";
            checkBoxIntegrada.UseVisualStyleBackColor = true;
            checkBoxIntegrada.CheckedChanged += checkBoxIntegrada_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxCertificate);
            groupBox2.Controls.Add(checkBoxIntegrada);
            groupBox2.Location = new Point(35, 409);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(613, 56);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // checkBoxCertificate
            // 
            checkBoxCertificate.AutoSize = true;
            checkBoxCertificate.Depth = 0;
            checkBoxCertificate.Location = new Point(201, 12);
            checkBoxCertificate.Margin = new Padding(0);
            checkBoxCertificate.MouseLocation = new Point(-1, -1);
            checkBoxCertificate.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxCertificate.Name = "checkBoxCertificate";
            checkBoxCertificate.ReadOnly = false;
            checkBoxCertificate.Ripple = true;
            checkBoxCertificate.Size = new Size(203, 37);
            checkBoxCertificate.TabIndex = 4;
            checkBoxCertificate.Text = "Confiar en el certificado";
            checkBoxCertificate.UseVisualStyleBackColor = true;
            // 
            // buttonProbar
            // 
            buttonProbar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonProbar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonProbar.Depth = 0;
            buttonProbar.HighEmphasis = true;
            buttonProbar.Icon = null;
            buttonProbar.Location = new Point(35, 491);
            buttonProbar.Margin = new Padding(4, 6, 4, 6);
            buttonProbar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonProbar.Name = "buttonProbar";
            buttonProbar.NoAccentTextColor = Color.Empty;
            buttonProbar.Size = new Size(78, 36);
            buttonProbar.TabIndex = 7;
            buttonProbar.Text = "Probar";
            buttonProbar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonProbar.UseAccentColor = false;
            buttonProbar.UseVisualStyleBackColor = true;
            buttonProbar.Click += ButtonProbar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonGuardar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonGuardar.Depth = 0;
            buttonGuardar.HighEmphasis = true;
            buttonGuardar.Icon = null;
            buttonGuardar.Location = new Point(483, 491);
            buttonGuardar.Margin = new Padding(4, 6, 4, 6);
            buttonGuardar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.NoAccentTextColor = Color.Empty;
            buttonGuardar.Size = new Size(165, 36);
            buttonGuardar.TabIndex = 8;
            buttonGuardar.Text = "Guardar conexión";
            buttonGuardar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonGuardar.UseAccentColor = false;
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 362);
            label5.Name = "label5";
            label5.Size = new Size(136, 28);
            label5.TabIndex = 10;
            label5.Text = "Base de datos:";
            // 
            // textBoxBaseDatos
            // 
            textBoxBaseDatos.AnimateReadOnly = false;
            textBoxBaseDatos.BorderStyle = BorderStyle.None;
            textBoxBaseDatos.Depth = 0;
            textBoxBaseDatos.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxBaseDatos.LeadingIcon = null;
            textBoxBaseDatos.Location = new Point(177, 353);
            textBoxBaseDatos.MaxLength = 50;
            textBoxBaseDatos.MouseState = MaterialSkin.MouseState.OUT;
            textBoxBaseDatos.Multiline = false;
            textBoxBaseDatos.Name = "textBoxBaseDatos";
            textBoxBaseDatos.Size = new Size(456, 50);
            textBoxBaseDatos.TabIndex = 9;
            textBoxBaseDatos.Text = "";
            textBoxBaseDatos.TrailingIcon = Properties.Resources.close_48;
            textBoxBaseDatos.TrailingIconClick += textBoxBaseDatos_TrailingIconClick;
            // 
            // Conexion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(688, 579);
            Controls.Add(label5);
            Controls.Add(textBoxBaseDatos);
            Controls.Add(buttonGuardar);
            Controls.Add(buttonProbar);
            Controls.Add(groupBox2);
            Controls.Add(groupBoxUsuario);
            Controls.Add(label1);
            Controls.Add(textBoxServidor);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Conexion";
            ShowIcon = false;
            Sizable = false;
            Text = "Configuración";
            FormClosed += Conexion_FormClosed;
            Load += Conexion_Load;
            Controls.SetChildIndex(textBoxServidor, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(groupBoxUsuario, 0);
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(buttonProbar, 0);
            Controls.SetChildIndex(buttonGuardar, 0);
            Controls.SetChildIndex(textBoxBaseDatos, 0);
            Controls.SetChildIndex(label5, 0);
            groupBoxUsuario.ResumeLayout(false);
            groupBoxUsuario.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxServidor;
        private Label label1;
        private GroupBox groupBoxUsuario;
        private Label label3;
        private MaterialSkin.Controls.MaterialTextBox textBoxClave;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox textBoxUsuario;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxIntegrada;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxCertificate;
        private MaterialSkin.Controls.MaterialButton buttonProbar;
        private MaterialSkin.Controls.MaterialButton buttonGuardar;
        private Label label5;
        private MaterialSkin.Controls.MaterialTextBox textBoxBaseDatos;
    }
}