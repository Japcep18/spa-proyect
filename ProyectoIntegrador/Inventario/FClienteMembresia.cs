using System.Data;
using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FClienteMembresia : BaseForm
    {
        private ClienteConsultableModel clienteModel = new();
        private MembresiaModel membresiaModel = new();
        private ClienteMembresiaModel clienteMembresiaModel = new();
        private PuenteModeloUI<Membresia> membresiaPuente;

        private PuenteModeloUI<Cliente> clientePuente;

        private List<ClienteConsultable> clienteList = new();
        public FClienteMembresia()
        {
            InitializeComponent();
            base.guardarClick += FClienteMembresia_guardarClick;

            this.membresiaPuente = new PuenteModeloUI<Membresia>(membresiaModel)
            {
                BloquearCodigoLuegoDeBuscar = false
            };
            this.membresiaPuente.SetBotonBuscar(bBuscarMembresia);
            this.membresiaPuente.SetTextBoxCodigo(textBoxCodigoMembresia);
            this.membresiaPuente.SetTextBoxDescripcion(textBoxDescMembresia);

            membresiaModel.CambioModelo += Model_CambioModelo;

            // Cliente --------------------------------------------------------------
            this.clientePuente = new PuenteModeloUI<Cliente>(clienteModel)
            {
                BloquearCodigoLuegoDeBuscar = false
            };
            this.clientePuente.SetBotonBuscar(bBuscarCliente);
            this.clientePuente.SetTextBoxCodigo(textBoxCodigoCliente);
            this.clientePuente.SetTextBoxDescripcion(textBoxDescCliente);
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (membresiaModel.Model != null)
            {
                var clientemsg = this.clienteMembresiaModel.ObtenerClientes(this.membresiaModel.Model);

                if (clientemsg.State)
                {
                    // CONTROL DE INTERFAZ - TRAS SELECCIONAR MEMBRESIA NO SE PODRÁ EDITAR: Para hacerlo debe ejecutarse el método nuevo
                    this.groupBoxMembresia.Enabled = false;
                    this.groupBoxCliente.Enabled = true;
                    // Carga de datos
                    this.dataGridView1.Rows.Clear();
                    this.labelStatus.Text = $"Se está modificando: {this.membresiaModel.Model}";

                    clienteList = new(this.clienteModel.ObtenerConsultable(clientemsg.Entity ?? []));
                    this.RenderClientes();
                }
                else
                {
                    // Manejo de errores
                    AlertaController.AlertaError(this, clientemsg.Msg);
                }
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        private void FClienteMembresia_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.clienteList.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, "No se ha agregado ningun cliente");
                return;
            }

            if (this.membresiaModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            this.clienteMembresiaModel.Membresia = this.membresiaModel.Model;
            IEnumerable<Cliente?> clientes = this.clienteList.Select(cli => this.clienteModel.Obtener(cli.codent_cli.ToString())).Where(cli => cli != null);
            Modelos.Tipos.EntityMessage<object?> msg = this.clienteMembresiaModel.Guardar(clientes!);

            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }

            Nuevo(false);
        }

        private void FClienteMembresia_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);
                this.progressBar.Value = 0;

                this.clienteList = new();
                this.membresiaModel.Model = null;
                this.textBoxCodigoMembresia.Clear();
                this.textBoxDescMembresia.Clear();
                this.dataGridView1.Rows.Clear();
                this.buttonEliminar.Enabled = false;
                // - RESTAURAR PARA PODER SELECCIONAR UNA MEMBRESÍA
                this.groupBoxMembresia.Enabled = true;
                this.groupBoxCliente.Enabled = false;
            }
            return valor;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();

            // Validar que el modelo consultable esté seleccionado
            if (this.clienteModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, textBoxDescCliente, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            ClienteConsultable? cliente = this.clienteModel.ObtenerConsultable([this.clienteModel.Model]).FirstOrDefault();
            if (cliente is not null)
                this.clienteList.Add(cliente);

            this.RenderClientes();

            // Limpiar el código
            this.clienteModel.Codigo = null;
        }

        private void RenderClientes()
        {
            this.dataGridView1.Rows.Clear();

            foreach (var item in clienteList)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[ColumnCodigo.Index].Value = item.codent_cli;
                this.dataGridView1.Rows[index].Cells[ColumnNombre.Index].Value = item.nombre_cliente;
                this.dataGridView1.Rows[index].Cells[ColumnTipocliente.Index].Value = item.tipo_cliente;
                this.dataGridView1.Rows[index].Cells[ColumnActivo.Index].Value = item.activo_cli;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int clindex = this.clienteList.FindIndex(cli => this.dataGridView1.Rows[e.RowIndex].Cells[ColumnCodigo.Index].Value.Equals(cli.codent_cli));
            if (clindex == -1)
                return;

            this.clienteModel.Codigo = this.clienteList[clindex].codent_cli.ToString();
            this.RenderClientes();

            this.buttonEliminar.Enabled = true;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (this.clienteModel.Model == null)
                return;

            int index = this.clienteList.FindIndex(cli => cli.codent_cli == this.clienteModel.Model.codent_cli);
            if (index != -1)
                return;

            this.clienteList.RemoveAt(index);
            this.clienteModel.Codigo = null;

            this.buttonEliminar.Enabled = false;
        }
    }
}
