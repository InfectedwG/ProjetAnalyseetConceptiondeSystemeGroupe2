
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for GererEmploye.xaml
    /// </summary>
    public partial class GererEmploye : Window
    {
        
        public MainWindow model;

        /// <summary> 
        /// Initialise une nouvelle instance de la classe <see cref="GererEmploye"/> 
        /// </summary> 
        /// <param name="model"> L'objet de la fenêtre principale. </param> 
        public GererEmploye(MainWindow model)
        {
            InitializeComponent();
            this.model = model;
           
        }

        /// <summary>
        /// Cette méthode gère l'événement click du bouton "Retour".
        /// Elle ferme la fenêtre actuelle et ouvre la fenêtre principale.
        /// </summary>
         ///<param name="sender">Objet qui a déclenché l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>
        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
            model.Show();
        }

        /// <summary>
        /// Cette méthode gère l'événement click du bouton "Ajouter".
        /// Elle insère les données d'un nouvel employé dans la table "VotreTable".
        /// </summary>
        ///<param name="sender">Objet qui a déclenché l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string nom = txbNom.ToString();
            TimeOnly hdLundi;
        }


        /// <summary> 
        /// Gère l'événement Click du champ BtnSupprimer.
        /// Supprime un enregistrement d'employé de la base de données en fonction du nom saisi dans la zone de texte idnom. 
        /// Affiche une boîte de message pour indiquer si l'opération a réussi ou non.
        /// </summary> 
        ///<param name="sender">Objet qui a déclenché l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>
        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
    }
