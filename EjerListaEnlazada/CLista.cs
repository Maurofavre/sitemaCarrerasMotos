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


        // INSERTAR 
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

        //LISTAR A TODOS 
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

        // LISTAR LOS GANADORES CON LA CONDICION DE TENER 2 GANADAS
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

   
        //Buscar en los nodos
        public Nodo Buscar(int nroCompe)
        {
            Nodo auxiliar = Primero; // Creamos un nodo auxiliar para recorrer la lista

            // Recorremos toda la lista  Este ciclo while continúa ejecutándose mientras el nodo actual (representado por auxiliar) no sea null.
            while (auxiliar != null)
            {
                if (auxiliar.NroCorredor == nroCompe) // Si encontramos la cuenta buscada
                {
                              
                    return auxiliar; // Devolvemos el nodo encontrado  
                }

                auxiliar = auxiliar.Siguiente; // Avanzamos al siguiente nodo, pregunta si no es null y sigue igual
            }

            // Si no encontramos el nodo, retornamos null
            return null;
        }


        public Nodo Eliminar(int nroCorredor)
        {
            Nodo anterior = null; //Crea un puntero anterior que inicialmente es null, ya que no hay un nodo antes del primer nodo.
            Nodo auxiliar = Primero; //

            // Recorremos la lista hasta encontrar el nodo que queremos eliminar
            while (auxiliar != null)
            {
                if (auxiliar.NroCorredor == nroCorredor) // Si encontramos la cuenta buscada
                {
                    if (anterior == null) // Si el anterior al encontrado es null (osea que seria el primero )
                    {
                        Primero = auxiliar.Siguiente; //Primero seria auxiliar que tmb es primero, pero apuntando al siguiente que seria 2, por ende no hay mas 1 
                    }
                    else
                    {
                        anterior.Siguiente = auxiliar.Siguiente; // Saltamos el nodo que queremos eliminar
                    }

                    // Si el nodo eliminado es el último nodo, actualizamos el puntero Ultimo
                    if (auxiliar == Ultimo)
                    {
                        Ultimo = anterior; //Hace que el ultimo pase a ser el anterior nodo 
                    }

                    return auxiliar; // Devolvemos el nodo encontrado y eliminado
                }

                anterior = auxiliar; // se actualiza anterior para que apunte al nodo actual.
                auxiliar = auxiliar.Siguiente; // Se mueve el puntero auxiliar al siguiente nodo en la lista
            }

            // Si no encontramos el nodo, retornamos null
            return null;
        }
    }

}
