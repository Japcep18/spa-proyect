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
    public class TipoSalaServicioConsultable
    {
        [DisplayName("Tipo de sala")]
        public string codtsal_tssrv { get; set; }

        [DisplayName("Servicio")]
        public string codser_tssrv { get; set; }
    }
    public class TipoSalaServicioConsultableModel : TipoSalaServicioModel, IConsultableModel<TipoSalaServicio>
    {
        private TipoSalaModel tipoSalaModel = new();
        private ServicioModel servicioModel = new();

        public TipoSalaServicioConsultableModel() : base()
        {

        }
        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<TipoSalaServicio> data)
        {
            var tiposalamsg = tipoSalaModel.CargarDatos();
            var serviciomsg = servicioModel.CargarDatos();
            IEnumerable<TipoSalaServicioConsultable> transformed = data.Select((TipoSalaServicio tsalser) =>
            {
                string tiposala = (tiposalamsg.Entity ?? []).FirstOrDefault(tsal => tsal.cod_tsal == tsalser.codtsal_tssrv)?.ToString() ?? "No encontrado";
                string servicio = (serviciomsg.Entity ?? []).FirstOrDefault(ser => ser.cod_ser == tsalser.codser_tssrv)?.ToString() ?? "No encontrado";
                TipoSalaServicioConsultable tipoSalaServicioConsultable = new TipoSalaServicioConsultable()
                {
                    codtsal_tssrv = tiposala,
                    codser_tssrv = servicio,

                };
                return tipoSalaServicioConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public TipoSalaServicio? RetrieveData(DataRow row)
        {
            return null; // DE MIENTRAS
            TipoSalaServicioConsultable? resultado = DataManager.DataRowToObject<TipoSalaServicioConsultable>(row);
            if (resultado == null)
                return null;
        }
    }
}
