﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork
{
    public class ArtificialNeuralNetwork
    {
        private List<Layer> networkLayers;

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
    }
}
