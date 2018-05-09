using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace win.Tester
{
    public class TimeTester : IDisposable
    {
        private Stopwatch w = new Stopwatch();
        public long SpendTime
        {
            get { return w.ElapsedMilliseconds; }
        }
        public TimeTester()
        {
            w.Start();
        }
        public void Dispose()
        {
            this.Log();
        }
        private void Log()
        {
            w.Stop();
            System.Diagnostics.Debug.WriteLine("花费时间" + w.ElapsedMilliseconds);
        }
    }
}
