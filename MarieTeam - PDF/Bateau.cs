namespace MarieTeam___PDF
{
    // Classe représentant un bateau
    // Contient un identifiant, un nom, une longueur et une largeur
    public class Bateau
    {
        // Identifiant du bateau (ex: "BAT001")
        protected string _idBat;

        // Nom du bateau (ex: "Le Corsaire")
        protected string _nomBat;

        // Longueur du bateau en mètres
        protected double _longueurBat;

        // Largeur du bateau en mètres
        protected double _largeurBat;

        /*
         * Constructeur du bateau
         * @param unId : identifiant du bateau
         * @param unNom : nom du bateau
         * @param uneLongueur : longueur du bateau en mètres
         * @param uneLargeur : largeur du bateau en mètres
         */
        public Bateau(string unId, string unNom, double uneLongueur, double uneLargeur)
        {
            _idBat = unId;
            _nomBat = unNom;
            _longueurBat = uneLongueur;
            _largeurBat = uneLargeur;
        }

        // Accesseur et mutateur pour l'identifiant du bateau
        public string idBat
        {
            get { return _idBat; }
            set { _idBat = value; }
        }

        // Accesseur et mutateur pour le nom du bateau
        public string nomBat
        {
            get { return _nomBat; }
            set { _nomBat = value; }
        }

        // Accesseur et mutateur pour la longueur du bateau
        public double longueurBat
        {
            get { return _longueurBat; }
            set { _longueurBat = value; }
        }

        // Accesseur et mutateur pour la largeur du bateau
        public double largeurBat
        {
            get { return _largeurBat; }
            set { _largeurBat = value; }
        }

        /*
         * Retourne une description textuelle du bateau
         * @return chaîne contenant le nom, la longueur et la largeur
         */
        public override string ToString()
        {
            return $"Nom du bateau : {nomBat}\nLongueur : {longueurBat} mètres\nLargeur : {largeurBat} mètres";
        }
    }
}
