namespace Modelos.Tipos
{
    public class EntityMessage<T>(bool state, string? message, T? entity) : MSSQLRepositorio.Tipos.Message<T>(state, message, entity) //where T : class
    {
    }
}
