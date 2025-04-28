using MaterialSkin.Controls;
using Modelos;

namespace ProyectoIntegrador.Utilidades
{
    internal static class Autenticacion
    {
        public static Sesion? CurrentSession { get; private set; }

        public static bool IniciarSesion()
        {
            // Configuración por defecto del login ===================================
            Login login = new()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            // =======================================================================
            FormUtils.SetTextBoxChangeFocusOnEnter(login);
            login.ShowDialog();

            if (login.CurrentSession != null)
                CurrentSession = login.CurrentSession;
            else
                CurrentSession = null;
            return login.Logged;
        }

        public static bool VerificarSesion()
        {
            Login login = new(CurrentSession!.usuario_ses);
            login.ShowDialog();
            return login.Logged;
        }

        internal static void ClearSession()
        {
            CurrentSession = null;
        }
    }
}
