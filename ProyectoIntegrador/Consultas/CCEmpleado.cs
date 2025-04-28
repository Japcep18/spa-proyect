using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Consultables;
using Presentacion.Support;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Tipos;

namespace ProyectoIntegrador.Consultas
{
    internal class CCEmpleado : IConsultaUI
    {
        private readonly EmpleadoConsultableModel model = new();

        public void Consultar()
        {
            var msg = model.CargarDatos();
            if (!msg.State)
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
