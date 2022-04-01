using System;

namespace TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArbolBinarioDe Busqueda
            //ArbolBinarioBusqueda arbol2 = new ArbolBinarioBusqueda(3);
            //IComparable[] array = { 10, 5, 15, 17, 2, 7, 12 };
            //arbol2.AgregarConjunto(array);
            
            
            AVL avl = new AVL(80);
            avl.Agregar(66);
            avl.Agregar(95);
            avl.Agregar(85);
            avl.Agregar(70);
            avl.Agregar(67);
            Imprimir.Arbol(avl);


        }
    }
}
