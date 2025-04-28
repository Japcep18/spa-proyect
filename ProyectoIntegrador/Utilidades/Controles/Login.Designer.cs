namespace ProyectoIntegrador
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            label1 = new Label();
            label3 = new Label();
            buttonLogin = new MaterialSkin.Controls.MaterialButton();
            label2 = new Label();
            textBoxUsuario = new MaterialSkin.Controls.MaterialTextBox();
            buttonCancelar = new MaterialSkin.Controls.MaterialButton();
            errorProvider1 = new ErrorProvider(components);
            textBoxClave = new MaterialSkin.Controls.MaterialTextBox2();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(63, 81, 181);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(635, 54);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(200, 7);
            label1.Name = "label1";
            label1.Size = new Size(234, 41);
            label1.TabIndex = 0;
            label1.Text = "Inicio de sesión";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(32, 193);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // buttonLogin
            // 
            buttonLogin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonLogin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonLogin.Depth = 0;
            buttonLogin.HighEmphasis = true;
            buttonLogin.Icon = null;
            buttonLogin.Location = new Point(32, 304);
            buttonLogin.Margin = new Padding(4, 6, 4, 6);
            buttonLogin.MouseState = MaterialSkin.MouseState.HOVER;
            buttonLogin.Name = "buttonLogin";
            buttonLogin.NoAccentTextColor = Color.Empty;
            buttonLogin.Size = new Size(128, 36);
            buttonLogin.TabIndex = 2;
            buttonLogin.Text = "Iniciar sesión";
            buttonLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonLogin.UseAccentColor = false;
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += BLogin_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(32, 103);
            label2.Name = "label2";
            label2.Size = new Size(79, 28);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUsuario.AnimateReadOnly = false;
            textBoxUsuario.BorderStyle = BorderStyle.None;
            textBoxUsuario.Depth = 0;
            textBoxUsuario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxUsuario.LeadingIcon = null;
            textBoxUsuario.Location = new Point(32, 136);
            textBoxUsuario.MaxLength = 50;
            textBoxUsuario.MouseState = MaterialSkin.MouseState.OUT;
            textBoxUsuario.Multiline = false;
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(559, 50);
            textBoxUsuario.TabIndex = 0;
            textBoxUsuario.Text = "";
            textBoxUsuario.TrailingIcon = null;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonCancelar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonCancelar.Depth = 0;
            buttonCancelar.HighEmphasis = true;
            buttonCancelar.Icon = null;
            buttonCancelar.Location = new Point(493, 304);
            buttonCancelar.Margin = new Padding(4, 6, 4, 6);
            buttonCancelar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.NoAccentTextColor = Color.Empty;
            buttonCancelar.Size = new Size(96, 36);
            buttonCancelar.TabIndex = 3;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonCancelar.UseAccentColor = false;
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += materialButton1_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // textBoxClave
            // 
            textBoxClave.AnimateReadOnly = false;
            textBoxClave.BackgroundImageLayout = ImageLayout.None;
            textBoxClave.CharacterCasing = CharacterCasing.Normal;
            textBoxClave.Depth = 0;
            textBoxClave.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxClave.HideSelection = true;
            textBoxClave.LeadingIcon = null;
            textBoxClave.Location = new Point(32, 224);
            textBoxClave.MaxLength = 32767;
            textBoxClave.MouseState = MaterialSkin.MouseState.OUT;
            textBoxClave.Name = "textBoxClave";
            textBoxClave.PasswordChar = '●';
            textBoxClave.PrefixSuffixText = null;
            textBoxClave.ReadOnly = false;
            textBoxClave.RightToLeft = RightToLeft.No;
            textBoxClave.SelectedText = "";
            textBoxClave.SelectionLength = 0;
            textBoxClave.SelectionStart = 0;
            textBoxClave.ShortcutsEnabled = true;
            textBoxClave.Size = new Size(557, 48);
            textBoxClave.TabIndex = 1;
            textBoxClave.TabStop = false;
            textBoxClave.Text = "materialTextBox21";
            textBoxClave.TextAlign = HorizontalAlignment.Left;
            textBoxClave.TrailingIcon = Properties.Resources.key_48;
            textBoxClave.UseSystemPasswordChar = false;
            textBoxClave.TrailingIconClick += textBoxClave_TrailingIconClick_1;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 350);
            Controls.Add(textBoxClave);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonLogin);
            Controls.Add(label3);
            Controls.Add(textBoxUsuario);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormStyle = FormStyles.ActionBar_None;
            MaximizeBox = false;
            MaximumSize = new Size(635, 350);
            MinimizeBox = false;
            MinimumSize = new Size(635, 350);
            Name = "Login";
            Padding = new Padding(0, 24, 0, 0);
            ShowInTaskbar = false;
            Sizable = false;
            Text = "Inicio de sesión";
            Load += Login_Load;
            Shown += Login_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label3;
        private MaterialSkin.Controls.MaterialButton buttonLogin;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox textBoxUsuario;
        private MaterialSkin.Controls.MaterialButton buttonCancelar;
        private ErrorProvider errorProvider1;
        private MaterialSkin.Controls.MaterialTextBox2 textBoxClave;
    }
}
