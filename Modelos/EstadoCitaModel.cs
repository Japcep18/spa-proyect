using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Tipos;
using Modelos.Servicios;
using Microsoft.Data.SqlClient;
using System.Data;
using Modelos.Estandard;
using MSSQLRepositorio;

namespace Modelos
{
    public class EstadoCita : DBObject
    {
        [Required]
        [DisplayName("Código")]
        public int cod_ecit { get; set; }
        [Required]                                              
        [StringLength(maximumLength: 50, MinimumLength = 1)]   
        [DisplayName("Descripción")]                          
        public string desc_ecit { get; set; }

        public override string ToString()
        {
            return $"{cod_ecit} - {desc_ecit}";
        }
    }
    public class EstadoCitaModel : BaseModel<EstadoCita>, IModeloSimple<EstadoCita>
    {
        public string? Codigo
        {
            get => Model?.cod_ecit.ToString();
            set
            {
                {
                    if (value == null)
                    {
                        this.Model = null;
                        this.Descripcion = null;
                    }
                    else
                    {
                        if (value != Model?.cod_ecit.ToString())
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
        }
        public string? Descripcion
        {
            get
            {
                if (this.Model != null)
                    return this.Model.desc_ecit;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_ecit = value;
            }
        }

        public override string TableName => "EstadoCita";

        public event EventHandler<string?>? CambioModelo;

        public EstadoCitaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<EstadoCita>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<EstadoCita> rawDataList = DataManager.DataTableToList<EstadoCita>(msg.Entity);
                this.DataList = rawDataList.Select(ecit =>
                {
                    return new EstadoCita()
                    {
                        cod_ecit = ecit.cod_ecit,
                        desc_ecit = ecit.desc_ecit,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<EstadoCita> Guardar()
        {
            if(this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }
            switch (this.Model.state) 
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                         (SqlConnection conn, SqlTransaction tran) =>
                         {
                             string query = $"INSERT INTO {this.TableName} (cod_ecit, desc_ecit) VALUES (@cod, @desc_ecit);";

                             try
                             {
                                 int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                 if (secuencia == -1)
                                 {
                                     return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                 }
                                 SqlParameter[] paramsList = [
                                    new("cod", secuencia),
                                    new("desc_ecit", this.Model.desc_ecit.ToUpper()),
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
                            (SqlConnection conn, SqlTransaction tran) =>
                            {
                                string query = $"UPDATE {this.TableName} SET desc_ecit = @desc_ecit " +
                                $" WHERE cod_ecit = @cod_ecit";

                                SqlParameter[] paramsList = [
                                    new("desc_ecit", this.Model.desc_ecit.ToUpper()),
                                    new("cod_ecit", this.Model.cod_ecit)
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

        public EstadoCita? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_ecit = @cod_ecit;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_ecit", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        EstadoCita? ecit = DataManager.DataRowToObject<EstadoCita>(dataTable.Rows[0]);
                        return ecit;
                    }
                }
            }
            return null;
        }
        public override void CargarDatos(EstadoCita? entity)
        {
            if(entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_ecit.ToString();
        }

        IEnumerable<EstadoCita> IModeloSimple<EstadoCita>.ObtenerTodos()
        {
            return this.DataList;
        }
    }
}
