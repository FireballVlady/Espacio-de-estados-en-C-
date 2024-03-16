using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class agente
    {
        public List<ESTADOS> Estados = new List<ESTADOS>();
        public void crearEstado(string pregunta)
        {
            ESTADOS estado = new ESTADOS(pregunta);
            Estados.Add(estado);
        }
    }
}
