using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.Tools.Encryptor
{
    public interface IEncryptor
    {
        string Encrypt(string plaintext);
        string Decrypt(string secrettext);
    }
}
