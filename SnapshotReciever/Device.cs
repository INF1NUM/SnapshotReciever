using SnapshotReciever.onvif.devicemgmt;
using SnapshotReciever.onvif.media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;

namespace SnapshotReciever
{
    [Serializable]
    public class Device
    {
        public Device(string name, string address, CryptoString cryptoString)
        {
            this.Cameras = new List<Camera>();
            this.Name = name;
            this.Address = address;
            _cryptoString = cryptoString;
            InitializeBind();
        }

        [NonSerialized]
        private CustomBinding _bind;

        [NonSerialized]
        private CryptoString _cryptoString;
        public CryptoString CryptoString { get { return _cryptoString; } set { _cryptoString = value; } }
        private byte[] _encryptedPassword;

        public string Model { get; set; }
        public string Name { get; set; }
        public string Address { get; private set; }
        public string Username { get; set; }
        public string Password 
        {
            get
            {
                return _cryptoString.DecryptFromByte(_encryptedPassword);
            }
            set
            {
                _encryptedPassword = _cryptoString.EncryptToByte(value);
            }
        }
        public List<Camera> Cameras { get; private set; }

        

        private void InitializeBind()
        {
            var messageElement = new TextMessageEncodingBindingElement();
            messageElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None);

            HttpTransportBindingElement httpBinding = new HttpTransportBindingElement();
            httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest;

            _bind = new CustomBinding(messageElement, httpBinding);
        }

        public void GetInfo()
        {
            if (_bind == null)
                InitializeBind();
            using (var device = new DeviceClient(_bind, new EndpointAddress("http://" + this.Address + "/onvif/device_service")))
            {
                device.ClientCredentials.HttpDigest.ClientCredential.UserName = this.Username;
                device.ClientCredentials.HttpDigest.ClientCredential.Password = this.Password;
                device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                string dvcModel, dvcFrmwr, dvcSerinal, dvcHardwrID;
                string result = device.GetDeviceInformation(out dvcModel, out dvcFrmwr, out dvcSerinal, out dvcHardwrID);
                this.Model = dvcModel;
            }
        }

        #region find chanels
        
        private List<string> GetSnapshotUri()
        {
            //var messageElement = new TextMessageEncodingBindingElement();
            //messageElement.MessageVersion = MessageVersion.CreateVersion(EnvelopeVersion.Soap12, AddressingVersion.None);

            //HttpTransportBindingElement httpBinding = new HttpTransportBindingElement();
            //httpBinding.AuthenticationScheme = AuthenticationSchemes.Digest;

            //CustomBinding bind = new CustomBinding(messageElement, httpBinding);

            using (var device = new DeviceClient(_bind, new EndpointAddress("http://" + this.Address + "/onvif/device_service")))
            {
                //device.ClientCredentials.HttpDigest.ClientCredential.UserName = this.Username;
                //device.ClientCredentials.HttpDigest.ClientCredential.Password = this.Password;
                //device.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                //string dvcModel, dvcFrmwr, dvcSerinal, dvcHardwrID;
                //string result = device.GetDeviceInformation(out dvcModel, out dvcFrmwr, out dvcSerinal, out dvcHardwrID);

                var services = device.GetServices(false);
                var serviceMedia = services.FirstOrDefault(s => s.Namespace == "http://www.onvif.org/ver10/media/wsdl");
                if (serviceMedia != null)
                {
                    List<string> snapshotUris = new List<string>();

                    //DeviceClient deviceClient = new DeviceClient(bind, new EndpointAddress(serviceMedia.XAddr));
                    //deviceClient.ClientCredentials.HttpDigest.ClientCredential.UserName = this.Username;
                    //deviceClient.ClientCredentials.HttpDigest.ClientCredential.Password = this.Password;
                    //deviceClient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;

                    using (MediaClient mediaClient = new MediaClient(_bind, new EndpointAddress(serviceMedia.XAddr)))
                    {
                        mediaClient.ClientCredentials.HttpDigest.ClientCredential.UserName = this.Username;
                        mediaClient.ClientCredentials.HttpDigest.ClientCredential.Password = this.Password;
                        mediaClient.ClientCredentials.HttpDigest.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
                        Profile[] profiles = mediaClient.GetProfiles();

                        foreach (Profile profile in profiles) snapshotUris.Add(mediaClient.GetSnapshotUri(profile.token).Uri);
                    }
                    return snapshotUris;
                }
                else throw new Exception("Сервис Media не найден среди ONVIF сервисов устройства с адресом " + Address);
            }
        }

        private static int ExctractChanelNumber(string uri)
        {
            string portNumberStr = ExctractChanelNumberHik(uri);
            if (String.IsNullOrEmpty(portNumberStr))
                portNumberStr = ExctractChanelNumberDahua(uri);


            if (!String.IsNullOrEmpty(portNumberStr))
                return Convert.ToInt32(portNumberStr.First().ToString());
            else 
                throw new Exception("URI \"" + uri + "\" не содержит информации о номере канала.");
        }

        private static string ExctractChanelNumberHik(string uri)
        {
            Uri uri1 = new Uri(uri);
            return uri1.Segments.FirstOrDefault(s => Regex.IsMatch(s, @"^(\d\d\d)$"));
        }

        private static string ExctractChanelNumberDahua(string uri)
        {
            //System.Uri uri1 = new Uri(uri);
            //string portname = uri1.Segments.FirstOrDefault(s => Regex.IsMatch(s, @"^(\d\d\d)$"));
            var matches = Regex.Matches(uri, @"channel=(\d)&subtype=(\d)");
            if (matches.Count == 1 && matches[0].Groups.Count == 3)
                return matches[0].Groups[1].Value;
            else
                return string.Empty;
        }


        public List<Camera> GetCameraList()
        {
            List<string> uriList = GetSnapshotUri();
            List<Camera> newCameraList = new List<Camera>();
            if (uriList.Count > 0)
            {
                foreach (string uri in uriList)
                {
                    int port = ExctractChanelNumber(uri);
                    
                    if(newCameraList.FirstOrDefault(c => c.PortNumber.Equals(port)) == null) // отсекаем каналы со вторичными потоками
                        newCameraList.Add(new Camera("CAM" + port, port, this));
                }
            }
            return newCameraList;
        }

        #endregion
    }
}
