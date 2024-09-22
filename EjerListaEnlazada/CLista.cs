using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recup2_ED_CS
{
    public class CLista
    {
        // propiedades
        public Nodo Primero { get; set; }
        public Nodo Ultimo { get; set; }

        // constructor
        public CLista()
        {
            Primero = null;
            Ultimo = null;
        }

        // creamos un nuevo nodo para agregar
        public void Crear(Nodo nuevo)
        {
            if (Primero == null && Ultimo == null)
            {
                Primero = nuevo;
                Ultimo = nuevo;
            }
            else
            {
                Insertar(nuevo);
            }
        }

        // el INSERTAR mantiene ordenada la lista por el campo "Numero" de menor a mayor
        public void Insertar(Nodo nuevo)
        {

            
            if (Primero != null && Ultimo != null) // si los aputadores NO son nulos
            {
                // el nodo nuevo se enlaza según el crterio de orden establecido para la lista


                // caso 1: el nodo nuevo es menor al primero de la lista
                if (nuevo.NroCorredor < Primero.NroCorredor) // el orden está dado por el numero de corredor
                {
                    nuevo.Siguiente = Primero; // el nuevo pasa a ser el primero
                    Primero = nuevo;
                }
                // caso 2: el nuevo es mayor al ultimo
                if (nuevo.NroCorredor > Ultimo.NroCorredor)
                {
                    Ultimo.Siguiente = nuevo; // el nuevo pasa a ser el ultimo
                    Ultimo = nuevo;
                }


                // caso 3: el nuevo es mayor que el primero y menor al ultimo
                if (nuevo.NroCorredor > Primero.NroCorredor && nuevo.NroCorredor < Ultimo.NroCorredor)
                {
                    // hay que recorrer los nodos con 2 auxiliares, desde el primero
                    Nodo anterior = null;
                    Nodo auxiliar = Primero;

                    //mientras el número de corredor del nodo nuevo (nuevo.NroCorredor) sea mayor que el número de corredor del nodo actual (auxiliar.NroCorredor)
                    while (nuevo.NroCorredor > auxiliar.NroCorredor)
                    {
                        anterior = auxiliar;     // se avanza al siguiente nodo
                        auxiliar = auxiliar.Siguiente;
                    }
                    anterior.Siguiente = nuevo;
                    nuevo.Siguiente = auxiliar; // se enlaza el nuevo entre los 2 auxiliares
                }
            }
            else
            {
                Crear(nuevo);
            }
        }


        public List<Nodo> Listar()
        {
            List<Nodo> competidores = new List<Nodo>();

            //este codigo es igual , sirve para recorrer el nodo e ir listando 
            Nodo auxiliar = Primero; // se recorre desde el primero
            while (auxiliar != null)
            {
                competidores.Add(auxiliar); // guardar el nodo en la lista
                auxiliar = auxiliar.Siguiente; // avanza al siguiente
            }

            return competidores;
        }

        // Método para listar ganadores según las condiciones: más de 2 carreras ganadas y 5 o más participaciones
        public List<Nodo> ListarGanadores()
        {
            List<Nodo> ganadores = new List<Nodo>(); // Lista para almacenar los ganadores

            Nodo auxiliar = Primero; // Nodo auxiliar para recorrer la lista

            while (auxiliar != null)
            {
                // Verifica si el corredor cumple las condiciones
                if (auxiliar.Ganadas > 2 && auxiliar.Carreras >= 5)
                {
                    ganadores.Add(auxiliar); // Agrega el nodo a la lista de ganadores
                }
                auxiliar = auxiliar.Siguiente; // Avanza al siguiente nodo
            }

            return ganadores; // Devuelve la lista de ganadores
        }



        public Nodo Buscar(int nro)
        {
            Nodo nodo = null;

            return nodo;
        }
    }
}
