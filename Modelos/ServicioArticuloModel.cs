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
    public class ServicioArticulo : DBObject
    {
        [Required]
        public int codser_sat { get; set; }

        [Required]
        public int codart_sat { get; set; }
    }

    public class ServicioArticuloModel : BaseModel<ServicioArticulo>
    {
        public Servicio? Servicio { get; set; }
        public override string TableName => "ServicioArticulo";

        public event EventHandler<string?>? CambioModelo;

        public ServicioArticuloModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<ServicioArticulo>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName} ";
            SqlParameter[] parameters = [];
            if (this.Servicio != null)
            {
                query += $" WHERE codser_sat = @codser_sat";
                parameters = [
                    new("codser_sat", this.Servicio.cod_ser),
                ];
            }

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<ServicioArticulo> rawDataList = DataManager.DataTableToList<ServicioArticulo>(msg.Entity);
                this.DataList = rawDataList.Select(serart =>
                {
                    return new ServicioArticulo()
                    {
                        codser_sat = serart.codser_sat,
                        codart_sat = serart.codart_sat,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public EntityMessage<IEnumerable<Articulo>> ObtenerArticulos(Servicio servicio)
        {
            string query = "SELECT * FROM Articulo WHERE cod_art IN (SELECT codart_sat FROM ServicioArticulo WHERE codser_sat = @codser_sat)";

            SqlParameter[] parameters =
            [
                new("codser_sat", servicio.cod_ser),
            ];

            IEnumerable<Articulo> dataList = [];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Articulo> rawDataList = DataManager.DataTableToList<Articulo>(msg.Entity);
                dataList = rawDataList.Select(art =>
                {

                    return new Articulo()
                    {
                        cod_art = art.cod_art,
                        coduni_art = art.coduni_art,
                        descripcion_art = art.descripcion_art,
                       // valor_itbis = art.valor_itbis,
                        precio_art = art.precio_art,
                        afectainv_art = art.afectainv_art,
                        cantidadinv_art = art.cantidadinv_art,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, dataList);
        }

        public override EntityMessage<ServicioArticulo> Guardar()
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
                             string query = $"INSERT INTO {this.TableName} (codser_sat, codart_sat) " +
                                 $"VALUES (@codser_sat, @codart_sat);";
                             try
                             {
                                 SqlParameter[] paramsList = [
                                    new("codser_sat", this.Model.codser_sat),
                                    new("codart_sat", this.Model.codart_sat),
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
                               string query = $"UPDATE {this.TableName} SET codser_sat = @codser_sat " +
                                   $" WHERE codart_sat = @codart_sat;";

                               SqlParameter[] paramsList = [
                                    new("codser_sat", this.Model.codser_sat),
                                    new("codart_sat", this.Model.codart_sat),
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

        public EntityMessage<object?> Guardar(IEnumerable<Articulo> articloList)
        {
            if (this.Servicio == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            string deleteQuery = $"DELETE {this.TableName} WHERE codser_sat = @codser_sat";
            SqlParameter[] deleteParams = [
                new("codser_sat", this.Servicio.cod_ser),
            ];

            string insertQuery = $"INSERT INTO {this.TableName} (codser_sat, codart_sat) VALUES (@codser_sat, @codart_sat)";

            var msg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    SqlParameter[] insertParameters;

                    try
                    {
                        ConexionSQL.ExecuteNonQuery(deleteQuery, conn, deleteParams, tran);

                        foreach (var item in articloList)
                        {
                            insertParameters = [
                                new("codart_sat", item.cod_art),
                                new("codser_sat", this.Servicio.cod_ser),
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
