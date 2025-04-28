using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Modelos
{
    public class Articulo : DBObject
    {
        public int cod_art { get; set; }
        [Required]
        public int coduni_art { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string descripcion_art { get; set; }
        public decimal valor_itbis {  get; set; }
        [Required]
        public decimal precio_art { get; set; }
        public bool afectainv_art { get; set; }
        public decimal cantidadinv_art { get; set; }
        //Sera que debo traer la cantidad desde inventario, es decir, la existencia de ello?
        public bool activo_art { get; set; }

        public override string ToString()
        {
            return $"{cod_art} - {descripcion_art}";
        }
    }

    // Solo para asociarlo con unidad, es una clase pivote
    internal class ArticuloContable : Articulo
    {
        public decimal cantidad { get; set; }       
    }

    public class ArticuloModel : BaseModel<Articulo>, IModeloSimple<Articulo>
    {
        public override string TableName => "Articulo";

        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.cod_art.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_art.ToString())
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
                    return this.Model.descripcion_art;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.descripcion_art = value;
            }
        }
        public ArticuloModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public event EventHandler<string?>? CambioModelo;

        public override EntityMessage<IEnumerable<Articulo>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Articulo> rawDataList = DataManager.DataTableToList<Articulo>(msg.Entity);
                this.DataList = rawDataList.Select(art =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Articulo()
                    {
                        cod_art = art.cod_art,
                        coduni_art = art.coduni_art,
                        afectainv_art = art.afectainv_art,
                        activo_art = art.activo_art,
                        cantidadinv_art = art.cantidadinv_art,
                        precio_art = art.precio_art,
                        descripcion_art = art.descripcion_art,
                        valor_itbis = art.valor_itbis, 
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Articulo> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_art, coduni_art, afectainv_art, activo_art" +
                            //$", cantidadinv_art" +
                            $", precio_art, descripcion_art, valor_itbis)" +
                            $" VALUES (@cod_art, @coduni_art, @afectainv_art, @activo_art, " +
                            //$"@cantidadinv_art, " +
                            $"@precio_art, @descripcion_art, @valor_itbis)";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    //new("cod_art", this.Model.cod_art), 
                                    new("cod_art", secuencia),
                                    new("coduni_art", this.Model.coduni_art),
                                    new("afectainv_art", this.Model.afectainv_art),
                                    new("activo_art", this.Model.activo_art), 
                                    //new("cantidadinv_art", this.Model.cantidadinv_art), 
                                    new("precio_art", this.Model.precio_art),
                                    new("descripcion_art", this.Model.descripcion_art),
                                    new("valor_itbis", this.Model.valor_itbis)
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
                        (conn, tran) =>
                        {
                            string query = $"UPDATE {this.TableName} SET " +
                            $" coduni_art = @coduni_art, afectainv_art = @afectainv_art, activo_art = @activo_art, " +
                            //$"cantidadinv_art = @cantidadinv_art, " +
                            $"precio_art = @precio_art, descripcion_art = @descripcion_art, valor_itbis = @valor_itbis" +
                            $" WHERE cod_art = @cod_art";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }

                                SqlParameter[] paramsList = [
                                    //new("cod_art", this.Model.cod_art), 
                                    new("cod_art", this.Model.cod_art),
                                    new("coduni_art", this.Model.coduni_art),
                                    new("afectainv_art", this.Model.afectainv_art),
                                    new("activo_art", this.Model.activo_art),
                                    //new("cantidadinv_art", this.Model.cantidadinv_art),
                                    new("precio_art", this.Model.precio_art),
                                    new("descripcion_art", this.Model.descripcion_art),
                                    new("valor_itbis", this.Model.valor_itbis)
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
            }

            return null;
        }

        public override void CargarDatos(Articulo? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            this.Codigo = entity?.cod_art.ToString();
        }

        public IEnumerable<Articulo> ObtenerTodos()
        {
            return this.DataList;
        }

        public EntityMessage<IEnumerable<Contable<Articulo>>> CargarArticuloDeServicio(Servicio servicio)
        {
            const string ServicioArticuloTable = "ServicioArticulo";
            string query = $"SELECT *, (SELECT cantidad_sat FROM {ServicioArticuloTable} WHERE codser_sat = @codser_sat AND cod_art = codart_sat) AS cantidad FROM {TableName} WHERE cod_art IN (SELECT codart_sat FROM {ServicioArticuloTable} WHERE codser_sat = @codser_sat) ;";
            SqlParameter[] parameters = [
                new ("codser_sat", servicio.cod_ser),
            ];
            return CargarDatosBase(query, parameters);
        }

        private EntityMessage<IEnumerable<Contable<Articulo>>> CargarDatosBase(string query, SqlParameter[] parameters)
        {
            var msg = conexion.ObtenerDatos(query, parameters);
            IEnumerable<Contable<Articulo>> listaArticulos = [];
            if (msg.State)
            {
                var rawDataList = DataManager.DataTableToList<ArticuloContable>(msg.Entity);
                listaArticulos = rawDataList.Select(art =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Contable<Articulo>()
                    {
                        Cantidad = art.cantidad,
                        Data = new Articulo()
                        {
                            cod_art = art.cod_art,
                            coduni_art = art.coduni_art,
                            afectainv_art = art.afectainv_art,
                            activo_art = art.activo_art,
                            cantidadinv_art = art.cantidadinv_art,
                            precio_art = art.precio_art,
                            descripcion_art = art.descripcion_art,
                            valor_itbis = art.valor_itbis,
                            state = EntityState.Modificado,
                        },
                    };
                });
            }

            return new(msg.State, msg.Msg, listaArticulos);
        }

        public EntityMessage<IEnumerable<Contable<Articulo>>> CargarDatos(Cita selectedData)
        {
            const string ServicioArticuloTable = "ServicioArticulo";
            string query = $"SELECT *, (SELECT cantidad_dac FROM DetArticuloCita WHERE codart_dac = cod_art AND codcita_dac = @codcita_dac) AS cantidad FROM {TableName} " +
                $"WHERE EXISTS " +
                $"(SELECT * FROM DetArticuloCita WHERE codart_dac = cod_art AND codcita_dac = @codcita_dac)";

            SqlParameter[] parameters = [new("codcita_dac", selectedData.cod_cita)];

            return this.CargarDatosBase(query, parameters);
        }

        public Articulo? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_art = @cod_art;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_art", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        var art = DataManager.DataRowToObject<Articulo>(dataTable.Rows[0]);
                        return art;
                    }
                }
            }
            return null;
        }
    }
}
