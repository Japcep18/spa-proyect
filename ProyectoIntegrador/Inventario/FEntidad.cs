using Microsoft.IdentityModel.Abstractions;
using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FEntidad : BaseForm
    {
        //Modelos
        private GeneroModel GeneroModel = new();
        private CiudadModel ciudadModel = new();
        private MunicipioConsultableModel municipioConsultableModel = new();
        private SectorConsultableModel sectorConsultableModel = new();
        private EntidadConsultableModel model = new EntidadConsultableModel();

        //Puentes
        private PuenteModeloUI<Sector> sectorPuente;
        private PuenteModeloUI<Ciudad> ciudadPuente;
        private PuenteModeloUI<Municipio> municipioPuente;
        private PuenteModeloUI<Entidad> entidadPuente;

        public FEntidad()
        {
            InitializeComponent();
            base.guardarClick += FEntidad_guardarClick;
            this.entidadPuente = new PuenteModeloUI<Entidad>(model)
            {
                Editar = true,
            };

            this.ciudadPuente = new PuenteModeloUI<Ciudad>(ciudadModel)
            {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false
            };

            this.municipioPuente = new PuenteModeloUI<Municipio>(municipioConsultableModel)
            {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false,
            };
            this.sectorPuente = new PuenteModeloUI<Sector>(sectorConsultableModel)
            {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false,
            };
            //this.entidadConul
            this.entidadPuente.ProgresoCarga += entidadPuente_ProgresoCarga;
            this.ciudadModel.CambioModelo += CiudadModel_CambioModelo;
            this.municipioConsultableModel.CambioModelo += MunicipioConsultableModel_CambioModelo;
            this.sectorConsultableModel.CambioModelo += SectorConsultableModel_CambioModelo;
            this.model.CambioModelo += Model_CambioModelo;
        }

        private void CiudadModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (this.ciudadModel.Model != null)
            {
                this.textBoxCiudadDesc.Text = this.ciudadModel.Descripcion;
                this.municipioConsultableModel.CiudadFiltro = this.ciudadModel.Model;
                this.groupBoxCiudad.Enabled = true;
                this.groupBoxMunicipio.Enabled = true;
            }
            else
            {
                this.textBoxCiudadDesc.Clear();
            }
        }

        private void MunicipioConsultableModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (this.municipioConsultableModel.Model != null)
            {
                this.textBoxMunicipioDesc.Text = this.municipioConsultableModel.Descripcion;
                this.sectorConsultableModel.MunicipioFiltro = this.municipioConsultableModel.Model;
                this.groupBoxMunicipio.Enabled = true;
                this.groupBoxSector.Enabled = true;
            }
            else
            {
                this.textBoxMunicipioDesc.Clear();
            }
        }
        private void SectorConsultableModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (this.sectorConsultableModel.Model != null)
            {
                this.textBoxSectorDesc.Text = this.sectorConsultableModel.Descripcion;
                this.groupBoxSector.Enabled = true;
            }
            else
            {
                this.groupBoxSector.Enabled = false;
                this.textBoxSectorDesc.Clear();
            }
        }


        private void entidadPuente_ProgresoCarga(object? sender, ValorProgreso e)
        {
            this.labelStatus.Text = e.Labelstatus;

            int valor = (e.ValorActual / e.ValorMax) * 100;
            this.progressBar.Value = valor > this.progressBar.Maximum ? this.progressBar.Maximum : valor;
        }

        private void Model_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if (model.Model != null)
            {
                this.textBoxCodigoEnt.Text = model.Model.codent_ent.ToString();
                this.textBoxNombreEnt.Text = model.Model.nombre_ent;
                this.textBoxCedulaEnt.Text = model.Model.cedula_ent;
                this.CheckboxEspersona.Checked = model.Model.espersona_ent;
                this.fechaNacEnt.Value = model.Model.fecnac_ent ?? DateTime.Now;
                Genero? genero = this.GeneroModel.Obtener($"{model.Model.codgen_ent}");
                if (genero is not null)
                    FormUtils.SelectItemInComboBox(
                        this.CBGenero, genero!,
                        (gen) => gen.cod_gen == model.Model.codgen_ent);
                
                this.ciudadModel.Codigo = model.Model.codciud_dir.ToString();
                this.municipioConsultableModel.Codigo = model.Model.codmuni_dir.ToString();
                this.sectorConsultableModel.Codigo = model.Model.codsect_dir.ToString();
                this.textBoxDireccion.Text = model.Model.direccion_dir;
                this.CheckboxActivo.Checked = model.Model.activo_ent;
            }
            // Si no hay nada, limpiame esto
            else
            {
                Nuevo(false);
            }
        }

        private void FEntidad_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;
            string nombre = this.textBoxNombreEnt.Text;
            string cedula = this.textBoxCedulaEnt.Text;
            Genero? selectedGenero = null;
            Ciudad? ciudad = this.ciudadModel.Model;
            Municipio? municipio = this.municipioConsultableModel.Model;
            Sector? sector = this.sectorConsultableModel.Model;

            if (nombre.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxNombreEnt, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            object? selectedItemGenerno = this.CBGenero.SelectedItem;
            if(this.CheckboxEspersona.Checked)
            {
                if (selectedItemGenerno != null)
                {
                    if (selectedItemGenerno is Genero)
                        selectedGenero = (Genero)selectedItemGenerno;
                    else
                    {
                        FormUtils.AddError(errorProvider, this.CBGenero, "Debe seleccionar el genero");
                        return;
                    }
                }
                else
                {
                    FormUtils.AddError(errorProvider, this.CBGenero, "Debe seleccionar el genero");
                    return;
                }
            }

            if (ciudad == null)
            {
                FormUtils.AddError(errorProvider, this.textBoxCiudadDesc, "Debe seleccionar la ciudad");
                return;
            }

            if (municipio == null)
            {
                FormUtils.AddError(errorProvider, this.textBoxMunicipioDesc, "Debe seleccionar el municipio");
                return;
            }

            if (sector == null)
            {
                FormUtils.AddError(errorProvider, this.textBoxSectorDesc, "Debe seleccionar el sector");
                return;
            }

            string direccion = this.textBoxDireccion.Text;
            if (direccion.Trim().Length == 0)
            {
                FormUtils.AddError(errorProvider, this.textBoxDireccion, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            bool espersona = this.CheckboxEspersona.Checked, 
                 activo = this.CheckboxActivo.Checked;

            Entidad ent = new()
            {
                nombre_ent = nombre,
                cedula_ent = cedula,
                fecnac_ent = espersona ? fechaNacEnt.Value : null,
                codgen_ent = espersona ? selectedGenero?.cod_gen : null,
                codciud_dir = ciudad.cod_ciud,
                codmuni_dir = municipio.cod_muni,
                codsect_dir = sector.cod_sect,
                direccion_dir = direccion,
                espersona_ent = espersona,
                activo_ent = activo,
            };

            ObjectValidation validation = new(ent);

            if (validation.IsValid())
            {
                EntidadModel model = new EntidadModel();
                model.Model = ent;
                if (this.model.Model != null)
                {
                    model.Model.codent_ent = this.model.Model.codent_ent;
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
        private void FEntidad_Load(object sender, EventArgs e)
        {
            this.entidadPuente.SetTextBoxCodigo(this.textBoxCodigoEnt);
            this.entidadPuente.SetBotonBuscar(bBuscar1);
            this.entidadPuente.SetTextBoxDescripcion(this.textBoxNombreEnt);

            this.ciudadPuente.SetTextBoxCodigo(this.textBoxCodigoCiudad);
            this.ciudadPuente.SetBotonBuscar(this.bBuscar2);
            this.ciudadPuente.SetTextBoxDescripcion(this.textBoxCiudadDesc);

            this.municipioPuente.SetTextBoxCodigo(this.textBoxCodigoMunicipio);
            this.municipioPuente.SetBotonBuscar(this.bBuscar3);
            this.municipioPuente.SetTextBoxDescripcion(this.textBoxMunicipioDesc);

            this.sectorPuente.SetTextBoxCodigo(this.textBoxCodigoSector);
            this.sectorPuente.SetBotonBuscar(this.bBuscar4);
            this.sectorPuente.SetTextBoxDescripcion(this.textBoxSectorDesc);

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
                this.ciudadModel.Codigo = null;
                this.municipioConsultableModel.Codigo = null;
                this.sectorConsultableModel.Codigo = null;
                this.textBoxCodigoEnt.Enabled = true;

                this.CheckboxActivo.Checked = true;

                this.progressBar.Value = 0;

                this.CargarDatos();
            }
            return valor;
        }

        private async Task CargarDatos()
        {
            // Invoke -> Preparar la UI para ser manipulada desde otro hilo
            if (this.InvokeRequired)
            {
                await this.Invoke(async () => await this.CargarDatos());
                return;
            }

            this.progressBar.Value = 0;
            const int incr_progress = 100 / 2;
            string last_status = this.labelStatus.Text ?? "";

            //Genero
            this.GeneroModel = new();
            Action updateProgressBar = () =>
            {
                int progressBarNextValue = this.progressBar.Value + incr_progress;
                this.progressBar.Value = progressBarNextValue > this.progressBar.Maximum ? this.progressBar.Maximum : progressBarNextValue;
            };

            var GeneroTask = Task.Run(() =>
            {
                EntityMessage<IEnumerable<Genero>> dataList = this.GeneroModel.CargarDatos();
                if (this.progressBar.Value + incr_progress < this.progressBar.Maximum)
                {
                    if (this.progressBar.InvokeRequired)
                        this.progressBar.Invoke(updateProgressBar);
                    else
                        updateProgressBar();
                }
                this.labelStatus.Text = "Genero cargado";
                return dataList;
            });


            await Task.WhenAll([GeneroTask]);
            this.progressBar.Value = 100;

            if (GeneroTask.Result.State)
            {
                this.CBGenero.Items.Clear();
                // .. -> spread operator
                this.CBGenero.Items.AddRange([.. (GeneroTask.Result.Entity ?? [])]);
                if (CBGenero.Items.Count > 0)
                    this.CBGenero.SelectedIndex = 0;
            }
            else
            {
                AlertaController.AlertaError(this, GeneroTask.Result.Msg);
            }
            this.labelStatus.Text = last_status;
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialCheckboxNacimiento_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckboxEspersona.Checked == true)
            {
                this.fechaNacEnt.Enabled = true;
                this.CBGenero.Enabled = true;
            }
            else
            {
                this.fechaNacEnt.Enabled = false;
                this.CBGenero.Enabled = false;
                this.CBGenero = null;
            }
        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void textBoxCedulaEnt_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckboxEspersona_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = this.CheckboxEspersona.Checked;
            if (!this.CheckboxEspersona.Checked) { 
                this.fechaNacEnt.Value = DateTime.Today;
                this.CBGenero.SelectedIndex = -1; 
            }
        }
    }
}
