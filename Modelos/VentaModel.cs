using Microsoft.Data.SqlClient;
using Modelos.Consultables;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using System.Data;

namespace Modelos
{
    public class Venta : DBObject
    {
        public int cod_ven { get; set; }
        public int codcli_ven { get; set; }
        public int codcita_ven { get; set; }
        public decimal monto_ven { get; set; }
        public DateTime fecha_ven { get; set; }
        public decimal total_descuento { get; set; }
        public decimal total_neto { get; set; }

        public string estado_ven { get; set; }

    }

    public class VentaModel : BaseModel<Venta>, IModeloSimple<Venta>
    {
        private CitasModel citasModel = new();
        private GuarderiaModel guarderiaModel = new();
        public override string TableName => "Venta";

        public bool SoloActivosFiltro = false;

        public event EventHandler<string?>? CambioModelo;

        public string? Codigo
        {
            get; set;
        }
        public string? Descripcion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public VentaModel() : base()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Venta>> CargarDatos()
        {
            string query = "SELECT * FROM Venta";
            if (this.SoloActivosFiltro)
            {
                query += " WHERE estado_ven = 'A'";
            }
            SqlParameter[] parameters = [];
            var msg = conexion.ObtenerDatos(query);

            if (msg.State)
            {
                IEnumerable<Venta> rawDataList = DataManager.DataTableToList<Venta>(msg.Entity);
                this.DataList = rawDataList.Select(venta =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Venta()
                    {
                        cod_ven = venta.cod_ven,
                        codcita_ven = venta.codcli_ven,
                        codcli_ven = venta.codcli_ven,
                        fecha_ven = venta.fecha_ven,
                        monto_ven = venta.monto_ven,
                        estado_ven = venta.estado_ven,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Venta> Guardar()
        {
            throw new NotImplementedException();
        }

        public EntityMessage<object?> Guardar(
            Venta venta, Cita cita, IEnumerable<Servicio> servicioList, 
            IEnumerable<Contable<Articulo>> articuloList, IEnumerable<Empleado> personalList, IEnumerable<Guarderia> guarderias)
        {
            // La cita se debe actualizar
            // Solo insertar
            string insertVentaQuery = $"INSERT INTO {this.TableName} " +
                $"(cod_ven, codcli_ven, codcita_ven, monto_ven, fecha_ven, total_descuento, total_neto) " +
                $"VALUES (@cod_ven, @codcli_ven, @codcita_ven, @monto_ven, @fecha_ven, @total_descuento, @total_neto)";

            SqlParameter[] parameters = [
                new("codcli_ven", venta.codcli_ven),
                new("codcita_ven", cita.cod_cita),
                new("monto_ven", venta.monto_ven),
                new("fecha_ven", venta.fecha_ven),
                new("total_descuento", venta.total_descuento),
                new("total_neto", venta.total_neto),
            ];

            if(cita.state != EntityState.Modificado)
            {
                // QUE SE EPLOTE TO COÑO
                cita.state = EntityState.Agregado;
            }

            cita.codecit_cita = 3; // ESTADO FACTURADO

            try
            {
                const string GUARDERIA_TABLA = "Guarderia";
                string insertGuarderiaQuery = $"INSERT INTO {GUARDERIA_TABLA} (codven_guar, secuen_guar, tutor_guar, infante_guar) VALUES (@codven_guar, @secuen_guar, @tutor_guar, @infante_guar)";
                string deleteGuarderiaQuery = $"DELETE FROM {GUARDERIA_TABLA} WHERE codven_guar = @codven_guar";
                var msg = conexion.ExecuteInstructions( (conn, tran) =>
                {
                    int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);

                    parameters = [new("cod_ven", secuencia), .. parameters];
                    ConexionSQL.ExecuteNonQuery(insertVentaQuery, conn, parameters, tran);
                    var citasMsg = this.citasModel.GuardarCita(cita, servicioList, articuloList, personalList);
                    if(!citasMsg.State)
                    {
                        return new(citasMsg.State, citasMsg.Msg, null);
                    }
                    // ----------------------------- GUARDERIA ------------------------------------------
                    ConexionSQL.ExecuteNonQuery(deleteGuarderiaQuery, conn, [new("codven_guar", secuencia)], tran);

                    foreach (var item in guarderias)
                    {
                        SqlParameter[] paramters = [
                            new SqlParameter("codven_guar", secuencia),
                                new SqlParameter("secuen_guar", item.secuen_guar),
                                new SqlParameter("tutor_guar", item.tutor_guar),
                                new SqlParameter("infante_guar", item.infante_guar)
                        ];

                        ConexionSQL.ExecuteNonQuery(insertGuarderiaQuery, conn, paramters, tran);
                    }
                    // ----------------------------------------------------------------------------------

                    tran.Commit();
                    return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, null);
                });

                return new(msg.State, msg.Msg, msg.Entity);
            }
            catch (Exception ex)
            {
                return new(false, ex.Message, null);
            }
        }

        public EntityMessage<object?> FacturarVenta(Venta venta)
        {
            // LOGICA PARA EL UPDATE VENTA SET ESTADO = 'F'
            string query = "UPDATE Venta SET estado_ven = 'F' WHERE cod_ven = @cod_ven";
            SqlParameter[] parameters = [ new("cod_ven", venta.cod_ven) ];

            var msg = this.conexion.ExecuteInstructions((conn, tran) =>
            {
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

            return new(msg.State, msg.Msg, null);
        }

        public IEnumerable<Venta> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public Venta? Obtener(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
