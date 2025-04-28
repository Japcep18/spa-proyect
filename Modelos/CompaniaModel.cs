using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio.Tipos;
using System.ComponentModel;
using System.Data;

namespace Modelos
{
    public class Compania
    {
        [DisplayName("Código de Compaía")]
        public int codcomp_comp { get; set; }
        public string descr_comp { get; set; }
        public string? dir_comp { get; set; }
        public string? rnc_comp { get; set; }
        public bool estado_comp { get; set; }
    }

    public class CompaniaModel : BaseModel<Compania>
    {
        public override string TableName => "Compania";

        public CompaniaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Compania>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName}";
            Message<DataTable> msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                var list = DataManager.DataTableToList<Compania>(msg.Entity);
                this.DataList = list;
            }
            return new(msg.State, msg.Msg, this.DataList);
        }

        public IEnumerable<Compania> ObtenerCompaniasPorId(int id)
        {
            return this.DataList.Where(comp => comp.codcomp_comp == id);
        }

        public override EntityMessage<Compania> Guardar()
        {
            throw new NotImplementedException();
        }
    }
}
