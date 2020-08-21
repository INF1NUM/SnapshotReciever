using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SnapshotReciever
{
    public partial class FormMasterPassword : Form
    {
        public FormMasterPassword(byte[] passwordHash)
        {
            InitializeComponent();
            _passwordHash = passwordHash;
            
        }

        public string Password { get; set; }
        private byte[] _passwordHash;

        private void OK()
        {
            if (_passwordHash != null)
            {
                byte[] passwordHash;
                using (SHA256 hash = SHA256.Create())
                    passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(textBoxPassword.Text));
                if (!_passwordHash.SequenceEqual(passwordHash))
                {
                    MessageBox.Show("Указан не верный пароль!", "Ошибка проверки пароля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            this.Password = textBoxPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            OK();
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
                OK();
        }

        private void FormMasterPassword_Shown(object sender, EventArgs e)
        {
            textBoxPassword.Focus();
            if(_passwordHash == null)
                label1.Text = "Внимание! Введённый вами пароль будет использоваться в дальнейшем для шифрования паролей устройств!";

        }
    }
}
