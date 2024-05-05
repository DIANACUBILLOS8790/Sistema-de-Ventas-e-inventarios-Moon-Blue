using C_Datos;
using C_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
