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
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
        }

        //buton de revenire la admin
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Administrativ am = new Administrativ();
            this.Close();
            am.Show();
        }

        //metoda click buton stergere
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //se obt cuvantul din lista
            string w = cb.Text;

            //se cauta cuvantul in lista
            Word aux_word = (this.DataContext as Autocomplete).SearchWord(w);

            //se face o linia aux ce v-a fi stearsa
            string rm_line = aux_word.text + "," + aux_word.category + "," + aux_word.description + "," + aux_word.picture_path;

            //se initializeaza un fisier temporar
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

            //mesaj de confirmare
            MessageBox.Show("Cuvântul a fost șters cu succes!", "Confirmare", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
