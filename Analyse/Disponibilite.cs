﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    internal class Disponibilite
    {
        private TimeOnly heureDebut;
        private TimeOnly heureFin;
        private string jour;

        public TimeOnly HeureDebut
        {
            get { return heureDebut; }
            set { heureDebut = value; }
        }

        public TimeOnly HeureFin
        {
            get { return heureFin; }
            set { heureFin = value; }
        }

        public string Jour
        {
            get { return jour; }
            set { jour = value; }
        }

        public Disponibilite(TimeOnly heureDebut, TimeOnly heureFin, string jour)
        {
            HeureDebut = heureDebut;
            HeureFin = heureFin;
            Jour = jour;
        }

        public bool ComparerDispo(String jour, TimeSpan check)
        {
            TimeSpan dureeDispo = this.HeureFin - this.HeureDebut;

            if (dureeDispo == check && this.Jour == jour)return true;
            else return false;
        }
    }
}
