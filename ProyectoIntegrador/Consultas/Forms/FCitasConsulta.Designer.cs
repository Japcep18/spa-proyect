namespace ProyectoIntegrador.Consultas.Forms
{
    partial class FCitasConsulta
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
            consultauc1 = new Utilidades.Controles.ConsultaUC();
            panel1 = new Panel();
            switchFiltrarFecha = new MaterialSkin.Controls.MaterialSwitch();
            groupBox1 = new GroupBox();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridViewArticulo = new DataGridView();
            ColumnCodigoArticulo = new DataGridViewTextBoxColumn();
            ColumnDescArticulo = new DataGridViewTextBoxColumn();
            ColumnCantidadArticulo = new DataGridViewTextBoxColumn();
            ColumnPrecioUnitario = new DataGridViewTextBoxColumn();
            ColumnImporteArt = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dataGridViewServicio = new DataGridView();
            ColumnCodigoServicio = new DataGridViewTextBoxColumn();
            ColumnDescServicio = new DataGridViewTextBoxColumn();
            ColumnPrecioServicio = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulo).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServicio).BeginInit();
            SuspendLayout();
            // 
            // consultauc1
            // 
            consultauc1.AscDefaultOrder = false;
            consultauc1.DefaultColumnOrder = null;
            consultauc1.Dock = DockStyle.Fill;
            consultauc1.Location = new Point(3, 161);
            consultauc1.Name = "consultauc1";
            consultauc1.Size = new Size(800, 315);
            consultauc1.TabIndex = 0;
            consultauc1.Load += consultauc1_Load;
            // 
            // panel1
            // 
            panel1.Controls.Add(switchFiltrarFecha);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 97);
            panel1.TabIndex = 1;
            // 
            // switchFiltrarFecha
            // 
            switchFiltrarFecha.AutoSize = true;
            switchFiltrarFecha.Depth = 0;
            switchFiltrarFecha.Location = new Point(13, 3);
            switchFiltrarFecha.Margin = new Padding(0);
            switchFiltrarFecha.MouseLocation = new Point(-1, -1);
            switchFiltrarFecha.MouseState = MaterialSkin.MouseState.HOVER;
            switchFiltrarFecha.Name = "switchFiltrarFecha";
            switchFiltrarFecha.Ripple = true;
            switchFiltrarFecha.Size = new Size(170, 37);
            switchFiltrarFecha.TabIndex = 3;
            switchFiltrarFecha.Text = "Filtrar por fecha";
            switchFiltrarFecha.UseVisualStyleBackColor = true;
            switchFiltrarFecha.CheckedChanged += swtichFiltrarFecha_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(199, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(444, 67);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros de fecha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(234, 31);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 3;
            label2.Text = "Hasta:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(300, 28);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(131, 27);
            dateTimePicker2.TabIndex = 2;
            dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 31);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "Desde:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(82, 28);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(131, 27);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(tabControl1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(3, 476);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 197);
            panel2.TabIndex = 4;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 197);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridViewArticulo);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 164);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Articulos";
            // 
            // dataGridViewArticulo
            // 
            dataGridViewArticulo.AllowUserToAddRows = false;
            dataGridViewArticulo.AllowUserToDeleteRows = false;
            dataGridViewArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArticulo.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArticulo.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigoArticulo, ColumnDescArticulo, ColumnCantidadArticulo, ColumnPrecioUnitario, ColumnImporteArt });
            dataGridViewArticulo.Dock = DockStyle.Fill;
            dataGridViewArticulo.Location = new Point(3, 3);
            dataGridViewArticulo.Name = "dataGridViewArticulo";
            dataGridViewArticulo.ReadOnly = true;
            dataGridViewArticulo.RowHeadersVisible = false;
            dataGridViewArticulo.RowHeadersWidth = 51;
            dataGridViewArticulo.Size = new Size(786, 158);
            dataGridViewArticulo.TabIndex = 13;
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
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridViewServicio);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 164);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Servicio";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewServicio
            // 
            dataGridViewServicio.AllowUserToAddRows = false;
            dataGridViewServicio.AllowUserToDeleteRows = false;
            dataGridViewServicio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServicio.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewServicio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServicio.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigoServicio, ColumnDescServicio, ColumnPrecioServicio });
            dataGridViewServicio.Dock = DockStyle.Fill;
            dataGridViewServicio.Location = new Point(3, 3);
            dataGridViewServicio.Name = "dataGridViewServicio";
            dataGridViewServicio.ReadOnly = true;
            dataGridViewServicio.RowHeadersVisible = false;
            dataGridViewServicio.RowHeadersWidth = 51;
            dataGridViewServicio.Size = new Size(786, 158);
            dataGridViewServicio.TabIndex = 2;
            // 
            // ColumnCodigoServicio
            // 
            ColumnCodigoServicio.FillWeight = 50F;
            ColumnCodigoServicio.HeaderText = "Código";
            ColumnCodigoServicio.MinimumWidth = 6;
            ColumnCodigoServicio.Name = "ColumnCodigoServicio";
            ColumnCodigoServicio.ReadOnly = true;
            // 
            // ColumnDescServicio
            // 
            ColumnDescServicio.HeaderText = "Descripción";
            ColumnDescServicio.MinimumWidth = 6;
            ColumnDescServicio.Name = "ColumnDescServicio";
            ColumnDescServicio.ReadOnly = true;
            // 
            // ColumnPrecioServicio
            // 
            ColumnPrecioServicio.FillWeight = 50F;
            ColumnPrecioServicio.HeaderText = "Precio";
            ColumnPrecioServicio.MinimumWidth = 6;
            ColumnPrecioServicio.Name = "ColumnPrecioServicio";
            ColumnPrecioServicio.ReadOnly = true;
            // 
            // FCitasConsulta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 676);
            Controls.Add(consultauc1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "FCitasConsulta";
            Text = "Consulta de Citas";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulo).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewServicio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Utilidades.Controles.ConsultaUC consultauc1;
        private Panel panel1;
        private GroupBox groupBox1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private MaterialSkin.Controls.MaterialSwitch switchFiltrarFecha;
        private Panel panel2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridViewArticulo;
        private DataGridViewTextBoxColumn ColumnCodigoArticulo;
        private DataGridViewTextBoxColumn ColumnDescArticulo;
        private DataGridViewTextBoxColumn ColumnCantidadArticulo;
        private DataGridViewTextBoxColumn ColumnPrecioUnitario;
        private DataGridViewTextBoxColumn ColumnImporteArt;
        private DataGridView dataGridViewServicio;
        private DataGridViewTextBoxColumn ColumnCodigoServicio;
        private DataGridViewTextBoxColumn ColumnDescServicio;
        private DataGridViewTextBoxColumn ColumnPrecioServicio;
    }
}