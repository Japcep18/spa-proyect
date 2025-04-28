using MaterialSkin.Controls;
using Presentacion.Support;
using System.ComponentModel;
using System.Data;

namespace ProyectoIntegrador.Utilidades
{
    public partial class ConsultaGeneral : MaterialForm, IConsultable
    {
        public string DefaultColumnOrder { get => consultauc1.DefaultColumnOrder; set => consultauc1.DefaultColumnOrder = value; }
        public ListSortDirection DefaultListSortDirection { get => consultauc1.AscDefaultOrder ? ListSortDirection.Ascending : ListSortDirection.Descending; set { consultauc1.AscDefaultOrder = value == ListSortDirection.Ascending; } }

        public event EventHandler<DataRow?>? OnRowSelected;

        public bool ForConsult { get; set; }

        public ConsultaGeneral(DataTable values)
        {
            InitializeComponent();
            this.consultauc1.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            this.consultauc1.OnSelectResult += delegate 
            { 
                OnRowSelected?.Invoke(this, this.consultauc1.GetSelectedRow());
            };
            this.SetData(values);
        }

        public ConsultaGeneral()
        {
            InitializeComponent();
            this.consultauc1.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
        }

        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (!this.ForConsult)
                {
                    this.Hide();
                }
                //else
                //{
                //    // OnRowSelected?.Invoke(this, this.consultauc1.GetSelectedRow());
                //}
            }
        }

        public void SetData(DataTable values)
        {
            this.consultauc1.SetDataSource(values);
        }

        public DataRow? GetSelectedRow()
        {
            return this.consultauc1.GetSelectedRow();
        }

        void IConsultable.ShowDialog()
        {
            this.ShowDialog();
        }
    }
}
