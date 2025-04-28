using Modelos.Consultables;
using Modelos;
using ProyectoIntegrador.Utilidades.Controles;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;
using Modelos.Servicios;
using Modelos.Tipos;

namespace ProyectoIntegrador.Inventario
{
    public partial class FCliente : BaseForm
    {
        private TipoClienteModel tipoClienteModel = new();
        private EntidadModel entidadModel = new();
        ClienteConsultableModel clienteConsultableModel = new();
        PuenteModeloUI<Entidad> puenteModeloUI;
        public FCliente()
        {
            InitializeComponent();
            base.guardarClick += FCliente_guardarClick;
            this.puenteModeloUI = new(entidadModel)
            {
                Editar = true,
            };
            clienteConsultableModel.CambioModelo += Model_CambioModelo;
            this.entidadModel.CambioModelo += EntidadModel_CambioModelo;
            this.puenteModeloUI.ProgresoCarga += PuenteModeloUI_ProgresoCarga;
        }

        private void EntidadModel_CambioModelo(object? sender, string? e)
        {
            errorProvider.Clear();
            if (entidadModel.Model != null)
            {
                clienteConsultableModel.Codigo = e;
                Entidad entidad = entidadModel.Obtener(entidadModel.Model.codent_ent.ToString())!;
                this.textBoxNombre.Text = entidad.nombre_ent;
                this.checkBoxActivo.Checked = clienteConsultableModel.Model?.activo_cli ?? false;
                this.CBTipo.SelectedItem = this.tipoClienteModel.Obtener(clienteConsultableModel.Model?.codtcli_cli.ToString() ?? "-1");
            }
            else
            {
                this.Nuevo(false);
            }
        }

        private void PuenteModeloUI_ProgresoCarga(object? sender, ValorProgreso e)
        {
            this.labelStatus.Text = e.Labelstatus;

            int valor = (e.ValorActual / e.ValorMax) * 100;
            this.progressBar.Value = valor > this.progressBar.Maximum ? this.progressBar.Maximum : valor;
        }

        private void FCliente_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();

            // Validar
            if (this.entidadModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.bBuscar1, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            TipoCliente? tipoCliente = this.CBTipo.SelectedItem as TipoCliente;
            if (tipoCliente == null)
            {
                FormUtils.AddError(this.errorProvider, this.CBTipo, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            Cliente cliente = new Cliente()
            {
                codent_cli = this.entidadModel.Model.codent_ent,
                codtcli_cli = tipoCliente.cod_tcli,
                activo_cli = checkBoxActivo.Checked,
            };

            ObjectValidation validation = new(cliente);

            if (validation.IsValid())
            {
                ClienteModel model = new ClienteModel();
                model.Model = cliente;
                if (this.clienteConsultableModel.Model != null)
                {
                    model.Model.codent_cli = this.clienteConsultableModel.Model.codent_cli;
                    model.Model.state = this.clienteConsultableModel.Model.state;
                    model.Model.feceg_cli = this.clienteConsultableModel.Model.feceg_cli;
                }
                else
                {
                    model.Model.feceg_cli = DateTime.Now;
                }

                this.progressBar.Value = 50;
                var msg = model.Guardar();
                if (msg.State)
                {
                    this.progressBar.Value = 100;
                    ToastController.MostrarInfo(this, Mensajes.Msj_Aviso_RegistroGuardado);
                    Nuevo(false);
                }
                else
                {
                    AlertaController.AlertaError(this, msg.Msg);
                }
                this.progressBar.Value = 0;
            }
            else
            {
                AlertaController.AlertaError(this, validation.GetMessage());
            }
        }
        private void FCliente_Load(object sender, EventArgs e)
        {
            Nuevo(false);
            this.puenteModeloUI.SetBotonBuscar(this.bBuscar1);
            this.puenteModeloUI.SetTextBoxCodigo(this.textBoxCodigo);
            this.puenteModeloUI.SetTextBoxDescripcion(this.textBoxNombre);
        }
        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (clienteConsultableModel.Model != null)
            {
                TipoCliente tipoCliente = tipoClienteModel.Obtener(clienteConsultableModel.Model.codtcli_cli.ToString())!;
                Entidad entidad = entidadModel.Obtener(clienteConsultableModel.Model.codent_cli.ToString())!;
                this.textBoxNombre.Text = entidad.nombre_ent;
                FormUtils.SelectItemInComboBox(
                    this.CBTipo, tipoCliente!,
                    (tcli) => tcli.cod_tcli == clienteConsultableModel.Model.codtcli_cli
                );
                this.checkBoxActivo.Checked = clienteConsultableModel.Model.activo_cli;

                this.labelStatus.Text = $"Se está modificando: {this.clienteConsultableModel.Model}";
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        private async Task CargarDatos()
        {
            // Invoke -> Preparar la UI para ser manipulada desde otro hilo
            if (this.InvokeRequired)
            {
                await this.Invoke(async () => await this.CargarDatos());
                return;
            }

            this.progressBar.Value = 0;
            const int incr_progress = 100 / 2;
            string last_status = this.labelStatus.Text ?? "";

            // PuestoSala
            this.tipoClienteModel = new();
            Action updateProgressBar = () =>
            {
                int progressBarNextValue = this.progressBar.Value + incr_progress;
                this.progressBar.Value = progressBarNextValue > this.progressBar.Maximum ? this.progressBar.Maximum : progressBarNextValue;
            };

            var tipoClienteTask = Task.Run(() =>
            {
                EntityMessage<IEnumerable<TipoCliente>> dataList = this.tipoClienteModel.CargarDatos();
                if (this.progressBar.Value + incr_progress < this.progressBar.Maximum)
                {
                    if (this.progressBar.InvokeRequired)
                        this.progressBar.Invoke(updateProgressBar);
                    else
                        updateProgressBar();
                }
                this.labelStatus.Text = "Tipo sala cargada";
                return dataList;
            });

            await tipoClienteTask;
            this.progressBar.Value = this.progressBar.Maximum;


            if (tipoClienteTask.Result.State)
            {
                this.CBTipo.Items.Clear();
                // .. -> spread operator
                this.CBTipo.Items.AddRange([.. (tipoClienteTask.Result.Entity ?? [])]);
                if (CBTipo.Items.Count > 0)
                    this.CBTipo.SelectedIndex = 0;
            }
            else
            {
                AlertaController.AlertaError(this, tipoClienteTask.Result.Msg);
            }

            this.labelStatus.Text = last_status;
        }
        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.progressBar.Value = 0;
                this.checkBoxActivo.Checked = true;

                this.textBoxCodigo.Enabled = true;

                this.CargarDatos();
            }
            return valor;
        }

        private void checkBoxActivo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
