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
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FPuesto : BaseForm
    {
        private PuestoModel model = new PuestoModel();
        private PuenteModeloUI<Puesto> puestoPuente;
        public FPuesto()
        {
            InitializeComponent();
            base.guardarClick += FPuesto_guardarClick;
            this.puestoPuente = new PuenteModeloUI<Puesto>(model)
            {
                Editar = true,
            };
            model.CambioModelo += Model_CambioModel;
        }

        private void Model_CambioModel(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (model.Model != null)
            {
                this.textBoxCodigoPues.Text = model.Model.cod_pue.ToString();
                this.textBoxDescripcionPues.Text = model.Model.descr_pue;
                this.textBoxSueldoPues.Text = model.Model.sueldobase_pue.ToString(Formatos.formatoMoneda);

                this.labelStatus.Text = $"Se está modificando: {this.model.Model}";
            }
            else
            {
                Nuevo(false);
            }
        }

        private void FPuesto_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string nombre = this.textBoxDescripcionPues.Text;
            string sueldobase_str = this.textBoxSueldoPues.Text;

            if (nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionPues, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (!double.TryParse(sueldobase_str, out double sueldobase_pue))
            {
                FormUtils.AddError(errorProvider, this.textBoxSueldoPues, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            Puesto pues = new Puesto()
            {
                descr_pue = nombre,
                sueldobase_pue = (decimal) sueldobase_pue,
            };

            ObjectValidation validation = new(pues);

            if (validation.IsValid())
            {
                PuestoModel model = new PuestoModel();
                model.Model = pues;
                if (this.model.Model != null)
                {
                    model.Model.cod_pue = this.model.Model.cod_pue;
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
        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.model = new();
                this.model.CambioModelo += Model_CambioModel;
                this.puestoPuente.Modelo = this.model;

                this.puestoPuente.SetTextBoxCodigo(this.textBoxCodigoPues);
                this.puestoPuente.SetBotonBuscar(bBuscar1);
                this.puestoPuente.SetTextBoxDescripcion(this.textBoxDescripcionPues);

                this.progressBar.Value = 0;
            }
            return valor;
        }

        private void FEstadoSala_Load_1(object sender, EventArgs e)
        {
            Nuevo(false);
        }


    }
}
