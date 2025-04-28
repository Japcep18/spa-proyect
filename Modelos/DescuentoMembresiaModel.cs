using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public class DescuentoMembresia : DBObject
    {
        [Required]
        public int coddes_dmem { get; set; }

        [Required]
        public int codmem_dmem { get; set; }
    }

    public class DescuentoMembresiaModel : BaseModel<DescuentoMembresia>
    {
        public Membresia? Membresia { get; set; }

        public override string TableName => "DescuentoMembresia";

        public event EventHandler<string?>? CambioModelo;

        public DescuentoMembresiaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<DescuentoMembresia>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName} ";
            SqlParameter[] parameters = [];
            if (this.Membresia != null)
            {
                query += $" WHERE codmem_dmem = @codmem_dmem";
                parameters = [
                    new("codmem_dmem", this.Membresia.cod_mem),
                ];
            }

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<DescuentoMembresia> rawDataList = DataManager.DataTableToList<DescuentoMembresia>(msg.Entity);
                this.DataList = rawDataList.Select(descmemb =>
                {
                    return new DescuentoMembresia()
                    {
                        coddes_dmem = descmemb.coddes_dmem,
                        codmem_dmem = descmemb.codmem_dmem,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public EntityMessage<IEnumerable<Descuento>> ObtenerDescuentos(Membresia membresia)
        {
            string query = "SELECT * FROM Descuento WHERE cod_desc IN (SELECT coddes_dmem FROM DescuentoMembresia WHERE codmem_dmem = @codmem_dmem)";

            SqlParameter[] parameters =
            [
                new("codmem_dmem", membresia.cod_mem),
            ];

            IEnumerable<Descuento> dataList = [];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Descuento> rawDataList = DataManager.DataTableToList<Descuento>(msg.Entity);
                dataList = rawDataList.Select(des => 
                {
                    return new Descuento()
                    {
                        cod_desc = des.cod_desc,
                        descripcion_desc = des.descripcion_desc,
                        porcentaje_desc = des.porcentaje_desc,
                        fechainicio_desc = des.fechainicio_desc,
                        fechafin_desc = des.fechafin_desc,
                        afectaitbis_desc = des.afectaitbis_desc,
                        activo_des = des.activo_des,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, dataList);
        }

        public override EntityMessage<DescuentoMembresia> Guardar()
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
                             string query = $"INSERT INTO {this.TableName} (coddes_dmem, codmem_dmem) " +
                                 $"VALUES (@coddes_dmem, @codmem_dmem);";
                             try
                             {
                                 SqlParameter[] paramsList = [
                                    new("coddes_dmem", this.Model.coddes_dmem),
                                    new("codmem_dmem", this.Model.codmem_dmem),
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
                               string query = $"UPDATE {this.TableName} SET codmem_dmem = @codmem_dmem " +
                                   $" WHERE coddes_dmem = @coddes_dmem;";

                               SqlParameter[] paramsList = [
                                    new("coddes_dmem", this.Model.coddes_dmem),
                                    new("codmem_dmem", this.Model.codmem_dmem),
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

        public EntityMessage<object?> Guardar(IEnumerable<Descuento> descuentoList)
        {
            if (this.Membresia == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            string deleteQuery = $"DELETE {this.TableName} WHERE codmem_dmem = @codmem_dmem";
            SqlParameter[] deleteParams = [
                new("codmem_dmem", this.Membresia.cod_mem),
            ];

            string insertQuery = $"INSERT INTO {this.TableName} (coddes_dmem, codmem_dmem) VALUES (@coddes_dmem, @codmem_dmem)";

            var msg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    SqlParameter[] insertParameters;

                    try
                    {
                        ConexionSQL.ExecuteNonQuery(deleteQuery, conn, deleteParams, tran);

                        foreach (var item in descuentoList)
                        {
                            insertParameters = [
                                new("coddes_dmem", item.cod_desc),
                                new("codmem_dmem", this.Membresia.cod_mem),
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
