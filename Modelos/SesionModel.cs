using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public enum ResultadoAutenticacion
    {
        UsuarioIncorrecto,
        SesionActiva,
        Autenticado
    }

    public class Sesion : DBObject
    {
        public long codses_ses { get; set; }
        public int codusr_ses { get; set; }
        public DateTime ultsesion_ses { get; set; }
        public DateTime fecha_sesion { get; set; }
        public string equipo_ses { get; set; }
        public string usuario_ses { get; set; }
        public bool mantener_ses { get; set; }
        public bool cerrado_ses { get; set; }
    }

    public class SesionModel
    {
        private readonly string pcname;
        private readonly ConexionSQL conexion;
        public static Sesion CurrentSession { get; private set; }
        private static string? currentProgram;
        public static string? CurrentProgram { private get => currentProgram; 
            set
            {
                currentProgram = value;
                if(value != null)
                {
                    if(ConexionSQL.SessionInfo != null)
                    {
                        ConexionSQL.SessionInfo.programa_actual = value;
                    } 
                    else
                    {
                        ConexionSQL.SessionInfo = new()
                        {
                            programa_actual = value,
                        };
                    }
                }
            } 
        }

        private static readonly string TableUsuario = "Usuario";
        private static readonly string TableSesion = "Sesion";

        public SesionModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
            this.pcname = System.Environment.MachineName;
        }

        public EntityMessage<ResultadoAutenticacion> IniciarSesion(string username, string clave)
        {
            string query = $"SELECT * FROM {TableUsuario} WHERE username = @username AND clave = @clave";
            SqlParameter[] parameters = [
                new("username", username),
                new("clave", clave),
            ];

            var msg = this.conexion.ObtenerDatos(query, parameters);
            if(!msg.State)
            {
                return new(msg.State, msg.Msg, ResultadoAutenticacion.UsuarioIncorrecto);
            }

            if(msg.Entity == null)
            {
                return new(msg.State, "Usuario incorrecto", ResultadoAutenticacion.UsuarioIncorrecto);
            }

            if(msg.Entity.Rows.Count == 0) 
            {
                return new(msg.State, "Usuario incorrecto", ResultadoAutenticacion.UsuarioIncorrecto);
            }

            Usuario? insUsuario = DataManager.DataRowToObject<Usuario>(msg.Entity.Rows[^1]);

            if(insUsuario == null)
            {
                return new(msg.State, "Usuario incorrecto", ResultadoAutenticacion.UsuarioIncorrecto);
            }

            var sessionMsg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    string insertSessionQuery = 
                    $"INSERT INTO {TableSesion} (codses_ses, codusr_ses, ultsesion_ses, " +
                    $"fecha_sesion, equipo_ses, usuario_ses, mantener_ses, cerrado_ses) " +
                    $"VALUES (@codses_ses, @codusr_ses, @ultsesion_ses, @fecha_sesion, @equipo_ses, @usuario_ses, @mantener_ses, @cerrado_ses)";

                    string updateSessionQuery = $"UPDATE {TableSesion} " +
                    $"SET ultsesion_ses = @ultsesion_ses, equipo_ses = @equipo_ses, " +
                    $"mantener_ses = @mantener_ses " +
                    $"WHERE codses_ses = @codses_ses";

                    string sessionQuery = $"SELECT * FROM {TableSesion} WHERE cerrado_ses = 0 AND usuario_ses = @usuario_ses";

                    var sesionMsg = this.conexion.ObtenerDatos(sessionQuery, conn, [ new("usuario_ses", username) ], tran);

                    if(!sesionMsg.State)
                    {
                        return new(false, sesionMsg.Msg, null);
                    }

                    if(sesionMsg.Entity == null)
                    {
                        return new(false, sesionMsg.Msg, null);
                    }

                    // SI ES NULA, NO HAY SESION ACTIVA
                    Sesion? tempSession = DataManager.DataRowToObject<Sesion>(sesionMsg.Entity.Rows.Count > 0 ? sesionMsg.Entity.Rows[^1] : null);

                    try
                    {
                        int secuencia = SecuenciaManager.ObtenerSiguiente(TableSesion, conn, tran, true);
                        if (secuencia == -1)
                        {
                            return new(false, Mensajes.Msj_Error_GenerarSecuencia, false);
                        }

                        SqlParameter[] updateParamList = [
                            new("codses_ses", secuencia),
                            new("ultsesion_ses", DateTime.Now),
                            new("mantener_ses", false),
                            new("equipo_ses", this.pcname),
                        ];

                        SqlParameter[] parameters = tempSession != null ? updateParamList : 
                        [
                            new("codses_ses", secuencia),
                            new("codusr_ses", insUsuario.cod_usr),
                            new("ultsesion_ses", DateTime.Now),
                            new("equipo_ses", this.pcname),
                            new("usuario_ses", insUsuario.username),
                            new("mantener_ses", false),
                            new("cerrado_ses", false),
                            new("fecha_sesion", DateTime.Now),
                        ];

                        int affected = ConexionSQL.ExecuteNonQuery( tempSession == null ? insertSessionQuery : updateSessionQuery, conn, parameters, tran);
                        var currentSession = this.conexion.ObtenerDatos(sessionQuery, conn, [new("usuario_ses", username)], tran);

                        if(!currentSession.State)
                        {
                            return new(false, currentSession.Msg, false);
                        }

                        if(currentSession.Entity == null)
                        {
                            return new(false, currentSession.Msg, false);
                        }

                        if(currentSession.Entity.Rows.Count == 0)
                        {
                            return new(false, $"Error al crear la sesión: {currentSession.Msg}", false);
                        }

                        tempSession = DataManager.DataRowToObject<Sesion>(currentSession.Entity.Rows[^1]);

                        if(tempSession == null)
                        {
                            return new(false, $"Error al crear la sesión: {currentSession.Msg}", false);
                        }

                        SesionModel.CurrentSession = tempSession;
                        ConexionSQL.SessionInfo = new()
                        {
                            codusr_actual = tempSession.codusr_ses,
                            usuario_actual = tempSession.usuario_ses,
                        };
                        var valor = new MSSQLRepositorio.Tipos.Message<object>(true, Mensajes.Msj_Aviso_InstruccionEjecutada, true);
                        if (valor.State)
                        {
                            tran.Commit();
                        }
                        return valor;
                    }
                    catch (Exception ex)
                    {
                        return new(false, ex.Message, false);
                    }
                }
            );

            string _msg = sessionMsg.Entity is true ? $"Bienvenido {username}" : sessionMsg.Msg;
            return new(sessionMsg.State, _msg, sessionMsg.Entity is true ? ResultadoAutenticacion.Autenticado : ResultadoAutenticacion.UsuarioIncorrecto);
        }
    }
}
