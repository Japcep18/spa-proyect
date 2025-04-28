namespace ProyectoIntegrador.Inventario
{
    partial class FTelefonoEntidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTelefonoEntidad));
            textBoxNombre = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            ColumnSecuencia = new DataGridViewTextBoxColumn();
            ColumnTelefono = new DataGridViewTextBoxColumn();
            ColumnEstado = new DataGridViewCheckBoxColumn();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(736, 5);
            // 
            // textBoxNombre
            // 
            textBoxNombre.AnimateReadOnly = false;
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Depth = 0;
            textBoxNombre.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNombre.LeadingIcon = null;
            textBoxNombre.Location = new Point(187, 26);
            textBoxNombre.MaxLength = 50;
            textBoxNombre.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombre.Multiline = false;
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(537, 50);
            textBoxNombre.TabIndex = 24;
            textBoxNombre.Text = "";
            textBoxNombre.TrailingIcon = null;
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(137, 26);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(44, 39);
            bBuscar1.TabIndex = 21;
            bBuscar1.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(6, 26);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(125, 50);
            textBoxCodigo.TabIndex = 20;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxCodigo);
            groupBox1.Controls.Add(bBuscar1);
            groupBox1.Controls.Add(textBoxNombre);
            groupBox1.Location = new Point(6, 122);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(724, 83);
            groupBox1.TabIndex = 25;
            groupBox1.TabStop = false;
            groupBox1.Text = "Entidad";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(buttonEliminar);
            groupBox2.Controls.Add(buttonAgregar);
            groupBox2.Location = new Point(9, 207);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(721, 234);
            groupBox2.TabIndex = 26;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lista de teléfono:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnSecuencia, ColumnTelefono, ColumnEstado });
            dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView1.Location = new Point(6, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(709, 167);
            dataGridView1.TabIndex = 25;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged_1;
            dataGridView1.RowEnter += dataGridView1_RowEnter_1;
            dataGridView1.RowLeave += dataGridView1_RowLeave_1;
            // 
            // ColumnSecuencia
            // 
            ColumnSecuencia.HeaderText = "#";
            ColumnSecuencia.MinimumWidth = 6;
            ColumnSecuencia.Name = "ColumnSecuencia";
            ColumnSecuencia.ReadOnly = true;
            // 
            // ColumnTelefono
            // 
            ColumnTelefono.FillWeight = 300F;
            ColumnTelefono.HeaderText = "Teléfono";
            ColumnTelefono.MaxInputLength = 512;
            ColumnTelefono.MinimumWidth = 6;
            ColumnTelefono.Name = "ColumnTelefono";
            // 
            // ColumnEstado
            // 
            ColumnEstado.HeaderText = "Estado";
            ColumnEstado.MinimumWidth = 6;
            ColumnEstado.Name = "ColumnEstado";
            // 
            // buttonEliminar
            // 
            buttonEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminar.Depth = 0;
            buttonEliminar.HighEmphasis = true;
            buttonEliminar.Icon = Properties.Resources.material_delete_24;
            buttonEliminar.Location = new Point(598, 16);
            buttonEliminar.Margin = new Padding(4, 6, 4, 6);
            buttonEliminar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.NoAccentTextColor = Color.Empty;
            buttonEliminar.Size = new Size(116, 36);
            buttonEliminar.TabIndex = 24;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonEliminar.UseAccentColor = true;
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click_1;
            // 
            // buttonAgregar
            // 
            buttonAgregar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregar.Depth = 0;
            buttonAgregar.HighEmphasis = true;
            buttonAgregar.Icon = Properties.Resources.material_add_24;
            buttonAgregar.Location = new Point(474, 16);
            buttonAgregar.Margin = new Padding(4, 6, 4, 6);
            buttonAgregar.MouseState = MaterialSkin.MouseState.HOVER;
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.NoAccentTextColor = Color.Empty;
            buttonAgregar.Size = new Size(116, 36);
            buttonAgregar.TabIndex = 23;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonAgregar.UseAccentColor = false;
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click_1;
            // 
            // FTelefonoEntidad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 469);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FTelefonoEntidad";
            Text = "FTelefonoEntidad";
            Load += FTelefonoEntidad_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox textBoxNombre;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnSecuencia;
        private DataGridViewTextBoxColumn ColumnTelefono;
        private DataGridViewCheckBoxColumn ColumnEstado;
    }
}