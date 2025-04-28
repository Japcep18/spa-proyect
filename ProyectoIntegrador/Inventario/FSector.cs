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
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FSector : BaseForm
    {
        //Modelos
        private CiudadModel ciudadModel = new();
        private MunicipioConsultableModel municipioConsultableModel = new();
        private SectorConsultableModel sectorConsultableModel = new();
        //Puentes
        private PuenteModeloUI<Sector> sectorPuente;
        private PuenteModeloUI<Ciudad> ciudadPuente;
        private PuenteModeloUI<Municipio> municpioPuente;
        public FSector()
        {
            InitializeComponent();
            base.guardarClick += FSector_guardarClick;
            this.sectorPuente = new PuenteModeloUI<Sector>(sectorConsultableModel)
            {
                BloquearCodigoLuegoDeBuscar = false,
                Editar = true
            };
            this.ciudadPuente = new PuenteModeloUI<Ciudad>(ciudadModel)
            {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false,
            };
            this.municpioPuente = new PuenteModeloUI<Municipio>(municipioConsultableModel)
            {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false,
            };
            sectorConsultableModel.CambioModelo += Model_CambioModelo;
            this.municipioConsultableModel.CambioModelo += MunicipioConsultableModel_Model_CambioModelo;  
            this.ciudadModel.CambioModelo += CiudadModel_CambioModelo;
            this.sectorPuente.ProgresoCarga += SectorPuente_ProgresoCarga;
        }

        private void MunicipioConsultableModel_Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (this.municipioConsultableModel.Model != null)
            {
                this.textBoxDescripcionMuni.Text = this.municipioConsultableModel.Descripcion;
            }
            else
            {
                this.textBoxDescripcionMuni.Clear();
            }
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

        private void SectorPuente_ProgresoCarga(object? sender, ValorProgreso e)
        {
            this.labelStatus.Text = e.Labelstatus;

            int valor = (e.ValorActual / e.ValorMax) * 100;
            this.progressBar.Value = valor > this.progressBar.Maximum ? this.progressBar.Maximum : valor;
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (sectorConsultableModel.Model != null)
            {
                this.municipioConsultableModel.Codigo = sectorConsultableModel.Model.cod_muni.ToString();
                this.ciudadModel.Codigo = sectorConsultableModel.Model.cod_ciud.ToString();
                this.textBoxDescripcionSector.Text = sectorConsultableModel.Model.desc_sect;

                this.labelStatus.Text = $"Se está modificando: {this.sectorConsultableModel.Model}";
            }
            else
            {
                //Nuevo(false);
            }
        }
        private void FSector_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            Ciudad? ciudad = this.ciudadModel.Model;
            Municipio? municipio = this.municipioConsultableModel.Model;

            if (ciudad == null) 
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionCiudad, "Debe seleccionar la ciudad");
                return;
            }
            if(municipio == null)
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionMuni, "Debe seleccionar el municipio");
                return;
            }
            string descripcion = this.textBoxDescripcionSector.Text;
            if (descripcion.Trim().Length == 0) 
            {
                FormUtils.AddError(errorProvider, this.textBoxDescripcionSector, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            Sector sect = new Sector()
            {
                desc_sect = descripcion,
                cod_ciud = ciudad.cod_ciud,
                cod_muni = municipio.cod_muni,
            };

            ObjectValidation validation = new(sect);

            if (validation.IsValid())
            {
                SectorModel model = new SectorModel();
                model.Model = sect;
                if (this.sectorConsultableModel.Model != null)
                {
                    model.Model.cod_sect = this.sectorConsultableModel.Model.cod_sect;
                    model.Model.state = this.sectorConsultableModel.Model.state;
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
        private void FSector_Load(object sender, EventArgs e)
        {
            Nuevo(false);

            this.ciudadPuente.SetTextBoxCodigo(this.textBoxCodigoCiudad);
            this.ciudadPuente.SetBotonBuscar(this.bBuscar2);

            this.municpioPuente.SetTextBoxCodigo(this.textBoxCodigoMunicipio);
            this.municpioPuente.SetBotonBuscar(this.bBuscar3);

            this.sectorPuente.SetTextBoxCodigo(this.textBoxCodigoSector);
            this.sectorPuente.SetBotonBuscar(bBuscar1);
        }


        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.sectorConsultableModel.Codigo = null;
                this.ciudadModel.Codigo = null;
                this.municipioConsultableModel.Codigo = null;

                //this.model = new();
                //this.model.CambioModelo += Model_CambioModelo;
                //this.serviciosPuente.Modelo = this.model;

                //this.serviciosPuente.SetTextBoxCodigo(this.textBoxCodigo);
                //this.serviciosPuente.SetBotonBuscar(bBuscar1);
                //this.serviciosPuente.SetTextBoxDescripcion(this.textBoxNombre);

                this.progressBar.Value = 0;

            }
            return valor;
        }
    }
}
