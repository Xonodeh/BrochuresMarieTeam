using System.Collections.Generic;

namespace MarieTeam___PDF
{
    public class BateauVoyageur : Bateau
    {
        private double vitesseBatVoy;
        private string imageBatVoy;
        private List<Equipement> lesEquipements;

        public BateauVoyageur(string unId, string unNom, double uneLongueur, double uneLargeur,
                              double uneVitesse, string uneImage, List<Equipement> uneCollEquip)
            : base(unId, unNom, uneLongueur, uneLargeur)
        {
            vitesseBatVoy = uneVitesse;
            imageBatVoy = uneImage;
            lesEquipements = uneCollEquip;
        }

        public override string ToString()
        {
            string equipements = "Liste des équipements du bateau :\n";
            foreach (Equipement eq in lesEquipements)
            {
                equipements += "- " + eq.ToString() + "\n";
            }

            return base.ToString() + $"\nVitesse : {vitesseBatVoy} noeuds\n{equipements}";
        }

        public string GetImageBatVoy()
        {
            return imageBatVoy;
        }

        // PROPRIÉTÉS AJOUTÉES CI-DESSOUS (OBLIGATOIRE)
        public string nomBat
        {
            get { return base.nomBat; }
        }

        public double longueurBat
        {
            get { return base.longueurBat; }
        }

        public double largeurBat
        {
            get { return base.largeurBat; }
        }

        public double VitesseBatVoy
        {
            get { return vitesseBatVoy; }
        }

        public List<Equipement> LesEquipements
        {
            get { return lesEquipements; }
        }
    }
}
