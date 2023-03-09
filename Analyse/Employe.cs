using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Analyse
{
    public class Employe
    {
        
        private string nom;
        private List<Disponibilite> disponibilites = new List<Disponibilite>();

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public List<Disponibilite> Disponibilites
        {
            get { return disponibilites; }
        }

        public Employe(string nom)
        {
            Nom = nom;
        }

        public Employe(string nom, List<Disponibilite> dispos)
        {
            Nom = nom;
            foreach (var x in dispos)
            {
                Disponibilites.Add(x);
            }
        }

        public void AjouterDispo(Disponibilite dispo)
        {
            disponibilites.Add(dispo);
        }
        public Disponibilite RetournerDispos(Disponibilite dispo)
        {
            return dispo;
        }

        public List<Disponibilite> RechercherDispo(string jour, TimeSpan duree)
        {
            List<Disponibilite> dispos = new List<Disponibilite>();

            foreach(Disponibilite dispo in Disponibilites)
            {
                if (dispo.ComparerDispo(jour, duree))
                {
                    dispos.Add(dispo);
                }

            }
            return dispos;
        }

        public string ToString()
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

        public bool ComparerEmploye(string nom)
        {
            if(nom == this.Nom) return true;
            else return false;
        }
    }
}
