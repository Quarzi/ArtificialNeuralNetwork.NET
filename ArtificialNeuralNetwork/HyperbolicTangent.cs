using System;

namespace ArtificialNeuralNetwork
{
    public class HyperbolicTangent : ITransfer
    {
        double ITransfer.Transfer(double x)
        {
            return (Math.Exp(2 * x) - 1) / (Math.Exp(2 * x) + 1);
        }

        double ITransfer.TransferFirstOrderDerivative(double x)
        {
            return 4 * Math.Exp(2 * x) / Math.Pow(Math.Exp(2 * x) + 1, 2);
        }
    }
}
