using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Profesor
    {
        public string nrp { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string departamento { get; set; }
        public string password { get; set; }

        public Profesor(string nrp, string nombre, string apellidos, string email,  string departamento, string password) {
            this.nrp = nrp;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.departamento = departamento;
            this.password = password;
        }
        public Profesor()
        {
            this.nrp = "";
            this.nombre = "";
            this.apellidos = "";
            this.email = "";
            this.departamento = "";
            this.password = "";
        }
    }
}
