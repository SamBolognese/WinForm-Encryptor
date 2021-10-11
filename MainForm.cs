using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel.Design;

namespace The_Encryptor
{
    public partial class MainForm : Form
    {
        CipherCollection CipherList = new CipherCollection();
        int EncryptionCount = 0;
        public MainForm()
        {
            InitializeComponent();
            Populate_List();
        }
        public void Populate_List()
        {
            ReversalCipher reversalCipher = new ReversalCipher("Reversal Cipher");
            CaesarCipher caesarCipher1 = new CaesarCipher(1, "Caesar Cipher 1 step");
            RövarLanguage rövarCipher = new RövarLanguage("Rövarspråk Cipher");
            OddAndEvenCipher oddevenCiper = new OddAndEvenCipher("Odd and Even Cipher");
            AvailableCipherBox.Items.Add(reversalCipher);
            AvailableCipherBox.Items.Add(caesarCipher1);
            AvailableCipherBox.Items.Add(rövarCipher);
            AvailableCipherBox.Items.Add(oddevenCiper);
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (InputBox.Text == "")
            {
                MessageBox.Show("You must write an input.");
            }
            else if (ChosenCipherBox.Items.Count == 0)
            {
                MessageBox.Show("You must choose a cipher to encrypt with.");
            }
            else
            {
                InputBox.Text = CipherList.Encrypt(InputBox.Text);
            }
            EncryptionCount ++;
        }      
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (EncryptionCount != 0)
            {
                InputBox.Text = CipherList.Decrypt(InputBox.Text);
                EncryptionCount --;
            }
            else MessageBox.Show("You have nothing to Decrypt.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (EncryptionCount != 0)
            {
                MessageBox.Show("You can't add ciphers after encryption.");
            }
            else if(AvailableCipherBox.SelectedItem != null)
            {
                ChosenCipherBox.Items.Add(AvailableCipherBox.SelectedItem);
                CipherList.Add((Cipher)AvailableCipherBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("You have not selected anything to add.");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (ChosenCipherBox.Items.Count == 0)
            {
                MessageBox.Show("You have nothing to remove.");
            }
            if (EncryptionCount != 0)
            {
                InputBox.Text = CipherList.Decrypt(InputBox.Text);
                CipherList.Remove((Cipher)ChosenCipherBox.SelectedItem);
                ChosenCipherBox.Items.Remove(ChosenCipherBox.SelectedItem);
                InputBox.Text = CipherList.Encrypt(InputBox.Text);
            }
            else
            {
                ChosenCipherBox.Items.Remove(ChosenCipherBox.SelectedItem);
                CipherList.Remove((Cipher)ChosenCipherBox.SelectedItem);
            }
            if (ChosenCipherBox.Items.Count == 0)
            {
                EncryptionCount = 0;
            }
        }
    }
}
