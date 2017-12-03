using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.CardService
{
    public interface ICardDevice
    {
        void ReadCard();

        event EventHandler AfterReadCard;
    }
}
