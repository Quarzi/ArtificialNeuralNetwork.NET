namespace ArtificialNeuralNetwork
{
    interface ITransfer
    {
        double Transfer(double x);
        double TransferFirstOrderDerivative(double x);
    }
}
