using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarieTeam___PDF;
using System.Collections.Generic;

namespace MarieTeamTests
{
    [TestClass]
    public class PasserelleTests
    {
        [TestMethod]
        public void ChargerLesBateauxVoyageurs_RetourneDonnees()
        {
            var result = Passerelle.ChargerLesBateauxVoyageurs();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void ChargerLesEquipementsDuBateau_RetourneEquipements()
        {
            var idBateau = "BV001";
            var result = Passerelle.ChargerLesEquipementsDuBateau(idBateau);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ModifierBateau_AvecSucces()
        {
            var bateau = new BateauVoyageur("BV001", "Updated Name", 320, 33, 35, "updated.jpg", new List<Equipement>());
            bool modifie = Passerelle.ModifierBateau(bateau);

            Assert.IsTrue(modifie);
        }
    }
}
