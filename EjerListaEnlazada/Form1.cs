using Recup2_ED_CS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjerListaEnlazada
{
    public partial class Form1 : Form
    {
        //creamos la lista enlazada 
        CLista Competidores = new CLista();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //primero crear la lista arriba con el nombre de nodo {PRIMERO , SIGUIENTE}
            // crear un nuevo nodo
            Nodo competidor = new Nodo();


            //juntamos la infomacion
            competidor.NroCorredor = int.Parse(txtNumero.Text);
            competidor.Nombre = txtNombre.Text;
            competidor.Carreras = int.Parse(txtParticipaciones.Text);
            competidor.Ganadas =int.Parse(txtGanadas.Text);

            // agregar el nodo a la lista
            Competidores.Insertar(competidor);

            // limpiar la interfaz
            txtNumero.Text = "";
            txtNombre.Text = "";
            txtParticipaciones.Text = "";
            txtGanadas.Text = "";
            // refrescar la grilla con los datos de los movimientos
            
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            MostrarCompetidores();
        }
        private void MostrarCompetidores()
        {
            List<Nodo> competidor = Competidores.Listar(); // obtener la lista de movimientos
            grCorredores.Rows.Clear(); // limpiar la grilla
            // recorrer todos los movimientos
            foreach (Nodo nodo in competidor)
            {
                grCorredores.Rows.Add(nodo.NroCorredor.ToString(), nodo.Nombre,
                    nodo.Carreras.ToString(), nodo.Ganadas.ToString());
            }

        }


        //Listar ganadores
        public List<Nodo> ListarGanadores()
        {

            List<Nodo> ganadores = Competidores.ListarGanadores(); // Obtener la lista de ganadores
            grGanadores.Rows.Clear(); // Limpiar la grilla

            //agregamos al datagrid
            foreach (Nodo nodo in ganadores)
            {
                grGanadores.Rows.Add(nodo.NroCorredor.ToString(), nodo.Nombre,
                    nodo.Carreras.ToString(), nodo.Ganadas.ToString());
            }

            return ganadores;
        }

        private void btnListarGanadores_Click(object sender, EventArgs e)
        {
            ListarGanadores();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Nodo> cantidadCompe = Competidores.Listar();

            int aux = 0;  // Empezamos con 0, ya que estamos contando

            foreach (Nodo nodo in cantidadCompe)
            {
                aux = aux + 1;  // Incrementamos aux por cada nodo encontrado
            }

            txtTotal.Text = aux.ToString();  // Mostramos el total en el TextBox

        }
    }
}

