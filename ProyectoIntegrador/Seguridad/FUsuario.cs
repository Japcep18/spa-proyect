using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Seguridad
{
    public partial class FUsuario : BaseForm
    {
        // Modelos ====================================
        private UsuarioConsultableModel usuarioConsultableModel = new();
        private EmpleadoConsultableModel empleadoConsultableModel = new();
        private PerfilModel perfilModel = new();
        // -- Entidad -- Para obtener los datos del empleado
        private EntidadModel entidadModel = new();
        // Puentes ====================================
        private PuenteModeloUI<Usuario> usuarioPuente;
        private PuenteModeloUI<Empleado> empleadoPuente;
        private PuenteModeloUI<Perfil> perfilPuente;
        // ============================================

        public FUsuario()
        {
            InitializeComponent();
            base.guardarClick += FUsuario_guardarClick;

            this.usuarioPuente = new PuenteModeloUI<Usuario>(usuarioConsultableModel)
            {
                BloquearCodigoLuegoDeBuscar = false,
                Editar = true
            };

            this.empleadoPuente = new PuenteModeloUI<Empleado>(empleadoConsultableModel) {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false
            };

            this.perfilPuente = new PuenteModeloUI<Perfil>(perfilModel) {
                Editar = false,
                BloquearCodigoLuegoDeBuscar = false,
            };

            this.usuarioConsultableModel.CambioModelo += UsuarioModel_CambioModelo;
            this.empleadoConsultableModel.CambioModelo += EmpleadoConsultableModel_CambioModelo;
            this.perfilModel.CambioModelo += PerfilModel_CambioModelo;
        }

        private void PerfilModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if(this.perfilModel.Model != null)
            {
                this.textBoxPerfilDesc.Text = this.perfilModel.Descripcion;
            } 
            else
            {
                this.textBoxPerfilDesc.Clear();
            }
        }

        private void EmpleadoConsultableModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if(this.empleadoConsultableModel.Model != null)
            {
                string? nombre_ent = this.entidadModel.Obtener(
                                        this.empleadoConsultableModel.Model.codent_emp.ToString()
                                    )?.nombre_ent;
                this.textBoxEmpleadoDesc.Text =
                    nombre_ent ?? "No Asignado";
            } 
            else
            {
                this.textBoxEmpleadoDesc.Clear();
            }
        }

        private void UsuarioModel_CambioModelo(object? sender, string? e)
        {
            this.errorProvider.Clear();
            if(usuarioConsultableModel.Model != null)
            {
                this.empleadoConsultableModel.Codigo = usuarioConsultableModel.Model.codemp_usr.ToString();
                this.perfilModel.Codigo = usuarioConsultableModel.Model.codperf_usr.ToString();

                this.textBoxUsuario.Text = usuarioConsultableModel.Model.username;
                this.textBoxClave.Text = usuarioConsultableModel.Model.clave;

                this.checkBoxActivo.Checked = usuarioConsultableModel.Model.activo_usr;
                this.labelStatus.Text = $"Se está modificando: {this.usuarioConsultableModel.Model}";
            }
            else
            {
                //Nuevo(false);
            }
        }

        private void FUsuario_guardarClick(object? sender, EventArgs e)
        {
            this.errorProvider.Clear();
            this.progressBar.Value = 0;

            Perfil? perfil = this.perfilModel.Model;
            Empleado? empleado = this.empleadoConsultableModel.Model;

            if(perfil == null)
            {
                FormUtils.AddError(errorProvider, this.textBoxPerfilDesc, "Debe seleccionar el perfil");
                return;
            }
             
            if (empleado == null)
            {
                FormUtils.AddError(errorProvider, this.textBoxEmpleadoDesc, "Debe seleccionar el empleado");
                return;
            }

            string usuario = this.textBoxUsuario.Text;
            if(usuario.Trim().Length == 0) 
            {
                FormUtils.AddError(errorProvider, this.textBoxEmpleadoDesc, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            string clave = this.textBoxClave.Text;
            if(clave.Trim().Length == 0) 
            {
                FormUtils.AddError(errorProvider, this.textBoxEmpleadoDesc, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            bool activo = this.checkBoxActivo.Checked;

            Usuario usr = new Usuario() 
            {
                codperf_usr = perfil.cod_perf,
                codemp_usr = empleado.codent_emp,
                username = usuario,
                clave = clave,
                activo_usr = activo,
            };

            ObjectValidation validation = new(usr);

            if (validation.IsValid())
            {
                UsuarioModel model = new UsuarioModel();
                model.Model = usr;
                if (this.usuarioConsultableModel.Model != null)
                {
                    model.Model.cod_usr = this.usuarioConsultableModel.Model.cod_usr;
                    model.Model.state = this.usuarioConsultableModel.Model.state;
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

        private void FUsuario_Load(object sender, EventArgs e)
        {
            // Asignacion de controles: Usuario
            this.usuarioPuente.SetTextBoxCodigo(this.textBoxCodigoUsuario);
            this.usuarioPuente.SetBotonBuscar(this.bBuscarUsuario);

            // Asignacion de controles: Empleado
            this.empleadoPuente.SetTextBoxCodigo(this.textBoxEmpleadoCodigo);
            this.empleadoPuente.SetBotonBuscar(this.bBuscarEmpleado);
            //this.empleadoPuente.SetTextBoxDescripcion(this.textBoxEmpleadoDesc);

            // Asignacion de controles: Perfil
            this.perfilPuente.SetTextBoxCodigo(this.textBoxPerfilCodigo);
            this.perfilPuente.SetBotonBuscar(this.bBuscarPerfil);
            //this.perfilPuente.SetTextBoxDescripcion(this.textBoxPerfilDesc);

            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.usuarioConsultableModel.Codigo = null;
                this.empleadoConsultableModel.Codigo = null;
                this.perfilModel.Codigo = null;

                this.progressBar.Value = 0;
                this.checkBoxActivo.Checked = true;
            }
            return valor;
        }
    }
}
