using System;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArbolBinario<int> arbol = new ArbolBinario<int>(1);
            //ArbolBinario<int> hijoIzquierdo = new ArbolBinario<int>(2);
            //ArbolBinario<int> hijoDerecho = new ArbolBinario<int>(5);
            //ArbolBinario<int> hijoDerecho2 = new ArbolBinario<int>(8);

            //arbol.AgregarHijoIzquierdo(hijoIzquierdo);
            //arbol.AgregarHijoDerecho(hijoDerecho);

            //hijoIzquierdo.AgregarHijoIzquierdo(new ArbolBinario<int>(30));
            //hijoIzquierdo.AgregarHijoDerecho(new ArbolBinario<int>(4));

            //hijoDerecho.AgregarHijoIzquierdo(new ArbolBinario<int>(6));
            //hijoDerecho.AgregarHijoDerecho(new ArbolBinario<int>(7));
            //hijoDerecho.AgregarHijoDerecho(hijoDerecho2);


            ////Console.WriteLine(arbol.ContarHojas());
            //arbol.RecorridoEntreNiveles(0, 12);
            //ProfundidadDeArbolBinario profundidad = new ProfundidadDeArbolBinario(arbol);
            //RedBinariaLlena red = new RedBinariaLlena(arbol);

            //Console.WriteLine("\n"+profundidad.SumaElementosProfundidad(2));
            //Console.WriteLine("\n" + red.RetardoReenvio());
            //Heap<int> heap = new Heap<int>(false);
            //heap.Agregar(13);
            //heap.Agregar(10);
            //heap.Agregar(30);
            //heap.Agregar(9);
            //heap.Agregar(7);
            //heap.Agregar(8);
            //heap.Agregar(4);
            //heap.Agregar(15);
            //foreach (int x in heap.GetHeap())
            //{
            //    Console.Write(x + " ");
            //}


            Heap<int> heap2 = new Heap<int>(false);

            heap2.Agregar(new int[] {13,10,30,9,7,8,4,15});
            
            foreach (int x in heap2.GetHeap())
            {
                Console.Write(x + " ");
            }
        }
    }
}
