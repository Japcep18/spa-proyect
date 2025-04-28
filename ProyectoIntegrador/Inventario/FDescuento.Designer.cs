namespace ProyectoIntegrador.Inventario
{
    partial class FDescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDescuento));
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigoDesc = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            textBoxPorcentajeDesc = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            textBoxDescripcionDesc = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            fechaIncioDesc = new DateTimePicker();
            fechaFinalDesc = new DateTimePicker();
            itbisCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            activoCheckbox = new MaterialSkin.Controls.MaterialCheckbox();
            checkBoxDefinirFechaFin = new MaterialSkin.Controls.MaterialCheckbox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(517, 5);
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(278, 131);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 13;
            // 
            // textBoxCodigoDesc
            // 
            textBoxCodigoDesc.AnimateReadOnly = false;
            textBoxCodigoDesc.BorderStyle = BorderStyle.None;
            textBoxCodigoDesc.Depth = 0;
            textBoxCodigoDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoDesc.LeadingIcon = null;
            textBoxCodigoDesc.Location = new Point(149, 125);
            textBoxCodigoDesc.MaxLength = 50;
            textBoxCodigoDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoDesc.Multiline = false;
            textBoxCodigoDesc.Name = "textBoxCodigoDesc";
            textBoxCodigoDesc.Size = new Size(122, 50);
            textBoxCodigoDesc.TabIndex = 16;
            textBoxCodigoDesc.Text = "";
            textBoxCodigoDesc.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(32, 142);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 15;
            materialLabel3.Text = "Código:";
            // 
            // textBoxPorcentajeDesc
            // 
            textBoxPorcentajeDesc.AnimateReadOnly = false;
            textBoxPorcentajeDesc.BorderStyle = BorderStyle.None;
            textBoxPorcentajeDesc.Depth = 0;
            textBoxPorcentajeDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPorcentajeDesc.LeadingIcon = null;
            textBoxPorcentajeDesc.Location = new Point(149, 237);
            textBoxPorcentajeDesc.MaxLength = 50;
            textBoxPorcentajeDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPorcentajeDesc.Multiline = false;
            textBoxPorcentajeDesc.Name = "textBoxPorcentajeDesc";
            textBoxPorcentajeDesc.Size = new Size(122, 50);
            textBoxPorcentajeDesc.TabIndex = 11;
            textBoxPorcentajeDesc.Text = "";
            textBoxPorcentajeDesc.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(32, 254);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(80, 19);
            materialLabel2.TabIndex = 14;
            materialLabel2.Text = "Porcentaje:";
            // 
            // textBoxDescripcionDesc
            // 
            textBoxDescripcionDesc.AnimateReadOnly = false;
            textBoxDescripcionDesc.BorderStyle = BorderStyle.None;
            textBoxDescripcionDesc.Depth = 0;
            textBoxDescripcionDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcionDesc.LeadingIcon = null;
            textBoxDescripcionDesc.Location = new Point(149, 181);
            textBoxDescripcionDesc.MaxLength = 50;
            textBoxDescripcionDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcionDesc.Multiline = false;
            textBoxDescripcionDesc.Name = "textBoxDescripcionDesc";
            textBoxDescripcionDesc.Size = new Size(350, 50);
            textBoxDescripcionDesc.TabIndex = 10;
            textBoxDescripcionDesc.Text = "";
            textBoxDescripcionDesc.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(32, 198);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(88, 19);
            materialLabel1.TabIndex = 12;
            materialLabel1.Text = "Descripcion:";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(32, 316);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(111, 19);
            materialLabel4.TabIndex = 17;
            materialLabel4.Text = "Fecha de inicio:";
            // 
            // fechaIncioDesc
            // 
            fechaIncioDesc.CustomFormat = "dd/MM/yyyy";
            fechaIncioDesc.Font = new Font("Segoe UI", 10F);
            fechaIncioDesc.Format = DateTimePickerFormat.Custom;
            fechaIncioDesc.Location = new Point(149, 305);
            fechaIncioDesc.Name = "fechaIncioDesc";
            fechaIncioDesc.Size = new Size(167, 30);
            fechaIncioDesc.TabIndex = 23;
            // 
            // fechaFinalDesc
            // 
            fechaFinalDesc.CustomFormat = "dd/MM/yyyy";
            fechaFinalDesc.Font = new Font("Segoe UI", 10F);
            fechaFinalDesc.Format = DateTimePickerFormat.Custom;
            fechaFinalDesc.Location = new Point(6, 18);
            fechaFinalDesc.Name = "fechaFinalDesc";
            fechaFinalDesc.Size = new Size(181, 30);
            fechaFinalDesc.TabIndex = 24;
            fechaFinalDesc.ValueChanged += fechaFinalDesc_ValueChanged;
            // 
            // itbisCheckBox
            // 
            itbisCheckBox.AutoSize = true;
            itbisCheckBox.Depth = 0;
            itbisCheckBox.Location = new Point(402, 351);
            itbisCheckBox.Margin = new Padding(0);
            itbisCheckBox.MouseLocation = new Point(-1, -1);
            itbisCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            itbisCheckBox.Name = "itbisCheckBox";
            itbisCheckBox.ReadOnly = false;
            itbisCheckBox.Ripple = true;
            itbisCheckBox.Size = new Size(73, 37);
            itbisCheckBox.TabIndex = 25;
            itbisCheckBox.Text = "ITBIS";
            itbisCheckBox.UseVisualStyleBackColor = true;
            // 
            // activoCheckbox
            // 
            activoCheckbox.AutoSize = true;
            activoCheckbox.Checked = true;
            activoCheckbox.CheckState = CheckState.Checked;
            activoCheckbox.Depth = 0;
            activoCheckbox.Location = new Point(402, 408);
            activoCheckbox.Margin = new Padding(0);
            activoCheckbox.MouseLocation = new Point(-1, -1);
            activoCheckbox.MouseState = MaterialSkin.MouseState.HOVER;
            activoCheckbox.Name = "activoCheckbox";
            activoCheckbox.ReadOnly = false;
            activoCheckbox.Ripple = true;
            activoCheckbox.Size = new Size(79, 37);
            activoCheckbox.TabIndex = 26;
            activoCheckbox.Text = "Activo";
            activoCheckbox.UseVisualStyleBackColor = true;
            // 
            // checkBoxDefinirFechaFin
            // 
            checkBoxDefinirFechaFin.AutoSize = true;
            checkBoxDefinirFechaFin.Checked = true;
            checkBoxDefinirFechaFin.CheckState = CheckState.Checked;
            checkBoxDefinirFechaFin.Depth = 0;
            checkBoxDefinirFechaFin.Location = new Point(32, 351);
            checkBoxDefinirFechaFin.Margin = new Padding(0);
            checkBoxDefinirFechaFin.MouseLocation = new Point(-1, -1);
            checkBoxDefinirFechaFin.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxDefinirFechaFin.Name = "checkBoxDefinirFechaFin";
            checkBoxDefinirFechaFin.ReadOnly = false;
            checkBoxDefinirFechaFin.Ripple = true;
            checkBoxDefinirFechaFin.Size = new Size(216, 37);
            checkBoxDefinirFechaFin.TabIndex = 27;
            checkBoxDefinirFechaFin.Text = "Definir fecha vencimiento";
            checkBoxDefinirFechaFin.UseVisualStyleBackColor = true;
            checkBoxDefinirFechaFin.CheckedChanged += checkBoxDefinirFechaFin_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fechaFinalDesc);
            groupBox1.Location = new Point(32, 391);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 54);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            // 
            // materialLabel6
            // 
          
            // 
            // FDescuento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 482);
            Controls.Add(groupBox1);
            Controls.Add(checkBoxDefinirFechaFin);
            Controls.Add(activoCheckbox);
            Controls.Add(itbisCheckBox);
            Controls.Add(fechaIncioDesc);
            Controls.Add(materialLabel4);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxCodigoDesc);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxPorcentajeDesc);
            Controls.Add(materialLabel2);
            Controls.Add(textBoxDescripcionDesc);
            Controls.Add(materialLabel1);
            Name = "FDescuento";
            Text = "FDescuento";
            Load += FDescuento_Load;
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxDescripcionDesc, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(textBoxPorcentajeDesc, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigoDesc, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(materialLabel4, 0);
            Controls.SetChildIndex(fechaIncioDesc, 0);
            Controls.SetChildIndex(itbisCheckBox, 0);
            Controls.SetChildIndex(activoCheckbox, 0);
            Controls.SetChildIndex(checkBoxDefinirFechaFin, 0);
            Controls.SetChildIndex(groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox textBoxPorcentajeDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcionDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private DateTimePicker fechaIncioDesc;
        private DateTimePicker fechaFinalDesc;
        private MaterialSkin.Controls.MaterialCheckbox itbisCheckBox;
        private MaterialSkin.Controls.MaterialCheckbox activoCheckbox;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxDefinirFechaFin;
        private GroupBox groupBox1;
    }
}