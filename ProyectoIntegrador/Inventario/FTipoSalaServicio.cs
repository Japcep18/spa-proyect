using Modelos;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FTipoSalaServicio : BaseForm
    {
        private TipoSalaModel tipoSalaModel = new();
        private ServicioModel servicioModel = new();
        private TipoSalaServicioModel tipoSalaServicioModel = new();

        private PuenteModeloUI<TipoSala> tipoSalaPuente;
        private PuenteModeloUI<Servicio> servicioPuente;

        private List<TipoSala> tipoSalaList = new();
        public FTipoSalaServicio()
        {
            InitializeComponent();
            base.guardarClick += FTipoSalaServicio_guardarClick;

            //Servicio
            this.servicioPuente = new PuenteModeloUI<Servicio>(servicioModel)
            {
                Editar = true,
                BloquearCodigoLuegoDeBuscar = false
            };
            this.servicioPuente.SetBotonBuscar(bBuscarServicio);
            this.servicioPuente.SetTextBoxCodigo(textBoxCodigoServicio);
            this.servicioPuente.SetTextBoxDescripcion(textBoxDescServicio);

            servicioModel.CambioModelo += Model_CambioModelo;

            //Tipo Sala
            this.tipoSalaPuente = new PuenteModeloUI<TipoSala>(tipoSalaModel)
            {
                Editar = true,
                BloquearCodigoLuegoDeBuscar = false
            };
            this.tipoSalaPuente.SetBotonBuscar(bBuscarTiposala);
            this.tipoSalaPuente.SetTextBoxCodigo(textBoxCodigoTiposala);
            this.tipoSalaPuente.SetTextBoxDescripcion(textBoxDescTiposala);
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (servicioModel.Model != null)
            {
                var tiposalamsg = this.tipoSalaServicioModel.ObtenerServicios(this.servicioModel.Model);

                if (tiposalamsg.State)
                {
                    // CONTROL DE INTERFAZ - TRAS SELECCIONAR MEMBRESIA NO SE PODRÁ EDITAR: Para hacerlo debe ejecutarse el método nuevo
                    this.groupBoxServicio.Enabled = false;
                    this.groupBoxTiposala.Enabled = true;
                    // Carga de datos
                    this.dataGridView1.Rows.Clear();
                    this.labelStatus.Text = $"Se está modificando: {this.servicioModel.Model}";

                    // RE- INICIALIZACION de la lista interna de descuentos
                    this.tipoSalaList = new List<TipoSala>(tiposalamsg.Entity ?? []);

                    foreach (var item in this.tipoSalaList)
                    {
                        AgregarTiposala(item);
                    }
                }
                else
                {
                    // Manejo de errores
                    AlertaController.AlertaError(this, tiposalamsg.Msg);
                }
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        private void AgregarTiposala(TipoSala item)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[ColumnCodigo.Index].Value = item.cod_tsal;
            this.dataGridView1.Rows[index].Cells[ColumnDesc.Index].Value = item.nombre_tsal;
        }

        private void FTipoSalaServicio_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.tipoSalaList.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, "No se han agregado las salas");
                return;
            }

            if (this.servicioModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            this.tipoSalaServicioModel.Servicio = this.servicioModel.Model;
            var msg = this.tipoSalaServicioModel.Guardar(tipoSalaList);

            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
                return;
            }

            Nuevo(false);
        }

        private void FTipoSalaServicio_Load(object sender, EventArgs e)
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

                this.tipoSalaList = new();
                this.servicioModel.Model = null;
                this.textBoxCodigoServicio.Clear();
                this.textBoxDescServicio.Clear();
                this.dataGridView1.Rows.Clear();
                this.buttonEliminar.Enabled = false;

                this.groupBoxServicio.Enabled = true;
                this.groupBoxTiposala.Enabled = false;
            }
            return valor;
        }
        private void groupBoxMembresia_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            if (this.tipoSalaModel.Model == null)
            {
                FormUtils.AddError(this.errorProvider, textBoxDescTiposala, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            this.AgregarTiposala(this.tipoSalaModel.Model);
            this.tipoSalaList.Add(this.tipoSalaModel.Model);
            this.tipoSalaModel.Codigo = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int tsalIndex = this.tipoSalaList.FindIndex(tsal => tsal.cod_tsal.Equals(this.dataGridView1.Rows[e.RowIndex].Cells[ColumnCodigo.Index].Value));
            if (tsalIndex == -1) // SE ENCONTRÓ UN DESCUENTO
                return;

            this.tipoSalaModel.Codigo = this.tipoSalaList[tsalIndex].cod_tsal.ToString();
            if (this.tipoSalaModel.Codigo == null) // SI SE ENCONTRÓ EN LA BD, QUITALO (YA ESTA CARGADO)
                return;

            this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            this.buttonEliminar.Enabled = true;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (this.tipoSalaModel.Model == null)
                return;

            int index = this.tipoSalaList.FindIndex(tsal => tsal.cod_tsal == this.tipoSalaModel.Model.cod_tsal);
            if (index != -1)
                return;

            this.tipoSalaList.RemoveAt(index);
            this.tipoSalaModel.Codigo = null;

            this.buttonEliminar.Enabled = false;
        }
    }
}
