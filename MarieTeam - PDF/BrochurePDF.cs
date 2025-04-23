using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Collections.Generic;
using System.IO;
using MarieTeam___PDF;
using System.Net;
using System;


public static class BrochurePDF
{
    public static void GenererBrochure(List<BateauVoyageur> bateaux)
    {
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Brochure des Bateaux - MarieTeam";

        XFont fontTitre = new XFont("Arial", 16, XFontStyle.Bold);
        XFont fontInfos = new XFont("Arial", 12, XFontStyle.Regular);
        XFont fontItalic = new XFont("Arial", 12, XFontStyle.Italic);

        foreach (var bateau in bateaux)
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            double posY = 30;

            gfx.DrawString("BATEAUX", fontTitre, XBrushes.Black, new XRect(0, posY, page.Width, 30), XStringFormats.TopCenter);
            posY += 40;

            // Gestion de l'image (utilise l'image URL ou locale)
            string imagePath = bateau.GetImageBatVoy();
            bool isUrl = imagePath.StartsWith("http", StringComparison.OrdinalIgnoreCase);
            string localImagePath = imagePath;

            if (isUrl)
            {
                try
                {
                    string tempFile = Path.GetTempFileName();
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(imagePath, tempFile);
                    }
                    localImagePath = tempFile;
                }
                catch
                {
                    localImagePath = null;
                }
            }

            if (!string.IsNullOrEmpty(localImagePath) && File.Exists(localImagePath))
            {
                using (XImage img = XImage.FromFile(localImagePath))
                {
                    double imgWidth = 250, imgHeight = 100;
                    gfx.DrawImage(img, (page.Width - imgWidth) / 2, posY, imgWidth, imgHeight);
                    posY += imgHeight + 20;
                }
            }

            // Maintenant, tu peux supprimer le fichier temporaire en toute sécurité
            if (isUrl && !string.IsNullOrEmpty(localImagePath) && File.Exists(localImagePath))
                File.Delete(localImagePath);


            if (isUrl && !string.IsNullOrEmpty(localImagePath) && File.Exists(localImagePath))
                File.Delete(localImagePath);

            // Le reste de tes champs texte
            gfx.DrawString($"Nom du bateau : {bateau.nomBat}", fontItalic, XBrushes.Black, 50, posY);
            posY += 25;
            gfx.DrawString($"Longueur : {bateau.longueurBat} mètres", fontInfos, XBrushes.Black, 50, posY);
            posY += 20;
            gfx.DrawString($"Largeur : {bateau.largeurBat} mètres", fontInfos, XBrushes.Black, 50, posY);
            posY += 20;
            gfx.DrawString($"Vitesse : {bateau.VitesseBatVoy} noeuds", fontInfos, XBrushes.Black, 50, posY);
            posY += 20;
            gfx.DrawString("Liste des équipements du bateau :", fontInfos, XBrushes.Black, 50, posY);
            posY += 20;

            foreach (var eq in bateau.LesEquipements)
            {
                gfx.DrawString($"- {eq}", fontInfos, XBrushes.Black, 70, posY);
                posY += 18;
            }
        }

        string filename = "BrochureMarieTeam.pdf";
        document.Save(filename);
        System.Diagnostics.Process.Start(filename);
    }

}
