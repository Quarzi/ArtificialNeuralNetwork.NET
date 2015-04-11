using System;

using ArtificialNeuralNetwork;

namespace AnnTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = new double[] { 0, 0 }, output;

            ArtificialNeuralNetwork.ArtificialNeuralNetwork ann = new ArtificialNeuralNetwork.ArtificialNeuralNetwork(2, 1, 2, 1);
            
            output = ann.FeedForward(input);

            Console.WriteLine(" Input to ANN: ({0}) Output from ANN: ({1})", input.VectorToString(), output.VectorToString());
            Console.ReadKey(false);
        }
    }
}
