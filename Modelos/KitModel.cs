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
    public class Kit : DBObject
    {
        public int cod_kit {  get; set; }
        public string nombre_kit { get; set; }
        public int? cod_mem { get; set; }
        public DateTime fecha_validez { get; set; }
        public bool activo_kit { get; set; }

        public override string ToString()
        {
            return $"{cod_kit} - {nombre_kit}";
        }
    }
    public class KitModel : BaseModel<Kit>, IModeloSimple<Kit>
    {
        public string? Codigo
        {
            get => Model?.cod_kit.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_kit.ToString())
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
                    return this.Model.nombre_kit;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.nombre_kit = value;
            }
        }

        public override string TableName => "Kit";

        public event EventHandler<string?>? CambioModelo;

        public KitModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Kit>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Kit> rawDataList = DataManager.DataTableToList<Kit>(msg.Entity);
                this.DataList = rawDataList.Select(kit =>
                {

                    return new Kit()
                    {
                        cod_kit = kit.cod_kit,
                        nombre_kit = kit.nombre_kit,
                        cod_mem = kit.cod_mem,
                        fecha_validez = kit.fecha_validez,
                        activo_kit = kit.activo_kit,
                       
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Kit> Guardar()
        {
            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }
            switch (this.Model.state)
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                        (conn, tran) => {
                            string query = $"INSERT INTO {this.TableName} (cod_kit, nombre_kit, cod_mem, fecha_validez, activo_kit ) " +
                                $"VALUES ( @cod_kit, @nombre_kit, @cod_mem, @fecha_validez, @activo_kit );";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    new("cod_kit", secuencia),
                                    new("nombre_kit", this.Model.nombre_kit.ToUpper()),
                                    new("cod_mem", this.Model.cod_mem),
                                    new("fecha_validez", this.Model.fecha_validez),
                                    new("activo_kit", this.Model.activo_kit),
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
                                string query = $"UPDATE {this.TableName} SET nombre_kit = @nombre_kit, cod_mem = @cod_mem, fecha_validez = @fecha_validez, activo_kit = @activo_kit " +
                                    $" WHERE cod_kit = @cod_kit;";

                                SqlParameter[] paramsList = [
                                    new("cod_kit", this.Model.cod_kit),
                                    new("nombre_kit", this.Model.nombre_kit.ToUpper()),
                                    new("cod_mem", this.Model.cod_mem),
                                    new("fecha_validez", this.Model.fecha_validez),
                                    new("activo_kit", this.Model.activo_kit),
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

        public Kit? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_kit = @cod_kit;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_kit", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Kit? kit = DataManager.DataRowToObject<Kit>(dataTable.Rows[0]);
                        return kit;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Kit> ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(Kit? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_kit.ToString();
        }
    }
}
