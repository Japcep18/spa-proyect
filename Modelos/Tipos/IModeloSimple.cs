namespace Modelos.Tipos
{
    public interface IModeloSimple<T> where T : class, new()
    {
        public void CargarDatos(T? entity);
        public EntityMessage<IEnumerable<T>> CargarDatos();
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }

        public string TableName { get; }

        public event EventHandler<string?>? CambioModelo;
        public IEnumerable<T> ObtenerTodos();
        public T? Obtener(string codigo);
    }
}
