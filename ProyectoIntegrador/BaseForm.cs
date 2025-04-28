using MaterialSkin.Controls;
using ProyectoIntegrador.Properties;
using ProyectoIntegrador.Utilidades;

namespace ProyectoIntegrador
{
    public class BaseForm : MaterialForm
    {
        private ToolStrip toolStrip;
        private ToolStripButton btnNuevo;
        private ToolStripButton btnGuardar;
        private ToolStripButton btnEliminar;
        private ToolStripButton btnImprimir;
        protected MaterialProgressBar progressBar;
        protected StatusStrip statusStrip;
        protected ToolStripLabel labelStatus;
        protected ErrorProvider errorProvider;

        protected event EventHandler nuevoClick;
        protected event EventHandler guardarClick;
        protected event EventHandler eliminarClick;
        protected event EventHandler imprimirClick;

        public BaseForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Configurar el ToolStrip
            this.toolStrip = new ToolStrip();
            toolStrip.ImageScalingSize = new(32, 32);
            toolStrip.Dock = DockStyle.Top;

            // StatusStrip
            this.statusStrip = new StatusStrip();
            this.statusStrip.Dock = DockStyle.Bottom;
            this.statusStrip.ImageScalingSize = new Size(20, 20);
            this.statusStrip.Location = new Point(3, 296);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new Size(613, 24);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip";

            this.labelStatus = new()
            {
                Text = "",
            };

            this.statusStrip.Items.Add(labelStatus);

            // Progress Bar
            this.progressBar = new MaterialProgressBar();
            this.progressBar.Dock = DockStyle.Top;

            // Boton de nuevo
            this.btnNuevo = new ToolStripButton();
            btnNuevo.Image = Resources.note_48;
            btnNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNuevo.Click += BtnNuevo_Click;

            // Boton de guardado
            this.btnGuardar = new ToolStripButton();
            btnGuardar.Image = Resources.save_48;
            btnGuardar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGuardar.Click += BtnGuardar_Click;

            // Boton de imprimir
            this.btnImprimir = new ToolStripButton();
            btnImprimir.Image = Resources.print_48;
            btnImprimir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnImprimir.Click += BtnImprimir_Click;

            // Boton de imprimir
            this.btnEliminar = new ToolStripButton();
            btnEliminar.Image = Resources.cancel_48;
            btnEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEliminar.Click += BtnEliminar_Click;

            // Agregar botones al tool strip
            ToolStripItem[] toolStripItems = [
                this.btnNuevo,
                this.btnGuardar,
                this.btnEliminar,
                this.btnImprimir,
            ];

            this.toolStrip.Items.AddRange(toolStripItems);

            // Agregar al form
            this.Controls.Add(toolStrip);
            this.Controls.Add(statusStrip);
            this.Controls.Add(progressBar);

            // Configurar al form
            this.FormStyle = FormStyles.ActionBar_48;
            this.errorProvider = new();
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (this.eliminarClick != null)
            {
                this.eliminarClick.Invoke(this, e);
            }
        }

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            this.Nuevo(true);
            if (this.nuevoClick != null)
            {
                this.nuevoClick.Invoke(this, e);
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (this.guardarClick != null)
            {
                this.guardarClick.Invoke(this, e);
            }
        }

        private void BtnImprimir_Click(object? sender, EventArgs e)
        {
            if (this.imprimirClick != null)
            {
                this.imprimirClick.Invoke(this, e);
            }
        }

        protected virtual bool Nuevo(bool preguntar)
        {
            if (preguntar)
            {
                if (AlertaController.AlertaConfirmar(this, "Se perderán los cambios", "¿Descartar cambios?") != DialogResult.OK)
                    return false;
            }

            var limpiarFn = (Control ctrl) =>
            {
                if (ctrl is TextBox txtBox)
                {
                    txtBox.Clear();
                }
                else if (ctrl is RichTextBox rich)
                {
                    rich.Clear();
                }
                else if (ctrl is ComboBox cmbBox)
                {
                    cmbBox.Items.Clear();
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.Checked = false;
                }
                else if (ctrl is RadioButton rad)
                {
                    rad.Checked = false;
                }
            };

            foreach (Control ctrl in this.Controls)
            {
                if(ctrl.InvokeRequired)
                {
                    ctrl.Invoke(() => limpiarFn(ctrl));
                } else
                {
                    limpiarFn(ctrl);
                }
            }

            this.progressBar.Value = 0;
            this.labelStatus.Text = "Nuevo";

            // Volver a dibujar
            this.Invalidate();

            return true;
        }

        protected void MostrarBotones(bool nuevo = true, bool guardar = false, bool eliminar = false, bool imprimir = false)
        {
            this.btnNuevo.Visible = nuevo;
            this.btnGuardar.Visible = guardar;
            this.btnEliminar.Visible = eliminar;
            this.btnImprimir.Visible = imprimir;
        }

        private void InitializeComponent()
        {

        }

        protected void HabilitarBotones(bool nuevo = true, bool guardar = false, bool eliminar = false, bool imprimir = false)
        {
            this.btnNuevo.Enabled = nuevo;
            this.btnGuardar.Enabled = guardar;
            this.btnEliminar.Enabled = eliminar;
            this.btnImprimir.Enabled = imprimir;
        }
    }
}
