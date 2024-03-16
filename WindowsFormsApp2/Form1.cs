using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        private const string V = ",";
     
        char[] characters = V.ToCharArray();
        int numeroEstados;
        String[] preguntas;
        String[] respuestas;

        agente q = new agente();
        ESTADOS Actual;
        public Form1()
        {
            InitializeComponent();
        }
        private void proceso(ESTADOS estado)
        {
            Actual = estado;
            Lectura.Text = Actual.pregunta;
            Combox.Items.Clear();
            foreach (ListaEstados elemento in Actual.EstadoSiguiente)
            {
                Combox.Items.Add(elemento.Respuesta);
            }
        } 

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Import_Click(object sender, EventArgs e)
        {
            q = new agente();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"..\";
            openFileDialog.Filter = "Archivo de espacio de estados(*.ia)|*.ia";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader leer = new StreamReader(openFileDialog.FileName);
                    preguntas = leer.ReadLine().Split(characters);
                    numeroEstados = preguntas.Length;
                    respuestas = leer.ReadLine().Split(characters);
                    for (int i = 0; i < numeroEstados; i++)
                    {

                        q.crearEstado(preguntas[i]);
                    }
                    leer.ReadLine();
                    for (int i = 0; i < numeroEstados; i++)
                    {
                        string[] transiciones = leer.ReadLine().Split('\t');
                        if (transiciones[i] != "")
                        {
                            for (int t = 0; t < transiciones.Length; t++)
                            {
                                string numeroEstado = transiciones[t];
                                if (numeroEstado != "null")
                                {
                                    int estado = Convert.ToInt32(numeroEstado);
                                    string transicion = respuestas[t].ToString();
                                    q.Estados[i].agregarEstado(transicion, q.Estados[estado]);

                                }
                            }
                        }
                        proceso(q.Estados[0]);
                    }
                   
                }
                finally { }

            }
        }

        private void Combox_SelectedIndexChanged(object sender, EventArgs e)
        {
            proceso(Actual.EstadoSiguiente[Combox.SelectedIndex].EstadoSig);
        }

        private void Aceptacion_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
