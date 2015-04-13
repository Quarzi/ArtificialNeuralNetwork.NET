namespace ArtificialNeuralNetwork
{
    public interface ITransfer
    {
        double Transfer(double x);
        double TransferFirstOrderDerivative(double x);
    }
}
