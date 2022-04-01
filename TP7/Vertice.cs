using System;
using System.Collections.Generic;

namespace TP7
{

	public class Vertice<T>
	{
		private int gradoEntrada = 0;
		public Vertice()
		{
		}
		
		private List<Arista<T>> adyacentes; 
    
		private T dato;
    
		private int posicion;
	
	    public Vertice(T d){
			dato = d;
			adyacentes = new List<Arista<T>>();
			
		}
    
		public T getDato() {
			return dato;
		}

		public void setDato(T unDato) {
			dato = unDato;
		}

		
		public int getPosicion() {
			return posicion;
		}
	
		public List<Arista<T>> getAdyacentes(){
			return adyacentes;
		}
	
		
		public void setPosicion(int pos){
			posicion = pos; 
		}

		public bool entradaCero()
		{
			return gradoEntrada == 0;
		}

		public void aumentarGradoEntrada()
		{
			gradoEntrada++;
		}		
		
	}
}
