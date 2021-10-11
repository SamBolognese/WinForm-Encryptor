using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Encryptor
{
    public abstract class Cipher
    {
        /// <summary>
        /// Denna konstruktor tar emot namnet på chiffret.
        /// </summary>
        /// <param name="CN"> String i form av namn på chiffret. </param>
        public Cipher(string CN)
        {
            CipherName = CN;
        }
        /// <summary>
        /// Denna metod returnerar chiffernamn.
        /// </summary>
        /// <returns>Returnerar en string som innehåller chiffernamn. </returns>
        public override string ToString()
        {
            return CipherName;
        }

        public string CipherName { get; set; }
        public abstract string Encrypt(string input);
        public abstract string Decrypt(string input);
    }
}
