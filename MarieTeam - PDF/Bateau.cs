using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarieTeam___PDF
{
    public class Bateau
    {
        private string idBat;
        private string nomBat;
        private double longueurBat;
        private double largeurBat;

        public Bateau(string unId, string unNom, double uneLongueur, double uneLargeur)
        {
            idBat = unId;
            nomBat = unNom;
            longueurBat = uneLongueur;
            largeurBat = uneLargeur;
        }

        public override string ToString()
        {
            return $"Nom du bateau : {nomBat}\nLongueur : {longueurBat} mètres\nLargeur : {largeurBat} mètres";
        }

        public string IdBat => idBat;
        public string NomBat => nomBat;
        public double LongueurBat => longueurBat;

        public double LargeurBat => largeurBat;












    }
}
