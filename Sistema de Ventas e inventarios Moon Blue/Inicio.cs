using C_Entidad;
using C_Negocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    public partial class Inicio : Form
    {

        private static Usuario UsuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null) UsuarioActual = new Usuario() { Nombre = "Admin", IdUsuario = 1 };
            else
                UsuarioActual = objusuario;


            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(UsuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {

                bool encontrado = ListaPermisos.Any(m => m.Nombre_Menu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }

            }

            lblusuario.Text = UsuarioActual.Nombre;

        }

        private void menumantenedor_Click(object sender, EventArgs e)
        {

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.FloralWhite;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.LightGray;


            Panel.Controls.Add(formulario);
            formulario.Show();

        }

        private void menuacerca_Click(object sender, EventArgs e)
        {

        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {

        }




        private void menuusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Usuarios());
        }




        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Clientes());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Proveedores());
        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new form_Tipo_Producto());
        }

        private void Submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new form_Producto());

        }

        private void menucompras_Click(object sender, EventArgs e)
        {

        }

        private void submenuregis_Compra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new form_Compras());
        }

        private void Sunmenuregistrar_venta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new form_Ventas());
        }

        private void submenuventa_detalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new form_Detalle_ventas());
        }

        private void submenudetalle_compra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new form_Detalle_Compra());
        }

        private void menuregistro_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Registros());
        }

        private void Inicio_Load_1(object sender, EventArgs e)
        {

        }
    }
}
