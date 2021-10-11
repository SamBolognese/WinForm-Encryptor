using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Encryptor
{
    public interface ICipher
    {
        string Encrypt(string input);
        string Decrypt(string input);
        void Add(Cipher input);
        void Remove(Cipher input);
    }
}
