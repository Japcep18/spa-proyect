using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Tipos;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Modelos.Servicios;
using System.Data;
using Modelos.Estandard;
using MSSQLRepositorio;

namespace Modelos
{
    public class Puesto : DBObject
    {
        [DisplayName("Código")]
        public int cod_pue { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Descripción")]
        public string descr_pue { get; set; }
        [Required]
        [DisplayName ("Sueldo Base")]
        [Range(0, double.MaxValue)]
        public decimal sueldobase_pue{ get; set; }

        public override string ToString()
        {
            return $"{this.cod_pue} - {this.descr_pue}";
        }
    }

    public class PuestoModel : BaseModel<Puesto>, IModeloSimple<Puesto>
    {
        public string? Codigo
        {
            get => Model?.cod_pue.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_pue.ToString())
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
                    return this.Model.descr_pue;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.descr_pue = value;
            }
        }
        public override string TableName => "Puesto";

        public event EventHandler<string?>? CambioModelo;

        public PuestoModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override void CargarDatos(Puesto? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_pue.ToString();
        }

        public override EntityMessage<IEnumerable<Puesto>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Puesto> rawDataList = DataManager.DataTableToList<Puesto>(msg.Entity);
                this.DataList = rawDataList.Select(pues =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Puesto()
                    {
                        cod_pue = pues.cod_pue,
                        descr_pue = pues.descr_pue,
                        sueldobase_pue = pues.sueldobase_pue,
                        state = EntityState.Modificado,
                    };
                });
            }
            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Puesto> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_pue, descr_pue, sueldobase_pue) VALUES (@cod_pue, @descr_pue, @sueldobase_pue);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }
                                SqlParameter[] paramsList = [
                                    new("cod_pue", secuencia),
                                    new("descr_pue", Model.descr_pue.ToUpper()),
                                    new("sueldobase_pue", Model.sueldobase_pue),
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
                                string query = $"UPDATE {this.TableName} SET descr_pue = @descr_pue, sueldobase_pue = @sueldobase_pue " +
                                $" WHERE cod_pue = @cod_pue";

                                SqlParameter[] paramsList = [
                                    new("descr_pue", this.Model.descr_pue.ToUpper()),
                                    new("sueldobase_pue", this.Model.sueldobase_pue ),
                                    new("cod_pue", this.Model.cod_pue)
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


        public Puesto? Obtener(string codigo)
        {
            string query = $"SELECT * FROM {TableName} WHERE cod_pue = @cod_pue;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_pue", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Puesto? pues = DataManager.DataRowToObject<Puesto>(dataTable.Rows[0]);
                        return pues;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Puesto> ObtenerTodos()
        {
            return this.DataList;
        }

        
    }
}
