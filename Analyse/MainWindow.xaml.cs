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
        private List<Employe> employes;

        public List<Employe> Employes
        {
            get { return employes; }
            set { employes = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            Employes = GetEmployesDB();
        }
        public Employe GetEmployeFromList(string nom, List<Employe> liste)
        {
            Employe temp = new Employe(nom);
            foreach (var e in liste)
            {

            }
            
        }

        public int getIdEmployeDB(string nom)
        {
            int id;
            string requete = "select id from Employe where nom = @nom";
            SqlCommand getId = new SqlCommand(requete, connexion);
            getId.Parameters.AddWithValue("@nom", nom);

            connexion.Open();
            SqlDataReader dr = getId.ExecuteReader();
            dr.Read();
            id = dr.GetInt16(0);
            connexion.Close();
            return id;

        }


        public List<Employe> GetEmployesDB()
        {
            

            string requeteEmploye = "select * from Employe";
            List<Employe> employes = new List<Employe>();

            SqlCommand getEmploye = new SqlCommand(requeteEmploye, connexion);

            connexion.Open(); //Ouvrir la connexion

            SqlDataReader dr = getEmploye.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête

            List<string> listeNom = new List<string>();
            List<int> listeId = new List<int>();

            while (dr.Read())
            {
                var nom = dr.GetString(1);
                listeNom.Add(nom);

                var id = dr.GetInt16(0);
                listeId.Add(id);
            }
            connexion.Close();


            for (int i = 0; i < listeNom.Count && i < listeId.Count; i++)
            {
                var nom = listeNom[i];
                var index = listeId[i];
                List<Disponibilite> dispos = new List<Disponibilite>();
                string requeteDispo = "select heure_debut, heure_fin, jour from Disponibilite where id_employe = @index";
                SqlCommand getDispo = new SqlCommand(requeteDispo, connexion);

                //getDispo.CommandType = CommandType.Text;

                getDispo.Parameters.AddWithValue("@index", index);
                

                connexion.Open();

                SqlDataReader dr1 = getDispo.ExecuteReader();
                
                while (dr1.Read())
                {
                    var donnee_heure_debut = dr1.GetTimeSpan(0);
                    TimeOnly heure_debut = TimeOnly.FromTimeSpan(donnee_heure_debut);

                    var donnee_heure_fin = dr1.GetTimeSpan(1);
                    TimeOnly heure_fin = TimeOnly.FromTimeSpan(donnee_heure_fin);

                    var jour = dr1.GetString(2);

                    Disponibilite dispo = new Disponibilite(heure_debut, heure_fin, jour);

                    dispos.Add(dispo);
                }
                connexion.Close();

                Employe employe = new Employe(nom, dispos);
                //Console.WriteLine(employe.ToString());

                employes.Add(employe);
                
            }
            return employes;

        }

        public void AjoutEmployeDB(Employe employe)
        {
            int id_employe;

            string requeteEmploye = "insert into Employe values (@nom)";
            string requeteIdLast = "select @@IDENTITY";

            SqlCommand addEmploye = new SqlCommand(requeteEmploye, connexion);
            SqlCommand getId = new SqlCommand(requeteIdLast, connexion);

            addEmploye.CommandType = CommandType.Text;
            addEmploye.Parameters.AddWithValue("@nom", employe.Nom);

            connexion.Open();
            addEmploye.ExecuteNonQuery();
            SqlDataReader dr = getId.ExecuteReader();
            dr.Read();
            id_employe = Convert.ToInt32(dr.GetDecimal(0));
            connexion.Close();

            foreach (var dispo in employe.Disponibilites)
            {
                TimeOnly heure_debut = dispo.HeureDebut;
                TimeOnly heure_fin = dispo.HeureFin;

                string requeteDispo = "insert into Disponibilite values (@heure_debut, @heure_fin, @jour, @id_employe)";
                SqlCommand addDispos = new SqlCommand(requeteDispo, connexion);
                addDispos.CommandType = CommandType.Text;

                addDispos.Parameters.AddWithValue("@heure_debut", heure_debut.ToTimeSpan());
                addDispos.Parameters.AddWithValue("@heure_fin", heure_fin.ToTimeSpan());
                addDispos.Parameters.AddWithValue("@jour", dispo.Jour);
                addDispos.Parameters.AddWithValue("@id_employe", id_employe);

                connexion.Open();
                addDispos.ExecuteNonQuery();
                connexion.Close();
            }            
        }

        public bool SupprimerEmployeDB(string nom)
        {
            int id = getIdEmployeDB(nom);
            bool confirmation = true;

            string requeteEmploye = "delete from Employe where id = @id_employe";
            string requeteDispo = "delete from Disponibilite where id_employe = @id_employe";

            SqlCommand deleteEmploye = new SqlCommand(requeteEmploye, connexion);
            SqlCommand deleteDispos = new SqlCommand(requeteDispo, connexion);

            deleteDispos.Parameters.AddWithValue("@id_employe", id);
            deleteEmploye.Parameters.AddWithValue("@id_employe", id);


            deleteEmploye.CommandType = CommandType.Text;
            deleteEmploye.Parameters.AddWithValue("@nom", nom);

            connexion.Open();
            deleteDispos.ExecuteNonQuery();
            int reponse = deleteEmploye.ExecuteNonQuery();
            connexion.Close();
            if (reponse == 0) confirmation = false;
            
            Employes.Remove();
            return confirmation;
        }

        public DataTable RechercheEmployeDB(List<string> listeNoms)
        {

            string requete = "select e.nom, d.jour, d.heure_debut, d.heure_fin from Disponibilite d inner join Employe e on e.id = d.id_employe where e.nom = @nom";
            SqlCommand rechercheEmploye = new SqlCommand(requete, connexion);
            rechercheEmploye.Parameters.AddWithValue("@nom", listeNoms);




        }


        private void TextBox_TextChanged()
        {

        }

        private void GererEmploye_Click(object sender, RoutedEventArgs e)
        {
            GererEmploye gererEmploye = new GererEmploye(this);
            this.Hide();
            gererEmploye.Show();
            
        }

        private void rechercheEmploye_Click(object sender, RoutedEventArgs e)
        {
            Recherche recherche = new Recherche(this);
            this.Hide();
            recherche.Show();
            
        }
    }
}
