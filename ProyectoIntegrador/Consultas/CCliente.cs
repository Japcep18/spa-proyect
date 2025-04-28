using Modelos.Consultables;
using Presentacion.Support;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Tipos;

namespace ProyectoIntegrador.Consultas
{
    internal class CCliente : IConsultaUI
    {
        private readonly ClienteConsultableModel model = new();

        public void Consultar()
        {
            var msg = model.CargarDatos();
            if(!msg.State)
            {
                // Manejo del error
                FormUtils.MostrarAlertaEnMenu(msg.Msg);
                return;
            }

            IConsultable consulta = new Consulta(model.GetDataTable(msg.Entity ?? []))
            {
                ForConsult = true,
            };
            consulta.ShowDialog();
        }
    }
}
