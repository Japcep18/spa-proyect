namespace ProyectoIntegrador.Facturacion
{
    partial class FFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFacturacion));
            groupBox2 = new GroupBox();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPageServicios = new TabPage();
            buttonAgregarServicio = new MaterialSkin.Controls.MaterialButton();
            buttonEliminarServicio = new MaterialSkin.Controls.MaterialButton();
            dataGridViewServicio = new DataGridView();
            ColumnCodigoServicio = new DataGridViewTextBoxColumn();
            ColumnDescServicio = new DataGridViewTextBoxColumn();
            ColumnPrecioServicio = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            textBoxDescServicio = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarServicio = new Utilidades.Controles.BBuscar();
            textBoxCodigoServicio = new MaterialSkin.Controls.MaterialTextBox();
            tabPageArticulos = new TabPage();
            label2 = new Label();
            buttonAgregarArticulo = new MaterialSkin.Controls.MaterialButton();
            textBoxCantidad = new MaterialSkin.Controls.MaterialTextBox();
            buttonEliminarArticulo = new MaterialSkin.Controls.MaterialButton();
            dataGridViewArticulo = new DataGridView();
            ColumnCodigoArticulo = new DataGridViewTextBoxColumn();
            ColumnDescripcionArticulo = new DataGridViewTextBoxColumn();
            ColumnPrecioArticulo = new DataGridViewTextBoxColumn();
            ColumnCantidadArticulo = new DataGridViewTextBoxColumn();
            ColumnImporteArticulo = new DataGridViewTextBoxColumn();
            groupBox3 = new GroupBox();
            textBoxDescArticulo = new MaterialSkin.Controls.MaterialTextBox();
            bBuscarArticulo = new Utilidades.Controles.BBuscar();
            textBoxCodigoArticulo = new MaterialSkin.Controls.MaterialTextBox();
            tabPagePersonal = new TabPage();
            dataGridViewEmpleado = new DataGridView();
            ColumnCodigoEmpleado = new DataGridViewTextBoxColumn();
            ColumnDescEmpleado = new DataGridViewTextBoxColumn();
            ColumnPuestoEmpleado = new DataGridViewTextBoxColumn();
            buttonAgregarEmpleado = new MaterialSkin.Controls.MaterialButton();
            buttonEliminarEmpleado = new MaterialSkin.Controls.MaterialButton();
            groupBox4 = new GroupBox();
            bBuscarEmpleado = new Utilidades.Controles.BBuscar();
            textBoxDescEmpleado = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigoEmpleado = new MaterialSkin.Controls.MaterialTextBox();
            tabPageSala = new TabPage();
            groupBox5 = new GroupBox();
            multiLineTextBoxObservaciones = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            tabPageDetallesGuarderia = new TabPage();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            dataGridViewGuardería = new DataGridView();
            columnSecuenciaGuarderia = new DataGridViewTextBoxColumn();
            columnTutor = new DataGridViewTextBoxColumn();
            columnInfante = new DataGridViewTextBoxColumn();
            materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            label5 = new Label();
            textBoxDescSala = new MaterialSkin.Controls.MaterialTextBox();
            textBoxDescCliente = new MaterialSkin.Controls.MaterialTextBox();
            label1 = new Label();
            labelTotal = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            buttonBuscarCitas = new MaterialSkin.Controls.MaterialButton();
            label4 = new Label();
            labelTiempoEstimado = new Label();
            label7 = new Label();
            labelSinDescuento = new Label();
            label8 = new Label();
            labelDescuento = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBox2.SuspendLayout();
            materialTabControl1.SuspendLayout();
            tabPageServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServicio).BeginInit();
            groupBox1.SuspendLayout();
            tabPageArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulo).BeginInit();
            groupBox3.SuspendLayout();
            tabPagePersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleado).BeginInit();
            groupBox4.SuspendLayout();
            tabPageSala.SuspendLayout();
            groupBox5.SuspendLayout();
            tabPageDetallesGuarderia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGuardería).BeginInit();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(1146, 5);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(materialTabControl1);
            groupBox2.Controls.Add(materialTabSelector1);
            groupBox2.Font = new Font("Microsoft Sans Serif", 9F);
            groupBox2.Location = new Point(6, 293);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(0);
            groupBox2.Size = new Size(1140, 302);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalles";
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPageServicios);
            materialTabControl1.Controls.Add(tabPageArticulos);
            materialTabControl1.Controls.Add(tabPagePersonal);
            materialTabControl1.Controls.Add(tabPageSala);
            materialTabControl1.Controls.Add(tabPageDetallesGuarderia);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.Location = new Point(0, 51);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1140, 251);
            materialTabControl1.TabIndex = 11;
            // 
            // tabPageServicios
            // 
            tabPageServicios.Controls.Add(buttonAgregarServicio);
            tabPageServicios.Controls.Add(buttonEliminarServicio);
            tabPageServicios.Controls.Add(dataGridViewServicio);
            tabPageServicios.Controls.Add(groupBox1);
            tabPageServicios.Location = new Point(4, 27);
            tabPageServicios.Name = "tabPageServicios";
            tabPageServicios.Padding = new Padding(3);
            tabPageServicios.Size = new Size(1132, 220);
            tabPageServicios.TabIndex = 0;
            tabPageServicios.Text = "Servicios";
            // 
            // buttonAgregarServicio
            // 
            buttonAgregarServicio.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregarServicio.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregarServicio.Depth = 0;
            buttonAgregarServicio.HighEmphasis = true;
            buttonAgregarServicio.Icon = Properties.Resources.material_add_24;
            buttonAgregarServicio.Location = new Point(190, 188);
            buttonAgregarServicio.Margin = new Padding(4, 6, 4, 6);
            buttonAgregarServicio.MouseState = MaterialSkin.MouseState.HOVER;
            buttonAgregarServicio.Name = "buttonAgregarServicio";
            buttonAgregarServicio.NoAccentTextColor = Color.Empty;
            buttonAgregarServicio.Size = new Size(116, 36);
            buttonAgregarServicio.TabIndex = 24;
            buttonAgregarServicio.Text = "Agregar";
            buttonAgregarServicio.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonAgregarServicio.UseAccentColor = false;
            buttonAgregarServicio.UseVisualStyleBackColor = true;
            buttonAgregarServicio.Click += buttonAgregarServicio_Click;
            // 
            // buttonEliminarServicio
            // 
            buttonEliminarServicio.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminarServicio.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminarServicio.Depth = 0;
            buttonEliminarServicio.HighEmphasis = true;
            buttonEliminarServicio.Icon = Properties.Resources.material_delete_24;
            buttonEliminarServicio.Location = new Point(321, 188);
            buttonEliminarServicio.Margin = new Padding(4, 6, 4, 6);
            buttonEliminarServicio.MouseState = MaterialSkin.MouseState.HOVER;
            buttonEliminarServicio.Name = "buttonEliminarServicio";
            buttonEliminarServicio.NoAccentTextColor = Color.Empty;
            buttonEliminarServicio.Size = new Size(116, 36);
            buttonEliminarServicio.TabIndex = 25;
            buttonEliminarServicio.Text = "Eliminar";
            buttonEliminarServicio.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonEliminarServicio.UseAccentColor = true;
            buttonEliminarServicio.UseVisualStyleBackColor = true;
            buttonEliminarServicio.Click += buttonEliminarServicio_Click;
            // 
            // dataGridViewServicio
            // 
            dataGridViewServicio.AllowUserToAddRows = false;
            dataGridViewServicio.AllowUserToDeleteRows = false;
            dataGridViewServicio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServicio.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewServicio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServicio.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigoServicio, ColumnDescServicio, ColumnPrecioServicio });
            dataGridViewServicio.Location = new Point(444, 6);
            dataGridViewServicio.Name = "dataGridViewServicio";
            dataGridViewServicio.ReadOnly = true;
            dataGridViewServicio.RowHeadersVisible = false;
            dataGridViewServicio.RowHeadersWidth = 51;
            dataGridViewServicio.Size = new Size(685, 218);
            dataGridViewServicio.TabIndex = 1;
            dataGridViewServicio.CellDoubleClick += dataGridViewServicio_CellDoubleClick;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxDescServicio);
            groupBox1.Controls.Add(bBuscarServicio);
            groupBox1.Controls.Add(textBoxCodigoServicio);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(432, 142);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Servicio:";
            // 
            // textBoxDescServicio
            // 
            textBoxDescServicio.AnimateReadOnly = false;
            textBoxDescServicio.BorderStyle = BorderStyle.None;
            textBoxDescServicio.Depth = 0;
            textBoxDescServicio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescServicio.LeadingIcon = null;
            textBoxDescServicio.Location = new Point(10, 82);
            textBoxDescServicio.MaxLength = 50;
            textBoxDescServicio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescServicio.Multiline = false;
            textBoxDescServicio.Name = "textBoxDescServicio";
            textBoxDescServicio.ReadOnly = true;
            textBoxDescServicio.Size = new Size(407, 50);
            textBoxDescServicio.TabIndex = 16;
            textBoxDescServicio.Text = "";
            textBoxDescServicio.TrailingIcon = null;
            // 
            // bBuscarServicio
            // 
            bBuscarServicio.Image = (Image)resources.GetObject("bBuscarServicio.Image");
            bBuscarServicio.Location = new Point(117, 28);
            bBuscarServicio.Name = "bBuscarServicio";
            bBuscarServicio.Size = new Size(48, 48);
            bBuscarServicio.TabIndex = 16;
            bBuscarServicio.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoServicio
            // 
            textBoxCodigoServicio.AnimateReadOnly = false;
            textBoxCodigoServicio.BorderStyle = BorderStyle.None;
            textBoxCodigoServicio.Depth = 0;
            textBoxCodigoServicio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoServicio.LeadingIcon = null;
            textBoxCodigoServicio.Location = new Point(10, 26);
            textBoxCodigoServicio.MaxLength = 50;
            textBoxCodigoServicio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoServicio.Multiline = false;
            textBoxCodigoServicio.Name = "textBoxCodigoServicio";
            textBoxCodigoServicio.Size = new Size(101, 50);
            textBoxCodigoServicio.TabIndex = 0;
            textBoxCodigoServicio.Text = "";
            textBoxCodigoServicio.TrailingIcon = null;
            // 
            // tabPageArticulos
            // 
            tabPageArticulos.Controls.Add(label2);
            tabPageArticulos.Controls.Add(buttonAgregarArticulo);
            tabPageArticulos.Controls.Add(textBoxCantidad);
            tabPageArticulos.Controls.Add(buttonEliminarArticulo);
            tabPageArticulos.Controls.Add(dataGridViewArticulo);
            tabPageArticulos.Controls.Add(groupBox3);
            tabPageArticulos.Location = new Point(4, 27);
            tabPageArticulos.Name = "tabPageArticulos";
            tabPageArticulos.Padding = new Padding(3);
            tabPageArticulos.Size = new Size(1132, 220);
            tabPageArticulos.TabIndex = 1;
            tabPageArticulos.Text = "artículos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 146);
            label2.Name = "label2";
            label2.Size = new Size(70, 18);
            label2.TabIndex = 31;
            label2.Text = "Cantidad:";
            // 
            // buttonAgregarArticulo
            // 
            buttonAgregarArticulo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregarArticulo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregarArticulo.Depth = 0;
            buttonAgregarArticulo.HighEmphasis = true;
            buttonAgregarArticulo.Icon = Properties.Resources.material_add_24;
            buttonAgregarArticulo.Location = new Point(176, 166);
            buttonAgregarArticulo.Margin = new Padding(4, 6, 4, 6);
            buttonAgregarArticulo.MouseState = MaterialSkin.MouseState.HOVER;
            buttonAgregarArticulo.Name = "buttonAgregarArticulo";
            buttonAgregarArticulo.NoAccentTextColor = Color.Empty;
            buttonAgregarArticulo.Size = new Size(116, 36);
            buttonAgregarArticulo.TabIndex = 28;
            buttonAgregarArticulo.Text = "Agregar";
            buttonAgregarArticulo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonAgregarArticulo.UseAccentColor = false;
            buttonAgregarArticulo.UseVisualStyleBackColor = true;
            buttonAgregarArticulo.Click += buttonAgregarArticulo_Click;
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.AnimateReadOnly = false;
            textBoxCantidad.BorderStyle = BorderStyle.None;
            textBoxCantidad.Depth = 0;
            textBoxCantidad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCantidad.LeadingIcon = null;
            textBoxCantidad.Location = new Point(12, 169);
            textBoxCantidad.MaxLength = 50;
            textBoxCantidad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCantidad.Multiline = false;
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(104, 36);
            textBoxCantidad.TabIndex = 30;
            textBoxCantidad.Text = "";
            textBoxCantidad.TrailingIcon = null;
            textBoxCantidad.UseTallSize = false;
            textBoxCantidad.KeyPress += textBoxCantidad_KeyPress;
            // 
            // buttonEliminarArticulo
            // 
            buttonEliminarArticulo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminarArticulo.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminarArticulo.Depth = 0;
            buttonEliminarArticulo.HighEmphasis = true;
            buttonEliminarArticulo.Icon = Properties.Resources.material_delete_24;
            buttonEliminarArticulo.Location = new Point(307, 166);
            buttonEliminarArticulo.Margin = new Padding(4, 6, 4, 6);
            buttonEliminarArticulo.MouseState = MaterialSkin.MouseState.HOVER;
            buttonEliminarArticulo.Name = "buttonEliminarArticulo";
            buttonEliminarArticulo.NoAccentTextColor = Color.Empty;
            buttonEliminarArticulo.Size = new Size(116, 36);
            buttonEliminarArticulo.TabIndex = 29;
            buttonEliminarArticulo.Text = "Eliminar";
            buttonEliminarArticulo.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonEliminarArticulo.UseAccentColor = true;
            buttonEliminarArticulo.UseVisualStyleBackColor = true;
            buttonEliminarArticulo.Click += buttonEliminarArticulo_Click;
            // 
            // dataGridViewArticulo
            // 
            dataGridViewArticulo.AllowUserToAddRows = false;
            dataGridViewArticulo.AllowUserToDeleteRows = false;
            dataGridViewArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArticulo.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArticulo.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigoArticulo, ColumnDescripcionArticulo, ColumnPrecioArticulo, ColumnCantidadArticulo, ColumnImporteArticulo });
            dataGridViewArticulo.Location = new Point(444, 6);
            dataGridViewArticulo.Name = "dataGridViewArticulo";
            dataGridViewArticulo.ReadOnly = true;
            dataGridViewArticulo.RowHeadersVisible = false;
            dataGridViewArticulo.RowHeadersWidth = 51;
            dataGridViewArticulo.Size = new Size(682, 218);
            dataGridViewArticulo.TabIndex = 27;
            dataGridViewArticulo.CellDoubleClick += dataGridViewArticulo_CellDoubleClick;
            // 
            // ColumnCodigoArticulo
            // 
            ColumnCodigoArticulo.FillWeight = 50F;
            ColumnCodigoArticulo.HeaderText = "Código";
            ColumnCodigoArticulo.MinimumWidth = 6;
            ColumnCodigoArticulo.Name = "ColumnCodigoArticulo";
            ColumnCodigoArticulo.ReadOnly = true;
            // 
            // ColumnDescripcionArticulo
            // 
            ColumnDescripcionArticulo.HeaderText = "Descripción";
            ColumnDescripcionArticulo.MinimumWidth = 6;
            ColumnDescripcionArticulo.Name = "ColumnDescripcionArticulo";
            ColumnDescripcionArticulo.ReadOnly = true;
            // 
            // ColumnPrecioArticulo
            // 
            ColumnPrecioArticulo.FillWeight = 50F;
            ColumnPrecioArticulo.HeaderText = "Precio";
            ColumnPrecioArticulo.MinimumWidth = 6;
            ColumnPrecioArticulo.Name = "ColumnPrecioArticulo";
            ColumnPrecioArticulo.ReadOnly = true;
            // 
            // ColumnCantidadArticulo
            // 
            ColumnCantidadArticulo.FillWeight = 50F;
            ColumnCantidadArticulo.HeaderText = "Cantidad";
            ColumnCantidadArticulo.MinimumWidth = 6;
            ColumnCantidadArticulo.Name = "ColumnCantidadArticulo";
            ColumnCantidadArticulo.ReadOnly = true;
            // 
            // ColumnImporteArticulo
            // 
            ColumnImporteArticulo.FillWeight = 50F;
            ColumnImporteArticulo.HeaderText = "Importe";
            ColumnImporteArticulo.MinimumWidth = 6;
            ColumnImporteArticulo.Name = "ColumnImporteArticulo";
            ColumnImporteArticulo.ReadOnly = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBoxDescArticulo);
            groupBox3.Controls.Add(bBuscarArticulo);
            groupBox3.Controls.Add(textBoxCodigoArticulo);
            groupBox3.Location = new Point(6, 6);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(432, 118);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Artículo:";
            // 
            // textBoxDescArticulo
            // 
            textBoxDescArticulo.AnimateReadOnly = false;
            textBoxDescArticulo.BorderStyle = BorderStyle.None;
            textBoxDescArticulo.Depth = 0;
            textBoxDescArticulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescArticulo.LeadingIcon = null;
            textBoxDescArticulo.Location = new Point(10, 69);
            textBoxDescArticulo.MaxLength = 50;
            textBoxDescArticulo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescArticulo.Multiline = false;
            textBoxDescArticulo.Name = "textBoxDescArticulo";
            textBoxDescArticulo.ReadOnly = true;
            textBoxDescArticulo.Size = new Size(407, 36);
            textBoxDescArticulo.TabIndex = 16;
            textBoxDescArticulo.Text = "";
            textBoxDescArticulo.TrailingIcon = null;
            textBoxDescArticulo.UseTallSize = false;
            // 
            // bBuscarArticulo
            // 
            bBuscarArticulo.Image = (Image)resources.GetObject("bBuscarArticulo.Image");
            bBuscarArticulo.Location = new Point(117, 23);
            bBuscarArticulo.Name = "bBuscarArticulo";
            bBuscarArticulo.Size = new Size(40, 40);
            bBuscarArticulo.TabIndex = 16;
            bBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoArticulo
            // 
            textBoxCodigoArticulo.AnimateReadOnly = false;
            textBoxCodigoArticulo.BorderStyle = BorderStyle.None;
            textBoxCodigoArticulo.Depth = 0;
            textBoxCodigoArticulo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoArticulo.LeadingIcon = null;
            textBoxCodigoArticulo.Location = new Point(10, 26);
            textBoxCodigoArticulo.MaxLength = 50;
            textBoxCodigoArticulo.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoArticulo.Multiline = false;
            textBoxCodigoArticulo.Name = "textBoxCodigoArticulo";
            textBoxCodigoArticulo.Size = new Size(101, 36);
            textBoxCodigoArticulo.TabIndex = 0;
            textBoxCodigoArticulo.Text = "";
            textBoxCodigoArticulo.TrailingIcon = null;
            textBoxCodigoArticulo.UseTallSize = false;
            // 
            // tabPagePersonal
            // 
            tabPagePersonal.Controls.Add(dataGridViewEmpleado);
            tabPagePersonal.Controls.Add(buttonAgregarEmpleado);
            tabPagePersonal.Controls.Add(buttonEliminarEmpleado);
            tabPagePersonal.Controls.Add(groupBox4);
            tabPagePersonal.Location = new Point(4, 27);
            tabPagePersonal.Name = "tabPagePersonal";
            tabPagePersonal.Padding = new Padding(3);
            tabPagePersonal.Size = new Size(1132, 220);
            tabPagePersonal.TabIndex = 2;
            tabPagePersonal.Text = "PERSONAL";
            // 
            // dataGridViewEmpleado
            // 
            dataGridViewEmpleado.AllowUserToAddRows = false;
            dataGridViewEmpleado.AllowUserToDeleteRows = false;
            dataGridViewEmpleado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmpleado.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpleado.Columns.AddRange(new DataGridViewColumn[] { ColumnCodigoEmpleado, ColumnDescEmpleado, ColumnPuestoEmpleado });
            dataGridViewEmpleado.Location = new Point(444, 6);
            dataGridViewEmpleado.Name = "dataGridViewEmpleado";
            dataGridViewEmpleado.ReadOnly = true;
            dataGridViewEmpleado.RowHeadersVisible = false;
            dataGridViewEmpleado.RowHeadersWidth = 51;
            dataGridViewEmpleado.Size = new Size(682, 239);
            dataGridViewEmpleado.TabIndex = 32;
            dataGridViewEmpleado.CellDoubleClick += dataGridViewEmpleado_CellDoubleClick;
            // 
            // ColumnCodigoEmpleado
            // 
            ColumnCodigoEmpleado.FillWeight = 50F;
            ColumnCodigoEmpleado.HeaderText = "Código";
            ColumnCodigoEmpleado.MinimumWidth = 6;
            ColumnCodigoEmpleado.Name = "ColumnCodigoEmpleado";
            ColumnCodigoEmpleado.ReadOnly = true;
            // 
            // ColumnDescEmpleado
            // 
            ColumnDescEmpleado.HeaderText = "Descripción";
            ColumnDescEmpleado.MinimumWidth = 6;
            ColumnDescEmpleado.Name = "ColumnDescEmpleado";
            ColumnDescEmpleado.ReadOnly = true;
            // 
            // ColumnPuestoEmpleado
            // 
            ColumnPuestoEmpleado.HeaderText = "Puesto";
            ColumnPuestoEmpleado.MinimumWidth = 6;
            ColumnPuestoEmpleado.Name = "ColumnPuestoEmpleado";
            ColumnPuestoEmpleado.ReadOnly = true;
            // 
            // buttonAgregarEmpleado
            // 
            buttonAgregarEmpleado.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonAgregarEmpleado.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonAgregarEmpleado.Depth = 0;
            buttonAgregarEmpleado.HighEmphasis = true;
            buttonAgregarEmpleado.Icon = Properties.Resources.material_add_24;
            buttonAgregarEmpleado.Location = new Point(181, 206);
            buttonAgregarEmpleado.Margin = new Padding(4, 6, 4, 6);
            buttonAgregarEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            buttonAgregarEmpleado.Name = "buttonAgregarEmpleado";
            buttonAgregarEmpleado.NoAccentTextColor = Color.Empty;
            buttonAgregarEmpleado.Size = new Size(116, 36);
            buttonAgregarEmpleado.TabIndex = 30;
            buttonAgregarEmpleado.Text = "Agregar";
            buttonAgregarEmpleado.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonAgregarEmpleado.UseAccentColor = false;
            buttonAgregarEmpleado.UseVisualStyleBackColor = true;
            buttonAgregarEmpleado.Click += ButtonAgregarEmpleado_Click;
            // 
            // buttonEliminarEmpleado
            // 
            buttonEliminarEmpleado.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonEliminarEmpleado.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonEliminarEmpleado.Depth = 0;
            buttonEliminarEmpleado.HighEmphasis = true;
            buttonEliminarEmpleado.Icon = Properties.Resources.material_delete_24;
            buttonEliminarEmpleado.Location = new Point(312, 206);
            buttonEliminarEmpleado.Margin = new Padding(4, 6, 4, 6);
            buttonEliminarEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            buttonEliminarEmpleado.Name = "buttonEliminarEmpleado";
            buttonEliminarEmpleado.NoAccentTextColor = Color.Empty;
            buttonEliminarEmpleado.Size = new Size(116, 36);
            buttonEliminarEmpleado.TabIndex = 31;
            buttonEliminarEmpleado.Text = "Eliminar";
            buttonEliminarEmpleado.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            buttonEliminarEmpleado.UseAccentColor = true;
            buttonEliminarEmpleado.UseVisualStyleBackColor = true;
            buttonEliminarEmpleado.Click += buttonEliminarEmpleado_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(bBuscarEmpleado);
            groupBox4.Controls.Add(textBoxDescEmpleado);
            groupBox4.Controls.Add(textBoxCodigoEmpleado);
            groupBox4.Location = new Point(6, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(428, 139);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            groupBox4.Text = "Empleado";
            // 
            // bBuscarEmpleado
            // 
            bBuscarEmpleado.Image = (Image)resources.GetObject("bBuscarEmpleado.Image");
            bBuscarEmpleado.Location = new Point(102, 25);
            bBuscarEmpleado.Name = "bBuscarEmpleado";
            bBuscarEmpleado.Size = new Size(48, 48);
            bBuscarEmpleado.TabIndex = 21;
            bBuscarEmpleado.UseVisualStyleBackColor = true;
            // 
            // textBoxDescEmpleado
            // 
            textBoxDescEmpleado.AnimateReadOnly = false;
            textBoxDescEmpleado.BorderStyle = BorderStyle.None;
            textBoxDescEmpleado.Depth = 0;
            textBoxDescEmpleado.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescEmpleado.LeadingIcon = null;
            textBoxDescEmpleado.Location = new Point(10, 81);
            textBoxDescEmpleado.MaxLength = 50;
            textBoxDescEmpleado.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescEmpleado.Multiline = false;
            textBoxDescEmpleado.Name = "textBoxDescEmpleado";
            textBoxDescEmpleado.ReadOnly = true;
            textBoxDescEmpleado.Size = new Size(412, 50);
            textBoxDescEmpleado.TabIndex = 22;
            textBoxDescEmpleado.Text = "";
            textBoxDescEmpleado.TrailingIcon = null;
            // 
            // textBoxCodigoEmpleado
            // 
            textBoxCodigoEmpleado.AnimateReadOnly = false;
            textBoxCodigoEmpleado.BorderStyle = BorderStyle.None;
            textBoxCodigoEmpleado.Depth = 0;
            textBoxCodigoEmpleado.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoEmpleado.LeadingIcon = null;
            textBoxCodigoEmpleado.Location = new Point(10, 25);
            textBoxCodigoEmpleado.MaxLength = 50;
            textBoxCodigoEmpleado.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoEmpleado.Multiline = false;
            textBoxCodigoEmpleado.Name = "textBoxCodigoEmpleado";
            textBoxCodigoEmpleado.Size = new Size(86, 50);
            textBoxCodigoEmpleado.TabIndex = 20;
            textBoxCodigoEmpleado.Text = "";
            textBoxCodigoEmpleado.TrailingIcon = null;
            // 
            // tabPageSala
            // 
            tabPageSala.Controls.Add(groupBox5);
            tabPageSala.Location = new Point(4, 27);
            tabPageSala.Name = "tabPageSala";
            tabPageSala.Size = new Size(1132, 220);
            tabPageSala.TabIndex = 3;
            tabPageSala.Text = "Observaciones";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(multiLineTextBoxObservaciones);
            groupBox5.Location = new Point(6, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1123, 226);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Observaciones";
            // 
            // multiLineTextBoxObservaciones
            // 
            multiLineTextBoxObservaciones.BackColor = Color.FromArgb(255, 255, 255);
            multiLineTextBoxObservaciones.BorderStyle = BorderStyle.None;
            multiLineTextBoxObservaciones.Depth = 0;
            multiLineTextBoxObservaciones.Dock = DockStyle.Fill;
            multiLineTextBoxObservaciones.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            multiLineTextBoxObservaciones.ForeColor = Color.FromArgb(222, 0, 0, 0);
            multiLineTextBoxObservaciones.Location = new Point(3, 20);
            multiLineTextBoxObservaciones.MouseState = MaterialSkin.MouseState.HOVER;
            multiLineTextBoxObservaciones.Name = "multiLineTextBoxObservaciones";
            multiLineTextBoxObservaciones.Size = new Size(1117, 203);
            multiLineTextBoxObservaciones.TabIndex = 2;
            multiLineTextBoxObservaciones.Text = "";
            // 
            // tabPageDetallesGuarderia
            // 
            tabPageDetallesGuarderia.Controls.Add(materialButton1);
            tabPageDetallesGuarderia.Controls.Add(dataGridViewGuardería);
            tabPageDetallesGuarderia.Location = new Point(4, 27);
            tabPageDetallesGuarderia.Name = "tabPageDetallesGuarderia";
            tabPageDetallesGuarderia.Size = new Size(1132, 220);
            tabPageDetallesGuarderia.TabIndex = 4;
            tabPageDetallesGuarderia.Text = "Detalles de la guardería";
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(9, 12);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(173, 36);
            materialButton1.TabIndex = 23;
            materialButton1.Text = "Modificar detalles";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click_1;
            // 
            // dataGridViewGuardería
            // 
            dataGridViewGuardería.AllowUserToAddRows = false;
            dataGridViewGuardería.AllowUserToDeleteRows = false;
            dataGridViewGuardería.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGuardería.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewGuardería.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGuardería.Columns.AddRange(new DataGridViewColumn[] { columnSecuenciaGuarderia, columnTutor, columnInfante });
            dataGridViewGuardería.Location = new Point(9, 57);
            dataGridViewGuardería.Name = "dataGridViewGuardería";
            dataGridViewGuardería.ReadOnly = true;
            dataGridViewGuardería.RowHeadersVisible = false;
            dataGridViewGuardería.RowHeadersWidth = 51;
            dataGridViewGuardería.Size = new Size(1106, 200);
            dataGridViewGuardería.TabIndex = 33;
            // 
            // columnSecuenciaGuarderia
            // 
            columnSecuenciaGuarderia.FillWeight = 30F;
            columnSecuenciaGuarderia.HeaderText = "Secuencia";
            columnSecuenciaGuarderia.MinimumWidth = 6;
            columnSecuenciaGuarderia.Name = "columnSecuenciaGuarderia";
            columnSecuenciaGuarderia.ReadOnly = true;
            // 
            // columnTutor
            // 
            columnTutor.HeaderText = "Tutor";
            columnTutor.MinimumWidth = 6;
            columnTutor.Name = "columnTutor";
            columnTutor.ReadOnly = true;
            // 
            // columnInfante
            // 
            columnInfante.HeaderText = "Infante";
            columnInfante.MinimumWidth = 6;
            columnInfante.Name = "columnInfante";
            columnInfante.ReadOnly = true;
            columnInfante.Resizable = DataGridViewTriState.True;
            // 
            // materialTabSelector1
            // 
            materialTabSelector1.BaseTabControl = materialTabControl1;
            materialTabSelector1.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Upper;
            materialTabSelector1.Depth = 0;
            materialTabSelector1.Dock = DockStyle.Top;
            materialTabSelector1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTabSelector1.Location = new Point(0, 17);
            materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabSelector1.Name = "materialTabSelector1";
            materialTabSelector1.Size = new Size(1140, 34);
            materialTabSelector1.TabIndex = 12;
            materialTabSelector1.Text = "materialTabSelector1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 256);
            label5.Name = "label5";
            label5.Size = new Size(40, 20);
            label5.TabIndex = 24;
            label5.Text = "Sala:";
            // 
            // textBoxDescSala
            // 
            textBoxDescSala.AnimateReadOnly = false;
            textBoxDescSala.BorderStyle = BorderStyle.None;
            textBoxDescSala.Depth = 0;
            textBoxDescSala.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescSala.LeadingIcon = null;
            textBoxDescSala.Location = new Point(79, 248);
            textBoxDescSala.MaxLength = 50;
            textBoxDescSala.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescSala.Multiline = false;
            textBoxDescSala.Name = "textBoxDescSala";
            textBoxDescSala.ReadOnly = true;
            textBoxDescSala.Size = new Size(473, 36);
            textBoxDescSala.TabIndex = 23;
            textBoxDescSala.Text = "";
            textBoxDescSala.TrailingIcon = null;
            textBoxDescSala.UseTallSize = false;
            // 
            // textBoxDescCliente
            // 
            textBoxDescCliente.AnimateReadOnly = false;
            textBoxDescCliente.BorderStyle = BorderStyle.None;
            textBoxDescCliente.Depth = 0;
            textBoxDescCliente.Enabled = false;
            textBoxDescCliente.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDescCliente.LeadingIcon = null;
            textBoxDescCliente.Location = new Point(79, 169);
            textBoxDescCliente.MaxLength = 50;
            textBoxDescCliente.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDescCliente.Multiline = false;
            textBoxDescCliente.Name = "textBoxDescCliente";
            textBoxDescCliente.ReadOnly = true;
            textBoxDescCliente.Size = new Size(473, 36);
            textBoxDescCliente.TabIndex = 14;
            textBoxDescCliente.Text = "";
            textBoxDescCliente.TrailingIcon = null;
            textBoxDescCliente.UseTallSize = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(803, 253);
            label1.Name = "label1";
            label1.Size = new Size(58, 28);
            label1.TabIndex = 16;
            label1.Text = "Total:";
            // 
            // labelTotal
            // 
            labelTotal.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            labelTotal.ForeColor = Color.Firebrick;
            labelTotal.Location = new Point(879, 247);
            labelTotal.Name = "labelTotal";
            labelTotal.RightToLeft = RightToLeft.No;
            labelTotal.Size = new Size(260, 41);
            labelTotal.TabIndex = 17;
            labelTotal.Text = "0.00";
            labelTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(79, 211);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(244, 30);
            dateTimePicker1.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 214);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 19;
            label3.Text = "Fecha:";
            // 
            // buttonBuscarCitas
            // 
            buttonBuscarCitas.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonBuscarCitas.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonBuscarCitas.Depth = 0;
            buttonBuscarCitas.HighEmphasis = true;
            buttonBuscarCitas.Icon = null;
            buttonBuscarCitas.Location = new Point(16, 124);
            buttonBuscarCitas.Margin = new Padding(4, 6, 4, 6);
            buttonBuscarCitas.MouseState = MaterialSkin.MouseState.HOVER;
            buttonBuscarCitas.Name = "buttonBuscarCitas";
            buttonBuscarCitas.NoAccentTextColor = Color.Empty;
            buttonBuscarCitas.Size = new Size(113, 36);
            buttonBuscarCitas.TabIndex = 20;
            buttonBuscarCitas.Text = "Buscar cita";
            buttonBuscarCitas.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonBuscarCitas.UseAccentColor = false;
            buttonBuscarCitas.UseVisualStyleBackColor = true;
            buttonBuscarCitas.Click += buttonBuscarCitas_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 177);
            label4.Name = "label4";
            label4.Size = new Size(58, 20);
            label4.TabIndex = 15;
            label4.Text = "Cliente:";
            // 
            // labelTiempoEstimado
            // 
            labelTiempoEstimado.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelTiempoEstimado.ForeColor = Color.DimGray;
            labelTiempoEstimado.Location = new Point(879, 124);
            labelTiempoEstimado.Name = "labelTiempoEstimado";
            labelTiempoEstimado.RightToLeft = RightToLeft.No;
            labelTiempoEstimado.Size = new Size(260, 41);
            labelTiempoEstimado.TabIndex = 22;
            labelTiempoEstimado.Text = "0.00";
            labelTiempoEstimado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(579, 130);
            label7.Name = "label7";
            label7.Size = new Size(282, 28);
            label7.TabIndex = 21;
            label7.Text = "Tiempo estimado (en minutos):";
            // 
            // labelSinDescuento
            // 
            labelSinDescuento.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelSinDescuento.ForeColor = Color.DimGray;
            labelSinDescuento.Location = new Point(879, 165);
            labelSinDescuento.Name = "labelSinDescuento";
            labelSinDescuento.RightToLeft = RightToLeft.No;
            labelSinDescuento.Size = new Size(260, 41);
            labelSinDescuento.TabIndex = 26;
            labelSinDescuento.Text = "0.00";
            labelSinDescuento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(683, 171);
            label8.Name = "label8";
            label8.Size = new Size(178, 28);
            label8.TabIndex = 25;
            label8.Text = "Total sin descuento";
            // 
            // labelDescuento
            // 
            labelDescuento.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            labelDescuento.ForeColor = Color.DimGray;
            labelDescuento.Location = new Point(879, 206);
            labelDescuento.Name = "labelDescuento";
            labelDescuento.RightToLeft = RightToLeft.No;
            labelDescuento.Size = new Size(260, 41);
            labelDescuento.TabIndex = 28;
            labelDescuento.Text = "0.00";
            labelDescuento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(757, 212);
            label9.Name = "label9";
            label9.Size = new Size(104, 28);
            label9.TabIndex = 27;
            label9.Text = "Descuento";
            // 
            // FFacturacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 623);
            Controls.Add(labelDescuento);
            Controls.Add(label9);
            Controls.Add(labelSinDescuento);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(labelTiempoEstimado);
            Controls.Add(textBoxDescSala);
            Controls.Add(buttonBuscarCitas);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1);
            Controls.Add(labelTotal);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(textBoxDescCliente);
            Controls.Add(groupBox2);
            Name = "FFacturacion";
            Text = "Facturación de citas";
            Load += FAgendarCitas_Load;
            Controls.SetChildIndex(groupBox2, 0);
            Controls.SetChildIndex(textBoxDescCliente, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(labelTotal, 0);
            Controls.SetChildIndex(dateTimePicker1, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(buttonBuscarCitas, 0);
            Controls.SetChildIndex(textBoxDescSala, 0);
            Controls.SetChildIndex(labelTiempoEstimado, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(progressBar, 0);
            Controls.SetChildIndex(label8, 0);
            Controls.SetChildIndex(labelSinDescuento, 0);
            Controls.SetChildIndex(label9, 0);
            Controls.SetChildIndex(labelDescuento, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBox2.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            tabPageServicios.ResumeLayout(false);
            tabPageServicios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServicio).EndInit();
            groupBox1.ResumeLayout(false);
            tabPageArticulos.ResumeLayout(false);
            tabPageArticulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulo).EndInit();
            groupBox3.ResumeLayout(false);
            tabPagePersonal.ResumeLayout(false);
            tabPagePersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpleado).EndInit();
            groupBox4.ResumeLayout(false);
            tabPageSala.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            tabPageDetallesGuarderia.ResumeLayout(false);
            tabPageDetallesGuarderia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGuardería).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescCliente;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPageServicios;
        private TabPage tabPageArticulos;
        private TabPage tabPagePersonal;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox8;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox9;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox10;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox11;
        private GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescServicio;
        private Utilidades.Controles.BBuscar bBuscarServicio;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoServicio;
        private DataGridView dataGridViewServicio;
        private Label label1;
        private Label labelTotal;
        private DataGridViewTextBoxColumn ColumnCodigoServicio;
        private DataGridViewTextBoxColumn ColumnDescServicio;
        private DataGridViewTextBoxColumn ColumnPrecioServicio;
        private MaterialSkin.Controls.MaterialButton buttonAgregarServicio;
        private MaterialSkin.Controls.MaterialButton buttonEliminarServicio;
        private MaterialSkin.Controls.MaterialButton buttonAgregarArticulo;
        private MaterialSkin.Controls.MaterialButton buttonEliminarArticulo;
        private DataGridView dataGridViewArticulo;
        private GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescArticulo;
        private Utilidades.Controles.BBuscar bBuscarArticulo;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoArticulo;
        private Label label2;
        private MaterialSkin.Controls.MaterialTextBox textBoxCantidad;
        private DataGridViewTextBoxColumn ColumnCodigoArticulo;
        private DataGridViewTextBoxColumn ColumnDescripcionArticulo;
        private DataGridViewTextBoxColumn ColumnPrecioArticulo;
        private DataGridViewTextBoxColumn ColumnCantidadArticulo;
        private DataGridViewTextBoxColumn ColumnImporteArticulo;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescEmpleado;
        private Utilidades.Controles.BBuscar bBuscarEmpleado;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoEmpleado;
        private GroupBox groupBox4;
        private MaterialSkin.Controls.MaterialButton buttonAgregarEmpleado;
        private MaterialSkin.Controls.MaterialButton buttonEliminarEmpleado;
        private DataGridView dataGridViewEmpleado;
        private DataGridViewTextBoxColumn ColumnCodigoEmpleado;
        private DataGridViewTextBoxColumn ColumnDescEmpleado;
        private DataGridViewTextBoxColumn ColumnPuestoEmpleado;
        private TabPage tabPageSala;
        private MaterialSkin.Controls.MaterialButton buttonBuscarCitas;
        private Label label5;
        private GroupBox groupBox5;
        private MaterialSkin.Controls.MaterialMultiLineTextBox multiLineTextBoxObservaciones;
        private MaterialSkin.Controls.MaterialTextBox textBoxDescSala;
        private Label label4;
        private TabPage tabPageDetallesGuarderia;
        private DataGridView dataGridViewGuardería;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private DataGridViewTextBoxColumn columnSecuenciaGuarderia;
        private DataGridViewTextBoxColumn columnTutor;
        private DataGridViewTextBoxColumn columnInfante;
        private Label labelTiempoEstimado;
        private Label label7;
        private Label labelSinDescuento;
        private Label label8;
        private Label labelDescuento;
        private Label label9;
    }
}