using HomophonicCipherWPF;
using System;
using System.Windows;
using System.Windows.Input;
using Szyfry;

namespace CaesarCipherWPF
{
    public partial class MainWindow : Window
    {
        private static readonly string PolishAlphabet = "aąbcćdeęfghijklłmnńoóprsśtuwyzźż";

        public MainWindow()
        {
            InitializeComponent();

            PlainTextTextBox.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
            ShiftTextBox.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
            ResultTextBox.SetValue(InputMethod.IsInputMethodEnabledProperty, false);
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ShiftTextBox.Text, out int shift) && shift >= 1 && shift <= 31)
            {
                ResultTextBox.Text = Encrypt(PlainTextTextBox.Text.ToLower(), shift).Replace(" ", "");
            }
            else
            {
                MessageBox.Show("Podaj poprawną liczbę całkowitą od 1 do 31 jako przesunięcie!", "Błędne dane");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ShiftTextBox.Text, out int shift) && shift >= 1 && shift <= 31)
            {
                ResultTextBox.Text = Decrypt(PlainTextTextBox.Text.ToLower(), shift).Replace(" ", "");
            }
            else
            {
                MessageBox.Show("Podaj poprawną liczbę całkowitą od 1 do 31 jako przesunięcie!","Błędne dane");
            }
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

        private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Tworzymy nowe okno
            Window1 newWindow = new Window1();

            // Zamykamy bieżące okno
            this.Close();

            // Otwieramy nowe okno
            newWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 newWindow = new Window2();

            this.Close();
            newWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 newWindow = new Window3();

            this.Close();
            newWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window4 newWindow = new Window4();

            this.Close();
            newWindow.Show();
        }
    }
}