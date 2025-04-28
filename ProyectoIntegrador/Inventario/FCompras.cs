using Modelos;
using Modelos.Estandard;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;
using System.Runtime.CompilerServices;

namespace ProyectoIntegrador.Inventario
{
    public partial class FCompras : BaseForm
    {
        private SuplidorModel SuplidorModel = new();
        private ArticuloModel articuloModel = new();
        private ComprasModel comprasModel = new();
        private PuenteModeloUI<Suplidor> puenteSuplidor;
        private PuenteModeloUI<Articulo> puenteArticulo;

        private List<CompraPivote> listaArticulos = new();

        public FCompras()
        {
            InitializeComponent();

            // Suplidor ------------------------------------------------------------
            this.puenteSuplidor = new(this.SuplidorModel)
            {
                BloquearCodigoLuegoDeBuscar = false,
            };
            this.puenteSuplidor.SetTextBoxCodigo(this.textBoxCodigoSuplidor);
            this.puenteSuplidor.SetBotonBuscar(this.bBuscarSuplidor);
            this.puenteSuplidor.SetTextBoxDescripcion(this.textBoxDescSuplidor);

            // Articulo ------------------------------------------------------------
            this.puenteArticulo = new(this.articuloModel);
            this.puenteArticulo.SetBotonBuscar(this.bBuscarArticulo);
            this.puenteArticulo.SetTextBoxDescripcion(this.textBoxDescArticulo);

            this.SuplidorModel.CambioModelo += SuplidorModel_CambioModelo;
            this.articuloModel.CambioModelo += ArticuloModel_CambioModelo;
            this.guardarClick += FCompras_guardarClick;
        }

        private void ArticuloModel_CambioModelo(object? sender, string? e)
        {
            this.textBoxDescArticulo.Text = this.articuloModel.Model?.descripcion_art;

            if(this.articuloModel.Model is not null)
            {
                this.textBoxPrecio.Text = this.articuloModel.Model.precio_art.ToString(Formatos.formatoMoneda);
            }
        }

        private void FCompras_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.SuplidorModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.bBuscarSuplidor, "Debe seleccionar un suplidor");
                return;
            }

            if (this.listaArticulos.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.bBuscarSuplidor, "Debe agregar articulos");
                return;
            }

            var msg = this.comprasModel.GuardarCompra(
                new()
                {
                    codsupl_com = this.SuplidorModel.Model.codent_sup,
                    fecha_compra = DateTime.Now,
                    total_compra = this.CalcularTotal(),
                },
                listaArticulos
                );
            if(!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }
            ToastController.MostrarInfo(this, msg.Msg);
            Nuevo(false);
        }

        private decimal CalcularTotal()
        {
            decimal valor = 0;
            foreach (var item in listaArticulos)
            {
                valor += item.Cantidad * item.Precio;
            }
            return valor;
        }

        private void SuplidorModel_CambioModelo(object? sender, string? e)
        {
            if (this.SuplidorModel.Model is null)
            {
                return;
            }

            this.listaArticulos.Clear();
            this.groupBox1.Enabled = false;
            this.groupBoxDetalle.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            int cod;
            try
            {
                cod = Convert.ToInt32(this.dataGridView1.Rows[e.RowIndex].Cells[ColumnCodigo.Index].Value);
            }
            catch (Exception)
            {
                return;
            }

            int index = this.listaArticulos.FindIndex(art => art.Data.cod_art == cod);
            if (index == -1)
                return;
            var art = this.listaArticulos[index];
            try
            {
                this.listaArticulos.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            this.RenderArticulos();
            this.articuloModel.Codigo = cod.ToString();
            this.textBoxCantidad.Text = art.Cantidad.ToString(Formatos.formatoMoneda);
            this.textBoxPrecio.Text = art.Precio.ToString(Formatos.formatoMoneda);
        }

        private void RenderArticulos()
        {
            this.dataGridView1.Rows.Clear();
            foreach (var item in listaArticulos)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[ColumnCodigo.Index].Value = item.Data.cod_art;
                this.dataGridView1.Rows[index].Cells[ColumnDescripcion.Index].Value = item.Data.ToString();
                this.dataGridView1.Rows[index].Cells[ColumnCantidad.Index].Value = item.Cantidad.ToString(Formatos.formatoMoneda);
                this.dataGridView1.Rows[index].Cells[ColumnPrecio.Index].Value = item.Precio.ToString(Formatos.formatoMoneda);
                this.dataGridView1.Rows[index].Cells[ColumnImporte.Index].Value = (item.Cantidad * item.Precio).ToString(Formatos.formatoMoneda);
            }

            this.labelTotal.Text = this.CalcularTotal().ToString(Formatos.formatoMoneda);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.HabilitarBotones(true, true);
                this.MostrarBotones(true, true);

                this.articuloModel.Codigo = null;
                this.SuplidorModel.Codigo = null;
                this.labelTotal.Text = 0.ToString(Formatos.formatoMoneda);
                this.dataGridView1.Rows.Clear();
                this.listaArticulos.Clear();
                this.groupBoxDetalle.Enabled = false;
                this.groupBox1.Enabled = true;
                this.textBoxCantidad.Clear();
                this.textBoxPrecio.Clear();

            }
            return valor;
        }

        private void buttonAgregar_Click_1(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.articuloModel.Model is null)
            {
                FormUtils.AddError(this.errorProvider, this.bBuscarArticulo, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (!decimal.TryParse(this.textBoxCantidad.Text, out decimal cantidad))
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCantidad, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            if (!decimal.TryParse(this.textBoxPrecio.Text, out decimal precio))
            {
                FormUtils.AddError(this.errorProvider, this.textBoxPrecio, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            if (cantidad <= 0)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCantidad, Mensajes.Msj_Error_Rango_Mayor0);
                return;
            }

            if (precio <= 0)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxPrecio, Mensajes.Msj_Error_Rango_MayorIgual0);
                return;
            }

            this.listaArticulos.Add(new()
            {
                Data = this.articuloModel.Model,
                Cantidad = cantidad,
                Precio = precio
            });

            this.articuloModel.Codigo = null;

            this.RenderArticulos();
        }

        private void FCompras_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        private void buttonEliminar_Click_1(object sender, EventArgs e)
        {
            this.articuloModel.Codigo = null;
            this.textBoxCantidad.Clear();
            this.textBoxPrecio.Clear();
        }
    }
}
