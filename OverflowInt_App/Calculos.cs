using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverflowInt_App
{
    public class Calculos
    {
        public int CalculoTrajetoria(int timeBoxNumber, int velocity)
        {
            int numeroBase = timeBoxNumber;
            int expoente = velocity;

            int valor = (int)Math.Pow(numeroBase, expoente);

            Debug.WriteLine(valor.ToString());
            return valor;
        }
    }
}
