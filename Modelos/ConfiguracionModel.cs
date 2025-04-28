using Modelos.Servicios;
using Modelos.Tipos;
using MSSQLRepositorio;

namespace Modelos
{
    public class LocalConfiguracion
    {
        DatosConexion conexion;

        public DatosConexion Conexion { get => conexion; set => conexion = value; }
    }

    public class ConfiguracionModel : BaseModel<LocalConfiguracion>
    {
        private readonly JSONManager<LocalConfiguracion> localConfigJsonManager = new("local.config.json");

        public override string TableName => "Configuracion";

        public ConfiguracionModel()
        {
            this.CargarDatos();
        }

        public override EntityMessage<IEnumerable<LocalConfiguracion>> CargarDatos()
        {
            var config = this.localConfigJsonManager.LoadData();
            if (config == null)
            {
                // Colocar aqui la configuracion por defecto

                this.Model = new()
                {
                    Conexion = new DatosConexion()
                    {
                        Servidor = "proyectointegradorutesa.database.windows.net,1433",
                        Usuario = "administrador",
                        Clave = "admin1234**",
                        BaseDatos = "ProyectoIntegrador1",
                        TrustServerCertificate = true,
                        WindowsAuth = false
                    }
                };
            }
            else
            {
                this.Model = config;
            }
            return new(true, "Configuración cargada", [this.Model]);
        }

        public override EntityMessage<LocalConfiguracion> Guardar()
        {
            this.localConfigJsonManager.SaveData(this.Model);
            return new EntityMessage<LocalConfiguracion>(true, "Configuración guardada", this.Model);
        }

        public EntityMessage<DatosConexion> ProbarConexion(DatosConexion datos)
        {
            MSSQLRepositorio.Tipos.Message<MSSQLRepositorio.Tipos.DatosConexion> msg = new ConexionSQL(datos).ProbarConexion(datos);
            return new(msg.State, msg.Msg, new DatosConexion()
            {
                Servidor = msg.Entity!.Servidor,
                BaseDatos = msg.Entity!.BaseDatos,
                Clave = msg.Entity!.Clave,
                TrustServerCertificate = msg.Entity!.TrustServerCertificate,
                Usuario = msg.Entity!.Usuario,
                WindowsAuth = msg.Entity!.WindowsAuth,
            });
        }
    }
}
