using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    internal class Employe
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

        public void AjouterDispo(Disponibilite dispo)
        {
            disponibilites.Add(dispo);
        }
        public Disponibilite RetournerDispos(Disponibilite dispo)
        {
            return dispo;
        }

        public void RechercherDispo(string jour, TimeSpan duree)
        {
            foreach(Disponibilite dispo in Disponibilites)
            {
                if (dispo.ComparerDispo(jour, duree))
                {
                    RetournerDispos(dispo);
                }
            }            
        }
    }
}
