using C_Datos;
using C_Entidad;
using System.Collections.Generic;

namespace C_Negocio
{
    public class CN_Permiso
    {

        private CD_Permiso objCD_Permiso = new CD_Permiso();
        public List<Permiso> Listar(int IdUsuario)
        {
            return objCD_Permiso.Listar(IdUsuario);
        }
    }
}
