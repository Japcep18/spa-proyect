using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Presentacion.Support;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador.Inventario
{
    public partial class FDesactivarCita : BaseForm
    {
        private CitaConsultableModel citasModel = new();
        private ClienteModel clienteModel = new();

        public FDesactivarCita()
        {
            InitializeComponent();
            this.eliminarClick += FDesactivarCita_eliminarClick;
        }

        private void FDesactivarCita_eliminarClick(object? sender, EventArgs e)
        {
            if (this.citasModel.Model is null)
                return;

            if(AlertaController.AlertaConfirmar(this, "¿Desea anular el registro?") == DialogResult.OK)
            {
                var msg = this.citasModel.AnularCita(this.citasModel.Model);
                if(!msg.State)
                {
                    AlertaController.AlertaError(this, msg.Msg);
                    return;
                } 
                else
                {
                    this.Nuevo(false);
                }
            }
        }

        private void FDesactivarCita_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.HabilitarBotones(true, false, false, false);
                this.MostrarBotones(true, false, true, false);

                this.citasModel = new()
                {
                    SoloActivos = true,
                };
                this.clienteModel = new();
                this.labelStatus.Text = "Nuevo";

                this.textBoxDescripcion.Text = String.Empty;
            }
            return valor;
        }

        private void bBuscarCita_Click(object sender, EventArgs e)
        {
            var msg = this.citasModel.CargarDatos();
            if(!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }

            Consulta consulta = new(DataManager.ToDataTable(msg.Entity ?? []));
            consulta.ShowDialog();

            var selected = consulta.GetSelectedRow();
            if (selected is null)
                return;

            Cita? inst = DataManager.DataRowToObject<Cita>(selected);
            if (inst is null)
                return;

            this.citasModel.Model = inst;
            this.HabilitarBotones(true, false, true);

            string descripcion = $"{inst.cod_cita} - {inst.fecha_cita.ToString(Formatos.formatoFechaHora)}";
            Cliente? cliente = this.clienteModel.Obtener(inst.codcli_cita.ToString());
            if(cliente is not null)
            {
                descripcion += $" - {cliente.nombre_cliente}";
            }

            this.labelStatus.Text = $"Modificando la cita #{inst.cod_cita}";
            this.textBoxDescripcion.Text = descripcion;
        }
    }
}
