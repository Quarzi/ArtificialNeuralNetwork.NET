using ArtificialNeuralNetwork.Extensions;

namespace ArtificialNeuralNetwork
{
    public class Layer
    {
        public enum TransferFunctions { Bypass, Sigmoid, HyperbolicTangent };

        public double Bias { get; set; }
        public double[,] Weights { get; set; }
        public Layer PreviousLayer { get; private set; }
        public Layer NextLayer { get; set; }
        //public int NumberOfInputNeurons { get; private set; }   //  Before summation (Previous layer)
        public int NumberOfNeurons { get; private set; }        //  After summation

        public double[] BeforeTransfer { get; private set; }
        public double[] LastOutput { get; private set; }
        public string Text { get; set; }

        public ITransfer Transfer { get; private set; }
        public TransferFunctions TransferFunction { get; private set; }

        public Layer(string name, int numberOfNeurons, Layer previousLayer = null, TransferFunctions tf = TransferFunctions.Sigmoid, double bias = -1)
        {
            this.Text = name;
            this.TransferFunction = tf;
            this.NumberOfNeurons = numberOfNeurons;     //  Excluding bias-neuron
            this.BeforeTransfer = new double[numberOfNeurons].Zeros();
            this.LastOutput = new double[numberOfNeurons].Zeros();
            this.PreviousLayer = previousLayer;
            this.NextLayer = null;
            this.Bias = bias;

            if (numberOfNeurons > 0)
            {
                switch (tf)
                {
                    case TransferFunctions.Bypass:
                        return;
                    case TransferFunctions.Sigmoid:
                        this.Transfer = new Sigmoid();
                        break;
                    case TransferFunctions.HyperbolicTangent:
                        this.Transfer = new HyperbolicTangent();
                        break;
                }

                this.Weights = new double[NumberOfNeurons, previousLayer.NumberOfNeurons + 1].Randomize();   //  ... + 1 Accounts for the bias neuron from previous layer [0.0 -> 1.0]
            }
        }

        public override string ToString()
        {
            return this.Text;
        }

        public double[] FeedForward(double[] input)
        {
            double[] output = new double[this.NumberOfNeurons].Zeros();

            //  Calculate output
            if (this.TransferFunction == TransferFunctions.Bypass)
            {
                try
                {
                    input.CopyTo(output, 0);
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
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

        public void SetTransfer (TransferFunctions tf)
        {
            if (this.TransferFunction == TransferFunctions.Bypass || tf == TransferFunctions.Bypass) return;

            this.TransferFunction = tf;
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

        public void SetNumberOfNeurons(int nrNeurons)
        {
            if (this.NumberOfNeurons != nrNeurons && nrNeurons > 0)
            {
                this.NumberOfNeurons = nrNeurons;
                this.BeforeTransfer = new double[nrNeurons].Zeros();
                this.LastOutput = new double[nrNeurons].Zeros();
                this.Weights = new double[nrNeurons, this.PreviousLayer.NumberOfNeurons + 1].Randomize();   //   [0.0 -> 1.0]
            }
        }

        public void SetNumberOfInputNeurons(int nrNeurons)
        {
            if (this.PreviousLayer.NumberOfNeurons != nrNeurons && nrNeurons > 0)
            {
                this.BeforeTransfer = new double[nrNeurons].Zeros();
                this.LastOutput = new double[nrNeurons].Zeros();
                this.Weights = new double[this.NumberOfNeurons, nrNeurons + 1].Randomize();   //   [0.0 -> 1.0]
            }
        }
    }
}
