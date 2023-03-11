using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Analyse
{
    internal class classeTest
    {

        static void Main(string[] args)
        {
            SqlConnection connexion = new SqlConnection(@"Data Source=Brazo-PC\SQLEXPRESS02;Initial Catalog=GestionDispoEmploye;Integrated Security=True");

            string requete = "select * from Employe";
            List<Employe> employes = new List<Employe>();

            SqlCommand cmd = new SqlCommand(requete, connexion);

            connexion.Open(); //Ouvrir la connexion

            SqlDataReader dr = cmd.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête
            while (dr.Read())
            {
                var donnee = dr.GetString(0);
                Console.WriteLine(donnee);

            }
        }
    }
}
