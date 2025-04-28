using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using System.ComponentModel;
using System.Data;

namespace Modelos.Consultables
{
    public class UsuarioConsultable
    {
        [DisplayName("Código")]
        public int cod_usr { get; set; }
        [DisplayName("Empleado")]
        public string empleado_usr { get; set; }
        [DisplayName("Usuario")]
        public string username { get; set; }
        [DisplayName("Perfil")]
        public string perfil_usr { get; set; }
        [DisplayName("Activo")]
        public string activo_usr { get; set; }
    }

    public class UsuarioConsultableModel : UsuarioModel, IConsultableModel<Usuario>
    {
        private PerfilModel perfilModel = new();
        private EmpleadoConsultableModel empleadoConsultableModel = new();
        private EntidadModel entidadModel = new();

        public UsuarioConsultableModel() : base()
        {
        
        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Usuario> data)
        {
            var perfmsg = perfilModel.CargarDatos();
            var empleadomsg = empleadoConsultableModel.CargarDatos();
            var entidadmsg = entidadModel.CargarDatos();

            var transformed = data.Select( (usr) =>
            {
                var temp_ent = (empleadomsg.Entity ?? []).
                            FirstOrDefault(emp => emp.codent_emp == usr.codemp_usr)?.codent_emp;
                string empleado = temp_ent != null ? (entidadmsg.Entity ?? []).FirstOrDefault( ent =>
                         temp_ent == ent.codent_ent
                    )?.ToString() ?? "No Asignado" : "No Asignado";
                string perfil = (perfmsg.Entity ?? []).FirstOrDefault
                    (per => per.cod_perf == usr.codperf_usr)?.ToString() ?? "No Asignado";

                return new UsuarioConsultable()
                {
                    cod_usr = usr.cod_usr,
                    empleado_usr = empleado,
                    perfil_usr = perfil,
                    username = usr.username,
                    activo_usr = Formatos.GetSiNoNombre(usr.activo_usr),
                };
            } );

            return DataManager.ToDataTable( transformed );
        }

        public Usuario? RetrieveData(DataRow row)
        {
            UsuarioConsultable? resultado = DataManager.DataRowToObject<UsuarioConsultable>(row);
            if (resultado == null)
                return null;
            Usuario? ent = this.Obtener(resultado.cod_usr.ToString());
            return ent;
        }
    }
}
