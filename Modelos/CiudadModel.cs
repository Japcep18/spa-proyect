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
    public class Ciudad : DBObject
    {
        [DisplayName("Código")]
        public int cod_ciud { get; set; }
        [DisplayName("Abreviatura")]
        [StringLength(5, MinimumLength = 0)]
        public string Abr_ciud { get; set; }
        [DisplayName("Descripción")]
        [StringLength(300, MinimumLength = 3)]
        public string desc_ciud { get; set; }

        public override string ToString()
        {
            return $"{cod_ciud} - {desc_ciud}";
        }
    }

    public class CiudadModel : BaseModel<Ciudad>, IModeloSimple<Ciudad>
    {
        public override string TableName => "Ciudad";

        public string? Codigo
        {
            get => Model?.cod_ciud.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_ciud.ToString())
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
        public string? Descripcion
        {
            get
            {
                if (this.Model != null)
                    return this.Model.desc_ciud;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_ciud = value;
            }
        }

        public event EventHandler<string?>? CambioModelo;

        public CiudadModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override void CargarDatos(Ciudad? entity)
        {
            if(entity != null)
                entity.state = EntityState.Modificado;
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_ciud.ToString();
        }

        public override EntityMessage<IEnumerable<Ciudad>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Ciudad> rawDataList = DataManager.DataTableToList<Ciudad>(msg.Entity);
                this.DataList = rawDataList.Select(srv =>
                {
                    return new Ciudad()
                    {
                        cod_ciud = srv.cod_ciud,
                        Abr_ciud = srv.Abr_ciud,
                        desc_ciud = srv.desc_ciud,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Ciudad> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_ciud, Abr_ciud, desc_ciud) VALUES (@cod_ciud, @Abr_ciud, @desc_ciud)";
                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramList = [
                                    new ("cod_ciud ", secuencia)
                                    ,new ("Abr_ciud", Model.Abr_ciud.ToUpper())
                                    ,new ("desc_ciud", Model.desc_ciud.ToUpper())
                                ];

                                int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramList, tran);
                                var valor = new MSSQLRepositorio.Tipos.Message<object>(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
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
                        });
                    return new(insertMsg.State, insertMsg.Msg, this.Model);
                case EntityState.Modificado:
                    var updateMsg = this.conexion.ExecuteInstructions(
                        (conn, tran) => {
                            string query = $"UPDATE {this.TableName} SET desc_ciud = @desc_ciud, Abr_ciud = @Abr_ciud WHERE cod_ciud = @cod_ciud;";

                            try
                            {
                                SqlParameter[] paramsList = [
                                    new("cod_ciud", Model.cod_ciud),
                                    new("desc_ciud", Model.desc_ciud.ToUpper()),
                                    new("Abr_ciud", Model.Abr_ciud.ToUpper()),
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
                    return new(updateMsg.State, updateMsg.Msg, this.Model);
                case EntityState.Eliminado:
                    break;
                default:
                    break;
            }

            return null;
        }

        public Ciudad? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_ciud = @cod_ciud;";
            SqlParameter[] paramList =
            [
                new("cod_ciud", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramList);
            if(msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count != 0)
                    {
                        Ciudad? ciudad = DataManager.DataRowToObject<Ciudad>(dataTable.Rows[0]);
                        return ciudad;
                    }
                }
            }
            return null;
        }

        IEnumerable<Ciudad> IModeloSimple<Ciudad>.ObtenerTodos()
        {
            return this.DataList;
        }
    }
}
