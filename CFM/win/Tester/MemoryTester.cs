using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace win.Tester
{
    public class MemoryTester
    {
      
        public void Log(LogType logType= LogType.debug)
        {
            Process p = Process.GetCurrentProcess();          
            string info = string.Format("当前进程占用内存：{0}", p.PrivateMemorySize64);

            if (logType == LogType.debug)
                System.Diagnostics.Debug.WriteLine(info);
            else if (logType == LogType.txt)
            {
                string path = Environment.CurrentDirectory;
                File.AppendAllText(path + "/spentMem.txt", info);
            }
            
        }
    }
}
