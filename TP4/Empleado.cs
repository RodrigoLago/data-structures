using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    public class Empleado
    {
        public string nombre { set; get; }
        public int numero { set; get; }
        public int dni { set; get; }
        public Empleado(int numero, string nombre, int dni)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.dni = dni;
        }
        public override string ToString()
        {
            return "Empleado: "+this.nombre+"   Dni:" +this.dni+"   Numero:"+this.numero;
        }
    }
}
