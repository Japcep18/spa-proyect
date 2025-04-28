using Modelos.Servicios;
using Modelos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FUnidad : BaseForm
    {
        private UnidadModel model = new UnidadModel();
        private PuenteModeloUI<Unidad> puenteUnidad;
        public FUnidad()
        {
            InitializeComponent();
            base.guardarClick += FUnidad_guardarClick;
            this.puenteUnidad = new PuenteModeloUI<Unidad>(model);
            model.CambioModelo += Model_Cambiomodelo;

        }
        private void Model_Cambiomodelo(object? sender, string? e)
        {
            if (model.Model != null)
            {
                this.textBoxCodigoUnidad.Text = model.Model.cod_uni.ToString();
                this.textBoxDescripcionUnidad.Text = model.Model.descr_uni.ToString();
            }
            else
            {
                Nuevo(false);
            }
        }
        private void FUnidad_guardarClick(object? sender, EventArgs e)
        {
            string descripcion = this.textBoxDescripcionUnidad.Text;
            Unidad uni = new Unidad()
            {
                descr_uni = descripcion,
            };

            ObjectValidation validation = new(uni);

            if (validation.IsValid())
            {
                UnidadModel model = new UnidadModel();
                model.Model = uni;
                if (this.model.Model != null)
                {
                    model.Model.cod_uni = this.model.Model.cod_uni;
                    model.Model.state = this.model.Model.state;
                }

                var msg = model.Guardar();
                if (msg.State)
                {
                    Nuevo(false);
                }
                else
                {
                    AlertaController.AlertaError(this, msg.Msg);
                }
            }
            else
            {
                AlertaController.AlertaError(this, validation.GetMessage());
            }
        }

        private void FUnidad_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.model = new();
                this.puenteUnidad = new(this.model);
                this.puenteUnidad.SetTextBoxCodigo(this.textBoxCodigoUnidad);
                this.puenteUnidad.SetBotonBuscar(ButtonBuscar);
                model.CambioModelo += Model_Cambiomodelo;


            }
            return valor;
        }

        private void bBuscar1_Click(object sender, EventArgs e)
        {

        }
    }
}
