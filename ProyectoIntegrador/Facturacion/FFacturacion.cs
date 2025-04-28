using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using Presentacion.Support;
using ProyectoIntegrador.Inventario;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Facturacion
{
    public partial class FFacturacion : BaseForm
    {
        private CitaConsultableModel citasModel = new();
        private VentaModel ventaModel = new();

        private const int GUARDERIA_SERVICIO_COD = 3;

        private ClienteConsultableModel clienteModel = new();
        private ServicioModel servicioModel = new();
        private ArticuloConsultableModel articuloModel = new();
        private EmpleadoConsultableModel empleadoModel = new();
        private SalaConsultableModel salaConsultableModel = new()
        {
            PermiteReservarFiltro = true,
            SoloActivosFiltro = true,
        };

        private List<Guarderia> guarderiaDetalleList = new();

        private PuenteModeloUI<Cliente> clientePuente;
        private PuenteModeloUI<Servicio> servicioPuente;
        private PuenteModeloUI<Articulo> articuloPuente;
        private PuenteModeloUI<Empleado> empleadoPuente;
        private PuenteModeloUI<Sala> salaPuente;

        private Dictionary<int, Servicio> servicioDictionary = new();
        private Dictionary<int, Contable<Articulo>> articuloDictionary = new();
        private Dictionary<int, Empleado> empleadoDictionary = new();

        private decimal porcentaje_descuento = 0;

        public FFacturacion() : base()
        {
            InitializeComponent();

            // ---------------------- CLIENTE -----------------------------
            this.clientePuente = new(this.clienteModel);
            this.clientePuente.SetTextBoxDescripcion(this.textBoxDescCliente);
            this.clienteModel.CambioModelo += ClienteModel_CambioModelo;

            // --------------------- SERVICIO -----------------------------
            this.servicioPuente = new(servicioModel)
            {
                BloquearCodigoLuegoDeBuscar = false
            };
            this.servicioPuente.SetBotonBuscar(this.bBuscarServicio);
            this.servicioPuente.SetTextBoxCodigo(this.textBoxCodigoServicio);
            this.servicioPuente.SetTextBoxDescripcion(this.textBoxDescServicio);

            // --------------------- ARTICULO -----------------------------
            this.articuloPuente = new(articuloModel)
            {
                BloquearCodigoLuegoDeBuscar = false
            };
            this.articuloPuente.SetBotonBuscar(this.bBuscarArticulo);
            this.articuloPuente.SetTextBoxCodigo(this.textBoxCodigoArticulo);
            this.articuloPuente.SetTextBoxDescripcion(this.textBoxDescArticulo);

            this.articuloModel.CambioModelo += ArticuloModel_CambioModelo;

            // --------------------- EMPLEADO -----------------------------
            this.empleadoPuente = new(this.empleadoModel)
            {
                BloquearCodigoLuegoDeBuscar = false
            };
            this.empleadoPuente.SetBotonBuscar(this.bBuscarEmpleado);
            this.empleadoPuente.SetTextBoxCodigo(this.textBoxCodigoEmpleado);
            this.empleadoPuente.SetTextBoxDescripcion(this.textBoxDescEmpleado);

            // -------------------- SALA ----------------------------------
            this.salaPuente = new(this.salaConsultableModel)
            {
                BloquearCodigoLuegoDeBuscar = false,
            };
            this.salaPuente.SetTextBoxDescripcion(this.textBoxDescSala);

            this.salaConsultableModel.CambioModelo += SalaConsultableModel_CambioModelo;

            this.guardarClick += FFacturacionCitas_guardarClick;
        }

        private void ClienteModel_CambioModelo(object? sender, string? e)
        {
            if (this.clienteModel.Model is null)
            {
                this.porcentaje_descuento = 0;
            }
            else
            {
                EntityMessage<decimal> msg = this.clienteModel.ObtenerDescuento();
                if (!msg.State)
                {
                    AlertaController.AlertaError(this, msg.Msg);
                    this.porcentaje_descuento = 0;
                }
                else
                {
                    this.porcentaje_descuento = msg.Entity;
                }
            }

            this.ReCalcularTotal();
        }

        private void SalaConsultableModel_CambioModelo(object? sender, string? e)
        {
            this.servicioModel.tipoSalaFiltro = this.salaConsultableModel.Model?.codtsal_sala;

            if (this.salaConsultableModel.Model == null)
                return;

            this.textBoxDescSala.Text = this.salaConsultableModel.Model.nombre_sala;
        }

        private void ArticuloModel_CambioModelo(object? sender, string? e)
        {
            if (this.articuloModel.Model != null)
            {
                if (!this.tabPageArticulos.Focused)
                    this.tabPageArticulos.Select();
                this.textBoxCantidad.Select();
            }
        }

        private void FFacturacionCitas_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();

            if (this.servicioDictionary.Count == 0)
            {
                ToastController.MostrarError(this, "No hay servicios seleccionados");
                return;
            }

            if (this.clienteModel.Codigo == null)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxDescCliente, "No hay un cliente seleccionado");
                return;
            }

            //if (this.dateTimePicker1.Value.Date < DateTime.Now.Date)
            //{
            //    FormUtils.AddError(this.errorProvider, this.dateTimePicker1, "La fecha no puede ser antes que hoy");
            //    return;
            //}

            if (!int.TryParse(clienteModel.Codigo, out int codcli))
            {
                FormUtils.AddError(this.errorProvider, this.textBoxDescCliente, "No hay un cliente seleccionado");
                return;
            }

            if (this.empleadoDictionary.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.bBuscarEmpleado, "No hay un empleado seleccionado");
                return;
            }

            if (this.salaConsultableModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxDescSala, "No hay una sala seleccionada");
                return;
            }

            if(this.servicioDictionary.Values.FirstOrDefault( (serv) => serv.cod_ser == GUARDERIA_SERVICIO_COD ) is not null)
            {
                if(this.guarderiaDetalleList.Count == 0)
                {
                    FormUtils.AddError(this.errorProvider, this.tabPageDetallesGuarderia, "No se han agregado padres y tutores en los detalles de la guardería");
                    return;
                }
            }

            if (!this.servicioDictionary.Values.Any(srv => !(srv.complemento_ser ?? false)))
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCodigoServicio, "Debe seleccionar al menos un servicio no complementario");
                return;
            }

            // Inicializar obj
            Cita cita = new()
            {
                codcli_cita = codcli,
                fecha_cita = this.dateTimePicker1.Value,
                codsala_cita = this.salaConsultableModel.Model.cod_sala,
                observaciones = this.multiLineTextBoxObservaciones.Text,
                codecit_cita = 1, // Estado: Activo
            };

            if (this.citasModel.Model != null)
            {
                // Lógica para editar
                cita.state = EntityState.Modificado;
                cita.cod_cita = this.citasModel.Model.cod_cita;
            }

            // VALIDAR DISPONIBILIDAD --------------------
            int minutos = ServicioModel.ObtenerMinutosDeServicio([.. this.servicioDictionary.Values]);
            var dispCita = this.citasModel.CalcularDisponibilidadCita(cita, minutos);

            if (!dispCita.State)
            {
                AlertaController.AlertaError(this, dispCita.Msg);
                return;
            }

            if (!dispCita.Entity)
            {
                FormUtils.AddError(this.errorProvider, this.dateTimePicker1, "La fecha seleccionada ya está ocupada en la sala seleccionada");
                return;
            }

            EntityMessage<decimal> artMsg;
            foreach (var item in articuloDictionary.Values)
            {
                artMsg = this.citasModel.ComprobarArticulo(item.Data);
                if (!artMsg.State)
                {
                    AlertaController.AlertaError(this, artMsg.Msg);
                    return;
                }

                if (artMsg.Entity < item.Cantidad)
                {
                    AlertaController.AlertaError(this, $"Existencia insuficiente de: {item.Data}");
                    return;
                }
            }
            // -------------------------------------------

            Tuple<decimal, decimal, decimal> tuple = this.ReCalcularTotal();
            Venta venta = new()
            {
                codcita_ven = cita.cod_cita,
                codcli_ven = cita.codcli_cita,
                fecha_ven = DateTime.Now,
                monto_ven = tuple.Item1,
                total_descuento = tuple.Item2,
                total_neto = tuple.Item3,
                state = EntityState.Agregado,
            };

            EntityMessage<object?> msg = this.ventaModel.Guardar(venta, cita, servicioDictionary.Values, articuloDictionary.Values, empleadoDictionary.Values, this.guarderiaDetalleList);

            if (msg.State)
            {
                ToastController.MostrarInfo(this, Mensajes.Msj_Aviso_RegistroGuardado);
                Nuevo(false);
            }
            else
            {
                AlertaController.AlertaError(this, msg.Msg);
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
                this.servicioDictionary = new();
                this.empleadoDictionary = new();
                this.guarderiaDetalleList = new();

                this.buttonEliminarServicio.Enabled = false;
                this.buttonEliminarArticulo.Enabled = false;
                this.buttonEliminarEmpleado.Enabled = false;

                this.dataGridViewArticulo.Rows.Clear();
                this.dataGridViewEmpleado.Rows.Clear();
                this.dataGridViewServicio.Rows.Clear();
                this.dataGridViewGuardería.Rows.Clear();

                string zero_formated = 0.ToString(Formatos.formatoMoneda);
                this.labelTotal.Text = zero_formated;
                this.labelTiempoEstimado.Text = zero_formated;
                this.labelStatus.Text = "Nuevo";
                this.multiLineTextBoxObservaciones.Text = "";
                this.dateTimePicker1.Value = DateTime.Now;
                this.porcentaje_descuento = 0;

                this.articuloModel.Codigo = null;
                this.salaConsultableModel.Codigo = null;

                if(materialTabControl1.TabPages.Contains(this.tabPageDetallesGuarderia))
                    this.materialTabControl1.TabPages.Remove(this.tabPageDetallesGuarderia);
            }
            return valor;
        }

        private void FAgendarCitas_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        #region Servicio
        private void buttonAgregarServicio_Click(object sender, EventArgs e)
        {
            if (this.servicioModel.Model == null)
            {
                ToastController.MostrarError(this, "No hay servicio seleccionado");
                return;
            }

            Servicio servicio = this.servicioModel.Model;
            if (this.servicioDictionary.ContainsKey(servicio.cod_ser))
            {
                ToastController.MostrarInfo(this, "Ya se ha seleccionado el servicio");
                return;
            }
            AgregarServicio(servicio);

            var artMsg = this.articuloModel.CargarArticuloDeServicio(this.servicioModel.Model);
            if (artMsg.State)
            {
                IEnumerable<Contable<Articulo>> data = (artMsg.Entity ?? []);
                if (data.Any())
                {
                    if (AlertaController.AlertaConfirmar(this, "¿Desea agregar los artículos asociados al servicio?") == DialogResult.OK)
                    {
                        foreach (Contable<Articulo> item in data)
                        {
                            this.AgregarArticulo(item.Data, item.Cantidad);
                        }
                        this.RenderArticulos();
                        ToastController.MostrarInfo(this, $"Se han agregado los articulos del servicio: {this.servicioModel.Model}");
                    }
                }
            }
            else
            {
                ToastController.MostrarError(this, artMsg.Msg);
            }
            this.servicioModel.Codigo = null;

            this.ReCalcularTotal();
        }

        private void AgregarServicio(Servicio servicio)
        {
            // LOGICA PARA AGREGAR EL SERVICIO
            if (!this.servicioDictionary.ContainsKey(servicio.cod_ser))
                this.servicioDictionary.Add(servicio.cod_ser, servicio);
            else
            {
                ToastController.MostrarInfo(this, "Ya se ha seleccionado el servicio");
                return;
            }

            // ---------- GUARDERIA ----------------------
            if (servicio.cod_ser == GUARDERIA_SERVICIO_COD)
                if(!this.materialTabControl1.TabPages.Contains(this.tabPageDetallesGuarderia))
                    this.materialTabControl1.TabPages.Add(this.tabPageDetallesGuarderia);

            int index = this.dataGridViewServicio.Rows.Add();

            this.dataGridViewServicio.Rows[index].Cells[ColumnCodigoServicio.Index].Value = servicio.cod_ser;
            this.dataGridViewServicio.Rows[index].Cells[ColumnDescServicio.Index].Value = servicio.desc_ser;
            this.dataGridViewServicio.Rows[index].Cells[ColumnPrecioServicio.Index].Value = servicio.preciobase_ser;
        }

        private void buttonEliminarServicio_Click(object sender, EventArgs e)
        {
            if (this.servicioModel.Model == null)
                return;

            this.buttonEliminarServicio.Enabled = false;
            this.servicioModel.Codigo = null;
        }

        private void dataGridViewServicio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var codigo = this.dataGridViewServicio.Rows[e.RowIndex].Cells[ColumnCodigoServicio.Index].Value as int?;
            if (codigo != null)
            {
                this.servicioModel.Codigo = codigo.ToString();
                if (this.servicioModel.Model != null)
                {
                    this.buttonEliminarServicio.Enabled = true;
                    this.dataGridViewServicio.Rows.RemoveAt(e.RowIndex);

                    if (this.servicioDictionary.ContainsKey(codigo.Value))
                        this.servicioDictionary.Remove(codigo.Value);

                    if (this.materialTabControl1.TabPages.Contains(this.tabPageDetallesGuarderia))
                        this.materialTabControl1.TabPages.Remove(this.tabPageDetallesGuarderia);
                }
            }
        }
        #endregion

        // No hace falta un método para remover
        #region Articulos
        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToChar(Keys.Enter) == e.KeyChar)
                this.AgregarArtículoHandler();
        }

        private void buttonAgregarArticulo_Click(object sender, EventArgs e)
        {
            AgregarArtículoHandler();
        }

        /// <summary>
        /// Toma los datos de la UI, los valida y los agrega a la lista de artículo.
        /// </summary>
        private void AgregarArtículoHandler()
        {
            this.errorProvider.Clear();


            // -- LOGICA PARA AGREGAR EL ARTICULO
            // ------------------- VALIDACION ------------------------------
            if (this.articuloModel.Model == null)
            {
                ToastController.MostrarError(this, "No hay artículo seleccionado");
                return;
            }
            Articulo articulo = this.articuloModel.Model;

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
            var msg = this.citasModel.ComprobarArticulo(articulo);
            if (!msg.State)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCodigoArticulo, msg.Msg);
                return;
            }

            if (msg.Entity < cantidad)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCodigoArticulo, $"Existencia insuficiente del artículo: {articulo}");
                this.tabPageArticulos.Select();
                return;
            }

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

            this.articuloModel.Codigo = null;
            this.RenderArticulos();
            // -- 

            this.ReCalcularTotal();
        }

        private void buttonEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (this.articuloModel.Model == null)
                return;

            this.buttonEliminarArticulo.Enabled = false;
            this.articuloModel.Codigo = null;
        }

        private void dataGridViewArticulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int codigo;
            if (
                    !int.TryParse(
                    this.dataGridViewArticulo.Rows[e.RowIndex]
                    .Cells[ColumnCodigoArticulo.Index].Value.ToString(),
                    out codigo)
                )
                return;

            this.articuloModel.Codigo = codigo.ToString();
            if (this.articuloModel.Model == null)
                return;

            this.buttonEliminarArticulo.Enabled = true;
            this.articuloDictionary.Remove(codigo);
            this.textBoxCantidad.Text =
                this.dataGridViewArticulo
                .Rows[e.RowIndex]
                .Cells[ColumnCantidadArticulo.Index]
                .Value.ToString();
            // this.dataGridViewArticulo.Rows.RemoveAt(e.RowIndex);
            this.RenderArticulos();
            this.ReCalcularTotal();
        }

        private void RenderArticulos()
        {
            this.dataGridViewArticulo.Rows.Clear();
            foreach (var item in articuloDictionary.Values)
            {
                int index = this.dataGridViewArticulo.Rows.Add();

                this.dataGridViewArticulo.Rows[index].Cells[ColumnCodigoArticulo.Index].Value = item.Data.cod_art.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnDescripcionArticulo.Index].Value = item.Data.descripcion_art.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnPrecioArticulo.Index].Value = item.Data.precio_art.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnCantidadArticulo.Index].Value = item.Cantidad.ToString();
                this.dataGridViewArticulo.Rows[index].Cells[ColumnImporteArticulo.Index].Value
                    = PreciosManager.ObtenerImporte(item.Data, item.Cantidad).ToString(Formatos.formatoMoneda);
            }
            this.ReCalcularTotal();
        }

        #endregion

        #region Empleado
        private void buttonEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (this.empleadoModel.Model == null)
                return;

            this.buttonEliminarEmpleado.Enabled = false;
            this.empleadoModel.Codigo = null;
        }

        private void ButtonAgregarEmpleado_Click(object sender, EventArgs e)
        {
            // VALIDAR QUE SE HAYA SELECCIONADO UN EMPLEADO
            if (this.empleadoModel.Model == null)
                return;

            Empleado empleado = this.empleadoModel.Model;
            AgregarEmpleado(empleado);
        }

        private void AgregarEmpleado(Empleado empleado)
        {
            // VALIDAR DISPONIBILIDAD DE EMPLEADO PARA ESA FECHA ---------
            var validarEmpMsg = this.citasModel.CalcularDisponibilidadEmpleado(
                DateUtils.TrimSeconds(this.dateTimePicker1.Value),
                empleado,
                this.citasModel.Model?.cod_cita
            );

            this.errorProvider.Clear();

            // -------- Manejo de error ----------
            if (!validarEmpMsg.State)
            {
                AlertaController.AlertaError(this, validarEmpMsg.Msg);
                return;
            }
            // --- Comprobar disponibilidad
            if (!validarEmpMsg.Entity)
            {
                FormUtils.AddError(this.errorProvider, this.textBoxCodigoEmpleado, "El empleado ya está reservado para otra cita en esa fecha");
                this.tabPagePersonal.Select();
                return;
            }

            if (this.empleadoDictionary.Values.Any(emp => emp.puesto == empleado.puesto))
            {
                DialogResult opcion = AlertaController.AlertaConfirmar(this, "Ya hay otro empleado con el mismo puesto ¿Desea agregar otro más?");
                if (opcion != DialogResult.OK)
                {
                    return;
                }
            }

            // -----------------------------------------------------------
            if (!this.empleadoDictionary.ContainsKey(empleado.codent_emp))
            {
                int index = this.dataGridViewEmpleado.Rows.Add();
                this.dataGridViewEmpleado.Rows[index].Cells[ColumnCodigoEmpleado.Index].Value = empleado.codent_emp;
                this.dataGridViewEmpleado.Rows[index].Cells[ColumnDescEmpleado.Index].Value = empleado.descripcion;
                this.dataGridViewEmpleado.Rows[index].Cells[ColumnPuestoEmpleado.Index].Value = empleado.puesto;

                this.empleadoDictionary.Add(empleado.codent_emp, empleado);
            }
            else
                ToastController.MostrarInfo(this, "El empleado ya ha sido agregado");

            // LIMPIAR CODIGO
            this.empleadoModel.Codigo = null;
        }

        private void dataGridViewEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var codigo = this.dataGridViewEmpleado.Rows[e.RowIndex].Cells[ColumnCodigoEmpleado.Index].Value as int?;
            if (codigo == null)
                return;

            this.empleadoModel.Codigo = codigo.ToString();
            if (this.empleadoModel.Model == null)
                return;

            this.buttonEliminarEmpleado.Enabled = true;
            this.dataGridViewEmpleado.Rows.RemoveAt(e.RowIndex);
            this.empleadoDictionary.Remove(codigo.Value);
        }
        #endregion

        #region General
        /// <summary>
        /// Agregar la lógica para calcular el bruto de la cita
        /// </summary>
        private Tuple<decimal, decimal, decimal> ReCalcularTotal()
        {
            decimal bruto = 0;
            int tiempo = ServicioModel.ObtenerMinutosDeServicio([.. servicioDictionary.Values]);

            // ACUMULADOR - REF: https://learn.microsoft.com/en-us/dotnet/api/system.linq.data.aggregate?view=net-9.0
            // Contar artículos
            bruto += articuloDictionary.Values
                .Aggregate(0,
                (decimal acc, Contable<Articulo> item) =>
                // importante mult. por la cantidad      Acumulador
                (item.Cantidad * item.Data.precio_art) + acc);

            bruto += servicioDictionary.Values
                .Aggregate(0,
                (decimal acc, Servicio serv) => serv.preciobase_ser + acc);

            decimal descuento = (bruto * (this.porcentaje_descuento / 100));
            decimal neto = bruto - descuento;

            // ACTUALIZAR LABELS //
            this.labelSinDescuento.Text = bruto.ToString(Formatos.formatoMoneda);
            this.labelTiempoEstimado.Text = tiempo.ToString();
            this.labelTotal.Text = neto.ToString(Formatos.formatoMoneda);
            this.labelDescuento.Text = $"{Math.Round(this.porcentaje_descuento):0}%";
            // ----------------- //

            return Tuple.Create(bruto, descuento, neto);
        }
        #endregion

        #region Sala

        #endregion

        #region Carga de datos
        private void buttonBuscarCitas_Click(object sender, EventArgs e)
        {
            // Define si hay datos editándose
            bool hay_datos =
                this.servicioDictionary.Count != 0 ||
                this.articuloDictionary.Count != 0 ||
                this.empleadoDictionary.Count != 0 ||
                this.multiLineTextBoxObservaciones.Text.Trim().Length != 0;

            if (hay_datos)
            {
                if (AlertaController.AlertaConfirmar(this, "Hay datos editándose ¿Desea continuar?") == DialogResult.Cancel)
                    return;
            }

            this.citasModel.SoloActivos = true;
            EntityMessage<IEnumerable<Cita>> data = this.citasModel.CargarDatos();
            if (!data.State)
            {
                AlertaController.AlertaError(this, data.Msg);
                return;
            }

            IConsultable consulta = new Consulta(citasModel.GetDataTable(data.Entity ?? []));
            consulta.ShowDialog();

            System.Data.DataRow? row = consulta.GetSelectedRow();
            if (row != null)
            {
                this.Nuevo(false);
                var selectedData = DataManager.DataRowToObject<CitaConsultable>(row);
                if (selectedData != null)
                {
                    Cita? cita = this.citasModel.Obtener(selectedData.cod_cita.ToString());
                    if (cita is not null)
                    {
                        this.textBoxDescCliente.Text = $"{selectedData.cliente_cita}";
                        this.CargarData(cita);
                    }
                }
            }
        }

        private void CargarData(Cita cita)
        {
            this.citasModel.Model = cita;

            // VALIDAR DATOS
            var empMsg = this.empleadoModel.CargarDatos(cita);

            if (!empMsg.State)
            {
                AlertaController.AlertaError(this, empMsg.Msg);
                return;
            }

            var artMsg = this.articuloModel.CargarDatos(cita);

            if (!artMsg.State)
            {
                AlertaController.AlertaError(this, artMsg.Msg);
                return;
            }

            var serMsg = this.servicioModel.CargarDatos(cita);

            if (!serMsg.State)
            {
                AlertaController.AlertaError(this, serMsg.Msg);
                return;
            }

            // CARGA DE DATOS

            // - Empleado --
            foreach (var item in (empMsg.Entity ?? []))
            {
                this.AgregarEmpleado(item);
            }

            // -- Servicio --
            foreach (var item in (serMsg.Entity ?? []))
            {
                this.AgregarServicio(item);
            }

            // --- Articulo --
            foreach (var item in (artMsg.Entity ?? []))
            {
                this.AgregarArticulo(item.Data, item.Cantidad);
            }

            // ---- Cliente --
            this.clienteModel.Codigo = cita.codcli_cita.ToString();

            // ------ Sala --
            this.salaConsultableModel.Codigo = cita.codsala_cita.ToString();

            // ------- Observaciones --
            this.multiLineTextBoxObservaciones.Text = cita.observaciones;

            this.labelStatus.Text = $"Facturando la cita #{cita.cod_cita}";
            this.dateTimePicker1.Value = cita.fecha_cita;
        }
        #endregion

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            FGuarderia guarderia = new(this.guarderiaDetalleList);
            guarderia.ShowDialog();
            // CAPTAR LA LISTA DE TUTORES Y NIÑOS DE LA VENTANA
            List<Guarderia> lista = guarderia.ObtenerDatos();
            this.guarderiaDetalleList = lista;

            this.dataGridViewGuardería.Rows.Clear();
            foreach (var item in lista.OrderBy(r => r.secuen_guar))
            {
                int index = dataGridViewGuardería.Rows.Add();
                this.dataGridViewGuardería.Rows[index].Cells[columnSecuenciaGuarderia.Index].Value = item.secuen_guar;
                this.dataGridViewGuardería.Rows[index].Cells[columnTutor.Index].Value = item.tutor_guar;
                this.dataGridViewGuardería.Rows[index].Cells[columnInfante.Index].Value = item.infante_guar;
            }
        }
    }
}
