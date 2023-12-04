using CaesarCipherWPF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Szyfry;

namespace HomophonicCipherWPF
{
    public partial class Window1 : Window
    {
        private Dictionary<char, List<string>> homophonicMapping;

        public Window1()
        {
            InitializeComponent();
            InitializeHomophonicMapping();
        }

        private void InitializeHomophonicMapping()
        {
            homophonicMapping = new Dictionary<char, List<string>>();

            homophonicMapping.Add('A', new List<string> { "01", "02", "03" });
            homophonicMapping.Add('Ą', new List<string> { "04", "05", "06" });
            homophonicMapping.Add('B', new List<string> { "07", "08", "09" });
            homophonicMapping.Add('C', new List<string> { "10", "11", "12" });
            homophonicMapping.Add('Ć', new List<string> { "13", "14" });
            homophonicMapping.Add('D', new List<string> { "15", "16", "17" });
            homophonicMapping.Add('E', new List<string> { "18", "19", "20" });
            homophonicMapping.Add('Ę', new List<string> { "21", "22" });
            homophonicMapping.Add('F', new List<string> { "23", "24", "25" });
            homophonicMapping.Add('G', new List<string> { "26", "27", "28" });
            homophonicMapping.Add('H', new List<string> { "29", "30", "31" });
            homophonicMapping.Add('I', new List<string> { "32", "33", "34" });
            homophonicMapping.Add('J', new List<string> { "35", "36", "37" });
            homophonicMapping.Add('K', new List<string> { "38", "39", "40" });
            homophonicMapping.Add('L', new List<string> { "41", "42", "43" });
            homophonicMapping.Add('Ł', new List<string> { "44", "45" });
            homophonicMapping.Add('M', new List<string> { "46", "47", "48" });
            homophonicMapping.Add('N', new List<string> { "49", "50", "51" });
            homophonicMapping.Add('Ń', new List<string> { "52", "53" });
            homophonicMapping.Add('O', new List<string> { "54", "55", "56" });
            homophonicMapping.Add('Ó', new List<string> { "57", "58" });
            homophonicMapping.Add('P', new List<string> { "59", "60", "61" });
            homophonicMapping.Add('Q', new List<string> { "62", "63" });
            homophonicMapping.Add('R', new List<string> { "64", "65", "66" });
            homophonicMapping.Add('S', new List<string> { "67", "68", "69" });
            homophonicMapping.Add('Ś', new List<string> { "70", "71" });
            homophonicMapping.Add('T', new List<string> { "72", "73", "74" });
            homophonicMapping.Add('U', new List<string> { "75", "76", "77" });
            homophonicMapping.Add('W', new List<string> { "78", "79", "80" });
            homophonicMapping.Add('Y', new List<string> { "81", "82", "83" });
            homophonicMapping.Add('Z', new List<string> { "84", "85", "86" });
            homophonicMapping.Add('Ż', new List<string> { "87", "88" });
            homophonicMapping.Add('Ź', new List<string> { "89", "90" });
        }


        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextTextBox.Text.ToUpper();
            string encryptedText = Encrypt(plainText);
            ResultTextBox.Text = encryptedText;
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string encryptedText = ResultTextBox.Text;
            string decryptedText = Decrypt(encryptedText);
            ResultTextBox.Text = decryptedText;
        }

        private string Encrypt(string plainText)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in plainText)
            {
                if (homophonicMapping.ContainsKey(c))
                {
                    List<string> codes = homophonicMapping[c];
                    int randomIndex = new Random().Next(codes.Count);
                    encryptedText.Append(codes[randomIndex]);
                }
                else
                {
                    encryptedText.Append(c);
                }
            }

            return encryptedText.ToString();
        }


        private string Decrypt(string encryptedText)
        {
            StringBuilder decryptedText = new StringBuilder();

            // Usuń ewentualne spacje z zakodowanego tekstu
            encryptedText = encryptedText.Replace(" ", "");

            // Odkoduj tekst
            for (int i = 0; i < encryptedText.Length; i++)
            {
                char c = encryptedText[i];

                // Sprawdź, czy znak jest w mapowaniu homofonicznym
                foreach (var entry in homophonicMapping)
                {
                    if (entry.Value.Contains(encryptedText.Substring(i, Math.Min(2, encryptedText.Length - i))))
                    {
                        decryptedText.Append(entry.Key.ToString().ToLower());
                        i++; // Przeskocz do następnego znaku kodu
                        break;
                    }
                    else if (entry.Key == c)
                    {
                        decryptedText.Append(c);
                        break;
                    }
                }
            }

            return decryptedText.ToString();
        }

        private void OpenNewWindowButton_Click(object sender, RoutedEventArgs e)
        {
            // Tworzymy nowe okno
            MainWindow newWindow = new MainWindow(); // Zmieniono z "MainWindow" na "Window1"

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
    }
}
