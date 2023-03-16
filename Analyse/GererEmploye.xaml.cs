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
        
        public MainWindow Model;

        public GererEmploye(MainWindow model)
        {
            InitializeComponent();
            Model = model;
        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            this.Close();            
            Model.Show();
        }
        /*
        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
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

        }
        */
        /*
        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
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
        }
        */
    }
}
