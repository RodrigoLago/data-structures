using System;

namespace TP2
{
	public class ArbolBinario<T>
	{
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;
	
		
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
	
		public T GetDatoRaiz() {
			return this.dato;
		}
	
		public ArbolBinario<T> GetHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> GetHijoDerecho() {
			return this.hijoDerecho;
		}
	
		public void AgregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo = hijo;
		}
	
		public void AgregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho = hijo;
		}
	
		public void EliminarHijoIzquierdo() {
			this.hijoIzquierdo = null;
		}
	
		public void EliminarHijoDerecho() {
			this.hijoDerecho = null;
		}
	
		public bool EsHoja() {
			return this.hijoIzquierdo == null && this.hijoDerecho == null;
		}
		
		public void Inorden() {
			// hijo izquierdo
			if(this.GetHijoIzquierdo() != null)
				this.GetHijoIzquierdo().Inorden();
			
			// raiz
			Console.Write(GetDatoRaiz() + " ");
			
			// hijo derecho
			if(this.GetHijoDerecho() != null)
				this.GetHijoDerecho().Inorden();	
		}
		
		public void PreOrden() {
			// raiz
			Console.Write(GetDatoRaiz() + " ");
			
			// hijos
			if(this.GetHijoIzquierdo() != null)
				this.GetHijoIzquierdo().PreOrden();
			
			if(this.GetHijoDerecho() != null)
				this.GetHijoDerecho().PreOrden();			
		}
		
		public void PostOrden() {
			// hijos
			if(this.GetHijoIzquierdo() != null)
				this.GetHijoIzquierdo().PostOrden();
			
			if(this.GetHijoDerecho() != null)
				this.GetHijoDerecho().PostOrden();
			
			// raiz
			Console.Write(GetDatoRaiz() + " ");
		}
		
		public void PorNiveles() {
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolAux;
			
			c.Encolar(this);
			
			while(!c.EsVacia()){
				arbolAux = c.Desencolar();
				
				Console.Write(arbolAux.GetDatoRaiz() + " ");
				
				if(arbolAux.GetHijoIzquierdo() != null)
					c.Encolar(arbolAux.GetHijoIzquierdo());
				
				if(arbolAux.GetHijoDerecho() != null)
					c.Encolar(arbolAux.GetHijoDerecho());				
			}
		}
	
		public int ContarHojas() {
			Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolAux;
			int contador = 0;
			cola.Encolar(this);

			while (!cola.EsVacia())
			{
				arbolAux = cola.Desencolar();
				if (arbolAux.EsHoja())
                {
					contador ++;
                }

				if (arbolAux.GetHijoIzquierdo() != null)
					cola.Encolar(arbolAux.GetHijoIzquierdo());

				if (arbolAux.GetHijoDerecho() != null)
					cola.Encolar(arbolAux.GetHijoDerecho());
			}
			return contador;
		}
		
		public void RecorridoEntreNiveles(int min,int max) {
			Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolAux;
			int nivel = 0;
			cola.Encolar(this);
			cola.Encolar(null);
			Console.Write("Nivel 0:  ");
			while (!cola.EsVacia())
			{
				arbolAux = cola.Desencolar();
				if (arbolAux == null)
				{
                    if (!cola.EsVacia())
                    {
						cola.Encolar(null);
						nivel++;
                        Console.Write("\nNivel " + nivel+ ":  ");
					}
				}
				else
				{
					if (nivel >= min && nivel <= max)
					{
						Console.Write(arbolAux.GetDatoRaiz()+" ");
					}
					if (arbolAux.GetHijoIzquierdo() != null)
						cola.Encolar(arbolAux.GetHijoIzquierdo());
					if (arbolAux.GetHijoDerecho() != null)
						cola.Encolar(arbolAux.GetHijoDerecho());
				}
			}
		}
	}
}
