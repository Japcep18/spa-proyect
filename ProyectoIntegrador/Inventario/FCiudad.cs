using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FCiudad : BaseForm
    {
        private CiudadModel model = new();
        private PuenteModeloUI<Ciudad> puenteModelo;

        public FCiudad()
        {
            InitializeComponent();
            guardarClick += FCiudad_guardarClick;
            puenteModelo = new(this.model) { 
                Editar = true,
            };
            model.CambioModelo += Model_CambioModelo;

            MostrarBotones(true, true);
            HabilitarBotones(true, true);
        }

        private void FCiudad_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string abreviatura = this.textBoxAbr.Text;
            string descripcion = this.textBoxDescripcion.Text;

            // Validaciones
            if (abreviatura.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxAbr, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }
            //      
            if (descripcion.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcion, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            Ciudad ciudad = new Ciudad() { 
                Abr_ciud = abreviatura,
                desc_ciud = descripcion,
            };

            ObjectValidation validation = new(ciudad);

            if (validation.IsValid())
            {
                CiudadModel model = new CiudadModel();
                model.Model = ciudad;
                if (this.model.Model != null)
                {
                    model.Model.cod_ciud = this.model.Model.cod_ciud;
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

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (this.model.Model != null)
            {
                this.textBoxCodigo.Text = model.Model.cod_ciud.ToString();
                this.textBoxDescripcion.Text = model.Model.desc_ciud;
                this.textBoxAbr.Text = model.Model.Abr_ciud;

                this.labelStatus.Text = $"Se está modificando: {this.model.Model}";
            }
            else
                Nuevo(false);
        }

        private void FCiudad_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor =  base.Nuevo(preguntar);
            if(valor)
            {
                this.model = new();
                this.model.CambioModelo += Model_CambioModelo;
                this.puenteModelo.Modelo = this.model;

                puenteModelo.SetBotonBuscar(this.bBuscar1);
                puenteModelo.SetTextBoxCodigo(this.textBoxCodigo);
                puenteModelo.SetTextBoxDescripcion(this.textBoxDescripcion);

                this.textBoxAbr.Text = "";
                this.progressBar.Value = 0;
            }
            return valor;
        }
    }
}
