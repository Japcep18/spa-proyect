namespace MSSQLRepositorio.Tipos
{
    public interface ITaskeable
    {
        string Label { get; set; }
        string Description { get; set; }
        DateTime Created { get; }
        ETaskStatus Status { get; }
        Task Task { get; set; }

        public event EventHandler<ETaskStatus> StatusChanged;
    }
}
