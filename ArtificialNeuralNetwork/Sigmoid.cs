using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork
{
    public class Sigmoid : ITransfer
    {
        public double Transfer(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double TransferFirstOrderDerivative(double x)
        {
            return Math.Exp(-x) / Math.Pow(1 + Math.Exp(-x), 2);
        }
    }
}
