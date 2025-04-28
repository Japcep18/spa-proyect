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
    //public class GuarderiaConusultable
    //{
    //    [DisplayName("#")]
    //    public int secuen_guar { get; set; }
    //    [DisplayName("Tutor")]
    //    public string tutor_guar { get; set; }
    //    [DisplayName("Infante")]
    //    public string infante_guar { get; set; }
    //}
    //public class GuarderiaConsultableModel : GuarderiaModel, IConsultableModel<Guarderia>
    //{
    //    private Venta venta = new();

    //    public GuarderiaConsultableModel(Venta venta) : base()
    //    {
    //        Venta = venta;
    //    }
    //    public DataTable GetDataTable()
    //    {
    //        return this.GetDataTable(this.DataList);
    //    }

    //    public DataTable GetDataTable(IEnumerable<Guarderia> data)
    //    {
    //        IEnumerable<GuarderiaConusultable> transformed = data.Select((Guarderia guar) =>
    //        {
    //            GuarderiaConusultable guarderiaConusultable = new()
    //            {
    //                activo_telef = Formatos.GetEstadoNombre(telf.activo_telef),
    //            };
    //            return empleadoConsultable;
    //        });
    //        return DataManager.ToDataTable(transformed);
    //    }

    //    public Guarderia? RetrieveData(DataRow row)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
