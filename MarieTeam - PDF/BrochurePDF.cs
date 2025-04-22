using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Collections.Generic;
using MarieTeam___PDF;
using System.Drawing;
using System.Xml.Linq;

public static class BrochurePDF
{
    public static void GenererBrochure(List<BateauVoyageur> bateaux)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Brochure des Bateaux - MarieTeam";

        foreach (var bateau in bateaux)
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont fontTitre = new XFont("Verdana", 16, PdfSharp.Drawing.XFontStyle.Bold);
            XFont fontTexte = new XFont("Verdana", 12, PdfSharp.Drawing.XFontStyle.Regular);

            gfx.DrawString("Brochure des Bateaux - MarieTeam", fontTitre, XBrushes.DarkBlue, new XRect(0, 20, page.Width, 40), XStringFormats.TopCenter);
            gfx.DrawString(bateau.ToString(), fontTexte, XBrushes.Black, new XRect(40, 70, page.Width - 80, page.Height - 100), XStringFormats.TopLeft);

            if (System.IO.File.Exists(bateau.GetImageBatVoy()))
            {
                XImage image = XImage.FromFile(bateau.GetImageBatVoy());
                gfx.DrawImage(image, 40, 250, 250, 150);
            }
        }

        string filename = "BrochureMarieTeam.pdf";
        document.Save(filename);
        System.Diagnostics.Process.Start(filename);
    }
}

