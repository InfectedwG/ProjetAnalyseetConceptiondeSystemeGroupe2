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

namespace Analyse
{
    /// <summary>
    /// Interaction logic for Recherche.xaml
    /// </summary>
    public partial class Recherche : Window
    {

        public MainWindow Model;

        public Recherche(MainWindow model)
        {
            InitializeComponent();
            Model = model;
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
           
                this.Close();
                Model.Show();
            

        }
    }
}
