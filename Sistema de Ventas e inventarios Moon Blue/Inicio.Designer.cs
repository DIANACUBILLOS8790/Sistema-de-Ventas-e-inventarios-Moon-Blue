namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    partial class Inicio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuusuario = new FontAwesome.Sharp.IconMenuItem();
            this.menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenu_regiscompra = new System.Windows.Forms.ToolStripMenuItem();
            this.submenudetalle_compra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrar_venta = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuventa_detalleventa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.submenutipo = new System.Windows.Forms.ToolStripMenuItem();
            this.submenu_producto = new System.Windows.Forms.ToolStripMenuItem();
            this.menuacerca = new FontAwesome.Sharp.IconMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(166)))), ((int)(((byte)(163)))));
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(1174, 81);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(201)))));
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuario,
            this.menucompras,
            this.menuventas,
            this.menuclientes,
            this.menuproveedores,
            this.menureportes,
            this.menumantenedor,
            this.menuacerca});
            this.menu.Location = new System.Drawing.Point(0, 81);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1174, 54);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip2";
            // 
            // menuusuario
            // 
            this.menuusuario.AutoSize = false;
            this.menuusuario.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuusuario.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            this.menuusuario.IconColor = System.Drawing.Color.Black;
            this.menuusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuario.IconSize = 35;
            this.menuusuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuario.Name = "menuusuario";
            this.menuusuario.Padding = new System.Windows.Forms.Padding(0);
            this.menuusuario.Size = new System.Drawing.Size(90, 50);
            this.menuusuario.Text = "Usuarios";
            this.menuusuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuario.Click += new System.EventHandler(this.menuusuario_Click);
            // 
            // menucompras
            // 
            this.menucompras.AutoSize = false;
            this.menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenu_regiscompra,
            this.submenudetalle_compra});
            this.menucompras.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menucompras.IconColor = System.Drawing.Color.Black;
            this.menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompras.IconSize = 35;
            this.menucompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompras.Name = "menucompras";
            this.menucompras.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.menucompras.Size = new System.Drawing.Size(90, 50);
            this.menucompras.Text = "Compras";
            this.menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menucompras.Click += new System.EventHandler(this.menucompras_Click);
            // 
            // submenu_regiscompra
            // 
            this.submenu_regiscompra.Name = "submenu_regiscompra";
            this.submenu_regiscompra.Size = new System.Drawing.Size(201, 24);
            this.submenu_regiscompra.Text = "Registrar compra";
            this.submenu_regiscompra.Click += new System.EventHandler(this.submenu_regiscompra_Click);
            // 
            // submenudetalle_compra
            // 
            this.submenudetalle_compra.Name = "submenudetalle_compra";
            this.submenudetalle_compra.Size = new System.Drawing.Size(201, 24);
            this.submenudetalle_compra.Text = "Detalle de compra";
            this.submenudetalle_compra.Click += new System.EventHandler(this.submenudetalle_compra_Click);
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrar_venta,
            this.submenuventa_detalleventa});
            this.menuventas.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.IconSize = 35;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.menuventas.Size = new System.Drawing.Size(90, 50);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuventas.Click += new System.EventHandler(this.menuventas_Click);
            // 
            // submenuregistrar_venta
            // 
            this.submenuregistrar_venta.Name = "submenuregistrar_venta";
            this.submenuregistrar_venta.Size = new System.Drawing.Size(188, 24);
            this.submenuregistrar_venta.Text = "Registrar venta";
            this.submenuregistrar_venta.Click += new System.EventHandler(this.submenuregistrar_venta_Click);
            // 
            // submenuventa_detalleventa
            // 
            this.submenuventa_detalleventa.Name = "submenuventa_detalleventa";
            this.submenuventa_detalleventa.Size = new System.Drawing.Size(188, 24);
            this.submenuventa_detalleventa.Text = "Detalle de venta";
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.IconSize = 35;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.menuclientes.Size = new System.Drawing.Size(90, 50);
            this.menuclientes.Text = "Clientes";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuclientes.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menuproveedores
            // 
            this.menuproveedores.AutoSize = false;
            this.menuproveedores.Font = new System.Drawing.Font("Candara", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuproveedores.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            this.menuproveedores.IconColor = System.Drawing.Color.Black;
            this.menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedores.IconSize = 35;
            this.menuproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedores.Name = "menuproveedores";
            this.menuproveedores.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.menuproveedores.Size = new System.Drawing.Size(90, 50);
            this.menuproveedores.Text = "Proveedores";
            this.menuproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuproveedores.Click += new System.EventHandler(this.menuproveedores_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.Font = new System.Drawing.Font("Candara", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartColumn;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 35;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.menureportes.Size = new System.Drawing.Size(90, 50);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menureportes.Click += new System.EventHandler(this.menureportes_Click);
            // 
            // menumantenedor
            // 
            this.menumantenedor.AutoSize = false;
            this.menumantenedor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenutipo,
            this.submenu_producto});
            this.menumantenedor.Font = new System.Drawing.Font("Candara", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menumantenedor.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menumantenedor.IconColor = System.Drawing.Color.Black;
            this.menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenedor.IconSize = 35;
            this.menumantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenedor.Name = "menumantenedor";
            this.menumantenedor.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.menumantenedor.Size = new System.Drawing.Size(90, 50);
            this.menumantenedor.Text = "Mantenedor ";
            this.menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menumantenedor.Click += new System.EventHandler(this.menumantenedor_Click);
            // 
            // submenutipo
            // 
            this.submenutipo.Name = "submenutipo";
            this.submenutipo.Size = new System.Drawing.Size(182, 22);
            this.submenutipo.Text = "Tipo de producto";
            this.submenutipo.Click += new System.EventHandler(this.submenutipo_Click);
            // 
            // submenu_producto
            // 
            this.submenu_producto.Name = "submenu_producto";
            this.submenu_producto.Size = new System.Drawing.Size(182, 22);
            this.submenu_producto.Text = "Producto";
            this.submenu_producto.Click += new System.EventHandler(this.submenu_producto_Click);
            // 
            // menuacerca
            // 
            this.menuacerca.AutoSize = false;
            this.menuacerca.Font = new System.Drawing.Font("Candara", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuacerca.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacerca.IconColor = System.Drawing.Color.Black;
            this.menuacerca.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacerca.IconSize = 35;
            this.menuacerca.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacerca.Name = "menuacerca";
            this.menuacerca.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.menuacerca.Size = new System.Drawing.Size(90, 50);
            this.menuacerca.Text = "Acerca de ";
            this.menuacerca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacerca.Click += new System.EventHandler(this.menuacerca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(166)))), ((int)(((byte)(163)))));
            this.label1.Font = new System.Drawing.Font("Candara", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ventas e inventarios";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(166)))), ((int)(((byte)(163)))));
            this.label5.Font = new System.Drawing.Font("Vivaldi", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(198, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 47);
            this.label5.TabIndex = 7;
            this.label5.Text = "Moon Blue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(166)))), ((int)(((byte)(163)))));
            this.label2.Font = new System.Drawing.Font("Candara", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(708, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bienvenido";
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(191)))), ((int)(((byte)(175)))));
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 135);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1174, 596);
            this.Panel.TabIndex = 10;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(166)))), ((int)(((byte)(163)))));
            this.lblUsuario.Font = new System.Drawing.Font("Vivaldi", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(598, 34);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 47);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Sistema_de_Ventas_e_inventarios_Moon_Blue.Properties.Resources.luna;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 81);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 731);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load_1);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconMenuItem menuacerca;
        private FontAwesome.Sharp.IconMenuItem menuusuario;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ToolStripMenuItem submenuregistrar_venta;
        private System.Windows.Forms.ToolStripMenuItem submenuventa_detalleventa;
        private System.Windows.Forms.ToolStripMenuItem submenu_regiscompra;
        private System.Windows.Forms.ToolStripMenuItem submenudetalle_compra;
        private System.Windows.Forms.ToolStripMenuItem submenutipo;
        private System.Windows.Forms.ToolStripMenuItem submenu_producto;
        private System.Windows.Forms.Label lblUsuario;
    }
}