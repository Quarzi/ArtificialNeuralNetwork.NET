using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork
{
    public class BPGD : Trainer
    {
        private ArtificialNeuralNetwork ann;

        public BPGD(ArtificialNeuralNetwork ann)
        {
            this.ann = ann;

            //  Initialize standard values
            this.Epochs = 300;
            this.LearningRate = 0.015;
            this.Epsilon = 0.01;
            this.SetCostFunction(CostFunctions.MeanSquaredError);
        }

        public override double[] TrainAnn(double[,] inputMatrix, double[,] targetMatrix, TrainingSchemes ts = TrainingSchemes.OnlineLearning)
        {
            double[] errorOutput = new double[1].Zeros();

            switch (ts)
            {
                case TrainingSchemes.OnlineLearning:
                    return this.TrainOnline(inputMatrix, targetMatrix);
            }

            return inputMatrix.ExtractColumn(0);
        }

        private double[] TrainOnline(double[,] inputMatrix, double[,] targetMatrix)
        {
            int index = 0;
            List<double> errorDevelopment = new List<double>();
            Layer prevLayer, currentLayer, nextLayer;
            double error = double.PositiveInfinity;
            double[] input, target, output, errorRate, firstOrderDerivative;
            double[,] trimmedWeights;
            double[][,] deltaWeights = new double[this.ann.Layers.Count][,];
            double[] deltaBiases = new double[this.ann.Layers.Count];

            //  Process epochs
            for (int epoch = 0; epoch < this.Epochs && error > this.Epsilon; epoch++)
            {
                //  Wrap-over index if needed
                if (index >= inputMatrix.Cols()) index = 0;

                //  Feed-forward input
                input = inputMatrix.ExtractColumn(index);
                target = targetMatrix.ExtractColumn(index);
                output = this.ann.FeedForward(input);

                //  Calculate error
                error = this.CostFunction.Cost(output, target); ;
                errorRate = this.CostFunction.CostFirstOrderDerivative(output, target);
                errorDevelopment.Add(error);

                //  Back-propagate error through layers
                for (int layer = this.ann.Layers.Count - 1; layer > 0; layer--)
                {
                    prevLayer = this.ann.Layers[layer - 1];
                    currentLayer = this.ann.Layers[layer];
                    firstOrderDerivative = currentLayer.BeforeTransfer.ApplyFunction(currentLayer.Transfer.TransferFirstOrderDerivative);

                    //  Check if last layer
                    if (layer == this.ann.Layers.Count - 1)
                    {
                        errorRate = errorRate.HadamardProduct(firstOrderDerivative);
                    }
                    else    //  ... else
                    {
                        nextLayer = this.ann.Layers[layer + 1];
                        trimmedWeights = nextLayer.Weights.RemoveColumn(nextLayer.Weights.Cols() - 1);

                        errorRate = trimmedWeights.Transpose().Multiply(errorRate).HadamardProduct(firstOrderDerivative);
                    }

                    if (deltaWeights[layer] == null)
                        deltaWeights[layer] = new double[currentLayer.Weights.Rows(), currentLayer.Weights.Cols()].Zeros();

                    deltaWeights[layer] = deltaWeights[layer].Add(errorRate.OuterProduct(prevLayer.LastOutput.ConcatenateVector(new double[] { currentLayer.Bias })));
                    deltaBiases[layer] += errorRate.EuclideanLength();
                }

                //  Update weights
                for (int layer = 1; layer < deltaWeights.Length; layer++)
                {
                    currentLayer = this.ann.Layers[layer];

                    currentLayer.Weights = currentLayer.Weights.Subtract(deltaWeights[layer].Multiply(this.LearningRate));
                    currentLayer.Bias -= deltaBiases[layer];

                    deltaWeights[layer].Zeros();
                    deltaBiases[layer] = 0;
                }

                index++;
            }

            return errorDevelopment.ToArray();
        }
    }
}
