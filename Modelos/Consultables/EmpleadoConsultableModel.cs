using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using System.ComponentModel;
using System.Data;

namespace Modelos.Consultables
{
    public class EmpleadoConsultable
    {
        [DisplayName("Código de persona")]
        public int codent_emp { get; set; }
        [DisplayName("Nombre de persona")]
        public string nombre_empleado { get; set; }
        [DisplayName("Puesto")]
        public string puesto_empleado { get; set; }
        [DisplayName("Sueldo Agregado")]
        public string sueldoagregado_emp { get; set; }
        [DisplayName("Fecha de contratación")]
        public string fechacon_emp { get; set; }
        [DisplayName("Activo")]
        public string activo_emp { get; set; }
    }
    public class EmpleadoConsultableModel : EmpleadoModel, IConsultableModel<Empleado>
    {
        private EntidadModel entidadModel = new();
        private PuestoModel puestoModel = new();

        public EmpleadoConsultableModel() : base()
        {
            
        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Empleado> data)
        {
            var entidadmsg = entidadModel.CargarDatos();
            var puestomsg = puestoModel.CargarDatos();

            IEnumerable<EmpleadoConsultable> transformed = data.Select((Empleado empleado) =>
            {
                string entidad = (entidadmsg.Entity ?? []).FirstOrDefault(ent => ent.codent_ent == empleado.codent_emp)?.nombre_ent ?? "No encontrado";
                string puesto = (puestomsg.Entity ?? []).FirstOrDefault(pue => pue.cod_pue == empleado.codpue_emp)?.ToString() ?? "No encontrado";
                EmpleadoConsultable empleadoConsultable = new()
                {
                    codent_emp = empleado.codent_emp,
                    nombre_empleado = entidad,
                    puesto_empleado = puesto,
                    fechacon_emp = empleado.fechacon_emp.ToString(Formatos.formatoFecha),
                    sueldoagregado_emp = empleado.sueldoagregado_emp.ToString(Formatos.formatoMoneda),
                    activo_emp = Formatos.GetEstadoNombre(empleado.activo_emp),
                };
                return empleadoConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public Empleado? RetrieveData(DataRow row)
        {
            EmpleadoConsultable? resultado = DataManager.DataRowToObject<EmpleadoConsultable>(row);
            if (resultado == null)
                return null;
            Empleado? emp = this.Obtener(resultado.codent_emp.ToString());
            return emp;
        }
    }
}
