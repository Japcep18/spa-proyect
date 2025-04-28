using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FKit : BaseForm
    {
        private MembresiaModel membresiaModel = new();
        private KitConsultableModel model = new KitConsultableModel();

        private PuenteModeloUI<Membresia> membresiaPuente;
        private PuenteModeloUI<Kit> kitPuente;
        public FKit()
        {
            InitializeComponent();
            base.guardarClick += FKit_guardarClick;
            this.kitPuente = new PuenteModeloUI<Kit>(model)
            {
                Editar = true,
            };
            this.membresiaPuente = new PuenteModeloUI<Membresia>(membresiaModel)
            {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false
            };
            this.kitPuente.ProgresoCarga += kitPuente_ProgesoCarga;
            this.membresiaModel.CambioModelo += MembresiaModel_CambioModelo;
            this.model.CambioModelo += Model_CambioModelo;
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (model.Model != null)
            {
                this.textBoxCodigoKit.Text = model.Model.cod_kit.ToString();
                this.textBoxNombreKit.Text = model.Model.nombre_kit;
                this.fechaValidez.Value = model.Model.fecha_validez;
                this.membresiaModel.Codigo = model.Model.cod_mem.ToString();
                this.checkBoxActivo.Checked = model.Model.activo_kit;
            }
            else
            {
                Nuevo(false);
            }
        }

        private void MembresiaModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (this.membresiaModel.Model != null)
            {
                this.textBoxMembresiaNombre.Text = this.membresiaModel.Descripcion;
                this.groupBoxMembresia.Enabled = true;
            }
            else
            {
                this.textBoxMembresiaNombre.Clear();
            }
        }

        private void kitPuente_ProgesoCarga(object? sender, ValorProgreso e)
        {
            this.labelStatus.Text = e.Labelstatus;

            int valor = (e.ValorActual / e.ValorMax) * 100;
            this.progressBar.Value = valor > this.progressBar.Maximum ? this.progressBar.Maximum : valor;
        }

        private void FKit_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string nombre = this.textBoxNombreKit.Text;
            Membresia? membresia = this.membresiaModel.Model;

            if (nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxNombreKit, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (membresia == null)
            {
                FormUtils.AddError(errorProvider, this.textBoxMembresiaNombre, "Debe seleccionar la membresia");
                return;
            }

            bool activo = this.checkBoxActivo.Checked; 

            Kit kit = new Kit()
            {
                nombre_kit = nombre,
                cod_mem = membresia.cod_mem,
                fecha_validez = fechaValidez.Value,
                activo_kit = activo,
            };
            ObjectValidation validation = new(kit);


            if (validation.IsValid())
            {
                KitModel model = new KitModel();
                model.Model = kit;
                if (this.model.Model != null)
                {
                    model.Model.cod_kit = this.model.Model.cod_kit;
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

        private void FKit_Load(object sender, EventArgs e)
        {
            this.kitPuente.SetTextBoxCodigo(this.textBoxCodigoKit);
            this.kitPuente.SetBotonBuscar(bBuscar1);
            this.kitPuente.SetTextBoxDescripcion(this.textBoxNombreKit);

            this.membresiaPuente.SetTextBoxCodigo(this.textBoxCodigoMembresia);
            this.membresiaPuente.SetBotonBuscar(this.bBuscar2);
            this.membresiaPuente.SetTextBoxDescripcion(this.textBoxMembresiaNombre);

            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                //this.model.Codigo = null;
                this.membresiaModel.Codigo = null;
               
                this.checkBoxActivo.Checked = true;

                this.progressBar.Value = 0;

            }
            return valor;
        }
        private void materialTextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
