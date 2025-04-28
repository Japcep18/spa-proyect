using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public class TipoSalaServicio : DBObject
    {
        [Required]
        public int codtsal_tssrv { get; set; }
        [Required]
        public int codser_tssrv { get; set; }   

    }
    public class TipoSalaServicioModel : BaseModel<TipoSalaServicio>
    {
        public Servicio? Servicio { get; set; }
        public override string TableName => "TipoSalaServicio";

        public event EventHandler<string?>? CambioModelo;

        public TipoSalaServicioModel()
        {

            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<TipoSalaServicio>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName} ";
            SqlParameter[] parameters = [];
            if (this.Servicio != null)
            {
                query += $" WHERE codser_tssrv = @codser_tssrv";
                parameters = [
                    new("codser_tssrv", this.Servicio.cod_ser),
                ];
            }

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<TipoSalaServicio> rawDataList = DataManager.DataTableToList<TipoSalaServicio>(msg.Entity);
                this.DataList = rawDataList.Select(tsalser =>
                {
                    return new TipoSalaServicio()
                    {
                        codtsal_tssrv = tsalser.codtsal_tssrv,
                        codser_tssrv = tsalser.codser_tssrv,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public EntityMessage<IEnumerable<TipoSala>> ObtenerServicios(Servicio servicio)
        {
            string query = "SELECT * FROM TipoSala WHERE cod_tsal IN (SELECT codtsal_tssrv FROM TipoSalaServicio WHERE codser_tssrv = @codser_tssrv)";

            SqlParameter[] parameters =
            [
                new("codser_tssrv", servicio.cod_ser),
            ];

            IEnumerable<TipoSala> dataList = [];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<TipoSala> rawDataList = DataManager.DataTableToList<TipoSala>(msg.Entity);
                dataList = rawDataList.Select(tsal =>
                {

                    return new TipoSala()
                    {
                        cod_tsal = tsal.cod_tsal,
                        nombre_tsal = tsal.nombre_tsal,
                        state = EntityState.Modificado,
                    };
                });
            }
            return new(msg.State, msg.Msg, dataList);
        }

        public override EntityMessage<TipoSalaServicio> Guardar()
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
                             string query = $"INSERT INTO {this.TableName} (codtsal_tssrv, codser_tssrv) " +
                                 $"VALUES (@codser_tssrv, @codser_tssrv);";
                             try
                             {
                                 SqlParameter[] paramsList = [
                                    new("codtsal_tssrv", this.Model.codtsal_tssrv),
                                    new("codser_tssrv", this.Model.codser_tssrv),
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
                               string query = $"UPDATE {this.TableName} SET codser_tssrv = @codser_tssrv " +
                                   $" WHERE codtsal_tssrv = @codtsal_tssrv;";

                               SqlParameter[] paramsList = [
                                    new("codtsal_tssrv", this.Model.codtsal_tssrv),
                                    new("codser_tssrv", this.Model.codser_tssrv),
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
        public EntityMessage<object?> Guardar(IEnumerable<TipoSala> tiposalaList)
        {
            if (this.Servicio == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }
            string deleteQuery = $"DELETE {this.TableName} WHERE codser_tssrv = @codser_tssrv";
            SqlParameter[] deleteParams = [
                new("codser_tssrv", this.Servicio.cod_ser),
            ];

            string insertQuery = $"INSERT INTO {this.TableName} (codtsal_tssrv, codser_tssrv) VALUES (@codtsal_tssrv, @codser_tssrv)";

            var msg = this.conexion.ExecuteInstructions(
              (conn, tran) =>
              {
                  SqlParameter[] insertParameters;

                  try
                  {
                      ConexionSQL.ExecuteNonQuery(deleteQuery, conn, deleteParams, tran);

                      foreach (var item in tiposalaList)
                      {
                          insertParameters = [
                              new("codtsal_tssrv", item.cod_tsal),
                                new("codser_tssrv", this.Servicio.cod_ser),
                          ];

                          ConexionSQL.ExecuteNonQuery(insertQuery, conn, insertParameters, tran);
                      }

                      tran.Commit();
                      return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, null);
                  }
                  catch (Exception ex)
                  {
                      return new(false, ex.Message, null);
                  }
              });

            return new(msg.State, msg.Msg, null);
        }
    }
}
