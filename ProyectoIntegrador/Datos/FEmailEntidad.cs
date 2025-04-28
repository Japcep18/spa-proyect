
using Modelos;
using Modelos.Consultables;
using Modelos.Estandard;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;

namespace ProyectoIntegrador.Datos
{
    public partial class FEmailEntidad : BaseForm
    {
        private EmailEntidadModel emailEntidadModel = new();
        private EntidadConsultableModel entidadModel = new();
        private PuenteModeloUI<Entidad> puente;
        private int maxValue;

        public FEmailEntidad()
        {
            InitializeComponent();
            this.puente = new(entidadModel);
            // ============ ASIGNACION DE CONTROLES AL PUENTE ==============
            this.puente.SetBotonBuscar(bBuscar1);
            this.puente.SetTextBoxCodigo(textBoxCodigo);
            this.puente.SetTextBoxDescripcion(textBoxDescripcion);
            this.entidadModel.CambioModelo += EntidadModel_CambioModelo;
            this.guardarClick += FEmailEntidad_guardarClick;
        }

        private void FEmailEntidad_guardarClick(object? sender, EventArgs e)
        {
            if(this.dataGridView1.Rows.Count == 0)
            {
                FormUtils.AddError(this.errorProvider, this.dataGridView1, "No hay registros");
                return;
            }

            List<EmailEntidad> dataList = new();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                int? secuencia = item.Cells[ColumnSecuencia.Index].Value as int?;
                string? email = item.Cells[ColumnEmail.Index].Value as string;
                bool? estado = item.Cells[ColumnEstado.Index].Value as bool?;

                if(secuencia == null || estado == null || email == null)
                {
                    FormUtils.AddError(this.errorProvider, this.dataGridView1, "Dato Invalido");
                    return;
                }

                dataList.Add(new()
                {
                    codent_mail = this.entidadModel.Model!.codent_ent,
                    secuen_mail = (int) secuencia,
                    email_mail = email,
                    activo_mail = (bool) estado,
                });
            }

            var msg = this.emailEntidadModel.Guardar(dataList, this.entidadModel.Model!.codent_ent.ToString());
            if(!msg.State)
            {
                AlertaController.AlertaError(this, msg.Msg);
            } 
            else
            {
                ToastController.MostrarInfo(this, Mensajes.Msj_Aviso_RegistroGuardado);
                Nuevo(false);
            }
        }

        private void EntidadModel_CambioModelo(object? sender, string? e)
        {
            if (this.entidadModel.Model == null)
                return;

            this.groupBox1.Enabled = false;
            this.groupBox2.Enabled = true;

            var msgEmails = this.emailEntidadModel.Obtener(this.entidadModel.Model.codent_ent.ToString());

            if (msgEmails.State)
            {
                // Carga de datos
                this.maxValue = 0; // Valor inicial
                IEnumerable<EmailEntidad> dataList = msgEmails.Entity ?? [];
                foreach (var item in dataList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index]
                        .Cells[ColumnSecuencia.Index].Value = item.secuen_mail;
                    this.dataGridView1.Rows[index]
                        .Cells[ColumnEmail.Index].Value = item.email_mail;
                    this.dataGridView1.Rows[index]
                        .Cells[ColumnEstado.Index].Value = item.activo_mail;

                    if (this.maxValue < item.secuen_mail)
                        this.maxValue = item.secuen_mail;
                }
            }
            else
            {
                // Manejo de errores
                AlertaController.AlertaError(this, msgEmails.Msg);
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.CheckButtonEliminarState();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.CheckButtonEliminarState();
        }

        private void CheckButtonEliminarState()
        {
            this.buttonEliminar.Enabled = this.dataGridView1.CurrentRow == null;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells[ColumnSecuencia.Index].Value = this.maxValue + 1;
            this.dataGridView1.Rows[index].Cells[ColumnEstado.Index].Value = true;
            this.maxValue += 1;
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
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

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

        private void FEmailEntidad_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }
    }
}
