using Microsoft.Data.SqlClient;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio.Tipos;
using System.Data;

namespace Modelos
{
    public class TipoPrograma
    {
        public int codtip_tprg { get; set; }
        public string desctipo_tprg { get; set; }
        public bool activo_tprg { get; set; }
    }

    public class TipoProgramaModel : BaseModel<TipoPrograma>
    {
        public override string TableName => "TipoPrograma";

        public TipoProgramaModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<TipoPrograma>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName}";
            Message<DataTable> msg = this.conexion.ObtenerDatos(query);
            if (msg.State)
            {
                this.DataList = DataManager.DataTableToList<TipoPrograma>(msg.Entity ?? new DataTable());
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<TipoPrograma> Guardar()
        {
            throw new NotImplementedException();
        }

        public TipoPrograma? Obtener(string codigo)
        {
            if(this.DataList.Count() == 0)
            {
                this.CargarDatos();
            }
            return this.DataList.FirstOrDefault(tprg => tprg.codtip_tprg.ToString() == codigo);

            //string query = $"SELECT * FROM {TableName} WHERE codtip_tprg = @codtip_tprg";

            //SqlParameter[] paramsList = 
            //[
            //    new("codtip_tprg", codigo),
            //];

            //var msg = conexion.ObtenerDatos(query, paramsList);
            //if (msg.State)
            //{
            //    DataTable? dataTable = msg.Entity;
            //    if (dataTable != null)
            //    {
            //        if (dataTable.Rows.Count > 0)
            //        {
            //            TipoPrograma? tprg = DataManager.DataRowToObject<TipoPrograma>(dataTable.Rows[0]);
            //            return tprg;
            //        }
            //    }
            //}
        }

        public TipoPrograma? Obtener(int codigo)
        {
            return this.Obtener(codigo.ToString());
        }
    }
}
