using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.Tools.Encryptor
{
    interface IDecryptor
    {
        string Decrypt(string secrettext);
    }
}
