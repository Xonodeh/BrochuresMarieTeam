using System.Collections.Generic;

namespace MarieTeam___PDF
{
    public class BateauVoyageur : Bateau
    {
        // Champs privés
        private double vitesseBatVoy;
        private string imageBatVoy;
        private List<Equipement> lesEquipements;
        public string idBat { get; set; }

        // Constructeur
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

        // Nouvelle version des propriétés : get ET set !
        public string nomBat
        {
            get { return base.nomBat; }
            set { base.nomBat = value; }
        }

        public double longueurBat
        {
            get { return base.longueurBat; }
            set { base.longueurBat = value; }
        }

        public double largeurBat
        {
            get { return base.largeurBat; }
            set { base.largeurBat = value; }
        }

        public double VitesseBatVoy
        {
            get { return vitesseBatVoy; }
            set { vitesseBatVoy = value; }
        }

        public string ImageBatVoy
        {
            get { return imageBatVoy; }
            set { imageBatVoy = value; }
        }

        public List<Equipement> LesEquipements
        {
            get { return lesEquipements; }
            set { lesEquipements = value; }
        }

        // Pour compatibilité
        public string GetImageBatVoy()
        {
            return imageBatVoy;
        }
        public void SetImageBatVoy(string value)
        {
            imageBatVoy = value;
        }
    }
}
