using System;
using System.Collections;
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

namespace Analyse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArrayList<Employe> emp;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged()
        {

        }

        private void GererEmploye_Click(object sender, RoutedEventArgs e)
        {
            GererEmploye gererEmploye = new GererEmploye(this);
            gererEmploye.Show();
            this.Visibility = Visibility.Collapsed;
        }

        private void rechercheEmploye_Click(object sender, RoutedEventArgs e)
        {
            Recherche recherche = new Recherche();
            recherche.Show();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
