using System;
using System.Collections.Generic;

using ArtificialNeuralNetwork.Extensions;

namespace ArtificialNeuralNetwork
{
    public class ArtificialNeuralNetwork
    {

        public enum TrainingMethods { GradientDescent };

        public double[] LastInput { get; private set; }
        public double[] LastOutput { get; private set; }
        public Trainer Trainer { get; set; }
        public List<Layer> Layers { get; set; }
        public Layer.TransferFunctions DefaultTransfer { get; set; }

        public bool IsAnnOkay
        {
            get
            {
                if (this.Layers.Count > 1)
                {
                    return true;
                }

                return false;
            }
        }
        
        public ArtificialNeuralNetwork(int numberOfInputNeurons, int numberOfHiddenLayers, int numberOfNeuronsPerHiddenLayer, int numberOfOutputNeurons, Layer.TransferFunctions tf)
        {
            this.DefaultTransfer = tf;
            this.InitializeNetwork(numberOfInputNeurons, numberOfHiddenLayers, numberOfNeuronsPerHiddenLayer, numberOfOutputNeurons);
        }

        public void InitializeNetwork(int numberOfInputNeurons, int numberOfHiddenLayers, int numberOfNeuronsPerHiddenLayer, int numberOfOutputNeurons)
        {
            //  Set default trainer with default parameters
            this.SetTrainer(TrainingMethods.GradientDescent);

            //  Initialize network
            this.Layers = new List<Layer>();

            //  Initialize input layer
            this.Layers.Add(new Layer("Input Layer (Neurons = " + numberOfInputNeurons.ToString() + " + 1)", numberOfInputNeurons, null, Layer.TransferFunctions.Bypass));

            //  Initialize hidden layers if any
            for (int i = 0; i < numberOfHiddenLayers; i++)
            {

                this.Layers.Add(new Layer("Hidden Layer #" + (i + 1).ToString() + " (Neurons = " + numberOfNeuronsPerHiddenLayer.ToString() + " + 1)", numberOfNeuronsPerHiddenLayer, this.Layers[i], this.DefaultTransfer));
                this.Layers[i].NextLayer = this.Layers[i + 1];
            }

            //  Initialize output layer
            this.Layers.Add(new Layer("Output Layer (Neurons = " + numberOfOutputNeurons.ToString() + " + 1)", numberOfOutputNeurons, this.Layers[this.Layers.Count - 1], this.DefaultTransfer));
            this.Layers[this.Layers.Count - 2].NextLayer = this.Layers[this.Layers.Count - 1];
        }

        public double[] FeedForward(double[] input)
        {
            this.LastInput = new double[input.Length];
            input.CopyTo(this.LastInput, 0);

            //  Feed-forward in each layer
            foreach (var layer in this.Layers)
            {
                input = layer.FeedForward(input);
            }

            //  Remove bias neuron from final output
            double[] output = input.Subvector(input.Length - 2);

            this.LastOutput = new double[output.Length];
            output.CopyTo(this.LastOutput, 0);

            return output;
        }

        public void SetTrainer(TrainingMethods trainer)
        {
            switch (trainer)
            {
                case TrainingMethods.GradientDescent:
                    this.Trainer = new BPGD(this);
                    break;
                default:
                    this.Trainer = new BPGD(this);
                    break;
            }
            
        }
    }
}
