using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using win.form.Properties;
using System.Threading;


namespace win.form.Inherit
{
    public enum LoadMode
    {
        Warning,
        Error,
        Prompt
    }
    public partial class MessageBoxEx : Form
    {
        /*
        1. AW_SLIDE : 使用滑动类型, 默认为该类型. 当使用 AW_CENTER 效果时, 此效果被忽略
        2. AW_ACTIVE: 激活窗口, 在使用了 AW_HIDE 效果时不可使用此效果
        3. AW_BLEND: 使用淡入效果
        4. AW_HIDE: 隐藏窗口
        5. AW_CENTER: 与 AW_HIDE 效果配合使用则效果为窗口几内重叠,  单独使用窗口向外扩展.
        6. AW_HOR_POSITIVE : 自左向右显示窗口
        7. AW_HOR_NEGATIVE: 自右向左显示窗口
        8. AW_VER_POSITVE: 自顶向下显示窗口
        9. AW_VER_NEGATIVE : 自下向上显示窗口
        */
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;
                        
        private static LoadMode formMode = LoadMode.Prompt;
        private static string ShowMessage = null;
        private System.Windows.Forms.Timer Timer_Close = new System.Windows.Forms.Timer();

        public MessageBoxEx()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        private void MessageBoxEx_Load(object sender, EventArgs e)
        {
            this.lblTitle.Text = "提示";
            if (formMode == LoadMode.Error)
            {
                this.lblTitle.Text = "错误";
                this.panelShow.BackgroundImage = Resources.error;
            }
            else if (formMode == LoadMode.Warning)
            {
                this.lblTitle.Text = "警告";
                this.panelShow.BackgroundImage = Resources.warning;
            }
            else
            {
                this.panelShow.BackgroundImage = Resources.Prompt;
            }
            this.lblMessage.Text = ShowMessage;
            int width = Screen.PrimaryScreen.Bounds.Width;
            int num3 = (Screen.PrimaryScreen.Bounds.Height - 0x23) - base.Height;
            int num4 = (width - base.Width) - 5;
            base.Top = num3;
            base.Left = num4;
            base.TopMost = true;         
            AnimateWindow(base.Handle, 500, 0x40008);
            base.ShowInTaskbar = false;
            this.Timer_Close.Interval = 2000;
            this.Timer_Close.Tick += new EventHandler(this.Timer_Close_Tick);
            this.Timer_Close.Start();
        }

        private void MessageBoxEx_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(base.Handle, 0x3e8, 0x50004);
            this.Timer_Close.Stop();
            this.Timer_Close.Dispose();
        }

        private void Timer_Close_Tick(object sender, EventArgs e)
        {
            this.Timer_Close.Stop();
            base.Close();
        }

        public static void Show(LoadMode loadMode, string message)
        {
            formMode = loadMode;
            ShowMessage = message;            
            new MessageBoxEx().Show();
        }

        private void panelShow_Leave(object sender, EventArgs e)
        {
            this.Timer_Close.Start();
        }

        private void panelShow_Move(object sender, EventArgs e)
        {
            this.Timer_Close.Stop();
        }
    }
}
