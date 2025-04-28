using MaterialSkin.Controls;

namespace ProyectoIntegrador.Utilidades
{
    internal static class ToastController
    {
        private const int DEFAULT_DURATION = 1000;
        private const string DEFAULT_DIMISS_BUTTON_TEXT = "OK";

        public static void MostrarError(Form parent, string mensaje, int? duration = null) => 
            MostrarToast(parent, new() { 
                ColorAcento = true,
                Duration = duration ?? DEFAULT_DURATION,
                Message = mensaje,
                MostrarBtn = false,
                TextoBtn = DEFAULT_DIMISS_BUTTON_TEXT,
            });
        
        public static void MostrarInfo(Form parent, string mensaje, int? duration = null) => 
            MostrarToast(parent, new() { 
                ColorAcento = true,
                Duration = duration ?? DEFAULT_DURATION,
                Message = mensaje,
                MostrarBtn = false,
                TextoBtn = DEFAULT_DIMISS_BUTTON_TEXT,
            });

        public static void MostrarToast(Form parent, ToastConfig options)
        {
            MaterialSnackBar snack = new MaterialSnackBar(options.Message, 
                options.Duration ?? DEFAULT_DURATION, options.MostrarBtn ?? false, 
                options.TextoBtn ?? DEFAULT_DIMISS_BUTTON_TEXT, options.ColorAcento ?? false);
            snack.ShowDialog(parent);
        }
    }

    internal class ToastConfig
    {
        public string Message { get; set; }
        public int? Duration { get; set; }
        public bool? MostrarBtn { get; set; }
        public string? TextoBtn {  get; set; }
        public bool? ColorAcento { get; set; }
    }

}
