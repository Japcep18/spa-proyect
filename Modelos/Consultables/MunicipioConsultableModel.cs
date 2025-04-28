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
    internal class MunicipioConsultable
    {
        [DisplayName("Codigo")]
        public int cod_muni { get; set; }

        [DisplayName("Ciudad")]
        public string ciudad { get; set; }

        [DisplayName("Abreviatura")]
        public string Abr_muni { get; set; }

        [DisplayName("Descripcion")]
        public string desc_muni { get; set; }
    }

    public class MunicipioConsultableModel : MunicipioModel, IConsultableModel<Municipio>
    {
        private CiudadModel ciudadModel = new();
        public MunicipioConsultableModel() : base()
        {

        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Municipio> data)
        {
            var ciudmsg = ciudadModel.CargarDatos();

            var transformed = data.Select((muni) =>
            {
                
                string ciudad = (ciudmsg.Entity ?? []).FirstOrDefault
                    (ciud => ciud.cod_ciud == muni.cod_ciud)?.ToString() ?? "No Asignado";

                return new MunicipioConsultable()
                {
                    ciudad = ciudad,
                    cod_muni = muni.cod_muni,
                    Abr_muni = muni.Abr_muni,
                    desc_muni = muni.desc_muni,
                };
            });

            return DataManager.ToDataTable(transformed);
        }

        public Municipio? RetrieveData(DataRow row)
        {
            MunicipioConsultable? resultado = DataManager.DataRowToObject<MunicipioConsultable>(row);
            if (resultado == null)
                return null;
            Municipio? municipio = this.Obtener(resultado.cod_muni.ToString());
            return municipio;
        }
    }

}
