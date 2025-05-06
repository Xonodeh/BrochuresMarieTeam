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
    public class BateauVoyageurTests
    {
        private BateauVoyageur bateauVoyageur;

        [TestInitialize]
        public void Setup()
        {
            bateauVoyageur = new BateauVoyageur("BV001", "Queen Mary", 345.0, 41.0, 30.0, "queen.jpg", new List<Equipement>
            {
                new Equipement("E001", "Piscine"),
                new Equipement("E002", "Spa")
            });
        }

        [TestMethod]
        public void Constructeur_InitialisationCorrecte()
        {
            Assert.AreEqual("BV001", bateauVoyageur.idBat);
            Assert.AreEqual("Queen Mary", bateauVoyageur.nomBat);
            Assert.AreEqual(30.0, bateauVoyageur.VitesseBatVoy);
            Assert.AreEqual("queen.jpg", bateauVoyageur.ImageBatVoy);
            Assert.AreEqual(2, bateauVoyageur.LesEquipements.Count);
        }

        [TestMethod]
        public void Proprietes_SetEtGetCorrectes()
        {
            bateauVoyageur.nomBat = "Queen Elizabeth";
            bateauVoyageur.VitesseBatVoy = 28.5;

            Assert.AreEqual("Queen Elizabeth", bateauVoyageur.nomBat);
            Assert.AreEqual(28.5, bateauVoyageur.VitesseBatVoy);
        }

        [TestMethod]
        public void ToString_FormatCorrect()
        {
            string resultat = bateauVoyageur.ToString();
            Assert.IsTrue(resultat.Contains("Queen Mary"));
            Assert.IsTrue(resultat.Contains("Piscine"));
            Assert.IsTrue(resultat.Contains("Spa"));
        }
    }
}
