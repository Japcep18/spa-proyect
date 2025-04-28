using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using System.ComponentModel;
using System.Data;

namespace Modelos.Consultables
{
    public class SalaConsultable
    {
        [DisplayName("Código")]
        public int cod_sala { get; set; }

        [DisplayName("Nombre")]
        public string nombre_sala { get; set; }

        [DisplayName("Tipo de sala")]
        public string tipo_sala { get; set; }

        [DisplayName("Estado de sala")]
        public string estado_sala { get; set; }

        [DisplayName("Permite reservar")]
        public string permitereservar_sala { get; set; }

        [DisplayName("Activo")]
        public string activo_sala { get; set; }
    }

    public class SalaConsultableModel : SalaModel, IConsultableModel<Sala>
    {
        private TipoSalaModel tipoSalaModel = new();
        private EstadoSalaModel estadoSalaModel = new();

        public SalaConsultableModel() : base()
        {

        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Sala> data)
        {
            var tipomsg = tipoSalaModel.CargarDatos();
            var estadomsg = estadoSalaModel.CargarDatos();

            IEnumerable<SalaConsultable> transformed = data.Select((Sala sala) =>
            {
                string tipo = (tipomsg.Entity ?? []).FirstOrDefault(tsal => tsal.cod_tsal == sala.codtsal_sala)?.ToString() ?? "No encontrado";
                string estado = (estadomsg.Entity ?? []).FirstOrDefault(tsal => tsal.cod_esal == sala.codesal_sala)?.ToString() ?? "No encontrado";
                SalaConsultable salaConsultable = new SalaConsultable()
                {
                    cod_sala = sala.cod_sala,
                    nombre_sala = sala.nombre_sala,
                    tipo_sala = tipo,
                    estado_sala = estado,
                    activo_sala = Formatos.GetEstadoNombre(sala.activo_sala),
                    permitereservar_sala = Formatos.GetSiNoNombre(sala.permitereservar_sala),
                };
                return salaConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public Sala? RetrieveData(DataRow row)
        {
            SalaConsultable? resultado = DataManager.DataRowToObject<SalaConsultable>(row);
            if (resultado == null)
                return null;
            Sala? sala = this.Obtener(resultado.cod_sala.ToString());
            return sala;
        }
    }
}
