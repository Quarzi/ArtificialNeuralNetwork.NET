using System;
using System.IO;
//using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ArtificialNeuralNetwork
{
    [Serializable]
    public class TrainingSet
    {
        public double[,] InputMatrix { get; set; }
        public double[,] TargetMatrix { get; set; }

        public void SaveSet(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream file = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(file, this);
            }
        }

        public TrainingSet LoadSet(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream file = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                this.Equals((TrainingSet)formatter.Deserialize(file));

            }
            
            return this;
        }
        public TrainingSet LoadSet(Stream file)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            this.Equals((TrainingSet)formatter.Deserialize(file));

            return this;
        }

    }
}
