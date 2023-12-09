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

            //zadeklaruj słownik z literami alfabetu
            homophonicMapping.Add('A', new List<string> { "92", "48", "18", "04", "17", "82", "34", "58", "41" });
            homophonicMapping.Add('Ą', new List<string> { "45" });
            homophonicMapping.Add('B', new List<string> { "19" });
            homophonicMapping.Add('C', new List<string> { "80", "73", "95", "66" });
            homophonicMapping.Add('Ć', new List<string> { "12" });
            homophonicMapping.Add('D', new List<string> { "21", "68", "40" });
            homophonicMapping.Add('E', new List<string> { "23", "76", "62", "57", "01", "56", "44", "65" });
            homophonicMapping.Add('Ę', new List<string> { "50" });
            homophonicMapping.Add('F', new List<string> { "32" });
            homophonicMapping.Add('G', new List<string> { "29" });
            homophonicMapping.Add('H', new List<string> { "35" });
            homophonicMapping.Add('I', new List<string> { "89", "10", "93", "15", "63", "72", "11", "24" });
            homophonicMapping.Add('J', new List<string> { "28", "70" });
            homophonicMapping.Add('K', new List<string> { "78", "98", "81", "69" });
            homophonicMapping.Add('L', new List<string> { "26", "88" });
            homophonicMapping.Add('Ł', new List<string> { "42", "77" });
            homophonicMapping.Add('M', new List<string> { "97", "13", "36" });
            homophonicMapping.Add('N', new List<string> { "03", "14", "75", "74", "71", "55" });
            homophonicMapping.Add('Ń', new List<string> { "25" });
            homophonicMapping.Add('O', new List<string> { "08", "53", "07", "94", "49", "09", "54", "38" });
            homophonicMapping.Add('Ó', new List<string> { "47" });
            homophonicMapping.Add('P', new List<string> { "20", "64", "61" });
            homophonicMapping.Add('Q', new List<string> { "59" });
            homophonicMapping.Add('R', new List<string> { "33", "37", "84", "46", "86" });
            homophonicMapping.Add('S', new List<string> { "31", "52", "60", "83" });
            homophonicMapping.Add('Ś', new List<string> { "16" });
            homophonicMapping.Add('T', new List<string> { "85", "22", "67", "91" });
            homophonicMapping.Add('U', new List<string> { "90", "79", "74" });
            homophonicMapping.Add('V', new List<string> { "43" });
            homophonicMapping.Add('W', new List<string> { "30", "51", "96", "87", "05" });
            homophonicMapping.Add('X', new List<string> { "27" });
            homophonicMapping.Add('Y', new List<string> { "06", "99", "16", "02" });
            homophonicMapping.Add('Z', new List<string> { "59", "28", "75", "92", "70", "43" });
            homophonicMapping.Add('Ż', new List<string> { "39" });
            homophonicMapping.Add('Ź', new List<string> { "58", "76" });
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
