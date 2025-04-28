using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public class Municipio : DBObject
    {
        public int cod_ciud { get; set; }
        public int cod_muni { get; set; }

        [StringLength(5, MinimumLength = 3)]
        public string Abr_muni { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string desc_muni { get; set; }

        public override string ToString()
        {
            return $"{cod_muni} - {desc_muni}";
        }
    }
    public class MunicipioModel : BaseModel<Municipio>, IModeloSimple<Municipio>
    {
        public Ciudad? CiudadFiltro { get; set; }
        public string? Codigo 
        { 
            get => Model?.cod_muni.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_muni.ToString())
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
                    return this.Model.Abr_muni;
                return null;
            }
            set 
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.Abr_muni = value;
            }
        }

        public override string TableName => "Municipio";

        public event EventHandler<string?>? CambioModelo;

        public MunicipioModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Municipio>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName} {(this.CiudadFiltro != null ? "WHERE cod_ciud = @cod_ciud" : "")};";
            SqlParameter[] parameters = this.CiudadFiltro != null ? [ new("cod_ciud", this.CiudadFiltro.cod_ciud) ] : [];
            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Municipio> rawDataList = DataManager.DataTableToList<Municipio>(msg.Entity);
                this.DataList = rawDataList.Select(muni =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Municipio()
                    {
                        cod_ciud = muni.cod_ciud,
                        cod_muni = muni.cod_muni,
                        Abr_muni = muni.Abr_muni,
                        desc_muni = muni.desc_muni,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Municipio> Guardar()
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
                            string querySession = "sp_set_session_context @key = 'usuario_actual', @value = 'JuanPerez';";
                            string query = $"INSERT INTO {this.TableName} (cod_ciud, cod_muni, Abr_muni, desc_muni) " +
                                $"VALUES (@cod_ciud, @cod_muni, @Abr_muni, @desc_muni);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    new("cod_ciud", this.Model.cod_ciud),
                                    new("cod_muni", secuencia),
                                    new("Abr_muni", this.Model.Abr_muni.ToUpper()),
                                    new("desc_muni", this.Model.desc_muni.ToUpper()),
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
                               string query = $"UPDATE {this.TableName} SET cod_ciud = @cod_ciud, Abr_muni = @Abr_muni, desc_muni = @desc_muni " +
                                   $" WHERE cod_muni = @cod_muni;";

                               SqlParameter[] paramsList = [
                                    new("cod_ciud", this.Model.cod_ciud),
                                    new("cod_muni", this.Model.cod_muni),
                                    new("Abr_muni", this.Model.Abr_muni),
                                    new("desc_muni", this.Model.desc_muni),
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

        public Municipio? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_muni = @cod_muni;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_muni", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Municipio? muni = DataManager.DataRowToObject<Municipio>(dataTable.Rows[0]);
                        return muni;
                    }
                }
            }
            return null;
        }

        IEnumerable<Municipio> IModeloSimple<Municipio>.ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(Municipio? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_muni.ToString();
        }
    }
}
