namespace ProyectoIntegrador.Utilidades.Controles
{
    public partial class BBuscar : Button
    {
        public BBuscar()
        {
            this.Image = new Bitmap(Properties.Resources.search_48, new Size(32, 32));
            this.Text = String.Empty;
            this.Size = new Size(48, 48);
        }
    }
}
