namespace ProyectoIntegrador.Inventario
{
    partial class FClienteMembresia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FClienteMembresia));
            groupBoxMembresia = new GroupBox();
            textBoxCodigoMembresia = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescMembresia = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarMembresia = new Utilidades.Controles.BBuscar();
            groupBoxCliente = new GroupBox();
            textBoxCodigoCliente = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescCliente = new MaterialSkin.Controls.MaterialTextBox();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            bBuscarCliente = new Utilidades.Controles.BBuscar();
            dataGridView1 = new DataGridView();
            ColumnCodigo = new DataGridViewTextBoxColumn();
            ColumnNombre = new DataGridViewTextBoxColumn();
            ColumnTipocliente = new DataGridViewTextBoxColumn();
            ColumnActivo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBoxMembresia.SuspendLayout();
            groupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(794, 5);
            // 
            // groupBoxMembresia
            // 
            groupBoxMembresia.Controls.Add(textBoxCodigoMembresia);
            groupBoxMembresia.Controls.Add(textBoxDescMembresia);
            groupBoxMembresia.Controls.Add(bBuscarMembresia);
            groupBoxMembresia.Location = new Point(3, 119);
            groupBoxMembresia.Name = "groupBoxMembresia";
            groupBoxMembresia.Size = new Size(782, 89);
            groupBoxMembresia.TabIndex = 28;
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
            // groupBoxCliente
            // 
            groupBoxCliente.Controls.Add(textBoxCodigoCliente);
            groupBoxCliente.Controls.Add(textBoxDescCliente);
            groupBoxCliente.Controls.Add(buttonAgregar);
            groupBoxCliente.Controls.Add(buttonEliminar);
            groupBoxCliente.Controls.Add(bBuscarCliente);
            groupBoxCliente.Controls.Add(dataGridView1);
            groupBoxCliente.Location = new Point(3, 206);
            groupBoxCliente.Name = "groupBoxCliente";
            groupBoxCliente.Size = new Size(782, 276);
            groupBoxCliente.TabIndex = 27;
            groupBoxCliente.TabStop = false;
            groupBoxCliente.Text = "Cliente:";
            // 
            // textBoxCodigoCliente
            // 
            textBoxCodigoCliente.AnimateReadOnly = false;
            textBoxCodigoCliente.BorderStyle = BorderStyle.None;
            textBoxCodigoCliente.Depth = 0;
            textBoxCodigoCliente.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoCliente.LeadingIcon = null;
            textBoxCodigoCliente.Location = new Point(8, 23);
            textBoxCodigoCliente.MaxLength = 50;
            textBoxCodigoCliente.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoCliente.Multiline = false;
            textBoxCodigoCliente.Name = "textBoxCodigoCliente";
            textBoxCodigoCliente.Size = new Size(92, 50);
            textBoxCodigoCliente.TabIndex = 25;
            textBoxCodigoCliente.Text = "";
            textBoxCodigoCliente.TrailingIcon = null;
            // 
            // textBoxDescCliente
            // 
            textBoxDescCliente.AnimateReadOnly = false;
            textBoxDescCliente.BorderStyle = BorderStyle.None;
            textBoxDescCliente.Depth = 0;
            textBoxDescCliente.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescCliente.LeadingIcon = null;
            textBoxDescCliente.Location = new Point(151, 23);
            textBoxDescCliente.MaxLength = 50;
            textBoxDescCliente.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescCliente.Multiline = false;
            textBoxDescCliente.Name = "textBoxDescCliente";
            textBoxDescCliente.Size = new Size(376, 50);
            textBoxDescCliente.TabIndex = 24;
            textBoxDescCliente.Text = "";
            textBoxDescCliente.TrailingIcon = null;
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
            // bBuscarCliente
            // 
            bBuscarCliente.Image = (Image)resources.GetObject("bBuscarCliente.Image");
            bBuscarCliente.Location = new Point(107, 31);
            bBuscarCliente.Name = "bBuscarCliente";
            bBuscarCliente.Size = new Size(37, 34);
            bBuscarCliente.TabIndex = 10;
            bBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigo, ColumnNombre, ColumnTipocliente, ColumnActivo });
            dataGridView1.Location = new Point(8, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(765, 179);
            dataGridView1.TabIndex = 20;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // ColumnCodigo
            // 
            ColumnCodigo.FillWeight = 50F;
            ColumnCodigo.HeaderText = "Código";
            ColumnCodigo.MinimumWidth = 6;
            ColumnCodigo.Name = "ColumnCodigo";
            ColumnCodigo.ReadOnly = true;
            // 
            // ColumnNombre
            // 
            ColumnNombre.HeaderText = "Nombre";
            ColumnNombre.MinimumWidth = 6;
            ColumnNombre.Name = "ColumnNombre";
            ColumnNombre.ReadOnly = true;
            // 
            // ColumnTipocliente
            // 
            ColumnTipocliente.HeaderText = "Tipo de cliente:";
            ColumnTipocliente.MaxInputLength = 512;
            ColumnTipocliente.MinimumWidth = 6;
            ColumnTipocliente.Name = "ColumnTipocliente";
            ColumnTipocliente.ReadOnly = true;
            // 
            // ColumnActivo
            // 
            ColumnActivo.FillWeight = 50F;
            ColumnActivo.HeaderText = "Activo";
            ColumnActivo.MinimumWidth = 6;
            ColumnActivo.Name = "ColumnActivo";
            ColumnActivo.ReadOnly = true;
            // 
            // FClienteMembresia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(groupBoxMembresia);
            Controls.Add(groupBoxCliente);
            Name = "FClienteMembresia";
            Text = "FClienteMembresia";
            Load += FClienteMembresia_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBoxCliente, 0);
            Controls.SetChildIndex(groupBoxMembresia, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBoxMembresia.ResumeLayout(false);
            groupBoxCliente.ResumeLayout(false);
            groupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxMembresia;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoMembresia;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescMembresia;
        private Utilidades.Controles.BBuscar bBuscarMembresia;
        private GroupBox groupBoxCliente;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoCliente;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescCliente;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private Utilidades.Controles.BBuscar bBuscarCliente;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnCodigo;
        private DataGridViewTextBoxColumn ColumnNombre;
        private DataGridViewTextBoxColumn ColumnTipocliente;
        private DataGridViewTextBoxColumn ColumnActivo;
    }
}