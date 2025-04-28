using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using MSSQLRepositorio.Tipos;
using System.Data;
using System.Text;

namespace Modelos
{
    public class EmailEntidad : DBObject
    {
        public int codent_mail { get; set; }
        public int secuen_mail { get; set; }
        public string email_mail { get; set; }
        public bool activo_mail { get; set; }
    }

    public class EmailEntidadModel : BaseModel<EmailEntidad>
    {
        public override string TableName => "EmailEntidad";

        public EmailEntidadModel() : base()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<EmailEntidad>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName}";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<EmailEntidad> rawDataList = DataManager.DataTableToList<EmailEntidad>(msg.Entity);
                this.DataList = rawDataList.Select(email =>
                {
                    //srv.state = EntityState.Modificado;
                    return new EmailEntidad()
                    {
                        codent_mail = email.codent_mail,
                        secuen_mail = email.secuen_mail,
                        email_mail = email.email_mail,
                        activo_mail = email.activo_mail,
                        state = EntityState.Modificado,
                    };
                });
            }
            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<EmailEntidad> Guardar()
        {
            // Validacion de instancia
            if(this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            switch (this.Model.state)
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                        (conn, tran) =>
                        {
                            string query = $"INSERT INTO {this.TableName} (codent_mail, secuen_mail, email_mail, activo_mail) " +
                            $"VALUES (@codent_mail, @secuen_mail, @email_mail, @activo_mail)";

                            SqlParameter[] paramsList = 
                            [
                                new("codent_mail", this.Model.codent_mail)
                                , new("secuen_mail", this.Model.secuen_mail)
                                , new("email_mail", this.Model.email_mail)
                                , new("activo_mail", this.Model.activo_mail)

                            ];

                            try
                            {
                                int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                                Message<object> valor = new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
                                if(valor.State)
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
                            string query = $"UPDATE {this.TableName} secuen_mail = @secuen_mail, email_mail = @email_mail, activo_mail = @activo_mail) " +
                            $"WHERE codent_mail = @codent_mail";

                            SqlParameter[] paramsList =
                            [
                                new("codent_mail", this.Model.codent_mail)
                                , new("secuen_mail", this.Model.secuen_mail)
                                , new("email_mail", this.Model.email_mail)
                                , new("activo_mail", this.Model.activo_mail)

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
                    return new(updateMsg.State, updateMsg.Msg, this.Model);
                case EntityState.Eliminado:
                    break;
                default:
                    break;
            }

            return null;
        }

        public EntityMessage<IEnumerable<EmailEntidad>> Guardar(IEnumerable<EmailEntidad> dataList, string codigoent)
        {
            string insertQuery = $"INSERT INTO {this.TableName} (codent_mail, secuen_mail, email_mail, activo_mail) VALUES (@codent_mail, @secuen_mail, @email_mail, @activo_mail)";
            string deleteQuery = $"DELETE FROM {this.TableName} WHERE codent_mail = @codent_mail";
            var resultMsg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    try
                    {
                        var deleteMsg = ConexionSQL.ExecuteNonQuery(deleteQuery, conn, [ new("codent_mail", codigoent) ], tran);
                        
                        foreach (var item in dataList)
                        {
                            SqlParameter[] paramters = [
                                new SqlParameter("codent_mail", codigoent),
                                new SqlParameter("secuen_mail", item.secuen_mail),
                                new SqlParameter("email_mail", item.email_mail),
                                new SqlParameter("activo_mail", item.activo_mail)
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

        public EntityMessage<IEnumerable<EmailEntidad>> Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE codent_mail = @codent_mail";
            SqlParameter[] parameters = 
            [
                new("codent_mail", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, parameters);
            if(msg.State)
            {
                DataTable? data = msg.Entity;
                if(data == null)
                    return new(msg.State, msg.Msg, []);
                if (data.Rows.Count == 0)
                    return new(msg.State, msg.Msg, []);

                List<EmailEntidad> dataList = new();
                foreach (DataRow row in data.Rows)
                {
                    var obj = DataManager.DataRowToObject<EmailEntidad>(row);
                    if(obj != null)
                        dataList.Add(obj);
                }

                return new(msg.State, msg.Msg, dataList);
            }
            return new(msg.State, msg.Msg, []);
        }

        public EntityMessage<EmailEntidad?> Obtener(string codigo, string secuencia)
        {
            string query = $"SELECT * FROM {TableName} WHERE codent_mail = @codent_mail AND secuen_mail = @secuen_mail";
            SqlParameter[] parameters =
            [
                new("codent_mail", codigo),
                new("secuen_mail", secuencia),
            ];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                DataTable? data = msg.Entity;
                if (data == null)
                    return new(msg.State, msg.Msg, null);
                if (data.Rows.Count == 0)
                    return new(msg.State, msg.Msg, null);

                var obj = DataManager.DataRowToObject<EmailEntidad>(data.Rows[0]);

                return new(msg.State, msg.Msg, obj);
            }
            return new(msg.State, msg.Msg, null);
        }
    }
}
