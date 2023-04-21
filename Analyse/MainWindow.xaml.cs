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
using System.Net;

namespace Analyse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static SqlConnection connexion = new SqlConnection(@"Data Source=Brazo-PC\SQLEXPRESS02;Initial Catalog=GestionDispoEmploye;Integrated Security=True");
        private static List<Employe> employes;

        public static List<Employe> Employes
        {
            get { return GetEmployesDB(); }
            set { employes = value; }
        }
        /// <summary>
        /// constructeur du model mainwindow. 
        /// va chercher la liste demploye dans la base de donnees
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Employes = GetEmployesDB();
        }


        /// <summary>
        /// retourne l'id d'un employe de la bas de donnees
        /// </summary>
        /// <param name="nom"></param>
        /// <returns>
        /// ID
        /// </returns>
        public static int getIdEmployeDB(string nom)
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

        /// <summary>
        /// retourne la liste d'employe de la DB
        /// </summary>
        /// <returns>
        /// liste d'employe
        /// </returns>
        public static List<Employe> GetEmployesDB()
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

                employes.Add(employe);

            }
            return employes;

        }

        /// <summary>
        /// ajoute un employe dans la DB
        /// </summary>
        /// <param name="employe"></param>
        public static int AjoutEmployeDB(Employe employe)
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

            return id_employe;
        }
        /// <summary>
        /// permet l'Autorisation d'entrer un utilisateur 
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public static bool AutorisationInsertion(string nom)
        {
            bool autorisation = true;

            foreach (var emp in Employes)
            {
                if (emp.ComparerEmploye(nom))
                {                    
                    autorisation = false;
                    break;
                }
            }

            return autorisation;
        }

        /// <summary>
        /// supprime un employe de la DB
        /// </summary>
        /// <param name="nom"></param>
        /// <returns>
        /// confirmation
        /// </returns>
        public static bool SupprimerEmployeDB(string nom)
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

            Employes = GetEmployesDB();
            return confirmation;
        }
        /// <summary>
        /// Nous permet de recuperer le nom pour faire la suppression
        /// </summary>
        /// <param name="nomEmploye"></param>
        /// <returns></returns>
        public static bool SupprimerEmployeLocal(string nomEmploye)
        {
            bool confirmation = false;
            foreach (var emp in Employes)
            {

                if (emp.ComparerEmploye(nomEmploye))
                {

                    confirmation = SupprimerEmployeDB(nomEmploye);


                    Employes.Remove(emp);
                }
            }

            return confirmation;
        }

        /// <summary>
        /// recherche un employe dans la liste d'emplye
        /// </summary>
        /// <param name="listeNoms"></param>
        /// <param name="jour"></param>
        /// <param name="duree"></param>
        /// <returns>
        /// retourne un tableau avec le ou les employes et ses dispos
        /// </returns>
        public static DataTable RechercheEmploye(List<string> listeNoms, string jour, TimeSpan duree)
        {
            List<string> resultatsNoms = new List<string>();

            List<Disponibilite> dispos = new List<Disponibilite>();


            foreach (var nom in listeNoms)
            {
                foreach (var emp in Employes)
                {
                    if (emp.ComparerEmploye(nom)) emp.ComparerDispos(jour, duree, dispos, resultatsNoms);
                }
            }

            int length = dispos.Count();

            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (resultatsNoms[i] != resultatsNoms[j] && dispos[i].VerifOverlap(dispos[j]))
                    {
                        dispos.Add(dispos[i].GetOverlap(dispos[j]));
                        string nom = $"{resultatsNoms[i]} et {resultatsNoms[j]}";
                        resultatsNoms.Add(nom);
                    }
                }
            }

            DataTable resultat = new DataTable();

            resultat.Columns.Add("Nom", typeof(string));
            resultat.Columns.Add("Jour", typeof(string));
            resultat.Columns.Add("HeureDebut", typeof(string));
            resultat.Columns.Add("HeureFin", typeof(string));

            // Add data to DataTable
            for (int i = 0; i < dispos.Count(); i++)
            {
                var newRow = resultat.NewRow();
                newRow[0] = resultatsNoms[i];
                newRow[1] = dispos[i].Jour;
                newRow[2] = dispos[i].HeureDebut.ToString();
                newRow[3] = dispos[i].HeureFin.ToString();

                resultat.Rows.Add(newRow);
            }

            return resultat;
        }




        /// <summary>
        /// affiche la fenetre gereremplye
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GererEmploye_Click(object sender, RoutedEventArgs e)
        {
            GererEmploye gererEmploye = new GererEmploye(this);
            this.Hide();
            gererEmploye.Show();

        }

        /// <summary>
        /// affiche la fenetre recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rechercheEmploye_Click(object sender, RoutedEventArgs e)
        {
            Recherche recherche = new Recherche(this);
            this.Hide();
            recherche.Show();
        }

        public static bool AreTablesTheSame(DataTable tbl1, DataTable tbl2)
        {
            if (tbl1.Rows.Count != tbl2.Rows.Count || tbl1.Columns.Count != tbl2.Columns.Count)
                return false;


            for (int i = 0; i < tbl1.Rows.Count; i++)
            {
                for (int c = 0; c < tbl1.Columns.Count; c++)
                {
                    if (!Equals(tbl1.Rows[i][c], tbl2.Rows[i][c]))
                    {
                        MessageBox.Show($"{tbl1.Rows[i][c]} + {tbl2.Rows[i][c]}");
                        return false;
                    }
                }
            }
            return true;
        }


    }
}
