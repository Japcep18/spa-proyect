using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Modelos.Tipos;
using Modelos.Servicios;
using Microsoft.Data.SqlClient;
using System.Data;
using Modelos.Estandard;
using MSSQLRepositorio;

namespace Modelos
{
    public class Entidad : DBObject
    {
        [Required]
        [DisplayName("Código")]
        public int codent_ent { get; set; }
        [Required]
        [DisplayName("Nombre")]
        [StringLength(250, MinimumLength = 3)]
        public string nombre_ent { get; set; }

        [Required]
        [DisplayName("Documento")]
        [StringLength(11, MinimumLength = 11)]
        public string cedula_ent { get; set; }

        [DisplayName("Fecha nacimiento")]
        public DateTime? fecnac_ent { get; set; }

        public int? codgen_ent { get; set; }

        [Required]
        public int? codciud_dir { get; set; }
        [Required]
        public int? codsect_dir { get; set; }

        [Required]
        public int? codmuni_dir {  get; set; }
        [Required]
        public string direccion_dir { get; set; }

        [Required]
        [DisplayName("¿Es una persona?")]
        public bool espersona_ent { get; set; }
        [Required]
        public bool activo_ent { get; set; }

        public override string ToString()
        {
            return $"{codent_ent} - {nombre_ent}";
        }
    }
    public class EntidadModel : BaseModel<Entidad>, IModeloSimple<Entidad>
    {
        public string? Codigo
        {
            get => Model?.codent_ent.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.codent_ent.ToString())
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
                    return this.Model.nombre_ent;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.nombre_ent = value;
            }
        }
        public override string TableName => "Entidad";

        public event EventHandler<string?>? CambioModelo;

        public EntidadModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Entidad>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Entidad> rawDataList = DataManager.DataTableToList<Entidad>(msg.Entity);
                this.DataList = rawDataList.Select(ent =>
                {

                    return new Entidad()
                    {
                        codent_ent = ent.codent_ent,
                        nombre_ent = ent.nombre_ent,
                        cedula_ent = ent.cedula_ent,
                        fecnac_ent = ent.fecnac_ent,
                        codgen_ent = ent.codgen_ent,
                        codciud_dir = ent.codciud_dir,
                        codmuni_dir = ent.codmuni_dir,
                        codsect_dir = ent.codsect_dir,
                        direccion_dir = ent.direccion_dir,
                        espersona_ent = ent.espersona_ent,
                        activo_ent = ent.activo_ent,

                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Entidad> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (codent_ent, nombre_ent, cedula_ent, fecnac_ent, codgen_ent, codciud_dir, codmuni_dir, codsect_dir, direccion_dir, espersona_ent, activo_ent ) " +
                                $"VALUES ( @codent_ent, @nombre_ent, @cedula_ent, @fecnac_ent, @codgen_ent, @codciud_dir, @codmuni_dir, @codsect_dir, @direccion_dir, @espersona_ent, @activo_ent );";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    new("codent_ent", secuencia),
                                    new("nombre_ent", this.Model.nombre_ent.ToUpper()),
                                    new("cedula_ent", this.Model.cedula_ent),
                                    new("fecnac_ent", this.Model.fecnac_ent),
                                    new("codgen_ent", this.Model.codgen_ent),
                                    new("codciud_dir", this.Model.codciud_dir),
                                    new("codmuni_dir", this.Model.codmuni_dir),
                                    new("codsect_dir", this.Model.codsect_dir),
                                    new("direccion_dir", this.Model.direccion_dir),
                                    new("espersona_ent", this.Model.espersona_ent),
                                    new("activo_ent", this.Model.activo_ent),
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
                                string query = $"UPDATE {this.TableName} SET nombre_ent = @nombre_ent, cedula_ent = @cedula_ent, {(this.Model.espersona_ent ? "fecnac_ent = @fecnac_ent," : "")} {(this.Model.espersona_ent ? "codgen_ent = @codgen_ent," : "")} codciud_dir = @codciud_dir, codmuni_dir = @codmuni_dir, codsect_dir = @codsect_dir, direccion_dir = @direccion_dir ,espersona_ent = @espersona_ent, activo_ent = @activo_ent " +
                                    $" WHERE codent_ent = @codent_ent;";

                                SqlParameter[] paramsList = [
                                    new("codent_ent", this.Model.codent_ent),
                                    new("nombre_ent", this.Model.nombre_ent.ToUpper()),
                                    new("cedula_ent", this.Model.cedula_ent),
                                    new("codciud_dir", this.Model.codciud_dir),
                                    new("codmuni_dir", this.Model.codmuni_dir),
                                    new("codsect_dir", this.Model.codsect_dir),
                                    new("direccion_dir", this.Model.direccion_dir),
                                    new("espersona_ent", this.Model.espersona_ent),
                                    new("activo_ent", this.Model.activo_ent),
                                ];
                                if(this.Model.espersona_ent)
                                {
                                    paramsList = [
                                        .. paramsList,
                                    new("codgen_ent", this.Model.codgen_ent),
                                    new("fecnac_ent", this.Model.fecnac_ent),
                                        ];
                                }

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

        public Entidad? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE codent_ent = @codent_ent;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("codent_ent", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Entidad? ent = DataManager.DataRowToObject<Entidad>(dataTable.Rows[0]);
                        return ent;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Entidad> ObtenerTodos()
        {
            return this.DataList;
        }
        public override void CargarDatos(Entidad? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.codent_ent.ToString();
        }
    }
}
