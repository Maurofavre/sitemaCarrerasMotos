using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recup2_ED_CS
{
    public class Nodo
    {
        public int NroCorredor { get; set; }

        public string Nombre { get; set; }

        public int Ganadas { get; set; }

        public int Carreras { get; set; }

        public Nodo Siguiente { get; set; }

        // constructor
        public Nodo()
        {
            NroCorredor = 0;
            Nombre = "";
            Ganadas = 0;
            Carreras = 0;
            Siguiente = null;
        }
    }
}
