using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Encryptor
{
    public class ReversalCipher : Cipher
    {
        /// <summary>
        /// Klassens konstruktor sätter Ciphernames namn.
        /// </summary>
        /// <param name="CN"> Namnet på chiffret som matas in när ett objekt av denna klass instansieras. </param>
        public ReversalCipher(string CN) : base(CN)
        {
            CipherName = CN;
        }
        /// <summary>
        /// Metoden tar emot en string och kallar på Reverse som vänder på stringen.
        /// </summary>
        /// <param name="input">Texten i textboxen</param>
        /// <returns>Returnerar den reversade stringen</returns>
        public override string Decrypt(string input)
        {
            return Reverse(input);
        }
        /// <summary>
        /// Metoden tar emot en string och kallar på Reverse som vänder på stringen.
        /// </summary>
        /// <param name="input">Texten i textboxen.</param>
        /// <returns>Returnerar den reversade stringen.</returns>
        public override string Encrypt(string input)
        {
            return Reverse(input);
        }
        /// <summary>
        ///  Metoden tar emot en string och skriver ut den baklänges.
        /// </summary>
        /// <param name="input"> Input i form av en string</param>
        /// <returns>Metoden returnerar den nya stringen som är input fast baklänges. </returns>
        public string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
