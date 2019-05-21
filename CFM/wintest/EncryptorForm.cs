using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.Tools.Encryptor;

namespace wintest
{
    public partial class EncryptorForm : Form
    {
        public EncryptorForm()
        {
            InitializeComponent();
        }


        private void EncryptorForm_Load(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
                this.txtPlain.Text = "13501066823";
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                string seckey = "tjlx4Xd_dXa6xsC3pq-uX92h";
                DESEncryptor cryptor = new DESEncryptor(seckey);
                this.txtEncrypt.Text = cryptor.Encrypt(this.txtPlain.Text);
            }
            else
            {
                string pwd = "800:6cc3cfc47dbd03c1cbc60398b0988a:186e5678c8b40921e56e847807b7de";
                string[] arr = pwd.Split(':');


                HMACSHA1Encryptor eb = new HMACSHA1Encryptor(arr[1], Convert.ToInt32(arr[0]));

                string arreer= eb.Encrypt("1");                                
                
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 1)
            {
                string seckey = "tjlx4Xd_dXa6xsC3pq-uX92h";
                DESEncryptor cryptor = new DESEncryptor(seckey);
            }
            else
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
                this.txtPlain.Text = "13501066823";
        }

        private static byte[] fromHex(String hex)
        {
            byte[] binary = new byte[hex.Length / 2];
            for (int i = 0; i < binary.Length; i++)
            {
                binary[i] = (byte) Convert.ToInt16(hex.Substring(2 * i, 2),16);
            }
            return binary;
        }

    }
}
