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
    public partial class Modify : Window
    {
        public string modified_word { get; set; }

       
        public Modify()
        {
            InitializeComponent();
        }

        //buton inapoi
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Administrativ mn = new Administrativ();
            this.Close();
            mn.Show();
        }

        // BUTON MODIFICARE
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //SE CAUTA CUVNATUL DE MODIFICAT IN LISTA CUVINTELOR
            Word w = (DataContext as Autocomplete).SearchWord(modified_word);

            //se construiește o linie nouă cu datele actualizate ale cuvântului.
            string line = text.Text + "," + category.Text + "," + description.Text + "," + path.Text;

            //se construiește linia care va fi eliminată din fișierul text.
            string rm_line = w.text + "," + w.category + "," + w.description + "," + w.picture_path;

            //se inițializează un fișier temporar.
            var tempFile = @"C:\Users\andre\Desktop\MVP-DEX\TextFile2.txt";

            //se citesc liniile din fișierul original, excludând linia de șters.
            var linesToKeep = File.ReadLines(@"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt").Where(l => l != rm_line);

            //se scriu liniile valide în fișierul temporar.
            File.WriteAllLines(tempFile, linesToKeep);

            //se șterge fișierul original și se redenumește fișierul temporar.
            File.Delete(@"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt");
            File.Move(@"C:\Users\andre\Desktop\MVP-DEX\TextFile2.txt", @"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt");

            //se ajustează lungimea fișierului pentru a elimina un caracter gol la final.
            FileStream fs = new FileStream(@"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt", FileMode.Open, FileAccess.ReadWrite);
            fs.SetLength(fs.Length - 1);
            fs.Close();

            //se adaugă linia nouă în fișierul text.
            File.AppendAllText(@"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt", line);

            //se afișează un mesaj de confirmare după modificarea cuvântului.
            MessageBox.Show("Cuvântul a fost modificat cu succes!", "Confirmare", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //buton cautare cuvant selectat(modificat)
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //se obține cuvântul selectat pentru modificare din lista de combinații.
            string w = cb_modify.Text;
            modified_word = w;

            //se caută cuvântul în lista de cuvinte și se completează câmpurile pentru modificare.
            Word newWord = (DataContext as Autocomplete).SearchWord(w);
            text.Text = newWord.text;
            category.Text = newWord.category;
            description.Text = newWord.description;
            path.Text = newWord.picture_path;
        }
    }
}
