namespace ProyectoIntegrador.Datos
{
    partial class FEmailEntidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEmailEntidad));
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigo = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescripcion = new MaterialSkin.Controls.MaterialTextBox();
            dataGridView1 = new DataGridView();
            ColumnSecuencia = new DataGridViewTextBoxColumn();
            ColumnEmail = new DataGridViewTextBoxColumn();
            ColumnEstado = new DataGridViewCheckBoxColumn();
            groupBox1 = new GroupBox();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(794, 5);
            // 
            // bBuscar1
            // 
            bBuscar1.AutoSize = true;
            bBuscar1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(135, 31);
            bBuscar1.Margin = new Padding(0);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(38, 38);
            bBuscar1.TabIndex = 18;
            // 
            // textBoxCodigo
            // 
            textBoxCodigo.AnimateReadOnly = false;
            textBoxCodigo.BorderStyle = BorderStyle.None;
            textBoxCodigo.Depth = 0;
            textBoxCodigo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigo.LeadingIcon = null;
            textBoxCodigo.Location = new Point(6, 25);
            textBoxCodigo.MaxLength = 50;
            textBoxCodigo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigo.Multiline = false;
            textBoxCodigo.Name = "textBoxCodigo";
            textBoxCodigo.Size = new Size(126, 50);
            textBoxCodigo.TabIndex = 19;
            textBoxCodigo.Text = "";
            textBoxCodigo.TrailingIcon = null;
            // 
            // textBoxDescripcion
            // 
            textBoxDescripcion.AnimateReadOnly = false;
            textBoxDescripcion.BorderStyle = BorderStyle.None;
            textBoxDescripcion.Depth = 0;
            textBoxDescripcion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescripcion.LeadingIcon = null;
            textBoxDescripcion.Location = new Point(176, 25);
            textBoxDescripcion.MaxLength = 50;
            textBoxDescripcion.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescripcion.Multiline = false;
            textBoxDescripcion.Name = "textBoxDescripcion";
            textBoxDescripcion.Size = new Size(552, 50);
            textBoxDescripcion.TabIndex = 17;
            textBoxDescripcion.Text = "";
            textBoxDescripcion.TrailingIcon = null;
            // 
            // dataGridViewServicio
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnSecuencia, ColumnEmail, ColumnEstado });
            dataGridView1.Location = new Point(6, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(722, 173);
            dataGridView1.TabIndex = 20;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.RowEnter += dataGridView1_RowEnter;
            dataGridView1.RowLeave += dataGridView1_RowLeave;
            // 
            // ColumnSecuencia
            // 
            ColumnSecuencia.HeaderText = "#";
            ColumnSecuencia.MinimumWidth = 6;
            ColumnSecuencia.Name = "ColumnSecuencia";
            ColumnSecuencia.ReadOnly = true;
            // 
            // ColumnEmail
            // 
            ColumnEmail.FillWeight = 300F;
            ColumnEmail.HeaderText = "Correo electrónico";
            ColumnEmail.MaxInputLength = 512;
            ColumnEmail.MinimumWidth = 6;
            ColumnEmail.Name = "ColumnEmail";
            // 
            // ColumnEstado
            // 
            ColumnEstado.HeaderText = "Estado";
            ColumnEstado.MinimumWidth = 6;
            ColumnEstado.Name = "ColumnEstado";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxCodigo);
            groupBox1.Controls.Add(textBoxDescripcion);
            groupBox1.Controls.Add(bBuscar1);
            groupBox1.Location = new Point(26, 132);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(747, 85);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Entidad";
            // 
            // buttonAgregar
            // 
            buttonAgregar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregar.Depth = 0;
            buttonAgregar.HighEmphasis = true;
            buttonAgregar.Icon = Properties.Resources.material_add_24;
            buttonAgregar.Location = new Point(488, 24);
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
            buttonEliminar.Location = new Point(612, 24);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(buttonAgregar);
            groupBox2.Controls.Add(buttonEliminar);
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(26, 223);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(747, 245);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lista de correo:";
            // 
            // FEmailEntidad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 496);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FEmailEntidad";
            Text = "Email";
            Load += FEmailEntidad_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigo;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescripcion;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnSecuencia;
        private DataGridViewTextBoxColumn ColumnEmail;
        private DataGridViewCheckBoxColumn ColumnEstado;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private GroupBox groupBox2;
    }
}