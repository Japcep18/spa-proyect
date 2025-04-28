using MaterialSkin.Controls;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Utilidades
{
    internal static class AlertaController
    {
        /// <summary>
        /// Muestra un mensaje de información
        /// </summary>
        /// <param name="parent">Form desde el que se va a alertar</param>
        /// <param name="mensaje">Mensaje que se va a mostrar</param>
        /// <param name="titulo">Opcional, título de la alerta</param>
        public static DialogResult AlertaInformacion(Form parent, string mensaje, string titulo = "Información")
        {
            MaterialDialog dialog = new MaterialDialog(parent, titulo, mensaje);
            return dialog.ShowDialog(parent);
            //return new Alerta(new OpcionesAlerta()
            //{
            //    Titulo = titulo,
            //    Message = mensaje,
            //    Icono = IconoAlerta.INFO,
            //    Botones = [BotonAlerta.ACEPTAR],
            //}).ShowDialog();
        }

        /// <summary>
        /// Muestra un mensaje de error
        /// </summary>
        /// <param name="parent">Form desde el que se va a alertar</param>
        /// <param name="mensaje">Mensaje que se va a mostrar</param>
        /// <param name="titulo">Opcional, título de la alerta</param>
        public static DialogResult AlertaError(Form parent, string mensaje, string titulo = "Error")
        {
            MaterialDialog dialog = new MaterialDialog(parent, titulo, mensaje, "Ok", false, "Cancelar", true);
            return dialog.ShowDialog(parent);
            //return new Alerta(new OpcionesAlerta()
            //{
            //    Titulo = titulo,
            //    Message = mensaje,
            //    Icono = IconoAlerta.ERROR,
            //    Botones = [BotonAlerta.ACEPTAR],
            //    Portapapeles = true,
            //}).ShowDialog();
        }

        /// <summary>
        /// Alerta con opciones de sí y no
        /// </summary>
        /// <param name="parent">Form desde el que se va a alertar</param>
        /// <param name="mensaje">Mensaje que se va a mostrar</param>
        /// <param name="titulo">Opcional, título de la alerta</param>
        public static DialogResult AlertaConfirmar(Form parent, string mensaje, string titulo = "Aviso")
        {
            MaterialDialog dialog = new MaterialDialog(parent, titulo, mensaje, "Aceptar", true, "Cancelar");
            return dialog.ShowDialog(parent);
            //return new Alerta(new OpcionesAlerta()
            //{
            //    Titulo = titulo,
            //    Message = mensaje,
            //    Icono = IconoAlerta.AVISO,
            //    Botones = [BotonAlerta.SI, BotonAlerta.NO],
            //}).ShowDialog();
        }
    }
}
