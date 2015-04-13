using System;

namespace ArtificialNeuralNetwork
{
    public static class ExtensionMethodsDouble2D
    {
        public static int Rows(this double[,] me)
        {
            return me.GetLength(0);
        }

        public static int Cols(this double[,] me)
        {
            return me.GetLength(1);
        }

        public static double[,] Zeros(this double[,] me)
        {
            for (int i = 0; i < me.Rows(); i++)
            {
                for (int j = 0; j < me.Cols(); j++)
                {
                    me[i, j] = 0;
                }
            }

            return me;
        }

        public static double[,] Ones(this double[,] me)
        {
            for (int i = 0; i < me.Rows(); i++)
            {
                for (int j = 0; j < me.Cols(); j++)
                {
                    me[i, j] = 1;
                }
            }

            return me;
        }

        public static double[,] Randomize(this double[,] me, double maxValue = 10)
        {
            Random rand = new Random((int)DateTime.Now.ToBinary());

            for (int i = 0; i < me.Rows(); i++)
            {
                for (int j = 0; j < me.Cols(); j++)
                {
                    double value = rand.NextDouble() * maxValue;

                    if (rand.Next(2) == 0) value *= -1;

                    me[i, j] = value;
                }
            }

            return me;
        }

        public static double[,] Add(this double[,] lhs, double[,] rhs)
        {
            double[,] result = new double[lhs.Rows(), lhs.Cols()].Zeros();

            if (lhs.Rows() == rhs.Rows() && lhs.Cols() == rhs.Cols())
            {
                for (int i = 0; i < lhs.Rows(); i++)
                {
                    for (int j = 0; j < lhs.Cols(); j++)
                    {
                        result[i, j] = lhs[i, j] + rhs[i, j];
                    }
                }
            }
            else
            {
                string msg = string.Format("Dimensions of left-hand-side and right-hand-side are not matching addition - Matrix1: ({0}x{1}) and Matrox2: ({2}x{3})", lhs.Rows(), lhs.Cols(), rhs.Rows(), rhs.Cols());
                throw new DimensionMismatchException(msg);
            }

            return result;
        }

        public static double[,] Subtract(this double[,] lhs, double[,] rhs)
        {
            double[,] result = new double[lhs.Rows(), lhs.Cols()].Zeros();

            if (lhs.Rows() == rhs.Rows() && lhs.Cols() == rhs.Cols())
            {
                result = lhs.Add(rhs.Multiply(-1));
            }
            else
            {
                string msg = string.Format("Dimensions of left-hand-side and right-hand-side are not matching addition - Matrix1: ({0}x{1}) and Matrox2: ({2}x{3})", lhs.Rows(), lhs.Cols(), rhs.Rows(), rhs.Cols());
                throw new DimensionMismatchException(msg);
            }

            return result;
        }

        public static double[,] Multiply(this double[,] me, double scale)
        {
            double[,] result = new double[me.Rows(), me.Cols()].Zeros();

            for (int i = 0; i < me.Rows(); i++)
            {
                for (int j = 0; j < me.Cols(); j++)
                {
                    result[i, j] = scale * me[i, j];
                }
            }

            return result;
        }

        public static double[] Multiply(this double[,] lhs, double[] rhs)
        {
            double[] output = new double[lhs.Rows()].Zeros();

            if (lhs.Cols() == rhs.Length)
            {
                for (int i = 0; i < lhs.Rows(); i++)
                {
                    for (int j = 0; j < lhs.Cols(); j++)
                    {
                        output[i] += lhs[i, j] * rhs[j];
                    }
                }
            }
            else
            {
                string msg = string.Format("Dimensions of left-hand-side and right-hand-side are not matching multiplication operation - Matrix: ({0}x{1}) and Vector: ({2}x1)", lhs.Rows(), lhs.Cols(), rhs.Length);
                throw new DimensionMismatchException(msg);
            }

            return output;
        }

        public static double[,] Multiply(this double[,] lhs, double[,] rhs)
        {
            double[,] output = new double[lhs.Rows(), rhs.Cols()].Zeros();

            if (lhs.Cols() == rhs.Rows())
            {
                for (int i = 0; i < output.Rows(); i++)
                {
                    for (int j = 0; j < output.Cols(); j++)
                    {
                        for (int k = 0; k < lhs.Cols(); k++)
                        {
                            output[i, j] += lhs[i, k] * rhs[k, j];
                        }
                    }
                }
            }
            else
            {
                string msg = string.Format("Dimensions of left-hand-side and right-hand-side are not matching: {0}x{1} and {2}x{3}", lhs.Rows(), lhs.Cols(), rhs.Rows(), rhs.Cols());
                throw new DimensionMismatchException(msg);
            }

            return output;
        }

        public static double[] ExtractColumn(this double[,] me, int columnIndex)
        {
            double[] result = new double[me.Rows()];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = me[i, columnIndex];
            }

            return result;
        }

        public static double[,] RemoveColumn(this double[,] me, int index = 0)
        {
            double[,] result = new double[me.Rows(), me.Cols() - 1];

            for (int j = 0, k = 0; j < result.Cols(); j++, k++)
            {
                if (index == k) k++;

                for (int i = 0; i < result.Rows(); i++)
                {
                    result[i,j] = me[i, k];                    
                }
            }

            return result;
        }

        public static double[,] Transpose(this double[,] me)
        {
            double[,] result = new double[me.Cols(), me.Rows()].Zeros();

            for (int i = 0; i < result.Rows(); i++)
            {
                for (int j = 0; j < result.Cols(); j++)
                {
                    result[i, j] = me[j, i];
                }
            }

            return result;
        }

        public static double Min(this double[,] me)
        {
            double output = double.PositiveInfinity;

            for (int i = 0; i < me.Rows(); i++)
            {
                for (int j = 0; j < me.Cols(); j++)
                {
                    if (me[i, j] < output) output = me[i, j];
                }
            }

            return output;
        }

        public static double Max(this double[,] me)
        {
            double output = double.NegativeInfinity;

            for (int i = 0; i < me.Rows(); i++)
            {
                for (int j = 0; j < me.Cols(); j++)
                {
                    if (me[i,j] > output) output = me[i,j];
                }
            }

            return output;
        }
    }
}
