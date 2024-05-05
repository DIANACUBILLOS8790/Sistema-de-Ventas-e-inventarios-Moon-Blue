using C_Datos;
using C_Entidad;
using System.Collections.Generic;

namespace C_Negocio
{
    public class CN_Productos
    {
        private CD_Productos objCD_Productos = new CD_Productos();


        public List<Productos> Listar()
        {

            return objCD_Productos.Listar();

        }


        public int Registrar(Productos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo_Producto == "")
            {
                Mensaje += "Es necesario el código del Producto\n";
            }


            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }

            if (obj.Descripcion_Producto == "")
            {
                Mensaje += "Es necesario la descripcion del Producto\n";
            }


            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Productos.Registrar(obj, out Mensaje);
            }
        }


        public bool Editar(Productos obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo_Producto == "")
            {
                Mensaje += "Es necesario el código del Producto\n";
            }


            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del Producto\n";
            }


            if (obj.Descripcion_Producto == "")
            {
                Mensaje += "Es necesario la descripción del Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Productos.Editar(obj, out Mensaje);
            }
        }



        public bool Eliminar(Productos obj, out string Mensaje)
        {

            return objCD_Productos.Eliminar(obj, out Mensaje);
        }

    }
}
