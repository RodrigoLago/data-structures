using System;

namespace TP3
{

	public class AVL{
		
		private IComparable dato;
		private AVL hijoIzquierdo;
		private AVL hijoDerecho;
		private int altura;
		
		public AVL(IComparable dato){
			this.dato = dato;
			altura = 0;
		}
		
		public IComparable GetDatoRaiz(){
			return this.dato;
		}
		
		public int GetAltura(){
			return this.altura;
		}
		
		public AVL GetHijoIzquierdo(){
			return this.hijoIzquierdo;
		}
		
		public AVL GetHijoDerecho(){
			return this.hijoDerecho;
		}
	
		public void AgregarHijoIzquierdo(AVL hijo){
			this.hijoIzquierdo = hijo;
		}

		public void AgregarHijoDerecho(AVL hijo){
			this.hijoDerecho = hijo;
		}
		
		public void EliminarHijoIzquierdo(){
			this.hijoIzquierdo = null;
		}
		
		public void EliminarHijoDerecho(){
			this.hijoDerecho = null;
		}
		
		public AVL Agregar(IComparable elem) {
			// inserta dato como en ABB:
			// si elem es mayor que el dato almacenado en la raiz...
			if(elem.CompareTo(this.dato) > 0){
				// si el subarbol derecho esta vacio, inserto elem 
				if(this.hijoDerecho == null)
					this.AgregarHijoDerecho(new AVL(elem));
				// si el arbol derecho no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoDerecho = this.hijoDerecho.Agregar(elem); 
			}
			// si elem es menor o igual...
			else{
				// si el subarbol iquierdo esta vacio, inserto elem 
				if(this.hijoIzquierdo == null)
					this.AgregarHijoIzquierdo(new AVL(elem));
				// si el arbol izquierdo no esta vacio, hago llamada recursiva a agregar()
				else
					this.hijoIzquierdo = this.hijoIzquierdo.Agregar(elem);
			}	
			
			// actualizo altura 
			this.ActualizarAltura();

			// chequeamos balance
			AVL nuevaRaiz = this;
			int balance = this.CalcularDesbalance();
					
			
			if(balance >= 2){ // entonces el lado derecho es mas alto -> rotacion con derecho
				// si elem > dato hijo derecho, entonces aplico rotacion simple
				if(elem.CompareTo(this.hijoDerecho.dato) > 0)
					nuevaRaiz = this.RotacionSimpleDerecha();
				else
					nuevaRaiz = this.RotacionDobleDerecha();
			}
			
			if(balance <= -2){// entonces el lado izquierdo es mas alto -> rotacion con izquierdo
				// si elem < dato hijo izquierdo, entonces aplico rotacion simple
				if(elem.CompareTo(this.hijoIzquierdo.dato) <= 0)
					nuevaRaiz = this.RotacionSimpleIzquierda();
				else
					nuevaRaiz = this.RotacionDobleIzquierda();
			}
			
			return nuevaRaiz;			
		}
		
		// rotacion simple CON derecho
		public AVL RotacionSimpleDerecha() {
			Console.WriteLine("Estoy haciendo una rotacion simple derecha");
			// referencia a nueva a raiz
			AVL nuevaRaiz = this.GetHijoDerecho();
			
			// cambio hijo derecho de raiz actual (this)
			//this.agregarHijoDerecho(nuevaRaiz.hijoIzquierdo);
			this.hijoDerecho = nuevaRaiz.hijoIzquierdo;
			
			// cambio hijo izquierdo de nueva raiz
			nuevaRaiz.AgregarHijoIzquierdo(this);
			
			// actualizamos altura de antigua raiz (this)
			this.ActualizarAltura();
			
			// actualizamos altura de nueva raiz 
			nuevaRaiz.ActualizarAltura();
			
			// retorno nueva raiz
			return nuevaRaiz;
		}
		
		// rotacion simple CON izquierdo
		public AVL RotacionSimpleIzquierda() {
			Console.WriteLine("Estoy haciendo una rotacion simple izquierda");
			// referencia a nueva a raiz
			AVL nuevaRaiz = this.GetHijoIzquierdo();
			
			// cambio hijo izquierdo de raiz actual (this)
			this.AgregarHijoIzquierdo(nuevaRaiz.hijoDerecho);
			
			// cambio hijo derecho de nueva raiz
			nuevaRaiz.AgregarHijoDerecho(this);
			
			// actualizamos altura de antigua raiz (this)
			this.ActualizarAltura();
			
			// actualizamos altura de nueva raiz 
			nuevaRaiz.ActualizarAltura();
			
			// retorno nueva raiz
			return nuevaRaiz;
		}
		
		// rotacion doble CON derecho
		public AVL RotacionDobleDerecha() {
			Console.WriteLine("Estoy haciendo una rotacion doble derecha");
			// 1ero: rotacion simple con izquierdo en hijo derecho
			this.hijoDerecho = this.hijoDerecho.RotacionSimpleIzquierda();
			
			// 2do: rotacion simple con derecho en raiz (this)
			return this.RotacionSimpleDerecha();
		}
		
		// rotacion doble CON izquierdo		
		public AVL RotacionDobleIzquierda() {
			Console.WriteLine("Estoy haciendo una rotacion doble izquierda");
			// 1ero: rotacion simple con derecho en hijo izquierdo
			this.hijoIzquierdo = this.hijoIzquierdo.RotacionSimpleDerecha();
			
			// 2do: rotacion simple con izquierdo en raiz (this)
			return this.RotacionSimpleIzquierda();
		}
		
		private void ActualizarAltura(){
			int alturaIzq = -1;
			int alturaDer = -1;
			
			if(this.hijoIzquierdo != null)
				alturaIzq = this.hijoIzquierdo.altura;
			
			if(this.hijoDerecho != null)
				alturaDer = this.hijoDerecho.altura;
			
			if(alturaDer > alturaIzq)
				this.altura = alturaDer + 1;
			else
				this.altura = alturaIzq + 1;
		}
		
		private int CalcularDesbalance(){
			int alturaIzq = -1;
			int alturaDer = -1;
			
			if(this.hijoIzquierdo != null)
				alturaIzq = this.hijoIzquierdo.altura;
			
			if(this.hijoDerecho != null)
				alturaDer = this.hijoDerecho.altura;
			
			return (alturaDer - alturaIzq);
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
			Cola<AVL> c = new Cola<AVL>();
			AVL arbolAux;
			
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

		public bool Incluye(IComparable elem)
		{

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


	}
}