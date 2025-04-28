using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos.Consultables;
using Modelos;
using ProyectoIntegrador.Utilidades.Controles;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Modelos.Servicios;

namespace ProyectoIntegrador.Inventario
{
    public partial class FTelefonoEntidad : BaseForm
    {
        private TelefonoEntidadModel telefonoEntidadModel = new();
        private EntidadConsultableModel entidadModel = new();
        private PuenteModeloUI<Entidad> puente;
        private int maxValue;
        public FTelefonoEntidad()
        {
            InitializeComponent();
            this.puente = new(entidadModel);
            // ============ ASIGNACION DE CONTROLES AL PUENTE ==============
            this.puente.SetBotonBuscar(bBuscar1);
            this.puente.SetTextBoxCodigo(textBoxCodigo);
            this.puente.SetTextBoxDescripcion(textBoxNombre);
            this.entidadModel.CambioModelo += EntidadModel_CambioModelo;
            this.guardarClick += FTelefonoEntidad_guardarClick;
        }

        private void EntidadModel_CambioModelo(object? sender, string? e)
        {
            if (this.entidadModel.Model == null)
                return;

            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = true;

            var msgEmails = this.telefonoEntidadModel.Obtener(this.entidadModel.Model.codent_ent.ToString());

            if (msgEmails.State)
            {
                // Carga de datos
                this.maxValue = 0; // Valor inicial
                IEnumerable<TelefonoEntidad> dataList = msgEmails.Entity ?? [];
                foreach (var item in dataList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index]
                        .Cells[ColumnSecuencia.Index].Value = item.secuen_telef;
                    this.dataGridView1.Rows[index]
                        .Cells[ColumnTelefono.Index].Value = item.telef_telef;
                    this.dataGridView1.Rows[index]
                        .Cells[ColumnEstado.Index].Value = item.activo_telef;

                    if (this.maxValue < item.secuen_telef)
                        this.maxValue = item.secuen_telef;
                }
            }
            else
            {
                // Manejo de errores
                AlertaController.AlertaError(this, msgEmails.Msg);
            }
        }

        private void FTelefonoEntidad_guardarClick(object? sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, "No hay registros");
                return;
            }

            List<TelefonoEntidad> dataList = new();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                int? secuencia = item.Cells[ColumnSecuencia.Index].Value as int?;
                string? telefono = item.Cells[ColumnTelefono.Index].Value as string;
                bool? estado = item.Cells[ColumnEstado.Index].Value as bool?;

                if (secuencia == null || estado == null || telefono == null)
                {
                    FormUtils.AddError(this.errorProvider, this.dataGridView1, "Dato Invalido");
                    return;
                }

                dataList.Add(new()
                {
                    codent_telef = this.entidadModel.Model!.codent_ent,
                    secuen_telef = (int)secuencia,
                    telef_telef = telefono,
                    activo_telef = (bool)estado,
                });
            }

            var msg = this.telefonoEntidadModel.Guardar(dataList, this.entidadModel.Model!.codent_ent.ToString());
            if (!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
            }
            else
            {
                ToastController.MostrarInfo(this, Mensajes.Msj_Aviso_RegistroGuardado);
                Nuevo(false);
            }
        }

        private void CheckButtonEliminarState()
        {
            this.buttonEliminar.Enabled = this.dataGridView1.CurrentRow == null;
        }


        private void FTelefonoEntidad_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            var valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.dataGridView1.Rows.Clear();
                this.groupBox1.Enabled = true;
                this.groupBox2.Enabled = false;
                this.buttonEliminar.Enabled = false;
                this.entidadModel.Model = null;
                this.entidadModel.Codigo = null;
            }
            return valor;
        }

        private void dataGridView1_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            this.CheckButtonEliminarState();
        }

        private void dataGridView1_RowLeave_1(object sender, DataGridViewCellEventArgs e)
        {
            this.CheckButtonEliminarState();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void buttonAgregar_Click_1(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[ColumnSecuencia.Index].Value = this.maxValue + 1;
            this.dataGridView1.Rows[index].Cells[ColumnEstado.Index].Value = true;
            this.maxValue += 1;
        }

        private void buttonEliminar_Click_1(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows == null)
                return;

            if (this.dataGridView1.SelectedRows.Count == 0)
                return;

            int index = this.dataGridView1.SelectedRows[0].Index;
            try
            {
                this.dataGridView1.Rows.RemoveAt(index);
            }
            catch (Exception)
            {
            }
        }
    }
}
