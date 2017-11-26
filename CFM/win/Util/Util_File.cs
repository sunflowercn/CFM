using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace win.Util
{
    class Util_File
    {    
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        /// <summary>
        /// 用于判断文件是否可以以独占方式打开；
        /// </summary>
        /// <param name="fileFullName"></param>
        /// <returns></returns>
        private bool ValidCopy(string fileFullName)
        {
            if (!File.Exists(fileFullName))
            {
                return false;
            }
            IntPtr handle = _lopen(fileFullName, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (handle == HFILE_ERROR)
            {
                return false;
            }
            CloseHandle(handle);
            return true;
        }
        private bool ValidCopy1(string filename)
        {
            try
            {
                using (FileStream ds = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool ValidCopy2(string filename)
        {
            FileStream ds = null;
            try
            {
                ds = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (ds != null)
                {
                    ds.Flush();
                    ds.Close();
                }
            }
        }       
    }
}
