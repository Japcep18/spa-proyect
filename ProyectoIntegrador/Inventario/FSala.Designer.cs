namespace ProyectoIntegrador.Inventario
{
    partial class FSala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSala));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            textBoxNombre = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            CBTipoSala = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            CBEstadoSala = new MaterialSkin.Controls.MaterialComboBox();
            checkBoxPermiteReservar = new MaterialSkin.Controls.MaterialCheckbox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(565, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(34, 214);
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
            textBoxNombre.Location = new Point(158, 199);
            textBoxNombre.MaxLength = 50;
            textBoxNombre.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombre.Multiline = false;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(354, 50);
            textBoxNombre.TabIndex = 0;
            textBoxNombre.Text = "";
            textBoxNombre.TrailingIcon = null;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(158, 143);
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
            materialLabel3.Location = new Point(34, 158);
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
            bBuscar1.Location = new Point(287, 149);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 2;
            // 
            // CBTipoSala
            // 
            CBTipoSala.AutoResize = false;
            CBTipoSala.BackColor = Color.FromArgb(255, 255, 255);
            CBTipoSala.Depth = 0;
            CBTipoSala.DrawMode = DrawMode.OwnerDrawVariable;
            CBTipoSala.DropDownHeight = 174;
            CBTipoSala.DropDownStyle = ComboBoxStyle.DropDownList;
            CBTipoSala.DropDownWidth = 121;
            CBTipoSala.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            CBTipoSala.ForeColor = Color.FromArgb(222, 0, 0, 0);
            CBTipoSala.FormattingEnabled = true;
            CBTipoSala.IntegralHeight = false;
            CBTipoSala.ItemHeight = 43;
            CBTipoSala.Location = new Point(158, 255);
            CBTipoSala.MaxDropDownItems = 4;
            CBTipoSala.MouseState = MaterialSkin.MouseState.OUT;
            CBTipoSala.Name = "CBTipoSala";
            CBTipoSala.Size = new Size(354, 49);
            CBTipoSala.StartIndex = 0;
            CBTipoSala.TabIndex = 10;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(34, 272);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(92, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Tipo de sala:";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(34, 327);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(109, 19);
            materialLabel4.TabIndex = 13;
            materialLabel4.Text = "Estado de sala:";
            // 
            // CBEstadoSala
            // 
            CBEstadoSala.AutoResize = false;
            CBEstadoSala.BackColor = Color.FromArgb(255, 255, 255);
            CBEstadoSala.Depth = 0;
            CBEstadoSala.DrawMode = DrawMode.OwnerDrawVariable;
            CBEstadoSala.DropDownHeight = 174;
            CBEstadoSala.DropDownStyle = ComboBoxStyle.DropDownList;
            CBEstadoSala.DropDownWidth = 121;
            CBEstadoSala.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            CBEstadoSala.ForeColor = Color.FromArgb(222, 0, 0, 0);
            CBEstadoSala.FormattingEnabled = true;
            CBEstadoSala.IntegralHeight = false;
            CBEstadoSala.ItemHeight = 43;
            CBEstadoSala.Location = new Point(158, 310);
            CBEstadoSala.MaxDropDownItems = 4;
            CBEstadoSala.MouseState = MaterialSkin.MouseState.OUT;
            CBEstadoSala.Name = "CBEstadoSala";
            CBEstadoSala.Size = new Size(354, 49);
            CBEstadoSala.StartIndex = 0;
            CBEstadoSala.TabIndex = 12;
            // 
            // checkBoxPermiteReservar
            // 
            checkBoxPermiteReservar.AutoSize = true;
            checkBoxPermiteReservar.Depth = 0;
            checkBoxPermiteReservar.Location = new Point(34, 383);
            checkBoxPermiteReservar.Margin = new Padding(0);
            checkBoxPermiteReservar.MouseLocation = new Point(-1, -1);
            checkBoxPermiteReservar.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxPermiteReservar.Name = "checkBoxPermiteReservar";
            checkBoxPermiteReservar.ReadOnly = false;
            checkBoxPermiteReservar.Ripple = true;
            checkBoxPermiteReservar.Size = new Size(190, 37);
            checkBoxPermiteReservar.TabIndex = 14;
            checkBoxPermiteReservar.Text = "Permite reservaciones";
            checkBoxPermiteReservar.UseVisualStyleBackColor = true;
            // 
            // FSala
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 456);
            Controls.Add(checkBoxPermiteReservar);
            Controls.Add(materialLabel4);
            Controls.Add(CBEstadoSala);
            Controls.Add(materialLabel2);
            Controls.Add(CBTipoSala);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxCodigo);
            Controls.Add(materialLabel3);
            Controls.Add(textBoxNombre);
            Controls.Add(materialLabel1);
            Name = "FSala";
            Text = "Sala";
            Load += FServicios_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(textBoxNombre, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(textBoxCodigo, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(CBTipoSala, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(CBEstadoSala, 0);
            Controls.SetChildIndex(materialLabel4, 0);
            Controls.SetChildIndex(checkBoxPermiteReservar, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox textBoxNombre;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialComboBox CBTipoSala;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialComboBox CBEstadoSala;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxPermiteReservar;
    }
}