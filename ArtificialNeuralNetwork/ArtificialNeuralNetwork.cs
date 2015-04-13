using System;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork
{
    public class ArtificialNeuralNetwork
    {
        public enum CostFunctions { MeanSquaredError, RootMeanSquaredError };
        public enum TrainingMethods { GradientDescent, GeneticAlgorithm }

        public int Epochs { get; set; }
        public int MiniBatchSize { get; set; }
        public double LearningRate { get; set; }
        public double Epsilon { get; set; }
        public double[] LastInput { get; private set; }
        public double[] LastOutput { get; private set; }

        public bool IsAnnOkay
        {
            get
            {
                if (this.networkLayers.Count > 1)
                {
                    return true;
                }

                return false;
            }
        }

        private List<Layer> networkLayers;
        private ICostFunction cost;

        public ArtificialNeuralNetwork(int numberOfInputNeurons, int numberOfHiddenLayers, int numberOfNeuronsPerHiddenLayer, int numberOfOutputNeurons)
        {
            this.InitializeNetwork(numberOfInputNeurons, numberOfHiddenLayers, numberOfNeuronsPerHiddenLayer, numberOfOutputNeurons);
        }

        public void InitializeNetwork(int numberOfInputNeurons, int numberOfHiddenLayers, int numberOfNeuronsPerHiddenLayer, int numberOfOutputNeurons)
        {
            //  Initialize network
            this.networkLayers = new List<Layer>();

            //  Initialize input layer
            this.networkLayers.Add(new Layer(numberOfInputNeurons));

            //  Initialize hidden layers if any
            for (int i = 0; i < numberOfHiddenLayers; i++)
            {
                this.networkLayers.Add(new Layer(numberOfNeuronsPerHiddenLayer, this.networkLayers[i].NumberOfNeurons));
            }

            //  Initialize output layer
            this.networkLayers.Add(new Layer(numberOfOutputNeurons, this.networkLayers[this.networkLayers.Count - 1].NumberOfNeurons));
        }

        public double[] FeedForward(double[] input)
        {
            this.LastInput = new double[input.Length];
            input.CopyTo(this.LastInput, 0);

            //  Feed-forward in each layer
            foreach (var layer in this.networkLayers)
            {
                input = layer.FeedForward(input);
            }

            //  Remove bias neuron from final output
            double[] output = input.Subvector(input.Length - 2);

            this.LastOutput = new double[output.Length];
            output.CopyTo(this.LastOutput, 0);

            return output;
        }

        public double[] AnnTrainingBatch(double[,] inputMatrix, double[,] targetMatrix, int batchSize = 30, int epochs = 1000, TrainingMethods tm = TrainingMethods.GradientDescent, CostFunctions cf = CostFunctions.MeanSquaredError)
        {
            int numberOfAnnInputs = this.networkLayers[0].NumberOfNeurons,
                numberOfAnnOutputs = this.networkLayers[this.networkLayers.Count - 1].NumberOfNeurons;

            double[] errors = new double[1].Zeros();

            //  Check dimensions for compatibility with each other and ANN
            if (inputMatrix.Rows() == numberOfAnnInputs && targetMatrix.Rows() == numberOfAnnOutputs && inputMatrix.Cols() == targetMatrix.Cols())
            {
                this.Epochs = epochs;
                this.LearningRate = 0.3;
                this.Epsilon = 0.0001;
                this.MiniBatchSize = batchSize;

                switch (cf)
                {
                    case CostFunctions.MeanSquaredError:
                        this.cost = new MeanSquaredError();
                        break;
                    case CostFunctions.RootMeanSquaredError:
                        break;
                    default:
                        break;
                }

                switch (tm)
                {
                    case TrainingMethods.GradientDescent:
                        errors = this.GradientDescentBackPropagationBatch(inputMatrix, targetMatrix);
                        break;
                    case TrainingMethods.GeneticAlgorithm:
                        break;
                    default:
                        break;
                }
            }

            return errors;
        }

        public double[] GradientDescentBackPropagationBatch(double[,] inputMatrix, double[,] targetMatrix)
        {
            int index = 0;
            List<double> errorDevelopment = new List<double>();
            Layer prevLayer, currentLayer, nextLayer;
            double errorIntegral, latestError = 1000000 * this.Epsilon;
            double[] input, target, output, errorRate, firstOrderDerivative;
            double[,] trimmedWeights;
            double[][,] deltaWeights = new double[this.networkLayers.Count][,];

            //  Process epochs
            for (int epoch = 0; epoch < this.Epochs && latestError > this.Epsilon; epoch++)
            {
                //  Wrap-over index if needed
                if (index >= inputMatrix.Cols()) index = 0;

                //  Process mini-batch, reset errorIntegral
                errorIntegral = 0;
                for (int batch = 0; batch < this.MiniBatchSize; batch++)
                {
                    //  Feed-forward input
                    input = inputMatrix.ExtractColumn(index);
                    target = targetMatrix.ExtractColumn(index);
                    output = this.FeedForward(input);

                    //  Calculate error
                    errorIntegral += this.cost.Cost(output, target);
                    errorRate = this.cost.CostFirstOrderDerivative(output, target);

                    //  Back-propagate error
                    for (int layer = this.networkLayers.Count - 1; layer > 0; layer--)
                    {
                        prevLayer = this.networkLayers[layer - 1];
                        currentLayer = this.networkLayers[layer];
                        firstOrderDerivative = currentLayer.BeforeTransfer.ApplyFunction(currentLayer.Transfer.TransferFirstOrderDerivative);

                        //  Check if last layer
                        if (layer == this.networkLayers.Count - 1)
                        {
                            errorRate = errorRate.HadamardProduct(firstOrderDerivative);
                        }
                        else    //  ... else
                        {
                            nextLayer = this.networkLayers[layer + 1];
                            trimmedWeights = nextLayer.Weights.RemoveColumn(nextLayer.Weights.Cols() - 1);

                            errorRate = trimmedWeights.Transpose().Multiply(errorRate).HadamardProduct(firstOrderDerivative);
                        }

                        if (deltaWeights[layer] == null)
                            deltaWeights[layer] = new double[currentLayer.Weights.Rows(), currentLayer.Weights.Cols()].Zeros();

                        deltaWeights[layer] = deltaWeights[layer].Add(errorRate.OuterProduct(prevLayer.LastOutput.ConcatenateVector(new double[] { currentLayer.Bias })));
                    }
                }

                //  Calculate mean error over the previous batch
                latestError = errorIntegral / (double)this.MiniBatchSize;
                errorDevelopment.Add(latestError);

                //  Update weights
                for (int layer = 1; layer < deltaWeights.Length; layer++)
                {
                    currentLayer = this.networkLayers[layer];

                    currentLayer.Weights = currentLayer.Weights.Subtract(deltaWeights[layer].Multiply(this.LearningRate / (double)this.MiniBatchSize));
                }

                index++;
            }

            return errorDevelopment.ToArray();
        }

        public double[] AnnTrainingOnline(double[,] inputMatrix, double[,] targetMatrix, int batchSize = 30, int epochs = 1000, TrainingMethods tm = TrainingMethods.GradientDescent, CostFunctions cf = CostFunctions.MeanSquaredError)
        {
            int numberOfAnnInputs = this.networkLayers[0].NumberOfNeurons,
                numberOfAnnOutputs = this.networkLayers[this.networkLayers.Count - 1].NumberOfNeurons;

            double[] errors = new double[1].Zeros();

            //  Check dimensions for compatibility with each other and ANN
            if (inputMatrix.Rows() == numberOfAnnInputs && targetMatrix.Rows() == numberOfAnnOutputs && inputMatrix.Cols() == targetMatrix.Cols())
            {
                this.Epochs = epochs;
                this.LearningRate = 0.3;
                this.Epsilon = 0.0001;
                this.MiniBatchSize = batchSize;

                switch (cf)
                {
                    case CostFunctions.MeanSquaredError:
                        this.cost = new MeanSquaredError();
                        break;
                    case CostFunctions.RootMeanSquaredError:
                        break;
                    default:
                        break;
                }

                switch (tm)
                {
                    case TrainingMethods.GradientDescent:
                        errors = this.GradientDescentBackPropagationOnline(inputMatrix, targetMatrix);
                        break;
                    case TrainingMethods.GeneticAlgorithm:
                        break;
                    default:
                        break;
                }
            }

            return errors;
        }

        public double[] GradientDescentBackPropagationOnline(double[,] inputMatrix, double[,] targetMatrix)
        {
            int index = 0;
            List<double> errorDevelopment = new List<double>();
            Layer prevLayer, currentLayer, nextLayer;
            double errorIntegral, latestError = 1000000 * this.Epsilon;
            double[] input, target, output, errorRate, firstOrderDerivative;
            double[,] trimmedWeights;
            double[][,] deltaWeights = new double[this.networkLayers.Count][,];
            double[] deltaBiases = new double[this.networkLayers.Count];

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
                output = this.FeedForward(input);

                //  Calculate error
                errorIntegral += this.cost.Cost(output, target);
                errorRate = this.cost.CostFirstOrderDerivative(output, target);

                //  Back-propagate error through layers
                for (int layer = this.networkLayers.Count - 1; layer > 0; layer--)
                {
                    prevLayer = this.networkLayers[layer - 1];
                    currentLayer = this.networkLayers[layer];
                    firstOrderDerivative = currentLayer.BeforeTransfer.ApplyFunction(currentLayer.Transfer.TransferFirstOrderDerivative);

                    //  Check if last layer
                    if (layer == this.networkLayers.Count - 1)
                    {
                        errorRate = errorRate.HadamardProduct(firstOrderDerivative);
                    }
                    else    //  ... else
                    {
                        nextLayer = this.networkLayers[layer + 1];
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
                    currentLayer = this.networkLayers[layer];

                    currentLayer.Weights = currentLayer.Weights.Subtract(deltaWeights[layer].Multiply(this.LearningRate / (double)this.MiniBatchSize));
                    currentLayer.Bias -= deltaBiases[layer];
                }

                index++;
            }

            return errorDevelopment.ToArray();
        }
    }
}
