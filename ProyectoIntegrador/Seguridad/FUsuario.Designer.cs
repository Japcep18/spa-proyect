namespace ProyectoIntegrador.Seguridad
{
    partial class FUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUsuario));
            bBuscarUsuario = new Utilidades.Controles.BBuscar();
            textBoxCodigoUsuario = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            bBuscarEmpleado = new Utilidades.Controles.BBuscar();
            textBoxEmpleadoCodigo = new MaterialSkin.Controls.MaterialTextBox();
            textBoxEmpleadoDesc = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            textBoxPerfilDesc = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarPerfil = new Utilidades.Controles.BBuscar();
            textBoxPerfilCodigo = new MaterialSkin.Controls.MaterialTextBox();
            textBoxUsuario = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            textBoxClave = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            checkBoxActivo = new MaterialSkin.Controls.MaterialCheckbox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(747, 5);
            // 
            // bBuscarUsuario
            // 
            bBuscarUsuario.AutoSize = true;
            bBuscarUsuario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscarUsuario.Image = (Image)resources.GetObject("bBuscarUsuario.Image");
            bBuscarUsuario.Location = new Point(273, 151);
            bBuscarUsuario.Margin = new Padding(0);
            bBuscarUsuario.Name = "bBuscarUsuario";
            bBuscarUsuario.Size = new Size(38, 38);
            bBuscarUsuario.TabIndex = 11;
            // 
            // textBoxCodigoUsuario
            // 
            textBoxCodigoUsuario.AnimateReadOnly = false;
            textBoxCodigoUsuario.BorderStyle = BorderStyle.None;
            textBoxCodigoUsuario.Depth = 0;
            textBoxCodigoUsuario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoUsuario.LeadingIcon = null;
            textBoxCodigoUsuario.Location = new Point(144, 145);
            textBoxCodigoUsuario.MaxLength = 50;
            textBoxCodigoUsuario.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoUsuario.Multiline = false;
            textBoxCodigoUsuario.Name = "textBoxCodigoUsuario";
            textBoxCodigoUsuario.Size = new Size(126, 50);
            textBoxCodigoUsuario.TabIndex = 13;
            textBoxCodigoUsuario.Text = "";
            textBoxCodigoUsuario.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(36, 162);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(59, 19);
            materialLabel3.TabIndex = 12;
            materialLabel3.Text = "Usuario:";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(36, 220);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(76, 19);
            materialLabel1.TabIndex = 14;
            materialLabel1.Text = "Empleado:";
            // 
            // bBuscarEmpleado
            // 
            bBuscarEmpleado.AutoSize = true;
            bBuscarEmpleado.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscarEmpleado.Image = (Image)resources.GetObject("bBuscarEmpleado.Image");
            bBuscarEmpleado.Location = new Point(273, 207);
            bBuscarEmpleado.Margin = new Padding(0);
            bBuscarEmpleado.Name = "bBuscarEmpleado";
            bBuscarEmpleado.Size = new Size(38, 38);
            bBuscarEmpleado.TabIndex = 15;
            // 
            // textBoxEmpleadoCodigo
            // 
            textBoxEmpleadoCodigo.AnimateReadOnly = false;
            textBoxEmpleadoCodigo.BorderStyle = BorderStyle.None;
            textBoxEmpleadoCodigo.Depth = 0;
            textBoxEmpleadoCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxEmpleadoCodigo.LeadingIcon = null;
            textBoxEmpleadoCodigo.Location = new Point(144, 201);
            textBoxEmpleadoCodigo.MaxLength = 50;
            textBoxEmpleadoCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxEmpleadoCodigo.Multiline = false;
            textBoxEmpleadoCodigo.Name = "textBoxEmpleadoCodigo";
            textBoxEmpleadoCodigo.Size = new Size(126, 50);
            textBoxEmpleadoCodigo.TabIndex = 16;
            textBoxEmpleadoCodigo.Text = "";
            textBoxEmpleadoCodigo.TrailingIcon = null;
            // 
            // textBoxEmpleadoDesc
            // 
            textBoxEmpleadoDesc.AnimateReadOnly = false;
            textBoxEmpleadoDesc.BorderStyle = BorderStyle.None;
            textBoxEmpleadoDesc.Depth = 0;
            textBoxEmpleadoDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxEmpleadoDesc.LeadingIcon = null;
            textBoxEmpleadoDesc.Location = new Point(314, 201);
            textBoxEmpleadoDesc.MaxLength = 50;
            textBoxEmpleadoDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxEmpleadoDesc.Multiline = false;
            textBoxEmpleadoDesc.Name = "textBoxEmpleadoDesc";
            textBoxEmpleadoDesc.ReadOnly = true;
            textBoxEmpleadoDesc.Size = new Size(395, 50);
            textBoxEmpleadoDesc.TabIndex = 17;
            textBoxEmpleadoDesc.Text = "";
            textBoxEmpleadoDesc.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(36, 275);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(42, 19);
            materialLabel2.TabIndex = 18;
            materialLabel2.Text = "Perfil:";
            // 
            // textBoxPerfilDesc
            // 
            textBoxPerfilDesc.AnimateReadOnly = false;
            textBoxPerfilDesc.BorderStyle = BorderStyle.None;
            textBoxPerfilDesc.Depth = 0;
            textBoxPerfilDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPerfilDesc.LeadingIcon = null;
            textBoxPerfilDesc.Location = new Point(314, 257);
            textBoxPerfilDesc.MaxLength = 50;
            textBoxPerfilDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPerfilDesc.Multiline = false;
            textBoxPerfilDesc.Name = "textBoxPerfilDesc";
            textBoxPerfilDesc.ReadOnly = true;
            textBoxPerfilDesc.Size = new Size(395, 50);
            textBoxPerfilDesc.TabIndex = 21;
            textBoxPerfilDesc.Text = "";
            textBoxPerfilDesc.TrailingIcon = null;
            // 
            // bBuscarPerfil
            // 
            bBuscarPerfil.AutoSize = true;
            bBuscarPerfil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscarPerfil.Image = (Image)resources.GetObject("bBuscarPerfil.Image");
            bBuscarPerfil.Location = new Point(273, 263);
            bBuscarPerfil.Margin = new Padding(0);
            bBuscarPerfil.Name = "bBuscarPerfil";
            bBuscarPerfil.Size = new Size(38, 38);
            bBuscarPerfil.TabIndex = 19;
            // 
            // textBoxPerfilCodigo
            // 
            textBoxPerfilCodigo.AnimateReadOnly = false;
            textBoxPerfilCodigo.BorderStyle = BorderStyle.None;
            textBoxPerfilCodigo.Depth = 0;
            textBoxPerfilCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPerfilCodigo.LeadingIcon = null;
            textBoxPerfilCodigo.Location = new Point(144, 257);
            textBoxPerfilCodigo.MaxLength = 50;
            textBoxPerfilCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPerfilCodigo.Multiline = false;
            textBoxPerfilCodigo.Name = "textBoxPerfilCodigo";
            textBoxPerfilCodigo.Size = new Size(126, 50);
            textBoxPerfilCodigo.TabIndex = 20;
            textBoxPerfilCodigo.Text = "";
            textBoxPerfilCodigo.TrailingIcon = null;
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.AnimateReadOnly = false;
            textBoxUsuario.BorderStyle = BorderStyle.None;
            textBoxUsuario.Depth = 0;
            textBoxUsuario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxUsuario.LeadingIcon = null;
            textBoxUsuario.Location = new Point(144, 329);
            textBoxUsuario.MaxLength = 50;
            textBoxUsuario.MouseState = MaterialSkin.MouseState.OUT;
            textBoxUsuario.Multiline = false;
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(354, 50);
            textBoxUsuario.TabIndex = 23;
            textBoxUsuario.Text = "";
            textBoxUsuario.TrailingIcon = null;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(36, 347);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(59, 19);
            materialLabel4.TabIndex = 22;
            materialLabel4.Text = "Usuario:";
            // 
            // textBoxClave
            // 
            textBoxClave.AnimateReadOnly = false;
            textBoxClave.BorderStyle = BorderStyle.None;
            textBoxClave.Depth = 0;
            textBoxClave.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxClave.LeadingIcon = null;
            textBoxClave.Location = new Point(144, 385);
            textBoxClave.MaxLength = 50;
            textBoxClave.MouseState = MaterialSkin.MouseState.OUT;
            textBoxClave.Multiline = false;
            textBoxClave.Name = "textBoxClave";
            textBoxClave.Size = new Size(354, 50);
            textBoxClave.TabIndex = 25;
            textBoxClave.Text = "";
            textBoxClave.TrailingIcon = null;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(36, 403);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(44, 19);
            materialLabel5.TabIndex = 24;
            materialLabel5.Text = "Clave:";
            // 
            // checkBoxActivo
            // 
            checkBoxActivo.AutoSize = true;
            checkBoxActivo.Depth = 0;
            checkBoxActivo.Location = new Point(144, 446);
            checkBoxActivo.Margin = new Padding(0);
            checkBoxActivo.MouseLocation = new Point(-1, -1);
            checkBoxActivo.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxActivo.Name = "checkBoxActivo";
            checkBoxActivo.ReadOnly = false;
            checkBoxActivo.Ripple = true;
            checkBoxActivo.Size = new Size(79, 37);
            checkBoxActivo.TabIndex = 26;
            checkBoxActivo.Text = "Activo";
            checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // FUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 517);
            Controls.Add(checkBoxActivo);
            Controls.Add(textBoxClave);
            Controls.Add(materialLabel5);
            Controls.Add(textBoxUsuario);
            Controls.Add(materialLabel4);
            Controls.Add(textBoxPerfilDesc);
            Controls.Add(bBuscarPerfil);
            Controls.Add(textBoxPerfilCodigo);
            Controls.Add(materialLabel2);
            Controls.Add(textBoxEmpleadoDesc);
            Controls.Add(bBuscarEmpleado);
            Controls.Add(textBoxEmpleadoCodigo);
            Controls.Add(materialLabel1);
            Controls.Add(bBuscarUsuario);
            Controls.Add(textBoxCodigoUsuario);
            Controls.Add(materialLabel3);
            Name = "FUsuario";
            Text = "FUsuario";
            Load += FUsuario_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigoUsuario, 0);
            Controls.SetChildIndex(bBuscarUsuario, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxEmpleadoCodigo, 0);
            Controls.SetChildIndex(bBuscarEmpleado, 0);
            Controls.SetChildIndex(textBoxEmpleadoDesc, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(textBoxPerfilCodigo, 0);
            Controls.SetChildIndex(bBuscarPerfil, 0);
            Controls.SetChildIndex(textBoxPerfilDesc, 0);
            Controls.SetChildIndex(materialLabel4, 0);
            Controls.SetChildIndex(textBoxUsuario, 0);
            Controls.SetChildIndex(materialLabel5, 0);
            Controls.SetChildIndex(textBoxClave, 0);
            Controls.SetChildIndex(checkBoxActivo, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Utilidades.Controles.BBuscar bBuscarUsuario;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoUsuario;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private Utilidades.Controles.BBuscar bBuscarEmpleado;
        private MaterialSkin.Controls.MaterialTextBox textBoxEmpleadoCodigo;
        private MaterialSkin.Controls.MaterialTextBox textBoxEmpleadoDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox textBoxPerfilDesc;
        private Utilidades.Controles.BBuscar bBuscarPerfil;
        private MaterialSkin.Controls.MaterialTextBox textBoxPerfilCodigo;
        private MaterialSkin.Controls.MaterialTextBox textBoxUsuario;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox textBoxClave;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxActivo;
    }
}