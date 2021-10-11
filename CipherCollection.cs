using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Encryptor
{
    class CipherCollection : ICipher, IEnumerable<Cipher>
    {
        public List<Cipher> CipherList = new List<Cipher>();
        public int Count { get{ return CipherList.Count;}}
        /// <summary>
        /// Denna metod kallar på alla chiffers decrypt metod som finns i CipherList.
        /// </summary>
        /// <param name="input"> Texten i textboxen. </param>
        /// <returns> Returnerar den dektypterade stringen </returns>
        public string Decrypt(string input)
        {
            for (int i = CipherList.Count - 1; i >= 0; i--)
            {
                Cipher ObjectsInBox = CipherList[i];
                input = ObjectsInBox.Decrypt(input);
            }
            return input;
        }
        /// <summary>
        ///  Denna metod kallar på alla chiffers encrypt metoder som finns i CipherList.  
        /// </summary>
        /// <param name="input"> Texten i textboxen. </param>
        /// <returns> Returnerar den krypterade stringen /returns>
        public string Encrypt(string input)
        {
            for (int i = 0; i < CipherList.Count; i++)
            {
                Cipher ObjectsInBox = CipherList[i];
                input = ObjectsInBox.Encrypt(input);
            }
            return input;
        }
        public IEnumerator<Cipher> GetEnumerator()
        {
            return CipherList.GetEnumerator();
        } 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return CipherList.GetEnumerator();
        }
        /// <summary>
        /// Denna metod lägger till chiffer i CipherList.
        /// </summary>
        /// <param name="item"> Objekt som finns i listan. </param>
        public void Add(Cipher item)
        {
            CipherList.Add(item);
        }
        /// <summary>
        /// Denna metod tar bort chiffer från CipherList
        /// </summary>
        /// <param name="item"> Objektet som finns i listan. </param>
        public void Remove(Cipher item)
        {
            CipherList.Remove(item);
        }
    }
}
