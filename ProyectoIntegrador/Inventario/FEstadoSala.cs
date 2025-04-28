using Modelos.Estandard;
using Modelos.Servicios;
using Modelos;
using ProyectoIntegrador.Utilidades.Controles;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador.Inventario
{
    public partial class FEstadoSala : BaseForm
    {
        private EstadoSalaModel model = new EstadoSalaModel();
        private PuenteModeloUI<EstadoSala> serviciosPuente;
        public FEstadoSala()
        {
            InitializeComponent();
            base.guardarClick += FServicios_guardarClick;
            this.serviciosPuente = new PuenteModeloUI<EstadoSala>(model)
            {
                Editar = true,
            };
            model.CambioModelo += Model_CambioModelo;
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (model.Model != null)
            {
                this.textBoxCodigo.Text = model.Model.cod_esal.ToString();
                this.textBoxDescripcion.Text = model.Model.desc_esal;

                this.labelStatus.Text = $"Se está modificando: {this.model.Model}";
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
            string nombre = this.textBoxDescripcion.Text;

            // Validaciones
            if (nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcion, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            EstadoSala serv = new EstadoSala()
            {
                desc_esal = nombre,
            };

            ObjectValidation validation = new(serv);

            if (validation.IsValid())
            {
                EstadoSalaModel model = new EstadoSalaModel();
                model.Model = serv;
                if (this.model.Model != null)
                {
                    model.Model.cod_esal = this.model.Model.cod_esal;
                    model.Model.desc_esal = this.model.Model.desc_esal;
                    model.Model.state = this.model.Model.state;
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

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.model = new();
                this.model.CambioModelo += Model_CambioModelo;
                this.serviciosPuente.Modelo = this.model;

                this.serviciosPuente.SetTextBoxCodigo(this.textBoxCodigo);
                this.serviciosPuente.SetBotonBuscar(bBuscar1);
                this.serviciosPuente.SetTextBoxDescripcion(this.textBoxDescripcion);

                this.progressBar.Value = 0;
            }
            return valor;
        }

        private void FEstadoSala_Load_1(object sender, EventArgs e)
        {
            Nuevo(false);
        }
    }
}
