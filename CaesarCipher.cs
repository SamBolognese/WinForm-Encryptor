using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Encryptor
{
    public class CaesarCipher : Cipher
    {
        public int key { get; private set; }
        /// <summary>
        /// Metodens konstruktor sätter Ciphername och keys värden.
        /// </summary>
        /// <param name="Key"> Int värde som representerar antalet steg som ska hoppas i chiffret. </param>
        /// <param name="CN"> Namnet på chiffret som matas in när ett objekt av denna klass instansieras. </param>
        public CaesarCipher(int Key, string CN) : base(CN)
        {
            key = Key;
            CipherName = CN;

        }
        /// <summary>
        /// Metoden kallar på LetterConvert metoden och matar in input i form av en string och nyckeln som representerar hur många steg tillbaka den ska gå för att man ska kunna decryptera meningen.  
        /// </summary>
        /// <param name="input">Texten i textboxen.</param>
        /// <returns> Returnerar den nya strängen som är decryptad. </returns>
        public override string Decrypt(string input)
        {
            char[] temp = LetterConvert(input, -key).ToCharArray();
            for(int i = 0; i < temp.Length; i++)
            {
                if(temp[i] == '`')
                {
                    temp[i] = 'z';
                }
                if (temp[i] == '@')
                {
                    temp[i] = 'Z';
                }
            }
            return new string(temp);
        }

        /// <summary>
        ///  Metoden kallar på LetterConvert metoden och matar in input i form av en string och nyckeln som representerar antalet steg som chiffret ska hoppa.  
        /// </summary>
        /// <param name="input">Texten i textboxen.</param>
        /// <returns> Returnerar den nya strängen som är encryptad. </returns>
        public override string Encrypt(string input)
        {
            return LetterConvert(input, key);
        }
        /// <summary>
        ///  Denna metod tar emot en nyckel och en string, sedan gör den om stringen så att beroende på vilket nummer som matats in i key hoppar den så många steg i alfabetet. 
        /// </summary>
        /// <param name="input">Texten i textboxen.</param>
        /// <param name="key">Int värde som representerar antalet steg som ska hoppas i chiffret.</param>
        /// <returns> Returnerar den nya och krypterade stringen. </returns>
        public string LetterConvert(string input, int key)
        {
            char[] CharArr = input.ToCharArray();
            for(int i = 0; i < CharArr.Length; i++)
            {
                CharArr[i] = GetCipherChar(input[i], key);
            }
            return new string(CharArr);
        }
        /// <summary>
        ///  Denna metod tar emot en char och returnar en char som är ett ett visst antal steg större eller mindre beroende på värdet av steps.
        /// </summary>
        /// <param name="c"> Den char som ska ändras. </param>
        /// <param name="steps"> Int värde som representerar antalet steg som ska hoppas i chiffret. </param>
        /// <returns> Returnerar den nya charactern </returns>
        private char GetCipherChar(char c, int steps)
        {
            List<char> specialCharacters = new List<char>() { 'å', 'ä', 'ö'};

            if(!char.IsLetter(c) || specialCharacters.Contains(char.ToLower(c)))
            {
                return c;
            }

            char d = char.IsUpper(c) ? 'A' : 'a';
                return (char)((((c + steps) - d) % 26) + d);

        }
    }
}
