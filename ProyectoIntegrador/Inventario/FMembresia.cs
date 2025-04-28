using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoIntegrador.Inventario
{
    public partial class FMembresia : BaseForm
    {
        private MembresiaModel model = new MembresiaModel();
        private PuenteModeloUI<Membresia> membresiaPuente;
        public FMembresia()
        {
            InitializeComponent();
            base.guardarClick += FMembresia_guardarClick;
            this.membresiaPuente = new PuenteModeloUI<Membresia>(model)
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
                this.textBoxCodigoMemb.Text = model.Model.cod_mem.ToString();
                this.textBoxNombreMemb.Text = model.Model.nombre_mem;
                this.textBoxDescripcionMemb.Text = model.Model.descripcion_mem;
                this.fechaInicioMemb.Text = model.Model.fechainicio_mem.ToString();
                this.fechaFinalMemb.Text = model.Model.fechafin_mem.ToString();
                this.textBoxPrecioMemb.Text = model.Model.precio_mem.ToString(Formatos.formatoMoneda);
                this.activaCheckbox.Checked = model.Model.activo_mem;

                this.labelStatus.Text = $"Se está modificando: {this.model.Model}";
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        private void FMembresia_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;

            string nombre = this.textBoxNombreMemb.Text;
            string descripcion = this.textBoxDescripcionMemb.Text;
            string precio = this.textBoxPrecioMemb.Text;

            if (!double.TryParse(precio, out double precio_mem))
            {
                FormUtils.AddError(errorProvider, this.textBoxPrecioMemb, Mensajes.Msj_Invalido_FormatoNumero);
                return;
            }

            if (nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxNombreMemb, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            Membresia memb = new Membresia()
            {
                nombre_mem = nombre,
                descripcion_mem = descripcion,
                fechainicio_mem = fechaInicioMemb.Value,
                fechafin_mem = fechaFinalMemb.Value,
                precio_mem = (decimal)precio_mem,
                activo_mem = this.activaCheckbox.Checked,
            };

            ObjectValidation validation = new(memb);

            if (validation.IsValid())
            {
                MembresiaModel model = new MembresiaModel();
                model.Model = memb;
                if (this.model.Model != null)
                {
                    model.Model.cod_mem = this.model.Model.cod_mem;
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
        private void FMembresia_Load(object sender, EventArgs e)
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
                this.membresiaPuente.Modelo = this.model;

                this.membresiaPuente.SetBotonBuscar(bBuscar1);
                this.membresiaPuente.SetTextBoxDescripcion(this.textBoxNombreMemb);

                this.textBoxPrecioMemb.Text = "";
                this.progressBar.Value = 0;
            }
            return valor;
        }

        private void defFechaVencinimiento_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = this.defFechaVencinimiento.Checked;
        }

        private void activaCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
