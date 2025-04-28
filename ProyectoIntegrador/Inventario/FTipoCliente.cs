using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FTipoCliente : BaseForm
    {
        private TipoClienteModel model = new TipoClienteModel();
        private PuenteModeloUI<TipoCliente> puenteTipoCliente;
        public FTipoCliente()
        {
            InitializeComponent();
            base.guardarClick += FTipoCliente_guardarClick;
            this.puenteTipoCliente = new PuenteModeloUI<TipoCliente>(model)
            {
                Editar = true,
            };
            model.CambioModelo += Model_Cambiomodelo;  
        }

        private void Model_Cambiomodelo(object? sender, string? e)
        {
            if (model.Model != null)
            {
                this.textBoxCodigoTCli.Text = model.Model.cod_tcli.ToString();
                this.textBoxDescripcionTCli.Text = model.Model.desc_tcli.ToString();
            }
            else
            {
                Nuevo(false);
            }
        }

        private void FTipoCliente_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string descripcion = this.textBoxDescripcionTCli.Text;

            // Validaciones
            if (descripcion.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionTCli, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            TipoCliente tcli = new TipoCliente()
            {
                desc_tcli = descripcion,
            };

            ObjectValidation validation = new(tcli);

            if (validation.IsValid())
            {
                TipoClienteModel model = new TipoClienteModel();
                model.Model = tcli;
                if (this.model.Model != null)
                {
                    model.Model.cod_tcli = this.model.Model.cod_tcli;
                    model.Model.desc_tcli = this.model.Model.desc_tcli;
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

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void FTipoCliente_Load(object sender, EventArgs e)
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

                this.model = new();
                this.puenteTipoCliente.Modelo = this.model;

                this.puenteTipoCliente.SetTextBoxCodigo(this.textBoxCodigoTCli);
                this.puenteTipoCliente.SetBotonBuscar(ButtonBuscar);
                this.puenteTipoCliente.SetTextBoxDescripcion(this.textBoxDescripcionTCli);

                this.progressBar.Value = 0;
            }
            return valor;
        }
    }
}
