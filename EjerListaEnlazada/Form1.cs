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

        //INSERTAR CON VERIFICADOR DE DUPLICIDAD
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



            // Verificar si el competidor con el mismo NroCorredor ya existe
            if (Competidores.Buscar(competidor.NroCorredor) != null)
            {
                MessageBox.Show("El competidor con el número " + competidor.NroCorredor + " ya existe.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Si ya existe, no lo insertamos
            }


            // agregar el nodo a la lista
            Competidores.Insertar(competidor);

            // limpiar la interfaz
            txtNumero.Text = "";
            txtNombre.Text = "";
            txtParticipaciones.Text = "";
            txtGanadas.Text = "";
            // refrescar la grilla con los datos de los movimientos
            
        }

       
        //MOSTRAR TODOS
        private void btnListar_Click(object sender, EventArgs e)
        {
            MostrarCompetidores();
        }


        //MOSTAR A TODOS
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


        //LISTAR A TODOS LOS GANADORES EN EL GRID EN EL GRID
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


        //lISTAR GANADORES
        private void btnListarGanadores_Click(object sender, EventArgs e)
        {
            ListarGanadores();
        }


        //BOTON CONSULTAR 
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


        //BOTON BUSCAR
        private void btnBusca_Click(object sender, EventArgs e)
        {

            //guardamos el valor a buscar
            int nroCompe = int.Parse(txtNumero.Text);

            // Usamos el método Buscar de la lista enlazada
            Nodo nodoEncontrado = Competidores.Buscar(nroCompe);

            // Verificamos si el nodo fue encontrado
            if (nodoEncontrado != null)
            {
                // Si se encuentra, mostramos la información del nodo
                //MessageBox.Show($"Cuenta encontrada: {nodoEncontrado.Cuenta}\n" );

                MessageBox.Show($"Corredor numero : {nodoEncontrado.NroCorredor}\n" +
                                $"Carreras ganadas: {nodoEncontrado.Ganadas}\n");
            }
            else
            {
                // Si no se encuentra, mostramos un mensaje de error
                MessageBox.Show("No se encontró ninguna cuenta con el número ingresado.");
            }
        }
      
        
        //BOTON ELIMINAR
        private void button1_Click(object sender, EventArgs e)
        {
            int nroCorredor = int.Parse(txtNumero.Text);


            Nodo compeEliminar = Competidores.Eliminar(nroCorredor);

            if (compeEliminar != null)
            {
                MessageBox.Show("Eliminado");

            }

            MostrarCompetidores();

        }
    }
}

