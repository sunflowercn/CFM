using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace win.form.Device.CommDevice
{
    public abstract class BaseCommDev
    {
        protected SerialPort serialport;
        public BaseCommDev(string comprot)
        {
            this.serialport = new SerialPort(comprot);
            this.serialport.DataReceived += Serialport_DataReceived;
        }

        private void Serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);
            int count = this.serialport.BytesToRead;
            if (count == 0)
                return;

            byte[] bytes = new byte[count];
            this.serialport.Read(bytes, 0, count);
        }

        public void Open()
        {
            this.serialport.Open();
        }
        public void Close()
        {
            this.serialport.Close();
        }
        public void WriteData(string text)
        {
            if (!this.serialport.IsOpen)
                this.Open();

            this.serialport.Write(text);
        }
        public virtual String ReadData()
        {
            return null;
        }
    }
}
