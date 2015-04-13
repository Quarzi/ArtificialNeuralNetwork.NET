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

            Console.WriteLine(" Input to ANN: ({0}) <-> Output from ANN: ({1})", input.VectorToString(), output.VectorToString());

            //  Generate data matrices for training of ANN as XOR gate
            Console.WriteLine("\n Training ANN ...\n");

            Random rand = new Random((int)DateTime.Now.ToBinary());
            const int numberOfInputSequences = 16;
            double[,] inputMatrix = new double[2, numberOfInputSequences], targetMatrix = new double[1, numberOfInputSequences];
            int x1, x2;

            for (int i = 0; i < numberOfInputSequences; i++)
            {
                x1 = rand.Next(0, 2);
                x2 = rand.Next(0, 2);

                inputMatrix[0, i] = x1;
                inputMatrix[1, i] = x2;
                targetMatrix[0, i] = x1 ^ x2;
            }

            double[] errorDev = ann.AnnTrainingBatch(inputMatrix, targetMatrix, 4, 10000);

            for (int i = 0; i < numberOfInputSequences; i++)
            {
                output = ann.FeedForward(inputMatrix.ExtractColumn(i));
                Console.WriteLine(" Input to ANN: ({0}) <-> Output from ANN: ({1})", inputMatrix.ExtractColumn(i).VectorToString(), output.VectorToString());
                Console.WriteLine(" ----------------------------------------------------------------------");
            }
            
            Console.ReadKey(false);
        }
    }
}
