using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class Invent : DBObject
    {
        [DisplayName("Código")]
        public int cod_inv { get; set; }
        [DisplayName("Fecha")]
        public DateTime fecha_inv { get; set; }
        [DisplayName("Estado")]
        public string estado_inv { get; set; }
        [DisplayName("Tipo de movimiento")]
        public string tipmov {  get; set; }
        [DisplayName("Total")]
        public decimal total_inv { get; set; }
    }
    public class InventarioModel : BaseModel<Invent>
    {
        public override string TableName => "Inventario";

        public InventarioModel() 
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Invent>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                var rawDataList = DataManager.DataTableToList<Invent>(msg.Entity);
                this.DataList = rawDataList.Select(inv =>
                {
                    return new Invent()
                    {
                        cod_inv = inv.cod_inv,
                        fecha_inv = inv.fecha_inv,
                        estado_inv = inv.estado_inv,
                        tipmov = inv.tipmov,
                        total_inv = inv.total_inv,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Invent> Guardar()
        {
            throw new NotImplementedException();
        }

        public EntityMessage<Invent?> GuardarInventario(Invent inventario, IEnumerable<Contable<Articulo>> articuloList)
        {
            const string DetArtiuloInventario = "DetArtiuloInventario";

            string insertHeaderQuery = $"INSERT INTO {TableName} (cod_inv, fecha_inv, total_inv, estado_inv, tipmov) VALUES " +
              $"(@cod_inv, GETDATE(), @total_inv, 'A', @tipmov)";

            SqlParameter[] insertHParameters =
           [
                new("tipmov", inventario.tipmov),
                new("total_inv", inventario.total_inv)
           ];

            string insertDetalleArticuloQuery = $"INSERT INTO {DetArtiuloInventario} (codinv_din, codart_din, cantidad_din, precio_unitario ) VALUES (@codinv_din, @codart_din, @cantidad_din, @precio_unitario)";
            SqlParameter[] insertDetalleArticuloParams;

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

                        // ACTUALIZAR SECUENCIA
                        inventario.cod_inv = secuencia;

                        // -- Maestro de movimiento de inv          -- -- --
                        ConexionSQL.ExecuteNonQuery(insertHeaderQuery, conn, [new("cod_inv", secuencia), .. insertHParameters], tran);

                        // -- Detalle de movmiento de inv              -- -- --
                        foreach (var art in articuloList)
                        {
                            insertDetalleArticuloParams =
                            [
                                new("codinv_din", secuencia),
                                new("codart_din", art.Data.cod_art),
                                new("cantidad_din ", art.Cantidad),
                                new("precio_unitario", art.Data.precio_art),
                            ];

                            ConexionSQL.ExecuteNonQuery(insertDetalleArticuloQuery, conn, insertDetalleArticuloParams, tran);
                        }

                        tran.Commit();
                        return new(true, Mensajes.Msj_Aviso_InstruccionEjecutada, inventario);
                    }
                    catch (Exception ex)
                    {
                        return new(false, ex.Message, null);
                    }
                });
            return new(msg.State, msg.Msg, msg.Entity as Invent);
        }

        //Verificacion de existencia
        public Dictionary<int, decimal> ObtenerExistenciasActuales()
        {
            string query = @"
            SELECT 
                a.cod_art,
                COALESCE(SUM(
                    CASE WHEN i.tipmov = 'E' THEN di.cantidad_din 
                    ELSE -di.cantidad_din END
                ), 0) AS existencia
            FROM Articulo a
            LEFT JOIN DetArtiuloInventario di ON a.cod_art = di.codart_din
            LEFT JOIN Inventario i ON di.codinv_din = i.cod_inv
            GROUP BY a.cod_art";

            var result = new Dictionary<int, decimal>();
            var msg = conexion.ObtenerDatos(query); // Usando tu método existente

            if (msg.State && msg.Entity != null)
            {
                foreach (DataRow row in msg.Entity.Rows)
                {
                    result.Add(
                        Convert.ToInt32(row["cod_art"]),
                        Convert.ToDecimal(row["existencia"])
                    );
                }
            }
            return result;
        }

        public bool ValidarExistencia(int codArticulo, decimal cantidad)
        {
            string query = @"
            SELECT COALESCE(SUM(
                CASE WHEN i.tipmov = 'E' THEN di.cantidad_din 
                ELSE -di.cantidad_din END
            ), 0) AS existencia
            FROM DetArtiuloInventario di
            JOIN Inventario i ON di.codinv_din = i.cod_inv
            WHERE di.codart_din = @codArticulo";

            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@codArticulo", codArticulo)
            };

            var result = conexion.ObtenerDatos(query, parametros.ToArray());

            if (result.State && result.Entity != null && result.Entity.Rows.Count > 0)
            {
                decimal existencia = Convert.ToDecimal(result.Entity.Rows[0]["existencia"]);
                return existencia >= cantidad;
            }

            return false; // Si no hay registros, consideramos que no hay existencia
        }
    }
}
