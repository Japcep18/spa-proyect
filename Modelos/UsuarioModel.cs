using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Modelos
{
    public class Usuario : DBObject
    {
        public int cod_usr { get; set; }
        public int codemp_usr { get; set; }
        [StringLength(200, MinimumLength = 3)]
        public string username { get; set; }
        [StringLength(200, MinimumLength = 3)]
        public string clave { get; set; }
        public int codperf_usr { get; set; }
        public bool activo_usr { get; set; }

        public override string ToString()
        {
            return $"{cod_usr} - {username}";
        }
    }

    public class UsuarioModel : BaseModel<Usuario>, IModeloSimple<Usuario>
    {
        public string? Codigo
        {
            get => Model?.cod_usr.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_usr.ToString())
                    {
                        var obj = this.Obtener(value);
                        if (obj == null)
                        {
                            this.Model = null;
                            this.Descripcion = null;
                        }
                        else
                        {
                            obj.state = EntityState.Modificado;
                            this.Model = obj;
                            this.Descripcion = obj.ToString();
                        }
                    }
                }
                // Ejecutar evento de que cambio
                this.CambioModelo?.Invoke(this, value);
            }
        }

        // Implementación de IModeloSimple, representa una descripción para poder mostrar
        public string? Descripcion
        {
            get
            {
                if (this.Model != null)
                    return this.Model.username;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.username = value;
            }
        }

        public override string TableName => "Usuario";

        public event EventHandler<string?>? CambioModelo;

        public UsuarioModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Usuario>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Usuario> rawDataList = DataManager.DataTableToList<Usuario>(msg.Entity);
                this.DataList = rawDataList.Select(usr =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Usuario()
                    {
                        cod_usr = usr.cod_usr,
                        codemp_usr = usr.codemp_usr,
                        codperf_usr = usr.codperf_usr,
                        clave = usr.clave,
                        username = usr.username,
                        activo_usr = usr.activo_usr,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Usuario> Guardar()
        {
            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            switch (this.Model.state)
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions((conn, tran) =>
                    {
                        string query = $"INSERT INTO {this.TableName} (cod_usr, codemp_usr, codperf_usr, username, clave, activo_usr) VALUES (@cod_usr, @codemp_usr, @codperf_usr, @username, @clave, @activo_usr)";
                        try
                        {
                            int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                            if (secuencia == -1)
                            {
                                return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                            }
                            SqlParameter[] paramsList = [
                                new("cod_usr", secuencia), 
                                new("codemp_usr", Model.codemp_usr), 
                                new("codperf_usr", Model.codperf_usr), 
                                new("username", Model.username), 
                                new("clave", Model.clave), 
                                new("activo_usr", Model.activo_usr)
                            ];

                            int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                            var valor = new MSSQLRepositorio.Tipos.Message<object>(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
                            if (valor.State)
                            {
                                tran.Commit();
                            }
                            return valor;
                        }
                        catch (Exception ex)
                        {
                            return new(false, ex.Message, this.Model);
                        }
                    });
                    return new(insertMsg.State, insertMsg.Msg, this.Model);
                case EntityState.Modificado:
                    var updateMsg = this.conexion.ExecuteInstructions(
                        (conn, tran) =>
                        {
                            string query = $"UPDATE {this.TableName} SET " +
                            $" codemp_usr = @codemp_usr, codperf_usr = @codperf_usr, username = @username, clave = @clave, activo_usr = @activo_usr " +
                            $"WHERE cod_usr = @cod_usr";

                            SqlParameter[] paramsList = [
                                new("cod_usr", Model.cod_usr),
                                new("codemp_usr", Model.codemp_usr),
                                new("codperf_usr", Model.codperf_usr),
                                new("username", Model.username),
                                new("clave", Model.clave),
                                new("activo_usr", Model.activo_usr)
                            ];

                            try
                            {
                                int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                                var valor = new MSSQLRepositorio.Tipos.Message<object>(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
                                if (valor.State)
                                {
                                    tran.Commit();
                                }
                                return valor;
                            }
                            catch (Exception ex)
                            {
                                return new(false, ex.Message, this.Model);
                            }
                        }
                    );
                    return new(updateMsg.State, updateMsg.Msg, this.Model);
                case EntityState.Eliminado:
                    break;
                default:
                    break;
            }

            return null;
        }

        public Usuario? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_usr = @cod_usr;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_usr", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Usuario? serv = DataManager.DataRowToObject<Usuario>(dataTable.Rows[0]);
                        return serv;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(Usuario? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            //this.CambioModelo?.Invoke(this, entity?.cod_ser.ToString());

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.cod_usr.ToString();
        }
    }
}
