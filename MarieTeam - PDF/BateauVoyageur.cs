using System.Collections.Generic;

namespace MarieTeam___PDF
{
    /*
     * Classe BateauVoyageur
     * Hérite de la classe Bateau.
     * Représente un bateau destiné au transport de voyageurs, avec une vitesse, une image et une liste d'équipements.
     */
    public class BateauVoyageur : Bateau
    {
        // Vitesse du bateau en nœuds
        private double vitesseBatVoy;

        // Chemin vers l'image du bateau (fichier ou URL)
        private string imageBatVoy;

        // Liste des équipements présents sur le bateau
        private List<Equipement> lesEquipements;

        /*
         * Constructeur du bateau voyageur
         * @param unId : identifiant du bateau
         * @param unNom : nom du bateau
         * @param uneLongueur : longueur du bateau
         * @param uneLargeur : largeur du bateau
         * @param uneVitesse : vitesse du bateau en nœuds
         * @param uneImage : chemin ou nom de l'image représentant le bateau
         * @param uneCollEquip : liste des équipements du bateau
         */
        public BateauVoyageur(string unId, string unNom, double uneLongueur, double uneLargeur,
                              double uneVitesse, string uneImage, List<Equipement> uneCollEquip)
            : base(unId, unNom, uneLongueur, uneLargeur)
        {
            vitesseBatVoy = uneVitesse;
            imageBatVoy = uneImage;
            lesEquipements = uneCollEquip;
        }

        /*
         * Redéfinition de la méthode ToString()
         * @return une description complète du bateau voyageur, incluant ses équipements
         */
        public override string ToString()
        {
            string equipements = "Liste des équipements du bateau :\n";
            foreach (Equipement eq in lesEquipements)
            {
                equipements += "- " + eq.ToString() + "\n";
            }
            return base.ToString() + $"\nVitesse : {vitesseBatVoy} noeuds\n{equipements}";
        }

        // Accesseur et mutateur du nom (hérité du bateau de base)
        public string nomBat
        {
            get { return base.nomBat; }
            set { base.nomBat = value; }
        }

        // Accesseur et mutateur de la longueur (hérité du bateau de base)
        public double longueurBat
        {
            get { return base.longueurBat; }
            set { base.longueurBat = value; }
        }

        // Accesseur et mutateur de la largeur (hérité du bateau de base)
        public double largeurBat
        {
            get { return base.largeurBat; }
            set { base.largeurBat = value; }
        }

        // Accesseur et mutateur pour la vitesse du bateau
        public double VitesseBatVoy
        {
            get { return vitesseBatVoy; }
            set { vitesseBatVoy = value; }
        }

        // Accesseur et mutateur pour l'image du bateau
        public string ImageBatVoy
        {
            get { return imageBatVoy; }
            set { imageBatVoy = value; }
        }

        // Accesseur et mutateur pour la liste des équipements
        public List<Equipement> LesEquipements
        {
            get { return lesEquipements; }
            set { lesEquipements = value; }
        }

        /*
         * Accesseur compatible avec certaines interfaces ou normes
         * @return le chemin de l'image du bateau
         */
        public string GetImageBatVoy()
        {
            return imageBatVoy;
        }

        /*
         * Mutateur compatible avec certaines interfaces ou normes
         * @param value : nouveau chemin de l'image du bateau
         */
        public void SetImageBatVoy(string value)
        {
            imageBatVoy = value;
        }
    }
}
