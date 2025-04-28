using Presentacion.Support;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace ProyectoIntegrador.Utilidades.Controles
{
    public partial class ConsultaUC : UserControl
    {
        private DataTable data = new();
        private DataRow? selectedValue;

        public string DefaultColumnOrder { get; set; }
        public bool AscDefaultOrder { get; set; }

        private readonly ItemFiltroTodos filtroTodos = new();

        public event EventHandler<DataRow>? OnSelectResult;

        public ConsultaUC()
        {
            InitializeComponent();
            this.textBoxFilter.TextChanged += TextBoxFilter_TextChanged;
        }

        private void TextBoxFilter_TextChanged(object? sender, EventArgs e) => this.Filter();

        public void SetDataSource(DataTable data)
        {
            this.data = data;
            this.dataGridView1.DataSource = data;
            this.RenderFilterAndOrderControls();
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
            DataView view = new DataView(this.data);
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
        public DataRow? GetSelectedRow()
        {
            return this.selectedValue;
        }

        public void RenderFilterAndOrderControls()
        {
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
            if (DefaultColumnOrder != null)
            {
                FormUtils.SelectItemInComboBox(this.comboBoxOrden, DefaultColumnOrder, str => str.Equals(DefaultColumnOrder));
            }

            this.checkBoxAsc.Checked = !AscDefaultOrder;
            this.checkboxDesc.Checked = AscDefaultOrder;
        }

        private void comboBoxFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void comboBoxOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void checkBoxAsc_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void textBoxFilter_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.OnSelectResult?.Invoke(sender, ((DataRowView)this.dataGridView1.Rows[e.RowIndex].DataBoundItem).Row);
        }
    }
}
