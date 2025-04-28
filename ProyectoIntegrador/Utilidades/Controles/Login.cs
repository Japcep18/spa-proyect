using MaterialSkin;
using MaterialSkin.Controls;
using Modelos;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador
{
    public partial class Login : MaterialForm
    {
        private readonly MaterialSkinManager skinManager;

        private SesionModel sesionModel = new();
        public Sesion? CurrentSession { get; private set; }
        public bool Logged { private set; get; }

        private bool showPassword = true;

        public Login()
        {
            InitializeComponent();

            // INICIALIZAR MATERIAL SKIN MANAGER - TEMAS DE BUG CON PASSWORD TRUE EN TEXTBOX
            skinManager = MaterialSkinManager.Instance;
            skinManager.EnforceBackcolorOnAllComponents = false;
            skinManager.AddFormToManage(this);
        }

        public Login(string username) : this()
        {
            this.textBoxUsuario.Text = username;
            this.textBoxUsuario.Enabled = false;

            this.textBoxClave.GotFocus += TextBoxClave_GotFocus;
        }

        private void TextBoxClave_GotFocus(object? sender, EventArgs e)
        {
            this.textBoxClave.SelectAll();
        }

        private void BLogin_Click_1(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();

            string username = this.textBoxUsuario.Text;
            string password = this.textBoxClave.Text;

            if (username.Trim().Length == 0)
            {
                FormUtils.AddError(this.errorProvider1, textBoxUsuario, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }

            if (password.Trim().Length == 0)
            {
                FormUtils.AddError(this.errorProvider1, textBoxClave, Mensajes.Msj_Invalido_CampoVacio);
                return;
            }
            this.EnableControls(false);
            Task.Run(() =>
            {
                var response = this.sesionModel.IniciarSesion(username, password);
                if (!response.State)
                {
                    this.Invoke(() =>
                    {
                        this.EnableControls(true);
                        AlertaController.AlertaError(this, response.Msg);
                    });
                    return;
                }

                this.Invoke(() =>
                {
                    ToastController.MostrarInfo(this, response.Msg, 2000);
                    this.EnableControls(true);
                });
                if (response.Entity == ResultadoAutenticacion.Autenticado)
                {
                    this.Invoke(() =>
                    {
                        this.CurrentSession = SesionModel.CurrentSession;
                        this.Logged = true;
                        if (this.Modal)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        this.Close();
                    });
                }
            });
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (this.Modal)
                this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SesionModel.CurrentProgram = "Login";
        }

        private void EnableControls(bool enable)
        {
            this.textBoxUsuario.Enabled = enable;
            this.textBoxClave.Enabled = enable;
            this.buttonCancelar.Enabled = enable;
            this.buttonLogin.Enabled = enable;
        }

        private void textBoxClave_TrailingIconClick_1(object sender, EventArgs e)
        {
            this.showPassword = !this.showPassword;
            this.textBoxClave.UseSystemPasswordChar = this.showPassword;
            this.textBoxClave.Refresh();
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            this.textBoxClave.Clear();
            this.textBoxClave.UseSystemPasswordChar = true;
            this.textBoxClave.Refresh();
        }
    }
}
