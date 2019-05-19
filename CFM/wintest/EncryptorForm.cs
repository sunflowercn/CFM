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
            string  seckey= "tjlx4Xd_dXa6xsC3pq-uX92h";
            DesEncryptor cryptor = new DesEncryptor(seckey);
            this.txtEncrypt.Text = cryptor.Encrypt(this.txtPlain.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string seckey = "tjlx4Xd_dXa6xsC3pq-uX92h";
            DesEncryptor cryptor = new DesEncryptor(seckey);
            this.txtDecrypt.Text = cryptor.Decrypt(this.txtEncrypt.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
                this.txtPlain.Text = "13501066823";
        }
    }
}
