using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SnapshotReciever
{
    class ImageDownloader
    {
        public ImageDownloader()
        {
            bwImageDownloader = new BackgroundWorker();// bwImageDownloader.
        }
        private const string baseUri = "http://{0}/ISAPI/Streaming/channels/{1}/picture?snapShotImageType=JPEG";
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CameraNumber { get; set; }
        public int Stream { get; set; }

        public Image GetImage(string uri)
        {
            //string uri = baseUri.Replace("{0}", Address).Replace("{1}", CameraNumber + "0" + Stream);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = new System.Net.NetworkCredential(Username, Password);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download it
                Image snapsot = Image.FromStream(response.GetResponseStream());
                return snapsot;
            }
            return null;
        }

        public Image GetImage()
        {
            //string uri = baseUri.Replace("{0}", Address).Replace("{1}", CameraNumber + "0" + Stream);
            return GetImage(baseUri.Replace("{0}", Address).Replace("{1}", CameraNumber + "0" + Stream));
        }

        private BackgroundWorker bwImageDownloader;

        public delegate Image DownloadCompletedEventHandler(object sender, Image image);
        public event DownloadCompletedEventHandler DownloadCompleted;

        private void OnDownloadCompleted(Image img)
        {
            if(DownloadCompleted != null)
            {
                DownloadCompleted(this, img);
            }
        }

        public void GetImageAsync()
        {
            //Task<Image> downloadTast = new Task<Image>(GetImage);
        }
    }
}
