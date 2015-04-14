using System;

using ArtificialNeuralNetwork.Extensions;

namespace ArtificialNeuralNetwork
{
    public class MeanSquaredError : ICostFunction
    {
        double ICostFunction.Cost(double[] output, double[] target)
        {
            return Math.Pow(target.Subtract(output).EuclideanLength(), 2) / 2;
        }

        double[] ICostFunction.CostFirstOrderDerivative(double[] output, double[] target)
        {
            return output.Subtract(target);
        }
    }
}
