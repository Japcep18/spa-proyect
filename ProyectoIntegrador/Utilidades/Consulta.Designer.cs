using MaterialSkin.Controls;

namespace Presentacion.Support
{
    partial class Consulta
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            checkboxDesc = new MaterialRadioButton();
            checkBoxAsc = new MaterialRadioButton();
            comboBoxOrden = new ComboBox();
            panel2 = new Panel();
            groupBox2 = new GroupBox();
            label1 = new Label();
            comboBoxFiltro = new ComboBox();
            textBoxFilter = new MaterialTextBox();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 216);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(834, 280);
            panel1.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(834, 280);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkboxDesc);
            groupBox1.Controls.Add(checkBoxAsc);
            groupBox1.Controls.Add(comboBoxOrden);
            groupBox1.Location = new Point(12, 15);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(267, 113);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ordenar por:";
            // 
            // checkboxDesc
            // 
            checkboxDesc.AutoSize = true;
            checkboxDesc.Depth = 0;
            checkboxDesc.Location = new Point(96, 65);
            checkboxDesc.Margin = new Padding(0);
            checkboxDesc.MouseLocation = new Point(-1, -1);
            checkboxDesc.MouseState = MaterialSkin.MouseState.HOVER;
            checkboxDesc.Name = "checkboxDesc";
            checkboxDesc.Ripple = true;
            checkboxDesc.Size = new Size(75, 37);
            checkboxDesc.TabIndex = 3;
            checkboxDesc.Text = "DESC";
            checkboxDesc.UseVisualStyleBackColor = true;
            checkboxDesc.CheckedChanged += CheckboxDesc_CheckedChanged;
            // 
            // checkBoxAsc
            // 
            checkBoxAsc.AutoSize = true;
            checkBoxAsc.Checked = true;
            checkBoxAsc.Depth = 0;
            checkBoxAsc.Location = new Point(10, 65);
            checkBoxAsc.Margin = new Padding(0);
            checkBoxAsc.MouseLocation = new Point(-1, -1);
            checkBoxAsc.MouseState = MaterialSkin.MouseState.HOVER;
            checkBoxAsc.Name = "checkBoxAsc";
            checkBoxAsc.Ripple = true;
            checkBoxAsc.Size = new Size(65, 37);
            checkBoxAsc.TabIndex = 2;
            checkBoxAsc.TabStop = true;
            checkBoxAsc.Text = "ASC";
            checkBoxAsc.UseVisualStyleBackColor = true;
            checkBoxAsc.CheckedChanged += CheckBoxAsc_CheckedChanged;
            // 
            // comboBoxOrden
            // 
            comboBoxOrden.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrden.FormattingEnabled = true;
            comboBoxOrden.Location = new Point(6, 28);
            comboBoxOrden.Margin = new Padding(3, 4, 3, 4);
            comboBoxOrden.Name = "comboBoxOrden";
            comboBoxOrden.Size = new Size(251, 28);
            comboBoxOrden.TabIndex = 1;
            comboBoxOrden.SelectedIndexChanged += comboBoxOrden_SelectedIndexChanged;
            comboBoxOrden.SelectedValueChanged += ComboBox1_SelectedValueChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 80);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(834, 136);
            panel2.TabIndex = 6;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(comboBoxFiltro);
            groupBox2.Controls.Add(textBoxFilter);
            groupBox2.Location = new Point(285, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(546, 114);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Buscar por:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 82);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 5;
            label1.Text = "Filtrar por:";
            // 
            // comboBoxFiltro
            // 
            comboBoxFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiltro.FormattingEnabled = true;
            comboBoxFiltro.Location = new Point(104, 79);
            comboBoxFiltro.Margin = new Padding(3, 4, 3, 4);
            comboBoxFiltro.Name = "comboBoxFiltro";
            comboBoxFiltro.Size = new Size(436, 28);
            comboBoxFiltro.TabIndex = 4;
            comboBoxFiltro.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBoxFilter
            // 
            textBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFilter.AnimateReadOnly = false;
            textBoxFilter.BackColor = SystemColors.Window;
            textBoxFilter.BorderStyle = BorderStyle.None;
            textBoxFilter.Depth = 0;
            textBoxFilter.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            textBoxFilter.LeadingIcon = null;
            textBoxFilter.Location = new Point(6, 26);
            textBoxFilter.MaxLength = 50;
            textBoxFilter.MouseState = MaterialSkin.MouseState.OUT;
            textBoxFilter.Multiline = false;
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(534, 50);
            textBoxFilter.TabIndex = 0;
            textBoxFilter.Text = "";
            textBoxFilter.TrailingIcon = null;
            textBoxFilter.KeyPress += TextBoxFilter_KeyUp;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // Consulta
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(840, 500);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Consulta";
            Padding = new Padding(3, 80, 3, 4);
            Text = "Consulta";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxOrden;
        private System.Windows.Forms.Panel panel2;
        private GroupBox groupBox2;
        private MaterialTextBox textBoxFilter;
        private MaterialSkin.Controls.MaterialRadioButton checkboxDesc;
        private MaterialSkin.Controls.MaterialRadioButton checkBoxAsc;
        private ErrorProvider errorProvider1;
        private ComboBox comboBoxFiltro;
        private Label label1;
    }
}