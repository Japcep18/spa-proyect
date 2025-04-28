namespace ProyectoIntegrador.Utilidades
{
    internal static class GraphicsUtils
    {
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
