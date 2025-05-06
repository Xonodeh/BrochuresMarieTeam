using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarieTeam___PDF;
using System.Collections.Generic;
using System.IO;

namespace MarieTeamTests
{
    [TestClass]
    public class BrochurePDFTests
    {
        private readonly string pdfFileName = "BrochureMarieTeam.pdf";

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(pdfFileName))
                File.Delete(pdfFileName);
        }

        [TestMethod]
        public void GenererBrochure_CreeFichierPDF()
        {
            var bateaux = new List<BateauVoyageur>
            {
                new BateauVoyageur("BV001", "Voyager", 300, 30, 40, "image.jpg", new List<Equipement>())
            };

            BrochurePDF.GenererBrochure(bateaux);

            Assert.IsTrue(File.Exists(pdfFileName));
        }

        [TestMethod]
        public void GenererBrochure_ListeVide_CreeFichierPDFVide()
        {
            var bateaux = new List<BateauVoyageur>();
            BrochurePDF.GenererBrochure(bateaux);

            Assert.IsTrue(File.Exists(pdfFileName));
            Assert.IsTrue(new FileInfo(pdfFileName).Length > 0);
        }
    }
}
