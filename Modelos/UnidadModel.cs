using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public class Unidad : DBObject
    {
        [Required]
        [DisplayName("Codigo")]
        public int cod_uni {  get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [DisplayName("Descripcion")]
        public string descr_uni { get; set; }

        public override string ToString()
        {
            return $"{cod_uni} - {descr_uni}";
        }

    }
    public class UnidadModel : BaseModel<Unidad>, IModeloSimple<Unidad>
    {
        public string? Codigo
        {
            get => Model?.cod_uni.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_uni.ToString())
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
                    return this.Model.descr_uni;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.descr_uni = value;
            }
        }

        public override string TableName => "Unidad";

        public event EventHandler<string?>? CambioModelo;
        public UnidadModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Unidad>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Unidad> rawDataList = DataManager.DataTableToList<Unidad>(msg.Entity);
                this.DataList = rawDataList.Select(uni =>
                {
                    return new Unidad()
                    {
                        cod_uni = uni.cod_uni,
                        descr_uni = uni.descr_uni,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Unidad> Guardar()
        {
            if(this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }
            switch (this.Model.state)
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                        (SqlConnection conn, SqlTransaction tran) =>
                        {
                            string query = $"INSERT INTO {this.TableName} (cod_uni, descr_uni) VALUES (@cod, @descr_uni);";

                            int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                            if (secuencia == -1)
                            {
                                return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                            }
                            SqlParameter[] paramsList = [
                                new("cod", secuencia),
                                new("descr_uni", this.Model.descr_uni.ToUpper()),
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
                        });
                    return new(insertMsg.State, insertMsg.Msg, this.Model);
                case EntityState.Modificado:
                    var updateMsg = this.conexion.ExecuteInstructions(
                        (SqlConnection conn, SqlTransaction tran) =>
                        {
                            string query = $"UPDATE {this.TableName} SET descr_uni = @descr_uni " +
                               $"WHERE cod_uni = @cod_uni";

                            SqlParameter[] paramsList = [
                                new("descr_uni", this.Model.descr_uni.ToUpper()),
                                new("cod_uni", this.Model.cod_uni)
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

        public Unidad? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_uni = @cod_uni";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_uni", codigo)
            ];
            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Unidad? uni = DataManager.DataRowToObject<Unidad>(dataTable.Rows[0]);
                        return uni;
                    }
                }
            }
            return null;
        }
        public override void CargarDatos(Unidad? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_uni.ToString();
        }

        IEnumerable<Unidad> IModeloSimple<Unidad>.ObtenerTodos()
        {
            return this.DataList;
        }

    }
}
