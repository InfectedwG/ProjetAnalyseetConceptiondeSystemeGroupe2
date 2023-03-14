
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
        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            /*
            string nom = idnom.Text;
            string HDLundi = this.HDLundi.Text;
            string HFLundi = this.HFLundi.Text;
            string HDMardi = this.HDMardi.Text;
            string HFMardi = this.HFMardi.Text;
            string HDMercredi =  this.HDMercredi.Text;
            string HFMercredi = this.HFMercredi.Text;
            string HDJeudi = this.HDJeudi.Text;
            string HFJeudi = this.HFJeudi.Text;
            string HDVendredi = this.HDVendredi.Text;
            string HFVendredi = this.HFVendredi.Text;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Créer une commande SQL pour insérer les données dans la table appropriée
                string query = "INSERT INTO VotreTable (Nom, HDLundi, HFLundi, HDMardi, HFMardi, HDMercredi, HFMercredi, HDJeudi, HFJeudi, HDVendredi, HFVendredi) VALUES (@Nom, @HDLundi, @HFLundi, @HDMardi, @HFMardi, @HDMercredi, @HFMercredi, @HDJeudi, @HFJeudi, @HDVendredi, @HFVendredi)";
                SqlCommand command = new SqlCommand(query, connection);

                // Ajouter les paramètres à la commande SQL
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@HDLundi", HDLundi);
                command.Parameters.AddWithValue("@HFLundi", HFLundi);
                command.Parameters.AddWithValue("@HDMardi", HDMardi);
                command.Parameters.AddWithValue("@HFMardi", HFMardi);
                command.Parameters.AddWithValue("@HDMercredi", HDMercredi);
                command.Parameters.AddWithValue("@HFMercredi", HFMercredi);
                command.Parameters.AddWithValue("@HDJeudi", HDJeudi);
                command.Parameters.AddWithValue("@HFJeudi", HFJeudi);
                command.Parameters.AddWithValue("@HDVendredi", HDVendredi);
                command.Parameters.AddWithValue("@HFVendredi", HFVendredi);

                // Exécuter la commande SQL

                command.ExecuteNonQuery();
            }
            */
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
