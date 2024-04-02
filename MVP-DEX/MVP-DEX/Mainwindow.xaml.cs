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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MVP_DEX
{
    /// <summary>
    /// Clasa care definește logica interacțiunii pentru MainWindow.xaml.
    /// </summary>
    public partial class Mainwindow : Window
    {
        // Constructorul
        public Mainwindow()
        {
            InitializeComponent();
        }

        //Buton cautare
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search sm = new Search();
            this.Close();
            sm.Show();
        }

        //Buton joc
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Entertainment em = new Entertainment();
            this.Close();
            em.Show();
        }

        //Buton admin
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Administrativ am = new Administrativ();
            this.Close();
            am.Show();
        }
    }
}
