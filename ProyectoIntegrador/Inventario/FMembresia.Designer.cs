namespace ProyectoIntegrador.Inventario
{
    partial class FMembresia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMembresia));
            activaCheckbox = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            textBoxNombreMemb = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            textBoxPrecioMemb = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigoMemb = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcionMemb = new MaterialSkin.Controls.MaterialTextBox();
            fechaFinalMemb = new DateTimePicker();
            fechaInicioMemb = new DateTimePicker();
            defFechaVencinimiento = new MaterialSkin.Controls.MaterialCheckbox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(636, 5);
            // 
            // activaCheckbox
            // 
            activaCheckbox.AutoSize = true;
            activaCheckbox.Checked = true;
            activaCheckbox.CheckState = CheckState.Checked;
            activaCheckbox.Depth = 0;
            activaCheckbox.Location = new Point(422, 461);
            activaCheckbox.Margin = new Padding(0);
            activaCheckbox.MouseLocation = new Point(-1, -1);
            activaCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            activaCheckbox.Name = "activaCheckbox";
            activaCheckbox.ReadOnly = false;
            activaCheckbox.Ripple = true;
            activaCheckbox.Size = new Size(79, 37);
            activaCheckbox.TabIndex = 7;
            activaCheckbox.Text = "Activo";
            activaCheckbox.UseVisualStyleBackColor = true;
            activaCheckbox.CheckedChanged += activaCheckbox_CheckedChanged;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(36, 324);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(49, 19);
            materialLabel6.TabIndex = 36;
            materialLabel6.Text = "Precio:";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(36, 375);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(111, 19);
            materialLabel4.TabIndex = 34;
            materialLabel4.Text = "Fecha de inicio:";
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(285, 140);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 30;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(36, 152);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 32;
            materialLabel3.Text = "Código:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(36, 264);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(88, 19);
            materialLabel2.TabIndex = 31;
            materialLabel2.Text = "Descripcion:";
            // 
            // textBoxNombreMemb
            // 
            textBoxNombreMemb.AnimateReadOnly = false;
            textBoxNombreMemb.BorderStyle = BorderStyle.None;
            textBoxNombreMemb.Depth = 0;
            textBoxNombreMemb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNombreMemb.LeadingIcon = null;
            textBoxNombreMemb.Location = new Point(156, 192);
            textBoxNombreMemb.MaxLength = 50;
            textBoxNombreMemb.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombreMemb.Multiline = false;
            textBoxNombreMemb.Name = "textBoxNombreMemb";
            textBoxNombreMemb.Size = new Size(219, 50);
            textBoxNombreMemb.TabIndex = 1;
            textBoxNombreMemb.Text = "";
            textBoxNombreMemb.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(36, 208);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(61, 19);
            materialLabel1.TabIndex = 29;
            materialLabel1.Text = "Nombre:";
            // 
            // textBoxPrecioMemb
            // 
            textBoxPrecioMemb.AnimateReadOnly = false;
            textBoxPrecioMemb.BorderStyle = BorderStyle.None;
            textBoxPrecioMemb.Depth = 0;
            textBoxPrecioMemb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPrecioMemb.LeadingIcon = null;
            textBoxPrecioMemb.Location = new Point(156, 309);
            textBoxPrecioMemb.MaxLength = 50;
            textBoxPrecioMemb.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPrecioMemb.Multiline = false;
            textBoxPrecioMemb.Name = "textBoxPrecioMemb";
            textBoxPrecioMemb.Size = new Size(126, 50);
            textBoxPrecioMemb.TabIndex = 3;
            textBoxPrecioMemb.Text = "";
            textBoxPrecioMemb.TrailingIcon = null;
            // 
            // textBoxCodigoMemb
            // 
            textBoxCodigoMemb.AnimateReadOnly = false;
            textBoxCodigoMemb.BorderStyle = BorderStyle.None;
            textBoxCodigoMemb.Depth = 0;
            textBoxCodigoMemb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoMemb.LeadingIcon = null;
            textBoxCodigoMemb.Location = new Point(157, 134);
            textBoxCodigoMemb.MaxLength = 50;
            textBoxCodigoMemb.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoMemb.Multiline = false;
            textBoxCodigoMemb.Name = "textBoxCodigoMemb";
            textBoxCodigoMemb.Size = new Size(125, 50);
            textBoxCodigoMemb.TabIndex = 0;
            textBoxCodigoMemb.Text = "";
            textBoxCodigoMemb.TrailingIcon = null;
            // 
            // textBoxDescripcionMemb
            // 
            textBoxDescripcionMemb.AnimateReadOnly = false;
            textBoxDescripcionMemb.BorderStyle = BorderStyle.None;
            textBoxDescripcionMemb.Depth = 0;
            textBoxDescripcionMemb.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionMemb.LeadingIcon = null;
            textBoxDescripcionMemb.Location = new Point(157, 250);
            textBoxDescripcionMemb.MaxLength = 50;
            textBoxDescripcionMemb.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionMemb.Multiline = false;
            textBoxDescripcionMemb.Name = "textBoxDescripcionMemb";
            textBoxDescripcionMemb.Size = new Size(469, 50);
            textBoxDescripcionMemb.TabIndex = 2;
            textBoxDescripcionMemb.Text = "";
            textBoxDescripcionMemb.TrailingIcon = null;
            // 
            // fechaFinalMemb
            // 
            fechaFinalMemb.CustomFormat = "dd/MM/yyyy";
            fechaFinalMemb.Format = DateTimePickerFormat.Custom;
            fechaFinalMemb.Location = new Point(6, 25);
            fechaFinalMemb.Name = "fechaFinalMemb";
            fechaFinalMemb.Size = new Size(152, 27);
            fechaFinalMemb.TabIndex = 46;
            // 
            // fechaInicioMemb
            // 
            fechaInicioMemb.CustomFormat = "dd/MM/yyyy";
            fechaInicioMemb.Format = DateTimePickerFormat.Custom;
            fechaInicioMemb.Location = new Point(156, 372);
            fechaInicioMemb.Name = "fechaInicioMemb";
            fechaInicioMemb.Size = new Size(126, 27);
            fechaInicioMemb.TabIndex = 4;
            // 
            // defFechaVencinimiento
            // 
            defFechaVencinimiento.AutoSize = true;
            defFechaVencinimiento.Depth = 0;
            defFechaVencinimiento.Location = new Point(36, 415);
            defFechaVencinimiento.Margin = new Padding(0);
            defFechaVencinimiento.MouseLocation = new Point(-1, -1);
            defFechaVencinimiento.MouseState = MaterialSkin.MouseState.HOVER;
            defFechaVencinimiento.Name = "defFechaVencinimiento";
            defFechaVencinimiento.ReadOnly = false;
            defFechaVencinimiento.Ripple = true;
            defFechaVencinimiento.Size = new Size(221, 37);
            defFechaVencinimiento.TabIndex = 5;
            defFechaVencinimiento.Text = "Definir Fecha Vencimiento";
            defFechaVencinimiento.UseVisualStyleBackColor = true;
            defFechaVencinimiento.CheckedChanged += defFechaVencinimiento_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fechaFinalMemb);
            groupBox1.Location = new Point(36, 446);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(339, 64);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // FMembresia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 552);
            Controls.Add(groupBox1);
            Controls.Add(defFechaVencinimiento);
            Controls.Add(fechaInicioMemb);
            Controls.Add(textBoxDescripcionMemb);
            Controls.Add(textBoxCodigoMemb);
            Controls.Add(textBoxPrecioMemb);
            Controls.Add(activaCheckbox);
            Controls.Add(materialLabel6);
            Controls.Add(materialLabel4);
            Controls.Add(bBuscar1);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(textBoxNombreMemb);
            Controls.Add(materialLabel1);
            Name = "FMembresia";
            Text = "Membresía";
            Load += FMembresia_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxNombreMemb, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(materialLabel4, 0);
            Controls.SetChildIndex(materialLabel6, 0);
            Controls.SetChildIndex(activaCheckbox, 0);
            Controls.SetChildIndex(textBoxPrecioMemb, 0);
            Controls.SetChildIndex(textBoxCodigoMemb, 0);
            Controls.SetChildIndex(textBoxDescripcionMemb, 0);
            Controls.SetChildIndex(fechaInicioMemb, 0);
            Controls.SetChildIndex(defFechaVencinimiento, 0);
            Controls.SetChildIndex(groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox activaCheckbox;
        private MaterialSkin.Controls.MaterialCheckbox itbisCheckBox;
        private DateTimePicker fechaFinalDesc;
        private DateTimePicker fechaIncioDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox textBoxPorcentajeDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox textBoxNombreMemb;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox textBoxPrecioMemb;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoMemb;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionMemb;
        private DateTimePicker fechaFinalMemb;
        private DateTimePicker fechaInicioMemb;
        private MaterialSkin.Controls.MaterialCheckbox defFechaVencinimiento;
        private GroupBox groupBox1;
    }
}