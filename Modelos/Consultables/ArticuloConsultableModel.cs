using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Modelos.Consultables
{
    public class ArticuloConsultable
    {
        [DisplayName("Código")]
        public int cod_art { get; set; }
        [DisplayName("Unidad")]
        public string unidad { get; set; }
        [DisplayName("Descripción")]
        public string descripcion_art { get; set; }
        [DisplayName("Precio")]
        public decimal precio_art { get; set; }
        [DisplayName("Afecta Inventario")]
        public string afectainv_art { get; set; }
        [DisplayName("Estado")]
        public string activo_art { get; set; }
        [DisplayName("Itbis")]
        public string valor_itbis { get; set; }
    }

    public class ArticuloConsultableModel : ArticuloModel, IConsultableModel<Articulo>
    {
        private UnidadModel unidadModel = new();
        private ITBISModel itbisModel = new();

        public ArticuloConsultableModel() : base()
        {
            
        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Articulo> data)
        {
            var unidadMsg = unidadModel.CargarDatos();
            var itbismsg = itbisModel.CargarDatos();

            IEnumerable<ArticuloConsultable> transformed = data.Select((Articulo art) =>
            {
                string unidad = (unidadMsg.Entity ?? []).FirstOrDefault(ent => ent.cod_uni == art.coduni_art)?.descr_uni ?? "No encontrada";
                string itbis = (itbismsg.Entity ?? []).FirstOrDefault(itb => itb.valor_itb == art.valor_itbis)?.ToString() ?? "No asignado";
               
                return new ArticuloConsultable()
                {
                    cod_art = art.cod_art,
                    precio_art = art.precio_art,
                    unidad = unidad,
                    descripcion_art = art.descripcion_art,
                    valor_itbis = itbis,
                    afectainv_art = Formatos.GetSiNoNombre(art.afectainv_art),
                    activo_art = Formatos.GetEstadoNombre(art.activo_art),
                };

            });
            return DataManager.ToDataTable(transformed);
        }

        public Articulo? RetrieveData(DataRow row)
        {
            var resultado = DataManager.DataRowToObject<ArticuloConsultable>(row);
            if (resultado == null)
                return null;
            Articulo? art = this.Obtener(resultado.cod_art.ToString());
            return art;
        }
    }
}
