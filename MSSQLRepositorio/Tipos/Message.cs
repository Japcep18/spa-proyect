namespace MSSQLRepositorio.Tipos
{
    public class Message<T> // where T : class
    {
        #region Declaracion de variables
        private bool state;
        private string message;
        private T? entity;

        public bool State { get => state; private set => state = value; }
        public string Msg { get => message; private set => message = value; }
        public T? Entity { get => entity; private set => entity = value; }
        #endregion

        public Message(bool state, string? message, T? entity)
        {
            this.State = state;
            this.Msg = message ?? "";
            this.Entity = entity;
        }
    }
}
