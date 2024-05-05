using C_Entidad;
using C_Negocio;
using ClosedXML.Excel;
using Sistema_de_Ventas_e_inventarios_Moon_Blue.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    public partial class form_Productos : Form
    {
        public form_Productos()
        {
            InitializeComponent();
        }


        private void form_Productos_Load(object sender, EventArgs e)
        {

            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;


            List<Tipo_Producto> listaTipo_Producto = new CN_Tipo_Producto().Listar();

            foreach (Tipo_Producto item in listaTipo_Producto)
            {
                cboTipo.Items.Add(new OpcionCombo() { Valor = item.IdTipo, Texto = item.Descripcion });
            }
            cboTipo.DisplayMember = "Texto";
            cboTipo.ValueMember = "Valor";
            cboTipo.SelectedIndex = 0;


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

            //Mostrar todos los productos

           

            List<Productos> lista= new CN_Productos().Listar();

            foreach (Productos item in lista)
            {
                dgvData.Rows.Add(new object[]
                {   "",
                    item.IdProductos,
                    item.Codigo_Producto,
                    item.Nombre,
                    item.Descripcion_Producto,
                    item.Tipo_Producto,
                    item.Stock,
                    item.Precio_Compra,
                    item.Precio_Venta,
                    item.Estado ==true ? "Activo" : "No Activo",
                    item.IdTipo,

                });

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Productos obj = new Productos()
            {
                IdProductos = Convert.ToInt32(txtId.Text),
                Codigo_Producto = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Descripcion_Producto = txtDescripcion.Text,

                oTipo_Producto = new Tipo_Producto() { IdTipo = Convert.ToInt32(((OpcionCombo)cboTipo.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdProductos == 0)
            {
                int Id_Generado = new CN_Productos().Registrar(obj, out Mensaje);

                if (Id_Generado != 0)
                {

                    dgvData.Rows.Add(new object[]
                    {   "",
                        Id_Generado,
                        txtCodigo.Text,
                        txtNombre.Text,
                        txtDescripcion.Text,
                        ((OpcionCombo) cboTipo.SelectedItem).Valor.ToString(),
                        ((OpcionCombo) cboTipo.SelectedItem).Texto.ToString(),
                        "0",
                        "0.00",
                        "0.00",
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
                bool Resultado = new CN_Productos().Editar(obj, out Mensaje);

                if (Resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = txtId.Text;
                    row.Cells["Codigo_Produto"].Value = txtCodigo.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Descripcion_Producto"].Value = txtDescripcion.Text;
                    row.Cells["IdTipo"].Value = ((OpcionCombo)cboTipo.SelectedItem).Valor.ToString();
                    row.Cells["Tipo_Producto"].Value = ((OpcionCombo)cboTipo.SelectedItem).Texto.ToString();
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
            txtCodigo.Text = " ";
            txtNombre.Text = " ";
            txtDescripcion.Text = " ";
            cboTipo.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            txtCodigo.Select();

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
            if (dgvData.Columns[e.ColumnIndex].Name == "dataGridViewButtonColumn1")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["IdProductos"].Value.ToString();
                    txtCodigo.Text = dgvData.Rows[indice].Cells["Codigo_Producto"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = dgvData.Rows[indice].Cells["Descripcion_Producto"].Value.ToString();


                    foreach (OpcionCombo oc in cboTipo.Items)
                    {



                        if (Convert.ToInt32(oc.Valor) == Convert.ToUInt32(dgvData.Rows[indice].Cells["IdTipo"].Value))
                        {
                            int indice_Combo = cboTipo.Items.IndexOf(oc);
                            cboTipo.SelectedIndex = indice_Combo;
                            break;

                        }
                    }


                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        var estado = dgvData.Rows[indice].Cells["Estado_Producto"].Value.ToString() == "Activo" ? 1 : 0;


                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(estado))
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
                if (MessageBox.Show("Desea eliminar este producto", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string Mensaje = string.Empty;

                    Productos obj = new Productos()
                    {
                        IdProductos = Convert.ToInt32(txtId.Text),

                    };
                    bool Respuesta = new CN_Productos().Eliminar(obj, out Mensaje);

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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay información para exportar ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn colum in dgvData.Columns)
                {
                    if (colum.HeaderText != " " && colum.Visible)
                        dt.Columns.Add(colum.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),                          
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                           

                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte_Producto_{0}.xlsx", DateTime.Now.ToString("dd++yyyy++HHmmss"));
                savefile.Filter = "Excel Files  | *.xlsm";


                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var Hoja = wb.Worksheets.Add(dt, "Informe");
                        Hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte ha sido generado con exito ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

        }
    }
}
