using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Encryptor 
{
    public class OddAndEvenCipher : Cipher
    {
        public string temp { get; private set; }
        /// <summary>
        /// Denna konstruktor tar emot namnet på chiffret.
        /// </summary>
        /// <param name="CN"> String i form av namn på chiffret. </param>
        public OddAndEvenCipher(string CN) : base(CN)
        {
            CipherName = CN;
        }
        /// <summary>
        /// Denna metod delar upp stringen i två delar och sätter sedan ihop dem i en ny string.
        /// </summary>
        /// <param name="input">Texten i textboxen.</param>
        /// <returns> Returnerar en string som innehåller det man skrivit från början.</returns>
        public override string Decrypt(string input)
        {
            string odd = input.Substring(0, input.Length / 2);
            string even = input.Substring(input.Length / 2);
            string output = "";

            for(int i = 0; i < even.Length; i++)
            {
                try
                {
                    output += even[i];
                    output += odd[i];
                }
                catch
                {
                }
            }
            return output;
        }
        /// <summary>
        ///  Denna metod flyttar alla bokstäver på udda indexpositioner längst fram och flyttar alla bokstäver på jämna indexpositioner längst bak.
        /// </summary>
        /// <param name="input">Texten i textboxen.</param>
        /// <returns> Returnerar den krypterade stringen </returns>
        public override string Encrypt(string input)
        {
            string udda = "";
            string jämt = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0)
                {
                    udda += input[i];
                }
                else jämt += input[i];
            }
            string resultat = (udda + jämt);
            return resultat;
        }
    }
}
