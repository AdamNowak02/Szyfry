using CaesarCipherWPF;
using HomophonicCipherWPF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Szyfry
{
    public partial class Window4 : Window
    {
        private readonly Dictionary<char, int> PolishAlphabetMap = new Dictionary<char, int>
        {
            {'A', 0}, {'Ą', 1}, {'B', 2}, {'C', 3}, {'Ć', 4}, {'D', 5},
            {'E', 6}, {'Ę', 7}, {'F', 8}, {'G', 9}, {'H', 10}, {'I', 11},
            {'J', 12}, {'K', 13}, {'L', 14}, {'Ł', 15}, {'M', 16}, {'N', 17},
            {'Ń', 18}, {'O', 19}, {'Ó', 20}, {'P', 21}, {'Q', 22}, {'R', 23},
            {'S', 24}, {'Ś', 25}, {'T', 26}, {'U', 27}, {'V', 28}, {'W', 29},
            {'X', 30}, {'Y', 31}, {'Z', 32}, {'Ź', 33}, {'Ż', 34}
        };

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
                if (PolishAlphabetMap.ContainsKey(character))
                {
                    int shift = PolishAlphabetMap[key[keyIndex]];
                    char encryptedChar = GetPolishAlphabetChar((PolishAlphabetMap[character] + shift) % 35);
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
                if (PolishAlphabetMap.ContainsKey(character))
                {
                    int shift = PolishAlphabetMap[key[keyIndex]];
                    char decryptedChar = GetPolishAlphabetChar((PolishAlphabetMap[character] - shift + 35) % 35);
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

        private char GetPolishAlphabetChar(int index)
        {
            foreach (var pair in PolishAlphabetMap)
            {
                if (pair.Value == index)
                {
                    return pair.Key;
                }
            }
            return ' '; // Handle the case where the character is not found
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 newWindow = new Window2();

            this.Close();
            newWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window3 newWindow = new Window3();

            this.Close();
            newWindow.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1();

            this.Close();
            newWindow.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new MainWindow();

            this.Close();
            newWindow.Show();
        }
    }
}
