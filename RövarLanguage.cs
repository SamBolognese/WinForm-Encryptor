using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Encryptor
{
    public class RövarLanguage : Cipher
    {
        public string Vowels { get; private set; }
        /// <summary>
        /// Denna konstruktor tar emot namnet på chiffret.
        /// </summary>
        /// <param name="CN"> String i form av namn på chiffret. </param>
        public RövarLanguage(string CN) : base(CN)
        {
            CipherName = CN;
            Vowels = "aAeEiIoOuUyYåÅäÄöÖ";
        }
        /// <summary>
        ///  Denna metod lägger till ett o och samma konsonant som skrivts efter varje konsonant.
        /// </summary>
        /// <param name="input"> Texten i textboxen. </param>
        /// <returns> Returnerar den krypterade stringen </returns>
        public override string Encrypt(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (Vowels.Contains(input[i]))
                {
                    output += input[i];
                }
                else
                {
                    output += input[i];
                    output += 'o';
                    output += input[i];
                }
            }
            return output;
        }
        /// <summary>
        /// Denna metod tar emot en string och tar bort bokstäverna två indexpositioner bakom characters som inte är vokaler.
        /// </summary>
        /// <param name="input"> Texten i textboxen. </param>
        /// <returns> Returnerar den dekrypterade stringen. </returns>
        public override string Decrypt(string input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Vowels.Contains(input[i]))
                {
                    output += input[i];
                }
                else
                {
                    output += input[i];
                    i += 2;
                }
            }
            return output;
        }

    }
}
