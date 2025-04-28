using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public class TipoDocumento : DBObject
    {
        [Required]
        [DisplayName("Código")]
        public int cod_tdoc { get; set; }
        [Required]
        [DisplayName("Descripcion")]
        [StringLength(100, MinimumLength = 3)]
        public string descr_tdoc { get; set; }

        public override string ToString()
        {
            return $"{cod_tdoc} - {descr_tdoc}";
        }
    }

    public class TipoDocumentoModel : BaseModel<TipoDocumento>, IModeloSimple<TipoDocumento>
    {
        public string? Codigo
        {
            get => Model?.cod_tdoc.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_tdoc.ToString())
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
                    return this.Model.descr_tdoc;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.descr_tdoc = value;
            }
        }

        public override string TableName => "TipoDocumento";

        public event EventHandler<string?>? CambioModelo;

        public TipoDocumentoModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<TipoDocumento>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<TipoDocumento> rawDataList = DataManager.DataTableToList<TipoDocumento>(msg.Entity);
                this.DataList = rawDataList.Select(tdoc =>
                {

                    return new TipoDocumento()
                    {
                        cod_tdoc = tdoc.cod_tdoc,
                        descr_tdoc = tdoc.descr_tdoc,
                        state = EntityState.Modificado,
                    };
                });
            }
            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<TipoDocumento> Guardar()
        {

            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            switch (this.Model.state) 
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                          (conn, tran) => {
                              string query = $"INSERT INTO {this.TableName} (cod_tdoc, descr_tdoc) " +
                                  $"VALUES (@cod_tdoc, @descr_tdoc);";

                              try
                              {
                                  int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                  if (secuencia == -1)
                                  {
                                      return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                  }

                                  SqlParameter[] paramsList = [
                                    new("cod_tdoc", secuencia),
                                    new("descr_tdoc", this.Model.descr_tdoc.ToUpper()),
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
                                string query = $"UPDATE {this.TableName} SET descr_tdoc = @descr_tdoc " +
                                    $" WHERE cod_tdoc = @cod_tdoc;";

                                SqlParameter[] paramsList = [
                                    new("cod_tdoc", this.Model.cod_tdoc),
                                    new("descr_tdoc", this.Model.descr_tdoc.ToUpper()),
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
       

        public TipoDocumento? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_tdoc = @cod_tdoc;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_tdoc", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        TipoDocumento? tdoc = DataManager.DataRowToObject<TipoDocumento>(dataTable.Rows[0]);
                        return tdoc;
                    }
                }
            }
            return null;
        }

        public IEnumerable<TipoDocumento> ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(TipoDocumento? entity)
        {
            if (entity != null)
                entity.state = EntityState.Modificado;
            {
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_tdoc.ToString();
        }
    }
}
