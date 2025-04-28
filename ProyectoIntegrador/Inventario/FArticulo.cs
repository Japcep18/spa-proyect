using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FArticulo : BaseForm
    {
        private ArticuloConsultableModel artModel = new();
        private UnidadModel unidadModel = new();
        private PuenteModeloUI<Articulo> articuloPuente;

        private ITBISModel ITBISModel = new();
        private PuenteModeloUI<ITBIS> itbisPuente;

        public FArticulo()
        {
            InitializeComponent();
            this.articuloPuente = new(this.artModel);
            this.artModel.CambioModelo += ArtModel_CambioModelo;
            guardarClick += FArticulo_guardarClick;
            // Asignar controles al puente
            this.articuloPuente.SetBotonBuscar(this.bBuscar1);
            this.articuloPuente.SetTextBoxCodigo(this.textBoxCodigo);
            this.articuloPuente.SetTextBoxDescripcion(this.textBoxDesc);
            //this.textBoxPrecio.KeyPress += FormUtils.AcceptOnlyDecimalOnKeyPress;
        }

        private void FArticulo_guardarClick(object? sender, EventArgs e)
        {
            // Limpiar errores
            this.errorProvider.Clear();

            // Validación de datos
            if (this.comboBoxUnidad.SelectedItem == null)
            {
                FormUtils.AddError(this.errorProvider, this.comboBoxUnidad,
                    Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (!decimal.TryParse(this.textBoxPrecio.Text, out decimal precio))
            {
                FormUtils.AddError(this.errorProvider, this.comboBoxUnidad,
                    Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            // Carga de datos
            string descripcion = this.textBoxDesc.Text;
            bool afectaInv = this.checkBoxAfectaInv.Checked;
            bool estado = this.checkBoxEstado.Checked;
            Unidad unidad = (this.comboBoxUnidad.SelectedItem as Unidad)!;
            ITBIS itbis = (this.comboBoxITBIS.SelectedItem as ITBIS)!;

            // Creación de instancia
            Articulo articulo = new()
            {
                coduni_art = unidad.cod_uni,
                valor_itbis = itbis.valor_itb,
                precio_art = precio,
                descripcion_art = descripcion.Trim().ToUpper(),
                afectainv_art = afectaInv,
                activo_art = estado,
            };

            // 2da Validación: OBJETO
            ObjectValidation validation = new(articulo);

            if (validation.IsValid())
            {
                var model = new ArticuloModel();
                model.Model = articulo;
                if (this.artModel.Model != null)
                {
                    model.Model.cod_art = this.artModel.Model.cod_art;
                    model.Model.state = this.artModel.Model.state;
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

        private void ArtModel_CambioModelo(object? sender, string? e)
        {
            if (this.artModel.Model != null)
            {
                var unidad = this.unidadModel.Obtener(this.artModel.Model.coduni_art.ToString());
                if (unidad != null)
                {
                    // Seleccionar item en el combo box de unidades
                    FormUtils.SelectItemInComboBox(this.comboBoxUnidad, unidad, (Unidad und) => unidad.cod_uni == und.cod_uni);
                }

                var itbis = this.ITBISModel.Obtener(this.artModel.Model.valor_itbis.ToString());
                    if(itbis != null)
                {
                    FormUtils.SelectItemInComboBox(this.comboBoxITBIS, itbis, (ITBIS itb) => itbis.valor_itb == itb.valor_itb);
                }

                this.checkBoxAfectaInv.Checked = this.artModel.Model.afectainv_art;
                this.checkBoxEstado.Checked = this.artModel.Model.activo_art;

                this.textBoxPrecio.Text = this.artModel.Model.precio_art.ToString(Formatos.formatoMoneda);

                this.labelStatus.Text = this.artModel.Model.ToString();
            }
            else
            {
                Nuevo(false);
            }
        }

        private void Artículo_Load(object sender, EventArgs e)
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
                this.checkBoxAfectaInv.Checked = true;
                this.checkBoxEstado.Checked = true;
                this.textBoxCodigo.Enabled = true;
                CargarDatos();

            }
            return valor;
        }

        private void CargarDatos()
        {
            var unidadMsg = this.unidadModel.CargarDatos();
            if (unidadMsg.State)
            {
                this.comboBoxUnidad.Items.Clear();
                // Carga de datos de unidad
                this.comboBoxUnidad.Items.AddRange((unidadMsg.Entity ?? []).ToArray());
            }
            else
            {
                // Manejo de errores
                AlertaController.AlertaError(this, unidadMsg.Msg);
            }

            var itbismsg = this.ITBISModel.CargarDatos();
            if (itbismsg.State)
            {
                this.comboBoxITBIS.Items.Clear();
                // Carga de datos de ITBIS
                this.comboBoxITBIS.Items.AddRange((itbismsg.Entity ?? []).ToArray());
            }
            else
            {
                // Manejo de errores
                AlertaController.AlertaError(this, itbismsg.Msg);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
