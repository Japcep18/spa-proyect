using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public class Compras : DBObject
    {
        public int cod_com { get; set; }
        public int? codsupl_com { get; set; }
        public DateTime fecha_compra { get; set; }
        public decimal total_compra { get; set; }
        public int codinv_com { get; set; }
    }

    public class CompraPivote : Contable<Articulo>
    {
        public decimal Precio { get; set; }
    }

    public class ComprasModel : BaseModel<Compras>
    {

        private InventarioModel inventarioModel = new();
        public override string TableName => "Compra";

        public ComprasModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Compras>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                var rawDataList = DataManager.DataTableToList<Compras>(msg.Entity);
                this.DataList = rawDataList.Select(com =>
                {
                    return new Compras()
                    {
                        cod_com = com.cod_com,
                        codsupl_com = com.codsupl_com,
                        fecha_compra = com.fecha_compra,
                        total_compra = com.total_compra,
                        codinv_com = com.codinv_com,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Compras> Guardar()
        {
            throw new NotImplementedException();
        }

        public EntityMessage<object?> GuardarCompra(Compras compras, IEnumerable<CompraPivote> articuloList)
        {

            string insertHeaderQuery = $"INSERT INTO {TableName} (cod_com, codsupl_com, fecha_compra, total_compra, codinv_com) VALUES " +
              $"(@cod_com, @codsupl_com, GETDATE(), @total_compra, @codinv_com)";

            SqlParameter[] insertHParameters =
             [
                new("codsupl_com", compras.codsupl_com),
                //new("codinv_com", compras.),
                new("total_compra", compras.total_compra)
             ];

            var msg = this.conexion.ExecuteInstructions(
              (conn, tran) =>
              {
                  try
                  {
                      // -- Secuencia                 -- -- --
                      int secuencia = SecuenciaManager.ObtenerSiguiente(this.TableName, conn, tran, true);

                      var msgInv = this.inventarioModel.GuardarInventario(new()
                      {
                          estado_inv = "A",
                          tipmov = "S",
                          total_inv = compras.total_compra,
                          fecha_inv = DateTime.Now,                          
                      },
                      articuloList);

                      if(!msgInv.State || msgInv.Entity is null)
                      {
                          return new(false, "Error al generar el movimiento", null);
                      }

                      // Validar secuencia
                      if (secuencia == -1)
                          return new(false, Mensajes.Msj_Error_GenerarSecuencia, null);

                      // -- Maestro de movimiento de inv          -- -- --
                      ConexionSQL.ExecuteNonQuery(insertHeaderQuery, conn, [new("cod_com", secuencia), new("codinv_com", msgInv.Entity.cod_inv), .. insertHParameters], tran);

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
    }


}
