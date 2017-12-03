using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.CardService.drivers
{
    class URF_R330_CardDevice:ICardDevice
    {
        public void ReadCard()
        {
          
            if(this.AfterReadCard!=null)
            {
                ReadCardEventArgs e=new ReadCardEventArgs();
                this.AfterReadCard(this, e);
            }
        }
        public event EventHandler AfterReadCard;
    }

    public class ReadCardEventArgs : EventArgs
    {
        public string CardNo { get; set; }
    }
}
