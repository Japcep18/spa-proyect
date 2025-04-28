using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using System.Data;

namespace Modelos
{
    public class Cita : DBObject
    {
        public int cod_cita { get; set; }
        public int codcli_cita { get; set; }
        public int codsala_cita { get; set; }
        public DateTime fecha_cita { get; set; }
        public string observaciones { get; set; }
        public int codecit_cita { get; set; }
    }

    public class CitasModel : BaseModel<Cita>
    {
        public bool SoloActivos = false;
        private readonly string SelectQuery;
        public override string TableName => "Cita";

        public CitasModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
            this.SelectQuery = $"SELECT * FROM {TableName}";
        }

        public override EntityMessage<IEnumerable<Cita>> CargarDatos()
        {
            SqlParameter[] parameters = [];
            string query = $"{SelectQuery}";

            if(SoloActivos)
            {
                query += " WHERE codecit_cita = @codecit_cita";
                parameters = [new("codecit_cita", 1), .. parameters];
            }

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                var rawDataList = DataManager.DataTableToList<Cita>(msg.Entity);
                this.DataList = rawDataList.Select(cit =>
                {
                    return new Cita()
                    {
                        cod_cita = cit.cod_cita,
                        codcli_cita = cit.codcli_cita,
                        codecit_cita = cit.codecit_cita,
                        codsala_cita = cit.codsala_cita,
                        //codemp_cita = cit.codemp_cita,
                        observaciones = cit.observaciones,
                        fecha_cita = cit.fecha_cita,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Cita> Guardar()
        {
            throw new NotImplementedException();
        }

        public EntityMessage<object?> GuardarCita(Cita cita, IEnumerable<Servicio> servicioList, IEnumerable<Contable<Articulo>> articuloList, IEnumerable<Empleado> empleadoList)
        {
            const string DetServicioTable = "DetServicioCita";
            const string DetArticuloTable = "DetArticuloCita";
            const string PersonalCitaTable = "PersonalCita";

            switch (cita.state)
            {
                case EntityState.Agregado:
                    {
                        string insertHeaderQuery = $"INSERT INTO {TableName} (cod_cita, codcli_cita, fecha_cita, observaciones, codecit_cita, codsala_cita) VALUES " +
                        $"(@cod_cita, @codcli_cita, @fecha_cita, @observaciones, @codecit_cita, @codsala_cita)";

                        SqlParameter[] insertHParameters =
                        [
                            new("codcli_cita", cita.codcli_cita),
                            new("codsala_cita", cita.codsala_cita),
                            //new("codemp_cita", cita.codemp_cita),
                            new("fecha_cita", cita.fecha_cita),
                            new("observaciones", cita.observaciones),
                            new("codecit_cita", cita.codecit_cita)
                        ];

                        string insertDetalleArticuloQuery = $"INSERT INTO {DetArticuloTable} (codcita_dac, codart_dac, cantidad_dac) VALUES (@codcita_dac, @codart_dac, @cantidad_dac)";
                        string insertDetalleServicioQuery = $"INSERT INTO {DetServicioTable} (cod_cita, cod_ser) VALUES (@cod_cita, @cod_ser)";
                        string insertPersonalQuery = $"INSERT INTO {PersonalCitaTable} (codcita_pci, codemp_pci) VALUES (@codcita_pci, @codemp_pci)";
                        SqlParameter[] insertDetalleArticuloParams;
                        SqlParameter[] insertDetalleServicioParams;
                        SqlParameter[] insertEmpleadoParams;

                        var msg = this.conexion.ExecuteInstructions(
                            (conn, tran) =>
                            {
                                try
                                {
                                    // -- Secuencia                 -- -- --
                                    int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);

                                    // Validar secuencia
                                    if (secuencia == -1)
                                        return new(false, Mensajes.Msj_Error_GenerarSecuencia, null);

                                    // -- Maestro de cita           -- -- --
                                    ConexionSQL.ExecuteNonQuery(insertHeaderQuery, conn, [new("cod_cita", secuencia), .. insertHParameters], tran);

                                    // -- Detalle de servicio       -- -- --
                                    foreach (var serv in servicioList)
                                    {
                                        insertDetalleServicioParams =
                                        [
                                            new("cod_cita", secuencia),
                                            new("cod_ser", serv.cod_ser),
                                        ];

                                        ConexionSQL.ExecuteNonQuery(insertDetalleServicioQuery, conn, insertDetalleServicioParams, tran);
                                    }

                                    // -- Detalle de artículo       -- -- --
                                    foreach (var art in articuloList)
                                    {
                                        insertDetalleArticuloParams =
                                        [
                                            new("codcita_dac", secuencia),
                                            new("codart_dac", art.Data.cod_art),
                                            new("cantidad_dac", art.Cantidad),
                                        ];

                                        ConexionSQL.ExecuteNonQuery(insertDetalleArticuloQuery, conn, insertDetalleArticuloParams, tran);
                                    }

                                    // -- Personal de la cita       -- -- --
                                    foreach (var emp in empleadoList)
                                    {
                                        insertEmpleadoParams =
                                        [
                                            new("codcita_pci", secuencia),
                                            new("codemp_pci", emp.codent_emp),
                                        ];

                                        ConexionSQL.ExecuteNonQuery(insertPersonalQuery, conn, insertEmpleadoParams, tran);
                                    }

                                    tran.Commit();
                                    return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, null);
                                }
                                catch (Exception ex)
                                {
                                    return new(false, ex.Message, ex);
                                }
                            });
                        return new(msg.State, msg.Msg, msg.Entity);
                    }
                case EntityState.Modificado:
                    {
                        string updateHeaderQuery = $"UPDATE {TableName} SET codsala_cita = @codsala_cita, " +
                            $"codcli_cita = @codcli_cita, fecha_cita = @fecha_cita, observaciones = @observaciones, codecit_cita = @codecit_cita " +
                            $" WHERE cod_cita = @cod_cita";

                        SqlParameter[] updateHParameters =
                        [
                            new("cod_cita", cita.cod_cita),
                            new("codcli_cita", cita.codcli_cita),
                            new("codsala_cita", cita.codsala_cita),
                            new("fecha_cita", cita.fecha_cita),
                            new("observaciones", cita.observaciones),
                            new("codecit_cita", cita.codecit_cita)
                        ];

                        string updateDetalleArticuloQuery = $"INSERT INTO {DetArticuloTable} (codcita_dac, codart_dac, cantidad_dac) VALUES (@codcita_dac, @codart_dac, @cantidad_dac)";
                        string updateDetalleServicioQuery = $"INSERT INTO {DetServicioTable} (cod_cita, cod_ser) VALUES (@cod_cita, @cod_ser)";
                        string updatePersonalQuery = $"INSERT INTO {PersonalCitaTable} (codcita_pci, codemp_pci) VALUES (@codcita_pci, @codemp_pci)";

                        string deleteDetalleArticuloQuery = $"DELETE {DetArticuloTable} WHERE codcita_dac = @codcita_dac";
                        string deleteDetalleServicioQuery = $"DELETE {DetServicioTable} WHERE cod_cita = @cod_cita";
                        string deletePersonalQuery = $"DELETE {PersonalCitaTable} WHERE codcita_pci = @codcita_pci";

                        SqlParameter[] deleteDetalleServicioParams =
                        [
                            new("cod_cita", cita.cod_cita)
                        ];
                        SqlParameter[] deleteDetalleArticuloParams =
                        [
                            new("codcita_dac", cita.cod_cita)
                        ];
                        SqlParameter[] deleteDetalleCitaParams =
                        [
                            new("codcita_pci", cita.cod_cita)
                        ];

                        SqlParameter[] updateDetalleArticuloParams;
                        SqlParameter[] updateDetalleServicioParams;
                        SqlParameter[] updateEmpleadoParams;

                        var msg = this.conexion.ExecuteInstructions(
                            (conn, tran) =>
                            {
                                try
                                {
                                    // -- Maestro de cita           -- -- --
                                    ConexionSQL.ExecuteNonQuery(updateHeaderQuery, conn, [.. updateHParameters], tran);

                                    // -- Detalle de servicio       -- -- --
                                    ConexionSQL.ExecuteNonQuery(deleteDetalleServicioQuery, conn, deleteDetalleServicioParams, tran);
                                    foreach (var serv in servicioList)
                                    {
                                        updateDetalleServicioParams =
                                        [
                                            new("cod_cita", cita.cod_cita),
                                            new("cod_ser", serv.cod_ser),
                                        ];

                                        ConexionSQL.ExecuteNonQuery(updateDetalleServicioQuery, conn, updateDetalleServicioParams, tran);
                                    }

                                    // -- Detalle de artículo       -- -- --
                                    ConexionSQL.ExecuteNonQuery(deleteDetalleArticuloQuery, conn, deleteDetalleArticuloParams, tran);
                                    foreach (var art in articuloList)
                                    {
                                        updateDetalleArticuloParams =
                                        [
                                            new("codcita_dac", cita.cod_cita),
                                            new("codart_dac", art.Data.cod_art),
                                            new("cantidad_dac", art.Cantidad),
                                        ];

                                        ConexionSQL.ExecuteNonQuery(updateDetalleArticuloQuery, conn, updateDetalleArticuloParams, tran);
                                    }

                                    // -- Personal de la cita       -- -- --
                                    ConexionSQL.ExecuteNonQuery(deletePersonalQuery, conn, deleteDetalleCitaParams, tran);
                                    foreach (var emp in empleadoList)
                                    {
                                        updateEmpleadoParams =
                                        [
                                            new("codcita_pci", cita.cod_cita),
                                            new("codemp_pci", emp.codent_emp),
                                        ];

                                        ConexionSQL.ExecuteNonQuery(updatePersonalQuery, conn, updateEmpleadoParams, tran);
                                    }

                                    tran.Commit();
                                    return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, null);
                                }
                                catch (Exception ex)
                                {
                                    return new(false, ex.Message, ex);
                                }
                            });
                        return new(msg.State, msg.Msg, msg.Entity);
                    }
                case EntityState.Eliminado:
                    break;
                default:
                    break;
            }
            return null;
        }

        public EntityMessage<decimal> ComprobarArticulo(Articulo articulo)
        {
            return this.ComprobarArticulo(articulo.cod_art);
        }

        public EntityMessage<bool> CalcularDisponibilidadCita(Cita cita, int minutos)
        {
            const string fn_name = "DBO.F_COMPROBAR_CITA_TIEMPO";
            string query = $"SELECT {fn_name}(@FECHA, @MINUTOS, @SALA";
            SqlParameter[] parameters = [
                new("FECHA", cita.fecha_cita), 
                new("MINUTOS", 45), 
                new("SALA", cita.codsala_cita)
            ];

            if(cita.state == EntityState.Agregado)
            {
                query += ", NULL)";
            }
            else
            {
                query += ", @CODCITA)";
                parameters = [ ..parameters, new("CODCITA", cita.cod_cita)];
            }

            var msg = this.conexion.ObtenerDatos(query, parameters);
            if (!msg.State) return new(msg.State, msg.Msg, false);

            bool valor = false;
            if(msg.Entity != null)
            {
                if(msg.Entity.Rows.Count > 0)
                {
                    if (msg.Entity.Rows[0].ItemArray.Length != 0)
                    {
                        try
                        {
                            valor = Convert.ToBoolean(msg.Entity.Rows[0][0]);
                        }
                        catch (Exception)
                        {
                            valor = false;
                        }
                    }
                }
            }

            return new(msg.State, msg.Msg, valor);
        }

        public EntityMessage<bool> CalcularDisponibilidadEmpleado(DateTime fecha, Empleado emp, int? codcita = null)
        {
            // ALTER FUNCTION F_COMPROBAR_EMPLEADO_CITA_TIEMPO(@FECHA DATETIME, @MINUTOS INT, @CODEMP INT,  @CODCITA INT = NULL)
            const string FN_NAME = "DBO.F_COMPROBAR_EMPLEADO_CITA_TIEMPO";
            SqlParameter[] parameters = [
                new("FECHA", fecha),
                new("CODEMP", emp.codent_emp),
                new("MINUTOS", 45),
            ];
            string query = $"SELECT {FN_NAME}(@FECHA, @MINUTOS, @CODEMP, ";
            if(codcita != null)
            {
                query += "@CODCITA";
                parameters = [.. parameters, new("@CODCITA", codcita)];
            } 
            else
            {
                query += "NULL";
            }
            query += ")";

            var msg = this.conexion.ObtenerDatos(query, parameters);
            if (!msg.State) return new(msg.State, msg.Msg, false);

            bool valor = false;
            if (msg.Entity != null)
            {
                if (msg.Entity.Rows.Count > 0)
                {
                    if (msg.Entity.Rows[0].ItemArray.Length != 0)
                    {
                        try
                        {
                            valor = Convert.ToBoolean(msg.Entity.Rows[0][0]);
                        }
                        catch (Exception)
                        {
                            valor = false;
                        }
                    }
                }
            }

            return new(msg.State, msg.Msg, valor);
        }

        public EntityMessage<decimal> ComprobarArticulo(int cod_art)
        {
            const string fn_name = "dbo.F_COMPROBAR_EXISTENCIA_ARTICULO";
            string query = $"SELECT {fn_name}(${cod_art});";
            var msg = this.conexion.ObtenerDatos(query);
            if (!msg.State)
                return new(msg.State, msg.Msg, 0);

            decimal valor;
            // Innecesario pero para validar todas las posibles formas de romper el programa

            if (msg.Entity is null)
            {
                valor = 0;
                return new(msg.State, msg.Msg, 0);
            }

            if (msg.Entity.Rows.Count == 0)
            {
                valor = 0;
            }
            else
            {
                var row = msg.Entity.Rows[0].ItemArray;
                if (row is null)
                {
                    valor = 0;
                }
                else
                {
                    if (row.Length == 0)
                    {
                        valor = 0;
                    }
                    else
                    {
                        if (row[0] is null)
                        {
                            valor = 0;
                        }
                        else
                        {
                            try
                            {
                                valor = Convert.ToDecimal(row[0]);
                            }
                            catch (InvalidCastException)
                            {
                                valor = 0;
                            }
                            catch (Exception)
                            {
                                valor = 0;
                            }
                        }
                    }
                }
            }

            return new(msg.State, msg.Msg, valor);
        }

        public EntityMessage<object?> AnularCita(Cita cita)
        {
            string query = $"UPDATE {this.TableName} " +
                $"SET codecit_cita = @codecit_cita " +
                $"WHERE cod_cita = @cod_cita";
            SqlParameter[] parameters = [new("cod_cita", cita.cod_cita), new("codecit_cita", 2)];

            var msg = this.conexion.ExecuteInstructions((conn, tran) => {
                try
                {
                    ConexionSQL.ExecuteNonQuery(query, conn, parameters, tran);
                    tran.Commit();
                    return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, null);
                } 
                catch (Exception ex)
                {
                    return new(false, ex.Message, null);
                }
            });

            return new(msg.State, msg.Msg, msg.Entity);
        }

        public Cita? Obtener(string codigo)
        {
            string query = $"{SelectQuery} WHERE cod_cita = @cod_cita";
            SqlParameter[] parameters = [new("cod_cita", codigo)];

            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        var cita = DataManager.DataRowToObject<Cita>(dataTable.Rows[0]);
                        return cita;
                    }
                }
            }
            return null;
        }
    }
}
