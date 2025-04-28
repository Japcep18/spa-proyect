using Modelos.Estandard;

namespace Modelos.Servicios
{
    public static class PreciosManager
    {
        public static decimal ObtenerImporte(Articulo art, decimal cantidad)
        {
            return Math.Round(art.precio_art * cantidad, Formatos.formatoRedondeoMoneda);
        }
    }
}
