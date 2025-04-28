using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using System.ComponentModel;
using System.Data;

namespace Modelos.Consultables
{
    public class CitaConsultable
    {
        [DisplayName("Código")]
        public int cod_cita { get; set; }
        [DisplayName("Cliente")]
        public string cliente_cita { get; set; }
        [DisplayName("Sala")]
        public string sala_cita { get; set; }
        [DisplayName("Fecha")]
        public string fecha_cita { get; set; }
        [DisplayName("Observaciones")]
        public string observaciones { get; set; }
        [DisplayName("Estado")]
        public string estado_cita { get; set; }
    }

    public class CitaConsultableModel : CitasModel, IConsultableModel<Cita>
    {
        private SalaModel salaModel = new();
        private ClienteModel clienteModel = new();
        private EstadoCitaModel estadoCitaModel = new();

        public CitaConsultableModel() : base()
        {
            
        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Cita> data)
        {
            IEnumerable<Cliente> clienteData = clienteModel.CargarDatos().Entity ?? [];
            IEnumerable<EstadoCita> estadoCitaData = estadoCitaModel.CargarDatos().Entity ?? [];
            IEnumerable<Sala> salaData = salaModel.CargarDatos().Entity ?? [];
            const string NO_ENCONTRADO = "No encontrado";

            IEnumerable<CitaConsultable> transformed = data.Select((cita) =>
            {
                string cliente = clienteData.FirstOrDefault(cli => cli.codent_cli == cita.codcli_cita)?.nombre_cliente ?? NO_ENCONTRADO;
                string estado = estadoCitaData.FirstOrDefault(est => est.cod_ecit == cita.codecit_cita)?.desc_ecit ?? NO_ENCONTRADO;
                string sala = salaData.FirstOrDefault(sal => sal.cod_sala == cita.codsala_cita)?.nombre_sala ?? NO_ENCONTRADO;

                return new CitaConsultable()
                {
                    cod_cita = cita.cod_cita,
                    cliente_cita = cliente,
                    estado_cita = estado,
                    sala_cita = sala,
                    fecha_cita = cita.fecha_cita.ToString(Formatos.formatoFechaHora),
                    observaciones = cita.observaciones,
                };
            });

            return DataManager.ToDataTable(transformed);
        }

        public Cita? RetrieveData(DataRow row)
        {
            CitaConsultable? resultado = DataManager.DataRowToObject<CitaConsultable>(row);
            if (resultado == null)
                return null;
            Cita? cita = this.Obtener(resultado.cod_cita.ToString());
            return cita;
        }
    }
}
