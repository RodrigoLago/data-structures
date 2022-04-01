using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class RedBinariaLlena
    {
        ArbolBinario<int> arbol;
        public RedBinariaLlena(ArbolBinario<int> arbol)
        {
            this.arbol = arbol;
        }
        public int RetardoReenvio()
        {
            Cola<ArbolBinario<int>> c = new Cola<ArbolBinario<int>>();
            ArbolBinario<int> aux;
            int retardoMax = 0;
            int retardoAux = 0;
            c.Encolar(arbol);
            c.Encolar(null);
            while (!c.EsVacia())
            {
                aux = c.Desencolar();
                if (aux == null)
                {
                    retardoMax += retardoAux;
                    retardoAux = 0;
                    if (!c.EsVacia())
                    {
                        c.Encolar(null);
                    }
                }
                else
                {
                    if (aux.GetDatoRaiz() > retardoAux)
                    {
                        retardoAux = aux.GetDatoRaiz();
                    }
                    if (aux.GetHijoIzquierdo() != null)
                    {
                        c.Encolar(aux.GetHijoIzquierdo());
                    }
                    if (aux.GetHijoDerecho() != null)
                    {
                        c.Encolar(aux.GetHijoDerecho());
                    }
                }
            }
            return retardoMax;
        }
    }
}
