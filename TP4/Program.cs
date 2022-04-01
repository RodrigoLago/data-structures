using System;

namespace TP4
{
    class Program
    {
        static void Main(string[] args)
        {
            TablaHash tabla = new TablaHash();
            Empleado empleado1= new Empleado(0, "Pepito", 50);
            tabla.AgregarEmpleado(empleado1.dni, empleado1);
            Console.WriteLine(tabla.AccederAEmpleado(50));
        }
    }
}
