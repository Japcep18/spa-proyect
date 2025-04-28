using Modelos;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FDescuentoMembresia : BaseForm
    {
        private DescuentoModel descuentoModel = new();
        private MembresiaModel membresiaModel = new();
        private DescuentoMembresiaModel descuentoMembresiaModel = new();
        private PuenteModeloUI<Membresia> membresiaPuente;
        private PuenteModeloUI<Descuento> descuentoPuente;

        private List<Descuento> descuentoList = new();

        public FDescuentoMembresia()
        {
            InitializeComponent();
            base.guardarClick += FDescuentoMembresia_guardarClick;

            // MEMBRESIA ----------------------------------------------------------------
            this.membresiaPuente = new PuenteModeloUI<Membresia>(membresiaModel)
            {
                Editar = true,
                BloquearCodigoLuegoDeBuscar = false
            };
            this.membresiaPuente.SetBotonBuscar(bBuscarMembresia);
            this.membresiaPuente.SetTextBoxCodigo(textBoxCodigoMembresia);
            this.membresiaPuente.SetTextBoxDescripcion(textBoxDescMembresia);

            membresiaModel.CambioModelo += Model_CambioModelo;

            // DESCUENTOS --------------------------------------------------------------
            this.descuentoPuente = new PuenteModeloUI<Descuento>(descuentoModel)
            {
                Editar = true,
                BloquearCodigoLuegoDeBuscar = false
            };
            this.descuentoPuente.SetBotonBuscar(bBuscarDescuento);
            this.descuentoPuente.SetTextBoxCodigo(textBoxCodigoDescuento);
            this.descuentoPuente.SetTextBoxDescripcion(textBoxDescDescuento);
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (membresiaModel.Model != null)
            {
                var descuentosMsg = this.descuentoMembresiaModel.ObtenerDescuentos(this.membresiaModel.Model);

                if (descuentosMsg.State)
                {
                    // CONTROL DE INTERFAZ - TRAS SELECCIONAR MEMBRESIA NO SE PODRÁ EDITAR: Para hacerlo debe ejecutarse el método nuevo
                    this.groupBoxMembresia.Enabled = false;
                    this.groupBoxDescuento.Enabled = true;
                    // Carga de datos
                    this.dataGridView1.Rows.Clear();
                    this.labelStatus.Text = $"Se está modificando: {this.membresiaModel.Model}";

                    // RE- INICIALIZACION de la lista interna de descuentos
                    this.descuentoList = new List<Descuento>(descuentosMsg.Entity ?? []);

                    foreach (var item in this.descuentoList)
                    {
                        AgregarDescuento(item);
                    }
                }
                else
                {
                    // Manejo de errores
                    AlertaController.AlertaError(this, descuentosMsg.Msg);
                }
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        /// <summary>
        /// Agrega un descuento al datagridview, no lo hace en la lista interna
        /// </summary>
        /// <param name="item">Descuento a agregar</param>
        private void AgregarDescuento(Descuento item)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[ColumnCodigo.Index].Value = item.cod_desc;
            this.dataGridView1.Rows[index].Cells[ColumnPorcentaje.Index].Value = item.porcentaje_desc;
            this.dataGridView1.Rows[index].Cells[ColumnDesc.Index].Value = item.descripcion_desc;
            this.dataGridView1.Rows[index].Cells[ColumnFechaFin.Index].Value = item.fechafin_desc;
        }

        private void FDescuentoMembresia_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.descuentoList.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, "No se han agregado descuentos");
                return;
            }

            if (this.membresiaModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            this.descuentoMembresiaModel.Membresia = this.membresiaModel.Model;
            var msg = this.descuentoMembresiaModel.Guardar(descuentoList);

            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }

            Nuevo(false);
        }

        private void FDescuentoMembresia_Load(object sender, EventArgs e)
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
                this.progressBar.Value = 0;

                this.descuentoList = new();
                this.membresiaModel.Model = null;
                this.textBoxCodigoMembresia.Clear();
                this.textBoxDescMembresia.Clear();
                this.dataGridView1.Rows.Clear();
                this.buttonEliminar.Enabled = false;
                // - RESTAURAR PARA PODER SELECCIONAR UNA MEMBRESÍA
                this.groupBoxMembresia.Enabled = true;
                this.groupBoxDescuento.Enabled = false;
            }
            return valor;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.descuentoModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, textBoxDescDescuento, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            this.AgregarDescuento(this.descuentoModel.Model);
            this.descuentoList.Add(this.descuentoModel.Model);
            this.descuentoModel.Codigo = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // VALIDAR QUE NO SE LE DIO CLICK AL COLUMN
            if (e.RowIndex < 0)
                return;

            int descIndex = this.descuentoList.FindIndex(desc => desc.cod_desc.Equals(this.dataGridView1.Rows[e.RowIndex].Cells[ColumnCodigo.Index].Value));
            if (descIndex == -1) // SE ENCONTRÓ UN DESCUENTO
                return;

            this.descuentoModel.Codigo = this.descuentoList[descIndex].cod_desc.ToString();
            if (this.descuentoModel.Codigo == null) // SI SE ENCONTRÓ EN LA BD, QUITALO (YA ESTA CARGADO)
                return;

            this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            this.buttonEliminar.Enabled = true;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (this.descuentoModel.Model == null)
                return;

            int index = this.descuentoList.FindIndex(des => des.cod_desc == this.descuentoModel.Model.cod_desc);
            if (index != -1)
                return;

            this.descuentoList.RemoveAt(index);
            this.descuentoModel.Codigo = null;

            this.buttonEliminar.Enabled = false;
        }
    }
}
