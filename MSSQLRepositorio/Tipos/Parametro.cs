namespace MSSQLRepositorio.Tipos
{
    public class Parametro<T> where T : struct
    {
        public string NombreParametro { get; set; }
        public T Valor { get; set; }
    }
}
