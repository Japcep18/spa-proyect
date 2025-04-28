using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.RRHH
{
    public partial class FEmpleado : BaseForm
    {
        private PuestoModel puestoModel = new();
        private EntidadModel entidadModel = new();
        EmpleadoConsultableModel empleadoConsultableModel = new();
        PuenteModeloUI<Entidad> puenteModeloUI;

        public FEmpleado()
        {
            InitializeComponent();
            base.guardarClick += FEmpleado_guardarClick;
            this.puenteModeloUI = new(entidadModel)
            {
                Editar = true,
            };
            empleadoConsultableModel.CambioModelo += Model_CambioModelo;
            this.entidadModel.CambioModelo += EntidadModel_CambioModelo;
            this.puenteModeloUI.ProgresoCarga += PuenteModeloUI_ProgresoCarga;
        }

        private void EntidadModel_CambioModelo(object? sender, string? e)
        {
            errorProvider.Clear();
            empleadoConsultableModel.Codigo = e;
            if(entidadModel.Model != null)
            {
                Entidad entidad = entidadModel.Obtener(entidadModel.Model.codent_ent.ToString())!;
                this.txtBoxNombre.Text = entidad.nombre_ent;
                this.textBoxSueldo.Text = empleadoConsultableModel.Model?.sueldoagregado_emp.ToString(Formatos.formatoMoneda);
                this.checkBoxActivo.Checked = empleadoConsultableModel.Model?.activo_emp ?? false;
                this.CBPuesto.SelectedItem = this.puestoModel.Obtener(empleadoConsultableModel.Model?.codpue_emp.ToString() ?? "-1");
            }
        }

        private void PuenteModeloUI_ProgresoCarga(object? sender, ValorProgreso e)
        {
            this.labelStatus.Text = e.Labelstatus;

            int valor = (e.ValorActual / e.ValorMax) * 100;
            this.progressBar.Value = valor > this.progressBar.Maximum ? this.progressBar.Maximum : valor;
        }

        private void FEmpleado_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();

            // Validar
            if (this.entidadModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.bBuscar1, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (this.textBoxSueldo.Text.Trim().Length == 0)
            {
                FormUtils.AddError(this.errorProvider, this.bBuscar1, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            double sueldo_agg;
            if (!double.TryParse(this.textBoxSueldo.Text, out sueldo_agg))
            {
                FormUtils.AddError(this.errorProvider, this.bBuscar1, "Formato inválido, debe insertar un número");
                return;
            }

            Puesto? puesto = this.CBPuesto.SelectedItem as Puesto;
            if(puesto == null)
            {
                FormUtils.AddError(this.errorProvider, this.CBPuesto, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            Empleado empleado = new Empleado()
            {
                codent_emp = this.entidadModel.Model.codent_ent,
                codpue_emp = puesto.cod_pue,
                sueldoagregado_emp = Convert.ToDecimal(sueldo_agg),
                activo_emp = checkBoxActivo.Checked,
            };

            ObjectValidation validation = new(empleado);

            if (validation.IsValid())
            {
                EmpleadoModel model = new EmpleadoModel();
                model.Model = empleado;
                if (this.empleadoConsultableModel.Model != null)
                {
                    model.Model.codent_emp = this.empleadoConsultableModel.Model.codent_emp;
                    model.Model.state = this.empleadoConsultableModel.Model.state;
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

        private void FEmpleado_Load(object sender, EventArgs e)
        {
            Nuevo(false);
            this.puenteModeloUI.SetBotonBuscar(this.bBuscar1);
            this.puenteModeloUI.SetTextBoxCodigo(this.textBoxCodigo);
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (empleadoConsultableModel.Model != null)
            {
                this.textBoxSueldo.Text = empleadoConsultableModel.Model.sueldoagregado_emp.ToString(Formatos.formatoMoneda);
                Puesto puesto = puestoModel.Obtener(empleadoConsultableModel.Model.codpue_emp.ToString())!;
                Entidad entidad = entidadModel.Obtener(empleadoConsultableModel.Model.codent_emp.ToString())!;
                this.txtBoxNombre.Text = entidad.nombre_ent;
                FormUtils.SelectItemInComboBox(
                    this.CBPuesto, puesto!,
                    (pue) => pue.cod_pue == empleadoConsultableModel.Model.codpue_emp
                );
                this.checkBoxActivo.Checked = empleadoConsultableModel.Model.activo_emp;

                this.labelStatus.Text = $"Se está modificando: {this.empleadoConsultableModel.Model}";
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
            this.puestoModel = new();
            Action updateProgressBar = () =>
            {
                int progressBarNextValue = this.progressBar.Value + incr_progress;
                this.progressBar.Value = progressBarNextValue > this.progressBar.Maximum ? this.progressBar.Maximum : progressBarNextValue;
            };

            var puestoTask = Task.Run(() =>
            {
                EntityMessage<IEnumerable<Puesto>> dataList = this.puestoModel.CargarDatos();
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

            await puestoTask;
            this.progressBar.Value = this.progressBar.Maximum;


            if (puestoTask.Result.State)
            {
                this.CBPuesto.Items.Clear();
                // .. -> spread operator
                this.CBPuesto.Items.AddRange([.. (puestoTask.Result.Entity ?? [])]);
                if (CBPuesto.Items.Count > 0)
                    this.CBPuesto.SelectedIndex = 0;
            }
            else
            {
                AlertaController.AlertaError(this, puestoTask.Result.Msg);
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

                this.CargarDatos();
            }
            return valor;
        }
    }
}
