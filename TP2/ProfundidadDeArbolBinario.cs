using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class ProfundidadDeArbolBinario 
    {
        ArbolBinario<int> arbol;
        public ProfundidadDeArbolBinario(ArbolBinario<int> arbol)
        {
            this.arbol = arbol;
        }
        public int SumaElementosProfundidad(int profundidad)
        {
			Cola<ArbolBinario<int>> cola = new Cola<ArbolBinario<int>>();
			ArbolBinario<int> aux;
            cola.Encolar(arbol);
            cola.Encolar(null);
            int prof = 0;
            int sumatoria = 0;
			
			while (!cola.EsVacia())
			{
				aux = cola.Desencolar();
                if (aux==null)
                {
                    prof++;
                    if (!cola.EsVacia())
                    {
                        cola.Encolar(null);
                    }
                }
                else
                {
                    if (prof <= profundidad)
                    {
                        sumatoria += aux.GetDatoRaiz();
                    }
                    if (aux.GetHijoIzquierdo() != null)
                    {
                        cola.Encolar(aux.GetHijoIzquierdo());
                    }
                    if (aux.GetHijoDerecho() != null)
                    {
                        cola.Encolar(aux.GetHijoDerecho());
                    }
                }
			}
			return sumatoria;
		}
    }
}
