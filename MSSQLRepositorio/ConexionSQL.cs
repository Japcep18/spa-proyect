using Microsoft.Data.SqlClient;
using MSSQLRepositorio.Tipos;
using System.Data;

namespace MSSQLRepositorio
{
    public class ConexionSQL : RepositorioBase
    {
        public static SessionInfo? SessionInfo { get; set; }
        protected List<SqlParameter> Parameters = new();

        public ConexionSQL(DatosConexion options) : base(options) { }

        public Message<DatosConexion> ProbarConexion(DatosConexion datos)
        {
            try
            {
                using var sqlConn = new SqlConnection(datos.GetConnectionString());
                sqlConn.Open();
                sqlConn.Close();
                sqlConn.Dispose();
                return new(true, "Conexión exitosa", datos);
            }
            catch (InvalidOperationException ex)
            {
                return new(false, $"Operacion Invalida: {ex.Message}", datos);
            }
            catch (SqlException ex)
            {
                return new(false, $"Error: {ex.Message}", datos);
            }
            catch (Exception ex)
            {
                return new(false, $"Error: {ex.Message}", datos);
            }
        }

        public Message<object> ExecuteInstructions(Func<SqlConnection, SqlTransaction, Message<object>> function)
        {
            try
            {
                using SqlConnection conn = base.GetConnection();

                if (conn.State != ConnectionState.Open)
                    conn.Open();
                
                using SqlTransaction transaction = conn.BeginTransaction();
                if(SessionInfo != null)
                {
                    string query = "EXEC sp_set_session_context @key = 'codusr_actual', @value = @value_codusr; " +
                        "EXEC sp_set_session_context @key = 'usuario_actual', @value = @value_usr; " +
                        "EXEC sp_set_session_context @key = 'programa_actual', @value = @programa;";
                    SqlParameter[] parameters = 
                    [
                        new("value_codusr", SessionInfo.codusr_actual),
                        new("value_usr", SessionInfo.usuario_actual ?? "SIN LOGGEAR"),
                        new("programa", SessionInfo.programa_actual ?? "SISTEMA"),
                    ];

                    ExecuteNonQuery(query, conn, parameters, transaction);
                }
                var msg = function.Invoke(conn, transaction);
                conn.Close();
                return msg;
            }
            catch (Exception ex)
            {
                return new Message<object>(false, $"Error: {ex.Message}", ex);
            }
        }

        public Message<DataTable> ObtenerDatos(string tsql, SqlParameter[]? parameters = null)
        {
            try
            {
                using SqlConnection conn = base.GetConnection();
                return this.ObtenerDatos(tsql, conn, parameters);
            }
            catch (Exception ex)
            {
                return new(false, $"Error: {ex.Message}", new DataTable());
            }
        }

        public Message<DataTable> ObtenerDatos(string tsql, SqlConnection conn, SqlParameter[]? parameters = null)
        {
            try
            {
                return new Message<DataTable>(true, "Consulta realizada", ExecuteReader(tsql, conn, parameters));
            }
            catch (SqlException ex)
            {
                return new Message<DataTable>(false, $"Error: {ex.Message}", new DataTable());
            }
        }

        public Message<DataTable> ObtenerDatos(string tsql, SqlConnection conn, SqlParameter[]? parameters = null, SqlTransaction? tran = null)
        {
            try
            {
                return new Message<DataTable>(true, "Consulta realizada", ExecuteReader(tsql, conn, parameters, tran));
            }
            catch (SqlException ex)
            {
                return new Message<DataTable>(false, $"Error: {ex.Message}", new DataTable());
            }
        }

        protected int ExecuteNonQuery(string TransactSql, SqlParameter[]? parameters = null)
        {
            using SqlConnection conn = base.GetConnection();
            return ExecuteNonQuery(TransactSql, conn, parameters);
        }

        public static int ExecuteNonQuery(string TransactSql, SqlConnection conn, SqlParameter[]? parameters = null, SqlTransaction? tran = null)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            using SqlCommand command = new(TransactSql, conn);
            if (tran != null)
            {
                command.Transaction = tran;
            }
            command.CommandType = System.Data.CommandType.Text;
            if (parameters != null)
            {
                foreach (SqlParameter item in parameters)
                {
                    command.Parameters.Add(item);
                }
            }
            int result = command.ExecuteNonQuery();
            return result;
        }

        protected DataTable ExecuteReader(string TransactSql, SqlParameter[]? parameters = null)
        {
            using SqlConnection conn = base.GetConnection();
            return ExecuteReader(TransactSql, conn, parameters);
        }

        public static DataTable ExecuteReader(string TransactSql, SqlConnection conn, SqlParameter[]? parameters = null, SqlTransaction? tran = null)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            using SqlCommand command = new(TransactSql, conn);
            if (tran != null)
            {
                command.Transaction = tran;
            }
            command.CommandType = CommandType.Text;
            command.CommandText = TransactSql;
            if (parameters != null)
            {
                foreach (SqlParameter item in parameters)
                {
                    command.Parameters.Add(item);
                }
            }
            using SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new();
            dataTable.Load(reader);
            return dataTable;
        }
    }
}
