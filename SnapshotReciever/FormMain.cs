using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnapshotReciever
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            imageDownloader = new ImageDownloader();
            dataManagerDevices = new DataManager(devicesFilePath);
            if (File.Exists(settingsFilePath))
                settings = Settings.Read(settingsFilePath);
            else
                settings = new Settings(settingsFilePath);
            this.Text += " - " + GetVersion();
        }

        private int wheelDelta = SystemInformation.MouseWheelScrollDelta;
        private ImageDownloader imageDownloader;
        private DataManager dataManagerDevices;
        private CryptoString cryptoString;
        private Settings settings;
        private const string devicesFilePath = "devices.dat";
        private const string settingsFilePath = "settings.dat";

        private string GetVersion()
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1, 0, 0, 0).AddDays(version.Revision);
            return String.Format("версия {0}.{1} сборка {2} от {3}", version.Major, version.Minor, version.Build, buildDate.ToString("dd.MM.yyyy"));
        }
         
        private void toolStripButtonAddDevice_Click(object sender, EventArgs e)
        {
            using (FormDevice formDeviceAdd = new FormDevice(cryptoString))
                if (formDeviceAdd.ShowDialog() == DialogResult.OK)
                    AddDevice(formDeviceAdd.currentDevice);
        }

        private void AddDevice(Device device)
        {
            TreeNode deviceNode = new TreeNode(device.Name);
            deviceNode.Tag = device;

            foreach(Camera cam in device.Cameras)
            {
                TreeNode cameraNode = new TreeNode(cam.Name);
                cameraNode.Tag = cam;
                deviceNode.Nodes.Add(cameraNode);
            }

            treeViewDevices.Nodes.Add(deviceNode);
            deviceNode.Expand();
        }

        private void treeViewDevices_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (pictureBoxSnapshot.Image != null)
            {
                pictureBoxSnapshot.Image.Dispose();
                pictureBoxSnapshot.Image = null;
            }

            if (treeViewDevices.SelectedNode.Tag.GetType().Equals(typeof(Camera)))
            {
                Camera selectedCamera = (Camera)treeViewDevices.SelectedNode.Tag;
                labelDeviceInfo.Text = selectedCamera.ParentDevice.Name;
                labelDeviceInfo.Text += ": " + selectedCamera.Name;
                //toolStripStatusLabelStarus.Text = String.Empty;
            }
            else
            {
                labelDeviceInfo.Text = String.Empty;
            }
            toolStripStatusLabelStarus.Text = String.Empty;
        }

        private void toolStripButtonRemoveDevice_Click(object sender, EventArgs e)
        {
            if (treeViewDevices.SelectedNode != null)
            {
                if (treeViewDevices.SelectedNode.Tag.GetType().Equals(typeof(Camera)))
                {
                    Camera selectedCamera = (Camera)treeViewDevices.SelectedNode.Tag;
                    var mbResult = MessageBox.Show("Вы действительно хотите удалить канал \"" + selectedCamera.Name + "\"?", "Удаление объекта", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mbResult == DialogResult.Yes)
                    {
                        treeViewDevices.Nodes.Remove(treeViewDevices.SelectedNode);
                        selectedCamera.ParentDevice.Cameras.Remove(selectedCamera);
                    }
                }
                else
                {
                    Device selecedDevice = (Device)treeViewDevices.SelectedNode.Tag;
                    var mbResult = MessageBox.Show("Вы действительно хотите удалить устройство \"" + selecedDevice.Name + "\" и все его каналы?", "Удаление объекта", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (mbResult == DialogResult.Yes)
                    {
                        treeViewDevices.Nodes.Remove(treeViewDevices.SelectedNode);
                    }
                }
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (treeViewDevices.Nodes.Count > 0)
            {
                List<Device> devices = new List<Device>();
                foreach (TreeNode nodeDevice in treeViewDevices.Nodes)
                    devices.Add(nodeDevice.Tag as Device);
                dataManagerDevices.ExportDevices(devices);
            }
            else
                File.Delete(devicesFilePath);
            settings.Save();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // ввод главного пароля
            using (FormMasterPassword formMP = new FormMasterPassword(settings.PasswordHash))
            {
                if (formMP.ShowDialog() == DialogResult.OK)
                {
                    cryptoString = new CryptoString(formMP.Password);
                    if (settings.PasswordHash == null)
                        settings.SetPasswordHash(formMP.Password);
                }
                else
                {
                    this.FormClosed -= this.FormMain_FormClosed;
                    Application.Exit();
                    return;
                }
            }

            // читаем список устройств
            if (File.Exists(devicesFilePath))
            {
                List<Device> devices = null;
                try
                {
                    devices = dataManagerDevices.ImportDevices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка чтения файла данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (Device dev in devices)
                {
                    dev.CryptoString = cryptoString;
                    AddDevice(dev);
                }
            }
        }
                
        private void toolStripButtonEditDevice_Click(object sender, EventArgs e)
        {
            if (treeViewDevices.SelectedNode != null)
            {
                Device selectedDevice;
                TreeNode treeNodeDevice;
                if (treeViewDevices.SelectedNode.Tag.GetType().Equals(typeof(Device)))
                {
                    selectedDevice = (Device)treeViewDevices.SelectedNode.Tag;
                    treeNodeDevice = treeViewDevices.SelectedNode;
                }
                else
                {
                    selectedDevice = (Device)treeViewDevices.SelectedNode.Parent.Tag;
                    treeNodeDevice = treeViewDevices.SelectedNode.Parent;
                }

                //Device selectedDevice = (Device)treeViewDevices.SelectedNode.Tag;
                using (FormDevice formDeviceAdd = new FormDevice(cryptoString, false))
                {
                    formDeviceAdd.currentDevice = selectedDevice;
                    if (formDeviceAdd.ShowDialog() == DialogResult.OK)
                    {
                        treeViewDevices.BeginUpdate();
                        treeNodeDevice.Text = formDeviceAdd.currentDevice.Name;

                        treeNodeDevice.Nodes.Clear();
                        foreach(Camera cam in formDeviceAdd.currentDevice.Cameras)
                        {
                            TreeNode cameraNode = new TreeNode(cam.Name);
                            cameraNode.Tag = cam;
                            treeNodeDevice.Nodes.Add(cameraNode);
                        }
                        treeViewDevices.ExpandAll();
                        treeViewDevices.EndUpdate();
                    }
                }
            }
        }
        
        private void MoveNodeUp(TreeNodeCollection nodes, TreeNode selectedNode)
        {
            if (nodes.Count > 1 && selectedNode.Index > 0)
            {
                TreeNode preNode = nodes[selectedNode.Index - 1];
                nodes.Remove(preNode);
                nodes.Insert(selectedNode.Index + 1, preNode);
            }
        }

        private void MoveNodeDown(TreeNodeCollection nodes, TreeNode selectedNode)
        {
            if (nodes.Count > 1 && selectedNode.Index < nodes.Count - 1)
            {
                TreeNode postNode = nodes[selectedNode.Index + 1];
                int positionIndex = selectedNode.Index;
                nodes.Remove(postNode);
                nodes.Insert(positionIndex, postNode);
            }
        }

        private void SortCameraList(TreeNode nodeDevice)
        {
            Device device = nodeDevice.Tag as Device;
            device.Cameras.Clear();
            foreach (TreeNode nodeCamera in nodeDevice.Nodes)
                device.Cameras.Add(nodeCamera.Tag as Camera);
        }

        private void toolStripButtonUp_Click(object sender, EventArgs e)
        {
            if (treeViewDevices.SelectedNode != null)
            {
                treeViewDevices.BeginUpdate();
                if (treeViewDevices.SelectedNode.Tag.GetType().Equals(typeof(Device)))
                    MoveNodeUp(treeViewDevices.Nodes, treeViewDevices.SelectedNode);
                else
                {
                    MoveNodeUp(treeViewDevices.SelectedNode.Parent.Nodes, treeViewDevices.SelectedNode);
                    SortCameraList(treeViewDevices.SelectedNode.Parent);
                }
                treeViewDevices.EndUpdate();
            }
        }

        private void toolStripButtonDown_Click(object sender, EventArgs e)
        {
            if (treeViewDevices.SelectedNode != null)
            {
                treeViewDevices.BeginUpdate();
                if (treeViewDevices.SelectedNode.Tag.GetType().Equals(typeof(Device)))
                    MoveNodeDown(treeViewDevices.Nodes, treeViewDevices.SelectedNode);
                else
                {
                    MoveNodeDown(treeViewDevices.SelectedNode.Parent.Nodes, treeViewDevices.SelectedNode);
                    SortCameraList(treeViewDevices.SelectedNode.Parent);
                }
                treeViewDevices.EndUpdate();
            }
        }

        private void toolStripButtonGetSnapshot_Click(object sender, EventArgs e)
        {
            if (treeViewDevices.SelectedNode != null && treeViewDevices.SelectedNode.Tag.GetType().Equals(typeof(Camera)))
            {
                Camera selectedCamera = (Camera)treeViewDevices.SelectedNode.Tag;

                imageDownloader.Address = selectedCamera.ParentDevice.Address;
                imageDownloader.Username = selectedCamera.ParentDevice.Username;
                try
                {
                    imageDownloader.Password = selectedCamera.ParentDevice.Password;
                }
                catch (System.Security.Cryptography.CryptographicException cEx)
                {
                    MessageBox.Show("В процессе шифрования произошла ошибка. Вероятно, не верно указан главный пароль. " + cEx.Message, "Ошибка шифрования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка шифрования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                imageDownloader.CameraNumber = selectedCamera.PortNumber;
                imageDownloader.Stream = CameraStream.Main;

                try
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    string uri;

                    switch (selectedCamera.ParentDevice.Model)
                    {
                        case "RVi-1HDR08LA":
                            uri = String.Format("http://{0}/cgi-bin/snapshot.cgi?channel={1}", selectedCamera.ParentDevice.Address, selectedCamera.PortNumber);
                            break;
                        case "RVi-HDR04LA-TA":
                            uri = String.Format("http://{0}/ISAPI/Streaming/channels/{1}01/picture?snapShotImageType=JPEG", selectedCamera.ParentDevice.Address, selectedCamera.PortNumber);
                            break;
                        case "RVi-HDR04MA":
                            uri = String.Format("http://{0}/ISAPI/Streaming/channels/{1}01/picture?snapShotImageType=JPEG", selectedCamera.ParentDevice.Address, selectedCamera.PortNumber);
                            break;
                        default:
                            MessageBox.Show("Неизвестное устройство: " + selectedCamera.ParentDevice.Model, "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    selectedCamera.LastSnapshot = imageDownloader.GetImage(uri);
                    pictureBoxSnapshot.Image = selectedCamera.LastSnapshot;
                    //SetImageAutosize(selectedCamera.LastSnapshot);
                    stopWatch.Stop();
                    toolStripStatusLabelStarus.Text = "Изображение получено за " + stopWatch.ElapsedMilliseconds / 1000 + " секунд. ";
                    toolStripStatusLabelStarus.Text += "Размер изображения: " + pictureBoxSnapshot.Image.Width + "x" + pictureBoxSnapshot.Image.Height;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButtonSaveImage_Click(object sender, EventArgs e)
        {
            if (pictureBoxSnapshot.Image != null)
            {
                using (SaveFileDialog sfDialog = new SaveFileDialog())
                {
                    sfDialog.AddExtension = true;
                    sfDialog.DefaultExt = "jpg";
                    sfDialog.Filter = "Файлы JPEG|*.jpg";

                    if (sfDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            pictureBoxSnapshot.Image.Save(sfDialog.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void treeViewDevices_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag.GetType().Equals(typeof(Camera)))
                e.Node.BeginEdit();
        }

        private void treeViewDevices_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Node.Tag.GetType().Equals(typeof(Camera)))
                {
                    Camera selectedCamera = e.Node.Tag as Camera;
                    selectedCamera.Name = e.Label;
                }
                else
                {
                    Device selectedDevice = e.Node.Tag as Device;
                    selectedDevice.Name = e.Label;
                }
            }
        }

        //double currentZoom = 1.0;
        //private void PictureBoxSnapshot_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (pictureBoxSnapshot.Image != null)
        //    {
        //        //pictureBoxSnapshot.SizeMode = PictureBoxSizeMode.CenterImage;
        //        Image originalImage = (treeViewDevices.SelectedNode.Tag as Camera).LastSnapshot;

        //        if (e.Delta > 0)
        //        {
        //            currentZoom += 0.1;
        //        }
        //        else
        //        {
        //            if (currentZoom <= 0.3)
        //                return;
        //            currentZoom -= 0.1;
        //        }

        //        Size newSize = new Size((int)(originalImage.Width * currentZoom), (int)(originalImage.Height * currentZoom));
        //        Bitmap bmp = new Bitmap(originalImage, newSize);
        //        pictureBoxSnapshot.Image = bmp;
        //    }
        //}

        //private void SetImageAutosize(Image img)
        //{
        //    if (img != null)
        //    {
        //        pictureBoxSnapshot.Image = new Bitmap(img, pictureBoxSnapshot.Size);
        //    }
        //}
    }
}
