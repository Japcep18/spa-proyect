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
    public partial class FTipoDocumento : BaseForm
    {
        private TipoDocumentoModel model = new TipoDocumentoModel();
        private PuenteModeloUI<TipoDocumento> tipoDocumentoPuente;
        public FTipoDocumento()
        {
            InitializeComponent();
            base.guardarClick += FTipoDocumento_guardarClick;
            this.tipoDocumentoPuente = new PuenteModeloUI<TipoDocumento>(model)
            {
                Editar = true,
            };
            model.CambioModelo += Model_CambioModelo;
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (model.Model != null)
            {
                this.textBoxCodigoTdoc.Text = model.Model.cod_tdoc.ToString();
                this.textBoxDescripcionTdoc.Text = model.Model.descr_tdoc;

                this.labelStatus.Text = $"Se está modificando: {this.model.Model}";
            }
            else
            {
                Nuevo(false);
            }
        }

        private void FTipoDocumento_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string descripcion = this.textBoxDescripcionTdoc.Text;

            if (descripcion.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionTdoc, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            TipoDocumento tdoc = new TipoDocumento()
            {
                descr_tdoc = descripcion,
            };

            ObjectValidation validation = new(tdoc);

            if (validation.IsValid())
            {
                TipoDocumentoModel model = new TipoDocumentoModel();
                model.Model = tdoc;
                if (this.model.Model != null)
                {
                    model.Model.cod_tdoc = this.model.Model.cod_tdoc;
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
        private void FTipoDocumento_Load(object sender, EventArgs e)
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

                this.model = new();
                this.model.CambioModelo += Model_CambioModelo;
                this.tipoDocumentoPuente.Modelo = this.model;

                this.tipoDocumentoPuente.SetTextBoxCodigo(this.textBoxCodigoTdoc);
                this.tipoDocumentoPuente.SetBotonBuscar(bBuscar1);
                this.tipoDocumentoPuente.SetTextBoxDescripcion(this.textBoxDescripcionTdoc);

                this.progressBar.Value = 0;

            }
            return valor;
        }

    }
}
