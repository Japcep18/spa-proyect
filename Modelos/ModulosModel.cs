using Modelos.Servicios;
using Modelos.Tipos;

namespace Modelos
{
    public class Modulo
    {
        public string cod_mod { get; set; }
        public string desc_mod { get; set; }
        public bool activo { get; set; }
        public string icono_mod { get; set; }
    }

    public class ModulosModel : BaseModel<Modulo>
    {
        public override string TableName => "Modulo";

        public ModulosModel()
        {
            DatosConexion connData = new ConfiguracionModel().Model.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Modulo>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName}";
            var result = this.conexion.ObtenerDatos(query);
            if (result.State)
            {
                IEnumerable<Modulo> moduloDataList = DataManager.DataTableToList<Modulo>(result.Entity);
                this.DataList = moduloDataList;
            }

            return new(result.State, result.Msg, this.DataList);
        }

        public override EntityMessage<Modulo> Guardar()
        {
            throw new NotImplementedException();
        }
    }
}
