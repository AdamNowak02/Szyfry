using System;
using System.Windows;
using System.Windows.Input;

namespace CaesarCipherWPF
{
    public partial class MainWindow : Window
    {
        // Rozszerzony polski alfabet w małych literach
        private static readonly string PolishAlphabet = "aąbcćdeęfghijklłmnńoóprsśtuwyzźż";

        public MainWindow()
        {
            InitializeComponent();

            // Ustawienie kodowania na Unicode dla kontrolek tekstowych
            PlainTextTextBox.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
            ShiftTextBox.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
            ResultTextBox.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            int shift = Convert.ToInt32(ShiftTextBox.Text);
            ResultTextBox.Text = Encrypt(PlainTextTextBox.Text.ToLower(), shift).Replace(" ", "");
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            int shift = Convert.ToInt32(ShiftTextBox.Text);
            ResultTextBox.Text = Decrypt(PlainTextTextBox.Text.ToLower(), shift).Replace(" ", "");
        }

        private string Encrypt(string text, int shift)
        {
            char[] result = text.ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(result[i]))
                {
                    int index = (PolishAlphabet.IndexOf(result[i]) + shift) % PolishAlphabet.Length;
                    result[i] = PolishAlphabet[index];
                }
            }

            return new string(result);
        }

        private string Decrypt(string text, int shift)
        {
            return Encrypt(text, PolishAlphabet.Length - shift);
        }
    }
}
