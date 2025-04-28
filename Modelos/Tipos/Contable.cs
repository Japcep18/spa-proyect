namespace Modelos.Tipos
{
    public class Contable<T> where T : class
    {
        public T Data { get; set; }
        public decimal Cantidad { get; set; }
    }
}
