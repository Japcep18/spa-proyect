using Microsoft.Data.SqlClient;
using Modelos.Tipos;
using MSSQLRepositorio;
using System.Data;

namespace Modelos.Servicios
{
    /// <summary>
    /// Se encarga de manejar las secuencias de las tablas
    /// </summary>
    public static class SecuenciaManager
    {
        /// <summary>
        /// Busca el siguiente código, no lo actualiza.
        /// </summary>
        /// <param name="tablename">Nombre de la tabla</param>
        /// <param name="conn">Conexion SQL</param>
        /// <returns>Devuelve el siguiente código, -1 si hubo un error</returns>
        public static EntityMessage<object> ObtenerSiguiente(string tablename)
        {
            var config = new ConfiguracionModel();
            var msg = new ConexionSQL(config.Model!.Conexion).ExecuteInstructions(
                (SqlConnection conn, SqlTransaction tran) =>
                {
                    var sec = ObtenerSiguiente(tablename, conn, tran, false);
                    return new(sec != -1, "", sec);
                });
            return new(msg.State, msg.Msg, ((int?) msg.Entity) ?? 0);
        }
        /// <summary>
        /// Busca el siguiente código, no lo actualiza.
        /// </summary>
        /// <param name="tablename">Nombre de la tabla</param>
        /// <param name="conn">Conexion SQL</param>
        /// <returns>Devuelve el siguiente código, -1 si hubo un error</returns>
        public static int ObtenerSiguiente(string tablename, SqlConnection conn)
        {
            return ObtenerSecuencia(tablename, conn);
        }
        /// <summary>
        /// Busca el siguiente código.
        /// </summary>
        /// <param name="tablename">Nombre de la tabla</param>
        /// <param name="conn">Conexion SQL, debe estar abierta</param>
        /// <param name="tran">Transaccion SQL</param>
        /// <param name="guardar">Define si se actualiza el codigo</param>
        /// <returns>Devuelve el siguiente código, -1 si hubo un error</returns>
        public static int ObtenerSiguiente(string tablename, SqlConnection conn, SqlTransaction tran, bool guardar)
        {
            return ObtenerSecuencia(tablename, conn, tran, guardar);
        }

        private static int ObtenerSecuencia(string tablename, SqlConnection conn, SqlTransaction? tran = null, bool guardar = false)
        {
            const string COLALIAS = "siguiente";
            string query =
                $"DECLARE @cod INT; " +
                $"EXEC SP_GETNEXTCOD @tabla = '{tablename}', @guardar = @valor, @codigo = @cod OUTPUT; " +
                $"SELECT @cod AS {COLALIAS};";
            SqlParameter[] parameters = [
                    new ("valor", guardar)
                ];
            try
            {
                DataTable dataTable = ConexionSQL.ExecuteReader(query, conn, parameters, tran);
                return Convert.ToInt32(dataTable.Rows[0][COLALIAS]);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
