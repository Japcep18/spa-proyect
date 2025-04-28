using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio.Tipos;
using System.Data;

namespace Modelos
{
    public class Programa
    {
        public int cod_prog { get; set; }
        public string codmod_prog { get; set; }
        public int codtprg_prog { get; set; }
        public string nombre_prg { get; set; }
        public string desc_prg { get; set; }
        public int pos_prg { get; set; }
        public bool activo_prg { get; set; }
        public string icono_prg { get; set; }
    }

    public class ProgramaModel : BaseModel<Programa>
    {
        private TipoProgramaModel tipoProgramaModel = new();
        public override string TableName => "Programa";

        public ProgramaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public TipoPrograma? ObtenerTipoPrograma(Programa prg)
        {
            return this.tipoProgramaModel.Obtener(prg.codtprg_prog);
        }

        public TipoPrograma? ObtenerTipoPrograma()
        {
            return this.tipoProgramaModel.Obtener(this.Model?.cod_prog.ToString() ?? "-1");
        }

        public override EntityMessage<IEnumerable<Programa>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName}";
            Message<DataTable> msg = this.conexion.ObtenerDatos(query);
            if (msg.State)
            {
                this.DataList = DataManager.DataTableToList<Programa>(msg.Entity ?? new DataTable());
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Programa> Guardar()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Programa> ObtenerPorModulo(string codmod_mod)
        {
            string query = $" SELECT * FROM {TableName} WHERE codmod_prog = '{codmod_mod}'";
            Message<DataTable> msg = this.conexion.ObtenerDatos(query);
            if (msg.State)
            {
                return DataManager.DataTableToList<Programa>(msg.Entity ?? new DataTable());
            }
            return []; // Arr vacio
        }
    }
}
