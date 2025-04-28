namespace ProyectoIntegrador.Inventario
{
    partial class FEntidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEntidad));
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            bBuscar1 = new Utilidades.Controles.BBuscar();
            textBoxCodigoEnt = new MaterialSkin.Controls.MaterialTextBox();
            textBoxNombreEnt = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCedulaEnt = new MaterialSkin.Controls.MaterialTextBox();
            CBGenero = new MaterialSkin.Controls.MaterialComboBox();
            CheckboxEspersona = new MaterialSkin.Controls.MaterialCheckbox();
            CheckboxActivo = new MaterialSkin.Controls.MaterialCheckbox();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            fechaNacEnt = new DateTimePicker();
            textBoxSectorDesc = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar4 = new Utilidades.Controles.BBuscar();
            textBoxCodigoSector = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigoCiudad = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar2 = new Utilidades.Controles.BBuscar();
            textBoxCiudadDesc = new MaterialSkin.Controls.MaterialTextBox();
            textBoxCodigoMunicipio = new MaterialSkin.Controls.MaterialTextBox();
            bBuscar3 = new Utilidades.Controles.BBuscar();
            textBoxMunicipioDesc = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            textBoxDireccion = new MaterialSkin.Controls.MaterialTextBox();
            groupBoxSector = new GroupBox();
            groupBoxMunicipio = new GroupBox();
            groupBoxCiudad = new GroupBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            groupBoxSector.SuspendLayout();
            groupBoxMunicipio.SuspendLayout();
            groupBoxCiudad.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(3, 111);
            progressBar.Size = new Size(709, 5);
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(20, 154);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(55, 19);
            materialLabel1.TabIndex = 10;
            materialLabel1.Text = "Codigo:";
            materialLabel1.Click += materialLabel1_Click;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(257, 158);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(61, 19);
            materialLabel2.TabIndex = 11;
            materialLabel2.Text = "Nombre:";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(19, 549);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(58, 19);
            materialLabel3.TabIndex = 12;
            materialLabel3.Text = "Cedula: ";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(6, 31);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(55, 19);
            materialLabel4.TabIndex = 13;
            materialLabel4.Text = "Genero:";
            // 
            // bBuscar1
            // 
            bBuscar1.Image = (Image)resources.GetObject("bBuscar1.Image");
            bBuscar1.Location = new Point(203, 145);
            bBuscar1.Name = "bBuscar1";
            bBuscar1.Size = new Size(39, 40);
            bBuscar1.TabIndex = 16;
            bBuscar1.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoEnt
            // 
            textBoxCodigoEnt.AnimateReadOnly = false;
            textBoxCodigoEnt.BorderStyle = BorderStyle.None;
            textBoxCodigoEnt.Depth = 0;
            textBoxCodigoEnt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoEnt.LeadingIcon = null;
            textBoxCodigoEnt.Location = new Point(76, 140);
            textBoxCodigoEnt.MaxLength = 50;
            textBoxCodigoEnt.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoEnt.Multiline = false;
            textBoxCodigoEnt.Name = "textBoxCodigoEnt";
            textBoxCodigoEnt.Size = new Size(121, 50);
            textBoxCodigoEnt.TabIndex = 17;
            textBoxCodigoEnt.Text = "";
            textBoxCodigoEnt.TrailingIcon = null;
            // 
            // textBoxNombreEnt
            // 
            textBoxNombreEnt.AnimateReadOnly = false;
            textBoxNombreEnt.BorderStyle = BorderStyle.None;
            textBoxNombreEnt.Depth = 0;
            textBoxNombreEnt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxNombreEnt.LeadingIcon = null;
            textBoxNombreEnt.Location = new Point(324, 140);
            textBoxNombreEnt.MaxLength = 50;
            textBoxNombreEnt.MouseState = MaterialSkin.MouseState.OUT;
            textBoxNombreEnt.Multiline = false;
            textBoxNombreEnt.Name = "textBoxNombreEnt";
            textBoxNombreEnt.Size = new Size(325, 50);
            textBoxNombreEnt.TabIndex = 18;
            textBoxNombreEnt.Text = "";
            textBoxNombreEnt.TrailingIcon = null;
            // 
            // textBoxCedulaEnt
            // 
            textBoxCedulaEnt.AnimateReadOnly = false;
            textBoxCedulaEnt.BorderStyle = BorderStyle.None;
            textBoxCedulaEnt.Depth = 0;
            textBoxCedulaEnt.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCedulaEnt.LeadingIcon = null;
            textBoxCedulaEnt.Location = new Point(105, 536);
            textBoxCedulaEnt.MaxLength = 13;
            textBoxCedulaEnt.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCedulaEnt.Multiline = false;
            textBoxCedulaEnt.Name = "textBoxCedulaEnt";
            textBoxCedulaEnt.Size = new Size(192, 50);
            textBoxCedulaEnt.TabIndex = 19;
            textBoxCedulaEnt.Text = "";
            textBoxCedulaEnt.TrailingIcon = null;
            textBoxCedulaEnt.TextChanged += textBoxCedulaEnt_TextChanged;
            // 
            // CBGenero
            // 
            CBGenero.AutoResize = false;
            CBGenero.BackColor = Color.FromArgb(255, 255, 255);
            CBGenero.Depth = 0;
            CBGenero.DrawMode = DrawMode.OwnerDrawVariable;
            CBGenero.DropDownHeight = 174;
            CBGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            CBGenero.DropDownWidth = 121;
            CBGenero.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            CBGenero.ForeColor = Color.FromArgb(222, 0, 0, 0);
            CBGenero.FormattingEnabled = true;
            CBGenero.IntegralHeight = false;
            CBGenero.ItemHeight = 43;
            CBGenero.Location = new Point(163, 13);
            CBGenero.MaxDropDownItems = 4;
            CBGenero.MouseState = MaterialSkin.MouseState.OUT;
            CBGenero.Name = "CBGenero";
            CBGenero.Size = new Size(192, 49);
            CBGenero.StartIndex = 0;
            CBGenero.TabIndex = 20;
            CBGenero.SelectedIndexChanged += CBGenero_SelectedIndexChanged;
            // 
            // CheckboxEspersona
            // 
            CheckboxEspersona.AutoSize = true;
            CheckboxEspersona.Checked = true;
            CheckboxEspersona.CheckState = CheckState.Checked;
            CheckboxEspersona.Depth = 0;
            CheckboxEspersona.Location = new Point(137, 605);
            CheckboxEspersona.Margin = new Padding(0);
            CheckboxEspersona.MouseLocation = new Point(-1, -1);
            CheckboxEspersona.MouseState = MaterialSkin.MouseState.HOVER;
            CheckboxEspersona.Name = "CheckboxEspersona";
            CheckboxEspersona.ReadOnly = false;
            CheckboxEspersona.Ripple = true;
            CheckboxEspersona.Size = new Size(160, 37);
            CheckboxEspersona.TabIndex = 21;
            CheckboxEspersona.Text = "¿Es una persona?";
            CheckboxEspersona.UseVisualStyleBackColor = true;
            CheckboxEspersona.CheckedChanged += CheckboxEspersona_CheckedChanged;
            // 
            // CheckboxActivo
            // 
            CheckboxActivo.AutoSize = true;
            CheckboxActivo.Checked = true;
            CheckboxActivo.CheckState = CheckState.Checked;
            CheckboxActivo.Depth = 0;
            CheckboxActivo.Location = new Point(19, 608);
            CheckboxActivo.Margin = new Padding(0);
            CheckboxActivo.MouseLocation = new Point(-1, -1);
            CheckboxActivo.MouseState = MaterialSkin.MouseState.HOVER;
            CheckboxActivo.Name = "CheckboxActivo";
            CheckboxActivo.ReadOnly = false;
            CheckboxActivo.Ripple = true;
            CheckboxActivo.Size = new Size(79, 37);
            CheckboxActivo.TabIndex = 22;
            CheckboxActivo.Text = "Activo";
            CheckboxActivo.UseVisualStyleBackColor = true;
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(6, 83);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(152, 19);
            materialLabel5.TabIndex = 23;
            materialLabel5.Text = "Fecha de nacimiento:";
            // 
            // fechaNacEnt
            // 
            fechaNacEnt.CustomFormat = "dd/MM/yy";
            fechaNacEnt.Font = new Font("Segoe UI", 10F);
            fechaNacEnt.Format = DateTimePickerFormat.Custom;
            fechaNacEnt.Location = new Point(163, 79);
            fechaNacEnt.Name = "fechaNacEnt";
            fechaNacEnt.Size = new Size(192, 30);
            fechaNacEnt.TabIndex = 24;
            // 
            // textBoxSectorDesc
            // 
            textBoxSectorDesc.AnimateReadOnly = false;
            textBoxSectorDesc.BorderStyle = BorderStyle.None;
            textBoxSectorDesc.Depth = 0;
            textBoxSectorDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxSectorDesc.LeadingIcon = null;
            textBoxSectorDesc.Location = new Point(200, 26);
            textBoxSectorDesc.MaxLength = 50;
            textBoxSectorDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxSectorDesc.Multiline = false;
            textBoxSectorDesc.Name = "textBoxSectorDesc";
            textBoxSectorDesc.Size = new Size(439, 50);
            textBoxSectorDesc.TabIndex = 27;
            textBoxSectorDesc.Text = "";
            textBoxSectorDesc.TrailingIcon = null;
            // 
            // bBuscar4
            // 
            bBuscar4.Image = (Image)resources.GetObject("bBuscar4.Image");
            bBuscar4.Location = new Point(146, 31);
            bBuscar4.Name = "bBuscar4";
            bBuscar4.Size = new Size(39, 41);
            bBuscar4.TabIndex = 28;
            bBuscar4.UseVisualStyleBackColor = true;
            // 
            // textBoxCodigoSector
            // 
            textBoxCodigoSector.AnimateReadOnly = false;
            textBoxCodigoSector.BorderStyle = BorderStyle.None;
            textBoxCodigoSector.Depth = 0;
            textBoxCodigoSector.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoSector.LeadingIcon = null;
            textBoxCodigoSector.Location = new Point(19, 26);
            textBoxCodigoSector.MaxLength = 50;
            textBoxCodigoSector.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoSector.Multiline = false;
            textBoxCodigoSector.Name = "textBoxCodigoSector";
            textBoxCodigoSector.Size = new Size(121, 50);
            textBoxCodigoSector.TabIndex = 29;
            textBoxCodigoSector.Text = "";
            textBoxCodigoSector.TrailingIcon = null;
            // 
            // textBoxCodigoCiudad
            // 
            textBoxCodigoCiudad.AnimateReadOnly = false;
            textBoxCodigoCiudad.BorderStyle = BorderStyle.None;
            textBoxCodigoCiudad.Depth = 0;
            textBoxCodigoCiudad.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoCiudad.LeadingIcon = null;
            textBoxCodigoCiudad.Location = new Point(19, 18);
            textBoxCodigoCiudad.MaxLength = 50;
            textBoxCodigoCiudad.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoCiudad.Multiline = false;
            textBoxCodigoCiudad.Name = "textBoxCodigoCiudad";
            textBoxCodigoCiudad.Size = new Size(121, 50);
            textBoxCodigoCiudad.TabIndex = 33;
            textBoxCodigoCiudad.Text = "";
            textBoxCodigoCiudad.TrailingIcon = null;
            // 
            // bBuscar2
            // 
            bBuscar2.Image = (Image)resources.GetObject("bBuscar2.Image");
            bBuscar2.Location = new Point(146, 23);
            bBuscar2.Name = "bBuscar2";
            bBuscar2.Size = new Size(39, 41);
            bBuscar2.TabIndex = 32;
            bBuscar2.UseVisualStyleBackColor = true;
            // 
            // textBoxCiudadDesc
            // 
            textBoxCiudadDesc.AnimateReadOnly = false;
            textBoxCiudadDesc.BorderStyle = BorderStyle.None;
            textBoxCiudadDesc.Depth = 0;
            textBoxCiudadDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCiudadDesc.LeadingIcon = null;
            textBoxCiudadDesc.Location = new Point(200, 18);
            textBoxCiudadDesc.MaxLength = 50;
            textBoxCiudadDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCiudadDesc.Multiline = false;
            textBoxCiudadDesc.Name = "textBoxCiudadDesc";
            textBoxCiudadDesc.Size = new Size(439, 50);
            textBoxCiudadDesc.TabIndex = 31;
            textBoxCiudadDesc.Text = "";
            textBoxCiudadDesc.TrailingIcon = null;
            // 
            // textBoxCodigoMunicipio
            // 
            textBoxCodigoMunicipio.AnimateReadOnly = false;
            textBoxCodigoMunicipio.BorderStyle = BorderStyle.None;
            textBoxCodigoMunicipio.Depth = 0;
            textBoxCodigoMunicipio.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxCodigoMunicipio.LeadingIcon = null;
            textBoxCodigoMunicipio.Location = new Point(19, 26);
            textBoxCodigoMunicipio.MaxLength = 50;
            textBoxCodigoMunicipio.MouseState = MaterialSkin.MouseState.OUT;
            textBoxCodigoMunicipio.Multiline = false;
            textBoxCodigoMunicipio.Name = "textBoxCodigoMunicipio";
            textBoxCodigoMunicipio.Size = new Size(121, 50);
            textBoxCodigoMunicipio.TabIndex = 37;
            textBoxCodigoMunicipio.Text = "";
            textBoxCodigoMunicipio.TrailingIcon = null;
            // 
            // bBuscar3
            // 
            bBuscar3.Image = (Image)resources.GetObject("bBuscar3.Image");
            bBuscar3.Location = new Point(146, 31);
            bBuscar3.Name = "bBuscar3";
            bBuscar3.Size = new Size(39, 41);
            bBuscar3.TabIndex = 36;
            bBuscar3.UseVisualStyleBackColor = true;
            // 
            // textBoxMunicipioDesc
            // 
            textBoxMunicipioDesc.AnimateReadOnly = false;
            textBoxMunicipioDesc.BorderStyle = BorderStyle.None;
            textBoxMunicipioDesc.Depth = 0;
            textBoxMunicipioDesc.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxMunicipioDesc.LeadingIcon = null;
            textBoxMunicipioDesc.Location = new Point(200, 26);
            textBoxMunicipioDesc.MaxLength = 50;
            textBoxMunicipioDesc.MouseState = MaterialSkin.MouseState.OUT;
            textBoxMunicipioDesc.Multiline = false;
            textBoxMunicipioDesc.Name = "textBoxMunicipioDesc";
            textBoxMunicipioDesc.Size = new Size(439, 50);
            textBoxMunicipioDesc.TabIndex = 35;
            textBoxMunicipioDesc.Text = "";
            textBoxMunicipioDesc.TrailingIcon = null;
            // 
            // materialLabel9
            // 
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(19, 494);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(71, 19);
            materialLabel9.TabIndex = 38;
            materialLabel9.Text = "Dirección:";
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.AnimateReadOnly = false;
            textBoxDireccion.BorderStyle = BorderStyle.None;
            textBoxDireccion.Depth = 0;
            textBoxDireccion.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxDireccion.LeadingIcon = null;
            textBoxDireccion.Location = new Point(101, 476);
            textBoxDireccion.MaxLength = 150;
            textBoxDireccion.MouseState = MaterialSkin.MouseState.OUT;
            textBoxDireccion.Multiline = false;
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(577, 50);
            textBoxDireccion.TabIndex = 39;
            textBoxDireccion.Text = "";
            textBoxDireccion.TrailingIcon = null;
            // 
            // groupBoxSector
            // 
            groupBoxSector.Controls.Add(textBoxCodigoSector);
            groupBoxSector.Controls.Add(textBoxSectorDesc);
            groupBoxSector.Controls.Add(bBuscar4);
            groupBoxSector.Location = new Point(20, 377);
            groupBoxSector.Name = "groupBoxSector";
            groupBoxSector.Size = new Size(657, 88);
            groupBoxSector.TabIndex = 40;
            groupBoxSector.TabStop = false;
            groupBoxSector.Text = "Sector:";
            // 
            // groupBoxMunicipio
            // 
            groupBoxMunicipio.Controls.Add(textBoxCodigoMunicipio);
            groupBoxMunicipio.Controls.Add(bBuscar3);
            groupBoxMunicipio.Controls.Add(textBoxMunicipioDesc);
            groupBoxMunicipio.Location = new Point(20, 287);
            groupBoxMunicipio.Name = "groupBoxMunicipio";
            groupBoxMunicipio.Size = new Size(659, 84);
            groupBoxMunicipio.TabIndex = 41;
            groupBoxMunicipio.TabStop = false;
            groupBoxMunicipio.Text = "Municipio:";
            // 
            // groupBoxCiudad
            // 
            groupBoxCiudad.Controls.Add(textBoxCiudadDesc);
            groupBoxCiudad.Controls.Add(bBuscar2);
            groupBoxCiudad.Controls.Add(textBoxCodigoCiudad);
            groupBoxCiudad.Location = new Point(20, 207);
            groupBoxCiudad.Name = "groupBoxCiudad";
            groupBoxCiudad.Size = new Size(659, 74);
            groupBoxCiudad.TabIndex = 42;
            groupBoxCiudad.TabStop = false;
            groupBoxCiudad.Text = "Ciudad:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(materialLabel4);
            groupBox1.Controls.Add(materialLabel5);
            groupBox1.Controls.Add(CBGenero);
            groupBox1.Controls.Add(fechaNacEnt);
            groupBox1.Location = new Point(318, 536);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(361, 118);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            // 
            // FEntidad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(715, 682);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxCiudad);
            Controls.Add(groupBoxMunicipio);
            Controls.Add(groupBoxSector);
            Controls.Add(textBoxDireccion);
            Controls.Add(materialLabel9);
            Controls.Add(CheckboxActivo);
            Controls.Add(CheckboxEspersona);
            Controls.Add(textBoxCedulaEnt);
            Controls.Add(textBoxNombreEnt);
            Controls.Add(textBoxCodigoEnt);
            Controls.Add(bBuscar1);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Name = "FEntidad";
            Text = "FEntidad";
            Load += FEntidad_Load;
            Controls.SetChildIndex(materialLabel1, 0);
            Controls.SetChildIndex(materialLabel2, 0);
            Controls.SetChildIndex(materialLabel3, 0);
            Controls.SetChildIndex(bBuscar1, 0);
            Controls.SetChildIndex(textBoxCodigoEnt, 0);
            Controls.SetChildIndex(textBoxNombreEnt, 0);
            Controls.SetChildIndex(textBoxCedulaEnt, 0);
            Controls.SetChildIndex(CheckboxEspersona, 0);
            Controls.SetChildIndex(CheckboxActivo, 0);
            Controls.SetChildIndex(materialLabel9, 0);
            Controls.SetChildIndex(textBoxDireccion, 0);
            Controls.SetChildIndex(groupBoxSector, 0);
            Controls.SetChildIndex(groupBoxMunicipio, 0);
            Controls.SetChildIndex(groupBoxCiudad, 0);
            Controls.SetChildIndex(groupBox1, 0);
            Controls.SetChildIndex(progressBar, 0);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            groupBoxSector.ResumeLayout(false);
            groupBoxMunicipio.ResumeLayout(false);
            groupBoxCiudad.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private Utilidades.Controles.BBuscar bBuscar1;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoEnt;
        private MaterialSkin.Controls.MaterialTextBox textBoxNombreEnt;
        private MaterialSkin.Controls.MaterialTextBox textBoxCedulaEnt;
        private MaterialSkin.Controls.MaterialComboBox CBGenero;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxEspersona;
        private MaterialSkin.Controls.MaterialCheckbox CheckboxActivo;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private DateTimePicker fechaNacEnt;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox textBoxSectorDesc;
        private Utilidades.Controles.BBuscar bBuscar4;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoSector;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoCiudad;
        private Utilidades.Controles.BBuscar bBuscar2;
        private MaterialSkin.Controls.MaterialTextBox textBoxCiudadDesc;
        private MaterialSkin.Controls.MaterialTextBox textBoxCodigoMunicipio;
        private Utilidades.Controles.BBuscar bBuscar3;
        private MaterialSkin.Controls.MaterialTextBox textBoxMunicipioDesc;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialTextBox textBoxDireccion;
        private GroupBox groupBoxSector;
        private GroupBox groupBoxMunicipio;
        private GroupBox groupBoxCiudad;
        private GroupBox groupBox1;
    }
}