

namespace MSSQLRepositorio.Tipos
{
    public class Taskeable : ITaskeable
    {
        private ETaskStatus status;

        public string Label { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; }

        public ETaskStatus Status
        {
            get => status;
            set
            {
                if (value != this.status)
                {
                    this.status = value;
                    this.StatusChanged?.Invoke(this, value);
                }
            }
        }

        public Task Task { get; set; }

        public event EventHandler<ETaskStatus>? StatusChanged;

        public Taskeable(Task task, string title = "", string desc = "")
        {
            this.Status = ETaskStatus.Created;
            this.Task = task;

            this.Label = title;
            this.Description = desc;

            if (task.Status != TaskStatus.WaitingToRun)
            {
                this.Status = ETaskStatus.WorkingIn;
            }
        }
    }
}
