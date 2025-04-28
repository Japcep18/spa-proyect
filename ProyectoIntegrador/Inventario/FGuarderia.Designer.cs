namespace ProyectoIntegrador.Inventario
{
    partial class FGuarderia
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
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            ColumnSecuencia = new DataGridViewTextBoxColumn();
            ColumnTutor = new DataGridViewTextBoxColumn();
            ColumnInfante = new DataGridViewTextBoxColumn();
            buttonEliminar = new MaterialSkin.Controls.MaterialButton();
            buttonAgregar = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(733, 5);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Controls.Add(buttonEliminar);
            groupBox2.Controls.Add(buttonAgregar);
            groupBox2.Location = new Point(12, 114);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(721, 313);
            groupBox2.TabIndex = 27;
            groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnSecuencia, ColumnTutor, ColumnInfante });
            dataGridView1.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView1.Location = new Point(6, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(709, 167);
            dataGridView1.TabIndex = 25;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // ColumnSecuencia
            // 
            ColumnSecuencia.HeaderText = "#";
            ColumnSecuencia.MinimumWidth = 6;
            ColumnSecuencia.Name = "ColumnSecuencia";
            ColumnSecuencia.ReadOnly = true;
            // 
            // ColumnTutor
            // 
            ColumnTutor.FillWeight = 250F;
            ColumnTutor.HeaderText = "Tutor";
            ColumnTutor.MaxInputLength = 512;
            ColumnTutor.MinimumWidth = 6;
            ColumnTutor.Name = "ColumnTutor";
            // 
            // ColumnInfante
            // 
            ColumnInfante.FillWeight = 250F;
            ColumnInfante.HeaderText = "Infante";
            ColumnInfante.MinimumWidth = 6;
            ColumnInfante.Name = "ColumnInfante";
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
            buttonEliminar.Click += buttonEliminar_Click;
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
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // FGuarderia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 356);
            Controls.Add(groupBox2);
            Name = "FGuarderia";
            Text = "FGuarderia";
            Load += FGuarderia_Load;
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnSecuencia;
        private DataGridViewTextBoxColumn ColumnTelefono;
        private DataGridViewCheckBoxColumn ColumnEstado;
        private MaterialSkin.Controls.MaterialButton buttonEliminar;
        private MaterialSkin.Controls.MaterialButton buttonAgregar;
        private DataGridViewTextBoxColumn ColumnTutor;
        private DataGridViewTextBoxColumn ColumnInfante;
    }
}