using System;

namespace ArtificialNeuralNetwork
{
    public static class ExtensionMethodsDouble1D
    {
        public static double[] Zeros(this double[] me)
        {
            for (int i = 0; i < me.Length; i++)
            {
                me[i] = 0;
            }

            return me;
        }

        public static double[] Ones(this double[] me)
        {
            for (int i = 0; i < me.Length; i++)
            {
                me[i] = 1;
            }

            return me;
        }

        public static double[] Randomize(this double[] me, double maxValue = 10)
        {
            Random rand = new Random((int)DateTime.Now.ToBinary());

            for (int i = 0; i < me.Length; i++)
            {
                double value = rand.NextDouble() * maxValue;

                if (rand.Next(2) == 0) value *= -1;

                me[i] = value;
            }

            return me;
        }

        public static double[] DotProduct(this double[] lhs, double[] rhs)
        {
            double[] output = new double[lhs.GetLength(0)].Zeros();

            if (lhs.Length == rhs.Length)
            {
                for (int i = 0; i < lhs.GetLength(0); i++)
                {
                    output[i] += lhs[i] * rhs[i];
                }
            }
            else
            {
                string msg = string.Format("Dimensions of left-hand-side and right-hand-side are not matching: {0}x1 and {1}x1", lhs.Length, rhs.Length);
                throw new DimensionMismatchException(msg);
            }

            return output;
        }

        public static double[,] OuterProduct(this double[] lhs, double[] rhs)
        {
            double[,] output = new double[lhs.Length, rhs.Length].Zeros();

            for (int i = 0; i < lhs.GetLength(0); i++)
            {
                for (int j = 0; j < rhs.Length; j++)
                {
                    output[i, j] = lhs[i] * rhs[j];
                }
            }

            return output;
        }

        public static double[] HadamardProduct(this double[] lhs, double[] rhs)
        {
            double[] result = new double[lhs.Length].Zeros();

            if (lhs.Length == rhs.Length)
            {
                for (int i = 0; i < lhs.GetLength(0); i++)
                {
                    result[i] = lhs[i] * rhs[i];
                }
            }

            return result;
        }

        public static double[] ApplyFunction(this double[] me, Func<double, double> function)
        {
            double[] output = new double[me.Length].Zeros();

            for (int i = 0; i < me.Length; i++)
            {
                output[i] = function(me[i]);
            }

            return output;
        }

        public static double[] Subvector(this double[] me, int endIndex, int startIndex = 0)
        {
            double[] output = new double[endIndex - startIndex + 1].Zeros();

            for (int i = startIndex; i <= endIndex; i++)
            {
                output[i] = me[i];
            }

            return output;
        }

        public static string VectorToString(this double[] me)
        {
            string str = "";

            foreach (var value in me)
            {
                str += value.ToString() + ", ";
            }

            str = str.Substring(0, str.Length - 2);

            return str;
        }

        public static double[] ConcatenateVector(this double[] me, double[] vector)
        {
            double[] result = new double[me.Length + vector.Length];

            int index = 0;

            foreach (var value in me)
            {
                result[index] = value;
                index++;
            }

            foreach (var value in vector)
            {
                result[index] = value;
                index++;
            }

            return result;
        }

        public static double[] Subtract(this double[] rhs, double[] lhs)
        {
            double[] result = new double[rhs.Length].Zeros();

            if (rhs.Length == lhs.Length)
            {
                for (int i = 0; i < rhs.Length; i++)
                {
                    result[i] = rhs[i] - lhs[i];
                }
            }
            else
            {
                string msg = string.Format("Dimensions of left-hand-side and right-hand-side are not matching - Matrix: ({0}x1) and Vector: ({1}x1)", lhs.Length, rhs.Length);
                throw new DimensionMismatchException(msg);
            }

            return result;
        }

        public static double EuclideanLength(this double[] me)
        {
            double result = 0;

            for (int i = 0; i < me.Length; i++)
            {
                result += Math.Pow(me[i], 2);
            }

            return Math.Sqrt(result);
        }
    }
}
