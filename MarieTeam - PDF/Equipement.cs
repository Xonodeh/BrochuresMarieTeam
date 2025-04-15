﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarieTeam___PDF
{
    public class Equipement
    {
        private string idEquip;
        private string libEquip;

        public Equipement(string unId, string unLib)
        {
            idEquip = unId;
            libEquip = unLib;
        }

        public override string ToString()
        {
            return libEquip;
        }

        public string IdEquip => idEquip;
        public string LibEquip => libEquip;
    }

   
}
