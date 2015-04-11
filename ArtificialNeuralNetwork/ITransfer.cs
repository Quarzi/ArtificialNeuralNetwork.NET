using System;

namespace ArtificialNeuralNetwork
{
    public interface ITransfer
    {
        public double Transfer(double x);
        public double TransferFirstOrderDerivative(double x);
    }
}
