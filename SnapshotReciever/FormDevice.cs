using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnapshotReciever
{
    public partial class FormDevice : Form
    {
        public FormDevice(CryptoString cryptoString, bool isNewDevice = true)
        {
            InitializeComponent();
            _cryptoString = cryptoString;
            _isNewDevice = isNewDevice;
            textBoxName.BackColor = Color.LightCoral;
            textBoxUserName.BackColor = Color.LightCoral;
            textBoxPassword.BackColor = Color.LightCoral;
            textBoxAddress.BackColor = Color.LightCoral;
        }
        private const string ipPattern = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        private CryptoString _cryptoString;
        private bool _isNewDevice;

        public Device currentDevice { get; set; }

        private bool CheckFieldsFilling()
        {
            if (!String.IsNullOrWhiteSpace(textBoxName.Text))
            {
                if (Regex.IsMatch(textBoxAddress.Text, ipPattern))
                {
                    if (!String.IsNullOrWhiteSpace(textBoxUserName.Text))
                    {
                        if (!String.IsNullOrWhiteSpace(textBoxPassword.Text))
                        {
                            return true;
                            
                        }
                        else
                        {
                            MessageBox.Show("Не заполнен пароль пользователя!", "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не заполнено имя пользователя!", "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Не заполнен адрес устройства!", "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Не заполнено название устройства!", "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool CheckCameraListFilling()
        {
            foreach(DataGridViewRow row in dataGridViewCameraList.Rows)
            {
                if(row.Cells[0].Value == null || String.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                {
                    MessageBox.Show(String.Format("Не заполнено название канала устройства (строка {0})", row.Index + 1), "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (row.Cells[1].Value == null || String.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()))
                {
                    MessageBox.Show(String.Format("Не заполнен номер канала устройства (строка {0})", row.Index + 1), "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (!Int32.TryParse(row.Cells[1].Value.ToString(), out int i))
                    {
                        MessageBox.Show(String.Format("Значение номера канала не возможно преобразовать к типу \"число\" (строка {0})", row.Index + 1), "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private void CreateDevice()
        {
            this.currentDevice = new Device(textBoxName.Text, textBoxAddress.Text, _cryptoString);
            this.currentDevice.Username = textBoxUserName.Text;
            this.currentDevice.Password = textBoxPassword.Text;
            if(string.IsNullOrEmpty(currentDevice.Model))
                this.currentDevice.GetInfo();
            textBoxModel.Text = currentDevice.Model;
        }

        private void SetTextBoxColor(TextBox tb)
        {
            if (String.IsNullOrWhiteSpace(tb.Text))
                tb.BackColor = Color.LightCoral;
            else
                tb.BackColor = SystemColors.Window;
        }

        private void SetDeviceParams()
        {
            currentDevice.Name = textBoxName.Text;
            //currentDevice.Address = textBoxPassword.Text;
            currentDevice.Username = textBoxPassword.Text;
            currentDevice.Password = textBoxPassword.Text;
        }
        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBoxAddress.Text, ipPattern))
                textBoxAddress.BackColor = Color.LightCoral;
            else
                textBoxAddress.BackColor = SystemColors.Window;
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxColor((TextBox)sender);
        }
        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxColor((TextBox)sender);
        }
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxColor((TextBox)sender);
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            if (CheckFieldsFilling() && CheckCameraListFilling())
            {
                if (dataGridViewCameraList.Rows.Count > 0)
                {
                    if (_isNewDevice) // добавление нового устройства
                    {
                        CreateDevice();
                    }
                    else // изменение существующего
                    {
                        currentDevice.Name = textBoxName.Text;
                        currentDevice.Username = textBoxUserName.Text;
                        currentDevice.Password = textBoxPassword.Text;
                        currentDevice.Model = textBoxModel.Text;
                    }

                    currentDevice.Cameras.Clear();
                    foreach (DataGridViewRow row in dataGridViewCameraList.Rows)
                        currentDevice.Cameras.Add(new Camera(row.Cells[0].Value.ToString(), Convert.ToInt32(row.Cells[1].Value), currentDevice));

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Список каналов устройства пуст. Воспользуйтесь поиском или добавьте их вручную.", "Ошибка заполнения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            if (CheckFieldsFilling())
            {
                //if (NewDevice == null)
                CreateDevice();
                dataGridViewCameraList.Rows.Clear();

                List<Camera> cameraList = null;// = NewDevice.GetCameraList();


                try
                {
                    cameraList = currentDevice.GetCameraList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка поиска камер", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (cameraList != null && cameraList.Count > 0)
                {
                    textBoxModel.Text = cameraList[0].ParentDevice.Model;
                    foreach (Camera c in cameraList)
                        dataGridViewCameraList.Rows.Add(c.Name, c.PortNumber);
                }
                else
                    MessageBox.Show("Не найдено ни одного канала записи на устройстве.", "Поиск каналов записи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormDevice_Shown(object sender, EventArgs e)
        {
            if (!_isNewDevice)
            {
                if (String.IsNullOrEmpty(currentDevice.Model))
                {
                    try
                    {
                        currentDevice.GetInfo();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка получения данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                this.Text = "Изменение устройства";
                buttonAddDevice.Text = "Применить";
                textBoxAddress.Enabled = false;

                textBoxName.Text = currentDevice.Name;
                textBoxAddress.Text = currentDevice.Address;
                textBoxUserName.Text = currentDevice.Username;
                textBoxPassword.Text = currentDevice.Password;
                textBoxModel.Text = currentDevice.Model;

                foreach (Camera cam in currentDevice.Cameras)
                    dataGridViewCameraList.Rows.Add(cam.Name, cam.PortNumber);
            }
        }

        private void toolStripButtonRemoveCamera_Click(object sender, EventArgs e)
        {
            //dataGridViewCameraList.SelectedCells
            foreach (DataGridViewRow row in dataGridViewCameraList.SelectedRows)
            {
                dataGridViewCameraList.Rows.Remove(row);
            }
        }

        private void toolStripButtonRowUp_Click(object sender, EventArgs e)
        {
            if(dataGridViewCameraList.Rows.Count > 1 && dataGridViewCameraList.SelectedRows[0].Index > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCameraList.SelectedRows[0];
                DataGridViewRow preRow = dataGridViewCameraList.Rows[selectedRow.Index - 1];
                dataGridViewCameraList.Rows.Remove(preRow);
                dataGridViewCameraList.Rows.Insert(selectedRow.Index + 1, preRow);
            }
        }

        private void toolStripButtonRowDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewCameraList.Rows.Count > 1 && dataGridViewCameraList.SelectedRows[0].Index < dataGridViewCameraList.Rows.Count - 1)
            {
                
                DataGridViewRow selectedRow = dataGridViewCameraList.SelectedRows[0];
                DataGridViewRow postRow = dataGridViewCameraList.Rows[selectedRow.Index + 1];
                int indexPosition = selectedRow.Index;
                dataGridViewCameraList.Rows.Remove(postRow);

                dataGridViewCameraList.Rows.Insert(indexPosition, postRow);
            }
        }

        private void toolStripButtonAddCamera_Click(object sender, EventArgs e)
        {
            int index  = dataGridViewCameraList.Rows.Add();
            dataGridViewCameraList.CurrentCell = dataGridViewCameraList.Rows[index].Cells[0];
            dataGridViewCameraList.BeginEdit(true);
        }
    }
}
