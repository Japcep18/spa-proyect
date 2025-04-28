using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FServicios : BaseForm
    {
        private ServicioModel model = new ServicioModel();
        private PuenteModeloUI<Servicio> serviciosPuente;
        public FServicios()
        {
            InitializeComponent();
            base.guardarClick += FServicios_guardarClick;
            this.serviciosPuente = new PuenteModeloUI<Servicio>(model)
            {
                Editar = true,
                BloquearCodigoLuegoDeBuscar = false,
            };
            model.CambioModelo += Model_CambioModelo;

            this.serviciosPuente.SetTextBoxCodigo(this.textBoxCodigo);
            this.serviciosPuente.SetBotonBuscar(bBuscar1);
            this.serviciosPuente.SetTextBoxDescripcion(this.textBoxNombre);

        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (model.Model != null)
            {
                this.textBoxCodigo.Text = model.Model.cod_ser.ToString();
                this.textBoxNombre.Text = model.Model.desc_ser;
                this.textBoxPrecioBase.Text = model.Model.preciobase_ser.ToString(Formatos.formatoMoneda);
                this.textBoxEstimado.Text = model.Model.estimado_ser.ToString();
                this.textBoxRecuperacion.Text = model.Model.recuperacion_ser.ToString();
                this.switchApilable.Checked = model.Model.estapilable_ser;
                this.switchComplementario.Checked = model.Model.complemento_ser ?? false;

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
            string preciobase_str = this.textBoxPrecioBase.Text;
            string estimado_str = this.textBoxEstimado.Text;
            string recuperacion_str = this.textBoxEstimado.Text;

            // Validaciones
            if(!double.TryParse(preciobase_str, out double preciobase_dbl))
            {
                FormUtils.AddError(errorProvider, this.textBoxPrecioBase, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }
            
            if(!int.TryParse(recuperacion_str, out int recuperacion))
            {
                FormUtils.AddError(errorProvider, this.textBoxRecuperacion, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }
            
            if(!int.TryParse(estimado_str, out int estimado))
            {
                FormUtils.AddError(errorProvider, this.textBoxEstimado, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            if(nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxNombre, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            Servicio serv = new Servicio()
            {
                desc_ser = nombre,
                preciobase_ser = (decimal) preciobase_dbl,
                activo_ser = this.checkBoxActivo.Checked,
                complemento_ser = this.switchComplementario.Checked,
                estapilable_ser = this.switchApilable.Checked,
                estimado_ser = estimado,
                recuperacion_ser = recuperacion,
            };

            ObjectValidation validation = new(serv);

            if (validation.IsValid())
            {
                ServicioModel model = new ServicioModel();
                model.Model = serv;
                if(this.model.Model != null)
                {
                    model.Model.cod_ser = this.model.Model.cod_ser;
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

        private void FServicios_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if(valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.textBoxCodigo.Enabled = true;
                this.checkBoxActivo.Checked = true;
                this.switchApilable.Checked = false;
                this.switchComplementario.Checked = false;

                this.textBoxPrecioBase.Text = "";
                this.progressBar.Value = 0;
            }
            return valor;
        }
    }
}
