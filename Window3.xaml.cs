using CaesarCipherWPF;
using HomophonicCipherWPF;
using System;
using System.Windows;

//do wygenerowanej liczby (przecięcie współrzędnych z tablicy) dodawana jest liczba 2 a następnie suma podnoszona jest do kwadratu)
//

namespace Szyfry
{
    public partial class Window3 : Window
    {
        private char[,] polibiuszTable = {
            {'a', 'ą', 'b', 'c', 'ć', 'd', 'e'},
            {'ę', 'f', 'g', 'h', 'i', 'j', 'k'},
            {'l', 'ł', 'm', 'n', 'ń', 'o', 'ó'},
            {'p', 'q', 'r', 's', 'ś', 't', 'u'},
            {'v', 'w', 'x', 'y', 'z', 'ź', 'ż'}
        };

        public Window3()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextTextBox.Text.ToLower();
            string encryptedText = Encrypt(plainText);
            ResultTextBox.Text = encryptedText;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = ResultTextBox.Text;
            string decryptedText = Decrypt(encryptedText);
            ResultTextBox.Text = decryptedText;
        }

        private string Encrypt(string input)
        {
            input = input.ToLower();
            string encryptedMessage = "";

            foreach (char character in input)
            {
                if (character == ' ')
                {
                    encryptedMessage += ' ';
                    continue;
                }

                for (int i = 0; i < polibiuszTable.GetLength(0); i++)
                {
                    for (int j = 0; j < polibiuszTable.GetLength(1); j++)
                    {
                        if (polibiuszTable[i, j] == character)
                        {
                            // Dodaj 2, a następnie podnieś do kwadratu
                            int encryptedValue = (i + 1) * 10 + (j + 1) + 2;
                            encryptedMessage += (encryptedValue * encryptedValue).ToString() + ' ';
                            break;
                        }
                    }
                }
            }

            return encryptedMessage.Trim();
        }

        private string Decrypt(string input)
        {
            string decryptedMessage = "";

            string[] pairs = input.Split(' ');

            foreach (string pair in pairs)
            {
                if (pair == "")
                {
                    decryptedMessage += ' ';
                    continue;
                }

                // Wydobywanie liczby z pary, odejmowanie 2 i pierwiastkowanie kwadratowe
                int decryptedValue = (int)Math.Sqrt(int.Parse(pair)) - 2;
                int row = decryptedValue / 10 - 1;
                int col = decryptedValue % 10 - 1;

                decryptedMessage += polibiuszTable[row, col];
            }

            return decryptedMessage;
        }










        private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();
            this.Close();

            newWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1();

            this.Close();
            newWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 newWindow = new Window2();

            this.Close();
            newWindow.Show();
        }
    }
}
