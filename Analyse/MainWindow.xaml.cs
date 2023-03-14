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
    ///  Ce constructeur initialise une nouvelle instance de la classe MainWindow.
    /// </summary>
    public partial class MainWindow : Window
    {
        private ArrayList<Employe> emp;
        public MainWindow()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 
        /// </summary>
        private void TextBox_TextChanged()
        {

        }

        /// <summary>
        /// Cette méthode est appelée lorsque l'utilisateur clique sur le bouton "GererEmploye". Elle ouvre une nouvelle fenêtre "GererEmploye" et masque la fenêtre principale.
        /// </summary>
        ///<param name="sender">Objet qui a déclenché l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>
        private void GererEmploye_Click(object sender, RoutedEventArgs e)
        {
            GererEmploye gererEmploye = new GererEmploye(this);
            gererEmploye.Show();
            this.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Cette méthode est appelée lorsque l'utilisateur clique sur le bouton "rechercheEmploye". Elle ouvre une nouvelle fenêtre "Recherche" et masque la fenêtre principale.
        /// </summary>
        ///<param name="sender">Objet qui a déclenché l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>
        private void rechercheEmploye_Click(object sender, RoutedEventArgs e)
        {
            Recherche recherche = new Recherche();
            recherche.Show();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
