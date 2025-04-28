using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{

    public class Genero : DBObject
    {
        [DisplayName("Código")]
        public int cod_gen { get; set; }
        [DisplayName("Descripción")]
        [StringLength(25, MinimumLength = 2)]
        public string desc_gen { get; set; }

        public override string ToString()
        {
            return $"{this.cod_gen} - {this.desc_gen}";
        }
    }


    public class GeneroModel : BaseModel<Genero>, IModeloSimple<Genero>
    {
        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.cod_gen.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_gen.ToString())
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
                    return this.Model.desc_gen;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_gen = value;
            }
        }
        public override string TableName => "Genero";

        public event EventHandler<string?>? CambioModelo;

        public GeneroModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Genero>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Genero> rawDataList = DataManager.DataTableToList<Genero>(msg.Entity);
                this.DataList = rawDataList.Select(gen =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Genero()
                    {
                        cod_gen = gen.cod_gen,
                        desc_gen = gen.desc_gen,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override void CargarDatos(Genero? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.cod_gen.ToString();
        }

        public override EntityMessage<Genero> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_gen, desc_gen) VALUES (@cod, @desc_gen);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }
                                SqlParameter[] paramsList = [
                                    new("cod", secuencia),
                                    new("desc_gen", Model.desc_gen.ToUpper()),
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
                                string query = $"UPDATE {this.TableName} SET desc_gen = @desc_gen " +
                                $"WHERE cod_gen = @cod_gen";

                                SqlParameter[] paramsList = [
                                    new("desc_gen", this.Model.desc_gen.ToUpper()),
                                    new("cod_gen", this.Model.cod_gen)
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

        public Genero? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_gen = @cod_gen;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_gen", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Genero? gen = DataManager.DataRowToObject<Genero>(dataTable.Rows[0]);
                        return gen;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Genero> ObtenerTodos()
        {
            return this.DataList;
        }
    }
}
