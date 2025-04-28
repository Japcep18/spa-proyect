using Modelos;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FGenero : BaseForm
    {
        private GeneroModel model = new GeneroModel();
        private PuenteModeloUI<Genero> generoPuente;
        public FGenero()
        {
            InitializeComponent();
            base.guardarClick += FTipoCliente_guardarClick;
            this.model = new();
            this.generoPuente = new(this.model);
            this.generoPuente.SetTextBoxCodigo(this.textBoxCodigoTCli);
            this.generoPuente.SetBotonBuscar(ButtonBuscar);
            //this.generoPuente.ProgresoCarga += GeneroPuente_ProgresoCarga;
            model.CambioModelo += Model_Cambiomodelo;
        }

        //private void GeneroPuente_ProgresoCarga(object? sender, ValorProgreso e)
        //{
        //    if (e.Labelstatus != null)
        //        this.labelStatus.Text = e.Labelstatus;

        //    int valor = e.ValorActual / e.ValorMax;
        //    if(valor * 100 < this.progressBar.Maximum)
        //        this.progressBar.Value = valor * 100;
        //    else
        //        this.progressBar.Value = this.progressBar.Maximum;
        //}

        private void Model_Cambiomodelo(object? sender, string? e)
        {
            if (model.Model != null)
            {
                this.textBoxCodigoTCli.Text = model.Model.cod_gen.ToString();
                this.textBoxDescripcionTCli.Text = model.Model.desc_gen.ToString();
            }
            else
            {
                Nuevo(false);
            }
        }

        private void FTipoCliente_guardarClick(object? sender, EventArgs e)
        {
            string descripcion = this.textBoxDescripcionTCli.Text;
            Genero tcli = new Genero()
            {
               desc_gen = descripcion,
            };

            ObjectValidation validation = new(tcli);

            if (validation.IsValid())
            {
                GeneroModel model = new GeneroModel();
                model.Model = tcli;
                if (this.model.Model != null)
                {
                    model.Model.cod_gen = this.model.Model.cod_gen;
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
            if (valor) {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.textBoxCodigoTCli.Enabled = true;
            }
            return valor;
        }
    }
}
