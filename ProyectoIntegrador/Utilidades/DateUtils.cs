namespace ProyectoIntegrador.Utilidades
{
    internal static class DateUtils
    {
        public static DateTime TrimSeconds(DateTime d) => d.Date + new TimeSpan(d.Hour, d.Minute, 0);
    }
}
