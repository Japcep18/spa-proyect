namespace ProyectoIntegrador.Inventario
{
    partial class FCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCompras));
            label1 = new Label();
            textBoxCodigoSuplidor = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarSuplidor = new Utilidades.Controles.BBuscar();
            textBoxDescSuplidor = new MaterialSkin.Controls.MaterialTextBox();
            groupBox1 = new GroupBox();
            labelTotal = new Label();
            label4 = new Label();
            groupBoxDetalle = new GroupBox();
            label3 = new Label();
            label2 = new Label();
            textBoxPrecio = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCantidad = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescArticulo = new MaterialSkin.Controls.MaterialTextBox();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            bBuscarArticulo = new Utilidades.Controles.BBuscar();
            dataGridView1 = new DataGridView();
            ColumnCodigo = new DataGridViewTextBoxColumn();
            ColumnDescripcion = new DataGridViewTextBoxColumn();
            ColumnCantidad = new DataGridViewTextBoxColumn();
            ColumnPrecio = new DataGridViewTextBoxColumn();
            ColumnImporte = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            groupBoxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(794, 5);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 11;
            label1.Text = "Suplidor:";
            // 
            // textBoxCodigoSuplidor
            // 
            textBoxCodigoSuplidor.AnimateReadOnly = false;
            textBoxCodigoSuplidor.BorderStyle = BorderStyle.None;
            textBoxCodigoSuplidor.Depth = 0;
            textBoxCodigoSuplidor.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoSuplidor.LeadingIcon = null;
            textBoxCodigoSuplidor.Location = new Point(99, 26);
            textBoxCodigoSuplidor.MaxLength = 50;
            textBoxCodigoSuplidor.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoSuplidor.Multiline = false;
            textBoxCodigoSuplidor.Name = "textBoxCodigoSuplidor";
            textBoxCodigoSuplidor.Size = new Size(108, 36);
            textBoxCodigoSuplidor.TabIndex = 12;
            textBoxCodigoSuplidor.Text = "";
            textBoxCodigoSuplidor.TrailingIcon = null;
            textBoxCodigoSuplidor.UseTallSize = false;
            // 
            // bBuscarSuplidor
            // 
            bBuscarSuplidor.Image = (Image)resources.GetObject("bBuscarSuplidor.Image");
            bBuscarSuplidor.Location = new Point(213, 23);
            bBuscarSuplidor.Name = "bBuscarSuplidor";
            bBuscarSuplidor.Size = new Size(42, 42);
            bBuscarSuplidor.TabIndex = 13;
            bBuscarSuplidor.UseVisualStyleBackColor = true;
            // 
            // textBoxDescSuplidor
            // 
            textBoxDescSuplidor.AnimateReadOnly = false;
            textBoxDescSuplidor.BorderStyle = BorderStyle.None;
            textBoxDescSuplidor.Depth = 0;
            textBoxDescSuplidor.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescSuplidor.LeadingIcon = null;
            textBoxDescSuplidor.Location = new Point(99, 68);
            textBoxDescSuplidor.MaxLength = 50;
            textBoxDescSuplidor.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescSuplidor.Multiline = false;
            textBoxDescSuplidor.Name = "textBoxDescSuplidor";
            textBoxDescSuplidor.Size = new Size(405, 36);
            textBoxDescSuplidor.TabIndex = 14;
            textBoxDescSuplidor.Text = "";
            textBoxDescSuplidor.TrailingIcon = null;
            textBoxDescSuplidor.UseTallSize = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelTotal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBoxCodigoSuplidor);
            groupBox1.Controls.Add(bBuscarSuplidor);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxDescSuplidor);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 116);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(794, 119);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos de la compra:";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.ForeColor = Color.Firebrick;
            labelTotal.Location = new Point(582, 23);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(59, 31);
            labelTotal.TabIndex = 16;
            labelTotal.Text = "0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(531, 28);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 15;
            label4.Text = "Total:";
            // 
            // groupBoxDetalle
            // 
            groupBoxDetalle.Controls.Add(label3);
            groupBoxDetalle.Controls.Add(label2);
            groupBoxDetalle.Controls.Add(textBoxPrecio);
            groupBoxDetalle.Controls.Add(textBoxCantidad);
            groupBoxDetalle.Controls.Add(textBoxDescArticulo);
            groupBoxDetalle.Controls.Add(buttonAgregar);
            groupBoxDetalle.Controls.Add(buttonEliminar);
            groupBoxDetalle.Controls.Add(bBuscarArticulo);
            groupBoxDetalle.Controls.Add(dataGridView1);
            groupBoxDetalle.Dock = DockStyle.Fill;
            groupBoxDetalle.Enabled = false;
            groupBoxDetalle.Location = new Point(3, 235);
            groupBoxDetalle.Name = "groupBoxDetalle";
            groupBoxDetalle.Size = new Size(794, 251);
            groupBoxDetalle.TabIndex = 16;
            groupBoxDetalle.TabStop = false;
            groupBoxDetalle.Text = "Detalle:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7F);
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(520, 13);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 33;
            label3.Text = "Precio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(407, 13);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 32;
            label2.Text = "Cantidad:";
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.AnimateReadOnly = false;
            textBoxPrecio.BorderStyle = BorderStyle.None;
            textBoxPrecio.Depth = 0;
            textBoxPrecio.Enabled = false;
            textBoxPrecio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPrecio.LeadingIcon = null;
            textBoxPrecio.Location = new Point(520, 31);
            textBoxPrecio.MaxLength = 50;
            textBoxPrecio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPrecio.Multiline = false;
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(107, 36);
            textBoxPrecio.TabIndex = 31;
            textBoxPrecio.Text = "";
            textBoxPrecio.TrailingIcon = null;
            textBoxPrecio.UseTallSize = false;
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.AnimateReadOnly = false;
            textBoxCantidad.BorderStyle = BorderStyle.None;
            textBoxCantidad.Depth = 0;
            textBoxCantidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCantidad.LeadingIcon = null;
            textBoxCantidad.Location = new Point(407, 31);
            textBoxCantidad.MaxLength = 50;
            textBoxCantidad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCantidad.Multiline = false;
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(110, 36);
            textBoxCantidad.TabIndex = 30;
            textBoxCantidad.Text = "";
            textBoxCantidad.TrailingIcon = null;
            textBoxCantidad.UseTallSize = false;
            // 
            // textBoxDescArticulo
            // 
            textBoxDescArticulo.AnimateReadOnly = false;
            textBoxDescArticulo.BorderStyle = BorderStyle.None;
            textBoxDescArticulo.Depth = 0;
            textBoxDescArticulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescArticulo.LeadingIcon = null;
            textBoxDescArticulo.Location = new Point(46, 31);
            textBoxDescArticulo.MaxLength = 50;
            textBoxDescArticulo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescArticulo.Multiline = false;
            textBoxDescArticulo.Name = "textBoxDescArticulo";
            textBoxDescArticulo.ReadOnly = true;
            textBoxDescArticulo.Size = new Size(358, 36);
            textBoxDescArticulo.TabIndex = 29;
            textBoxDescArticulo.Text = "";
            textBoxDescArticulo.TrailingIcon = null;
            textBoxDescArticulo.UseTallSize = false;
            // 
            // buttonAgregar
            // 
            buttonAgregar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregar.Depth = 0;
            buttonAgregar.HighEmphasis = true;
            buttonAgregar.Icon = Properties.Resources.material_add_24;
            buttonAgregar.Location = new Point(630, 31);
            buttonAgregar.Margin = new Padding(4, 6, 4, 6);
            buttonAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.NoAccentTextColor = Color.Empty;
            buttonAgregar.Size = new Size(116, 36);
            buttonAgregar.TabIndex = 27;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonAgregar.UseAccentColor = false;
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click_1;
            // 
            // buttonEliminar
            // 
            buttonEliminar.AutoSize = false;
            buttonEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminar.Depth = 0;
            buttonEliminar.HighEmphasis = false;
            buttonEliminar.Icon = Properties.Resources.material_delete_24;
            errorProvider.SetIconAlignment(buttonEliminar, ErrorIconAlignment.TopLeft);
            buttonEliminar.Location = new Point(749, 31);
            buttonEliminar.Margin = new Padding(4, 6, 4, 6);
            buttonEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.NoAccentTextColor = Color.Empty;
            buttonEliminar.Size = new Size(41, 36);
            buttonEliminar.TabIndex = 28;
            buttonEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonEliminar.UseAccentColor = true;
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click_1;
            // 
            // bBuscarArticulo
            // 
            bBuscarArticulo.Image = (Image)resources.GetObject("bBuscarArticulo.Image");
            bBuscarArticulo.Location = new Point(6, 32);
            bBuscarArticulo.Name = "bBuscarArticulo";
            bBuscarArticulo.Size = new Size(37, 34);
            bBuscarArticulo.TabIndex = 26;
            bBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigo, ColumnDescripcion, ColumnCantidad, ColumnPrecio, ColumnImporte });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(788, 175);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // ColumnCodigo
            // 
            ColumnCodigo.FillWeight = 70F;
            ColumnCodigo.HeaderText = "Código";
            ColumnCodigo.MinimumWidth = 6;
            ColumnCodigo.Name = "ColumnCodigo";
            ColumnCodigo.ReadOnly = true;
            // 
            // ColumnDescripcion
            // 
            ColumnDescripcion.FillWeight = 320F;
            ColumnDescripcion.HeaderText = "Descripción";
            ColumnDescripcion.MinimumWidth = 6;
            ColumnDescripcion.Name = "ColumnDescripcion";
            ColumnDescripcion.ReadOnly = true;
            // 
            // ColumnCantidad
            // 
            ColumnCantidad.HeaderText = "Cantidad";
            ColumnCantidad.MinimumWidth = 6;
            ColumnCantidad.Name = "ColumnCantidad";
            ColumnCantidad.ReadOnly = true;
            // 
            // ColumnPrecio
            // 
            ColumnPrecio.HeaderText = "Precio";
            ColumnPrecio.MinimumWidth = 6;
            ColumnPrecio.Name = "ColumnPrecio";
            ColumnPrecio.ReadOnly = true;
            // 
            // ColumnImporte
            // 
            ColumnImporte.HeaderText = "Importe";
            ColumnImporte.MinimumWidth = 6;
            ColumnImporte.Name = "ColumnImporte";
            ColumnImporte.ReadOnly = true;
            // 
            // FCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 511);
            Controls.Add(groupBoxDetalle);
            Controls.Add(groupBox1);
            Name = "FCompras";
            Text = "Compras";
            Load += FCompras_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(groupBoxDetalle, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxDetalle.ResumeLayout(false);
            groupBoxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoSuplidor;
        private Utilidades.Controles.BBuscar bBuscarSuplidor;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescSuplidor;
        private GroupBox groupBox1;
        private GroupBox groupBoxDetalle;
        private DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescArticulo;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private Utilidades.Controles.BBuscar bBuscarArticulo;
        private MaterialSkin.Controls.MaterialTextBox textBoxPrecio;
        private MaterialSkin.Controls.MaterialTextBox textBoxCantidad;
        private Label label3;
        private Label label2;
        private Label labelTotal;
        private Label label4;
        private DataGridViewTextBoxColumn ColumnCodigo;
        private DataGridViewTextBoxColumn ColumnDescripcion;
        private DataGridViewTextBoxColumn ColumnCantidad;
        private DataGridViewTextBoxColumn ColumnPrecio;
        private DataGridViewTextBoxColumn ColumnImporte;
    }
}