using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;
using Modelos.Estandard;
using Modelos.Servicios;
using Modelos.Tipos;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Inventario
{
    public partial class FITBIS : BaseForm
    {
        private ITBISModel model = new ITBISModel();
        private PuenteModeloUI<ITBIS> puenteITBIS;
        public FITBIS()
        {
            InitializeComponent();
            base.guardarClick += FITBIS_guardarClick;
            this.puenteITBIS = new PuenteModeloUI<ITBIS>(model);
            model.CambioModelo += Model_Cambiomodelo;
        }

        private void Model_Cambiomodelo(object? sender, string? e)
        {
            if (model.Model != null)
            {
                this.textBoxITBIS.Text = model.Model.valor_itb.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                Nuevo(false);
            }
        }

        private void FITBIS_guardarClick(object? sender, EventArgs e)
        {
            if (!decimal.TryParse(this.textBoxITBIS.Text,
                         NumberStyles.Any,
                         CultureInfo.InvariantCulture,
                         out decimal valorITBIS))
            {
                AlertaController.AlertaError(this, "El valor del ITBIS debe ser un número decimal válido");
                return;
            }

            valorITBIS = Math.Round(valorITBIS, 4);
            ITBIS itbis = new ITBIS()
            {
                valor_itb = valorITBIS,
                state = model.Model == null ? EntityState.Agregado : EntityState.Modificado
            };
            model.Model = itbis;

            var resultado = model.Guardar();

            if (resultado.State)
            {
                ToastController.MostrarInfo(this, Mensajes.Msj_Aviso_RegistroGuardado);
                model.CargarDatos();
                Nuevo(false);
            }
            else
            {
                AlertaController.AlertaError(this, resultado.Msg);
            }

        }
        private void FITBIS_Load(object? sender, EventArgs e)
        {
            Nuevo(false);
        }
        protected override bool Nuevo(bool preguntar)
        {
            bool valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.MostrarBotones(true, true);
                this.HabilitarBotones(true, true);

                this.model = new();
                this.puenteITBIS = new(this.model);
                this.puenteITBIS.SetBotonBuscar(bBuscar1);
                model.CambioModelo += Model_Cambiomodelo;
            }
            return valor;
        }

        private void bBuscar1_Click(object sender, EventArgs e)
        {

        }
    }
}
