using Modelos.Estandard;
using MSSQLRepositorio;

namespace Modelos.Tipos
{
    public abstract class BaseModel<T> where T : class
    {
        /// <summary>
        /// Nombre de la tabla en la Base de datos
        /// </summary>
        public abstract string TableName { get; }

        /// <summary>
        /// Modelo seleccionado
        /// </summary>
        public T? Model { get; set; }

        /// <summary>
        /// Lista de datos cargados
        /// </summary>
        public IEnumerable<T> DataList = new List<T>();

        /// <summary>
        /// Guarda los cambios que se realizarán
        /// </summary>
        /// <returns>Mensaje del resultado de los cambios</returns>
        public abstract EntityMessage<T> Guardar();

        /// <summary>
        /// Conexión para comunicar con la base de datos
        /// </summary>
        protected ConexionSQL conexion;

        /// <summary>
        /// Carga los datos
        /// </summary>
        public abstract EntityMessage<IEnumerable<T>> CargarDatos();

        /// <summary>
        /// Carga los datos y asigna al modelo actual los valores de la entidad dada
        /// </summary>
        /// <param name="entity">Entidad a cargar</param>
        public virtual void CargarDatos(T? entity)
        {
            Model = entity;
        }

        public virtual EntityMessage<IEnumerable<T>> ConsultarDatos()
        {
            return this.CargarDatos();
        }
    }
}
