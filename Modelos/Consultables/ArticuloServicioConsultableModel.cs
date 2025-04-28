using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Servicios;
using Modelos.Tipos;

namespace Modelos.Consultables
{
    public class ArticuloServicioConsultable
    {
        [DisplayName("Servicio")]
        public string codser_sat { get; set; }

        [DisplayName("Articulo")]
        public string codart_sat { get; set; }
    }

    public class ArticuloServicioConsultableModel : ServicioArticuloModel, IConsultableModel<ServicioArticulo>
    {
        private ServicioModel servicioModel = new();
        private ArticuloModel articuloModel = new();

        public ArticuloServicioConsultableModel() : base()
        {

        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<ServicioArticulo> data)
        {
            var serviciomsg = servicioModel.CargarDatos();
            var articulomsg = articuloModel.CargarDatos();

            IEnumerable<ArticuloServicioConsultable> transformed = data.Select((ServicioArticulo serart) =>
            {
                string servicio = (serviciomsg  .Entity ?? []).FirstOrDefault(serv => serv.cod_ser == serart.codser_sat)?.ToString() ?? "No encontrado";
                string articulo = (articulomsg.Entity ?? []).FirstOrDefault(art => art.cod_art == serart.codart_sat)?.ToString() ?? "No encontrado";
                ArticuloServicioConsultable articuloServicioConsultable = new ArticuloServicioConsultable()
                {
                    codser_sat = servicio,
                    codart_sat = articulo,

                };
                return articuloServicioConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public ServicioArticulo? RetrieveData(DataRow row)
        {
            return null; // DE MIENTRAS
            ArticuloServicioConsultable? resultado = DataManager.DataRowToObject<ArticuloServicioConsultable>(row);
            if (resultado == null)
                return null;
            //ServicioArticulo? descmemb = this.Obtener(resultado.coddes_dmem.ToString());
            //return descmemb;
        }
    }
}
