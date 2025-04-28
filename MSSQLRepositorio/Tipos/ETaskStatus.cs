namespace MSSQLRepositorio.Tipos
{
    /// <summary>
    /// Refleja el estado de la tarea
    /// </summary>
    public enum ETaskStatus
    {
        /// <summary>
        /// Ejecutada sin errores
        /// </summary>
        Completed,
        /// <summary>
        /// Sigue procesandose
        /// </summary>
        WorkingIn,
        /// <summary>
        /// Cancelada, por el usuario o por error
        /// </summary>
        Cancelled,
        /// <summary>
        /// Se ha creado, pero no se ha iniciado
        /// </summary>
        Created
    }
}
