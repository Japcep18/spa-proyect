using Modelos;
using Modelos.Servicios;
using Presentacion.Support;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Tipos;

namespace ProyectoIntegrador.Consultas
{
    internal class CCServicio : IConsultaUI
    {
        private readonly ServicioModel model = new();
        public void Consultar()
        {
            var msg = model.CargarDatos();
            if (!msg.State)
            {
                // Manejo del error
                FormUtils.MostrarAlertaEnMenu(msg.Msg);
                return;
            }

            System.Data.DataTable table = DataManager.ToDataTable(msg.Entity ?? []);
            IConsultable consulta = new Consulta(table)
            {
                ForConsult = true,
            };
            consulta.ShowDialog();
        }
    }
}
