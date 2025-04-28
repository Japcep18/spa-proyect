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
    // Clase a operar, para fines prácticos
    public class Servicio : DBObject
    {
        [Required]
        [DisplayName("Código")]
        public int cod_ser { get; set; }
        [Required]                                              // Requerido (NOT NULL en MS SQL Server)
        [StringLength(maximumLength: 50, MinimumLength = 1)]    // StringLength (Tamaño del NVARCHAR / VARCHAR y CHECK de longitud minima en MS SQL Server)
        [DisplayName("Descripción")]                            // Nombre a mostrar en datagridview o otros controles
        public string desc_ser { get; set; }

        [Required]
        [DisplayName("Precio Base")]
        [Range(0, double.MaxValue)]
        public decimal preciobase_ser { get; set; }
        [DisplayName("Estado")]
        public bool activo_ser { get; set; }

        [DisplayName("Tiempo estimado")]
        public int? estimado_ser { get; set; }
        [DisplayName("¿Es el tiempo apilable?")]
        public bool estapilable_ser { get; set; }
        [DisplayName("Tiempo de recuperación")]
        public int recuperacion_ser { get; set; }
        [DisplayName("El servicio es complemento")]
        public bool? complemento_ser { get; set; }

        public override string ToString()
        {
            return $"{this.cod_ser} - {this.desc_ser}";
        }
    }

    // Modelo: contiene la lógica, reglas y opraciones a seguir
    public class ServicioModel : BaseModel<Servicio>, IModeloSimple<Servicio>
    {
        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.cod_ser.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_ser.ToString())
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
                    return this.Model.desc_ser;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_ser = value;
            }
        }

        public override string TableName => "Servicio";
        private readonly string BaseQuery;

        public int? tipoSalaFiltro = null;

        public event EventHandler<string?>? CambioModelo;

        public ServicioModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
            this.BaseQuery = $"SELECT * FROM {TableName}";
        }

        public override EntityMessage<IEnumerable<Servicio>> CargarDatos()
        {
            SqlParameter[] parameters = [];
            string query = $"{BaseQuery}";
            if(this.tipoSalaFiltro is not null)
            {
                // SELECT * FROM Servicio WHERE EXISTS (SELECT * FROM TipoSalaServicio WHERE codtsal_tssrv = @CODTSAL AND codser_tssrv = cod_ser)
                query += " WHERE EXISTS (SELECT * FROM TipoSalaServicio WHERE codtsal_tssrv = @CODTSAL AND codser_tssrv = cod_ser)";
                parameters = [..parameters, new("CODTSAL", this.tipoSalaFiltro)];
            }
            return this.CargarDatosBase(query, parameters);
        }

        public EntityMessage<IEnumerable<Servicio>> CargarDatos(Cita cita)
        {
            string query = $"{BaseQuery} WHERE EXISTS " +
                $"(SELECT * FROM DetServicioCita AS D WHERE D.cod_ser = Servicio.cod_ser AND cod_cita = @cod_cita)";
            SqlParameter[] parameters = { new("cod_cita", cita.cod_cita) };

            return this.CargarDatosBase(query, parameters);
        }

        private EntityMessage<IEnumerable<Servicio>> CargarDatosBase(string query, SqlParameter[] parameters)
        {
            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Servicio> rawDataList = DataManager.DataTableToList<Servicio>(msg.Entity);
                this.DataList = rawDataList.Select(srv =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Servicio()
                    {
                        cod_ser = srv.cod_ser,
                        desc_ser = srv.desc_ser,
                        preciobase_ser = srv.preciobase_ser,
                        activo_ser = srv.activo_ser,
                        complemento_ser = srv.complemento_ser,
                        estapilable_ser = srv.estapilable_ser,
                        estimado_ser = srv.estimado_ser,
                        recuperacion_ser = srv.recuperacion_ser,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public Servicio? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_ser = @cod_ser;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_ser", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Servicio? serv = DataManager.DataRowToObject<Servicio>(dataTable.Rows[0]);
                        return serv;
                    }
                }
            }
            return null;
        }

        public override EntityMessage<Servicio> Guardar()
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
                            string query = $"INSERT INTO {this.TableName} (cod_ser, desc_ser, preciobase_ser, estimado_ser, estapilable_ser, recuperacion_ser, complemento_ser) " +
                            $"VALUES (@cod, @desc_ser, @preciobase_ser, @estimado_ser, @estapilable_ser, @recuperacion_ser, @complemento_ser);";

                            try
                            {
                                int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);
                                if (secuencia == -1)
                                {
                                    return new(false, Mensajes.Msj_Error_GenerarSecuencia, this.Model);
                                }
                                SqlParameter[] paramsList = [
                                    new("cod", secuencia),
                                    new("preciobase_ser", Model.preciobase_ser),
                                    new("desc_ser", Model.desc_ser.ToUpper()),
                                    new("estimado_ser", Model.estimado_ser), 
                                    new("estapilable_ser", Model.estapilable_ser), 
                                    new("recuperacion_ser", Model.recuperacion_ser), 
                                    new("complemento_ser", Model.complemento_ser)
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
                                string query = $"UPDATE {this.TableName} SET desc_ser = @desc_ser, preciobase_ser = @preciobase_ser, estimado_ser = @estimado_ser, estapilable_ser = @estapilable_ser, recuperacion_ser = @recuperacion_ser, complemento_ser = @" +
                                $"complemento_ser " +
                                $"WHERE cod_ser = @cod_ser";

                                SqlParameter[] paramsList = [
                                    new("desc_ser", this.Model.desc_ser.ToUpper()),
                                    new("preciobase_ser", this.Model.preciobase_ser ),
                                    new("cod_ser", this.Model.cod_ser),
                                    new("estimado_ser", Model.estimado_ser ?? 0),
                                    new("estapilable_ser", Model.estapilable_ser),
                                    new("recuperacion_ser", Model.recuperacion_ser),
                                    new("complemento_ser", Model.complemento_ser ?? false)
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

        public EntityMessage<object?> GuardarArticulos(IEnumerable<Contable<Articulo>> listaArticulos)
        {
            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            const string ServicioArticuloTable = "ServicioArticulo";
            string deleteQuery = $"DELETE {ServicioArticuloTable} WHERE codser_sat = @codser_sat";
            SqlParameter[] deleteParameters = 
            [
                new("codser_sat", this.Model.cod_ser),
            ];

            string insertQuery = $"INSERT INTO {ServicioArticuloTable} (codser_sat, codart_sat, cantidad_sat) VALUES (@codser_sat, @codart_sat, @cantidad_sat);";

            var msg = this.conexion.ExecuteInstructions(
                (conn, tran) =>
                {
                    SqlParameter[] insertParameters;

                    try
                    {
                        ConexionSQL.ExecuteNonQuery(deleteQuery, conn, deleteParameters, tran);

                        foreach (var item in listaArticulos)
                        {
                            insertParameters = [
                                new("codser_sat", this.Model.cod_ser),
                                new("codart_sat", item.Data.cod_art),
                                new("cantidad_sat", item.Cantidad),
                            ];

                            ConexionSQL.ExecuteNonQuery(insertQuery, conn, insertParameters, tran);
                        }

                        tran.Commit();
                        return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, null);
                    }
                    catch (Exception ex)
                    {
                        return new(false, ex.Message, null);
                    }
                });

            return new(msg.State, msg.Msg, null);
        }

        public override void CargarDatos(Servicio? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            //this.CambioModelo?.Invoke(this, entity?.cod_ser.ToString());

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.cod_ser.ToString();
        }

        IEnumerable<Servicio> IModeloSimple<Servicio>.ObtenerTodos()
        {
            return this.DataList;
        }

        public static int ObtenerMinutosDeServicio(Servicio[] servicios)
        {
            int acc = 0;
            foreach(Servicio item in servicios.Where(sv => !sv.estapilable_ser))
            {
                if (acc < item.estimado_ser)
                {
                    acc = item.estimado_ser ?? 0;
                }
            }

            foreach(Servicio item in servicios.Where((sv) => sv.estapilable_ser)) 
            {
                acc += item.estimado_ser ?? 0;
            }

            return acc;
        }

        public DataTable GetDataTable(IEnumerable<Servicio> enumerable)
        {
            throw new NotImplementedException();
        }
    }
}
