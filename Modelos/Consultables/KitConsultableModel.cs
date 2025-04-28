using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;

namespace Modelos.Consultables
{
    public class KitConsultable
    {
        [DisplayName("Código")]
        public int cod_kit { get; set; }

        [DisplayName("Nombre")]
        public string nombre_kit { get; set; }

        [DisplayName("Membresia")]
        public string cod_mem { get; set; }

        [DisplayName("Fecha validez")]
        public string fecha_validez { get; set; }

        [DisplayName("Activo")]
        public string activo_kit { get; set; }
    }

    public class KitConsultableModel : KitModel, IConsultableModel<Kit>
    {
        private MembresiaModel membresiaModel = new();

        public KitConsultableModel() :base() { }
        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Kit> data)
        {
            var membresiamsg = membresiaModel.CargarDatos();

            var transformed = data.Select((kit) =>
            {
                string membresia = (membresiamsg.Entity ?? []).FirstOrDefault
                    (memb => memb.cod_mem == kit.cod_mem)?.ToString() ?? "No Asignada";


                return new KitConsultable()
                {
                    cod_kit = kit.cod_kit,
                    nombre_kit = kit.nombre_kit,
                    cod_mem = membresia,
                    fecha_validez = kit.fecha_validez.ToString(Formatos.formatoFecha) ?? "Sin fecha asignada",
                    activo_kit = Formatos.GetEstadoNombre(kit.activo_kit),
                };
            });

            return DataManager.ToDataTable(transformed);
        }

        public Kit? RetrieveData(DataRow row)
        {
            KitConsultable? resultado = DataManager.DataRowToObject<KitConsultable>(row);
            if (resultado == null)
                return null;
            Kit? kit = this.Obtener(resultado.cod_mem.ToString());
            return kit;
        }
    }


}
