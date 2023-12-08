using System;
using System.Text;
using System.Windows;

namespace Szyfry
{
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextTextBox.Text.ToUpper();
            string key = ShiftTextBox.Text.ToUpper();

            string encryptedText = Encrypt(plainText, key);
            ResultTextBox.Text = encryptedText;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string encryptedText = ResultTextBox.Text.ToUpper();
            string key = ShiftTextBox.Text.ToUpper();

            string decryptedText = Decrypt(encryptedText, key);
            ResultTextBox.Text = decryptedText;
        }

        private string Encrypt(string input, string key)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            int keyIndex = 0;

            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    int shift = key[keyIndex] - 'A';
                    char encryptedChar = (char)(((character - 'A' + shift) % 26) + 'A');
                    encryptedMessage.Append(encryptedChar);

                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    encryptedMessage.Append(character);
                }
            }

            return encryptedMessage.ToString();
        }

        private string Decrypt(string input, string key)
        {
            StringBuilder decryptedMessage = new StringBuilder();
            int keyIndex = 0;

            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    int shift = key[keyIndex] - 'A';
                    char decryptedChar = (char)(((character - 'A' - shift + 26) % 26) + 'A');
                    decryptedMessage.Append(decryptedChar);

                    keyIndex = (keyIndex + 1) % key.Length;
                }
                else
                {
                    decryptedMessage.Append(character);
                }
            }

            return decryptedMessage.ToString();
        }

    



        // Pozostała część kodu pozostaje bez zmian
        // ...
    }
}
