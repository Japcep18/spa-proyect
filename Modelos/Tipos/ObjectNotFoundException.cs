namespace Modelos.Tipos
{
    public class ObjectNotFoundException : Exception
    {
        public object? Entity { get; set; }
        public ObjectNotFoundException(object? entity, string msg) : base(msg)
        {
            this.Entity = entity;
        }
    }
}
