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
    public partial class Administrativ : Window
    {
        //Constructor
        public Administrativ()
        {
            InitializeComponent();
        }

        //Buton revenire
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainwindow menu = new Mainwindow();
            this.Close();
            menu.Show();
        }

        //Metoda adaugare cuvnat nou
        private void Add_word(object sender, RoutedEventArgs e)
        {
            // Obține cuvântul nou și efectuează operațiile corespunzătoare în funcție de datele introduse.
            Word newWord = (DataContext as Autocomplete).newWord;
            if (newWord.category == "" && newWord.text != "" && newWord.description != "")
            {
                string newLine = "\n" + newWord.text + "," + newCat.Text + "," + newWord.description + "," + newWord.picture_path;
                File.AppendAllText(@"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt", newLine);
                (DataContext as Autocomplete).word_list.Add(new Word(newWord.text, newCat.Text, newWord.description, newWord.picture_path));
                (DataContext as Autocomplete).text_list.Add(newWord.text);
            }
            else
               if (newWord.text != "" && newWord.category != "" && newWord.description != "")
            {
                string newLine = "\n" + newWord.text + "," + newWord.category + "," + newWord.description + "," + newWord.picture_path;
                File.AppendAllText(@"C:\Users\andre\Desktop\MVP-DEX\TextFile1.txt", newLine);
                (DataContext as Autocomplete).word_list.Add(new Word(newWord.text, newWord.category, newWord.description, newWord.picture_path));
                (DataContext as Autocomplete).text_list.Add(newWord.text);
            }

            //Mesaj de confirmare
            MessageBox.Show("Cuvântul nou a fost adăugat cu succes!", "Confirmare", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //Buton pentru meniu modificare
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Modify m = new Modify();
            this.Close();
            m.Show();
        }

        //Buton pentru meniu stergere
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Delete d = new Delete();
            this.Close();
            d.Show();
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}