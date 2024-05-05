using Sistema_de_Ventas_e_inventarios_Moon_Blue.Utilidades;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sistema_de_Ventas_e_inventarios_Moon_Blue
{
    public partial class form_Registro_ventas : Form
    {
        public form_Registro_ventas()
        {
            InitializeComponent();
        }

      

        private void form_Registro_ventas_Load(object sender, System.EventArgs e)
        {
            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

        }


        private void txtfechainicio_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, System.EventArgs e)
        {

        }

        private void btnbuscarreporte_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}
