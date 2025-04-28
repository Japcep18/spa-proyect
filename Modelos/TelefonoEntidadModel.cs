using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using MSSQLRepositorio.Tipos;

namespace Modelos
{
    public class TelefonoEntidad : DBObject
    {
        public int codent_telef { get; set; }
        public int secuen_telef { get; set; }
        public string telef_telef { get; set; }
        public bool activo_telef { get; set; }
    }
    public class TelefonoEntidadModel : BaseModel<TelefonoEntidad>
    {
        public override string TableName => "TelefonoEntidad";

        public TelefonoEntidadModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<TelefonoEntidad>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<TelefonoEntidad> rawDataList = DataManager.DataTableToList<TelefonoEntidad>(msg.Entity);
                this.DataList = rawDataList.Select(telf =>
                {
                    //srv.state = EntityState.Modificado;
                    return new TelefonoEntidad()
                    {
                        codent_telef = telf.codent_telef,
                        secuen_telef = telf.secuen_telef,
                        telef_telef = telf.telef_telef,
                        activo_telef = telf.activo_telef,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<TelefonoEntidad> Guardar()
        {
            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }
            switch (this.Model.state) 
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                       ( conn,  tran) =>
                       {
                           string query = $"INSERT INTO {this.TableName} " +
                           $"(codent_telef, secuen_telef, telef_telef, activo_telef) " +
                           $"VALUES (@codent_telef, @secuen_telef, @telef_telef, @activo_telef);";

                           SqlParameter[] paramsList =
                           [
                                new("codent_telef", this.Model.codent_telef),
                                new("secuen_telef", this.Model.secuen_telef),
                                new("telef_telef", this.Model.telef_telef),
                                new("activo_telef", this.Model.activo_telef),
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
                           catch(Exception ex)
                           {
                               return new(false, ex.Message, this.Model);
                           }
                       }
                    );
                    return new(insertMsg.State, insertMsg.Msg, this.Model);

                case EntityState.Modificado:
                    var updateMsg = this.conexion.ExecuteInstructions(
                           ( conn,  tran) =>
                           {
                               string query = $"UPDATE {this.TableName} SET" +
                               $" secuen_telef = @secuen_telef, telef_telef = @telef_telef, activo_telef = @activo_telef " +
                               $" WHERE codent_telef = @codent_telef;";

                               SqlParameter[] paramsList = [
                                    new("codent_telef", this.Model.codent_telef),
                                    new("secuen_telef", this.Model.secuen_telef),
                                    new("telef_telef", this.Model.telef_telef),
                                    new("activo_telef", this.Model.activo_telef),
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

        public EntityMessage<IEnumerable<TelefonoEntidad>> Guardar(IEnumerable<TelefonoEntidad> dataList, string codigoent)
        {
            string insertQuery = $"INSERT INTO {this.TableName} (codent_telef, secuen_telef, telef_telef, activo_telef) VALUES (@codent_telef, @secuen_telef, @telef_telef, @activo_telef)";
            string deleteQuery = $"DELETE FROM {this.TableName} WHERE codent_telef = @codent_telef";
            var resultMsg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    try
                    {
                        var deleteMsg = ConexionSQL.ExecuteNonQuery(deleteQuery, conn, [new("codent_telef", codigoent)], tran);

                        foreach (var item in dataList)
                        {
                            SqlParameter[] paramters = [
                                new SqlParameter("codent_telef", codigoent),
                                new SqlParameter("secuen_telef", item.secuen_telef),
                                new SqlParameter("telef_telef", item.telef_telef),
                                new SqlParameter("activo_telef", item.activo_telef)
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

        public EntityMessage<IEnumerable<TelefonoEntidad>> Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE codent_telef = @codent_telef";
            SqlParameter[] parameters =
            [
                new("codent_telef", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                DataTable? data = msg.Entity;
                if (data == null)
                    return new(msg.State, msg.Msg, []);
                if (data.Rows.Count == 0)
                    return new(msg.State, msg.Msg, []);

                List<TelefonoEntidad> dataList = new();
                foreach (DataRow row in data.Rows)
                {
                    var obj = DataManager.DataRowToObject<TelefonoEntidad>(row);
                    if (obj != null)
                        dataList.Add(obj);
                }

                return new(msg.State, msg.Msg, dataList);
            }
            return new(msg.State, msg.Msg, []);
        }

        public EntityMessage<TelefonoEntidad?> Obtener(string codigo, string secuencia)
        {
            string query = $"SELECT * FROM {TableName} WHERE codent_telef = @codent_telef AND secuen_telef = @secuen_telef";
            SqlParameter[] parameters =
            [
                new("codent_telef", codigo),
                new("secuen_telef", secuencia),
            ];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                DataTable? data = msg.Entity;
                if (data == null)
                    return new(msg.State, msg.Msg, null);
                if (data.Rows.Count == 0)
                    return new(msg.State, msg.Msg, null);

                var obj = DataManager.DataRowToObject<TelefonoEntidad>(data.Rows[0]);

                return new(msg.State, msg.Msg, obj);
            }
            return new(msg.State, msg.Msg, null);
        }
    }
}
