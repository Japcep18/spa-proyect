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
    public class ClienteMembresia : DBObject
    {
        [Required]
        public int codcli_cmem { get; set; }

        [Required]
        public int codmem_cmem { get; set; }

    }

    public class ClienteMembresiaModel : BaseModel<ClienteMembresia>
    {
        public Membresia? Membresia { get; set; }
        public override string TableName => "ClienteMembresia";
        private ClienteModel clienteModel = new();

        public event EventHandler<string?>? CambioModelo;

        public ClienteMembresiaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<ClienteMembresia>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName} ";
            SqlParameter[] parameters = [];
            if (this.Membresia != null)
            {
                query += $" WHERE codmem_cmem = @codmem_cmem";
                parameters = [
                    new("codmem_cmem", this.Membresia.cod_mem),
                ];
            }

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<ClienteMembresia> rawDataList = DataManager.DataTableToList<ClienteMembresia>(msg.Entity);
                this.DataList = rawDataList.Select(climem =>
                {
                    return new ClienteMembresia()
                    {
                        codcli_cmem = climem.codcli_cmem,
                        codmem_cmem = climem.codmem_cmem,
                        state = EntityState.Modificado,
                    };
                });
            }
            return new(msg.State, msg.Msg, this.DataList);
        }

        public EntityMessage<IEnumerable<Cliente>> ObtenerClientes(Membresia membresia)
        {
            string query = "SELECT *, (SELECT nombre_ent FROM Entidad WHERE codent_cli = codent_ent) AS nombre_cliente FROM Cliente WHERE codent_cli IN (SELECT codcli_cmem FROM ClienteMembresia WHERE codmem_cmem = @codmem_cmem)";

            SqlParameter[] parameters =
            [
                new("codmem_cmem", membresia.cod_mem),
            ];

            IEnumerable<Cliente> dataList = [];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Cliente> rawDataList = DataManager.DataTableToList<Cliente>(msg.Entity);
                dataList = rawDataList.Select(cli =>
                {
                    return new Cliente()
                    {
                        codent_cli = cli.codent_cli,
                        codtcli_cli = cli.codtcli_cli,
                        feceg_cli = cli.feceg_cli,
                        activo_cli = cli.activo_cli,
                        state = EntityState.Modificado,
                    };
                });
            }
            return new(msg.State, msg.Msg, dataList);
        }
        public override EntityMessage<ClienteMembresia> Guardar()
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
                             string query = $"INSERT INTO {this.TableName} (codcli_cmem, codmem_cmem) " +
                                 $"VALUES (@codcli_cmem, @codmem_cmem);";
                             try
                             {
                                 SqlParameter[] paramsList = [
                                    new("codcli_cmem", this.Model.codcli_cmem),
                                    new("codmem_cmem", this.Model.codmem_cmem),
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
                               string query = $"UPDATE {this.TableName} SET codmem_cmem = @codmem_cmem " +
                                   $" WHERE codcli_cmem = @codcli_cmem;";

                               SqlParameter[] paramsList = [
                                    new("codcli_cmem", this.Model.codcli_cmem),
                                    new("codmem_cmem", this.Model.codmem_cmem),
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

        public EntityMessage<object?> Guardar(IEnumerable<Cliente> clienteList)
        {
            if (this.Membresia == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            string deleteQuery = $"DELETE {this.TableName} WHERE codmem_cmem = @codmem_cmem";
            SqlParameter[] deleteParams = [
                new("codmem_cmem", this.Membresia.cod_mem),
            ];

            string insertQuery = $"INSERT INTO {this.TableName} (codcli_cmem, codmem_cmem) VALUES (@codcli_cmem, @codmem_cmem)";

            var msg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    SqlParameter[] insertParameters;

                    try
                    {
                        ConexionSQL.ExecuteNonQuery(deleteQuery, conn, deleteParams, tran);

                        foreach (var item in clienteList)
                        {
                            insertParameters = [
                                new("codcli_cmem", item.codent_cli),
                                new("codmem_cmem", this.Membresia.cod_mem),
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
