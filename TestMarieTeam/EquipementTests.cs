using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarieTeam___PDF;


namespace MarieTeamTests
{
    [TestClass]
    public class EquipementTests
    {
        [TestMethod]
        public void Constructeur_CreationCorrecte()
        {
            var equip = new Equipement("E001", "Radar");
            Assert.AreEqual("E001", equip.IdEquip);
            Assert.AreEqual("Radar", equip.LibEquip);
        }

        [TestMethod]
        public void ToString_RetourneLibelle()
        {
            var equip = new Equipement("E002", "GPS");
            Assert.AreEqual("GPS", equip.ToString());
        }
    }
}
