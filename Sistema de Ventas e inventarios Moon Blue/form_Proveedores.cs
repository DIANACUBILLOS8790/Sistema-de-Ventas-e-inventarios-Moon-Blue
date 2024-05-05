using C_Entidad;
using C_Negocio;
using Sistema_de_Ventas_e_inventarios_Moon_Blue.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    public partial class form_Proveedores : Form
    {
        public form_Proveedores()
        {
            InitializeComponent();
        }

        private void form_Proveedores_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;



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


            List<Proveedores> lista = new CN_Proveedores().Listar();

            foreach (Proveedores item in lista)
            {
                dgvData.Rows.Add(new object[] {"", item.IdProveedores, item.Identificacion, item.Nombre_Empresa, item.Email, item.Telefono,
                        item.Estado == true ? 1 : 0,
                        item.Estado ==true ? "Acttivo" : "No Activo"
                });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Proveedores obj = new Proveedores()
            {
                IdProveedores = Convert.ToInt32(txtId.Text),
                Identificacion = txtIdentificacion.Text,
                Nombre_Empresa = txtNombre.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,

                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdProveedores == 0)
            {
                int Proveedores_Generado = new CN_Proveedores().Registrar(obj, out Mensaje);

                if (Proveedores_Generado != 0)
                {

                    dgvData.Rows.Add(new object[]
                    {   "",
                        Proveedores_Generado,
                        txtIdentificacion.Text,
                        txtNombre.Text,
                        txtEmail.Text,
                        txtTelefono.Text,
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
                bool Resultado = new CN_Proveedores().Editar(obj, out Mensaje);

                if (Resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["IdProveedores"].Value = txtId.Text;
                    row.Cells["Identificacion"].Value = txtIdentificacion.Text;
                    row.Cells["Nombre_Empresa"].Value = txtNombre.Text;
                    row.Cells["Email"].Value = txtEmail.Text;
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
            txtTelefono.Text = " ";
            cboEstado.SelectedIndex = 0;

            txtIdentificacion.Select();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var W = Properties.Resources.controlar.Width;
                var H = Properties.Resources.controlar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - W) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - H) / 2;

                e.Graphics.DrawImage(Properties.Resources.controlar, new Rectangle(x, y, W, H));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["IdProveedores"].Value.ToString();
                    txtIdentificacion.Text = dgvData.Rows[indice].Cells["Identificacion"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre_Empresa"].Value.ToString();
                    txtEmail.Text = dgvData.Rows[indice].Cells["Email"].Value.ToString();
                    txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();


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
                if (MessageBox.Show("¿Desea eliminar la información de este Proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;

                    Proveedores obj = new Proveedores()
                    {
                        IdProveedores = Convert.ToInt32(txtId.Text),

                    };
                    bool Respuesta = new CN_Proveedores().Eliminar(obj, out Mensaje);

                    if (Respuesta)
                    {
                        dgvData.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                        Limpiar();
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
