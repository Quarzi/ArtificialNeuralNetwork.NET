using ArtificialNeuralNetwork.Extensions;

namespace ArtificialNeuralNetwork
{
    public class Layer
    {
        public enum TransferFunctions { Sigmoid, HyperbolicTangent };

        public double Bias { get; set; }
        public double[,] Weights { get; set; }
        public int NumberOfInputNeurons { get; private set; }
        public int NumberOfNeurons { get; private set; }
        public bool PassThrough { get; private set; }
        public double[] BeforeTransfer { get; private set; }
        public double[] LastOutput { get; private set; }

        public ITransfer Transfer { get; private set; }

        public Layer(int numberOfNeurons, int numberOfNeuronsPrevLayer = 0, TransferFunctions tf = TransferFunctions.Sigmoid, double bias = 1)
        {
            if (numberOfNeurons > 0)
            {
                this.NumberOfNeurons = numberOfNeurons;     //  Excluding bias-neuron
                this.LastOutput = new double[numberOfNeurons];
                this.Bias = 1;

                //  Determine if it is a input layer or not
                if (numberOfNeuronsPrevLayer == 0)
                {
                    this.PassThrough = true;                //  Input is passed through layer not affected by weighting and transfer function (Utilized as input layer)
                }
                else
                {
                    this.PassThrough = false;
                    this.NumberOfInputNeurons = numberOfNeuronsPrevLayer + 1;   //  Accounting for bias neuron in previous layer
                    this.Weights = new double[NumberOfNeurons, numberOfNeuronsPrevLayer + 1].Randomize(2);   //  ... + 1 Accounts for the bias neuron from previous layer
                    this.BeforeTransfer = new double[1].Zeros();
                }

                //  Select transfer
                switch (tf)
                {
                    case TransferFunctions.Sigmoid:
                        this.Transfer = new Sigmoid();
                        break;
                    case TransferFunctions.HyperbolicTangent:
                        this.Transfer = new HyperbolicTangent();
                        break;
                }
            }
        }

        public double[] FeedForward(double[] input)
        {
            double[] output = new double[this.NumberOfNeurons].Zeros();

            //  Calculate output
            if (this.PassThrough)
            {
                input.CopyTo(output, 0);
            }
            else
            {
                //  Apply weights to input
                this.BeforeTransfer = Weights.Multiply(input);
                
                //  Transfer weighted sum through layer
                output = this.BeforeTransfer.ApplyFunction(this.Transfer.Transfer);
            }

            //  Set layer output to output vector
            output.CopyTo(this.LastOutput, 0);
            
            //  Concatenate output vector with layer bias
            output = output.ConcatenateVector(new double[] { this.Bias });
            
            return output;
        }


    }
}
