using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarieTeam___PDF
{
    public class BateauVoyageur : Bateau
    {
        private double vitesseBatVoy;
        private string imageBatVoy;
        private List<Equipement> lesEquipements;

        public BateauVoyageur(string unId, string unNom, double uneLongueur, double uneLargeur,
                              double uneVitesse, string uneImage, List<Equipement> uneListeEquip)
            : base(unId, unNom, uneLongueur, uneLargeur)
        {
            vitesseBatVoy = uneVitesse;
            imageBatVoy = uneImage;
            lesEquipements = uneListeEquip;
        }

        public override string ToString()
        {
            string str = base.ToString() +
                         $"\nVitesse : {vitesseBatVoy} noeuds\nListe des équipements du bateau :\n";
            foreach (Equipement e in lesEquipements)
            {
                str += $"- {e}\n";
            }
            return str;
        }

        public string GetImageBatVoy() => imageBatVoy;
        public List<Equipement> GetEquipements() => lesEquipements;
    }
}