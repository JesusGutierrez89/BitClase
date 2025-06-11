using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class EquipoMesa
    {
        public int FilaMesa { get; set; } 
        public int ColumnaMesa { get; set; } 
        public List<string> Equipo { get; set; } 

        public EquipoMesa()
        {
            Equipo = new List<string>(); 
        }
    }
}
