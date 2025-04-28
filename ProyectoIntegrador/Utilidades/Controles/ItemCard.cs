namespace ProyectoIntegrador.Utilidades.Controles
{
    public partial class ItemCard : UserControl
    {

        private Color originalColor;
        private Color hoverColor = Color.LightCyan;
        private Color clickedColor = Color.LightBlue;

        public override string Text
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
            }
        }
        public override Font Font { get => label1.Font; set => label1.Font = value; }
        public override Color ForeColor { get => label1.ForeColor; set => label1.ForeColor = value; }
        public Image Image { get => new Bitmap(pictureBox1.Image, new Size(64, 64)); set => pictureBox1.Image = value; }
        public ItemCard(string label, Image? image, int size = 64, string subtitle = "")
        {
            InitializeComponent();
            this.originalColor = this.materialCard1.BackColor;
            label1.Text = label;
            if (image != null)
            {
                pictureBox1.Image = GraphicsUtils.ResizeImage(image, new Size(size, size));
                this.pictureBox1.Height = size;
                this.Height = this.pictureBox1.Height;
                this.label1.Padding = new Padding(4, 0, 0, 0);
            }
            else
            {
                pictureBox1.Width = 0;
                pictureBox1.Visible = false;
                this.label1.Padding = new Padding(10, 0, 0, 0);
            }

            this.MouseDown += ItemCard_MouseDown;
            this.MouseUp += ItemCard_MouseUp;
            this.MouseHover += ItemCard_MouseHover;
            this.MouseLeave += ItemCard_MouseLeave;

            this.AssignMouseEvents(this);

            if(string.IsNullOrEmpty(subtitle))
            {
                this.panel1.Controls.Remove(this.label2);
            }
            else
            {
                this.label2.Text = subtitle;
            }
        }

        private void ItemCard_MouseLeave(object? sender, EventArgs e)
        {
            this.BackColor = originalColor; // Restaura el color al soltar el botón
            this.panel1.BackColor = originalColor;
            this.label1.BackColor = originalColor;
            this.materialCard1.BackColor = originalColor;
            this.pictureBox1.BackColor = originalColor;
        }

        private void ItemCard_MouseHover(object? sender, EventArgs e)
        {
            this.BackColor = hoverColor; // Cambia el color al presionar el botón
            this.panel1.BackColor = hoverColor;
            this.label1.BackColor = hoverColor;
            this.materialCard1.BackColor = hoverColor;
            this.pictureBox1.BackColor = hoverColor;
        }

        private void AssignMouseEvents(Control control)
        {
            control.MouseDown += ItemCard_MouseDown;
            control.MouseUp += ItemCard_MouseUp;
            control.MouseHover += ItemCard_MouseHover;
            control.MouseLeave += ItemCard_MouseLeave;

            foreach (Control child in control.Controls)
            {
                AssignMouseEvents(child); // Recursivamente asignar a todos los hijos
            }
        }

        private void ItemCard_MouseUp(object? sender, MouseEventArgs e)
        {
            this.BackColor = originalColor; // Restaura el color al soltar el botón
            this.panel1.BackColor = originalColor;
            this.label1.BackColor = originalColor;
            this.materialCard1.BackColor = originalColor;
            this.pictureBox1.BackColor = originalColor;
        }

        private void ItemCard_MouseDown(object? sender, MouseEventArgs e)
        {
            this.BackColor = clickedColor; // Cambia el color al presionar el botón
            this.panel1.BackColor = clickedColor;
            this.label1.BackColor = clickedColor;
            this.materialCard1.BackColor = clickedColor;
            this.pictureBox1.BackColor = clickedColor;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void materialCard1_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
