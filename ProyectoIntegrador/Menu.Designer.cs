namespace ProyectoIntegrador
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPageHome = new TabPage();
            labelUsuario = new Label();
            labelFecha = new Label();
            labelHora = new Label();
            IconList = new ImageList(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            conexionToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            openedProgramStrip = new MenuStrip();
            materialTabControl1.SuspendLayout();
            tabPageHome.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPageHome);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ImageList = IconList;
            materialTabControl1.Location = new Point(3, 116);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(941, 429);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPageHome
            // 
            tabPageHome.AutoScroll = true;
            tabPageHome.Controls.Add(labelUsuario);
            tabPageHome.Controls.Add(labelFecha);
            tabPageHome.Controls.Add(labelHora);
            tabPageHome.Location = new Point(4, 39);
            tabPageHome.Name = "tabPageHome";
            tabPageHome.Padding = new Padding(3);
            tabPageHome.Size = new Size(933, 386);
            tabPageHome.TabIndex = 0;
            tabPageHome.Text = "Inicio";
            tabPageHome.UseVisualStyleBackColor = true;
            // 
            // labelUsuario
            // 
            labelUsuario.AutoSize = true;
            labelUsuario.Location = new Point(183, 119);
            labelUsuario.Name = "labelUsuario";
            labelUsuario.Size = new Size(169, 20);
            labelUsuario.TabIndex = 2;
            labelUsuario.Text = "No se ha iniciado sesión";
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Font = new Font("Roboto Medium", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFecha.ForeColor = SystemColors.ControlDark;
            labelFecha.Location = new Point(180, 82);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(65, 28);
            labelFecha.TabIndex = 1;
            labelFecha.Text = "Hora";
            // 
            // labelHora
            // 
            labelHora.AutoSize = true;
            labelHora.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHora.ForeColor = SystemColors.Highlight;
            labelHora.Location = new Point(176, 27);
            labelHora.Name = "labelHora";
            labelHora.Size = new Size(106, 48);
            labelHora.TabIndex = 0;
            labelHora.Text = "Hora";
            // 
            // IconList
            // 
            IconList.ColorDepth = ColorDepth.Depth32Bit;
            IconList.ImageSize = new Size(32, 32);
            IconList.TransparentColor = Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { usuarioToolStripMenuItem, configuraciónToolStripMenuItem });
            menuStrip1.Location = new Point(3, 88);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(941, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // usuarioToolStripMenuItem
            // 
            usuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem });
            usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            usuarioToolStripMenuItem.Size = new Size(73, 24);
            usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(179, 26);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // configuraciónToolStripMenuItem
            // 
            configuraciónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { conexionToolStripMenuItem });
            configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            configuraciónToolStripMenuItem.Size = new Size(116, 24);
            configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // conexionToolStripMenuItem
            // 
            conexionToolStripMenuItem.Name = "conexionToolStripMenuItem";
            conexionToolStripMenuItem.Size = new Size(154, 26);
            conexionToolStripMenuItem.Text = "Conexión";
            conexionToolStripMenuItem.Click += conexionToolStripMenuItem_Click;
            // 
            // openedProgramStrip
            // 
            openedProgramStrip.ImageScalingSize = new Size(20, 20);
            openedProgramStrip.Location = new Point(3, 64);
            openedProgramStrip.Name = "openedProgramStrip";
            openedProgramStrip.Size = new Size(941, 24);
            openedProgramStrip.TabIndex = 3;
            openedProgramStrip.Text = "menuStrip2";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 548);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(materialTabControl1);
            Controls.Add(menuStrip1);
            Controls.Add(openedProgramStrip);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            DrawerWidth = 250;
            Name = "Menu";
            Text = "Menu";
            materialTabControl1.ResumeLayout(false);
            tabPageHome.ResumeLayout(false);
            tabPageHome.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private ImageList IconList;
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem configuraciónToolStripMenuItem;
        private ToolStripMenuItem conexionToolStripMenuItem;
        private TabPage tabPageHome;
        private Label labelFecha;
        private Label labelHora;
        private System.Windows.Forms.Timer timer1;
        private Label labelUsuario;
        private MenuStrip openedProgramStrip;
    }
}