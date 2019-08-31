using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.form.FormManager;

namespace wintest
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void TestChilForm(object sender, EventArgs e)
        {
            FormManager.FormManager.Instance.ShowForm("Form1",this);

            //Form1 childForm = new Form1();
            //childForm.MdiParent = this;
            ////childForm.Text = "Window " + childFormNumber++;
            //childForm.Show(this);
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Util_EncodingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util_EncodingForm form = new Util_EncodingForm();
            form.MdiParent = this;
            form.Show();
        }

        private void Util_xmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util_XmlForm form = new Util_XmlForm();
            form.MdiParent = this;
            form.Show();
        }

        private void myWaittingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestMyWaitingForm form = new TestMyWaitingForm();
            form.MdiParent = this;
            form.Show();
        }

        private void LoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoggerForm form = new LoggerForm();
            form.MdiParent = this;
            form.Show();
        }

        private void htmlParserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HtmlParserForm form = new HtmlParserForm();
            form.MdiParent = this;
            form.Show();
        }

        private void desEncryptorTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncryptorForm form = new EncryptorForm();
            form.MdiParent = this;
            form.Show();
        }

        private void rSAKeyTransToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RSAKeyTransForm form = new RSAKeyTransForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}
