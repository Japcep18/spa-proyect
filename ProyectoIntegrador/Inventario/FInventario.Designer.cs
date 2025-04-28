namespace ProyectoIntegrador.Inventario
{
    partial class FInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInventario));
            labelTotal = new Label();
            label1 = new Label();
            label3 = new Label();
            buttonEliminarArticulo = new MaterialSkin.Controls.MaterialButton();
            buttonAgregarArticulo = new MaterialSkin.Controls.MaterialButton();
            textBoxPrecioUnitario = new MaterialSkin.Controls.MaterialTextBox();
            label2 = new Label();
            textBoxCantidad = new MaterialSkin.Controls.MaterialTextBox();
            radioButtonEntrada = new MaterialSkin.Controls.MaterialRadioButton();
            radioButtonSalida = new MaterialSkin.Controls.MaterialRadioButton();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            textBoxDescArticulo = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarArticulo = new Utilidades.Controles.BBuscar();
            textBoxCodigoArticulo = new MaterialSkin.Controls.MaterialTextBox();
            dataGridViewArticulo = new DataGridView();
            ColumnCodigoArticulo = new DataGridViewTextBoxColumn();
            ColumnDescArticulo = new DataGridViewTextBoxColumn();
            ColumnCantidadArticulo = new DataGridViewTextBoxColumn();
            ColumnPrecioUnitario = new DataGridViewTextBoxColumn();
            ColumnImporteArt = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulo).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(1228, 5);
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.ForeColor = Color.Firebrick;
            labelTotal.Location = new Point(398, 443);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(76, 41);
            labelTotal.TabIndex = 19;
            labelTotal.Text = "0.00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(302, 448);
            label1.Name = "label1";
            label1.Size = new Size(70, 32);
            label1.TabIndex = 18;
            label1.Text = "Total:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(246, 157);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 44;
            label3.Text = "Precio Unitario:";
            // 
            // buttonEliminarArticulo
            // 
            buttonEliminarArticulo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminarArticulo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminarArticulo.Depth = 0;
            buttonEliminarArticulo.HighEmphasis = true;
            buttonEliminarArticulo.Icon = Properties.Resources.material_delete_24;
            buttonEliminarArticulo.Location = new Point(394, 204);
            buttonEliminarArticulo.Margin = new Padding(4, 6, 4, 6);
            buttonEliminarArticulo.MouseState = MaterialSkin.MouseState.HOVER;
            buttonEliminarArticulo.Name = "buttonEliminarArticulo";
            buttonEliminarArticulo.NoAccentTextColor = Color.Empty;
            buttonEliminarArticulo.Size = new Size(116, 36);
            buttonEliminarArticulo.TabIndex = 43;
            buttonEliminarArticulo.Text = "Eliminar";
            buttonEliminarArticulo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonEliminarArticulo.UseAccentColor = true;
            buttonEliminarArticulo.UseVisualStyleBackColor = true;
            // 
            // buttonAgregarArticulo
            // 
            buttonAgregarArticulo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregarArticulo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregarArticulo.Depth = 0;
            buttonAgregarArticulo.HighEmphasis = true;
            buttonAgregarArticulo.Icon = Properties.Resources.material_add_24;
            buttonAgregarArticulo.Location = new Point(270, 204);
            buttonAgregarArticulo.Margin = new Padding(4, 6, 4, 6);
            buttonAgregarArticulo.MouseState = MaterialSkin.MouseState.HOVER;
            buttonAgregarArticulo.Name = "buttonAgregarArticulo";
            buttonAgregarArticulo.NoAccentTextColor = Color.Empty;
            buttonAgregarArticulo.Size = new Size(116, 36);
            buttonAgregarArticulo.TabIndex = 42;
            buttonAgregarArticulo.Text = "Agregar";
            buttonAgregarArticulo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonAgregarArticulo.UseAccentColor = false;
            buttonAgregarArticulo.UseVisualStyleBackColor = true;
            buttonAgregarArticulo.Click += buttonAgregarArticulo_Click;
            // 
            // textBoxPrecioUnitario
            // 
            textBoxPrecioUnitario.AnimateReadOnly = false;
            textBoxPrecioUnitario.BorderStyle = BorderStyle.None;
            textBoxPrecioUnitario.Depth = 0;
            textBoxPrecioUnitario.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxPrecioUnitario.LeadingIcon = null;
            textBoxPrecioUnitario.Location = new Point(362, 141);
            textBoxPrecioUnitario.MaxLength = 50;
            textBoxPrecioUnitario.MouseState = MaterialSkin.MouseState.OUT;
            textBoxPrecioUnitario.Multiline = false;
            textBoxPrecioUnitario.Name = "textBoxPrecioUnitario";
            textBoxPrecioUnitario.Size = new Size(149, 50);
            textBoxPrecioUnitario.TabIndex = 41;
            textBoxPrecioUnitario.Text = "";
            textBoxPrecioUnitario.TrailingIcon = null;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 157);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 39;
            label2.Text = "Cantidad:";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.AnimateReadOnly = false;
            textBoxCantidad.BorderStyle = BorderStyle.None;
            textBoxCantidad.Depth = 0;
            textBoxCantidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCantidad.LeadingIcon = null;
            textBoxCantidad.Location = new Point(92, 140);
            textBoxCantidad.MaxLength = 50;
            textBoxCantidad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCantidad.Multiline = false;
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(129, 50);
            textBoxCantidad.TabIndex = 38;
            textBoxCantidad.Text = "";
            textBoxCantidad.TrailingIcon = null;
            textBoxCantidad.KeyPress += textBoxCantidad_KeyPress;
            // 
            // radioButtonEntrada
            // 
            radioButtonEntrada.AutoSize = true;
            radioButtonEntrada.Checked = true;
            radioButtonEntrada.Depth = 0;
            radioButtonEntrada.Location = new Point(16, 23);
            radioButtonEntrada.Margin = new Padding(0);
            radioButtonEntrada.MouseLocation = new Point(-1, -1);
            radioButtonEntrada.MouseState = MaterialSkin.MouseState.HOVER;
            radioButtonEntrada.Name = "radioButtonEntrada";
            radioButtonEntrada.Ripple = true;
            radioButtonEntrada.Size = new Size(90, 37);
            radioButtonEntrada.TabIndex = 28;
            radioButtonEntrada.TabStop = true;
            radioButtonEntrada.Text = "Entrada";
            radioButtonEntrada.UseVisualStyleBackColor = true;
            // 
            // radioButtonSalida
            // 
            radioButtonSalida.AutoSize = true;
            radioButtonSalida.Depth = 0;
            radioButtonSalida.Location = new Point(131, 23);
            radioButtonSalida.Margin = new Padding(0);
            radioButtonSalida.MouseLocation = new Point(-1, -1);
            radioButtonSalida.MouseState = MaterialSkin.MouseState.HOVER;
            radioButtonSalida.Name = "radioButtonSalida";
            radioButtonSalida.Ripple = true;
            radioButtonSalida.Size = new Size(80, 37);
            radioButtonSalida.TabIndex = 29;
            radioButtonSalida.TabStop = true;
            radioButtonSalida.Text = "Salida";
            radioButtonSalida.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonEntrada);
            groupBox2.Controls.Add(radioButtonSalida);
            groupBox2.Location = new Point(16, 420);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(236, 74);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Entrada/Salida";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxDescArticulo);
            groupBox1.Controls.Add(bBuscarArticulo);
            groupBox1.Controls.Add(textBoxCodigoArticulo);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxCantidad);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxPrecioUnitario);
            groupBox1.Controls.Add(buttonAgregarArticulo);
            groupBox1.Controls.Add(buttonEliminarArticulo);
            groupBox1.Location = new Point(16, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(526, 280);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Articulo";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBoxDescArticulo
            // 
            textBoxDescArticulo.AnimateReadOnly = false;
            textBoxDescArticulo.BorderStyle = BorderStyle.None;
            textBoxDescArticulo.Depth = 0;
            textBoxDescArticulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescArticulo.LeadingIcon = null;
            textBoxDescArticulo.Location = new Point(6, 76);
            textBoxDescArticulo.MaxLength = 50;
            textBoxDescArticulo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescArticulo.Multiline = false;
            textBoxDescArticulo.Name = "textBoxDescArticulo";
            textBoxDescArticulo.ReadOnly = true;
            textBoxDescArticulo.Size = new Size(503, 50);
            textBoxDescArticulo.TabIndex = 19;
            textBoxDescArticulo.Text = "";
            textBoxDescArticulo.TrailingIcon = null;
            // 
            // bBuscarArticulo
            // 
            bBuscarArticulo.Image = (Image)resources.GetObject("bBuscarArticulo.Image");
            bBuscarArticulo.Location = new Point(113, 22);
            bBuscarArticulo.Name = "bBuscarArticulo";
            bBuscarArticulo.Size = new Size(48, 48);
            bBuscarArticulo.TabIndex = 18;
            bBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoArticulo
            // 
            textBoxCodigoArticulo.AnimateReadOnly = false;
            textBoxCodigoArticulo.BorderStyle = BorderStyle.None;
            textBoxCodigoArticulo.Depth = 0;
            textBoxCodigoArticulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoArticulo.LeadingIcon = null;
            textBoxCodigoArticulo.Location = new Point(6, 20);
            textBoxCodigoArticulo.MaxLength = 50;
            textBoxCodigoArticulo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoArticulo.Multiline = false;
            textBoxCodigoArticulo.Name = "textBoxCodigoArticulo";
            textBoxCodigoArticulo.Size = new Size(101, 50);
            textBoxCodigoArticulo.TabIndex = 17;
            textBoxCodigoArticulo.Text = "";
            textBoxCodigoArticulo.TrailingIcon = null;
            // 
            // dataGridViewArticulo
            // 
            dataGridViewArticulo.AllowUserToAddRows = false;
            dataGridViewArticulo.AllowUserToDeleteRows = false;
            dataGridViewArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArticulo.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArticulo.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigoArticulo, ColumnDescArticulo, ColumnCantidadArticulo, ColumnPrecioUnitario, ColumnImporteArt });
            dataGridViewArticulo.Location = new Point(574, 134);
            dataGridViewArticulo.Name = "dataGridViewArticulo";
            dataGridViewArticulo.ReadOnly = true;
            dataGridViewArticulo.RowHeadersVisible = false;
            dataGridViewArticulo.RowHeadersWidth = 51;
            dataGridViewArticulo.Size = new Size(657, 373);
            dataGridViewArticulo.TabIndex = 11;
            dataGridViewArticulo.CellContentClick += dataGridViewServicio_CellContentClick;
            // 
            // ColumnCodigoArticulo
            // 
            ColumnCodigoArticulo.FillWeight = 50F;
            ColumnCodigoArticulo.HeaderText = "Código";
            ColumnCodigoArticulo.MinimumWidth = 6;
            ColumnCodigoArticulo.Name = "ColumnCodigoArticulo";
            ColumnCodigoArticulo.ReadOnly = true;
            // 
            // ColumnDescArticulo
            // 
            ColumnDescArticulo.HeaderText = "Descripción";
            ColumnDescArticulo.MinimumWidth = 6;
            ColumnDescArticulo.Name = "ColumnDescArticulo";
            ColumnDescArticulo.ReadOnly = true;
            // 
            // ColumnCantidadArticulo
            // 
            ColumnCantidadArticulo.HeaderText = "Cantidad";
            ColumnCantidadArticulo.MinimumWidth = 6;
            ColumnCantidadArticulo.Name = "ColumnCantidadArticulo";
            ColumnCantidadArticulo.ReadOnly = true;
            // 
            // ColumnPrecioUnitario
            // 
            ColumnPrecioUnitario.FillWeight = 50F;
            ColumnPrecioUnitario.HeaderText = "Precio";
            ColumnPrecioUnitario.MinimumWidth = 6;
            ColumnPrecioUnitario.Name = "ColumnPrecioUnitario";
            ColumnPrecioUnitario.ReadOnly = true;
            // 
            // ColumnImporteArt
            // 
            ColumnImporteArt.HeaderText = "Importe";
            ColumnImporteArt.MinimumWidth = 6;
            ColumnImporteArt.Name = "ColumnImporteArt";
            ColumnImporteArt.ReadOnly = true;
            // 
            // FInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 537);
            Controls.Add(dataGridViewArticulo);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(labelTotal);
            Controls.Add(label1);
            Name = "FInventario";
            Text = "FInventario";
            Load += FInventario_Load;
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(labelTotal, 0);
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(dataGridViewArticulo, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelTotal;
        private Label label1;
        private MaterialSkin.Controls.MaterialButton buttonEliminarArticulo;
        private MaterialSkin.Controls.MaterialButton buttonAgregarArticulo;
        private MaterialSkin.Controls.MaterialTextBox textBoxPrecioUnitario;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox textBoxCantidad;
        private Label label3;
        private MaterialSkin.Controls.MaterialRadioButton radioButtonEntrada;
        private MaterialSkin.Controls.MaterialRadioButton radioButtonSalida;
        private GroupBox groupBox2;
        private DataGridView dataGridViewArticulo;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescArticulo;
        private Utilidades.Controles.BBuscar bBuscarArticulo;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoArticulo;
        private DataGridViewTextBoxColumn ColumnCodigoArticulo;
        private DataGridViewTextBoxColumn ColumnDescArticulo;
        private DataGridViewTextBoxColumn ColumnCantidadArticulo;
        private DataGridViewTextBoxColumn ColumnPrecioUnitario;
        private DataGridViewTextBoxColumn ColumnImporteArt;
    }
}