using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialNeuralNetwork
{
    public abstract class Trainer
    {
        public enum TrainingSchemes { OnlineLearning };
        public enum CostFunctions { MeanSquaredError };

        public int Epochs { get; set; }
        public double LearningRate { get; set; }
        public double Epsilon { get; set; }
        public ICostFunction CostFunction { get; protected set; }
        public TrainingSchemes TrainingScheme { get; protected set; }

        public abstract double[] TrainAnn(double[,] inputMatrix, double[,] targetMatrix);

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

        public void SetTrainingScheme(TrainingSchemes ts)
        {
            this.TrainingScheme = ts;
        }
    }
}
