using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVP_DEX
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Calea către fișierul dvs. text
            string filePath = "C:\\Users\\andre\\Desktop\\MVP-DEX\\admin.txt";

            // Citirea liniilor din fișier
            var lines = File.ReadLines(filePath).ToList();

            // Presupunem că numele de utilizator este pe prima linie și parola pe a doua
            string username = lines[0];
            string password = lines[1];

            // Verificăm dacă numele de utilizator și parola introduse se potrivesc cu cele din fișier
            if (usernameTextBox.Text == username && passwordBox.Password == password)
            {
                Mainwindow mainWindow = new Mainwindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // Afișați un mesaj de eroare dacă numele de utilizator sau parola sunt incorecte
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
