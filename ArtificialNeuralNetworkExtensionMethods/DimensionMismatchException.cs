using System;

namespace ArtificialNeuralNetwork.Extensions
{
    public class DimensionMismatchException : Exception
    {
        public DimensionMismatchException()
        {

        }

        public DimensionMismatchException(string message)
            : base(message)
        {

        }

        public DimensionMismatchException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
