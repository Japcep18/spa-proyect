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
    public class TelefonoEntidadConsultable
    {
        [DisplayName("#")]
        public int secuen_telef { get; set; }
        [DisplayName("Correo electrónico")]
        public string telef_telef { get; set; }
        [DisplayName("Estado")]
        public string activo_telef { get; set; }
    }
    public class TelefonoEntidadConsultableModel : TelefonoEntidadModel, IConsultableModel<TelefonoEntidad>
    {
        private Entidad Entidad = new();
        public TelefonoEntidadConsultableModel(Entidad entidad) : base() 
        { 
            Entidad = entidad; 
        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<TelefonoEntidad> data)
        {
            IEnumerable<TelefonoEntidadConsultable> transformed = data.Select((TelefonoEntidad telf) =>
            {
                TelefonoEntidadConsultable empleadoConsultable = new()
                {
                    activo_telef = Formatos.GetEstadoNombre(telf.activo_telef),
                };
                return empleadoConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public TelefonoEntidad? RetrieveData(DataRow row)
        {
            var data = DataManager.DataRowToObject<TelefonoEntidadConsultable>(row);
            if (data == null) return null;

            return this.Obtener(this.Entidad.codent_ent.ToString(), data.secuen_telef.ToString()).Entity;
        }
    }
}
