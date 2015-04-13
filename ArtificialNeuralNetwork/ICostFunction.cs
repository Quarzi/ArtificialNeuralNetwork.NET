namespace ArtificialNeuralNetwork
{
    interface ICostFunction
    {
        double Cost(double[] output, double[] target);
        double[] CostFirstOrderDerivative(double[] output, double[] target);
    }
}