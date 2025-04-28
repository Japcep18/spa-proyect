using MaterialSkin;
using MaterialSkin.Controls;
using Modelos;
using Modelos.Tipos;
using ProyectoIntegrador.Configuracion;
using ProyectoIntegrador.Utilidades;
using ProyectoIntegrador.Utilidades.Controles;
using ProyectoIntegrador.Utilidades.Tipos;
using System.Text;

namespace ProyectoIntegrador
{
    public partial class Menu : MaterialForm
    {
        private static readonly string homeImgIcon = "material_home_48";
        private static readonly string noLoggedLabelText = "No se ha iniciado sesión";
        private ModulosModel modulosModel = new();
        private ProgramaModel programaModel = new();
        private TipoProgramaModel tipoProgramaModel = new();
        private Dictionary<string, FlowLayoutPanel> modDict = new();
        private List<Form> openedProgramList = new();
        private System.Timers.Timer timer;

        public Menu()
        {
            InitializeComponent();

            this.timer = new System.Timers.Timer();
            this.timer.Interval = 1000;

            this.HandleCreated += Menu_Load;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() => this.Timer_Elapsed(sender, e));
                return;
            }
            DateTime now = DateTime.Now;
            this.labelHora.Text = now.ToString("hh:mm:ss tt");
            this.labelFecha.Text = now.ToString("D");
        }

        private void Menu_Load(object? sender, EventArgs e)
        {
            //this.AddHomeTabPage();
            SetTime();
            IniciarSesion();
        }

        private void SetTime()
        {
            this.timer.Elapsed -= Timer_Elapsed;
            this.timer.Elapsed += Timer_Elapsed;
            this.timer.Start();

            labelHora.ForeColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor;
            labelFecha.ForeColor = MaterialSkinManager.Instance.ColorScheme.AccentColor;

            labelHora.Refresh();
            labelFecha.Refresh();
        }

        private void CargarDatos()
        {
            // 

            //this.conexionToolStripMenuItem.Enabled = false;
            this.SetTime();

            // Limpieza
            ClearIcons();
            this.ClearTabPages();

            if (Autenticacion.CurrentSession == null)
                return;

            labelUsuario.Text = Autenticacion.CurrentSession!.usuario_ses;

            // Obtener los módulos que se mostrarán 
            EntityMessage<IEnumerable<Modulo>> modResponse
                = modulosModel.CargarDatos();

            if (!modResponse.State)
            {
                AlertaController.AlertaError(this, modResponse.Msg);
                return;
            }

            //this.modulosModel.CargarDatos();

            foreach (Modulo modulo in (modResponse.Entity ?? []).Where(mod => mod.activo).OrderBy(mod => mod.cod_mod))
            {
                FlowLayoutPanel layout = new()
                {
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };

                TabPage tab = new();
                // Carga de imagen
                if (modulo.icono_mod != null)
                {
                    string imgkey = $"{modulo.icono_mod}_48";
                    Image? img = (Image?)Properties.Resources.ResourceManager.GetObject(imgkey);
                    if (img != null)
                    {
                        if (!this.IconList.Images.ContainsKey(imgkey))
                            this.IconList.Images.Add(imgkey, img);
                        tab.ImageKey = imgkey;
                    }
                }
                tab.Padding = new Padding(3);
                tab.Size = new Size(786, 350);
                tab.Text = modulo.desc_mod;
                tab.TabIndex = materialTabControl1.Controls.Count;
                tab.UseVisualStyleBackColor = false;
                tab.Tag = modulo;
                tab.Controls.Add(layout);
                tab.Enter += delegate
                {
                    if (this.modDict.ContainsKey(modulo.cod_mod))
                    {
                        IEnumerable<Programa> programas = programaModel.ObtenerPorModulo(modulo.cod_mod);
                        this.CargarProgramas(programas, this.modDict[modulo.cod_mod]);
                    }
                };

                this.materialTabControl1.Controls.Add(tab);

                this.modDict.Add(modulo.cod_mod, layout);
            }

            this.Refresh();
        }

        private void ClearIcons()
        {
            //this.IconList.Images.Clear();
            // Agregar el de HOME
            Image? homeimg = (Image?)Properties.Resources.ResourceManager.GetObject(homeImgIcon);
            if (homeimg != null)
                if (!this.IconList.Images.ContainsKey(homeImgIcon))
                    this.IconList.Images.Add(homeImgIcon, homeimg);
        }

        private void AddHomeTabPage()
        {
            Image? homeimg = (Image?)Properties.Resources.ResourceManager.GetObject(homeImgIcon);
            if (homeimg != null)
            {
                if (!this.IconList.Images.ContainsKey(homeImgIcon))
                    this.IconList.Images.Add(homeImgIcon, homeimg);
                this.tabPageHome.ImageKey = homeImgIcon;
            }
            this.materialTabControl1.Controls.Add(this.tabPageHome);
            this.materialTabControl1.Refresh();
        }

        private void CargarProgramas(IEnumerable<Programa> programas, FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            List<ItemCard> cardList = new();
            int maxHeigth = 0;
            foreach (var item in programas.Where((p) => p.activo_prg == true).OrderBy((p) => p.pos_prg).OrderBy((p) => p.codtprg_prog))
            {
                var tipoPrograma = this.programaModel.ObtenerTipoPrograma(item);
                // Crear tarjeta
                ItemCard prgCard = FormUtils.RenderCard
                    (item, item.desc_prg, item.icono_prg, tipoPrograma == null ? "" : tipoPrograma.desctipo_tprg);

                // Al hacer click, iniciar el proceso de cargar los formularios
                prgCard.Click += delegate (object? sender, EventArgs e)
                {
                    // A partir del programa obtener el desc_tcli de la clase (Nombre de la clase + espacio de desc_tcli)
                    StringBuilder builder = new();
                    // Nombre del namespace
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
                        string formText = $"{item.desc_prg}";
                        if (tipoPrograma != null)
                            formText += $" - ({tipoPrograma.desctipo_tprg})";

                        createdForm.Text = formText;
                        if (FormUtils.InitForm(createdForm))
                        {
                            // Aun no se ha iniciado, agregar
                            this.AddProgram(createdForm);
                        }
                        else
                        {
                            RenderOpenedProgramsInStripMenu();
                        }

                        createdForm.FormClosed += delegate
                        {
                            this.RemoveProgram(createdForm);
                        };
                    }
                    else if (instancedObj is IConsultaUI consulta)
                    {
                        consulta.Consultar();
                    }
                };

                if (prgCard.Height > maxHeigth)
                    maxHeigth = prgCard.Height;

                cardList.Add(prgCard);
            }

            panel.Controls.AddRange([.. cardList.Select(
                (card) => { card.Height = maxHeigth; return card; })
                ]);

        }

        private void conexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(conexionToolStripMenuItem_Click, [sender, e]);
                return;
            }
            Task tk = Task.Run(() =>
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

                conexion.StartPosition = FormStartPosition.CenterParent;
                conexion.FormClosed += delegate
                {
                    conexion.Dispose();
                };

                var dialog =
                    conexion.ShowDialog();
            });
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
                ToolStripMenuItem toolItem = new ToolStripMenuItem()
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

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // -- CONFIRMAR QUE NO HAYAN VENTANAS ABIERTAS -- //
            if (this.openedProgramList.Count > 0)
            {
                if (AlertaController.AlertaConfirmar(this, "Hay programas abiertos ¿Desea cerrarlos?") == DialogResult.No)
                    return;
            }

            // Se debe limpiar los recursos aqui, de tal manera que se "inicie de nuevo"
            this.modDict.Clear();
            ClearTabPages();

            this.labelUsuario.Text = noLoggedLabelText;

            this.programaModel = new();
            //this.conexionToolStripMenuItem.Enabled = true;
            this.modulosModel = new();

            // --  CERRAR FORMS ABIERTOS -- //
            try
            {
                foreach (var program in this.openedProgramList)
                {
                    RemoveProgram(program);
                    program.Close();
                    program.Dispose();
                }
            }
            catch (InvalidOperationException)
            {
            }

            // Parte de la autenticacion
            Autenticacion.ClearSession();
            IniciarSesion();
        }

        private void ClearTabPages()
        {
            this.materialTabControl1.Controls.Clear();
            this.AddHomeTabPage();
        }

        private void IniciarSesion()
        {
            Autenticacion.IniciarSesion();
            CargarDatos();
        }
    }
}
