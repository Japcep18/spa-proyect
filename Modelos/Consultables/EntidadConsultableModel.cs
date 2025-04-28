using Modelos.Tipos;
using System.ComponentModel;
using System.Data;
using Modelos.Estandard;
using Modelos.Servicios;

namespace Modelos.Consultables
{
    public class EntidadConsultable
    {
        [DisplayName("Código")]
        public int codent_ent { get; set; }

        [DisplayName("Nombre")]
        public string nombre_ent { get; set; }

        [DisplayName("Documento")]
        public string cedula_ent { get; set; }

        [DisplayName("Fecha nacimiento")]
        public string fecnac_ent { get; set; }

        [DisplayName("Género")]
        public string genero_entidad { get; set; }

        [DisplayName("Ciudad")]
        public string ciudad_entidad { get; set; }
        [DisplayName("Municipio")]
        public string municipio_entidad { get; set; }
        [DisplayName("Sector")]
        public string sector_entidad { get; set; }
        [DisplayName("Direccion")]
        public string direccion { get; set; }

        [DisplayName("¿Es una persona?")]
        public string espersona_ent { get; set; }
        [DisplayName("¿Está activo?")]
        public string activo_ent { get; set; }
    }
    public class EntidadConsultableModel : EntidadModel, IConsultableModel<Entidad>
    {
        private GeneroModel generoModel = new();
        private MunicipioConsultableModel municipioConsultableModel = new();
        private CiudadModel ciudadModel = new();
        private SectorConsultableModel sectorConsultableModel = new();

        public EntidadConsultableModel() : base()
        {
            
        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Entidad> data)
        {
            var generoMsg = generoModel.CargarDatos();
            var ciudadmsg = ciudadModel.CargarDatos();
            var municipiomsg = municipioConsultableModel.CargarDatos();    
            var sectorMsg = sectorConsultableModel.CargarDatos();


            var transformed = data.Select((ent) =>
            {
                string genero = (generoMsg.Entity ?? []).FirstOrDefault
                    (gen => gen.cod_gen == ent.codgen_ent)?.ToString() ?? "No Asignado";
                string ciudad = (ciudadmsg.Entity ?? []).FirstOrDefault
                    (ciud => ciud.cod_ciud == ent.codciud_dir)?.ToString() ?? "No Asignado";
                string municipio = (municipiomsg.Entity ?? []).FirstOrDefault
                    (muni => muni.cod_muni == ent.codmuni_dir)?.ToString() ?? "No Asignado";
                string sector = (sectorMsg.Entity ?? []).FirstOrDefault
                    (sect => sect.cod_sect == ent.codsect_dir)?.ToString() ?? "No Asignado";

                return new EntidadConsultable()
                {
                    codent_ent = ent.codent_ent,
                    nombre_ent = ent.nombre_ent,
                    cedula_ent = ent.cedula_ent,
                    activo_ent = Formatos.GetEstadoNombre(ent.activo_ent),
                    genero_entidad = genero,
                    ciudad_entidad = ciudad,
                    municipio_entidad = municipio,
                    sector_entidad = sector,
                    direccion = ent.direccion_dir,
                    espersona_ent = Formatos.GetSiNoNombre(ent.espersona_ent),
                    fecnac_ent = ent.fecnac_ent?.ToString(Formatos.formatoFecha) ?? "Sin fecha asignada"
                };
            });

            return DataManager.ToDataTable(transformed);

        }

        public Entidad? RetrieveData(DataRow row)
        {
            EntidadConsultable? resultado = DataManager.DataRowToObject<EntidadConsultable>(row);
            if (resultado == null)
                return null;
            Entidad? ent = this.Obtener(resultado.codent_ent.ToString());
            return ent;
        }
    }
}
