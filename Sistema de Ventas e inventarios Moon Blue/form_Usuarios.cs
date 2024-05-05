using C_Entidad;
using C_Negocio;
using Sistema_de_Ventas_e_inventarios_Moon_Blue.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    public partial class form_Usuarios : Form
    {
        public form_Usuarios()
        {
            InitializeComponent();
        }

        private void form_Usuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;


            List<Rol> listaRol = new CN_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;


            foreach (DataGridViewColumn columna in dgvData.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            //Mostrar todos los usuarios


            List<Usuario> listaUsuario = new CN_Usuario().Listar();

            foreach (Usuario item in listaUsuario)
            {
                dgvData.Rows.Add(new object[] {"", item.IdUsuario, item.Identificacion, item.Nombre, item.Email, item.Contraseña,
                        item.oRol.IdRol,
                        item.oRol.Descripcion,
                        item.Estado == true ? 1 : 0,
                        item.Estado ==true ? "Acttivo" : "No Activo"
                });
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Usuario objUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(txtId.Text),
                Identificacion = txtIdentificacion.Text,
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Contraseña = txtContraseña.Text,
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (objUsuario.IdUsuario == 0)
            {
                int IdUsuario_Generado = new CN_Usuario().Registrar(objUsuario, out Mensaje);

                if (IdUsuario_Generado != 0)
                {

                    dgvData.Rows.Add(new object[] { "", IdUsuario_Generado, txtIdentificacion.Text,txtNombre.Text, txtEmail.Text, txtContraseña.Text,
                        ((OpcionCombo) cboRol.SelectedItem).Valor.ToString(),
                        ((OpcionCombo) cboRol.SelectedItem).Texto.ToString(),
                        ((OpcionCombo) cboEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo) cboEstado.SelectedItem).Texto.ToString(),
                    });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
            else
            {
                bool Resultado = new CN_Usuario().Editar(objUsuario, out Mensaje);

                if (Resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Identificacion"].Value = txtIdentificacion.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Email"].Value = txtEmail.Text;
                    row.Cells["Contraseña"].Value = txtContraseña.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["Rol"].Value = ((OpcionCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
        }
        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtId.Text = "0";
            txtIdentificacion.Text = " ";
            txtNombre.Text = " ";
            txtEmail.Text = " ";
            txtContraseña.Text = " ";
            txtConfirmar.Text = " ";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            txtIdentificacion.Select();
        }




        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtIdentificacion.Text = dgvData.Rows[indice].Cells["Identificacion"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtEmail.Text = dgvData.Rows[indice].Cells["Email"].Value.ToString();
                    txtContraseña.Text = dgvData.Rows[indice].Cells["Contraseña"].Value.ToString();
                    txtConfirmar.Text = dgvData.Rows[indice].Cells["Contraseña"].Value.ToString();

                    foreach (OpcionCombo oc in cboRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_Combo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indice_Combo;
                            break;
                        }
                    }


                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_Combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_Combo;
                            break;
                        }
                    }
                }
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar este Usuario", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;

                    Usuario objUsuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(txtId.Text),

                    };
                    bool Respuesta = new CN_Usuario().Eliminar(objUsuario, out Mensaje);

                    if (Respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    }
                    else
                    {
                        MessageBox.Show(Mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string Columna_Filtro = ((OpcionCombo)cboBusqueda.SelectedItem).Valor.ToString();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Cells[Columna_Filtro].Value.ToString().Trim().ToUpper().Contains(txtBusqueda.Text.Trim().ToUpper()))

                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btn_Limpiar_Bus_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = " ";

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }       
    }
}
