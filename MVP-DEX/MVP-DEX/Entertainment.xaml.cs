using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Entertainment : Window
    {
        //lista raspunsuri date
        public List<string> answears;
        //lista raspunsuri corecte asociate intrebarilor
        public List<string> ranswears;
        //nr întrebări.
        public int numberOfQuestions = new int();
        //lista tuturor cuv ce pot aparea in joc
        private ObservableCollection<Word> cuv_aparut;
        //cuvantul curent
        private Word currentWord;

        public Entertainment()
        {
            InitializeComponent();
            //inițializarea vizibilității rezultatului ca ascuns.
            res.Visibility = System.Windows.Visibility.Hidden;
            cuv_aparut = new ObservableCollection<Word>();

            //inițializarea listelor de răspunsuri.
            answears = new List<string>();
            ranswears = new List<string>();

            // Inițializarea numărului de întrebări.
            numberOfQuestions = 0;

            //generare intrebare aleatoare
            Random random = new System.Random();
            Autocomplete x = new Autocomplete();
            cuv_aparut = x.word_list;

            int value1 = random.Next(0, cuv_aparut.Count());
            currentWord = cuv_aparut[value1];
            ranswears.Add(currentWord.text);

            int value = random.Next(0, 2);

            //afisarea aleatoare a unui cuvant, daca acesta contine si imagine si o descriere se v-a selecta aleatoriu intre cele doua
            // daca cuvantul nu contine imagine se v-a afisa descrierea
            if (value == 0 || currentWord.picture_path == "C:\\Users\\andre\\Desktop\\MVP-DEX\\default.png")
            {
                des.Text = currentWord.description;
                des.Visibility = System.Windows.Visibility.Visible;
                lb.Content = "Descriere";
                img.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(currentWord.picture_path);
                lb.Content = "    Imagine";
                img.Visibility = System.Windows.Visibility.Visible;
                des.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        //click pentru inapoi
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mainwindow menu = new Mainwindow();
            this.Close();
            menu.Show();
        }

        //butonul next, inrebarea urmatoare
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //se ia raspunsul si se adauga in lista de raspunsuri
            string a = answ.Text;
            answears.Add(a);
            numberOfQuestions++;
            answ.Text = "";

            //se sterge cuvantul din lista decuvinte disponibile pentr a nu se repeta
            cuv_aparut.Remove(currentWord);

            //generare alta intrebare aleatoare
            Random random = new System.Random();
            int value1 = random.Next(0, cuv_aparut.Count());

            currentWord = cuv_aparut[value1];
            ranswears.Add(currentWord.text);

            int value = random.Next(0, 2);

            //la fel ca mai sus
            if (value == 0 || currentWord.picture_path == "C:\\Users\\andre\\Desktop\\MVP-DEX\\default.png")
            {
                des.Text = currentWord.description;
                des.Visibility = System.Windows.Visibility.Visible;
                lb.Content = "Description";
                img.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                img.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(currentWord.picture_path);
                lb.Content = "     Image";
                img.Visibility = System.Windows.Visibility.Visible;
                des.Visibility = System.Windows.Visibility.Hidden;
            }

            //daca s-a raspuns la 4 intrebari, la urmatoarea v-a fi finalul jocului
            if (numberOfQuestions == 4)
            {
                next.Content = "Final joc";
            }

            //afisare raspunsuri daca s-a raspuns la toate intrabarile
            if (numberOfQuestions == 5)
            {
                next.Visibility = System.Windows.Visibility.Hidden;
                des.Visibility = System.Windows.Visibility.Hidden;
                img.Visibility = System.Windows.Visibility.Hidden;
                answ.Visibility = System.Windows.Visibility.Hidden;
                lb.Visibility = System.Windows.Visibility.Hidden;
                res.Visibility = System.Windows.Visibility.Visible;
                string results = "";
                for (int index = 0; index < 5; index++)
                {
                    if (answears[index] == ranswears[index])
                        results += "Intrebarea " + (index + 1) + ": Raspuns corect!" + "\n";
                    else
                        results += "Intrebarea " + (index + 1) + ": Raspuns gresit!" + " Raspunsul corect este: " + ranswears[index] + "\n";
                }
                Console.WriteLine(results);
                res.Text = results;
            }
        }
    }
}
