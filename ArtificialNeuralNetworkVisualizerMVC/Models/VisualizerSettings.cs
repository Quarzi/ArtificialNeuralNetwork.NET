using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ann = ArtificialNeuralNetwork;
using ArtificialNeuralNetwork;
using System.ComponentModel.DataAnnotations;

namespace ArtificialNeuralNetworkVisualizerMVC.Models
{
    public class VisualizerSettings
    {
        public int NumberOfInputs { get; set; }
        public int NumberOfOutputs { get; set; }
        public int NumberOfHiddenLayers { get; set; }
        public int NumberOfNeuronPerHiddenLayer { get; set; }
        public List<Layer> LayersList { get; set; }
        public Layer.TransferFunctions TransferFunction { get; set; }
        public Ann.ArtificialNeuralNetwork.TrainingMethods TrainingMethod { get; set; }
        public Trainer.TrainingSchemes TrainingScheme { get; set; }
        public Trainer.CostFunctions CostFunction { get; set; }
        public double LerningRate { get; set; }
        public double Epsilon { get; set; }
        public int Epochs { get; set; }

        public VisualizerSettings()
        {
            this.NumberOfInputs = 1;
            this.NumberOfOutputs = 1;
            this.NumberOfHiddenLayers = 1;
            this.NumberOfNeuronPerHiddenLayer = 2;

            this.LayersList = new List<Layer>();

            this.TransferFunction = Layer.TransferFunctions.HyperbolicTangent;
            this.TrainingMethod = Ann.ArtificialNeuralNetwork.TrainingMethods.GradientDescent;
            this.TrainingScheme = Trainer.TrainingSchemes.OnlineLearning;
            this.CostFunction = Trainer.CostFunctions.MeanSquaredError;

            this.LerningRate = 0.05;
            this.Epsilon = 0.001;
            this.Epochs = 500;
        }
    }
}