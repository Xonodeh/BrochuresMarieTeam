using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarieTeam___PDF
{
    public class Equipement
    {
        public string idEquip;  // Déclaré public
        public string libEquip; // Déclaré public

        public Equipement(string unId, string unLib)
        {
            idEquip = unId;
            libEquip = unLib;
        }

        public string IdEquip
        {
            get { return idEquip; }
        }

        public string LibEquip
        {
            get { return libEquip; }
        }

        public override string ToString()
        {
            return libEquip;
        }
    }




}
