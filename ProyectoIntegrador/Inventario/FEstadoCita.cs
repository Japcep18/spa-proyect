using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FEstadoCita : BaseForm
    {
        private EstadoCitaModel model = new EstadoCitaModel();
        private PuenteModeloUI<EstadoCita> puenteEstadoCita;
        public FEstadoCita()
        {
            InitializeComponent();
            base.guardarClick += FEstadoCita_guardarClick;
            this.puenteEstadoCita = new PuenteModeloUI<EstadoCita>(model)
            {
                Editar = true,
            };

            this.puenteEstadoCita.SetTextBoxCodigo(this.textBoxCodigoEstadoCita);
            this.puenteEstadoCita.SetTextBoxDescripcion(this.textBoxDescripcionEstadoCita);
            this.puenteEstadoCita.SetBotonBuscar(ButtonBuscar);
            model.CambioModelo += Model_CambioModelo;
        }
        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (model.Model != null)
            {
                this.textBoxCodigoEstadoCita.Text = model.Model.cod_ecit.ToString();
                this.textBoxDescripcionEstadoCita.Text = model.Model.desc_ecit;

                this.labelStatus.Text = $"Se esta modificando: {this.model.Model}";
            }
            else
            {
                Nuevo(false);
            }
        }

        private void FEstadoCita_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string descripcion = this.textBoxDescripcionEstadoCita.Text;

            if (descripcion.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionEstadoCita, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }
            
            EstadoCita ecit = new EstadoCita()
            {
                desc_ecit = descripcion,
            };

            ObjectValidation validation = new(ecit);

            if (validation.IsValid())
            {
                var model = new EstadoCitaModel();
                model.Model = ecit;
                if (this.model.Model != null)
                {
                    model.Model.cod_ecit = this.model.Model.cod_ecit;
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

        public void FEstadoCita_Load(object sender, EventArgs e)
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
            }
            return valor;
        }
        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            // Lógica del botón (si es necesario)
        }
    }
}
