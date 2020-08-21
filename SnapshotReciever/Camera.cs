using System;
using System.Drawing;

namespace SnapshotReciever
{
    [Serializable]
    public class Camera
    {
        public Camera(string name, int port, Device parent)
        {
            this.Name = name;
            this.PortNumber = port;
            this.ParentDevice = parent;
        }
        public int PortNumber { get; private set; }
        public string Name { get; set; }
        //public CameraStream Stream { get; private set; }
        public Device ParentDevice { get; private set; }
        
        [NonSerialized]
        private Image img;
        
        public Image LastSnapshot { get { return img; } set { img = value; } }
    }

    public static class CameraStream
    {
        public static int Main { get { return 1; } }
        public static int Second { get { return 2; } }
    }
}
