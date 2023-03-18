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
    /// classe de lobjet employe
    /// </summary>
    public class Employe
    {
        
        private string? nom;
        private List<Disponibilite> disponibilites = new List<Disponibilite>();

        /// <summary>
        /// La methode qui gere l'accesseur et le getteur de la propriete nom
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// La methode qui gere l'accesseur et le getteur de la de disponibilité dun employé
        /// </summary>
        public List<Disponibilite> Disponibilites
        {
            get { return disponibilites; }
        }

        /// <summary>
        /// Un constructeur de lobjet employé avec son nom
        /// </summary>
        /// <param name="nom"></param>
        public Employe(string nom)
        {
            Nom = nom;
        }

        /// <summary>
        /// Un constructeur de lobjet employé avec son nom et la liste de dispos
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="dispos"></param>
        public Employe(string nom, List<Disponibilite> dispos)
        {
            Nom = nom;
            foreach (var x in dispos)
            {
                Disponibilites.Add(x);
            }
        }

        /// <summary>
        /// methode qui gere l'ajout d'une disponibilite dans la liste
        /// </summary>
        /// <param name="dispo"></param>
        public void AjouterDispo(Disponibilite dispo)
        {
            disponibilites.Add(dispo);
        }
        
        /// <summary>
        /// methode qui gere la recherche dune dispo a laide du jour et la duree.
        /// elle retourne une confirmation et la liste des dispos 
        /// </summary>
        /// <param name="jour"></param>
        /// <param name="duree"></param>
        /// <param name="listeHeuresDebut"></param>
        /// <param name="listeHeuresFin"></param>
        /// <param name="listeJours"></param>
        /// <returns></returns>
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
        /// methode qui retourne un employe en string
        /// </summary>
        /// <returns></returns>
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
        /// methode qui compare 2 employe a laide du nom
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public bool ComparerEmploye(string nom)
        {
            if(nom == this.Nom) return true;
            else return false;
        }
    }
}
