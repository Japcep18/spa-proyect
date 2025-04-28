using Modelos;
using Modelos.Estandard;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FArticuloServicio : BaseForm
    {
        public ServicioModel servicioModel = new ServicioModel();
        public ArticuloModel articuloModel = new ArticuloModel();
        private ServicioArticuloModel servicioArticuloModel = new();
        PuenteModeloUI<Servicio> servicioPuente;
        PuenteModeloUI<Articulo> articuloPuente;

        private List<Contable<Articulo>> articuloList = new();

        public FArticuloServicio()
        {
            InitializeComponent();
            base.guardarClick += FArticuloServicio_guardarClick;

            // SERVICIO ----------------------------------------------------------------
            this.servicioPuente = new PuenteModeloUI<Servicio>(servicioModel)
            {
                Editar = true,
                BloquearCodigoLuegoDeBuscar = false
            };
            this.servicioPuente.SetBotonBuscar(bBuscarServicio);
            this.servicioPuente.SetTextBoxCodigo(textBoxCodigoServicio);
            this.servicioPuente.SetTextBoxDescripcion(textBoxDescServicio);

            servicioModel.CambioModelo += ServicioModel_CambioModelo;

            // ARTICULOS --------------------------------------------------------------
            this.articuloPuente = new PuenteModeloUI<Articulo>(articuloModel)
            {
                Editar = true,
                BloquearCodigoLuegoDeBuscar = false
            };
            this.articuloPuente.SetBotonBuscar(bBuscarArticulo);
            this.articuloPuente.SetTextBoxCodigo(textBoxCodigoArticulo);
            this.articuloPuente.SetTextBoxDescripcion(textBoxDescArticulo);
        }

        private void ServicioModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (servicioModel.Model != null)
            {
                var articulosMsg = this.servicioArticuloModel.ObtenerArticulos(this.servicioModel.Model);

                if (articulosMsg.State)
                {
                    // CONTROL DE INTERFAZ - TRAS SELECCIONAR MEMBRESIA NO SE PODRÁ EDITAR: Para hacerlo debe ejecutarse el método nuevo
                    this.groupBoxServicio.Enabled = false;
                    this.groupBoxArticulo.Enabled = true;
                    // Carga de datos
                    this.dataGridView1.Rows.Clear();
                    this.labelStatus.Text = $"Se está modificando: {this.servicioModel.Model}";

                    // RE- INICIALIZACION de la lista interna de descuentos
                    this.articuloList = new List<Contable<Articulo>>((articulosMsg.Entity ?? []).Select(art => new Contable<Articulo>() { Data = art, Cantidad = 1 }));

                    foreach (Contable<Articulo> item in this.articuloList)
                    {
                        AgregarArtículo(item.Data, item.Cantidad);
                    }
                }
                else
                {
                    // Manejo de errores
                    AlertaController.AlertaError(this, articulosMsg.Msg);
                }
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        private void FArticuloServicio_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.articuloList.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, "No se han agregado descuentos");
                return;
            }

            if (this.servicioModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            this.servicioArticuloModel.Servicio = this.servicioModel.Model;
            var msg = this.servicioModel.GuardarArticulos(articuloList);

            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }

            ToastController.MostrarInfo(this, msg.Msg);
            Nuevo(false);
        }

        private void FArticuloServicio_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        /// <summary>
        /// Agrega un artículo al datagridview, no lo hace en la lista interna
        /// </summary>
        /// <param name="item">Artículo a agregar</param>
        private void AgregarArtículo(Articulo item, decimal cantidad)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[ColumnCodigo.Index].Value = item.cod_art;
            this.dataGridView1.Rows[index].Cells[ColumnDescripcion.Index].Value = item.descripcion_art;
            this.dataGridView1.Rows[index].Cells[ColumnPrecio.Index].Value = item.precio_art.ToString(Formatos.formatoMoneda);
            this.dataGridView1.Rows[index].Cells[ColumnActivo.Index].Value = Formatos.GetEstadoNombre(item.activo_art);
            this.dataGridView1.Rows[index].Cells[ColumnCantidad.Index].Value = cantidad.ToString(Formatos.formatoMoneda);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);
                this.progressBar.Value = 0;
                this.servicioModel.Model = null;
                this.textBoxCodigoServicio.Clear();
                this.textBoxDescServicio.Clear();
                this.dataGridView1.Rows.Clear();
                this.buttonEliminar.Enabled = false;
                // - RESTAURAR PARA PODER SELECCIONAR UNA MEMBRESÍA
                this.groupBoxServicio.Enabled = true;
                this.groupBoxArticulo.Enabled = false;

            }
            return valor;
        }

        private void ButtonAgregar_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.articuloModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, textBoxDescArticulo, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (string.IsNullOrEmpty(this.textBoxCantidad.Text.Trim()))
            {
                FormUtils.AddError(this.errorProvider, textBoxCantidad, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (!decimal.TryParse(this.textBoxCantidad.Text, out decimal cant))
            {
                FormUtils.AddError(this.errorProvider, textBoxCantidad, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            this.AgregarArtículo(this.articuloModel.Model, cant);
            this.articuloList.Add(new()
            {
                Data = this.articuloModel.Model,
                Cantidad = cant,
            });

            this.articuloModel.Codigo = null;
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // VALIDAR QUE NO SE LE DIO CLICK AL COLUMN
            if (e.RowIndex < 0)
                return;

            int descIndex = this.articuloList.FindIndex(desc => desc.Data.cod_art.Equals(this.dataGridView1.Rows[e.RowIndex].Cells[ColumnCodigo.Index].Value));
            if (descIndex == -1) // SE ENCONTRÓ UN ARTICULO
                return;

            this.articuloModel.Codigo = this.articuloList[descIndex].Data.cod_art.ToString();
            this.textBoxCantidad.Text = this.articuloList[descIndex].Cantidad.ToString(Formatos.formatoMoneda);

            if (this.articuloModel.Codigo == null) // SI SE ENCONTRÓ EN LA BD, QUITALO (YA ESTA CARGADO)
                return;

            this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            this.buttonEliminar.Enabled = true;
        }

        private void ButtonEliminar_Click(object sender, EventArgs e)
        {
            if (this.articuloModel.Model == null)
                return;

            int index = this.articuloList.FindIndex(des => des.Data.cod_art == this.articuloModel.Model.cod_art);
            if (index != -1)
                return;

            this.articuloList.RemoveAt(index);
            this.articuloModel.Codigo = null;

            this.buttonEliminar.Enabled = false;
        }

        private void TextBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Convert.ToChar(Keys.Enter) == e.KeyChar)
                buttonAgregar.Select();
        }
    }
}
