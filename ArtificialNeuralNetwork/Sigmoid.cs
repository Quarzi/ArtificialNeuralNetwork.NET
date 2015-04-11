using System;

namespace ArtificialNeuralNetwork
{
    public class Sigmoid : ITransfer
    {
        double ITransfer.Transfer(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        double ITransfer.TransferFirstOrderDerivative(double x)
        {
            return Math.Exp(-x) / Math.Pow(1 + Math.Exp(-x), 2);
        }
    }
}
