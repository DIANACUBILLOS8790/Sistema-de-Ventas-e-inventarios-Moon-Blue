using C_Datos;
using C_Entidad;
using System.Collections.Generic;

namespace C_Negocio
{
    public class CN_Rol
    {
        private CD_Rol objCD_Rol = new CD_Rol();
        public List<Rol> Listar()
        {
            return objCD_Rol.listar();
        }
    }
}
