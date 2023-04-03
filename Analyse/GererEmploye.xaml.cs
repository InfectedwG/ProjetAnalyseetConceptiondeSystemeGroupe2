
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
            //string nom = txbNom.ToString();


            int HeureDebutLundi = int.Parse(HDLundi.ToString());
            int MinuteDebutLundi = int.Parse(MDLundi.ToString());
            int HeureFinLundi = int.Parse(HFLundi.ToString());
            int MinuteFinLundi = int.Parse(MFLundi.ToString());

            int HeureDebutMardi = int.Parse(HDMardi.ToString());
            int MinuteDebutMardi = int.Parse(MDMardi.ToString());
            int HeureFinMardi = int.Parse(HFMardi.ToString());
            int MinuteFinMardi = int.Parse(MFMardi.ToString());

            int HeureDebutMercredi = int.Parse(HDMercredi.ToString());
            int MinuteDebutMercredi = int.Parse(MDMercredi.ToString());
            int HeureFinMercredi = int.Parse(HFMercredi.ToString());
            int MinuteFinMercredi = int.Parse(MFMercredi.ToString());

            int HeureDebutJeudi = int.Parse(HDJeudi.ToString());
            int MinuteDebutJeudi = int.Parse(MDJeudi.ToString());
            int HeureFinJeudi = int.Parse(HFJeudi.ToString());
            int MinuteFinJeudi = int.Parse(MFJeudi.ToString());

            int HeureDebutVendredi = int.Parse(HDVendredi.ToString());
            int MinuteDebutVendredi = int.Parse(MDVendredi.ToString());
            int HeureFinVendredi = int.Parse(HFVendredi.ToString());
            int MinuteFinVendredi = int.Parse(MFVendredi.ToString());

            //------------verifier si lemployer existe


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
            /*
            string nom = idnom.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Créer une commande SQL pour supprimer les données de la table appropriée
                string query = "DELETE FROM VotreTable WHERE Nom=@Nom";
                SqlCommand command = new SqlCommand(query, connection);

                // Ajouter les paramètres à la commande SQL
                command.Parameters.AddWithValue("@Nom", nom);

                // Exécuter la commande SQL
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employé supprimé avec succès.");
                }
                else
                {
                    MessageBox.Show("Aucun employé trouvé avec ce nom.");
                }
            }
            */
        }

    }
    }
