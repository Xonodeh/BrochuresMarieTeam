using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarieTeam___PDF
{
    /*
     * Classe Equipement
     * Représente un équipement pouvant être présent sur un bateau.
     * Contient un identifiant et un libellé (nom) de l'équipement.
     */
    public class Equipement
    {
        // Identifiant de l’équipement
        public string idEquip;

        // Libellé (nom) de l’équipement
        public string libEquip;

        /*
         * Constructeur de la classe Equipement
         *
         * @param unId  : identifiant de l’équipement
         * @param unLib : libellé (nom) de l’équipement
         */
        public Equipement(string unId, string unLib)
        {
            idEquip = unId;
            libEquip = unLib;
        }

        /*
         * Propriété en lecture seule pour récupérer l'identifiant de l'équipement
         */
        public string IdEquip
        {
            get { return idEquip; }
        }

        /*
         * Propriété en lecture seule pour récupérer le libellé de l'équipement
         */
        public string LibEquip
        {
            get { return libEquip; }
        }

        /*
         * Redéfinition de la méthode ToString
         * Permet d'afficher directement le libellé de l’équipement
         *
         * @return le libellé de l’équipement
         */
        public override string ToString()
        {
            return libEquip;
        }
    }
}
