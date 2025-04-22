using System.Collections.Generic;

namespace MarieTeam___PDF
{
    public static class Passerelle
    {
        public static List<BateauVoyageur> ChargerLesBateauxVoyageurs()
        {
            List<BateauVoyageur> bateaux = new List<BateauVoyageur>();
            JeuEnregistrement jeu = new JeuEnregistrement("SELECT * FROM bateau");

            while (jeu.LireSuivant())
            {
                string idBat = jeu.GetValeur("IDBateau").ToString();
                string nomBat = jeu.GetValeur("nomBateau").ToString();
                double longueur = double.Parse(jeu.GetValeur("LongueurBateau").ToString());
                double largeur = double.Parse(jeu.GetValeur("largeurBat").ToString());
                double vitesse = double.Parse(jeu.GetValeur("VitesseBateau").ToString());
                string image = jeu.GetValeur("imageBat").ToString();

                List<Equipement> equipements = new List<Equipement>(); // Si tu ne gères pas encore les équipements
                bateaux.Add(new BateauVoyageur(idBat, nomBat, longueur, largeur, vitesse, image, equipements));
            }

            jeu.Fermer();
            return bateaux;
        }


        public static List<Equipement> ChargerLesEquipements(string idBateau)
        {
            List<Equipement> equipements = new List<Equipement>();
            JeuEnregistrement jeu = new JeuEnregistrement($"SELECT idEquipement, libEquipement FROM Equipement WHERE idBat = '{idBateau}'");

            while (jeu.LireSuivant())
            {
                string idEquip = jeu.GetValeur("idEquip").ToString();
                string libEquip = jeu.GetValeur("libEquip").ToString();
                equipements.Add(new Equipement(idEquip, libEquip));
            }
            jeu.Fermer();
            return equipements;
        }
    }
}
