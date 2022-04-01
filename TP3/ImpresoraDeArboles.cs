using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3
{
    public class Imprimir
    {
        public static void Arbol(ArbolBinarioBusqueda arbol, int padding = 2)
        {
            if (arbol.GetDatoRaiz() != null)
            {
                if (arbol.GetHijoDerecho() != null)
                {
                    Arbol(arbol.GetHijoDerecho(), padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (arbol.GetHijoDerecho() != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(arbol.GetDatoRaiz().ToString() + "\n ");
                if (arbol.GetHijoIzquierdo() != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Arbol(arbol.GetHijoIzquierdo(), padding + 4);
                }
            }
        }
        public static void Arbol(ArbolBinario<object> arbol, int padding = 2)
        {
            if (arbol.GetDatoRaiz() != null)
            {
                if (arbol.GetHijoDerecho() != null)
                {
                    Arbol(arbol.GetHijoDerecho(), padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (arbol.GetHijoDerecho() != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(arbol.GetDatoRaiz().ToString() + "\n ");
                if (arbol.GetHijoIzquierdo() != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Arbol(arbol.GetHijoIzquierdo(), padding + 4);
                }
            }
        }
        public static void Arbol(AVL arbol, int padding=2)
        {
            if (arbol.GetDatoRaiz() != null)
            {
                if (arbol.GetHijoDerecho() != null)
                {
                    Arbol(arbol.GetHijoDerecho(), padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (arbol.GetHijoDerecho() != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(arbol.GetDatoRaiz().ToString() + "\n ");
                if (arbol.GetHijoIzquierdo() != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Arbol(arbol.GetHijoIzquierdo(), padding + 4);
                }
            }
        }
        
    }
}
