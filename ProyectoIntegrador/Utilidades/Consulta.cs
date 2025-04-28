using MaterialSkin.Controls;
using Modelos;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Presentacion.Support
{
    public partial class Consulta : MaterialForm, IConsultable, IDisposable
    {
        private readonly DataTable values;
        private readonly ItemFiltroTodos filtroTodos = new();
        private DataRow? selectedValue;
        public bool ForConsult = false;

        public string? DefaultColumnOrder { get; set; }
        public ListSortDirection DefaultListSortDirection { get; set; }

        public event EventHandler<object?>? OnRowSelected;

        public Consulta(DataTable values, string? defaultColumnFilter = null, string? title = null, bool df_order = true)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = values;

            this.comboBoxOrden.Items.Clear();
            this.comboBoxFiltro.Items.Clear();

            // Agregar el filtro de Todos los campos
            this.comboBoxFiltro.Items.Add(filtroTodos);
            // Seleccionarlo
            this.comboBoxFiltro.SelectedItem = filtroTodos;

            // Agregar los demás campos
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                this.comboBoxOrden.Items.Add(column.Name);
                this.comboBoxFiltro.Items.Add(column.Name);
            }

            this.comboBoxOrden.SelectedIndex = 0;
            if (defaultColumnFilter != null)
            {
                FormUtils.SelectItemInComboBox(this.comboBoxOrden, defaultColumnFilter, str => str.Equals(defaultColumnFilter));
            }
            this.values = values;
            this.textBoxFilter.TextChanged += TextBoxFilter_TextChanged;

            if (title != null)
                this.Text = title;

            this.checkBoxAsc.Checked = !df_order;
            this.checkboxDesc.Checked = df_order;

            FormatearColumnasDataGridView(dataGridView1, values);
        }
        private void TextBoxFilter_TextChanged(object? sender, EventArgs e)
        {
            this.Filter();
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            if (!(this.comboBoxOrden.Items.Count > 0)) return;
            if (this.comboBoxOrden.SelectedItem == null) return;
            var columnname = this.comboBoxOrden.SelectedItem.ToString();
            var sort = this.checkBoxAsc.Checked ? "ASC" : "DESC";
            this.dataGridView1.Sort(this.dataGridView1.Columns[columnname], sort == "ASC" ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }

        private void Filter()
        {
            errorProvider1.Clear();
            DataView view = new DataView(this.values);
            string text = this.textBoxFilter.Text;
            if (text.Trim().Length > 0)
            {

                StringBuilder query = new();
                string searchvalue = text;
                if (this.comboBoxFiltro.SelectedItem == this.filtroTodos)
                {
                    for (int i = 0; i < view.Table!.Columns.Count; i++)
                    {
                        var item = view.Table.Columns[i];

                        query.Append($"CONVERT([{item.ColumnName}],System.String) LIKE '%{searchvalue}%' ");

                        if (i != view.Table.Columns.Count - 1)
                        {
                            query.Append(" OR ");
                        }
                    }
                }
                else
                {
                    query.Append($"CONVERT([{this.comboBoxFiltro.SelectedItem}],System.String) LIKE '%{searchvalue}%' ");
                }

                try
                {
                    view.RowFilter = query.ToString();
                }
                catch (EvaluateException)
                {
                    errorProvider1.SetError(this.groupBox2, "Formato incorrecto");
                }
            }
            this.dataGridView1.DataSource = view;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.selectedValue = ((DataRowView)this.dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                if (!this.ForConsult)
                {
                    this.Hide();
                }
                else
                {
                    OnRowSelected?.Invoke(this, this.selectedValue);
                }
            }
        }

        public DataRow? GetSelectedRow()
        {
            return this.selectedValue;
        }

        private void CheckBoxAsc_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void CheckboxDesc_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void TextBoxFilter_KeyUp(object sender, KeyPressEventArgs e)
        {

        }

        void IConsultable.ShowDialog()
        {
            this.ShowDialog();
        }

        private void FormatearColumnasDataGridView(DataGridView dataGridView, DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                // Encuentra la columna correspondiente en el DataGridView
                var gridColumn = dataGridView.Columns[column.ColumnName];
                if (gridColumn != null)
                {
                    // Aplica formato según el tipo de datos
                    if (column.DataType == typeof(decimal) || column.DataType == typeof(double) || column.DataType == typeof(float))
                    {
                        gridColumn.DefaultCellStyle.Format = "N2"; // Formato numérico con 2 decimales
                    }
                    else if (column.DataType == typeof(DateTime))
                    {
                        gridColumn.DefaultCellStyle.Format = "dd/MM/yyyy"; // Formato de fecha
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxOrden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    internal class ItemFiltroTodos
    {
        public override string ToString()
        {
            return "Todos";
        }
    }

    internal interface IConsultable
    {
        DataRow? GetSelectedRow();
        string DefaultColumnOrder { get; set; }
        ListSortDirection DefaultListSortDirection { get; set; }

        public void ShowDialog();
    }
}
