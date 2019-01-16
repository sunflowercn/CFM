using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace win.form.Device.CommDevice
{
    public class Chen_SD:BaseCommDev
    {
        public Chen_SD(string comprot) : base(comprot)
        {
            this.serialport.BaudRate = 9600;
            this.serialport.StopBits = StopBits.One;
        }

        public override string ReadData()
        {
            return base.ReadData();
        }
    }
}
