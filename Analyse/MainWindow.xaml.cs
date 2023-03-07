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
using System.Data.SqlClient;
using System.Data;

namespace Analyse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection connexion = new SqlConnection(@"Data Source=Brazo-PC\SQLEXPRESS02;Initial Catalog=GestionDispoEmploye;Integrated Security=True");
        public MainWindow()
        {
            InitializeComponent();
        }

        public void GetEmployesDB()
        {
            string requete = "select * from Employe";
            List<Employe> employes = new List<Employe>();

            SqlCommand cmd = new SqlCommand(requete, connexion);

            connexion.Open(); //Ouvrir la connexion

            SqlDataReader dr = cmd.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête
            while (dr.Read())
            {
                var donnee = dr.GetString(0); 

                
            }

            


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
