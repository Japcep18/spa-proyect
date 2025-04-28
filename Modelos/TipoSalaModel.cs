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
    public class TipoSala : DBObject
    {
        [DisplayName("Código")]
        public int cod_tsal { get; set; }
        [DisplayName("Nombre")]
        [StringLength(250, MinimumLength = 3)]
        public string nombre_tsal { get; set; }

        public override string ToString()
        {
            return $"{cod_tsal} - {nombre_tsal}";
        }
    }

    public class TipoSalaModel : BaseModel<TipoSala>, IModeloSimple<TipoSala>
    {
        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.cod_tsal.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_tsal.ToString())
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
                    return this.Model.nombre_tsal;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.nombre_tsal = value;
            }
        }

        public override string TableName => "TipoSala";

        public TipoSalaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public event EventHandler<string?>? CambioModelo;

        public override EntityMessage<IEnumerable<TipoSala>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<TipoSala> rawDataList = DataManager.DataTableToList<TipoSala>(msg.Entity);
                this.DataList = rawDataList.Select(esal =>
                {
                    //srv.state = EntityState.Modificado;
                    return new TipoSala()
                    {
                        cod_tsal = esal.cod_tsal,
                        nombre_tsal = esal.nombre_tsal,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override void CargarDatos(TipoSala? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.cod_tsal.ToString();
        }

        public override EntityMessage<TipoSala> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_tsal, nombre_tsal) VALUES (@cod, @nombre_tsal);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }
                                SqlParameter[] paramsList = [
                                    new("cod", secuencia),
                                    new("nombre_tsal", Model.nombre_tsal.ToUpper()),
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
                                string query = $"UPDATE {this.TableName} SET nombre_tsal = @nombre_tsal " +
                                $"WHERE cod_tsal = @cod_tsal";

                                SqlParameter[] paramsList = [
                                    new("nombre_tsal", this.Model.nombre_tsal.ToUpper()),
                                    new("cod_tsal", this.Model.cod_tsal)
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

        public TipoSala? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_tsal = @cod_tsal;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_tsal", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        TipoSala? tsal = DataManager.DataRowToObject<TipoSala>(dataTable.Rows[0]);
                        return tsal;
                    }
                }
            }
            return null;
        }

        IEnumerable<TipoSala> IModeloSimple<TipoSala>.ObtenerTodos()
        {
            return this.DataList;
        }
    }
}
