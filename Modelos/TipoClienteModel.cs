using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public class TipoCliente : DBObject
    {
        [Required]
        [DisplayName("Codigo")]
        public int cod_tcli { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [DisplayName("Descripcion")]
        public string desc_tcli { get; set; }

        public override string ToString()
        {
            return $"{cod_tcli} - {desc_tcli}";
        }
    }
    public class TipoClienteModel : BaseModel<TipoCliente>, IModeloSimple<TipoCliente>
    {
        public string? Codigo
        {
            get => Model?.cod_tcli.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_tcli.ToString())
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
                this.CambioModelo?.Invoke(this, value);
            }
        }
        public string? Descripcion
        {
            get
            {
                if (this.Model != null)
                    return this.Model.desc_tcli;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_tcli = value;
            }
        }

        public override string TableName => "TipoCliente";

        public event EventHandler<string?>? CambioModelo;
        public TipoClienteModel() 
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<TipoCliente>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<TipoCliente> rawDataList = DataManager.DataTableToList<TipoCliente>(msg.Entity);
                this.DataList = rawDataList.Select(tcli =>
                {
                    //srv.state = EntityState.Modificado;
                    return new TipoCliente()
                    {
                        cod_tcli = tcli.cod_tcli,
                        desc_tcli = tcli.desc_tcli,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<TipoCliente> Guardar()
        {
            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }
            switch (this.Model.state)
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                        (SqlConnection conn, SqlTransaction tran) =>
                        {
                            string query = $"INSERT INTO {this.TableName} (cod_tcli, desc_tcli) VALUES (@cod_tcli, @desc_tcli);";

                            int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                            if (secuencia == -1)
                            {
                                return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                            }
                            SqlParameter[] paramsList = [
                                new("cod_tcli", secuencia),
                                new("desc_tcli", Model.desc_tcli.ToUpper()),
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
                        });
                    return new(insertMsg.State, insertMsg.Msg, this.Model);
                case EntityState.Modificado:
                    var updateMsg = this.conexion.ExecuteInstructions(
                        (SqlConnection conn, SqlTransaction tran) =>
                        {
                            string query = $"UPDATE {this.TableName} SET desc_tcli = @desc_tcli " +
                               $"WHERE cod_tcli = @cod_tcli";

                            SqlParameter[] paramsList = [
                                new("nombre", this.Model.desc_tcli.ToUpper()),
                                new("cod_tcli", this.Model.cod_tcli)
                            ];
                            try
                            {
                                int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                                var valor = new MSSQLRepositorio.Tipos.Message<object>(true, "Instrucción Ejecutada", this.Model);
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

        public TipoCliente? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_tcli = @cod_tcli";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_tcli", codigo)
            ];
            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        TipoCliente? tcli = DataManager.DataRowToObject<TipoCliente>(dataTable.Rows[0]);
                        return tcli;
                    }
                }
            }
            return null;
        }

        public override void CargarDatos(TipoCliente? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_tcli.ToString();
        }

        IEnumerable<TipoCliente> IModeloSimple<TipoCliente>.ObtenerTodos()
        {
            return this.DataList;
        }
    }
}
