using Microsoft.Data.SqlClient;
using MSSQLRepositorio.Tipos;

namespace MSSQLRepositorio
{
    public class RepositorioBase
    {
        readonly string connectionString;
        public RepositorioBase(DatosConexion options)
        {
            this.connectionString = options.GetConnectionString();
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
