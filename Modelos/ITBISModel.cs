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
    public class ITBIS : DBObject
    {
        public decimal valor_itb { get; set; }

        public override string ToString()
        {
            return $"{valor_itb}";
        }
    }

    public class ITBISModel : BaseModel<ITBIS>, IModeloSimple<ITBIS>
    {
        public override string TableName => "Itbis";

        public string? Codigo {
            get => Model?.valor_itb.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.valor_itb.ToString())
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
        public string? Descripcion { get; set; }

        public event EventHandler<string?>? CambioModelo;

        public ITBISModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<ITBIS>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<ITBIS> rawDataList = DataManager.DataTableToList<ITBIS>(msg.Entity);
                this.DataList = rawDataList.Select(itbis =>
                {
                    return new ITBIS()
                    {
                        valor_itb = itbis.valor_itb,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<ITBIS> Guardar()
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
                    string query = $"INSERT INTO {this.TableName} (valor_itb) VALUES (@valor_itb);";

                    // Configurar explícitamente el parámetro como DECIMAL(10,4)
                    SqlParameter param = new SqlParameter("valor_itb", SqlDbType.Decimal);
                    param.Value = this.Model.valor_itb;
                    param.Precision = 10;  // Total de dígitos
                    param.Scale = 4;      // Dígitos decimales

                    try
                    {
                        int affected = ConexionSQL.ExecuteNonQuery(query, conn, new[] { param }, tran);
                        if (affected > 0)
                        {
                            tran.Commit();
                            return new MSSQLRepositorio.Tipos.Message<object>(true, "Valor guardado correctamente", this.Model);
                        }
                        return new MSSQLRepositorio.Tipos.Message<object>(false, "No se pudo guardar el valor", this.Model);
                    }
                    catch (SqlException ex)
                    {
                        tran.Rollback();
                        return new MSSQLRepositorio.Tipos.Message<object>(false, $"Error SQL: {ex.Message}", this.Model);
                    }
                });
                    return new(insertMsg.State, insertMsg.Msg, this.Model);
                //case EntityState.Modificado:
                //    var updateMsg = this.conexion.ExecuteInstructions(
                //        (SqlConnection conn, SqlTransaction tran) =>
                //        {
                //            string query = $"UPDATE {this.TableName} SET descr_uni = @descr_uni " +
                //               $"WHERE cod_uni = @cod_uni";

                //            SqlParameter[] paramsList = [
                //                new("descr_uni", this.Model.descr_uni.ToUpper()),
                //                new("cod_uni", this.Model.cod_uni)
                //            ];
                //            try
                //            {
                //                int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                //                var valor = new MSSQLRepositorio.Tipos.Message<object>(true, "Instrucción Ejecutada", this.Model);
                //                if (valor.State)
                //                {
                //                    tran.Commit();
                //                }
                //                return valor;
                //            }
                //            catch (Exception ex)
                //            {
                //                return new(false, ex.Message, this.Model);
                //            }
                //        }
                //    );
                //    return new(updateMsg.State, updateMsg.Msg, this.Model);
                case EntityState.Eliminado:
                    break;
                default:
                    break;
            }
            return null;
        }

        public ITBIS? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE valor_itb = @valor_itb";
            SqlParameter[] paramsList =
            [
                new SqlParameter("valor_itb", codigo)
            ];
            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        ITBIS? itbis = DataManager.DataRowToObject<ITBIS>(dataTable.Rows[0]);
                        return itbis;
                    }
                }
            }
            return null;
        }
        public override void CargarDatos(ITBIS? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.valor_itb.ToString();
        }

        public IEnumerable<ITBIS> ObtenerTodos()
        {
            return this.DataList;
        }
    }
}