using System;
using System.Collections.Generic;

namespace TP7
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo<T>
	{
		private List<Vertice<T>> vertices = new List<Vertice<T>>();
	
		public Grafo()
		{
		}
		
		public void agregarVertice(Vertice<T> v) {
			v.setPosicion(vertices.Count + 1);
			vertices.Add(v);
		}

		public void eliminarVertice(Vertice<T> v) {
			vertices.Remove(v);
		}

		public void conectar(Vertice<T> origen, Vertice<T> destino, int peso) {
			origen.getAdyacentes().Add(new Arista<T>(destino,peso));
		}

		public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			Arista<T> arista = origen.getAdyacentes().Find(a => a.getDestino().Equals(destino));
			origen.getAdyacentes().Remove(arista);
		}

		// public void desConectar(Vertice<T> origen, Vertice<T> destino) {
			// Arista<T> arista;
			// foreach(var a in origen.getAdyacentes()){
				// if(a.getDestino().Equals(destino))
					// arista = a;
			// }
			// origen.getAdyacentes().Remove(arista);			
		// }
		
		public List<Vertice<T>> getVertices() {
			return vertices;
		}

	
		public Vertice<T> vertice(int idx) {
			return this.vertices[idx];
		}
	

		public void DFS(Vertice<T> origen) {
			bool[] visitados = new bool[this.getVertices().Count];
			_DFS(origen, visitados);
			
		}
		
		private void _DFS(Vertice<T> origen, bool[] visitados){
			
			visitados[origen.getPosicion() - 1] = true;
			
			Console.Write(origen.getDato().ToString() + ", ");
			
			foreach(var ady in origen.getAdyacentes()){
				if(!visitados[ady.getDestino().getPosicion() - 1])
					_DFS(ady.getDestino(), visitados);
 			}
			
		}
		
		
		public void BFS(Vertice<T> origen) {
			bool[] visitados 		= new bool[this.getVertices().Count];
			Cola<Vertice<T>> c		= new Cola<Vertice<T>>();
			Vertice<T> verticeAux; 
			
			c.Encolar(origen);
			visitados[origen.getPosicion() - 1] = true;
			
			while(!c.EsVacia()){
				verticeAux = c.Desencolar();
				
				Console.Write(verticeAux.getDato().ToString() + ", ");
				
				foreach(var ady in verticeAux.getAdyacentes())
					if(!visitados[ady.getDestino().getPosicion() - 1]){
						c.Encolar(ady.getDestino());
						visitados[ady.getDestino().getPosicion() - 1] = true;
				}
			}						
		}
		
		
	}
}
