using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Tipos;
using Microsoft.Data.SqlClient;
using Modelos.Servicios;
using System.Data;
using Modelos.Estandard;
using MSSQLRepositorio;

namespace Modelos
{
    public class Membresia : DBObject
    {
        [Required]
        [DisplayName("Código")]
        public int cod_mem { get; set; }
        [Required]
        [DisplayName("Nombre")]
        [StringLength(250, MinimumLength = 3)]
        public string nombre_mem { get; set; }

        [Required]
        [DisplayName("Descripcion")]
        [StringLength(100, MinimumLength = 3)]
        public string descripcion_mem { get; set; }

        [Required]
        [DisplayName("Fecha de inicio")]
        public DateTime fechainicio_mem { get; set; }

        [DisplayName("Fecha final")]
        public DateTime fechafin_mem { get; set; }

        [Required]
        [DisplayName("Precio de membresia")]
        [Range(0, double.MaxValue)]
        public decimal precio_mem { get; set; }
        public bool activo_mem { get; set; }

        public override string ToString()
        {
            return $"{cod_mem} - {nombre_mem}";
        }
    }

    public class MembresiaModel : BaseModel<Membresia>, IModeloSimple<Membresia>
    {
        public string? Codigo
        {
            get => Model?.cod_mem.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_mem.ToString())
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
                // Ejecutar evento de que cambio
                this.CambioModelo?.Invoke(this, value);
            }
        }
        public string? Nombre
        {
            get
            {
                if (this.Model != null)
                    return this.Model.nombre_mem;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.nombre_mem = value;
            }
        }

        public string? Descripcion
        {
            get
            {
                if (this.Model != null)
                    return this.Model.descripcion_mem;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.descripcion_mem = value;
            }
        }

        public override string TableName => "Membresia";

        public event EventHandler<string?>? CambioModelo;

        public MembresiaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Membresia>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Membresia> rawDataList = DataManager.DataTableToList<Membresia>(msg.Entity);
                this.DataList = rawDataList.Select(memb =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Membresia()
                    {
                        cod_mem = memb.cod_mem,
                        nombre_mem = memb.nombre_mem,
                        descripcion_mem = memb.descripcion_mem,
                        fechainicio_mem = memb.fechainicio_mem,
                        fechafin_mem = memb.fechafin_mem,  
                        precio_mem = memb.precio_mem,  
                        activo_mem = memb.activo_mem, 
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }


        public override EntityMessage<Membresia> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_mem, nombre_mem, descripcion_mem, fechainicio_mem, fechafin_mem, precio_mem, activo_mem) " +
                                  $"VALUES (@cod_mem, @nombre_mem, @descripcion_mem, @fechainicio_mem, @fechafin_mem, @precio_mem, @activo_mem);";
                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    new("cod_mem", secuencia),
                                    new("nombre_mem", this.Model.nombre_mem.ToUpper()),
                                    new("descripcion_mem", this.Model.descripcion_mem.ToUpper()),
                                    new("fechainicio_mem", this.Model.fechainicio_mem),
                                    new("fechafin_mem", this.Model.fechafin_mem),
                                    new("precio_mem", this.Model.precio_mem),
                                    new("activo_mem", this.Model.activo_mem),
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
                                string query = $"UPDATE {this.TableName} SET nombre_mem = @nombre_mem, descripcion_mem = @descripcion_mem, fechainicio_mem = @fechainicio_mem, fechafin_mem = @fechafin_mem, precio_mem = @precio_mem, activo_mem = activo_mem " +
                                    $" WHERE cod_mem = @cod_mem ;";

                                SqlParameter[] paramsList = [
                                    new("cod_mem", this.Model.cod_mem),
                                    new("nombre_mem", this.Model.nombre_mem.ToUpper()),
                                    new("descripcion_mem", this.Model.descripcion_mem.ToUpper()),
                                    new("fechainicio_mem", this.Model.fechainicio_mem),
                                    new("fechafin_mem", this.Model.fechafin_mem),
                                    new("precio_mem", this.Model.precio_mem),
                                    new("activo_mem", this.Model.activo_mem),
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


        public Membresia? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_mem = @cod_mem;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_mem", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Membresia? memb = DataManager.DataRowToObject<Membresia>(dataTable.Rows[0]);
                        return memb;
                    }
                }
            }
            return null;
        }
        public IEnumerable<Membresia> ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(Membresia? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_mem.ToString();
        }

    }
}
