using MaterialSkin;
using MaterialSkin.Controls;
using ProyectoIntegrador.Properties;

namespace ProyectoIntegrador.Utilidades.Controles
{
    public partial class Alerta : MaterialForm
    {
        private readonly Dictionary<IconoAlerta, Image> imagenes = new()
        {
            {IconoAlerta.OK, Resources.check_96 },
            {IconoAlerta.AVISO, Resources.warning_96 },
            {IconoAlerta.ERROR, Resources.close_96 },
            {IconoAlerta.INFO, Resources.info_96 },
        };

        private readonly MaterialButton copiarAlPortaPapeles = new MaterialButton()
        {
            Text = "Copiar",
            Name = "Portapapeles",
            Type = MaterialButton.MaterialButtonType.Outlined,
            BackColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor,
            AutoSize = true,
        };

        private readonly Dictionary<BotonAlerta, Button> botones = new()
        {
            {BotonAlerta.ACEPTAR,
                new MaterialButton()
                {
                    Text = "Aceptar",
                    Type = MaterialButton.MaterialButtonType.Contained,
                    BackColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor,
                    DialogResult = DialogResult.OK,
                }
            },
            {BotonAlerta.CANCELAR,
                new MaterialButton()
                {
                    Text = "Cancelar",
                    Type = MaterialButton.MaterialButtonType.Contained,
                    BackColor = MaterialSkinManager.Instance.ColorScheme.AccentColor,
                    DialogResult = DialogResult.Cancel,
                }
            },
            {BotonAlerta.SI,
                new MaterialButton()
                {
                    Text = "Sí",
                    Type = MaterialButton.MaterialButtonType.Outlined,
                    BackColor = MaterialSkinManager.Instance.ColorScheme.PrimaryColor,
                    DialogResult = DialogResult.Yes,
                }
            },
            {BotonAlerta.NO,
                new MaterialButton(){
                    Text = "No",
                    Type = MaterialButton.MaterialButtonType.Outlined,
                    BackColor = MaterialSkinManager.Instance.ColorScheme.AccentColor,
                    DialogResult = DialogResult.No,
                }
            },
        };


        public Alerta(OpcionesAlerta opciones)
        {
            InitializeComponent();
            // Titulo de la alerta
            this.Text = opciones.Titulo;

            this.textBoxMensaje.Text = opciones.Message;

            if (opciones.Icono != null)
            {
                this.pictureBoxImage.Image = imagenes[opciones.Icono ?? IconoAlerta.INFO];
            }
            else
            {
                this.pictureBoxImage.Width = 0;
                this.pictureBoxImage.Visible = false;
            }

            if (opciones.Botones.Length > 0)
            {
                foreach (var btn in opciones.Botones)
                {
                    this.flowLayoutPanelButtons.Controls.Add(
                        botones[btn]
                    );
                }
            }
            else
            {
                this.flowLayoutPanelButtons.Controls.Add(
                    botones[BotonAlerta.ACEPTAR]
                );
            }

            if (opciones.Portapapeles)
            {
                copiarAlPortaPapeles.Click += delegate (object? sender, EventArgs e)
                {
                    Clipboard.SetText(this.textBoxMensaje.Text);
                };
                this.flowLayoutPanelButtons.Controls.Add(copiarAlPortaPapeles);
            }
        }
    }

    public class OpcionesAlerta
    {
        private string? titulo;
        private string message;
        private IconoAlerta? icono;
        private BotonAlerta[]? botones;
        private bool? portapapeles;

        public string Titulo { get => titulo ?? "Aviso"; set => titulo = value; }
        public string Message { get => message ?? ""; set => message = value; }
        public IconoAlerta? Icono { get => icono; set => icono = value; }
        public BotonAlerta[] Botones { get => botones ?? []; set => botones = value; }
        public bool Portapapeles { get => portapapeles ?? false; set => portapapeles = value; }
    }

    public enum IconoAlerta
    {
        ERROR,
        AVISO,
        OK,
        INFO,
    }

    public enum BotonAlerta
    {
        ACEPTAR,
        CANCELAR,
        SI,
        NO,
    }
}
