using System;
using System.Collections.Generic;

namespace TP4
{
    public class TablaHash
    {
        private List<Empleado>[] arreglo;
        public TablaHash()
        {
            arreglo = new List<Empleado>[21];
            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = new List<Empleado>();
            }
        }
        public void AgregarEmpleado(int dni, Empleado empleado)
        {
            int clave = dni%23;
            bool existe = false;
            foreach(Empleado emp in arreglo[clave])
            {
                if(emp.dni == dni)
                {
                    existe = true;
                    break;
                }
            }
            if(!existe)
            {
                arreglo[clave].Add(empleado);
            }
        }

        public Empleado AccederAEmpleado(int dni)
        {
            foreach (Empleado empleado in arreglo[dni%23])
            {
                if(empleado.dni == dni)
                {
                    return empleado;
                }
            }
            Console.WriteLine("No existe el empleado con ese dni");
            return null;
        }
    }
}