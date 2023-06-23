using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace VeesSaveSystem
{
    public sealed class SerializeationManager
    {
        public static bool SerializeObjectToBinary(string fileName, object objectToSave)
        {
            BinaryFormatter binary_formatter = new BinaryFormatter();

            if (Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                Directory.CreateDirectory("/saves");
            }

            string save_path = Application.persistentDataPath + fileName + ".data";

            FileStream file_stream = File.Create(save_path);

            binary_formatter.Serialize(file_stream, objectToSave);

            file_stream.Close();

            return true;
        }

        public static object Load(string path)
        {
            if (File.Exists(path))
            {
                return null;
            }

            BinaryFormatter binary_formatter = new BinaryFormatter();

            FileStream file_stream = File.Open(path, FileMode.Open);

            try
            {
                object loaded_object = binary_formatter.Deserialize(file_stream);
                file_stream.Close();
                return loaded_object;
            }
            catch
            {
                return null;
            }
        }
    }

}
