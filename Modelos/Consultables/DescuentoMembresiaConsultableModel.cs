using System.ComponentModel;
using System.Data;
using Modelos.Servicios;
using Modelos.Tipos;

namespace Modelos.Consultables
{
    public class DescuentoMembresiaConsultable
    {
        [DisplayName("Descuento")]
        public string coddes_dmem { get; set; }

        [DisplayName("Membresia")]
        public string codmem_dmem { get; set; }
    }
    public class DescuentoMembresiaConsultableModel : DescuentoMembresiaModel, IConsultableModel<DescuentoMembresia>
    {
        private DescuentoModel descuentoModel = new();
        private MembresiaModel membresiaModel = new();

        public DescuentoMembresiaConsultableModel() : base()
        {
            
        }
        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<DescuentoMembresia> data)
        {
            var descuentomsg = descuentoModel.CargarDatos();
            var membresiamsg = membresiaModel.CargarDatos();

            IEnumerable<DescuentoMembresiaConsultable> transformed = data.Select((DescuentoMembresia descmemb) =>
            {
                string descuento = (descuentomsg.Entity ?? []).FirstOrDefault(desc => desc.cod_desc == descmemb.coddes_dmem)?.ToString() ?? "No encontrado";
                string membresia = (membresiamsg.Entity ?? []).FirstOrDefault(memb => memb.cod_mem == descmemb.codmem_dmem)?.ToString() ?? "No encontrado";
                DescuentoMembresiaConsultable descuentoMembresiaConsultable = new DescuentoMembresiaConsultable()
                {
                    coddes_dmem = descuento,
                    codmem_dmem = membresia,
                    
                };
                return descuentoMembresiaConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public DescuentoMembresia? RetrieveData(DataRow row)
        {
            return null; // DE MIENTRAS
            DescuentoMembresiaConsultable? resultado = DataManager.DataRowToObject<DescuentoMembresiaConsultable>(row);
            if (resultado == null)
                return null;
            //DescuentoMembresia? descmemb = this.Obtener(resultado.coddes_dmem.ToString());
            //return descmemb;
        }
    }
    
}
