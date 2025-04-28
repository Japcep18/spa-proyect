using System.ComponentModel;
using System.Data;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Modelos.Consultables
{
    public class ClienteConsultable
    {
        [DisplayName("Código de persona")]
        public int codent_cli { get; set; }
        [DisplayName("Nombre de persona")]
        public string nombre_cliente { get; set; }
        [DisplayName("Tipo de cliente")]
        public string tipo_cliente { get; set; }
       
        [DisplayName("Fecha de registro")]
        public string feceg_cli { get; set; }
        [DisplayName("Estado")]
        public string activo_cli { get; set; }
    }
    public class ClienteConsultableModel : ClienteModel, IConsultableModel<Cliente>
    {
        private EntidadModel entidadModel = new();
        private TipoClienteModel tipoClienteModel = new();

        public ClienteConsultableModel() : base()
        {

        }

        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<Cliente> data)
        {
            return DataManager.ToDataTable(this.ObtenerConsultable(data));
        }

        public IEnumerable<ClienteConsultable> ObtenerConsultable(IEnumerable<Cliente> data)
        {
            EntityMessage<IEnumerable<Entidad>> entidadmsg = entidadModel.CargarDatos();
            EntityMessage<IEnumerable<TipoCliente>> tclimsg = tipoClienteModel.CargarDatos();

            IEnumerable<ClienteConsultable> transformed = data.Select((Cliente cliente) =>
            {
                string entidad = (entidadmsg.Entity ?? []).FirstOrDefault(ent => ent.codent_ent == cliente.codent_cli)?.nombre_ent ?? "No encontrado";
                string tipo = (tclimsg.Entity ?? []).FirstOrDefault(tcli => tcli.cod_tcli == cliente.codtcli_cli)?.ToString() ?? "No encontrado";
                ClienteConsultable cLienteConsultable = new()
                {
                    codent_cli = cliente.codent_cli,
                    nombre_cliente = entidad,
                    tipo_cliente = tipo,
                    feceg_cli = cliente.feceg_cli.ToString(Formatos.formatoFecha),
                    activo_cli = Formatos.GetEstadoNombre(cliente.activo_cli),
                };
                return cLienteConsultable;
            });

            return transformed;
        }

        public Cliente? RetrieveData(DataRow row)
        {
            ClienteConsultable? resultado = DataManager.DataRowToObject<ClienteConsultable>(row);
            if (resultado == null)
                return null;
            Cliente? cli = this.Obtener(resultado.codent_cli.ToString());
            return cli;
        }
    }
}
