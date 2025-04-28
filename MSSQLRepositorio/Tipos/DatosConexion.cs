using Microsoft.Data.SqlClient;

namespace MSSQLRepositorio.Tipos
{
    public class DatosConexion
    {
        string servidor;
        string baseDatos;
        string usuario;
        string clave;
        bool windowsAuth;
        bool serverCertificate;

        public string Servidor { get => servidor; set => servidor = value; }
        public string BaseDatos { get => baseDatos; set => baseDatos = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public bool WindowsAuth { get => windowsAuth; set => windowsAuth = value; }
        public bool TrustServerCertificate { get => serverCertificate; set => serverCertificate = value; }

        public DatosConexion() { }

        internal string GetConnectionString()
        {
            return new SqlConnectionStringBuilder()
            {
                DataSource = this.Servidor,
                InitialCatalog = this.BaseDatos,
                UserID = this.Usuario,
                Password = this.Clave,
                TrustServerCertificate = this.TrustServerCertificate,
                IntegratedSecurity = this.WindowsAuth,
                ConnectTimeout = 30,

            }
            .ConnectionString;
        }
    }
}
