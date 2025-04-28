using ProyectoIntegrador.Consultas.Forms;
using ProyectoIntegrador.Utilidades.Tipos;

namespace ProyectoIntegrador.Consultas
{
    internal class CCita : IConsultaUI
    {
        public void Consultar()
        {
            FCitasConsulta consulta = new();
            consulta.ShowDialog();
        }
    }
}
