using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class EquipoMesa
    {
        public int FilaMesa { get; set; } // Fila de la mesa
        public int ColumnaMesa { get; set; } // Columna de la mesa
        public List<string> Equipo { get; set; } // Lista de equipos en la mesa

        public EquipoMesa()
        {
            Equipo = new List<string>(); // Inicializar la lista de equipos
        }
    }
}
