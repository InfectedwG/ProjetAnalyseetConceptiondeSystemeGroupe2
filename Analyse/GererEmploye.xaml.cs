
using System;
using System.Collections.Generic;
using System.Data;
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
        private string connectionString = "Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;User ID=USER_ID;Password=PASSWORD;";
        private MainWindow model;

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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        /// <summary>
        /// Cette méthode gère l'événement click du bouton "Ajouter".
        /// Elle insère les données d'un nouvel employé dans la table "VotreTable".
        /// </summary>
        ///<param name="sender">Objet qui a déclenché l'événement.</param>
        /// <param name="e">Arguments de l'événement.</param>

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {

            string nom = txbNom.Text;
            //------------verifier si lemployer existe



            ComboBoxItem[,] tabItems = {
                { (ComboBoxItem)HDLundi.SelectedItem, (ComboBoxItem)HFLundi.SelectedItem, (ComboBoxItem)MDLundi.SelectedItem, (ComboBoxItem)MFLundi.SelectedItem },
                { (ComboBoxItem)HDMardi.SelectedItem, (ComboBoxItem)HFMardi.SelectedItem, (ComboBoxItem)MDMardi.SelectedItem, (ComboBoxItem)MFMardi.SelectedItem },
                { (ComboBoxItem)HDMercredi.SelectedItem, (ComboBoxItem)HFMercredi.SelectedItem, (ComboBoxItem)MDMercredi.SelectedItem, (ComboBoxItem)MFMercredi.SelectedItem },
                { (ComboBoxItem)HDJeudi.SelectedItem, (ComboBoxItem)HFJeudi.SelectedItem, (ComboBoxItem)MDJeudi.SelectedItem, (ComboBoxItem)MFJeudi.SelectedItem },
                { (ComboBoxItem)HDVendredi.SelectedItem, (ComboBoxItem)HFVendredi.SelectedItem, (ComboBoxItem)MDVendredi.SelectedItem, (ComboBoxItem)MFVendredi.SelectedItem }
            };

            string[,] tabString = new string[5, 4];
            string[] tabJours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi" };
            List<Disponibilite> listeDispos = new List<Disponibilite>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tabString[i, j] = tabItems[i, j].Content.ToString();
                }
            }


            //-----------verifier les dispos

            for (int i = 0; i < 5; i++)
            {
                Disponibilite temp;
                if (tabString[i, 0] != "N/A" && tabString[i, 1] != "N/A" && tabString[i, 2] != "N/A" && tabString[i, 3] != "N/A")
                {
                    TimeOnly debut = new TimeOnly(int.Parse(tabString[i, 0]), int.Parse(tabString[i, 2]));
                    TimeOnly fin = new TimeOnly(int.Parse(tabString[i, 1]), int.Parse(tabString[i, 3]));


                    temp = new Disponibilite(debut, fin, tabJours[i]);
                    listeDispos.Add(temp);
                }

            }
            Employe employe;
            bool autorisation = true;

            foreach (var emp in model.Employes)
            {
                if (emp.ComparerEmploye(nom))
                {
                    MessageBox.Show("L'employer existant!", "Attention");
                    autorisation = false;
                    break;
                }

            }
            if (autorisation)
            {
                employe = new Employe(nom, listeDispos);
                model.AjoutEmployeDB(employe);
                model.Employes.Add(employe);
                MessageBox.Show("Ajout fait avec succes!", "Attention");
            }






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
            string nomEmploye = txbNom.Text;
            bool confirmation = model.SupprimerEmployeLocal(nomEmploye);


            if (confirmation)
            {
                MessageBox.Show("L'employé a été supprimé avec succès.");
            }
            else
            {
                MessageBox.Show("Impossible de supprimer l'employé.");
            }


        }

    }

}
 
