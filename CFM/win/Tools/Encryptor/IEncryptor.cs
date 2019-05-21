using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.Tools.Encryptor
{
    interface IEncryptor
    {
        string Encrypt(string plaintext);        
    }
}
