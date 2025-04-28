namespace ProyectoIntegrador.Inventario
{
    partial class FArticuloServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FArticuloServicio));
            groupBoxServicio = new GroupBox();
            textBoxCodigoServicio = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescServicio = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarServicio = new Utilidades.Controles.BBuscar();
            groupBoxArticulo = new GroupBox();
            label1 = new Label();
            textBoxCantidad = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigoArticulo = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescArticulo = new MaterialSkin.Controls.MaterialTextBox();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            bBuscarArticulo = new Utilidades.Controles.BBuscar();
            dataGridView1 = new DataGridView();
            ColumnCodigo = new DataGridViewTextBoxColumn();
            ColumnDescripcion = new DataGridViewTextBoxColumn();
            ColumnCantidad = new DataGridViewTextBoxColumn();
            ColumnPrecio = new DataGridViewTextBoxColumn();
            ColumnActivo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBoxServicio.SuspendLayout();
            groupBoxArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(879, 5);
            // 
            // groupBoxServicio
            // 
            groupBoxServicio.Controls.Add(textBoxCodigoServicio);
            groupBoxServicio.Controls.Add(textBoxDescServicio);
            groupBoxServicio.Controls.Add(bBuscarServicio);
            groupBoxServicio.Location = new Point(12, 119);
            groupBoxServicio.Name = "groupBoxServicio";
            groupBoxServicio.Size = new Size(867, 89);
            groupBoxServicio.TabIndex = 28;
            groupBoxServicio.TabStop = false;
            groupBoxServicio.Text = "Servicio";
            // 
            // textBoxCodigoServicio
            // 
            textBoxCodigoServicio.AnimateReadOnly = false;
            textBoxCodigoServicio.BorderStyle = BorderStyle.None;
            textBoxCodigoServicio.Depth = 0;
            textBoxCodigoServicio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoServicio.LeadingIcon = null;
            textBoxCodigoServicio.Location = new Point(8, 28);
            textBoxCodigoServicio.MaxLength = 50;
            textBoxCodigoServicio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoServicio.Multiline = false;
            textBoxCodigoServicio.Name = "textBoxCodigoServicio";
            textBoxCodigoServicio.Size = new Size(92, 50);
            textBoxCodigoServicio.TabIndex = 28;
            textBoxCodigoServicio.Text = "";
            textBoxCodigoServicio.TrailingIcon = null;
            // 
            // textBoxDescServicio
            // 
            textBoxDescServicio.AnimateReadOnly = false;
            textBoxDescServicio.BorderStyle = BorderStyle.None;
            textBoxDescServicio.Depth = 0;
            textBoxDescServicio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescServicio.LeadingIcon = null;
            textBoxDescServicio.Location = new Point(151, 28);
            textBoxDescServicio.MaxLength = 50;
            textBoxDescServicio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescServicio.Multiline = false;
            textBoxDescServicio.Name = "textBoxDescServicio";
            textBoxDescServicio.Size = new Size(709, 50);
            textBoxDescServicio.TabIndex = 27;
            textBoxDescServicio.Text = "";
            textBoxDescServicio.TrailingIcon = null;
            // 
            // bBuscarServicio
            // 
            bBuscarServicio.Image = (Image)resources.GetObject("bBuscarServicio.Image");
            bBuscarServicio.Location = new Point(107, 36);
            bBuscarServicio.Name = "bBuscarServicio";
            bBuscarServicio.Size = new Size(37, 34);
            bBuscarServicio.TabIndex = 26;
            bBuscarServicio.UseVisualStyleBackColor = true;
            // 
            // groupBoxArticulo
            // 
            groupBoxArticulo.Controls.Add(label1);
            groupBoxArticulo.Controls.Add(textBoxCantidad);
            groupBoxArticulo.Controls.Add(textBoxCodigoArticulo);
            groupBoxArticulo.Controls.Add(textBoxDescArticulo);
            groupBoxArticulo.Controls.Add(buttonAgregar);
            groupBoxArticulo.Controls.Add(buttonEliminar);
            groupBoxArticulo.Controls.Add(bBuscarArticulo);
            groupBoxArticulo.Controls.Add(dataGridView1);
            groupBoxArticulo.Location = new Point(12, 206);
            groupBoxArticulo.Name = "groupBoxArticulo";
            groupBoxArticulo.Size = new Size(867, 323);
            groupBoxArticulo.TabIndex = 27;
            groupBoxArticulo.TabStop = false;
            groupBoxArticulo.Text = "Artículo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 76);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 27;
            label1.Text = "Cantidad:";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.AnimateReadOnly = false;
            textBoxCantidad.BorderStyle = BorderStyle.None;
            textBoxCantidad.Depth = 0;
            textBoxCantidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCantidad.LeadingIcon = null;
            textBoxCantidad.Location = new Point(8, 96);
            textBoxCantidad.MaxLength = 50;
            textBoxCantidad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCantidad.Multiline = false;
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(136, 50);
            textBoxCantidad.TabIndex = 26;
            textBoxCantidad.Text = "";
            textBoxCantidad.TrailingIcon = null;
            textBoxCantidad.KeyPress += TextBoxCantidad_KeyPress;
            // 
            // textBoxCodigoArticulo
            // 
            textBoxCodigoArticulo.AnimateReadOnly = false;
            textBoxCodigoArticulo.BorderStyle = BorderStyle.None;
            textBoxCodigoArticulo.Depth = 0;
            textBoxCodigoArticulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoArticulo.LeadingIcon = null;
            textBoxCodigoArticulo.Location = new Point(8, 23);
            textBoxCodigoArticulo.MaxLength = 50;
            textBoxCodigoArticulo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoArticulo.Multiline = false;
            textBoxCodigoArticulo.Name = "textBoxCodigoArticulo";
            textBoxCodigoArticulo.Size = new Size(92, 50);
            textBoxCodigoArticulo.TabIndex = 25;
            textBoxCodigoArticulo.Text = "";
            textBoxCodigoArticulo.TrailingIcon = null;
            // 
            // textBoxDescArticulo
            // 
            textBoxDescArticulo.AnimateReadOnly = false;
            textBoxDescArticulo.BorderStyle = BorderStyle.None;
            textBoxDescArticulo.Depth = 0;
            textBoxDescArticulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescArticulo.LeadingIcon = null;
            textBoxDescArticulo.Location = new Point(151, 23);
            textBoxDescArticulo.MaxLength = 50;
            textBoxDescArticulo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescArticulo.Multiline = false;
            textBoxDescArticulo.Name = "textBoxDescArticulo";
            textBoxDescArticulo.Size = new Size(463, 50);
            textBoxDescArticulo.TabIndex = 24;
            textBoxDescArticulo.Text = "";
            textBoxDescArticulo.TrailingIcon = null;
            // 
            // buttonAgregar
            // 
            buttonAgregar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregar.Depth = 0;
            buttonAgregar.HighEmphasis = true;
            buttonAgregar.Icon = Properties.Resources.material_add_24;
            buttonAgregar.Location = new Point(621, 93);
            buttonAgregar.Margin = new Padding(4, 6, 4, 6);
            buttonAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.NoAccentTextColor = Color.Empty;
            buttonAgregar.Size = new Size(116, 36);
            buttonAgregar.TabIndex = 22;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonAgregar.UseAccentColor = false;
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += ButtonAgregar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminar.Depth = 0;
            buttonEliminar.HighEmphasis = true;
            buttonEliminar.Icon = Properties.Resources.material_delete_24;
            buttonEliminar.Location = new Point(744, 93);
            buttonEliminar.Margin = new Padding(4, 6, 4, 6);
            buttonEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.NoAccentTextColor = Color.Empty;
            buttonEliminar.Size = new Size(116, 36);
            buttonEliminar.TabIndex = 23;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonEliminar.UseAccentColor = true;
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += ButtonEliminar_Click;
            // 
            // bBuscarArticulo
            // 
            bBuscarArticulo.Image = (Image)resources.GetObject("bBuscarArticulo.Image");
            bBuscarArticulo.Location = new Point(107, 31);
            bBuscarArticulo.Name = "bBuscarArticulo";
            bBuscarArticulo.Size = new Size(37, 34);
            bBuscarArticulo.TabIndex = 10;
            bBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigo, ColumnDescripcion, ColumnCantidad, ColumnPrecio, ColumnActivo });
            dataGridView1.Location = new Point(8, 149);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(852, 168);
            dataGridView1.TabIndex = 20;
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            // 
            // ColumnCodigo
            // 
            ColumnCodigo.FillWeight = 35F;
            ColumnCodigo.HeaderText = "Código";
            ColumnCodigo.MinimumWidth = 6;
            ColumnCodigo.Name = "ColumnCodigo";
            ColumnCodigo.ReadOnly = true;
            // 
            // ColumnDescripcion
            // 
            ColumnDescripcion.HeaderText = "Descripción";
            ColumnDescripcion.MinimumWidth = 6;
            ColumnDescripcion.Name = "ColumnDescripcion";
            ColumnDescripcion.ReadOnly = true;
            // 
            // ColumnCantidad
            // 
            ColumnCantidad.FillWeight = 40F;
            ColumnCantidad.HeaderText = "Cantidad";
            ColumnCantidad.MinimumWidth = 6;
            ColumnCantidad.Name = "ColumnCantidad";
            ColumnCantidad.ReadOnly = true;
            // 
            // ColumnPrecio
            // 
            ColumnPrecio.FillWeight = 50F;
            ColumnPrecio.HeaderText = "Precio/Unidad";
            ColumnPrecio.MinimumWidth = 6;
            ColumnPrecio.Name = "ColumnPrecio";
            ColumnPrecio.ReadOnly = true;
            // 
            // ColumnActivo
            // 
            ColumnActivo.FillWeight = 40F;
            ColumnActivo.HeaderText = "Estado";
            ColumnActivo.MinimumWidth = 6;
            ColumnActivo.Name = "ColumnActivo";
            ColumnActivo.ReadOnly = true;
            // 
            // FArticuloServicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 557);
            Controls.Add(groupBoxServicio);
            Controls.Add(groupBoxArticulo);
            Name = "FArticuloServicio";
            Text = "FArticuloServicio";
            Load += FArticuloServicio_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBoxArticulo, 0);
            Controls.SetChildIndex(groupBoxServicio, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBoxServicio.ResumeLayout(false);
            groupBoxArticulo.ResumeLayout(false);
            groupBoxArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxServicio;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoServicio;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescServicio;
        private Utilidades.Controles.BBuscar bBuscarServicio;
        private GroupBox groupBoxArticulo;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoArticulo;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescArticulo;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private Utilidades.Controles.BBuscar bBuscarArticulo;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnCodigo;
        private DataGridViewTextBoxColumn ColumnDescripcion;
        private DataGridViewTextBoxColumn ColumnCantidad;
        private DataGridViewTextBoxColumn ColumnPrecio;
        private DataGridViewTextBoxColumn ColumnActivo;
        private Label label1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCantidad;
    }
}