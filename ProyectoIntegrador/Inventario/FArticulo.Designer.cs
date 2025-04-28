namespace ProyectoIntegrador.Inventario
{
    partial class FArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FArticulo));
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDesc = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            label1 = new Label();
            label2 = new Label();
            comboBoxUnidad = new MaterialSkin.Controls.MaterialComboBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            checkBoxEstado = new MaterialSkin.Controls.MaterialCheckbox();
            checkBoxAfectaInv = new MaterialSkin.Controls.MaterialCheckbox();
            label4 = new Label();
            label6 = new Label();
            comboBoxITBIS = new MaterialSkin.Controls.MaterialComboBox();
            textBoxPrecio = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(664, 5);
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(161, 139);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(101, 50);
            textBoxCodigo.TabIndex = 10;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            // 
            // textBoxDesc
            // 
            textBoxDesc.AnimateReadOnly = false;
            textBoxDesc.BorderStyle = BorderStyle.None;
            textBoxDesc.Depth = 0;
            textBoxDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDesc.LeadingIcon = null;
            textBoxDesc.Location = new Point(161, 197);
            textBoxDesc.MaxLength = 50;
            textBoxDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDesc.Multiline = false;
            textBoxDesc.Name = "textBoxDesc";
            textBoxDesc.Size = new Size(485, 50);
            textBoxDesc.TabIndex = 0;
            textBoxDesc.Text = "";
            textBoxDesc.TrailingIcon = null;
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(264, 139);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(52, 48);
            bBuscar1.TabIndex = 12;
            bBuscar1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(35, 155);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 13;
            label1.Text = "Código:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(35, 212);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 14;
            label2.Text = "Descripción:";
            // 
            // comboBoxUnidad
            // 
            comboBoxUnidad.AutoResize = false;
            comboBoxUnidad.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxUnidad.Depth = 0;
            comboBoxUnidad.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxUnidad.DropDownHeight = 174;
            comboBoxUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUnidad.DropDownWidth = 121;
            comboBoxUnidad.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxUnidad.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxUnidad.FormattingEnabled = true;
            comboBoxUnidad.IntegralHeight = false;
            comboBoxUnidad.ItemHeight = 43;
            comboBoxUnidad.Location = new Point(161, 255);
            comboBoxUnidad.MaxDropDownItems = 4;
            comboBoxUnidad.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxUnidad.Name = "comboBoxUnidad";
            comboBoxUnidad.Size = new Size(243, 49);
            comboBoxUnidad.StartIndex = 0;
            comboBoxUnidad.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(35, 269);
            label3.Name = "label3";
            label3.Size = new Size(77, 25);
            label3.TabIndex = 16;
            label3.Text = "Unidad:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxEstado);
            groupBox1.Controls.Add(checkBoxAfectaInv);
            groupBox1.Location = new Point(35, 491);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(301, 72);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // checkBoxEstado
            // 
            checkBoxEstado.AutoSize = true;
            checkBoxEstado.Depth = 0;
            checkBoxEstado.Location = new Point(188, 23);
            checkBoxEstado.Margin = new Padding(0);
            checkBoxEstado.MouseLocation = new Point(-1, -1);
            checkBoxEstado.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxEstado.Name = "checkBoxEstado";
            checkBoxEstado.ReadOnly = false;
            checkBoxEstado.Ripple = true;
            checkBoxEstado.Size = new Size(79, 37);
            checkBoxEstado.TabIndex = 1;
            checkBoxEstado.Text = "Activo";
            checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // checkBoxAfectaInv
            // 
            checkBoxAfectaInv.AutoSize = true;
            checkBoxAfectaInv.Depth = 0;
            checkBoxAfectaInv.Location = new Point(12, 23);
            checkBoxAfectaInv.Margin = new Padding(0);
            checkBoxAfectaInv.MouseLocation = new Point(-1, -1);
            checkBoxAfectaInv.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxAfectaInv.Name = "checkBoxAfectaInv";
            checkBoxAfectaInv.ReadOnly = false;
            checkBoxAfectaInv.Ripple = true;
            checkBoxAfectaInv.Size = new Size(155, 37);
            checkBoxAfectaInv.TabIndex = 0;
            checkBoxAfectaInv.Text = "Afecta inventario";
            checkBoxAfectaInv.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(35, 326);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 19;
            label4.Text = "Precio:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(35, 383);
            label6.Name = "label6";
            label6.Size = new Size(57, 25);
            label6.TabIndex = 21;
            label6.Text = "ITBIS:";
            label6.Click += label6_Click;
            // 
            // comboBoxITBIS
            // 
            comboBoxITBIS.AutoResize = false;
            comboBoxITBIS.BackColor = Color.FromArgb(255, 255, 255);
            comboBoxITBIS.Depth = 0;
            comboBoxITBIS.DrawMode = DrawMode.OwnerDrawVariable;
            comboBoxITBIS.DropDownHeight = 174;
            comboBoxITBIS.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxITBIS.DropDownWidth = 121;
            comboBoxITBIS.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            comboBoxITBIS.ForeColor = Color.FromArgb(222, 0, 0, 0);
            comboBoxITBIS.FormattingEnabled = true;
            comboBoxITBIS.IntegralHeight = false;
            comboBoxITBIS.ItemHeight = 43;
            comboBoxITBIS.Location = new Point(161, 368);
            comboBoxITBIS.MaxDropDownItems = 4;
            comboBoxITBIS.MouseState = MaterialSkin.MouseState.OUT;
            comboBoxITBIS.Name = "comboBoxITBIS";
            comboBoxITBIS.Size = new Size(243, 49);
            comboBoxITBIS.StartIndex = 0;
            comboBoxITBIS.TabIndex = 3;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.AnimateReadOnly = false;
            textBoxPrecio.BorderStyle = BorderStyle.None;
            textBoxPrecio.Depth = 0;
            textBoxPrecio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPrecio.LeadingIcon = null;
            textBoxPrecio.Location = new Point(161, 312);
            textBoxPrecio.MaxLength = 50;
            textBoxPrecio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPrecio.Multiline = false;
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(184, 50);
            textBoxPrecio.TabIndex = 2;
            textBoxPrecio.Text = "";
            textBoxPrecio.TrailingIcon = null;
            // 
            // FArticulo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 591);
            Controls.Add(textBoxPrecio);
            Controls.Add(comboBoxITBIS);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(comboBoxUnidad);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bBuscar1);
            Controls.Add(textBoxDesc);
            Controls.Add(textBoxCodigo);
            Name = "FArticulo";
            Text = "Artículo";
            Load += Artículo_Load;
            Controls.SetChildIndex(textBoxCodigo, 0);
            Controls.SetChildIndex(textBoxDesc, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(comboBoxUnidad, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(comboBoxITBIS, 0);
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(textBoxPrecio, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private MaterialSkin.Controls.MaterialTextBox textBoxDesc;
        private Utilidades.Controles.BBuscar bBuscar1;
        private Label label1;
        private Label label2;
        private MaterialSkin.Controls.MaterialComboBox comboBoxUnidad;
        private Label label3;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxEstado;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxAfectaInv;
        private Label label4;
        private Label label6;
        private MaterialSkin.Controls.MaterialComboBox comboBoxITBIS;
        private MaterialSkin.Controls.MaterialTextBox textBoxPrecio;
    }
}