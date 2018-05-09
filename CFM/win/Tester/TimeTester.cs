using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace win.Tester
{
    public class TimeTester : IDisposable
    {
        private Stopwatch w;
        private string className;
        private string methodName;
        private LogType logType;

        private static object lockobj = new object();

        public long SpendTime
        {
            get { return w.ElapsedMilliseconds; }
        }    
        public TimeTester(string className,string methodName, LogType logType= LogType.debug)
        {         
            this.className = className;
            this.methodName = methodName;
            this.logType = logType;
            w = new Stopwatch();
            w.Start();
        }
        public void Dispose()
        {
            this.Log();
        }
        private void Log()
        {

            w.Stop();

            string info = string.Format("时间：{0}\t线程ID：{1}\t类：{2}\t方法：{3}\t用时：{4}",DateTime.Now,Thread.CurrentThread.ManagedThreadId,this.className, this.methodName, w.ElapsedMilliseconds);
         
            ThreadPool.QueueUserWorkItem((s => {

                lock (lockobj)  // lock(typeof(this)) 也可以 但是每次都要计算，所以不用这个  ，lockobj必须是一个静态对象
                {
                    if (this.logType == LogType.debug)
                        System.Diagnostics.Debug.WriteLine(info);
                    else if (this.logType == LogType.txt)
                    {
                        string path = Environment.CurrentDirectory;
                        File.AppendAllText(path + "/spentTime.txt", info);
                    }
                }

            }));                        
        }
    }

    public enum LogType
    {
        debug,
        txt
    }
}
