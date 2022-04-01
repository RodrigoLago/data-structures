using System;
using System.Collections.Generic;

namespace TP2
{

	public class Cola<T>
	{
		private List<T> datos = new List<T>();
	
		public void Encolar(T elem) {
			this.datos.Add(elem);
		}
	
		public T Desencolar() {
			T temp = this.datos[0];
			this.datos.RemoveAt(0);
			return temp;
		}
		
		public T Tope() {
			return this.datos[0]; 
		}
		
		public bool EsVacia() {
			return this.datos.Count == 0;
		}
	}
}
