namespace MarieTeam___PDF
{
    public class Bateau
    {
        protected string _idBat;
        protected string _nomBat;
        protected double _longueurBat;
        protected double _largeurBat;

        public Bateau(string unId, string unNom, double uneLongueur, double uneLargeur)
        {
            _idBat = unId;
            _nomBat = unNom;
            _longueurBat = uneLongueur;
            _largeurBat = uneLargeur;
        }

        // ✅ Propriétés publiques (à utiliser depuis les classes dérivées)
        public string idBat
        {
            get { return _idBat; }
            set { _idBat = value; }
        }

        public string nomBat
        {
            get { return _nomBat; }
            set { _nomBat = value; }
        }

        public double longueurBat
        {
            get { return _longueurBat; }
            set { _longueurBat = value; }
        }

        public double largeurBat
        {
            get { return _largeurBat; }
            set { _largeurBat = value; }
        }

        public override string ToString()
        {
            return $"Nom du bateau : {nomBat}\nLongueur : {longueurBat} mètres\nLargeur : {largeurBat} mètres";
        }
    }
}
