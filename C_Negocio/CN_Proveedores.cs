using C_Datos;
using C_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Negocio
{
    public class CN_Proveedores
    {
        private CD_Proveedores objCD_Proveedores = new CD_Proveedores();


        public List<Proveedores> Listar()
        {

            return objCD_Proveedores.Listar();

        }


        public int Registrar(Proveedores obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Identificacion == "")
            {
                Mensaje += "Es necesario el número de identificación\n";
            }


            if (obj.Nombre_Empresa  == "")
            {
                Mensaje += "Es necesario el nombre de la empresa\n";
            }


            if (obj.Email == "")
            {
                Mensaje += "Es necesario el email\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Proveedores.Registrar(obj, out Mensaje);
            }
        }






        public bool Editar(Proveedores obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Identificacion == "")
            {
                Mensaje += "Es necesario el número de identificación del Proveedor\n";
            }


            if (obj.Nombre_Empresa== "")
            {
                Mensaje += "Es necesario el nombre de la empresa\n";
            }


            if (obj.Email == "")
            {
                Mensaje += "Es necesario  el email\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Proveedores.Editar(obj, out Mensaje);
            }
        }



        public bool Eliminar(Proveedores obj, out string Mensaje)
        {

            return objCD_Proveedores.Eliminar(obj, out Mensaje);
        }



    }

}
