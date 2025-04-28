using MaterialSkin.Controls;
using Modelos;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador.Configuracion
{
    public partial class Conexion : MaterialForm
    {
        public Conexion()
        {
            InitializeComponent();
        }

        private void ButtonProbar_Click(object sender, EventArgs e)
        {
            string servidor = textBoxServidor.Text,
                usuario = textBoxUsuario.Text,
                clave = textBoxClave.Text,
                basedatos = textBoxBaseDatos.Text;

            bool integrada = checkBoxIntegrada.Checked,
                certificado = checkBoxCertificate.Checked;

            Task.Run(() =>
            {
                Action<bool> btnStateAction = (bool value) => {
                    buttonGuardar.Enabled = value;
                    buttonProbar.Enabled = value;
                };
                Action<string, bool> alertAction = (string value, bool iserror) =>
                {
                    if(!iserror) 
                        AlertaController.AlertaInformacion(this, value);
                    else
                        AlertaController.AlertaError(this, value);
                };
                try
                {
                    if(this.InvokeRequired)
                        this.Invoke(btnStateAction, [false]);
                    else
                        btnStateAction(false);

                    var msg = new ConfiguracionModel().ProbarConexion(new Modelos.Tipos.DatosConexion()
                    {
                        Servidor = servidor,
                        Usuario = usuario,
                        Clave = clave,
                        BaseDatos = basedatos,
                        TrustServerCertificate = certificado,
                        WindowsAuth = integrada,
                    });

                    if (this.InvokeRequired)
                        this.Invoke(alertAction, [msg.Msg, msg.State]);
                    else
                        alertAction(msg.Msg, msg.State);
                }
                catch (Exception ex)
                {
                    if(this.InvokeRequired)
                        this.Invoke(alertAction, [ex.Message, true]);
                    else
                        alertAction(ex.Message, true);
                }
                finally
                {
                    if (this.InvokeRequired)
                        this.Invoke(btnStateAction, [true]);
                    else
                        btnStateAction(true);
                }
            });
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string servidor = textBoxServidor.Text,
            usuario = textBoxUsuario.Text,
            clave = textBoxClave.Text,
            basedatos = textBoxBaseDatos.Text;

            bool integrada = checkBoxIntegrada.Checked,
                certificado = checkBoxCertificate.Checked;
            Task.Run(() =>
            {
                var configuracion = new ConfiguracionModel();

                configuracion.Model.Conexion = new Modelos.Tipos.DatosConexion()
                {
                    Servidor = servidor,
                    Usuario = usuario,
                    Clave = clave,
                    BaseDatos = basedatos,
                    TrustServerCertificate = certificado,
                    WindowsAuth = integrada,
                };

                var msg = configuracion.Guardar();
                this.Invoke( () =>
                {
                    if(msg.State)
                    {
                        ToastController.MostrarInfo(this, "Configuración guardada");
                    } 
                    else
                    {
                        ToastController.MostrarError(this, msg.Msg);
                    }
                });
            });
        }

        private void textBoxBaseDatos_TrailingIconClick(object sender, EventArgs e)
        {
            this.textBoxBaseDatos.Clear();
        }

        private void textBoxServidor_TrailingIconClick(object sender, EventArgs e)
        {
            this.textBoxServidor.Clear();
        }

        private void checkBoxIntegrada_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxUsuario.Enabled = !checkBoxIntegrada.Checked;
        }

        private void Conexion_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var configuracion = new ConfiguracionModel();
                var conex = configuracion.Model.Conexion;

                this.Invoke(() =>
                {
                    this.textBoxServidor.Text = conex?.Servidor ?? "";
                    this.textBoxUsuario.Text = conex?.Usuario ?? "";
                    this.textBoxClave.Text = conex?.Clave ?? "";
                    this.textBoxBaseDatos.Text = conex?.BaseDatos ?? "";
                    this.checkBoxIntegrada.Checked = conex?.WindowsAuth ?? false;
                    this.checkBoxCertificate.Checked = conex?.TrustServerCertificate ?? true;
                });
            });
        }

        private void Conexion_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult = DialogResult.OK;
        }
    }
}
