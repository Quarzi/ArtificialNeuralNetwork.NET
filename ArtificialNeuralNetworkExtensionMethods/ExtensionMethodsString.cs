using System;
using System.Collections.Generic;

namespace ArtificialNeuralNetwork.Extensions
{
    public static class ExtensionMethodsString
    {
        public static double[] ToDoubleArray(this string me)
        {
            string temp = me;
            int index;
            double number = 0;
            List<double> listDoubles = new List<double>();

            do
            {
                index = temp.IndexOf(",");

                if (index != -1)
                {
                    number = Convert.ToDouble(temp.Substring(0, index));
                    temp = temp.Substring(index + 1);
                }
                else
                {
                    number = Convert.ToDouble(temp.Substring(0, temp.Length));
                }

                listDoubles.Add(number);
                
            } while (index != -1);

            return listDoubles.ToArray();
        }
    }
}
