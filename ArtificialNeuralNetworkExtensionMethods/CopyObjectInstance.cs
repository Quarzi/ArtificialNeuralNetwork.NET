using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ArtificialNeuralNetwork.Extensions
{
    public static class CopyObject
    {
        public static T CopyInstance<T>(T obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();

            formatter.Serialize(mem, obj);

            return (T)formatter.Deserialize(mem);
        }
    }
}