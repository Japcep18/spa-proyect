using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using Presentacion.Support;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador.Inventario
{
    public partial class FFacturar : BaseForm
    {
        private VentaModel ventaModel = new()
        {
            SoloActivosFiltro = true,
        };
        private ClienteModel clienteModel = new();
        public FFacturar()
        {
            InitializeComponent();
            this.guardarClick += Facturacion_guardarClick;
        }

        private void Facturacion_guardarClick(object? sender, EventArgs e)
        {
            if (this.ventaModel.Model is null)
                return;

            Venta venta = this.ventaModel.Model;
            var msg = this.ventaModel.FacturarVenta(venta);
            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
            }
            else
            {
                ToastController.MostrarInfo(this, Mensajes.Msj_Aviso_RegistroGuardado);
                Nuevo(false);
            }
        }
        private void FFacturar_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }
        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.HabilitarBotones(true, true);
                this.MostrarBotones(true, true);

                this.ventaModel = new();
                this.clienteModel = new();
                this.labelStatus.Text = "Nuevo";
                this.textBoxDescripcion.Text = String.Empty;
            }
            return valor;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bBuscarVenta_Click(object sender, EventArgs e)
        {
            var msg = this.ventaModel.CargarDatos();
            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }

            Consulta consulta = new(DataManager.ToDataTable(msg.Entity ?? []));
            consulta.ShowDialog();

            var selected = consulta.GetSelectedRow();
            if (selected is null)
                return;

            Venta? inst = DataManager.DataRowToObject<Venta>(selected);
            if (inst is null)
                return;

            this.ventaModel.Model = inst;

            string descripcion = $"{inst.cod_ven} - {inst.fecha_ven.ToString(Formatos.formatoFechaHora)}";
            Cliente? cliente = this.clienteModel.Obtener(inst.codcli_ven.ToString());
            if (cliente is not null)
            {
                descripcion += $" - {cliente.nombre_cliente}";
            }

            this.labelStatus.Text = $"Modificando la factura #{inst.cod_ven}";
            this.textBoxDescripcion.Text = descripcion;
        }
    }
}
