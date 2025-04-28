using Microsoft.Data.SqlClient;
using Modelos.Servicios;
using Modelos.Tipos;
using System.Data;

namespace Modelos
{
    public class Perfil : DBObject
    {
        public int cod_perf { get; set; }
        public string desc_per { get; set; }

        public override string ToString()
        {
            return $"{cod_perf} - {desc_per}";
        }
    }

    public class PerfilModel : BaseModel<Perfil>, IModeloSimple<Perfil>
    {
        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.cod_perf.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.cod_perf.ToString())
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

        // Implementación de IModeloSimple, representa una descripción para poder mostrar
        public string? Descripcion
        {
            get
            {
                if (this.Model != null)
                    return this.Model.desc_per;
                return null;
            }
            set
            {
                if (value == null) return;
                if (this.Model != null)
                    this.Model.desc_per = value;
            }
        }

        public override string TableName => "Perfil";

        public event EventHandler<string?>? CambioModelo;

        public PerfilModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
        }

        public override EntityMessage<IEnumerable<Perfil>> CargarDatos()
        {
            string query = $"SELECT * FROM {TableName};";
            var msg = conexion.ObtenerDatos(query);
            if (msg.State)
            {
                IEnumerable<Perfil> rawDataList = DataManager.DataTableToList<Perfil>(msg.Entity);
                this.DataList = rawDataList.Select(perf =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Perfil()
                    {
                        cod_perf = perf.cod_perf,
                        desc_per = perf.desc_per,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public override EntityMessage<Perfil> Guardar()
        {
            throw new NotImplementedException();
        }

        public Perfil? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"SELECT * FROM {TableName} WHERE cod_perf = @cod_perf;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("cod_perf", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Perfil? perf = DataManager.DataRowToObject<Perfil>(dataTable.Rows[0]);
                        return perf;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Perfil> ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(Perfil? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            //this.CambioModelo?.Invoke(this, entity?.cod_ser.ToString());

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.cod_perf.ToString();
        }

    }
}
