namespace ProyectoIntegrador
{
    partial class MenuPrincipal
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
            panel1 = new Panel();
            flowLayoutPanelModulos = new FlowLayoutPanel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            panel2 = new Panel();
            flowLayoutPanelProgramas = new FlowLayoutPanel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            splitter1 = new Splitter();
            menuStrip1 = new MenuStrip();
            usuarioToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            configuraciónToolStripMenuItem = new ToolStripMenuItem();
            conexionToolStripMenuItem = new ToolStripMenuItem();
            openedProgramStrip = new MenuStrip();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(flowLayoutPanelModulos);
            panel1.Controls.Add(materialLabel1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(3, 124);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 530);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanelModulos
            // 
            flowLayoutPanelModulos.BackColor = SystemColors.Control;
            flowLayoutPanelModulos.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanelModulos.Dock = DockStyle.Fill;
            flowLayoutPanelModulos.Location = new Point(0, 24);
            flowLayoutPanelModulos.Name = "flowLayoutPanelModulos";
            flowLayoutPanelModulos.Size = new Size(248, 504);
            flowLayoutPanelModulos.TabIndex = 1;
            // 
            // materialLabel1
            // 
            materialLabel1.BackColor = SystemColors.Control;
            materialLabel1.Depth = 0;
            materialLabel1.Dock = DockStyle.Top;
            materialLabel1.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel1.Location = new Point(0, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(248, 24);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Módulos";
            materialLabel1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(flowLayoutPanelProgramas);
            panel2.Controls.Add(materialLabel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(253, 124);
            panel2.Name = "panel2";
            panel2.Size = new Size(779, 530);
            panel2.TabIndex = 1;
            // 
            // flowLayoutPanelProgramas
            // 
            flowLayoutPanelProgramas.Dock = DockStyle.Fill;
            flowLayoutPanelProgramas.Location = new Point(0, 25);
            flowLayoutPanelProgramas.Name = "flowLayoutPanelProgramas";
            flowLayoutPanelProgramas.Size = new Size(779, 505);
            flowLayoutPanelProgramas.TabIndex = 2;
            // 
            // materialLabel2
            // 
            materialLabel2.Depth = 0;
            materialLabel2.Dock = DockStyle.Top;
            materialLabel2.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            materialLabel2.Location = new Point(0, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.RightToLeft = RightToLeft.No;
            materialLabel2.Size = new Size(779, 25);
            materialLabel2.TabIndex = 1;
            materialLabel2.Text = "    Programas";
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.ControlLight;
            splitter1.Location = new Point(253, 124);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(4, 530);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { usuarioToolStripMenuItem, configuraciónToolStripMenuItem });
            menuStrip1.Location = new Point(3, 96);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1029, 28);
            menuStrip1.TabIndex = 0;
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
            openedProgramStrip.Location = new Point(3, 72);
            openedProgramStrip.Name = "openedProgramStrip";
            openedProgramStrip.Size = new Size(1029, 24);
            openedProgramStrip.TabIndex = 2;
            openedProgramStrip.Text = "menuStrip2";
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 657);
            Controls.Add(splitter1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Controls.Add(openedProgramStrip);
            FormStyle = FormStyles.ActionBar_48;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipal";
            Padding = new Padding(3, 72, 3, 3);
            Text = "Menú Principal";
            Load += MenuPrincipal_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Splitter splitter1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem usuarioToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem configuraciónToolStripMenuItem;
        private ToolStripMenuItem conexionToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanelModulos;
        private FlowLayoutPanel flowLayoutPanelProgramas;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MenuStrip openedProgramStrip;
    }
}