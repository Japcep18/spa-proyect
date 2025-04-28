namespace ProyectoIntegrador.RRHH
{
    partial class FEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEmpleado));
            checkBoxActivo = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            CBPuesto = new MaterialSkin.Controls.MaterialComboBox();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            textBoxSueldo = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtBoxNombre = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(614, 5);
            // 
            // checkBoxPermiteReservar
            // 
            checkBoxActivo.AutoSize = true;
            checkBoxActivo.Depth = 0;
            checkBoxActivo.Location = new Point(29, 368);
            checkBoxActivo.Margin = new Padding(0);
            checkBoxActivo.MouseLocation = new Point(-1, -1);
            checkBoxActivo.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxActivo.Name = "checkBoxPermiteReservar";
            checkBoxActivo.ReadOnly = false;
            checkBoxActivo.Ripple = true;
            checkBoxActivo.Size = new Size(79, 37);
            checkBoxActivo.TabIndex = 24;
            checkBoxActivo.Text = "Activo";
            checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(29, 319);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(54, 19);
            materialLabel2.TabIndex = 21;
            materialLabel2.Text = "Puesto:";
            // 
            // CBPuesto
            // 
            CBPuesto.AutoResize = false;
            CBPuesto.BackColor = Color.FromArgb(255, 255, 255);
            CBPuesto.Depth = 0;
            CBPuesto.DrawMode = DrawMode.OwnerDrawVariable;
            CBPuesto.DropDownHeight = 174;
            CBPuesto.DropDownStyle = ComboBoxStyle.DropDownList;
            CBPuesto.DropDownWidth = 121;
            CBPuesto.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            CBPuesto.ForeColor = Color.FromArgb(222, 0, 0, 0);
            CBPuesto.FormattingEnabled = true;
            CBPuesto.IntegralHeight = false;
            CBPuesto.ItemHeight = 43;
            CBPuesto.Location = new Point(162, 299);
            CBPuesto.MaxDropDownItems = 4;
            CBPuesto.MouseState = MaterialSkin.MouseState.OUT;
            CBPuesto.Name = "CBPuesto";
            CBPuesto.Size = new Size(283, 49);
            CBPuesto.StartIndex = 0;
            CBPuesto.TabIndex = 20;
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(269, 135);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 17;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(162, 129);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(104, 50);
            textBoxCodigo.TabIndex = 19;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(29, 147);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(55, 19);
            materialLabel3.TabIndex = 18;
            materialLabel3.Text = "Código:";
            // 
            // textBoxSueldo
            // 
            textBoxSueldo.AnimateReadOnly = false;
            textBoxSueldo.BorderStyle = BorderStyle.None;
            textBoxSueldo.Depth = 0;
            textBoxSueldo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxSueldo.LeadingIcon = null;
            textBoxSueldo.Location = new Point(162, 243);
            textBoxSueldo.MaxLength = 50;
            textBoxSueldo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxSueldo.Multiline = false;
            textBoxSueldo.Name = "textBoxSueldo";
            textBoxSueldo.Size = new Size(283, 50);
            textBoxSueldo.TabIndex = 15;
            textBoxSueldo.Text = "";
            textBoxSueldo.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(29, 261);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(125, 19);
            materialLabel1.TabIndex = 16;
            materialLabel1.Text = "Sueldo agregado:";
            // 
            // txtBoxNombre
            // 
            txtBoxNombre.AnimateReadOnly = false;
            txtBoxNombre.BackColor = SystemColors.Info;
            txtBoxNombre.BorderStyle = BorderStyle.None;
            txtBoxNombre.Depth = 0;
            txtBoxNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBoxNombre.LeadingIcon = null;
            txtBoxNombre.Location = new Point(162, 185);
            txtBoxNombre.MaxLength = 50;
            txtBoxNombre.MouseState = MaterialSkin.MouseState.OUT;
            txtBoxNombre.Multiline = false;
            txtBoxNombre.Name = "txtBoxNombre";
            txtBoxNombre.ReadOnly = true;
            txtBoxNombre.Size = new Size(423, 50);
            txtBoxNombre.TabIndex = 25;
            txtBoxNombre.Text = "";
            txtBoxNombre.TrailingIcon = null;
            // 
            // FEmpleado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 450);
            Controls.Add(txtBoxNombre);
            Controls.Add(checkBoxActivo);
            Controls.Add(materialLabel2);
            Controls.Add(CBPuesto);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxCodigo);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxSueldo);
            Controls.Add(materialLabel1);
            Name = "FEmpleado";
            Text = "Empleado";
            Load += FEmpleado_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxSueldo, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigo, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(CBPuesto, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(checkBoxActivo, 0);
            Controls.SetChildIndex(txtBoxNombre, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialCheckbox checkBoxActivo;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox CBPuesto;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox textBoxSueldo;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox txtBoxNombre;
    }
}