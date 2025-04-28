using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoIntegrador.Inventario
{
    public partial class FMunicipio : BaseForm
    {
        private CiudadModel ciudadModel = new();
        private PuenteModeloUI<Ciudad> ciudadPuente;
        private MunicipioConsultableModel municipioConsultableModel = new();
        private PuenteModeloUI<Municipio> municipioPuente;
        public FMunicipio()
        {
            InitializeComponent();
            base.guardarClick += FMunicipio_guardarClick;
            this.municipioPuente = new PuenteModeloUI<Municipio>(municipioConsultableModel)
            {
                Editar = true,
            };

            this.ciudadPuente = new PuenteModeloUI<Ciudad>(ciudadModel){
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false,
            };

            this.municipioConsultableModel.CambioModelo += Model_CambioModelo;
            this.municipioPuente.ProgresoCarga += MunicipioPuente_ProgresoCarga;
            this.ciudadModel.CambioModelo += CiudadModel_CambioModelo;
        }

        private void CiudadModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (this.ciudadModel.Model != null)
            {
                this.textBoxDescripcionCiudad.Text = this.ciudadModel.Descripcion;
            }
            else
            {
                this.textBoxDescripcionCiudad.Clear();
            }
        }

        private void MunicipioPuente_ProgresoCarga(object? sender, ValorProgreso e)
        {
            this.labelStatus.Text = e.Labelstatus;

            int valor = (e.ValorActual / e.ValorMax) * 100;
            this.progressBar.Value = valor > this.progressBar.Maximum ? this.progressBar.Maximum : valor;
        }
        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (municipioConsultableModel.Model != null)
            {
               this.ciudadModel.Codigo = municipioConsultableModel.Model.cod_ciud.ToString();
                this.textBoxDescripcionMuni.Text = municipioConsultableModel.Model.desc_muni;
               this.labelStatus.Text = $"Se está modificando: {this.municipioConsultableModel.Model}";
            }
            // Si no hay nada, limpiame esto
            else
            {
               // Nuevo(false);
            }
        }

        private void FMunicipio_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            Ciudad? ciudad = this.ciudadModel.Model;
            string abreviatura = this.textBoxAbreviaturaMuni.Text;
            string descripcion = this.textBoxDescripcionMuni.Text;

            if (ciudad == null) 
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionCiudad, "Debe seleccionar la ciudad");
                return;
            }
            if (abreviatura.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxAbreviaturaMuni, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }
            if (descripcion.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionMuni, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            Municipio muni = new Municipio()
            {
                cod_ciud = ciudad.cod_ciud,
                Abr_muni = abreviatura,
                desc_muni = descripcion,
            };

            ObjectValidation validation = new(muni);

            if (validation.IsValid())
            {
                MunicipioModel model = new MunicipioModel();
                model.Model = muni;
                if (this.municipioConsultableModel.Model != null)
                {
                    model.Model.cod_muni = this.municipioConsultableModel.Model.cod_muni;
                    model.Model.state = this.municipioConsultableModel.Model.state;
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

        private void FMunicipio_Load(object sender, EventArgs e)
        {
            Nuevo(false);
            this.municipioPuente.SetTextBoxCodigo(this.textBoxCodigoMuni);
            this.municipioPuente.SetBotonBuscar(bBuscar1);
            this.municipioPuente.SetTextBoxDescripcion(this.textBoxAbreviaturaMuni);
           

            this.ciudadPuente.SetTextBoxCodigo(this.textBoxCodigoCiudad);
            this.ciudadPuente.SetBotonBuscar(this.bBuscar2);

            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);
                this.ciudadModel.Codigo = null;

                this.progressBar.Value = 0;
            }
            return valor;
        }


        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
