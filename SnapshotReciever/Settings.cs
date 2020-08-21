using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnapshotReciever
{
    [Serializable]
    class Settings
    {
        public  Settings(string filepath)
        {
            _filepath = filepath;
        }

        [NonSerialized]
        private string _filepath;
        
        public string Location { get { return _filepath; } set { _filepath = value; } }

        public byte[] PasswordHash { get; set; }

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(Location, FileMode.OpenOrCreate))
                formatter.Serialize(fs, this);
        }

        public static Settings Read(string filepath)
        {
            Settings settings;
            BinaryFormatter formatter = new BinaryFormatter(); 
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
                settings = (Settings)formatter.Deserialize(fs);
            settings.Location = filepath;
            return settings;
        }

        public void SetPasswordHash(string password)
        {
            using (SHA256 hash = SHA256.Create())
                PasswordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
