using MaterialSkin.Controls;
using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;
using System.Data;

namespace ProyectoIntegrador.Consultas.Forms
{
    public partial class FCitasConsulta : MaterialForm
    {
        private IEnumerable<Cita> data = [];
        private CitaConsultableModel citaConsultable = new();
        private ArticuloModel articuloModel = new();
        private ServicioModel servicioModel = new();

        public FCitasConsulta()
        {
            InitializeComponent();
            this.CargarData();
            this.switchFiltrarFecha.Checked = false;
            consultauc1.OnSelectResult += Consultauc1_OnSelectResult;
        }

        private void Consultauc1_OnSelectResult(object? sender, DataRow e)
        {
            Cita? selected = this.citaConsultable.RetrieveData(e);
            if (selected is null)
                return;

            var artMsg = this.articuloModel.CargarDatos(selected);
            if(!artMsg.State)
            {
                AlertaController.AlertaError(this, artMsg.Msg);
                return;
            }

            var srvMsg = this.servicioModel.CargarDatos(selected);
            if(!srvMsg.State)
            {
                AlertaController.AlertaError(this, srvMsg.Msg);
                return;
            }

            this.dataGridViewArticulo.Rows.Clear();
            // Articulo
            foreach (var item in artMsg.Entity ?? [])
            {
                int index = this.dataGridViewArticulo.Rows.Add();
                this.dataGridViewArticulo[ColumnCodigoArticulo.Index, index].Value = item.Data.cod_art;
                this.dataGridViewArticulo[ColumnDescArticulo.Index, index].Value = item.Data.descripcion_art;
                this.dataGridViewArticulo[ColumnCantidadArticulo.Index, index].Value = item.Cantidad.ToString(Formatos.formatoMoneda);
                this.dataGridViewArticulo[ColumnPrecioUnitario.Index, index].Value = item.Data.precio_art.ToString(Formatos.formatoMoneda);
                this.dataGridViewArticulo[ColumnImporteArt.Index, index].Value = (item.Cantidad * item.Data.precio_art).ToString(Formatos.formatoMoneda);
            }

            this.dataGridViewServicio.Rows.Clear();
            // Servicio
            foreach (var item in srvMsg.Entity ?? [])
            {
                int index = this.dataGridViewServicio.Rows.Add();
                this.dataGridViewServicio[ColumnCodigoServicio.Index, index].Value = item.cod_ser;
                this.dataGridViewServicio[ColumnDescServicio.Index, index].Value = item.desc_ser;
                this.dataGridViewServicio[ColumnPrecioServicio.Index, index].Value = item.preciobase_ser;
            }
        }

        private void CargarData()
        {
            var msg = this.citaConsultable.CargarDatos();
            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }

            this.data = msg.Entity ?? [];
            this.RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // hasta
            this.RefreshData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // desde
            this.RefreshData();
        }

        private void swtichFiltrarFecha_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = switchFiltrarFecha.Checked;
        }

        private void RefreshData()
        {
            IEnumerable<Cita> data;
            if (this.switchFiltrarFecha.Checked)
            {
                DateTime desde = dateTimePicker1.Value.Date;
                DateTime hasta = dateTimePicker2.Value.Date;
                data = this.data.Where
                        (cit => cit.fecha_cita <= hasta && cit.fecha_cita >= desde);
            }
            else
            {
                data = this.data;
            }
            this.consultauc1.SetDataSource(
                this.citaConsultable.GetDataTable
                (
                    data
                )
            );

            this.dataGridViewArticulo.Rows.Clear();
            this.dataGridViewServicio.Rows.Clear();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void consultauc1_Load(object sender, EventArgs e)
        {

        }

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
