using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidad
{
    public class Permiso
    {
        public int IdPermiso {  get; set; }
        public Rol oRol {  get; set; }
        public string Nombre_Menu { get; set; } 
        public string Fecha {  get; set; }  
    }
}
