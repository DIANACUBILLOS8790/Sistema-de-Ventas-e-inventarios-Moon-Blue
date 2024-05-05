using C_Datos;
using C_Entidad;
using System.Collections.Generic;

namespace C_Negocio



{
    public class CN_Usuario
    {
        private CD_Usuario objCD_Usuario = new CD_Usuario();


        public List<Usuario> Listar()
        {

            return objCD_Usuario.Listar();

        }


        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Identificacion == "")
            {
                Mensaje += "Es necesario el número de identificación del usuario\n";
            }


            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del usuario\n";
            }


            if (obj.Contraseña == "")
            {
                Mensaje += "Es necesario la contraseña del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objCD_Usuario.Registrar(obj, out Mensaje);
            }
        }






        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Identificacion == "")
            {
                Mensaje += "Es necesario el número de identificación del usuario\n";
            }


            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del usuario\n";
            }


            if (obj.Contraseña == "")
            {
                Mensaje += "Es necesario la contraseña del usuario\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objCD_Usuario.Editar(obj, out Mensaje);
            }
        }



        public bool Eliminar(Usuario obj, out string Mensaje)
        {

            return objCD_Usuario.Eliminar(obj, out Mensaje);
        }



    }
}
