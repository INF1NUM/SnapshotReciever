using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SnapshotReciever
{
    class DataManager
    {
        public DataManager(String filepath)
        {
            _filepath = filepath;
        }

        private string _filepath;
        public void ExportDevices(List<Device> devices)
        {
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(_filepath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, devices);
            }
        }

        public List<Device> ImportDevices()
        {
            List<Device> devices = null;
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // десериализация из файла 
            using (FileStream fs = new FileStream(_filepath, FileMode.OpenOrCreate))
            {
                devices = (List<Device>)formatter.Deserialize(fs);
            }
            return devices;
        }
    }
}
