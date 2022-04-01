using System;

namespace TP3
{
	public class ArbolBinarioBusqueda{
		
		private IComparable dato;
		private ArbolBinarioBusqueda hijoIzquierdo;
		private ArbolBinarioBusqueda hijoDerecho;
		
		public ArbolBinarioBusqueda(IComparable dato){
			this.dato = dato;
		}
		
		public IComparable GetDatoRaiz(){
			return this.dato;
		}
		
		public ArbolBinarioBusqueda GetHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public ArbolBinarioBusqueda GetHijoDerecho(){
			return this.hijoDerecho;
		}
		
		public void AgregarHijoIzquierdo(ArbolBinarioBusqueda hijo){
			this.hijoIzquierdo = hijo;
		}

		public void AgregarHijoDerecho(ArbolBinarioBusqueda hijo){
			this.hijoDerecho = hijo;
		}
		
		public void EliminarHijoIzquierdo(){
			this.hijoIzquierdo = null;
		}
		
		public void EliminarHijoDerecho(){
			this.hijoDerecho = null;
		}
		
		public void Agregar(IComparable elem) {
			// si elem es mayor que el dato almacenado en la raiz...
			if(elem.CompareTo(this.dato) > 0){
				// si el subarbol derecho esta vacio, inserto elem 
				if(this.hijoDerecho == null)
					this.AgregarHijoDerecho(new ArbolBinarioBusqueda(elem));
				// si el arbol derecho no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoDerecho.Agregar(elem);
			}
			// si elem es menor o igual...
			else{
				// si el subarbol iquierdo esta vacio, inserto elem 
				if(this.hijoIzquierdo == null)
					this.AgregarHijoIzquierdo(new ArbolBinarioBusqueda(elem));
				// si el arbol izquierdo no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoIzquierdo.Agregar(elem);
			}			
		}

		public void AgregarConjunto(IComparable[] elem)
		{
            for (int i = 0; i < elem.Length; i++)
            {
				// si elem es mayor que el dato almacenado en la raiz...
				if (elem[i].CompareTo(this.dato) > 0)
				{
					// si el subarbol derecho esta vacio, inserto elem 
					if (this.hijoDerecho == null)
						this.AgregarHijoDerecho(new ArbolBinarioBusqueda(elem[i]));
					// si el arbol derecho no esta vacio, hago llamada recursiva a agregar()
					else
						this.hijoDerecho.Agregar(elem[i]);
				}
				// si elem es menor o igual...
				else
				{
					// si el subarbol iquierdo esta vacio, inserto elem 
					if (this.hijoIzquierdo == null)
						this.AgregarHijoIzquierdo(new ArbolBinarioBusqueda(elem[i]));
					// si el arbol izquierdo no esta vacio, hago llamada recursiva a agregar()
					else
						this.hijoIzquierdo.Agregar(elem[i]);
				}
			}
		}

		public bool Incluye(IComparable elem) {
            
            if (elem.CompareTo(this.dato) == 0)
            {
				return true;
            }
			// si elem es mayor que el dato almacenado en la raiz, voy al hijo derecho
			if (elem.CompareTo(this.dato) > 0)
			{
				if (this.hijoDerecho != null)
					return this.hijoDerecho.Incluye(elem);
			}
			// si elem es mayor que el dato almacenado en la raiz, voy al hijo izquierdo
			else if (elem.CompareTo(this.dato) < 0)
			{
				if (this.hijoIzquierdo != null)
					return this.hijoIzquierdo.Incluye(elem);
			}
			return false;
		}

		public void Inorden() {
			// hijo izquierdo (recursivamente)
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.Inorden();
			
			// raiz
			Console.Write(this.GetDatoRaiz() + " ");
			
			// hijo derecho (recursivamente)
			if(this.hijoDerecho != null)
				this.hijoDerecho.Inorden();
		}
		
		public void Preorden() {
			// primero raiz
			Console.Write(this.GetDatoRaiz() + " ");
			
			// hijo izquierdo (recursivamente)
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.Preorden();
			
			// hijo derecho (recursivamente)
			if(this.hijoDerecho != null)
				this.hijoDerecho.Preorden();
		}
		
		public void Postorden() {
			// hijo izquierdo (recursivamente)
			if(this.hijoIzquierdo != null)
				this.hijoIzquierdo.Postorden();
			
			// hijo derecho (recursivamente)
			if(this.hijoDerecho != null)
				this.hijoDerecho.Postorden();
			
			// raiz
			Console.Write(this.GetDatoRaiz() + " ");
		}
		
		public void RecorridoPorNiveles() {
			Cola<ArbolBinarioBusqueda> c = new Cola<ArbolBinarioBusqueda>();
			ArbolBinarioBusqueda arbolAux;
			
			c.Encolar(this);
			
			while(!c.EsVacia()){
				arbolAux = c.Desencolar();
				
				Console.Write(arbolAux.GetDatoRaiz() + " ");
				
				if(arbolAux.hijoIzquierdo != null)
					c.Encolar(arbolAux.hijoIzquierdo);
				
				if(arbolAux.hijoDerecho != null)
					c.Encolar(arbolAux.hijoDerecho);
			}			
		}
	}
}