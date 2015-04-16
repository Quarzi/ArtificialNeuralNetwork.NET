using System;

using ArtificialNeuralNetwork.Extensions;

namespace ArtificialNeuralNetwork
{
    public class TrainingSetGenerator
    {
        public enum Signals { OR, AND, XOR, Cubic, Quadratic, Linear, Trigonometric, Sigmoid, HyperbolicTangent };

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
                case Signals.OR:
                    return OrGenerator();

                case Signals.AND:
                    return AndGenerator();

                case Signals.XOR:
                    return XorGenerator();

                case Signals.Cubic:
                    return CubicGenerator();

                case Signals.Quadratic:
                    return QuadraticGenerator();

                case Signals.Linear:
                    return LinearGenerator();

                case Signals.Trigonometric:
                    return TrigGenerator();
                
                case Signals.Sigmoid:
                    return SigmoidGenerator();
                
                case Signals.HyperbolicTangent:
                    return TangentGenerator();
            }

            return new TrainingSet();
        }

        private TrainingSet CubicGenerator()
        {
            const double minX = -4, maxX = 4, stepSize = 0.5;
            const int numberOfElementsInX = (int)((maxX - minX) / stepSize) + 1;

            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[1, numberOfElementsInX].Zeros();
            ts.TargetMatrix = new double[1, numberOfElementsInX].Zeros();

            int index = 0;
            for (double x = minX; x <= maxX; x += stepSize, index++)
            {
                ts.InputMatrix[0, index] = x;
                ts.TargetMatrix[0, index] = Math.Pow(x,3) + 1;
            }

            if (this.NormalizeData)
            {
                //  Normalize input
                double min = ts.InputMatrix.Min();

                if (min < 0)
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(-min);
                }

                double max = ts.InputMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.InputMatrix = ts.InputMatrix.Multiply(1.0 / max);

                //  Normalize output
                min = ts.TargetMatrix.Min();

                if (min < 0)
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(-min);
                }

                max = ts.TargetMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.TargetMatrix = ts.TargetMatrix.Multiply(1.0 / max);
            }

            return ts;
        }

        private TrainingSet OrGenerator()
        {
            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[2, 4] { { 0, 0, 1, 1 }, { 0, 1, 0, 1 } }; ;
            ts.TargetMatrix = new double[1, 4].Zeros();

            for (int i = 0; i < 4; i++)
            {
                ts.TargetMatrix[0, i] = Convert.ToDouble(Convert.ToBoolean(ts.InputMatrix[0, i]) | Convert.ToBoolean(ts.InputMatrix[1, i]));
            }

            return ts;
        }

        private TrainingSet AndGenerator()
        {
            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[2, 4] { { 0, 0, 1, 1 }, { 0, 1, 0, 1 } }; ;
            ts.TargetMatrix = new double[1, 4].Zeros();

            for (int i = 0; i < 4; i++)
            {
                ts.TargetMatrix[0, i] = Convert.ToDouble(Convert.ToBoolean(ts.InputMatrix[0, i]) & Convert.ToBoolean(ts.InputMatrix[1, i]));
            }

            return ts;
        }
        
        private TrainingSet XorGenerator()
        {
            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[2, 4] { { 0, 0, 1, 1 }, { 0, 1, 0, 1 } }; ;
            ts.TargetMatrix = new double[1, 4].Zeros();

            for (int i = 0; i < 4; i++)
            {
                ts.TargetMatrix[0, i] = Convert.ToDouble(Convert.ToBoolean(ts.InputMatrix[0, i]) ^ Convert.ToBoolean(ts.InputMatrix[1, i]));
            }

            return ts;
        }

        private TrainingSet LinearGenerator()
        {
            const double minX = -4, maxX = 4, stepSize = 0.5;
            const int numberOfElementsInX = (int)((maxX - minX) / stepSize) + 1;

            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[1, numberOfElementsInX].Zeros();
            ts.TargetMatrix = new double[1, numberOfElementsInX].Zeros();

            int index = 0;
            for (double x = minX; x <= maxX; x += stepSize, index++)
            {
                ts.InputMatrix[0, index] = x;
                ts.TargetMatrix[0, index] = 2 * x + 1;
            }

            if (this.NormalizeData)
            {
                //  Normalize input
                double min = ts.InputMatrix.Min();
                
                if (min < 0)
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(-min);
                }

                double max = ts.InputMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.InputMatrix = ts.InputMatrix.Multiply(1.0 / max);

                //  Normalize output
                min = ts.TargetMatrix.Min();

                if (min < 0)
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(-min);
                }

                max = ts.TargetMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.TargetMatrix = ts.TargetMatrix.Multiply(1.0 / max);
            }

            return ts;
        }

        private TrainingSet QuadraticGenerator()
        {
            const double minX = -4, maxX = 4, stepSize = 0.5;
            const int numberOfElementsInX = (int)((maxX - minX) / stepSize) + 1;

            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[1, numberOfElementsInX].Zeros();
            ts.TargetMatrix = new double[1, numberOfElementsInX].Zeros();

            int index = 0;
            for (double x = minX; x <= maxX; x += stepSize, index++)
            {
                ts.InputMatrix[0, index] = x;
                ts.TargetMatrix[0, index] = 2 * Math.Pow(x,2) + 1;
            }

            if (this.NormalizeData)
            {
                //  Normalize input
                double min = ts.InputMatrix.Min();

                if (min < 0)
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(-min);
                }

                double max = ts.InputMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.InputMatrix = ts.InputMatrix.Multiply(1.0 / max);

                //  Normalize output
                min = ts.TargetMatrix.Min();

                if (min < 0)
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(-min);
                }

                max = ts.TargetMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.TargetMatrix = ts.TargetMatrix.Multiply(1.0 / max);
            }

            return ts;
        }

        private TrainingSet TrigGenerator()
        {
            const double minX = -Math.PI * 4, maxX = Math.PI * 4, stepSize = Math.PI / 10;
            const int numberOfElementsInX = (int)((maxX - minX) / stepSize) + 1;

            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[1, numberOfElementsInX].Zeros();
            ts.TargetMatrix = new double[1, numberOfElementsInX].Zeros();

            int index = 0;
            for (double x = minX; x <= maxX; x += stepSize, index++)
            {
                ts.InputMatrix[0, index] = x;
                ts.TargetMatrix[0, index] = 2 * Math.Sin(x) + 1;
            }

            if (this.NormalizeData)
            {
                //  Normalize input
                double min = ts.InputMatrix.Min();

                if (min < 0)
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(-min);
                }

                double max = ts.InputMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.InputMatrix = ts.InputMatrix.Multiply(1.0 / max);

                //  Normalize output
                min = ts.TargetMatrix.Min();

                if (min < 0)
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(-min);
                }

                max = ts.TargetMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.TargetMatrix = ts.TargetMatrix.Multiply(1.0 / max);
            }

            return ts;
        }

        private TrainingSet SigmoidGenerator()
        {
            const double minX = -4, maxX = 4, stepSize = 0.5;
            const int numberOfElementsInX = (int)((maxX - minX) / stepSize) + 1;

            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[1, numberOfElementsInX].Zeros();
            ts.TargetMatrix = new double[1, numberOfElementsInX].Zeros();

            int index = 0;
            for (double x = minX; x <= maxX; x += stepSize, index++)
            {
                ts.InputMatrix[0, index] = x;
                ts.TargetMatrix[0, index] = 1 / (1 + Math.Exp(-x));
            }

            if (this.NormalizeData)
            {
                //  Normalize input
                double min = ts.InputMatrix.Min();

                if (min < 0)
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(-min);
                }

                double max = ts.InputMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.InputMatrix = ts.InputMatrix.Multiply(1.0 / max);

                //  Normalize output
                min = ts.TargetMatrix.Min();

                if (min < 0)
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(-min);
                }

                max = ts.TargetMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.TargetMatrix = ts.TargetMatrix.Multiply(1.0 / max);
            }

            return ts;
        }

        private TrainingSet TangentGenerator()
        {
            const double minX = -4, maxX = 4, stepSize = 0.5;
            const int numberOfElementsInX = (int)((maxX - minX) / stepSize) + 1;

            TrainingSet ts = new TrainingSet();
            ts.InputMatrix = new double[1, numberOfElementsInX].Zeros();
            ts.TargetMatrix = new double[1, numberOfElementsInX].Zeros();

            int index = 0;
            for (double x = minX; x <= maxX; x += stepSize, index++)
            {
                ts.InputMatrix[0, index] = x;
                ts.TargetMatrix[0, index] = (Math.Exp(2 * x) - 1) / (Math.Exp(2 * x) + 1);
            }

            if (this.NormalizeData)
            {
                //  Normalize input
                double min = ts.InputMatrix.Min();

                if (min < 0)
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.InputMatrix = ts.InputMatrix.AddElementwise(-min);
                }

                double max = ts.InputMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.InputMatrix = ts.InputMatrix.Multiply(1.0 / max);

                //  Normalize output
                min = ts.TargetMatrix.Min();

                if (min < 0)
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(Math.Abs(min));
                }
                else
                {
                    ts.TargetMatrix = ts.TargetMatrix.AddElementwise(-min);
                }

                max = ts.TargetMatrix.Max();

                //  ... protection against division by zero
                if (max != 0.0) ts.TargetMatrix = ts.TargetMatrix.Multiply(1.0 / max);
            }

            return ts;
        }
    }
}
