using MarieTeam___PDF;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MarieTeamTests
{
    [TestClass]
    public class BateauTests
    {
        private Bateau bateau;

        [TestInitialize]
        public void Setup()
        {
            bateau = new Bateau("B001", "Titanic", 269.1, 28.2);
        }

        [TestMethod]
        public void Constructeur_CreationCorrecte()
        {
            Assert.AreEqual("B001", bateau.idBat);
            Assert.AreEqual("Titanic", bateau.nomBat);
            Assert.AreEqual(269.1, bateau.longueurBat);
            Assert.AreEqual(28.2, bateau.largeurBat);
        }

        [TestMethod]
        public void ToString_FormatCorrect()
        {
            string expected = "Nom du bateau : Titanic\nLongueur : 269.1 mètres\nLargeur : 28.2 mètres";
            Assert.AreEqual(expected, bateau.ToString());
        }
    }
}
