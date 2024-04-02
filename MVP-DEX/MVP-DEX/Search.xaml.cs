using System;
using System.Collections.Generic;
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

    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

        //metoda adaugare cuvant nou in interfata de cauatere
        private void addItem(Word word)
        {
            TextBlock block = new TextBlock();

            block.Text = word.text;

            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            //apasare click pe un cuvant din lista de cuvinte cautate
            block.MouseLeftButtonUp += (sender, e) =>
            {
                textBox.Text = (sender as TextBlock).Text;

                Word aux_word = (this.DataContext as Autocomplete).SearchWord(textBox.Text);
                descript.Text = aux_word.description;
                Picture.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(aux_word.picture_path);
            };

            //tinere mosue pe un cuvant din lista de cuvinte cautate
            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.DarkTurquoise;
            };

            //revenirea mouseului inafara listei de cuvinte
            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;
            };

            //adăugarea elementului în interfața de căutare.
            resultStack.Children.Add(block);
        }

        //metoda apelată la tastarea unui text în câmpul de căutare.
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            var data = (this.DataContext as Autocomplete).word_list;
            var aux_word = (this.DataContext as Autocomplete).newWord;

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            resultStack.Children.Clear();

            //parcurgerea listei de cuvinte pentru a găsi cele care corespund criteriilor de căutare.
            foreach (var obj in data)
            {

                if (obj.text.ToLower().StartsWith(query.ToLower()) && aux_word.category == "Nicio categorie")
                {
                    addItem(obj);
                    found = true;
                }
                else
                    if (obj.text.ToLower().StartsWith(query.ToLower()) && obj.category == aux_word.category)
                {
                    addItem(obj);
                    found = true;
                }
            }

            //afișarea unui mesaj dacă nu s-au găsit rezultate.
            if (!found)
            {
                resultStack.Children.Add(new TextBlock() { Text = "No results found." });
            }
        }

        //revenire la meniu principal
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainwindow menu = new Mainwindow();
            this.Close();
            menu.Show();
        }

        //metoda apelată la schimbarea selecției în combinație.
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
