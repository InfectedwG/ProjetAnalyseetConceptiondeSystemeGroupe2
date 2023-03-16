using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    /// <summary>
    /// Représente les disponibilités d'une personne pour un jour donné.
    /// </summary>
    public class Disponibilite
    {
        private TimeOnly heureDebut;
        private TimeOnly heureFin;
        private string jour;

        /// <summary>
        /// Obtient ou définit l'heure de début de la disponibilité.
        /// </summary>
        public TimeOnly HeureDebut
        {
            get { return heureDebut; }
            set { heureDebut = value; }
        }

        /// <summary>
        /// Obtient ou définit l'heure de fin de la disponibilité.
        /// </summary>
        public TimeOnly HeureFin
        {
            get { return heureFin; }
            set { heureFin = value; }
        }

        /// <summary>
        /// Obtient ou définit le jour de la disponibilité.
        /// </summary>
        public string Jour
        {
            get { return jour; }
            set { jour = value; }
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe Disponibilite avec les valeurs spécifiées.
        /// </summary>
        /// <param name="heureDebut">L'heure de début de la disponibilité.</param>
        /// <param name="heureFin">L'heure de fin de la disponibilité.</param>
        /// <param name="jour">Le jour de la disponibilité.</param>
        
        public Disponibilite(TimeOnly heureDebut, TimeOnly heureFin, string jour)
        {
            HeureDebut = heureDebut;
            HeureFin = heureFin;
            Jour = jour;
        }

        /// <summary>
        /// Vérifie si la disponibilité correspond au jour et à la durée spécifiés.
        /// </summary>
        /// <param name="jour">Le jour à vérifier.</param>
        /// <param name="dureeCheck">La durée à vérifier.</param>
        /// <returns>True si la disponibilité correspond, False sinon.</returns>
        public bool ComparerDispo(string jour, TimeSpan dureeCheck)
        {
            TimeSpan dureeDispo = this.HeureFin - this.HeureDebut;

            if (dureeDispo >= dureeCheck && this.Jour == jour) return true;
            else return false;
        }

        /// <summary>
        /// Retourne une chaîne de caractères qui représente l'objet Disponibilite.
        /// </summary>
        /// <returns>Une chaîne de caractères représentant l'objet Disponibilite.</returns>
        public string ToString()
        {
            return $"{this.Jour} : {this.HeureDebut} a {this.HeureFin}";
        }
    }
}
