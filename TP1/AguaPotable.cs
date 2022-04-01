using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class AguaPotable
    {
        private ArbolGeneral<int> arbolPotable;
		private int menorCantLitros;
        public AguaPotable(ArbolGeneral<int> arbol,int litros)
        {
			arbolPotable = arbol;
			menorCantLitros = this.MenorCaudal(litros);
        }
		public ArbolGeneral<int> GetArbol()
        {
			return this.arbolPotable;
        }
		public int GetMenorCaudal()
        {
			return menorCantLitros;
        }
		public int MenorCaudal(int litros){
			//Genero una cola y un arbol auxiliar para ir desencolando y el auxiliar con litros
			Cola<ArbolGeneral<int>> cola = new Cola<ArbolGeneral<int>>();
			ArbolGeneral<int> aux;
			arbolPotable.SetDatoRaiz(litros);
			int litrosAux = litros;
			//Encolo el arbol 
			cola.encolar(arbolPotable);
			while (!cola.esVacia()){
				aux = cola.desencolar();
				if (!aux.EsHoja()){
					int litrosHijos = aux.GetDatoRaiz() / aux.GetHijos().Count;
                    if (litrosHijos<litros)
						litrosAux = litrosHijos;
					foreach (var hijo in aux.GetHijos()){
						hijo.SetDatoRaiz(litrosHijos);
						cola.encolar(hijo);
					}
				}
			}
			menorCantLitros = litrosAux;
			return litrosAux;
		}
    }
}
