using System;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {

            ArbolGeneral<int> a = new ArbolGeneral<int>(0);
            ArbolGeneral<int> a1 = new ArbolGeneral<int>(1);
            ArbolGeneral<int> a2 = new ArbolGeneral<int>(2);
            ArbolGeneral<int> a3 = new ArbolGeneral<int>(3);
            ArbolGeneral<int> a4 = new ArbolGeneral<int>(4);
            ArbolGeneral<int> a5 = new ArbolGeneral<int>(5);
            ArbolGeneral<int> a6 = new ArbolGeneral<int>(6);
            ArbolGeneral<int> a7 = new ArbolGeneral<int>(7);

            a.AgregarHijo(a1);
            a.AgregarHijo(a2);
            a1.AgregarHijo(a3);
            a1.AgregarHijo(a4);
            a2.AgregarHijo(a5);
            a2.AgregarHijo(a6);
            a3.AgregarHijo(a7);

            Console.WriteLine("***Preorden***"); a.Preorden();

            Console.WriteLine("\n\n***PostOrden***"); a.PostOrden();

            Console.WriteLine("\n\n***InOrden***"); a.InOrden();

            Console.WriteLine("\n\n***Por Niveles***"); a.PorNiveles();

            Console.WriteLine("\n\n***Por Niveles con Separacion***"); a.PorNivelesConSeparador();

            //Console.WriteLine("**La altura del arbol es "+a.Altura()+ "***\n");
            //Console.WriteLine("***El elemento que busca se encuentra a nivel " + a.Nivel(6) + " ***\n");
            Console.WriteLine("\n\n***El ancho del arbol es de: " + a.Ancho() + "***");

            Console.WriteLine("\n***Lleno una copia del arbol con 1000 litros de agua: ***");
            AguaPotable aguaPotable = new AguaPotable(a,1000);
            aguaPotable.GetArbol().PorNivelesConSeparador();
            Console.WriteLine("\n\n***Caudal mas chico:  " + aguaPotable.GetMenorCaudal()+"***");

            //Console.ReadKey();
        }
    }
}
