using Modelos;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador.Inventario
{
    public partial class FGuarderia : BaseForm
    {
        private int maxValue;
        private List<Guarderia> dataList = new();

        public FGuarderia(List<Guarderia> dataList)
        {
            InitializeComponent();
            this.guardarClick += FGuarderia_guardarClick;
            this.dataList = dataList;
            this.RenderData();
        }

        private void RenderData()
        {
            this.dataGridView1.Rows.Clear();
            foreach (var item in dataList)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[ColumnTutor.Index].Value = item.tutor_guar;
                this.dataGridView1.Rows[index].Cells[ColumnInfante.Index].Value = item.infante_guar;
                this.dataGridView1.Rows[index].Cells[ColumnSecuencia.Index].Value = item.secuen_guar;
            }
            this.maxValue = dataList.Count;
        }

        private void FGuarderia_guardarClick(object? sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Ignorar fila nueva vacía

                // Obtener valores limpios (manejo seguro de nulls y espacios)
                var tutor = row.Cells[ColumnTutor.Index].Value?.ToString()?.Trim() ?? "";
                var infante = row.Cells[ColumnInfante.Index].Value?.ToString()?.Trim() ?? "";

                // Validar campos
                if (string.IsNullOrEmpty(tutor) || string.IsNullOrEmpty(infante))
                {
                    AlertaController.AlertaError(this, $"Complete TODOS los campos en la fila {row.Index + 1}");
                    return;
                }
            }

            // Actualizar la lista de datos
            dataList = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(row => !row.IsNewRow)
                .Select(row => new Guarderia
                {
                    secuen_guar = Convert.ToInt32(row.Cells[ColumnSecuencia.Index].Value),
                    tutor_guar = row.Cells[ColumnTutor.Index].Value?.ToString()?.Trim() ?? "",
                    infante_guar = row.Cells[ColumnInfante.Index].Value?.ToString()?.Trim() ?? ""
                })
                .ToList();

            this.Close();
        }

        public List<Guarderia> ObtenerDatos() => this.dataList;

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Seleccione una fila válida para eliminar",
                               "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow fila = dataGridView1.SelectedRows[0];
            dataGridView1.Rows.Remove(fila);

            // Reindexar secuencias
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].IsNewRow)
                    dataGridView1.Rows[i].Cells["ColumnSecuencia"].Value = i + 1;
            }

            maxValue = dataGridView1.Rows.Count - 1;
        }


        private void FGuarderia_Load(object sender, EventArgs e)
        {
            Nuevo(false);
        }

        protected override bool Nuevo(bool preguntar)
        {
            var valor = base.Nuevo(preguntar);
            if (valor)
            {
                this.RenderData();
                this.HabilitarBotones(true, true);
                this.MostrarBotones(true, true);
            }
            return valor;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.Rows.Add();
            this.dataGridView1.Rows[index].Cells["ColumnSecuencia"].Value = this.maxValue + 1;
            this.maxValue += 1;

            dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells["ColumnTutor"];
            dataGridView1.BeginEdit(true);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
    }
}
