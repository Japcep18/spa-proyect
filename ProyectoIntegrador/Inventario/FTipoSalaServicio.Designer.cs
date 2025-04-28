namespace ProyectoIntegrador.Inventario
{
    partial class FTipoSalaServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTipoSalaServicio));
            groupBoxServicio = new GroupBox();
            textBoxCodigoServicio = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescServicio = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarServicio = new Utilidades.Controles.BBuscar();
            groupBoxTiposala = new GroupBox();
            textBoxCodigoTiposala = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescTiposala = new MaterialSkin.Controls.MaterialTextBox();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            bBuscarTiposala = new Utilidades.Controles.BBuscar();
            dataGridView1 = new DataGridView();
            ColumnCodigo = new DataGridViewTextBoxColumn();
            ColumnDesc = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBoxServicio.SuspendLayout();
            groupBoxTiposala.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(794, 5);
            // 
            // groupBoxServicio
            // 
            groupBoxServicio.Controls.Add(textBoxCodigoServicio);
            groupBoxServicio.Controls.Add(textBoxDescServicio);
            groupBoxServicio.Controls.Add(bBuscarServicio);
            groupBoxServicio.Location = new Point(12, 119);
            groupBoxServicio.Name = "groupBoxServicio";
            groupBoxServicio.Size = new Size(782, 89);
            groupBoxServicio.TabIndex = 28;
            groupBoxServicio.TabStop = false;
            groupBoxServicio.Text = "Servicio:";
            groupBoxServicio.Enter += groupBoxMembresia_Enter;
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
            textBoxDescServicio.Size = new Size(622, 50);
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
            // groupBoxTiposala
            // 
            groupBoxTiposala.Controls.Add(textBoxCodigoTiposala);
            groupBoxTiposala.Controls.Add(textBoxDescTiposala);
            groupBoxTiposala.Controls.Add(buttonAgregar);
            groupBoxTiposala.Controls.Add(buttonEliminar);
            groupBoxTiposala.Controls.Add(bBuscarTiposala);
            groupBoxTiposala.Controls.Add(dataGridView1);
            groupBoxTiposala.Location = new Point(12, 206);
            groupBoxTiposala.Name = "groupBoxTiposala";
            groupBoxTiposala.Size = new Size(782, 284);
            groupBoxTiposala.TabIndex = 27;
            groupBoxTiposala.TabStop = false;
            groupBoxTiposala.Text = "Tipo de sala:";
            // 
            // textBoxCodigoTiposala
            // 
            textBoxCodigoTiposala.AnimateReadOnly = false;
            textBoxCodigoTiposala.BorderStyle = BorderStyle.None;
            textBoxCodigoTiposala.Depth = 0;
            textBoxCodigoTiposala.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoTiposala.LeadingIcon = null;
            textBoxCodigoTiposala.Location = new Point(8, 23);
            textBoxCodigoTiposala.MaxLength = 50;
            textBoxCodigoTiposala.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoTiposala.Multiline = false;
            textBoxCodigoTiposala.Name = "textBoxCodigoTiposala";
            textBoxCodigoTiposala.Size = new Size(92, 50);
            textBoxCodigoTiposala.TabIndex = 25;
            textBoxCodigoTiposala.Text = "";
            textBoxCodigoTiposala.TrailingIcon = null;
            // 
            // textBoxDescTiposala
            // 
            textBoxDescTiposala.AnimateReadOnly = false;
            textBoxDescTiposala.BorderStyle = BorderStyle.None;
            textBoxDescTiposala.Depth = 0;
            textBoxDescTiposala.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescTiposala.LeadingIcon = null;
            textBoxDescTiposala.Location = new Point(151, 23);
            textBoxDescTiposala.MaxLength = 50;
            textBoxDescTiposala.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescTiposala.Multiline = false;
            textBoxDescTiposala.Name = "textBoxDescTiposala";
            textBoxDescTiposala.Size = new Size(376, 50);
            textBoxDescTiposala.TabIndex = 24;
            textBoxDescTiposala.Text = "";
            textBoxDescTiposala.TrailingIcon = null;
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
            // bBuscarTiposala
            // 
            bBuscarTiposala.Image = (Image)resources.GetObject("bBuscarTiposala.Image");
            bBuscarTiposala.Location = new Point(107, 31);
            bBuscarTiposala.Name = "bBuscarTiposala";
            bBuscarTiposala.Size = new Size(37, 34);
            bBuscarTiposala.TabIndex = 10;
            bBuscarTiposala.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigo, ColumnDesc });
            dataGridView1.Location = new Point(8, 79);
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
            // FTipoSalaServicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 494);
            Controls.Add(groupBoxServicio);
            Controls.Add(groupBoxTiposala);
            Name = "FTipoSalaServicio";
            Text = "FTipoSalaServicio";
            Load += FTipoSalaServicio_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBoxTiposala, 0);
            Controls.SetChildIndex(groupBoxServicio, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBoxServicio.ResumeLayout(false);
            groupBoxTiposala.ResumeLayout(false);
            groupBoxTiposala.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxServicio;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoServicio;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescServicio;
        private Utilidades.Controles.BBuscar bBuscarServicio;
        private GroupBox groupBoxTiposala;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoTiposala;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescTiposala;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private Utilidades.Controles.BBuscar bBuscarTiposala;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnCodigo;
        private DataGridViewTextBoxColumn ColumnDesc;
    }
}