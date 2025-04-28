using MaterialSkin.Controls;
using Modelos;
using Modelos.Tipos;
using ProyectoIntegrador.Configuracion;
using ProyectoIntegrador.Utilidades;
using System.Diagnostics;
using System.Text;

namespace ProyectoIntegrador
{
    public partial class MenuPrincipal : MaterialForm
    {
        private List<Form> openedProgramList = new();
        private ModulosModel modulosModel = new();
        private ProgramaModel programaModel = new();
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var conexion = new Conexion();
                conexion.AutoScaleMode = AutoScaleMode.Font;

                conexion.KeyDown += delegate (object? sender, KeyEventArgs e)
                {
                    if (e.KeyCode == Keys.F10 && e.Control)
                    {
                        MessageBox.Show($"{conexion.Name} | {conexion.Text}");
                    }
                };

                conexion.FormClosed += delegate { conexion.Dispose(); };

                conexion.StartPosition = FormStartPosition.CenterParent;
                conexion.ShowDialog();
            });
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            EntityMessage<IEnumerable<Modulo>> modulosList = modulosModel.CargarDatos();

            foreach (Modulo modulo in modulosList.Entity ?? [])
            {
                var modCard = FormUtils.RenderCard
                    (modulo, modulo.desc_mod, modulo.icono_mod, Text);
                modCard.Click += delegate (object? sender, EventArgs e)
                {
                    IEnumerable<Programa> programas = programaModel.ObtenerPorModulo(modulo.cod_mod);
                    this.CargarProgramas(programas);
                };
                this.flowLayoutPanelModulos.Controls.Add(modCard);
            }
        }

        private void CargarProgramas(IEnumerable<Programa> programas)
        {
            this.flowLayoutPanelProgramas.Controls.Clear();
            foreach (var item in programas)
            {
                // Crear tarjeta
                var prgCard = FormUtils.RenderCard
                    (item, item.desc_prg, item.icono_prg, "");
                // Al hacer click, iniciar el proceso de cargar los formularios
                prgCard.Click += delegate (object? sender, EventArgs e)
                {
                    // A partir del programa obtener el desc_tcli de la clase (Nombre de la clase + espacio de desc_tcli)
                    StringBuilder builder = new();
                    builder.Append("ProyectoIntegrador.");
                    builder.Append(item.nombre_prg);
                    string typeName = builder.ToString();
                    // Obtiene el tipo en base al string
                    Type? type = Type.GetType(typeName);
                    if (type == null)
                        return;

                    // Se crea la instancia a partir del tipo obtenido
                    object? instancedObj = Activator.CreateInstance(type);

                    // Si coincide como un FORM entonces se inicializa y se agrega a la lista de FORMS abiertos
                    if (instancedObj is Form createdForm)
                    {
                        TipoPrograma? tprg = this.programaModel.ObtenerTipoPrograma(item);
                        if(tprg != null)
                            createdForm.Text = $"{item.desc_prg} ({tprg.desctipo_tprg})";

                        // Si aun no se ha iniciado, se agrega.
                        // La propia función de InitForm se encarga de presentarlo si ya existe.
                        if (FormUtils.InitForm(createdForm))
                            this.AddProgram(createdForm);
                        else
                            // Vuelve a actualizar la lista
                            RenderOpenedProgramsInStripMenu();

                        createdForm.FormClosed += delegate
                        {
                            this.RemoveProgram(createdForm);
                        };
                    }
                };

                this.flowLayoutPanelProgramas.Controls.Add(prgCard);
            }
        }

        private void RemoveProgram(Form form)
        {
            this.openedProgramList.Remove(form);
            this.RenderOpenedProgramsInStripMenu();
        }

        private void AddProgram(Form form)
        {
            this.openedProgramList.Add(form);
            this.RenderOpenedProgramsInStripMenu();
        }

        private void RenderOpenedProgramsInStripMenu()
        {
            this.openedProgramStrip.Items.Clear();
            foreach (var item in openedProgramList)
            {
                ToolStripMenuItem toolItem = new()
                {
                    Text = item.Text
                };

                toolItem.Click += delegate
                {
                    FormUtils.InitForm(item);
                };

                this.openedProgramStrip.Items.Add(toolItem);
            }
        }
    }
}
