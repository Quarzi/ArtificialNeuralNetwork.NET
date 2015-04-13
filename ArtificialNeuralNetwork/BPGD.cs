using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork
{
    public class BPGD : ITrainer
    {
        public enum TrainingSchemes { OnlineLearning };
        public enum CostFunctions { MeanSquaredError };
    
        public int Epochs { get; set; }
        public int MiniBatchSize { get; set; }
        public double LearningRate { get; set; }
        public double Epsilon { get; set; }
        public ICostFunction CostFunction { get; private set; }
        public TrainingSchemes TrainingScheme { get; private set; }

        private ArtificialNeuralNetwork ann;
        
        public BPGD(ArtificialNeuralNetwork ann, CostFunctions cf = CostFunctions.MeanSquaredError, TrainingSchemes ts = TrainingSchemes.OnlineLearning)
        {
            this.ann = ann;

            //  Initialize standard values
            this.Epochs = 100;
            this.MiniBatchSize = 10;
            this.LearningRate = 0.05;
            this.Epsilon = 0.001;

            this.TrainingScheme = ts;
            this.SetCostFunction(cf);
        }

        double[] ITrainer.TrainAnn(double[,] inputMatrix, double[,] targetMatrix)
        {
            double[] errorOutput = new double[1].Zeros();

            switch (this.TrainingScheme)
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
            double errorIntegral, latestError = 1000000 * this.Epsilon;
            double[] input, target, output, errorRate, firstOrderDerivative;
            double[,] trimmedWeights;
            double[][,] deltaWeights = new double[this.ann.Layers.Count][,];
            double[] deltaBiases = new double[this.ann.Layers.Count];

            //  Process epochs
            for (int epoch = 0; epoch < this.Epochs && latestError > this.Epsilon; epoch++)
            {
                //  Wrap-over index if needed
                if (index >= inputMatrix.Cols()) index = 0;

                //  Process mini-batch, reset errorIntegral
                errorIntegral = 0;

                //  Feed-forward input
                input = inputMatrix.ExtractColumn(index);
                target = targetMatrix.ExtractColumn(index);
                output = this.ann.FeedForward(input);

                //  Calculate error
                errorIntegral += this.CostFunction.Cost(output, target);
                errorRate = this.CostFunction.CostFirstOrderDerivative(output, target);

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
                    deltaBiases[layer] += Math.Sqrt(errorRate.DotProduct(errorRate));

                }

                //  Calculate mean error over the previous batch
                latestError = errorIntegral;// / (double)this.MiniBatchSize;
                errorDevelopment.Add(latestError);

                //  Update weights
                for (int layer = 1; layer < deltaWeights.Length; layer++)
                {
                    currentLayer = this.ann.Layers[layer];

                    currentLayer.Weights = currentLayer.Weights.Subtract(deltaWeights[layer].Multiply(this.LearningRate / (double)this.MiniBatchSize));
                    currentLayer.Bias -= deltaBiases[layer];
                }

                index++;
            }

            return errorDevelopment.ToArray();
        }

        public void SetCostFunction(CostFunctions cf)
        {
            switch (cf)
            {
                case CostFunctions.MeanSquaredError:
                    this.CostFunction = new MeanSquaredError();
                    break;
                default:
                    this.CostFunction = new MeanSquaredError();
                    break;
            }
        }
}
}
