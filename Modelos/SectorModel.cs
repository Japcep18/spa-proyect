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
    public class Sector : DBObject
    {
        public int cod_ciud { get; set; }

        public int cod_muni { get; set; }

        public int cod_sect { get; set; }

        [StringLength(300, MinimumLength = 3)]
        public string desc_sect { get; set; }

        public override string ToString()
        {
            return $"{cod_sect} - {desc_sect}";
        }
    }

    public class SectorModel : BaseModel<Sector>, IModeloSimple<Sector>
    {
        
        public string? Codigo
        {
            get => Model?.cod_sect.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_sect.ToString())
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
                    return this.Model.desc_sect;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_sect = value;
            }
        }
        public Municipio? MunicipioFiltro { get; set; } 

        public override string TableName => "Sector";

        public event EventHandler<string?>? CambioModelo;

        public SectorModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Sector>> CargarDatos()
        {
            //{ (this.MunicipioFiltro != null ? "WHERE cod_muni = @cod_muni AND cod_ciud = @cod_ciud " : "")}; "
            string query = $"SELECT * FROM {TableName} {(this.MunicipioFiltro != null ? "WHERE cod_muni = @cod_muni AND cod_ciud = @cod_ciud" : "")};";
            SqlParameter[] parameters = 
                this.MunicipioFiltro != null ? 
                [ new("cod_muni", this.MunicipioFiltro.cod_muni), new("cod_ciud", this.MunicipioFiltro.cod_ciud)] : 
                [];
            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Sector> rawDataList = DataManager.DataTableToList<Sector>(msg.Entity);
                this.DataList = rawDataList.Select(sect =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Sector()
                    {
                        cod_ciud = sect.cod_ciud,
                        cod_muni = sect.cod_muni,
                        cod_sect = sect.cod_sect,
                        desc_sect = sect.desc_sect,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Sector> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_ciud, cod_muni, cod_sect, desc_sect) " +
                                $"VALUES (@cod_ciud, @cod_muni, @cod_sect, @desc_sect);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    new("cod_sect", secuencia),
                                    new("cod_ciud", this.Model.cod_ciud),
                                    new("cod_muni", this.Model.cod_muni),
                                    new("desc_sect", this.Model.desc_sect.ToUpper()),
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
                                string query = $"UPDATE {this.TableName} SET cod_ciud = @cod_ciud, cod_muni = @cod_muni, desc_sect = @desc_sect " +
                                    $" WHERE cod_sect = @cod_sect;";

                                SqlParameter[] paramsList = [
                                    new("cod_ciud", this.Model.cod_ciud),
                                    new("cod_muni", this.Model.cod_muni),
                                    new("cod_sect", this.Model.cod_sect),
                                    new("desc_sect", this.Model.desc_sect.ToUpper()),
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

        public Sector? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_sect = @cod_sect;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_sect", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Sector? sect = DataManager.DataRowToObject<Sector>(dataTable.Rows[0]);
                        return sect;
                    }
                }
            }
            return null;
        }

         IEnumerable<Sector> IModeloSimple<Sector>.ObtenerTodos()
        {
            return this.DataList;
        }
        public override void CargarDatos(Sector? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_sect.ToString();
        }
    }
}
