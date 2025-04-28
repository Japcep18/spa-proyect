namespace ProyectoIntegrador.Inventario
{
    partial class FCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCliente));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            checkBoxActivo = new MaterialSkin.Controls.MaterialCheckbox();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            textBoxNombre = new MaterialSkin.Controls.MaterialTextBox();
            CBTipo = new MaterialSkin.Controls.MaterialComboBox();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(678, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(34, 153);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(59, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Entidad:";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(34, 230);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(41, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Tipo: ";
            // 
            // checkBoxActivo
            // 
            checkBoxActivo.AutoSize = true;
            checkBoxActivo.Checked = true;
            checkBoxActivo.CheckState = CheckState.Checked;
            checkBoxActivo.Depth = 0;
            checkBoxActivo.Location = new Point(34, 283);
            checkBoxActivo.Margin = new Padding(0);
            checkBoxActivo.MouseLocation = new Point(-1, -1);
            checkBoxActivo.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxActivo.Name = "checkBoxActivo";
            checkBoxActivo.ReadOnly = false;
            checkBoxActivo.Ripple = true;
            checkBoxActivo.Size = new Size(79, 37);
            checkBoxActivo.TabIndex = 5;
            checkBoxActivo.Text = "Activo";
            checkBoxActivo.UseVisualStyleBackColor = true;
            checkBoxActivo.CheckedChanged += checkBoxActivo_CheckedChanged;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(174, 142);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(125, 36);
            textBoxCodigo.TabIndex = 1;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            textBoxCodigo.UseTallSize = false;
            // 
            // textBoxNombre
            // 
            textBoxNombre.AnimateReadOnly = false;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Depth = 0;
            textBoxNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNombre.LeadingIcon = null;
            textBoxNombre.Location = new Point(174, 184);
            textBoxNombre.MaxLength = 50;
            textBoxNombre.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombre.Multiline = false;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.ReadOnly = true;
            textBoxNombre.Size = new Size(504, 36);
            textBoxNombre.TabIndex = 2;
            textBoxNombre.Text = "";
            textBoxNombre.TrailingIcon = null;
            textBoxNombre.UseTallSize = false;
            // 
            // CBTipo
            // 
            CBTipo.AutoResize = false;
            CBTipo.BackColor = Color.FromArgb(255, 255, 255);
            CBTipo.Depth = 0;
            CBTipo.DrawMode = DrawMode.OwnerDrawVariable;
            CBTipo.DropDownHeight = 118;
            CBTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            CBTipo.DropDownWidth = 121;
            CBTipo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            CBTipo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            CBTipo.FormattingEnabled = true;
            CBTipo.IntegralHeight = false;
            CBTipo.ItemHeight = 29;
            CBTipo.Location = new Point(174, 226);
            CBTipo.MaxDropDownItems = 4;
            CBTipo.MouseState = MaterialSkin.MouseState.OUT;
            CBTipo.Name = "CBTipo";
            CBTipo.Size = new Size(241, 35);
            CBTipo.StartIndex = 0;
            CBTipo.TabIndex = 3;
            CBTipo.UseTallSize = false;
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(302, 141);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 30;
            // 
            // FCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 360);
            Controls.Add(bBuscar1);
            Controls.Add(CBTipo);
            Controls.Add(textBoxNombre);
            Controls.Add(textBoxCodigo);
            Controls.Add(checkBoxActivo);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Name = "FCliente";
            Text = "FCliente";
            Load += FCliente_Load;
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(checkBoxActivo, 0);
            Controls.SetChildIndex(textBoxCodigo, 0);
            Controls.SetChildIndex(textBoxNombre, 0);
            Controls.SetChildIndex(CBTipo, 0);
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxActivo;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private MaterialSkin.Controls.MaterialTextBox textBoxNombre;
        private MaterialSkin.Controls.MaterialComboBox CBTipo;
        private Utilidades.Controles.BBuscar bBuscar1;
    }
}