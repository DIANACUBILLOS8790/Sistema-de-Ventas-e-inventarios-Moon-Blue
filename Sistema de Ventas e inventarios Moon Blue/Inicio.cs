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
            if (objusuario == null) UsuarioActual = new Usuario() { Nombre = "lblNombre", IdUsuario = 1 };
            else
                UsuarioActual = objusuario;

            InitializeComponent();
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

            lblUsuario.Text = UsuarioActual.Nombre;

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.FloralWhite;
            }
            menu.BackColor = Color.LightSkyBlue;
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

        private void menuusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Usuarios());
        }

        private void submenu_regiscompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new form_Registro_Compra());
        }

        private void submenudetalle_compra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new form_Detalle_Compra());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Clientes());
        }

        private void submenuregistrar_venta_Click(object sender, EventArgs e)
        {

            AbrirFormulario(menuventas, new form_Registro_ventas());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Proveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new form_Reportes());
        }

        private void submenutipo_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new form_Tipo_Producto());
        }

        private void submenu_producto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new form_Productos());
        }

        private void menucompras_Click(object sender, EventArgs e)
        {

        }

        private void menuventas_Click(object sender, EventArgs e)
        {

        }

        private void menumantenedor_Click(object sender, EventArgs e)
        {

        }

        private void menuacerca_Click(object sender, EventArgs e)
        {

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load_1(object sender, EventArgs e)
        {

        }
    }
}
