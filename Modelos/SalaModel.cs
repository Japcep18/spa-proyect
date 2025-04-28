using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Modelos
{
    public class Sala : DBObject
    {
        [Required]
        [DisplayName("Código")]
        public int cod_sala { get; set; }

        [Required]
        [DisplayName("Nombre")]
        [StringLength(250, MinimumLength = 3)]
        public string nombre_sala { get; set; }

        [Required]
        public int codtsal_sala { get; set; }

        [Required]
        public int codesal_sala { get; set; }

        [Required]
        [DisplayName("Permite reservar")]
        public bool permitereservar_sala { get; set; }

        public bool activo_sala { get; set; }

        public override string ToString()
        {
            return $"{cod_sala} - {nombre_sala}";
        }
    }

    public class SalaModel : BaseModel<Sala>, IModeloSimple<Sala>
    {
        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.cod_sala.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_sala.ToString())
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

        // Implementación de IModeloSimple, representa una descripción para poder mostrar
        public string? Descripcion
        {
            get
            {
                if (this.Model != null)
                    return this.Model.nombre_sala;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.nombre_sala = value;
            }
        }

        public bool PermiteReservarFiltro = false;
        public bool SoloActivosFiltro = false;

        public override string TableName => "Sala";

        public event EventHandler<string?>? CambioModelo;

        public SalaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Sala>> CargarDatos()
        {
            SqlParameter[] parameters = [];
            string query = $"SELECT * FROM {TableName}";

            if (this.PermiteReservarFiltro || this.SoloActivosFiltro)
            {
                query += " WHERE ";
                bool first = true;
                if (this.PermiteReservarFiltro)
                {
                    query += "permitereservar_sala = @permitereservar_sala";
                    parameters = [new("permitereservar_sala", this.PermiteReservarFiltro), .. parameters];
                    first = false;
                }

                if (this.SoloActivosFiltro)
                {
                    query += $"{(first ? "" : " AND ")}activo_sala = @activo_sala";
                    parameters = [new("activo_sala", this.SoloActivosFiltro), .. parameters];
                }
            }
            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Sala> rawDataList = DataManager.DataTableToList<Sala>(msg.Entity);
                this.DataList = rawDataList.Select(sala =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Sala()
                    {
                        cod_sala = sala.cod_sala,
                        nombre_sala = sala.nombre_sala,
                        codesal_sala = sala.codesal_sala,
                        codtsal_sala = sala.codtsal_sala,
                        activo_sala = sala.activo_sala,
                        permitereservar_sala = sala.permitereservar_sala,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Sala> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_sala, nombre_sala, codtsal_sala, codesal_sala, permitereservar_sala) " +
                                $"VALUES (@cod_sala, @nombre_sala, @codtsal_sala, @codesal_sala, @permitereservar_sala);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    new("cod_sala", secuencia),
                                    new("nombre_sala", this.Model.nombre_sala.ToUpper()),
                                    new("codtsal_sala", this.Model.codtsal_sala),
                                    new("codesal_sala", this.Model.codesal_sala),
                                    new("permitereservar_sala", this.Model.permitereservar_sala),
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
                                string query = $"UPDATE {this.TableName} SET nombre_sala = @nombre_sala, codtsal_sala = @codtsal_sala, codesal_sala = @codesal_sala, permitereservar_sala = @permitereservar_sala " +
                                    $" WHERE cod_sala = @cod_sala;";

                                SqlParameter[] paramsList = [
                                    new("cod_sala", this.Model.cod_sala),
                                    new("nombre_sala", this.Model.nombre_sala.ToUpper()),
                                    new("codtsal_sala", this.Model.codtsal_sala),
                                    new("codesal_sala", this.Model.codesal_sala),
                                    new("permitereservar_sala", this.Model.permitereservar_sala),
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

        public Sala? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_sala = @cod_sala;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_sala", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Sala? sala = DataManager.DataRowToObject<Sala>(dataTable.Rows[0]);
                        return sala;
                    }
                }
            }
            return null;
        }

        IEnumerable<Sala> IModeloSimple<Sala>.ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(Sala? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_sala.ToString();
        }
    }

}
