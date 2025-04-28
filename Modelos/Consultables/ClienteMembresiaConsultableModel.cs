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
    public class ClienteMembresiaConsultable
    {
        [DisplayName("Cliente")]
        public string codcli_cmem { get; set; }

        [DisplayName("Membresia")]
        public string codmem_cmem { get; set; }
    }
    public class ClienteMembresiaConsultableModel : ClienteMembresiaModel, IConsultableModel<ClienteMembresia>
    {
        private ClienteModel clienteModel = new();
        private MembresiaModel membresiaModel = new();

        public ClienteMembresiaConsultableModel() : base()
        {

        }
        public DataTable GetDataTable()
        {
            return this.GetDataTable(this.DataList);
        }

        public DataTable GetDataTable(IEnumerable<ClienteMembresia> data)
        {
            var clientemsg = clienteModel.CargarDatos();
            var membresiamsg = membresiaModel.CargarDatos();

            IEnumerable<ClienteMembresiaConsultable> transformed = data.Select((ClienteMembresia climem) =>
            {
                string cliente = (clientemsg.Entity ?? []).FirstOrDefault(cli => cli.codent_cli == climem.codcli_cmem)?.ToString() ?? "No encontrado";
                string membresia = (membresiamsg.Entity ?? []).FirstOrDefault(memb => memb.cod_mem == climem.codmem_cmem)?.ToString() ?? "No encontrado";
                ClienteMembresiaConsultable clienteMembresiaConsultable = new ClienteMembresiaConsultable()
                {
                    codcli_cmem = cliente,
                    codmem_cmem = membresia,

                };
                return clienteMembresiaConsultable;
            });
            return DataManager.ToDataTable(transformed);
        }

        public ClienteMembresia? RetrieveData(DataRow row)
        {
            return null; // DE MIENTRAS
            ClienteMembresiaConsultable? resultado = DataManager.DataRowToObject<ClienteMembresiaConsultable>(row);
            if (resultado == null)
                return null;
        }

    }
}
