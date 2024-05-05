using C_Entidad;
using C_Negocio;
using Sistema_de_Ventas_e_inventarios_Moon_Blue.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    public partial class form_Tipo_Producto : Form
    {
        public form_Tipo_Producto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void form_Tipo_Producto_Load(object sender, EventArgs e)
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

            List<Tipo_Producto> lista = new CN_Tipo_Producto().Listar();

            foreach (Tipo_Producto item in lista)
            {
                dgvData.Rows.Add(new object[] {"", item.IdTipo,
                    item.Descripcion,
                    item.Estado == true ? 1 : 0,
                    item.Estado ==true ? "Acttivo" : "No Activo"
                });
            }
        }


        //Guardar Tipo de producto 

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Tipo_Producto obj = new Tipo_Producto()
            {
                IdTipo = Convert.ToInt32(txtId.Text),
                Descripcion = txtDescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdTipo == 0)
            {
                int Id_Generado = new CN_Tipo_Producto().Registrar(obj, out Mensaje);

                if (Id_Generado != 0)
                {

                    dgvData.Rows.Add(new object[] { "", Id_Generado, txtDescripcion.Text,
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
                bool Resultado = new CN_Tipo_Producto().Editar(obj, out Mensaje);

                if (Resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Descripcion"].Value = txtDescripcion.Text;
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
            txtDescripcion.Text = " ";
            cboEstado.SelectedIndex = 0;

            txtDescripcion.Select();

        }


        // Pintar el visto en el check de DataGridView

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


        //contenido de seleccion Tipo de producto 

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["Descripcion"].Value.ToString();


                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToUInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_Combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_Combo;
                            break;

                        }
                    }
                }
            }
        }

        //Eliminar Tipo de producto 

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtId.Text) != 0)
            {
                if (MessageBox.Show("Desea eliminar este Tipo de producto", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;

                    Tipo_Producto obj = new Tipo_Producto()
                    {
                        IdTipo = Convert.ToInt32(txtId.Text),

                    };
                    bool Respuesta = new CN_Tipo_Producto().Eliminar(obj, out Mensaje);

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

        //Evento lupa de buscar tipo de producto 

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

        //limpiar buscado "icono Escoba" Tipo de producto 

        private void btn_Limpiar_Bus_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = " ";

            foreach (DataGridViewRow row in dgvData.Rows)
            {
                row.Visible = true;
            }
        }

        //Limpiar tipo de producto

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

       
    }

}
