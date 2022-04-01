using System;
using System.Collections.Generic;

namespace TP1
{
	public class ArbolGeneral<T>
	{
		private T dato;
		private readonly List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}

		public T GetDatoRaiz() {
			return this.dato;
		}
		public void SetDatoRaiz(T dato)
        {
			this.dato = dato;
        }
		public List<ArbolGeneral<T>> GetHijos() {
			return hijos;
		}
		public void AgregarHijo(ArbolGeneral<T> hijo) {
			this.GetHijos().Add(hijo);
		}
		public void EliminarHijo(ArbolGeneral<T> hijo) {
			this.GetHijos().Remove(hijo);
		}
		public bool EsHoja() {
			return this.GetHijos().Count == 0;
		}
		public int Altura() {
			int altura = 0;
			if (this.EsHoja())
			{
				return 0;
			}
			else
			{
				foreach (ArbolGeneral<T> hijo in this.GetHijos())
				{
					if (hijo.Altura() > altura)
					{
						altura = hijo.Altura();
					}
				}
			}
			return 1 + altura;
		}
		public int Ancho()
		{
			//Genero una cola y un arbol auxiliar para ir desencolando, y la variable ancho iniciando en 0
			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> aux;
			int ancho = 1;
			int anchoaux = 0;
			//Encolo el arbol y luego un nulo
			cola.encolar(this);
			cola.encolar(null);
			while (!cola.esVacia())
			{
				aux = cola.desencolar();
				//Este chequeo sirve para cuando me topo con un null (un null significa que aumento de nivel)
				if (aux == null)
				{
					//Este chequeo sirve para saber si no es el ultimo null de todos. En ese caso se cortaria el bucle simplemente
					if (!cola.esVacia())
					{
						//Le inserto un null a la cola, aumento el nivel y comparo los anchos
						cola.encolar(null);
						if (anchoaux > ancho)
						{
							ancho = anchoaux;
							anchoaux = 0;
						}
					}
				}
				else
				{
					//Si el elemento por el cual voy NO es null, entonces lo tengo que procesar, en este caso lo imprimo:
					foreach (var hijo in aux.GetHijos())
					{
						cola.encolar(hijo);
						anchoaux++;
					}
				}
			}
			return ancho;
		}
		public int Nivel(T dato)
        {
			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> aux;
			int nivel = 0;
			cola.encolar(this);
			cola.encolar(null);
			while (!cola.esVacia())
			{
				aux = cola.desencolar();
				if (aux == null)
				{
					if (!cola.esVacia())
					{
						cola.encolar(null);
						nivel++;
					}
				}
				else
				{
                    if (aux.GetDatoRaiz().Equals(dato))
                    {
						return nivel;
                    }
					foreach (var hijos in aux.GetHijos())
					{
						cola.encolar(hijos);
					}
				}
			}
			return -1;
		}
		public int NivelRecursivo(T dato,int nivel)
		{
			int a = 0;
            if (this.GetDatoRaiz().ToString().Equals(dato.ToString()))
            {
				return nivel;
            }
			else
			{
                foreach (ArbolGeneral<T> item in this.GetHijos())
                {
					a = item.NivelRecursivo(dato, nivel+1);
                    if (a!=-1)
                    {
						return a;
                    }
                }
				return -1;
			}
		}
		
		
		//Recorridos
		public void Preorden()
        {
			//Primero proceso el dato raiz
			Console.Write(this.dato.ToString()+" ");
            //Luego proceso sus hijos
			foreach (ArbolGeneral<T> hijo in this.GetHijos())
            {
				hijo.Preorden();
            }
        }
		public void PostOrden()
        {
			//Primero proceso los hijos
			foreach (ArbolGeneral<T> hijo in this.GetHijos())
			{
				hijo.PostOrden();
			}
			//Despues proceso el dato raiz
			Console.Write(this.dato.ToString()+" ");
		}
		public void InOrden()
        {
            //Primero el hijo izquierdo
            if (!this.EsHoja())
            {
				this.GetHijos()[0].InOrden();
			}
			//Luego la raiz
			Console.Write(this.GetDatoRaiz()+" ");
            //Por ultimo los hijos restantes
            if (!this.EsHoja())
            {
				for (int i = 1; i < this.GetHijos().Count; i++)
				{
					this.GetHijos()[i].InOrden();
				}
			}
        }
		public void PorNiveles()
        {
			//Genero una cola y un arbol auxiliar para ir desencolando
			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> aux;
			//Encolo el arbol
			cola.encolar(this);

            while (!cola.esVacia())
            {
				aux = cola.desencolar();
				Console.Write(aux.GetDatoRaiz()+" ");
				//Voy encolando los hijos a la cola para que vayan siendo procesados
                foreach (var hijos in aux.GetHijos())
                {
					cola.encolar(hijos);
                }
            }
        }
		public void PorNivelesConSeparador()
		{
			//Genero una cola y un arbol auxiliar para ir desencolando, y la variable nivel iniciando en 0
			Cola<ArbolGeneral<T>> cola = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> aux;
			int nivel = 0;
			//Encolo el arbol y luego un nulo
			cola.encolar(this);
			cola.encolar(null);
			Console.Write("Nivel "+nivel+": ");
			while (!cola.esVacia())
			{
				aux = cola.desencolar();
				//Este chequeo sirve para cuando me topo con un null (un null significa que aumento de nivel)
				if (aux == null)
				{
					//Este chequeo sirve para saber si no es el ultimo null de todos. En ese caso se cortaria el bucle simplemente
					if (!cola.esVacia())
					{
						//Le inserto un null a la cola, aumento el nivel y muestro que se inicia con el nivel siguiente
						cola.encolar(null);
						nivel++;
						Console.WriteLine();
						Console.Write("Nivel " + nivel + ": ");
					}
				}
				else
				{
					//Si el elemento por el cual voy NO es null, entonces lo tengo que procesar, en este caso lo imprimo:
					Console.Write(aux.GetDatoRaiz() + " ");
					foreach (var hijos in aux.GetHijos())
					{
						cola.encolar(hijos);
					}
				}
			}
		}
	}
}
