using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FSala : BaseForm
    {
        private TipoSalaModel tipoSalaModel = new();
        private EstadoSalaModel estadoSalaModel = new();
        private SalaConsultableModel salaConsultableModel = new();
        private PuenteModeloUI<Sala> serviciosPuente;

        public FSala()
        {
            InitializeComponent();
            base.guardarClick += FServicios_guardarClick;
            this.serviciosPuente = new PuenteModeloUI<Sala>(salaConsultableModel)
            {
                Editar = true,
            };
            salaConsultableModel.CambioModelo += Model_CambioModelo;
            this.serviciosPuente.ProgresoCarga += ServiciosPuente_ProgresoCarga;
        }

        private void ServiciosPuente_ProgresoCarga(object? sender, ValorProgreso e)
        {
            this.labelStatus.Text = e.Labelstatus;

            int valor = (e.ValorActual / e.ValorMax) * 100;
            this.progressBar.Value = valor > this.progressBar.Maximum ? this.progressBar.Maximum : valor;
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (salaConsultableModel.Model != null)
            {
                this.textBoxCodigo.Text = salaConsultableModel.Model.cod_sala.ToString();
                this.textBoxNombre.Text = salaConsultableModel.Model.nombre_sala;
                TipoSala tipoSala = this.tipoSalaModel.Obtener(salaConsultableModel.Model.codtsal_sala.ToString());
                EstadoSala estadoSala = this.estadoSalaModel.Obtener(salaConsultableModel.Model.codesal_sala.ToString());
                FormUtils.SelectItemInComboBox(
                    this.CBTipoSala, tipoSala!,
                    ((tsal) => tsal.cod_tsal == salaConsultableModel.Model.codtsal_sala)
                );
                FormUtils.SelectItemInComboBox(
                    this.CBEstadoSala, estadoSala!,
                    ((esal) => esal.cod_esal == salaConsultableModel.Model.codesal_sala)
                );
                this.checkBoxPermiteReservar.Checked = salaConsultableModel.Model.permitereservar_sala;

                this.labelStatus.Text = $"Se está modificando: {this.salaConsultableModel.Model}";
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        private void FServicios_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string nombre = this.textBoxNombre.Text;
            TipoSala selectedTipoSala;
            EstadoSala selectedEstadoSala;

            // Validaciones ===========================================================================================

            if (nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxNombre, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            object? selectedItemTipoSala = this.CBTipoSala.SelectedItem;
            if (selectedItemTipoSala != null)
            {
                if (selectedItemTipoSala is TipoSala)
                    selectedTipoSala = (TipoSala)selectedItemTipoSala;
                else
                {
                    FormUtils.AddError(errorProvider, this.CBTipoSala, "Debe seleccionar el tipo de sala");
                    return;
                }
            }
            else
            {
                FormUtils.AddError(errorProvider, this.CBTipoSala, "Debe seleccionar el tipo de sala");
                return;
            }

            object? selectedItemEstadoSala = this.CBEstadoSala.SelectedItem;
            if (selectedItemTipoSala != null)
            {
                if (selectedItemEstadoSala is EstadoSala)
                    selectedEstadoSala = (EstadoSala)selectedItemEstadoSala;
                else
                {
                    FormUtils.AddError(errorProvider, this.CBEstadoSala, "Debe seleccionar el estado de sala");
                    return;
                }
            }
            else
            {
                FormUtils.AddError(errorProvider, this.CBEstadoSala, "Debe seleccionar el estado de sala");
                return;
            }

            // Carga de datos =========================================================================================

            Sala sala = new Sala()
            {
                nombre_sala = nombre,
                codtsal_sala = selectedTipoSala.cod_tsal,
                codesal_sala = selectedEstadoSala.cod_esal,
                permitereservar_sala = checkBoxPermiteReservar.Checked,
                activo_sala = true
            };

            ObjectValidation validation = new(sala);

            if (validation.IsValid())
            {
                SalaModel model = new SalaModel();
                model.Model = sala;
                if (this.salaConsultableModel.Model != null)
                {
                    model.Model.cod_sala = this.salaConsultableModel.Model.cod_sala;
                    model.Model.state = this.salaConsultableModel.Model.state;
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

        private void FServicios_Load(object sender, EventArgs e)
        {
            Nuevo(false);
            this.serviciosPuente.SetTextBoxCodigo(this.textBoxCodigo);
            this.serviciosPuente.SetBotonBuscar(bBuscar1);
            this.serviciosPuente.SetTextBoxDescripcion(this.textBoxNombre);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.progressBar.Value = 0;

                this.CargarDatos();
            }
            return valor;
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

            // Tipo de sala
            this.tipoSalaModel = new();
            Action updateProgressBar = () =>
            {
                int progressBarNextValue = this.progressBar.Value + incr_progress;
                this.progressBar.Value = progressBarNextValue > this.progressBar.Maximum ? this.progressBar.Maximum : progressBarNextValue;
            };
            
            var tipoSalaTask = Task.Run(() =>
            {
                EntityMessage<IEnumerable<TipoSala>> dataList = this.tipoSalaModel.CargarDatos();
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

            this.estadoSalaModel = new();
            // Estado de sala
            var estadoSalaTask = Task.Run(() =>
            {
                EntityMessage<IEnumerable<EstadoSala>> dataList = this.estadoSalaModel.CargarDatos();
                if (this.progressBar.InvokeRequired)
                    this.progressBar.Invoke(updateProgressBar);
                else
                    updateProgressBar();
                this.labelStatus.Text = "Estado sala cargado";
                return dataList;
            });

            await Task.WhenAll([tipoSalaTask, estadoSalaTask]);
            this.progressBar.Value = this.progressBar.Maximum;

            if (tipoSalaTask.Result.State)
            {
                this.CBTipoSala.Items.Clear();
                // .. -> spread operator
                this.CBTipoSala.Items.AddRange([.. (tipoSalaTask.Result.Entity ?? [])]);
                if (CBTipoSala.Items.Count > 0)
                    this.CBTipoSala.SelectedIndex = 0;
            }
            else
            {
                AlertaController.AlertaError(this, tipoSalaTask.Result.Msg);
            }

            if (estadoSalaTask.Result.State)
            {
                this.CBEstadoSala.Items.Clear();
                this.CBEstadoSala.Items.AddRange([.. (estadoSalaTask.Result.Entity ?? [])]);
                if (CBEstadoSala.Items.Count > 0)
                    this.CBEstadoSala.SelectedIndex = 0;
            }
            else
            {
                AlertaController.AlertaError(this, estadoSalaTask.Result.Msg);
            }

            this.labelStatus.Text = last_status;
        }
    }
}
