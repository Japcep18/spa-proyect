using Microsoft.Data.SqlClient;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;
using System.Data;

namespace Modelos
{
    public class Empleado : DBObject
    {
        public int codent_emp { get; set; }
        public string descripcion { get; set; }
        public int codpue_emp { get; set; }
        public string puesto { get; set; }
        public decimal sueldoagregado_emp { get; set; }
        public DateTime fechacon_emp { get; set; }
        public bool activo_emp { get; set; }

    }

    public class EmpleadoModel : BaseModel<Empleado>, IModeloSimple<Empleado>
    {
        // Implementación de IModeloSimple, representa la clave primaria
        public string? Codigo
        {
            get => Model?.codent_emp.ToString();
            set
            {
                if (value == null)
                {
                    this.Model = null;
                    this.Descripcion = null;
                }
                else
                {
                    if (value != Model?.codent_emp.ToString())
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
            get => this.Model?.descripcion;
            set { return; }
        }

        public override string TableName => "Empleado";

        public event EventHandler<string?>? CambioModelo;

        private readonly string BaseSelect;

        public EmpleadoModel()
        {
            Tipos.DatosConexion connData = new ConfiguracionModel().Model!.Conexion;
            this.conexion = new(connData);
            BaseSelect = $"SELECT *, (SELECT nombre_ent FROM Entidad WHERE codent_emp = codent_ent) AS descripcion, " +
                $"(SELECT descr_pue FROM Puesto WHERE cod_pue = codpue_emp) AS puesto " +
                $"FROM {TableName}";
        }

        public override EntityMessage<IEnumerable<Empleado>> CargarDatos()
        {
            string query = $"{BaseSelect};";
            return CargarData(query, []);
        }

        private EntityMessage<IEnumerable<Empleado>> CargarData(string query, SqlParameter[] parameters)
        {
            var msg = conexion.ObtenerDatos(query, parameters);
            if (msg.State)
            {
                IEnumerable<Empleado> rawDataList = DataManager.DataTableToList<Empleado>(msg.Entity);
                this.DataList = rawDataList.Select(emp =>
                {
                    //srv.state = EntityState.Modificado;
                    return new Empleado()
                    {
                        codent_emp = emp.codent_emp,
                        codpue_emp = emp.codpue_emp,
                        activo_emp = emp.activo_emp,
                        descripcion = emp.descripcion,
                        puesto = emp.puesto,
                        fechacon_emp = emp.fechacon_emp,
                        sueldoagregado_emp = emp.sueldoagregado_emp,
                        state = EntityState.Modificado,
                    };
                });
            }

            return new(msg.State, msg.Msg, this.DataList);
        }

        public EntityMessage<IEnumerable<Empleado>> CargarDatos(Cita selectedData)
        {
            string query = $"{BaseSelect} WHERE EXISTS (SELECT * FROM PersonalCita WHERE codent_emp = codemp_pci AND codcita_pci = @codcita_pci);";
            SqlParameter[] parameters = [ new("codcita_pci", selectedData.cod_cita) ];
            return this.CargarData(query, parameters);
        }

        public override EntityMessage<Empleado> Guardar()
        {
            if (this.Model == null)
            {
                return new(false, Mensajes.Msj_Error_InstanciaNula, null);
            }

            switch (this.Model.state)
            {
                case EntityState.Agregado:
                    var insertMsg = this.conexion.ExecuteInstructions(
                        (SqlConnection conn, SqlTransaction tran) =>
                        {
                            string query = $"INSERT INTO {this.TableName} " +
                            $"(codent_emp, codpue_emp, sueldoagregado_emp, fechacon_emp, activo_emp) " +
                            $"VALUES (@codent_emp, @codpue_emp, @sueldoagregado_emp, @fechacon_emp, @activo_emp);";

                            try
                            {
                                SqlParameter[] paramsList = [
                                    new("codent_emp", this.Model.codent_emp),
                                    new("codpue_emp", this.Model.codpue_emp),
                                    new("sueldoagregado_emp", this.Model.sueldoagregado_emp),
                                    new("fechacon_emp", DateTime.Now),
                                    new("activo_emp", this.Model.activo_emp),
                                ];

                                int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                                var valor = new MSSQLRepositorio.Tipos.Message<object>(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
                                if (valor.State)
                                {
                                    tran.Commit();
                                }
                                return valor;
                            }
                            catch (Exception ex)
                            {
                                return new(false, ex.Message, this.Model);
                            }
                        });
                    return new(insertMsg.State, insertMsg.Msg, this.Model);
                case EntityState.Modificado:
                    var updateMsg = this.conexion.ExecuteInstructions(
                            (SqlConnection conn, SqlTransaction tran) =>
                            {
                                string query = $"UPDATE {this.TableName} SET" +
                                $" codpue_emp = @codpue_emp, sueldoagregado_emp = @sueldoagregado_emp, activo_emp = @activo_emp " +
                                $" WHERE codent_emp = @codent_emp;";

                                SqlParameter[] paramsList = [
                                    new("codent_emp", this.Model.codent_emp),
                                    new("codpue_emp", this.Model.codpue_emp),
                                    new("sueldoagregado_emp", this.Model.sueldoagregado_emp),
                                    new("activo_emp", this.Model.activo_emp),
                                ];

                                try
                                {
                                    int affected = ConexionSQL.ExecuteNonQuery(query, conn, paramsList, tran);
                                    var valor = new MSSQLRepositorio.Tipos.Message<object>(true, Mensajes.Msj_Aviso_InstruccionEjecutada, this.Model);
                                    if (valor.State)
                                    {
                                        tran.Commit();
                                    }
                                    return valor;
                                }
                                catch (Exception ex)
                                {
                                    return new(false, ex.Message, this.Model);
                                }
                            }
                        );
                    return new(updateMsg.State, updateMsg.Msg, this.Model);
                case EntityState.Eliminado:
                    break;
                default:
                    break;
            }
            return null;
        }

        public Empleado? Obtener(string codigo)
        {
            // Prepared Statement: https://en.wikipedia.org/wiki/Prepared_statement
            // Se envian los parametros por separado
            string query = $"{BaseSelect} WHERE codent_emp = @codent_emp;";
            SqlParameter[] paramsList =
            [
                new SqlParameter("codent_emp", codigo),
            ];

            var msg = conexion.ObtenerDatos(query, paramsList);
            if (msg.State)
            {
                DataTable? dataTable = msg.Entity;
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        Empleado? empleado = DataManager.DataRowToObject<Empleado>(dataTable.Rows[0]);
                        return empleado;
                    }
                }
            }
            return null;
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return this.DataList;
        }

        public override void CargarDatos(Empleado? entity)
        {
            if (entity != null)
            {
                entity.state = EntityState.Modificado;
            }
            base.CargarDatos(entity);
            //this.CambioModelo?.Invoke(this, entity?.cod_ser.ToString());

            // Probar con: CambioModelo.Invoke directamente
            this.Codigo = entity?.codent_emp.ToString();
        }
    }
}
