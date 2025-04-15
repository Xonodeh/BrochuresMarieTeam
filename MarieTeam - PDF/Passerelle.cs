using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarieTeam___PDF
{
    namespace MarieTeam___PDF
    {
        public static class Passerelle
        {
            public static List<Equipement> ChargerLesEquipements(string idBateau)
            {
                List<Equipement> listeEquipements = new List<Equipement>();

                string requete = $"SELECT e.idEquip, e.libEquip FROM equipement e " +
                                 $"JOIN disposer d ON d.idEquip = e.idEquip " +
                                 $"WHERE d.idBat = '{idBateau}'";

                JeuEnregistrement jeu = new JeuEnregistrement(requete);

                while (!jeu.Fin())
                {
                    string idEquip = jeu.GetValeur("idEquip").ToString();
                    string libEquip = jeu.GetValeur("libEquip").ToString();

                    Equipement e = new Equipement(idEquip, libEquip);
                    listeEquipements.Add(e);

                    jeu.Suivant();
                }

                jeu.Fermer();
                return listeEquipements;
            }

            public static List<BateauVoyageur> ChargerLesBateauxVoyageurs()
            {
                List<BateauVoyageur> liste = new List<BateauVoyageur>();

                string requete = "SELECT * FROM bateauvoyageur";

                JeuEnregistrement jeu = new JeuEnregistrement(requete);

                while (!jeu.Fin())
                {
                    string id = jeu.GetValeur("idBat").ToString();
                    string nom = jeu.GetValeur("nomBat").ToString();
                    double longueur = Convert.ToDouble(jeu.GetValeur("longueurBat"));
                    double largeur = Convert.ToDouble(jeu.GetValeur("largeurBat"));
                    double vitesse = Convert.ToDouble(jeu.GetValeur("vitesseBatVoy"));
                    string image = jeu.GetValeur("imageBatVoy").ToString();

                    List<Equipement> equipements = ChargerLesEquipements(id);

                    BateauVoyageur b = new BateauVoyageur(id, nom, longueur, largeur, vitesse, image, equipements);
                    liste.Add(b);

                    jeu.Suivant();
                }

                jeu.Fermer();
                return liste;
            }
        }
    }
}
