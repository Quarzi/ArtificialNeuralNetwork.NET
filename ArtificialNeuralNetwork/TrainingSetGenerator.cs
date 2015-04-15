using System;

using ArtificialNeuralNetwork.Extensions;

namespace ArtificialNeuralNetwork
{
    public class TrainingSetGenerator
    {
        public enum Signals { XOR, Quadratic, Linear, Trigonometric };
      
        public TrainingSet TrainingSet { get; set; }
        public Signals Signal { get; private set; }
        public bool NormalizeData { get; private set; }

        public TrainingSetGenerator(Signals signal = Signals.Quadratic)
        {
            this.NormalizeData = true;

            this.SetSignal(signal);
        }

        public void SetSignal(Signals signal)
        {
            this.Signal = signal;
        }

        public TrainingSet GenerateData()
        {
            switch (this.Signal)
            {
                case Signals.XOR:
                    return XorGenerator();
                    
                case Signals.Quadratic:
                    return new TrainingSet();
                    
                case Signals.Linear:
                    return new TrainingSet();
                    
                case Signals.Trigonometric:
                    return new TrainingSet();
            }

            return new TrainingSet();
        }

        public TrainingSet XorGenerator()
        {
            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[2, 4]{{0,0,1,1}, {0,1,0,1}};;
            ts.TargetMatrix = new double[1, 4].Zeros();

            for (int i = 0; i < 4; i++)
            {
                ts.TargetMatrix[0,i] = Convert.ToDouble(Convert.ToBoolean(ts.InputMatrix[0,i]) ^ Convert.ToBoolean(ts.InputMatrix[1,i]));
            }

            return ts;
        }
    }
}
