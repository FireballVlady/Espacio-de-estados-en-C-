using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class ESTADOS
    {
        public string pregunta;
        public List<ListaEstados> EstadoSiguiente = new List<ListaEstados>();
        public ESTADOS(string dato)
        {
            this.pregunta = dato;
        }
        public void agregarEstado(string respuesta, ESTADOS estado)
        {
            ListaEstados auxiliar = new ListaEstados(respuesta, estado);
            EstadoSiguiente.Add(auxiliar);
        }
    }
}
