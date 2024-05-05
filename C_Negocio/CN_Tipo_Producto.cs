using C_Datos;
using C_Entidad;
using System.Collections.Generic;

namespace C_Negocio
{
    public class CN_Tipo_Producto
    {
        private CD_Tipo_Producto objCD_Tipo_Producto = new CD_Tipo_Producto();

        public List<Tipo_Producto> Listar()
        {
            return objCD_Tipo_Producto.Listar();
        }

        //Metódo registrar Tipo de producto 

        public int Registrar(Tipo_Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la descripcion del Tipo_Producto\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Tipo_Producto.Registrar(obj, out Mensaje);
            }
        }



        //Metódo editar Tipo de producto 


        public bool Editar(Tipo_Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la Descripcion del Tipo_Producto\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Tipo_Producto.Editar(obj, out Mensaje);
            }
        }


        //Metódo Eliminar Tipo de producto 


        public bool Eliminar(Tipo_Producto obj, out string Mensaje)
        {

            return objCD_Tipo_Producto.Eliminar(obj, out Mensaje);
        }
    }
}

