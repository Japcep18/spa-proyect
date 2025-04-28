namespace ProyectoIntegrador.Inventario
{
    partial class FKit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKit));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            textBoxCodigoKit = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            textBoxNombreKit = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            groupBoxMembresia = new GroupBox();
            textBoxMembresiaNombre = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar2 = new Utilidades.Controles.BBuscar();
            textBoxCodigoMembresia = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            fechaValidez = new DateTimePicker();
            checkBoxActivo = new MaterialSkin.Controls.MaterialCheckbox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBoxMembresia.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(794, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(37, 138);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Código:";
            // 
            // textBoxCodigoKit
            // 
            textBoxCodigoKit.AnimateReadOnly = false;
            textBoxCodigoKit.BorderStyle = BorderStyle.None;
            textBoxCodigoKit.Depth = 0;
            textBoxCodigoKit.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoKit.LeadingIcon = null;
            textBoxCodigoKit.Location = new Point(98, 119);
            textBoxCodigoKit.MaxLength = 50;
            textBoxCodigoKit.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoKit.Multiline = false;
            textBoxCodigoKit.Name = "textBoxCodigoKit";
            textBoxCodigoKit.Size = new Size(179, 50);
            textBoxCodigoKit.TabIndex = 11;
            textBoxCodigoKit.Text = "";
            textBoxCodigoKit.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(342, 137);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(61, 19);
            materialLabel2.TabIndex = 12;
            materialLabel2.Text = "Nombre:";
            // 
            // textBoxNombreKit
            // 
            textBoxNombreKit.AnimateReadOnly = false;
            textBoxNombreKit.BorderStyle = BorderStyle.None;
            textBoxNombreKit.Depth = 0;
            textBoxNombreKit.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNombreKit.LeadingIcon = null;
            textBoxNombreKit.Location = new Point(409, 119);
            textBoxNombreKit.MaxLength = 50;
            textBoxNombreKit.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombreKit.Multiline = false;
            textBoxNombreKit.Name = "textBoxNombreKit";
            textBoxNombreKit.Size = new Size(364, 50);
            textBoxNombreKit.TabIndex = 14;
            textBoxNombreKit.Text = "";
            textBoxNombreKit.TrailingIcon = null;
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(283, 119);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(53, 50);
            bBuscar1.TabIndex = 15;
            bBuscar1.UseVisualStyleBackColor = true;
            // 
            // groupBoxMembresia
            // 
            groupBoxMembresia.Controls.Add(textBoxMembresiaNombre);
            groupBoxMembresia.Controls.Add(bBuscar2);
            groupBoxMembresia.Controls.Add(textBoxCodigoMembresia);
            groupBoxMembresia.Location = new Point(25, 175);
            groupBoxMembresia.Name = "groupBoxMembresia";
            groupBoxMembresia.Size = new Size(757, 80);
            groupBoxMembresia.TabIndex = 16;
            groupBoxMembresia.TabStop = false;
            groupBoxMembresia.Text = "Membresía:";
            // 
            // textBoxMembresiaNombre
            // 
            textBoxMembresiaNombre.AnimateReadOnly = false;
            textBoxMembresiaNombre.BorderStyle = BorderStyle.None;
            textBoxMembresiaNombre.Depth = 0;
            textBoxMembresiaNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxMembresiaNombre.LeadingIcon = null;
            textBoxMembresiaNombre.Location = new Point(194, 24);
            textBoxMembresiaNombre.MaxLength = 50;
            textBoxMembresiaNombre.MouseState = MaterialSkin.MouseState.OUT;
            textBoxMembresiaNombre.Multiline = false;
            textBoxMembresiaNombre.Name = "textBoxMembresiaNombre";
            textBoxMembresiaNombre.Size = new Size(554, 50);
            textBoxMembresiaNombre.TabIndex = 17;
            textBoxMembresiaNombre.Text = "";
            textBoxMembresiaNombre.TrailingIcon = null;
            // 
            // bBuscar2
            // 
            bBuscar2.Image = (Image)resources.GetObject("bBuscar2.Image");
            bBuscar2.Location = new Point(143, 26);
            bBuscar2.Name = "bBuscar2";
            bBuscar2.Size = new Size(45, 45);
            bBuscar2.TabIndex = 1;
            bBuscar2.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoMembresia
            // 
            textBoxCodigoMembresia.AnimateReadOnly = false;
            textBoxCodigoMembresia.BorderStyle = BorderStyle.None;
            textBoxCodigoMembresia.Depth = 0;
            textBoxCodigoMembresia.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoMembresia.LeadingIcon = null;
            textBoxCodigoMembresia.Location = new Point(12, 24);
            textBoxCodigoMembresia.MaxLength = 50;
            textBoxCodigoMembresia.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoMembresia.Multiline = false;
            textBoxCodigoMembresia.Name = "textBoxCodigoMembresia";
            textBoxCodigoMembresia.Size = new Size(125, 50);
            textBoxCodigoMembresia.TabIndex = 0;
            textBoxCodigoMembresia.Text = "";
            textBoxCodigoMembresia.TrailingIcon = null;
            textBoxCodigoMembresia.TextChanged += materialTextBox3_TextChanged;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(25, 275);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(123, 19);
            materialLabel5.TabIndex = 25;
            materialLabel5.Text = "Fecha de validez:";
            // 
            // fechaValidez
            // 
            fechaValidez.CustomFormat = "dd/MM/yy";
            fechaValidez.Font = new Font("Segoe UI", 10F);
            fechaValidez.Format = DateTimePickerFormat.Custom;
            fechaValidez.Location = new Point(182, 271);
            fechaValidez.Name = "fechaValidez";
            fechaValidez.Size = new Size(154, 30);
            fechaValidez.TabIndex = 26;
            // 
            // checkBoxActivo
            // 
            checkBoxActivo.AutoSize = true;
            checkBoxActivo.Checked = true;
            checkBoxActivo.CheckState = CheckState.Checked;
            checkBoxActivo.Depth = 0;
            checkBoxActivo.Location = new Point(371, 265);
            checkBoxActivo.Margin = new Padding(0);
            checkBoxActivo.MouseLocation = new Point(-1, -1);
            checkBoxActivo.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxActivo.Name = "checkBoxActivo";
            checkBoxActivo.ReadOnly = false;
            checkBoxActivo.Ripple = true;
            checkBoxActivo.Size = new Size(83, 37);
            checkBoxActivo.TabIndex = 27;
            checkBoxActivo.Text = "Activo:";
            checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // FKit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 354);
            Controls.Add(checkBoxActivo);
            Controls.Add(materialLabel5);
            Controls.Add(fechaValidez);
            Controls.Add(groupBoxMembresia);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxNombreKit);
            Controls.Add(materialLabel2);
            Controls.Add(textBoxCodigoKit);
            Controls.Add(materialLabel1);
            Name = "FKit";
            Text = "FKit";
            Load += FKit_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxCodigoKit, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(textBoxNombreKit, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(groupBoxMembresia, 0);
            Controls.SetChildIndex(fechaValidez, 0);
            Controls.SetChildIndex(materialLabel5, 0);
            Controls.SetChildIndex(checkBoxActivo, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBoxMembresia.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        //private void FKit_Load(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoKit;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox textBoxNombreKit;
        private Utilidades.Controles.BBuscar bBuscar1;
        private GroupBox groupBoxMembresia;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoMembresia;
        private MaterialSkin.Controls.MaterialTextBox textBoxMembresiaNombre;
        private Utilidades.Controles.BBuscar bBuscar2;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private DateTimePicker fechaValidez;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxActivo;
    }
}