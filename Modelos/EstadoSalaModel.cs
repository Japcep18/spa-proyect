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
    public class EstadoSala : DBObject
    {
        [DisplayName("Código")]
        public int cod_esal { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Descripción")]
        public string desc_esal { get; set; }

        public override string ToString()
        {
            return $"{cod_esal} - {desc_esal}";
        }
    }

    public class EstadoSalaModel : BaseModel<EstadoSala>, IModeloSimple<EstadoSala>
    {
        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.cod_esal.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_esal.ToString())
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
                    return this.Model.desc_esal;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_esal = value;
            }
        }

        public override string TableName => "EstadoSala";

        public event EventHandler<string?>? CambioModelo;

        public EstadoSalaModel() 
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override void CargarDatos(EstadoSala? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_esal.ToString();
        }

        public override EntityMessage<IEnumerable<EstadoSala>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<EstadoSala> rawDataList = DataManager.DataTableToList<EstadoSala>(msg.Entity);
                this.DataList = rawDataList.Select(esal =>
                {
                    //srv.state = EntityState.Modificado;
                    return new EstadoSala()
                    {
                        cod_esal = esal.cod_esal,
                        desc_esal = esal.desc_esal,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<EstadoSala> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_esal, desc_esal) VALUES (@cod_esal, @desc_esal);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }
                                SqlParameter[] paramsList = [
                                    new("cod_esal", secuencia),
                                    new("desc_esal", Model.desc_esal.ToUpper()),
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
                                string query = $"UPDATE {this.TableName} SET desc_esal = @desc_esal " +
                                    $"WHERE cod_esal = @cod_esal";

                                SqlParameter[] paramsList = [
                                    new("cod_esal", Model.cod_esal),
                                    new("desc_esal", Model.desc_esal.ToUpper()),
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

        public EstadoSala? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_esal = @cod_esal;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_esal", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        EstadoSala? esal = DataManager.DataRowToObject<EstadoSala>(dataTable.Rows[0]);
                        return esal;
                    }
                }
            }
            return null;
        }

        public IEnumerable<EstadoSala> ObtenerTodos()
        {
            return this.DataList;
        }
    }
}
