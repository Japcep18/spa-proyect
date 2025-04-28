namespace ProyectoIntegrador.Inventario
{
    partial class FServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FServicios));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            textBoxNombre = new MaterialSkin.Controls.MaterialTextBox();
            textBoxPrecioBase = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxEstimado = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            textBoxRecuperacion = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            groupBox1 = new GroupBox();
            checkBoxActivo = new MaterialSkin.Controls.MaterialCheckbox();
            switchApilable = new MaterialSkin.Controls.MaterialSwitch();
            switchComplementario = new MaterialSkin.Controls.MaterialSwitch();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(613, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(34, 213);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(61, 19);
            materialLabel1.TabIndex = 1;
            materialLabel1.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.AnimateReadOnly = false;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Depth = 0;
            textBoxNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNombre.LeadingIcon = null;
            textBoxNombre.Location = new Point(180, 196);
            textBoxNombre.MaxLength = 50;
            textBoxNombre.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombre.Multiline = false;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(402, 50);
            textBoxNombre.TabIndex = 0;
            textBoxNombre.Text = "";
            textBoxNombre.TrailingIcon = null;
            // 
            // textBoxPrecioBase
            // 
            textBoxPrecioBase.AnimateReadOnly = false;
            textBoxPrecioBase.BorderStyle = BorderStyle.None;
            textBoxPrecioBase.Depth = 0;
            textBoxPrecioBase.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPrecioBase.LeadingIcon = null;
            textBoxPrecioBase.Location = new Point(180, 252);
            textBoxPrecioBase.MaxLength = 50;
            textBoxPrecioBase.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPrecioBase.Multiline = false;
            textBoxPrecioBase.Name = "textBoxPrecioBase";
            textBoxPrecioBase.Size = new Size(167, 50);
            textBoxPrecioBase.TabIndex = 1;
            textBoxPrecioBase.Text = "";
            textBoxPrecioBase.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(34, 269);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(87, 19);
            materialLabel2.TabIndex = 3;
            materialLabel2.Text = "Precio base:";
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(180, 140);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(126, 50);
            textBoxCodigo.TabIndex = 6;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(34, 157);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 5;
            materialLabel3.Text = "Código:";
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(309, 146);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 2;
            // 
            // textBoxEstimado
            // 
            textBoxEstimado.AnimateReadOnly = false;
            textBoxEstimado.BorderStyle = BorderStyle.None;
            textBoxEstimado.Depth = 0;
            textBoxEstimado.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxEstimado.LeadingIcon = null;
            textBoxEstimado.Location = new Point(180, 308);
            textBoxEstimado.MaxLength = 50;
            textBoxEstimado.MouseState = MaterialSkin.MouseState.OUT;
            textBoxEstimado.Multiline = false;
            textBoxEstimado.Name = "textBoxEstimado";
            textBoxEstimado.Size = new Size(167, 50);
            textBoxEstimado.TabIndex = 10;
            textBoxEstimado.Text = "";
            textBoxEstimado.TrailingIcon = null;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(34, 325);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(129, 19);
            materialLabel4.TabIndex = 11;
            materialLabel4.Text = "Tiempo estimado:";
            // 
            // textBoxRecuperacion
            // 
            textBoxRecuperacion.AnimateReadOnly = false;
            textBoxRecuperacion.BorderStyle = BorderStyle.None;
            textBoxRecuperacion.Depth = 0;
            textBoxRecuperacion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxRecuperacion.LeadingIcon = null;
            textBoxRecuperacion.Location = new Point(180, 364);
            textBoxRecuperacion.MaxLength = 50;
            textBoxRecuperacion.MouseState = MaterialSkin.MouseState.OUT;
            textBoxRecuperacion.Multiline = false;
            textBoxRecuperacion.Name = "textBoxRecuperacion";
            textBoxRecuperacion.Size = new Size(167, 50);
            textBoxRecuperacion.TabIndex = 12;
            textBoxRecuperacion.Text = "";
            textBoxRecuperacion.TrailingIcon = null;
            // 
            // materialLabel5
            // 
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(34, 366);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(113, 47);
            materialLabel5.TabIndex = 13;
            materialLabel5.Text = "Tiempo de \r\nrecuperación:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxActivo);
            groupBox1.Controls.Add(switchApilable);
            groupBox1.Controls.Add(switchComplementario);
            groupBox1.Location = new Point(34, 420);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(548, 157);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // checkBoxActivo
            // 
            checkBoxActivo.AutoSize = true;
            checkBoxActivo.Depth = 0;
            checkBoxActivo.Location = new Point(14, 109);
            checkBoxActivo.Margin = new Padding(0);
            checkBoxActivo.MouseLocation = new Point(-1, -1);
            checkBoxActivo.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxActivo.Name = "checkBoxActivo";
            checkBoxActivo.ReadOnly = false;
            checkBoxActivo.Ripple = true;
            checkBoxActivo.Size = new Size(79, 37);
            checkBoxActivo.TabIndex = 2;
            checkBoxActivo.Text = "Activo";
            checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // switchApilable
            // 
            switchApilable.AutoSize = true;
            switchApilable.Depth = 0;
            switchApilable.Location = new Point(14, 66);
            switchApilable.Margin = new Padding(0);
            switchApilable.MouseLocation = new Point(-1, -1);
            switchApilable.MouseState = MaterialSkin.MouseState.HOVER;
            switchApilable.Name = "switchApilable";
            switchApilable.Ripple = true;
            switchApilable.Size = new Size(299, 37);
            switchApilable.TabIndex = 1;
            switchApilable.Text = "¿El tiempo de servicio es apilable?";
            switchApilable.UseVisualStyleBackColor = true;
            // 
            // switchComplementario
            // 
            switchComplementario.AutoSize = true;
            switchComplementario.Depth = 0;
            switchComplementario.Location = new Point(14, 23);
            switchComplementario.Margin = new Padding(0);
            switchComplementario.MouseLocation = new Point(-1, -1);
            switchComplementario.MouseState = MaterialSkin.MouseState.HOVER;
            switchComplementario.Name = "switchComplementario";
            switchComplementario.Ripple = true;
            switchComplementario.Size = new Size(284, 37);
            switchComplementario.TabIndex = 0;
            switchComplementario.Text = "¿Es el servicio complementario?";
            switchComplementario.UseVisualStyleBackColor = true;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(372, 325);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(70, 19);
            materialLabel6.TabIndex = 15;
            materialLabel6.Text = "(minutos)";
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(372, 379);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(70, 19);
            materialLabel7.TabIndex = 16;
            materialLabel7.Text = "(minutos)";
            // 
            // FServicios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 624);
            Controls.Add(materialLabel7);
            Controls.Add(materialLabel6);
            Controls.Add(groupBox1);
            Controls.Add(textBoxRecuperacion);
            Controls.Add(materialLabel5);
            Controls.Add(textBoxEstimado);
            Controls.Add(materialLabel4);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxCodigo);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxPrecioBase);
            Controls.Add(materialLabel2);
            Controls.Add(textBoxNombre);
            Controls.Add(materialLabel1);
            Name = "FServicios";
            Text = "Servicios";
            Load += FServicios_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxNombre, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(textBoxPrecioBase, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigo, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(materialLabel4, 0);
            Controls.SetChildIndex(textBoxEstimado, 0);
            Controls.SetChildIndex(materialLabel5, 0);
            Controls.SetChildIndex(textBoxRecuperacion, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(materialLabel6, 0);
            Controls.SetChildIndex(materialLabel7, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox textBoxNombre;
        private MaterialSkin.Controls.MaterialTextBox textBoxPrecioBase;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxEstimado;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox textBoxRecuperacion;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialSwitch switchComplementario;
        private MaterialSkin.Controls.MaterialSwitch switchApilable;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxActivo;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
    }
}