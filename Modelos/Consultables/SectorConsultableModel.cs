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
    public class SectorConsultable
    {
        [DisplayName("Ciudad")]
        public string cod_ciud { get; set; }

        [DisplayName("Municipio")]
        public string cod_muni { get; set; }

        [DisplayName("Código")]
        public int cod_sect { get; set; }

        [DisplayName("Descripcion")]
        public string desc_sect { get; set; }
    }
    public class SectorConsultableModel : SectorModel, IConsultableModel<Sector>
    {
        private CiudadModel ciudadModel = new();
        private MunicipioConsultableModel municipioConsultableMode = new();

        public SectorConsultableModel() : base()
        {
            
        }


        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Sector> data)
        {
            var ciudadmsg = ciudadModel.CargarDatos();
            var municipiomsg = municipioConsultableMode.CargarDatos();

            var transformed = data.Select((sect) =>
            {
                string ciudad = (ciudadmsg.Entity ?? []).FirstOrDefault
                     (ciud => ciud.cod_ciud == sect.cod_ciud)?.ToString() ?? "No Asignado";
                string municipio = (municipiomsg.Entity ?? []).FirstOrDefault
                    (muni => muni.cod_muni == sect.cod_muni)?.ToString() ?? "No Asignado";

                return new SectorConsultable()
                {
                    cod_sect = sect.cod_sect,
                    cod_ciud = ciudad,
                    cod_muni = municipio,
                    desc_sect = sect.desc_sect,
                };
            });
            return DataManager.ToDataTable(transformed);
        }

        public Sector? RetrieveData(DataRow row)
        {
            SectorConsultable? resultado = DataManager.DataRowToObject<SectorConsultable>(row);
            if (resultado == null)
                return null;
            Sector? sect = this.Obtener(resultado.cod_sect.ToString());
            return sect;
        }
    }
    
}
