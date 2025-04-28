using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using System.ComponentModel;
using System.Data;

namespace Modelos.Consultables
{
    public class EmailEntidadConsultable
    {
        [DisplayName("#")]
        public int secuen_mail { get; set; }
        [DisplayName("Correo electrónico")]
        public string email_mail { get; set; }
        [DisplayName("Estado")]
        public string activo_mail { get; set; }
    }

    public class EmailEntidadConsultableModel : EmailEntidadModel, IConsultableModel<EmailEntidad>
    {
        private Entidad Entidad { get; set; }

        public EmailEntidadConsultableModel(Entidad entidad) : base()
        {
            Entidad = entidad;
        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<EmailEntidad> data)
        {
            IEnumerable<EmailEntidadConsultable> transformed = data.Select((EmailEntidad email) =>
            {
                EmailEntidadConsultable empleadoConsultable = new()
                {

                    activo_mail = Formatos.GetEstadoNombre(email.activo_mail),
                };
                return empleadoConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public EmailEntidad? RetrieveData(DataRow row)
        {
            var data = DataManager.DataRowToObject<EmailEntidadConsultable>(row);
            if (data == null) return null;

            return this.Obtener(this.Entidad.codent_ent.ToString(), data.secuen_mail.ToString()).Entity;
        }
    }
}
