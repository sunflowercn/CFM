using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.form.FormManager;

namespace wintest.FormManager
{
    public class FormManager
    {
        private static FormManager instance = new FormManager();
        public static FormManager Instance
        {
            get { return instance; }
        }

        public void ShowForm(string formName,Form MainForm)
        {
            ChildForm form = CreateForm(formName);
            form.MdiParent = MainForm;
            form.Show();
        }

        private ChildForm CreateForm(string formName)
        {
            switch (formName)
            {
                case "Form1": return new Form1();
                default: return null;
            }

        }
    }
}
