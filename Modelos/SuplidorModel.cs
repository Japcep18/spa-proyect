using Microsoft.Data.SqlClient;
using Modelos.Servicios;
using Modelos.Tipos;
using System.Data;

namespace Modelos
{
    public class Suplidor : DBObject
    {
        public int codent_sup { get; set; }
        public string nombre_sup { get; set; }
        public bool activo_sup { get; set; }
    }
    public class SuplidorModel : BaseModel<Suplidor>, IModeloSimple<Suplidor>
    {
        public override string TableName => "Suplidor";

        public string? Codigo
        {
            get => Model?.codent_sup.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.codent_sup.ToString())
                    {
                        var obj = this.Obtener(value);
                        if (obj == null)
                        {
                            this.Model = null;
                            this.Descripcion = null;
                        }
                        else
                        {
                            obj.state = EntityState.Modificado;
                            this.Model = obj;
                            this.Descripcion = obj.ToString();
                        }
                    }
                }
                // Ejecutar evento de que cambio
                this.CambioModelo?.Invoke(this, value);
            }
        }


        public string? Descripcion { get => this.Model?.nombre_sup; set { return; } }

        public event EventHandler<string?>? CambioModelo;

        public SuplidorModel() : base()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Suplidor>> CargarDatos()
        {
            string query = $"SELECT *, (SELECT nombre_ent FROM ENTIDAD WHERE codent_ent = codent_sup) AS nombre_sup FROM {this.TableName}";
            var msg = conexion.ObtenerDatos(query);
            if(msg.State)
            {
                IEnumerable<Suplidor> rawDataList = DataManager.DataTableToList<Suplidor>(msg.Entity);
                this.DataList = rawDataList.Select(srv =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Suplidor()
                    {
                        codent_sup = srv.codent_sup,
                        nombre_sup = srv.nombre_sup,
                        activo_sup = srv.activo_sup,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Suplidor> Guardar()
        {
            throw new NotImplementedException();
        }

        public override void CargarDatos(Suplidor? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            //this.CambioModelo?.Invoke(this, entity?.cod_ser.ToString());

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.codent_sup.ToString();
        }

        public Suplidor? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT *, (SELECT nombre_ent FROM ENTIDAD WHERE codent_ent = codent_sup) AS nombre_sup FROM {TableName} WHERE codent_sup = @codent_sup;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("codent_sup", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        var sup = DataManager.DataRowToObject<Suplidor>(dataTable.Rows[0]);
                        return sup;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Suplidor> ObtenerTodos()
        {
            return this.DataList;
        }
    }
}
