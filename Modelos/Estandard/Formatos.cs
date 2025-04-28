namespace Modelos.Estandard
{
    public static class Formatos
    {
        public static string formatoFecha = "dd/MM/yyyy";
        public static string formatoFechaHora = "dd/MM/yyyy HH:mm:ss";
        public static string formatoMoneda = "0.00";
        /// <summary>
        /// Decimales luego del punto
        /// </summary>
        public static int formatoRedondeoMoneda = 2;

        public static string GetEstadoNombre(bool value) => value ? "Activo" : "Inactivo";
        public static string GetSiNoNombre(bool value) => value ? "Si" : "No";
    }
}
