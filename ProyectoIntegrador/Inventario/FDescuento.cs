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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoIntegrador.Inventario
{
    public partial class FDescuento : BaseForm
    {
        private DescuentoModel model = new DescuentoModel();
        private PuenteModeloUI<Descuento> descuentoPuente;
        public FDescuento()
        {
            InitializeComponent();
            base.guardarClick += FServicios_guardarClick;
            this.descuentoPuente = new PuenteModeloUI<Descuento>(model)
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
                this.textBoxCodigoDesc.Text = model.Model.cod_desc.ToString();
                this.textBoxDescripcionDesc.Text = model.Model.descripcion_desc;
                this.textBoxPorcentajeDesc.Text = model.Model.porcentaje_desc.ToString();
                this.fechaIncioDesc.Text = model.Model.fechainicio_desc.ToString();
                this.fechaFinalDesc.Text = model.Model.fechafin_desc.ToString();
                this.itbisCheckBox.Checked = model.Model.afectaitbis_desc;
                this.activoCheckbox.Checked = model.Model.activo_des;

                this.labelStatus.Text = $"Se está modificando: {this.model.Model}";
            }
            else
            {
                Nuevo(false);
            }
        }

        private void FServicios_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string descripcion = this.textBoxDescripcionDesc.Text;
            string porcentaje = this.textBoxPorcentajeDesc.Text;

            if (descripcion.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionDesc, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (!double.TryParse(porcentaje, out double porcentaje_desc))
            {
                FormUtils.AddError(errorProvider, this.textBoxPorcentajeDesc, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            Descuento des = new Descuento()
            {
                descripcion_desc = descripcion,
                porcentaje_desc = (decimal)porcentaje_desc,
                fechainicio_desc = fechaIncioDesc.Value,
                fechafin_desc = fechaFinalDesc.Value,
                afectaitbis_desc = itbisCheckBox.Checked,
                activo_des = this.activoCheckbox.Checked,
            };

            ObjectValidation validation = new(des);

            if (validation.IsValid())
            {
                DescuentoModel model = new DescuentoModel();
                model.Model = des;
                if (this.model.Model != null)
                {
                    model.Model.cod_desc = this.model.Model.cod_desc;
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

        private void FDescuento_Load(object sender, EventArgs e)
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
                this.descuentoPuente.Modelo = this.model;

                this.descuentoPuente.SetTextBoxCodigo(this.textBoxCodigoDesc);
                this.descuentoPuente.SetBotonBuscar(bBuscar1);
                this.descuentoPuente.SetTextBoxDescripcion(this.textBoxDescripcionDesc);

                this.progressBar.Value = 0;

            }
            return valor;
        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void fechaFinalDesc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxDefinirFechaFin_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = this.checkBoxDefinirFechaFin.Checked;
        }
    }
}
