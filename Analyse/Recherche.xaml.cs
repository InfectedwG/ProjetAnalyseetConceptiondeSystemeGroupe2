using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public List<string> EmployesRecherche = new List<string>();
        public DataTable resultatRecherche;

        /// <summary>
        /// Initialise une nouvelle instance de la classe Recherche avec le modèle MainWindow spécifié.
        /// </summary>
        /// <param name="model">Le modèle MainWindow à utiliser</param>
        public Recherche(MainWindow model)
        {
            InitializeComponent();
            Model = model;
            ChargerCbxEmployes();
            DataContext = resultatRecherche;
        }

        public void ChargerCbxEmployes()
        {
            foreach (var emp in Model.Employes)
            {
                cbxEmploye.Items.Add(emp.Nom);
            }
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
            Model.Show();
            

        }


        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {

            if (cbxEmploye.SelectedIndex == 0)
            {
                MessageBox.Show("Vous devez selectionnez un employe!");
            }
            else
            {
                EmployesRecherche.Add(cbxEmploye.SelectedItem.ToString());
            }

            cbxEmploye.SelectedIndex = 0;
        }

        private void BtnRechercher_Click(object sender, RoutedEventArgs e)
        {
            

            if(EmployesRecherche.Count == 0 && cbxEmploye.SelectedIndex == 0)
            {
                MessageBox.Show("Vous devez selectionnez un employe!");
            }
            else if (cbxJour.SelectedIndex == 0)
            {
                MessageBox.Show("Vous devez selectionnez une journee!");
            }
            else if (cbxDuree.SelectedIndex == 0)
            {
                MessageBox.Show("Vous devez selectionnez une duree!");
            }
            else
            {
                if(EmployesRecherche.Count == 0 && cbxEmploye.SelectedIndex > 0)
                {
                    EmployesRecherche.Add(cbxEmploye.SelectedItem.ToString());
                }

                string jour = cbxJour.SelectedItem.ToString();
                int dureeTemp = int.Parse(cbxDuree.SelectedItem.ToString().Substring(0, 2));
                TimeSpan duree = new TimeSpan(0, dureeTemp, 0);

                resultatRecherche = Model.RechercheEmploye(EmployesRecherche, jour, duree);

                


                dgResultatRecherche.ItemsSource = resultatRecherche.DefaultView;
            }
        }

        
    }
}
