using C_Entidad;
using C_Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario ousuario = new CN_Usuario().Listar().Where(u => u.Identificacion == txtUsuario.Text && u.Contraseña == txtPass.Text).
                FirstOrDefault();

            if (ousuario != null)
            {
                Inicio form = new Inicio(ousuario);

                form.Show();
                this.Hide();

                form.FormClosing += frm_Cerrar;
            }
            else
            {
                MessageBox.Show("El usuario no existe, por favor intente de nuevo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void frm_Cerrar(object sender, FormClosingEventArgs e)
        {
            txtUsuario.Text = " ";
            txtPass.Text = " ";
            this.Show();
        }

        

        private void Login_Load(object sender, EventArgs e)
        {

        }

        
    }
}
