using C_Datos;
using C_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocio
{
    public class CN_Cliente
    {
        private CD_Cliente objCD_Cliente = new CD_Cliente();


        public List<Cliente> Listar()
        {

            return objCD_Cliente.Listar();

        }


        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Identificacion == "")
            {
                Mensaje += "Es necesario el número de identificación del Cliente\n";
            }


            if (obj.Nombre_Cliente == "")
            {
                Mensaje += "Es necesario el nombre del Cliente\n";
            }

            if (obj.Email == "")
            {
                Mensaje += "Es necesario ingresar el email del Cliente\n";
            }




            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Cliente.Registrar(obj, out Mensaje);
            }
        }



        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Identificacion == "")
            {
                Mensaje += "Es necesario el número de identificación del Cliente\n";
            }


            if (obj.Nombre_Cliente == "")
            {
                Mensaje += "Es necesario el nombre del Cliente\n";
            }


            if (obj.Email == "")
            {
                Mensaje += "Es necesario ingresar el email del Cliente\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Cliente.Editar(obj, out Mensaje);
            }
        }



        public bool Eliminar(Cliente obj, out string Mensaje)
        {

            return objCD_Cliente.Eliminar(obj, out Mensaje);
        }

    }
}
