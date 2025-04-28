using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio.Tipos;
using MSSQLRepositorio;
using System.Data;
using System.ComponentModel;

namespace Modelos
{
    public class Guarderia : DBObject 
    {
        public int codven_guar {  get; set; }

        [DisplayName("#")]
        public int secuen_guar { get; set; }
        [DisplayName("Tutor")]
        public string tutor_guar { get; set; }
        [DisplayName("Infante")]
        public string infante_guar { get; set; }
    }

    public class GuarderiaModel : BaseModel<Guarderia>
    {
        public override string TableName => "Guarderia";

        public event EventHandler<string?>? CambioModelo;

        public GuarderiaModel() {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Guarderia>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Guarderia> rawDataList = DataManager.DataTableToList<Guarderia>(msg.Entity);
                this.DataList = rawDataList.Select(guar =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Guarderia()
                    {
                        codven_guar = guar.codven_guar,
                        secuen_guar = guar.secuen_guar,
                        tutor_guar = guar.tutor_guar,
                        infante_guar = guar.infante_guar,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Guarderia> Guardar()
        {
            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }
            switch (this.Model.state)
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                       (conn, tran) =>
                       {
                           string query = $"INSERT INTO {this.TableName} " +
                           $"(codven_guar, secuen_guar, tutor_guar, infante_guar) " +
                           $"VALUES (@codven_guar, @secuen_guar, @tutor_guar, @infante_guar);";

                           SqlParameter[] paramsList =
                           [
                                new("codven_guar", this.Model.codven_guar),
                                new("secuen_guar", this.Model.secuen_guar),
                                new("tutor_guar", this.Model.tutor_guar),
                                new("infante_guar", this.Model.infante_guar),
                            ];

                           try
                           {
                               int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                               Message<object> valor = new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
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
                    return new(insertMsg.State, insertMsg.Msg, this.Model);

                case EntityState.Modificado:
                    var updateMsg = this.conexion.ExecuteInstructions(
                           (conn, tran) =>
                           {
                               string query = $"UPDATE {this.TableName} SET" +
                               $" secuen_guar = @secuen_guar, tutor_guar = @tutor_guar, infante_guar = @infante_guar " +
                               $" WHERE codven_guar = @codven_guar;";

                               SqlParameter[] paramsList = [
                                    new("codven_guar", this.Model.codven_guar),
                                    new("secuen_guar", this.Model.secuen_guar),
                                    new("tutor_guar", this.Model.tutor_guar),
                                    new("infante_guar", this.Model.infante_guar),
                               ];

                               try
                               {
                                   int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                                   Message<object> valor = new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
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

        public EntityMessage<IEnumerable<Guarderia>> Guardar(IEnumerable<Guarderia> dataList, string codigoent)
        {
            string insertQuery = $"INSERT INTO {this.TableName} (codven_guar, secuen_guar, tutor_guar, infante_guar) VALUES (@codven_guar, @secuen_guar, @tutor_guar, @infante_guar)";
            string deleteQuery = $"DELETE FROM {this.TableName} WHERE codven_guar = @codven_guar";
            var resultMsg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    try
                    {
                        var deleteMsg = ConexionSQL.ExecuteNonQuery(deleteQuery, conn, [new("codven_guar", codigoent)], tran);

                        foreach (var item in dataList)
                        {
                            SqlParameter[] paramters = [
                                new SqlParameter("codven_guar", codigoent),
                                new SqlParameter("secuen_guar", item.secuen_guar),
                                new SqlParameter("tutor_guar", item.tutor_guar),
                                new SqlParameter("infante_guar", item.infante_guar)
                            ];

                            var result = ConexionSQL.ExecuteNonQuery(insertQuery, conn, paramters, tran);
                        }

                        tran.Commit();
                        return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, null);
                    }
                    catch (Exception ex)
                    {
                        return new(false, ex.Message, null);
                    }
                }
            );
            return new(resultMsg.State, resultMsg.Msg, dataList);
        }

        public EntityMessage<IEnumerable<Guarderia>> Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE codven_guar = @codven_guar";
            SqlParameter[] parameters =
            [
                new("codven_guar", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                DataTable? data = msg.Entity;
                if (data == null)
                    return new(msg.State, msg.Msg, []);
                if (data.Rows.Count == 0)
                    return new(msg.State, msg.Msg, []);

                List<Guarderia> dataList = new();
                foreach (DataRow row in data.Rows)
                {
                    var obj = DataManager.DataRowToObject<Guarderia>(row);
                    if (obj != null)
                        dataList.Add(obj);
                }

                return new(msg.State, msg.Msg, dataList);
            }
            return new(msg.State, msg.Msg, []);
        }

        public EntityMessage<Guarderia?> Obtener(string codigo, string secuencia)
        {
            string query = $"SELECT * FROM {TableName} WHERE codven_guar = @codven_guar AND secuen_guar = @secuen_guar";
            SqlParameter[] parameters =
            [
                new("codven_guar", codigo),
                new("secuen_guar", secuencia),
            ];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                DataTable? data = msg.Entity;
                if (data == null)
                    return new(msg.State, msg.Msg, null);
                if (data.Rows.Count == 0)
                    return new(msg.State, msg.Msg, null);

                var obj = DataManager.DataRowToObject<Guarderia>(data.Rows[0]);

                return new(msg.State, msg.Msg, obj);
            }
            return new(msg.State, msg.Msg, null);
        }
    }
}
