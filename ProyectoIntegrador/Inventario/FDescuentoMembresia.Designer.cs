namespace ProyectoIntegrador.Inventario
{
    partial class FDescuentoMembresia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDescuentoMembresia));
            bBuscarDescuento = new Utilidades.Controles.BBuscar();
            groupBoxDescuento = new GroupBox();
            textBoxCodigoDescuento = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescDescuento = new MaterialSkin.Controls.MaterialTextBox();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            dataGridView1 = new DataGridView();
            ColumnCodigo = new DataGridViewTextBoxColumn();
            ColumnDesc = new DataGridViewTextBoxColumn();
            ColumnPorcentaje = new DataGridViewTextBoxColumn();
            ColumnFechaFin = new DataGridViewTextBoxColumn();
            groupBoxMembresia = new GroupBox();
            textBoxCodigoMembresia = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescMembresia = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarMembresia = new Utilidades.Controles.BBuscar();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBoxDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBoxMembresia.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(794, 5);
            // 
            // bBuscarDescuento
            // 
            bBuscarDescuento.Image = (Image)resources.GetObject("bBuscarDescuento.Image");
            bBuscarDescuento.Location = new Point(107, 31);
            bBuscarDescuento.Name = "bBuscarDescuento";
            bBuscarDescuento.Size = new Size(37, 34);
            bBuscarDescuento.TabIndex = 10;
            bBuscarDescuento.UseVisualStyleBackColor = true;
            // 
            // groupBoxArticulo
            // 
            groupBoxDescuento.Controls.Add(textBoxCodigoDescuento);
            groupBoxDescuento.Controls.Add(textBoxDescDescuento);
            groupBoxDescuento.Controls.Add(buttonAgregar);
            groupBoxDescuento.Controls.Add(buttonEliminar);
            groupBoxDescuento.Controls.Add(bBuscarDescuento);
            groupBoxDescuento.Controls.Add(dataGridView1);
            groupBoxDescuento.Location = new Point(12, 213);
            groupBoxDescuento.Name = "groupBoxDescuento";
            groupBoxDescuento.Size = new Size(782, 276);
            groupBoxDescuento.TabIndex = 25;
            groupBoxDescuento.TabStop = false;
            groupBoxDescuento.Text = "Descuento:";
            // 
            // textBoxCodigoDescuento
            // 
            textBoxCodigoDescuento.AnimateReadOnly = false;
            textBoxCodigoDescuento.BorderStyle = BorderStyle.None;
            textBoxCodigoDescuento.Depth = 0;
            textBoxCodigoDescuento.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoDescuento.LeadingIcon = null;
            textBoxCodigoDescuento.Location = new Point(8, 23);
            textBoxCodigoDescuento.MaxLength = 50;
            textBoxCodigoDescuento.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoDescuento.Multiline = false;
            textBoxCodigoDescuento.Name = "textBoxCodigoDescuento";
            textBoxCodigoDescuento.Size = new Size(92, 50);
            textBoxCodigoDescuento.TabIndex = 25;
            textBoxCodigoDescuento.Text = "";
            textBoxCodigoDescuento.TrailingIcon = null;
            // 
            // textBoxDescDescuento
            // 
            textBoxDescDescuento.AnimateReadOnly = false;
            textBoxDescDescuento.BorderStyle = BorderStyle.None;
            textBoxDescDescuento.Depth = 0;
            textBoxDescDescuento.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescDescuento.LeadingIcon = null;
            textBoxDescDescuento.Location = new Point(151, 23);
            textBoxDescDescuento.MaxLength = 50;
            textBoxDescDescuento.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescDescuento.Multiline = false;
            textBoxDescDescuento.Name = "textBoxDescDescuento";
            textBoxDescDescuento.Size = new Size(376, 50);
            textBoxDescDescuento.TabIndex = 24;
            textBoxDescDescuento.Text = "";
            textBoxDescDescuento.TrailingIcon = null;
            // 
            // buttonAgregar
            // 
            buttonAgregar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregar.Depth = 0;
            buttonAgregar.HighEmphasis = true;
            buttonAgregar.Icon = Properties.Resources.material_add_24;
            buttonAgregar.Location = new Point(534, 30);
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
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminar.Depth = 0;
            buttonEliminar.HighEmphasis = true;
            buttonEliminar.Icon = Properties.Resources.material_delete_24;
            buttonEliminar.Location = new Point(657, 30);
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
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // dataGridViewServicio
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigo, ColumnDesc, ColumnPorcentaje, ColumnFechaFin });
            dataGridView1.Location = new Point(8, 79);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(765, 174);
            dataGridView1.TabIndex = 20;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // ColumnCodigo
            // 
            ColumnCodigo.HeaderText = "Código";
            ColumnCodigo.MinimumWidth = 6;
            ColumnCodigo.Name = "ColumnCodigo";
            ColumnCodigo.ReadOnly = true;
            // 
            // ColumnDesc
            // 
            ColumnDesc.FillWeight = 300F;
            ColumnDesc.HeaderText = "Descripción";
            ColumnDesc.MaxInputLength = 512;
            ColumnDesc.MinimumWidth = 6;
            ColumnDesc.Name = "ColumnDesc";
            ColumnDesc.ReadOnly = true;
            // 
            // ColumnPorcentaje
            // 
            ColumnPorcentaje.FillWeight = 80F;
            ColumnPorcentaje.HeaderText = "Porcentaje";
            ColumnPorcentaje.MinimumWidth = 6;
            ColumnPorcentaje.Name = "ColumnPorcentaje";
            ColumnPorcentaje.ReadOnly = true;
            // 
            // ColumnFechaFin
            // 
            ColumnFechaFin.FillWeight = 80F;
            ColumnFechaFin.HeaderText = "Fecha fin";
            ColumnFechaFin.MinimumWidth = 6;
            ColumnFechaFin.Name = "ColumnFechaFin";
            ColumnFechaFin.ReadOnly = true;
            // 
            // groupBoxServicio
            // 
            groupBoxMembresia.Controls.Add(textBoxCodigoMembresia);
            groupBoxMembresia.Controls.Add(textBoxDescMembresia);
            groupBoxMembresia.Controls.Add(bBuscarMembresia);
            groupBoxMembresia.Location = new Point(12, 126);
            groupBoxMembresia.Name = "groupBoxMembresia";
            groupBoxMembresia.Size = new Size(782, 89);
            groupBoxMembresia.TabIndex = 26;
            groupBoxMembresia.TabStop = false;
            groupBoxMembresia.Text = "Membresía";
            // 
            // textBoxCodigoMembresia
            // 
            textBoxCodigoMembresia.AnimateReadOnly = false;
            textBoxCodigoMembresia.BorderStyle = BorderStyle.None;
            textBoxCodigoMembresia.Depth = 0;
            textBoxCodigoMembresia.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoMembresia.LeadingIcon = null;
            textBoxCodigoMembresia.Location = new Point(8, 28);
            textBoxCodigoMembresia.MaxLength = 50;
            textBoxCodigoMembresia.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoMembresia.Multiline = false;
            textBoxCodigoMembresia.Name = "textBoxCodigoMembresia";
            textBoxCodigoMembresia.Size = new Size(92, 50);
            textBoxCodigoMembresia.TabIndex = 28;
            textBoxCodigoMembresia.Text = "";
            textBoxCodigoMembresia.TrailingIcon = null;
            // 
            // textBoxDescMembresia
            // 
            textBoxDescMembresia.AnimateReadOnly = false;
            textBoxDescMembresia.BorderStyle = BorderStyle.None;
            textBoxDescMembresia.Depth = 0;
            textBoxDescMembresia.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescMembresia.LeadingIcon = null;
            textBoxDescMembresia.Location = new Point(151, 28);
            textBoxDescMembresia.MaxLength = 50;
            textBoxDescMembresia.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescMembresia.Multiline = false;
            textBoxDescMembresia.Name = "textBoxDescMembresia";
            textBoxDescMembresia.Size = new Size(622, 50);
            textBoxDescMembresia.TabIndex = 27;
            textBoxDescMembresia.Text = "";
            textBoxDescMembresia.TrailingIcon = null;
            // 
            // bBuscarMembresia
            // 
            bBuscarMembresia.Image = (Image)resources.GetObject("bBuscarMembresia.Image");
            bBuscarMembresia.Location = new Point(107, 36);
            bBuscarMembresia.Name = "bBuscarMembresia";
            bBuscarMembresia.Size = new Size(37, 34);
            bBuscarMembresia.TabIndex = 26;
            bBuscarMembresia.UseVisualStyleBackColor = true;
            // 
            // FDescuentoMembresia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 521);
            Controls.Add(groupBoxMembresia);
            Controls.Add(groupBoxDescuento);
            Name = "FDescuentoMembresia";
            Text = "FDescuentoMembresia";
            Load += FDescuentoMembresia_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBoxDescuento, 0);
            Controls.SetChildIndex(groupBoxMembresia, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBoxDescuento.ResumeLayout(false);
            groupBoxDescuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBoxMembresia.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Utilidades.Controles.BBuscar bBuscarDescuento;
        private GroupBox groupBoxDescuento;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescDescuento;
        private GroupBox groupBoxMembresia;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoDescuento;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoMembresia;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescMembresia;
        private Utilidades.Controles.BBuscar bBuscarMembresia;
        private DataGridViewTextBoxColumn ColumnCodigo;
        private DataGridViewTextBoxColumn ColumnDesc;
        private DataGridViewTextBoxColumn ColumnPorcentaje;
        private DataGridViewTextBoxColumn ColumnFechaFin;
    }
}