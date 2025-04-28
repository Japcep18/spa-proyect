using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FInventario : BaseForm
    {
        private InventarioModel inventarioModel = new();

        private ArticuloConsultableModel articuloModel = new();

        private PuenteModeloUI<Articulo> articuloPuente;

        private Dictionary<int, Contable<Articulo>> articuloDictionary = new();
        public FInventario() : base()
        {
            InitializeComponent();

            // --------------------- ARTICULO -----------------------------
            this.articuloPuente = new(articuloModel);
            this.articuloPuente.SetBotonBuscar(this.bBuscarArticulo);
            this.articuloPuente.SetTextBoxCodigo(this.textBoxCodigoArticulo);
            this.articuloPuente.SetTextBoxDescripcion(this.textBoxDescArticulo);

            this.articuloModel.CambioModelo += ArticuloModel_CambioModelo;

            this.guardarClick += FInventario_guardarClick;

            // Validación de stock al agregar artículos (solo para movimientos de salida)
            this.buttonAgregarArticulo.Click += (s, ev) =>
            {
                if (radioButtonSalida.Checked && articuloModel.Model != null)
                {
                    // Validar existencia antes de agregar
                    decimal cantidad;
                    if (decimal.TryParse(textBoxCantidad.Text, out cantidad))
                    {
                        var existeStock = inventarioModel.ValidarExistencia(
                            articuloModel.Model.cod_art,
                            cantidad + (articuloDictionary.ContainsKey(articuloModel.Model.cod_art) ?
                                       articuloDictionary[articuloModel.Model.cod_art].Cantidad : 0));

                        if (!existeStock)
                        {
                            ToastController.MostrarError(this, "No hay suficiente stock disponible");
                            return;
                        }
                    }
                }
                AgregarArtículoHandler();
            };

        }

        private void FInventario_guardarClick(object? sender, EventArgs e)
        {
            if (!radioButtonEntrada.Checked && !radioButtonSalida.Checked)
            {
                FormUtils.AddError(this.errorProvider, radioButtonEntrada, "Selecciona Entrada o Salida");
                ToastController.MostrarError(this, "Debes seleccionar un tipo de movimiento (Entrada/Salida)");
                return;
            }
            string tipoMov = radioButtonEntrada.Checked ? "E" : "S";

            if (tipoMov == "S")
            {
                var existencias = inventarioModel.ObtenerExistenciasActuales();

                foreach (var item in articuloDictionary.Values)
                {
                    decimal existenciaActual = existencias.TryGetValue(item.Data.cod_art, out decimal stock) ? stock : 0;
                    if (existenciaActual < item.Cantidad)
                    {
                        string mensaje = $"Stock insuficiente para {item.Data.descripcion_art}\n" +
                                        $"Disponible: {existenciaActual} | Requerido: {item.Cantidad}";

                        ToastController.MostrarError(this, mensaje);
                        return;
                    }
                }
            }

            decimal total = CalcularTotalInventario();
            // Validar que el total sea positivo
            if (total <= 0)
            {
                ToastController.MostrarError(this, "El total debe ser mayor que cero");
                return;
            }

            if (this.articuloDictionary.Count == 0)
            {
                ToastController.MostrarError(this, "No hay artículos seleccionados");
                return;
            }

            Invent invent = new()
            {
                tipmov = tipoMov,
                fecha_inv = DateTime.Now,
                total_inv = total,
            };


            var msg = this.inventarioModel.GuardarInventario(invent, this.articuloDictionary.Values);

            if (msg.State)
            {
                ToastController.MostrarInfo(this, Mensajes.Msj_Aviso_RegistroGuardado);
                Nuevo(false);
            }
            else
            {
                ToastController.MostrarError(this, msg.Msg);
            }

        }

        private decimal CalcularTotalInventario()
        {
            return articuloDictionary.Values.Sum(item => item.Cantidad * item.Data.precio_art);
        }

        private void ArticuloModel_CambioModelo(object? sender, string? e)
        {
            if (this.articuloModel.Model != null)
            {
                this.textBoxCantidad.Select();
            }
            else
            {

            }
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                HabilitarBotones(true, true);
                MostrarBotones(true, true);
                this.articuloDictionary = new();
                this.buttonEliminarArticulo.Enabled = false;
                this.dataGridViewArticulo.Rows.Clear();
                this.labelTotal.Text = 0.ToString(Formatos.formatoMoneda);    
            }
            return valor;
        }
        private void FInventario_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        private void dataGridViewServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPageArticulo_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //ARTICULOS
        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToChar(Keys.Enter) == e.KeyChar)
                this.AgregarArtículoHandler();
        }
        private void AgregarArtículoHandler()
        {
            if (this.articuloModel.Model == null)
            {
                ToastController.MostrarError(this, "No hay artículo seleccionado");
                return;
            }

            Articulo articulo = this.articuloModel.Model;

            // -- LOGICA PARA AGREGAR EL ARTICULO
            // ------------------- VALIDACION ------------------------------
            this.errorProvider.Clear();

            if (this.textBoxCantidad.Text.Trim().Length == 0)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCantidad, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (!decimal.TryParse(this.textBoxCantidad.Text, out decimal cantidad))
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCantidad, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }
            // ------------------- ---------- ------------------------------
            this.AgregarArticulo(articulo, cantidad);
        }
        private void AgregarArticulo(Articulo articulo, decimal cantidad)
        {
            if (!this.articuloDictionary.ContainsKey(articulo.cod_art))
                this.articuloDictionary.Add(articulo.cod_art, new()
                {
                    Data = articulo,
                    Cantidad = cantidad,
                });
            else
            {
                this.articuloDictionary[articulo.cod_art].Cantidad += cantidad;
            }

            this.textBoxCantidad.Clear();
            this.textBoxPrecioUnitario.Clear(); 
            this.articuloModel.Codigo = null;
            this.RenderArticulos();
            // -- 

            this.ReCalcularTotal();
        }

        private void RenderArticulos()
        {
            this.dataGridViewArticulo.Rows.Clear();
            foreach (var item in articuloDictionary.Values)
            {
                int index = this.dataGridViewArticulo.Rows.Add();

                this.dataGridViewArticulo.Rows[index].Cells[ColumnCodigoArticulo.Index].Value = item.Data.cod_art.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnDescArticulo.Index].Value = item.Data.descripcion_art.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnPrecioUnitario.Index].Value = item.Data.precio_art.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnCantidadArticulo.Index].Value = item.Cantidad.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnImporteArt.Index].Value
                   = PreciosManager.ObtenerImporte(item.Data, item.Cantidad).ToString(Formatos.formatoMoneda);
            }
            this.ReCalcularTotal();
        }

        private void ReCalcularTotal()
        {
            decimal total = CalcularTotalInventario();
            this.labelTotal.Text = total.ToString(Formatos.formatoMoneda);

            // ACUMULADOR - REF: https://learn.microsoft.com/en-us/dotnet/api/system.linq.data.aggregate?view=net-9.0
            // Contar artículos
            //total += articuloDictionary.Values
            //    .Aggregate(0,
            //    (decimal acc, Contable<Articulo> item) =>
            //    // importante mult. por la cantidad      Acumulador
            //    (item.Cantidad * item.Data.precio_art) + acc);

           // this.labelTotal.Text = total.ToString(Formatos.formatoMoneda);
        }

        private void buttonAgregarArticulo_Click(object sender, EventArgs e)
        {
            AgregarArtículoHandler();
        }
    }
}

