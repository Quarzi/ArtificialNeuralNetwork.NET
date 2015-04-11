namespace ArtificialNeuralNetwork
{
    public class Layer
    {
        public enum TransferFunctions { Sigmoid, HyperbolicTangent };
        private ITransfer transfer;

        public double Bias { get; set; }
        public int NumberOfNeurons { get; private set; }
        public bool PassThrough { get; private set; }
        public double[,] Weights { get; private set; }
        public double[] BeforeTransfer { get; private set; }
        public double[] LastOutput { get; private set; }

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
                    this.PassThrough = true;                //  Input is passed through layer not affected by weighting and transfer function
                }
                else
                {
                    this.PassThrough = false;
                    this.Weights = new double[NumberOfNeurons, numberOfNeuronsPrevLayer + 1].Randomize(2);   //  ... + 1 Accounts for the bias neuron from previous layer
                    this.BeforeTransfer = new double[1].Zeros();
                }

                //  Select transfer
                switch (tf)
                {
                    case TransferFunctions.Sigmoid:
                        this.transfer = new Sigmoid();
                        break;
                    case TransferFunctions.HyperbolicTangent:
                        this.transfer = new HyperbolicTangent();
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
                
                //  Transfer weighted sum
                output = this.BeforeTransfer.Function(this.transfer.Transfer);
            }

            //  Set layer output to output vector
            output.CopyTo(this.LastOutput, 0);
            
            //  Concatenate output vector with layer bias
            output = output.ConcatenateVector(new double[] { this.Bias });
            
            return output;
        }
    }
}
