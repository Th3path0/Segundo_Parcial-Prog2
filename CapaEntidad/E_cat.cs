using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_cat
    {
        public int Idcontactos { get => idcontactos; set => idcontactos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Celular { get => celular; set => celular = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }

        private string nombre;
        private string apellido;
        private int celular;
        private DateTime fecha_nacimiento;
        private int idcontactos;
    }
}
