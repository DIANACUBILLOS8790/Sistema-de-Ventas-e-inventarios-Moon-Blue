using C_Datos;
using C_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
