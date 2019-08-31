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
    public partial class RSAKeyTransForm : Form
    {
        public RSAKeyTransForm()
        {
            InitializeComponent();
        }

        private void buttonJavaToNetPub_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxJavakey.Text))
            {
                MessageBox.Show("请输入Java密钥");
                return;
            }

            this.textBoxNetKey.Text = RSAEncryptor.RSAPublicKeyJava2DotNet(this.textBoxJavakey.Text);
           
        }

        private void buttonJavaToNetPri_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.textBoxJavakey.Text))
            {
                MessageBox.Show("请输入Java密钥");
                return;
            }

            this.textBoxNetKey.Text = RSAEncryptor.RSAPrivateKeyJava2DotNet(this.textBoxJavakey.Text);
        }

        private void buttonNetToJavaPub_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.textBoxNetKey.Text))
            {
                MessageBox.Show("请输入Net密钥");
                return;
            }

            this.textBoxJavakey.Text = RSAEncryptor.RSAPublicKeyDotNet2Java(this.textBoxNetKey.Text);
        }

        private void buttonNetToJavaPri_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxNetKey.Text))
            {
                MessageBox.Show("请输入Net密钥");
                return;
            }

            this.textBoxJavakey.Text = RSAEncryptor.RSAPrivateKeyDotNet2Java(this.textBoxNetKey.Text);
        }
    }
}
