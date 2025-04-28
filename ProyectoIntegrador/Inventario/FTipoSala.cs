using Modelos.Estandard;
using Modelos.Servicios;
using Modelos;
using ProyectoIntegrador.Utilidades.Controles;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador.Inventario
{
    public partial class FTipoSala : BaseForm
    {
        private TipoSalaModel model = new TipoSalaModel();
        private PuenteModeloUI<TipoSala> serviciosPuente;
        public FTipoSala()
        {
            InitializeComponent();
            base.guardarClick += FServicios_guardarClick;
            this.serviciosPuente = new PuenteModeloUI<TipoSala>(model)
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
                this.textBoxCodigo.Text = model.Model.cod_tsal.ToString();
                this.textBoxNombre.Text = model.Model.nombre_tsal;

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
            string nombre = this.textBoxNombre.Text;

            // Validaciones
            if (nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxNombre, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            TipoSala tsal = new TipoSala()
            {
                nombre_tsal = nombre,
            };

            ObjectValidation validation = new(tsal);

            if (validation.IsValid())
            {
                TipoSalaModel model = new TipoSalaModel();
                model.Model = tsal;
                if (this.model.Model != null)
                {
                    model.Model.cod_tsal = this.model.Model.cod_tsal;
                    model.Model.nombre_tsal = this.model.Model.nombre_tsal;
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
                this.serviciosPuente.SetTextBoxDescripcion(this.textBoxNombre);

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
