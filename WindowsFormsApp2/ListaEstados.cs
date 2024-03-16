using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class ListaEstados
    {
        public ESTADOS EstadoSig;
        public string Respuesta;
        public ListaEstados(string respuesta, ESTADOS estado)
        {
            Respuesta = respuesta;
            this.EstadoSig = estado;
        }
    }
}
