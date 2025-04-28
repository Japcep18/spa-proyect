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

namespace Modelos
{
    public class Cliente : DBObject
    {
        public int codent_cli { get; set; }
        public int codtcli_cli { get; set; }
        // Solo de vista
        public string nombre_cliente { get; set; }
        public DateTime feceg_cli { get; set; }
        public bool activo_cli { get; set; }

        public override string ToString()
        {
            return $"{codent_cli} - {nombre_cliente}";
        }
    }
    public class ClienteModel : BaseModel<Cliente>, IModeloSimple<Cliente>
    {
        public string? Codigo
        {
            get => Model?.codent_cli.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.codent_cli.ToString())
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
            get => this.Model?.nombre_cliente;
            set { return; }
        }
        public override string TableName => "Cliente";

        private readonly string SelectQuery;

        public event EventHandler<string?>? CambioModelo;

        public ClienteModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
            this.SelectQuery = $"SELECT *, " +
                $"(SELECT nombre_ent FROM Entidad WHERE codent_cli = codent_ent) AS nombre_cliente " +
                $"FROM {TableName}";
        }

        public override EntityMessage<IEnumerable<Cliente>> CargarDatos()
        {
            string query = $"{this.SelectQuery};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Cliente> rawDataList = DataManager.DataTableToList<Cliente>(msg.Entity);
                this.DataList = rawDataList.Select(cli =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Cliente()
                    {
                        codent_cli = cli.codent_cli,
                        codtcli_cli = cli.codtcli_cli,
                        feceg_cli = cli.feceg_cli,
                        activo_cli = cli.activo_cli,
                        nombre_cliente = cli.nombre_cliente,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Cliente> Guardar()
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
                             string query = $"INSERT INTO {this.TableName} " +
                             $"(codent_cli, codtcli_cli, feceg_cli, activo_cli) " +
                             $"VALUES (@codent_cli, @codtcli_cli, @feceg_cli, @activo_cli);";

                             try
                             {
                                 SqlParameter[] paramsList = [
                                    new("codent_cli", this.Model.codent_cli),
                                    new("codtcli_cli", this.Model.codtcli_cli),
                                    new("feceg_cli", DateTime.Now),
                                    new("activo_cli", this.Model.activo_cli),
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
                                string query = $"UPDATE {this.TableName} SET" +
                                $" codtcli_cli = @codtcli_cli, activo_cli = @activo_cli " +
                                $" WHERE codent_cli = @codent_cli;";

                                SqlParameter[] paramsList = [
                                    new("codent_cli", this.Model.codent_cli),
                                    new("codtcli_cli", this.Model.codtcli_cli),
                                    new("codpue_emp", this.Model.codtcli_cli),
                                    new("activo_cli", this.Model.activo_cli),
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

        public Cliente? Obtener(string codigo)
        {
            string query = $"{SelectQuery} WHERE codent_cli = @codent_cli;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("codent_cli", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Cliente? cliente = DataManager.DataRowToObject<Cliente>(dataTable.Rows[0]);
                        return cliente;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Cliente> ObtenerTodos()
        {
            return this.DataList;
        }
        public override void CargarDatos(Cliente? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            //this.CambioModelo?.Invoke(this, entity?.cod_ser.ToString());

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.codent_cli.ToString();
        }

        public EntityMessage<decimal> ObtenerDescuento()
        {
            return ObtenerDescuento(this.Model?.codent_cli ?? -1);
        }

        public EntityMessage<decimal> ObtenerDescuento(int codcli)
        {
            const string query = $"SELECT DBO.F_OBTENER_DESCUENTO(@codcli)";
            SqlParameter[] parameters = [new("@codcli", codcli)];
            MSSQLRepositorio.Tipos.Message<DataTable> msg = this.conexion.ObtenerDatos(query, parameters);
            if (!msg.State)
                return new(msg.State, msg.Msg, 0);

            if(msg.Entity is null)
                return new(msg.State, msg.Msg, 0);

            decimal valor = 0;
            if (msg.Entity.Rows.Count > 0)
            {
                if (msg.Entity.Rows[0].ItemArray.Length > 0)
                {
                    try
                    {
                        valor = Convert.ToDecimal(msg.Entity.Rows[0][0]);
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            return new(msg.State, msg.Msg, valor);
        }
    }
}
