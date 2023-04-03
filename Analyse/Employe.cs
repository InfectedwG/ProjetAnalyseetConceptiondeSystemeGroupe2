using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Analyse
{
    /// <summary>
    /// Classe représentant un employé avec un nom et des disponibilités.
    /// </summary>
    public class Employe
    {
        
        private string? nom;
        private List<Disponibilite> disponibilites = new List<Disponibilite>();

        /// <summary>
        /// Propriété pour accéder et définir le nom de l'employé.
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// Propriété pour accéder à la liste des disponibilités de l'employé.
        /// </summary>
        public List<Disponibilite> Disponibilites
        {
            get { return disponibilites; }
        }

        /// <summary>
        /// Constructeur de la classe Employe avec un nom spécifié.
        /// </summary>
        /// <param name="nom">Le nom de l'employé.</param>
        public Employe(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// Constructeur de la classe Employe avec un nom et une liste de disponibilités spécifiés.
        /// </summary>
        /// <param name="nom">Le nom de l'employé.</param>
        /// <param name="dispos">La liste des disponibilités de l'employé.</param>
        public Employe(string nom, List<Disponibilite> dispos)
        {
            Nom = nom;
            foreach (var x in dispos)
            {
                Disponibilites.Add(x);
            }
        }

        /// <summary>
        /// Ajoute une disponibilité à la liste de disponibilités de l'employé.
        /// </summary>
        /// <param name="dispo">La disponibilité à ajouter.</param>
        public void AjouterDispo(Disponibilite dispo)
        {
            disponibilites.Add(dispo);
        }

        /// <summary>
        /// Retourne une disponibilité spécifique de la liste de disponibilités de l'employé.
        /// </summary>
        /// <param name="dispo">La disponibilité à retourner.</param>
        /// <returns>La disponibilité spécifiée.</returns>
        public Disponibilite RetournerDispos(Disponibilite dispo)
        {
            return dispo;
        }

        /// <summary>
        /// Cette méthode compare les disponibilités de l'employé pour un jour donné avec une durée spécifique et retourne une valeur booléenne indiquant si l'employé est disponible pendant cette période.
        /// </summary>
        /// <param name="jour">Une chaîne de caractères représentant le jour de la semaine pour lequel on souhaite vérifier les disponibilités de l'employé.</param>
        /// <param name="duree"> Un objet de type TimeSpan représentant la durée pendant laquelle on souhaite vérifier les disponibilités de l'employé.</param>
        /// <param name="listeHeuresDebut"> Une liste de chaînes de caractères représentant les heures de début des disponibilités de l'employé pour le jour spécifié.</param>
        /// <param name="listeHeuresFin">Une liste de chaînes de caractères représentant les heures de fin des disponibilités de l'employé pour le jour spécifié.</param>
        /// <param name="listeJours">Une liste de chaînes de caractères représentant les jours de la semaine pour lesquels l'employé est disponible. </param>
        /// <returns>Un booléen indiquant si l'employé est disponible pendant la période spécifiée. </returns>
        public bool ComparerDispos(string jour, TimeSpan duree, List<string> listeHeuresDebut, List<string> listeHeuresFin, List<string> listeJours)
        {
            bool verification = false;

            foreach(Disponibilite dispo in this.Disponibilites)
            {
                if (dispo.ComparerDispo(jour, duree))
                {
                    verification = true;
                    listeJours.Add(dispo.Jour);
                    listeHeuresDebut.Add(dispo.HeureDebut.ToString());
                    listeHeuresFin.Add(dispo.HeureFin.ToString());
                }

            }
            return verification;
        }

        /// <summary>
        /// Cette méthode retourne une chaîne de caractères représentant les informations sur l'employé et ses disponibilités.
        /// </summary>
        /// <returns>Une chaîne de caractères représentant les informations sur l'employé et ses disponibilités.</returns>
        override public string ToString()
        {
            List<string> disposList = new List<string>();

            foreach (var i in Disponibilites)
            {
                disposList.Add(i.ToString());
            }

            string disposString = string.Join($"\n", disposList);
            
            return $"{this.Nom}\n" +
                $"{disposString}";
        }

        /// <summary>
        /// Cette méthode compare le nom de l'employé avec un nom spécifié et retourne une valeur booléenne indiquant si les noms correspondent.
        /// </summary>
        /// <param name="nom"> Une chaîne de caractères représentant le nom à comparer avec le nom de l'employé </param>
        /// <returns>Un booléen indiquant si les noms correspondent. </returns>
        public bool ComparerEmploye(string nom)
        {
            if(nom == this.Nom) return true;
            else return false;
        }

        
    }
}

