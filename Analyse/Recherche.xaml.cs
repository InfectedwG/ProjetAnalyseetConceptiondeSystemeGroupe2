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

        /// <summary>
        /// Initialise une nouvelle instance de la classe Recherche avec le modèle MainWindow spécifié.
        /// </summary>
        /// <param name="model">Le modèle MainWindow à utiliser</param>
        public Recherche(MainWindow model)
        {
            InitializeComponent();
            Model = model;
        }
        /// <summary>
        /// Gère l'événement Click du champ BtnRetour.
        /// Ferme la fenêtre de recherche et affiche la fenêtre principale.
        /// </summary>
        ///<param name="sender">Objet qui a déclenché l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
           
                this.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            

        }
    }
}
