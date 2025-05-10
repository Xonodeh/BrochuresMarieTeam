using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Collections.Generic;
using System.IO;
using MarieTeam___PDF;
using System.Net;
using System;

/*
 * Classe statique BrochurePDF
 * Permet de générer un fichier PDF contenant une brochure présentant une liste de bateaux voyageurs.
 * Utilise la bibliothèque PdfSharp pour la création et le rendu du document.
 */
public static class BrochurePDF
{
    /*
     * Méthode statique : GenererBrochure
     * Génère un fichier PDF listant les bateaux voyageurs, avec leurs images, dimensions, vitesses et équipements.
     *
     * @param bateaux : liste d'objets BateauVoyageur à inclure dans la brochure
     */
    public static void GenererBrochure(List<BateauVoyageur> bateaux)
    {
        // Création du document PDF
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Brochure des Bateaux - MarieTeam";

        // Définition des polices
        XFont fontTitre = new XFont("Arial", 16, XFontStyle.Bold);
        XFont fontInfos = new XFont("Arial", 12, XFontStyle.Regular);
        XFont fontItalic = new XFont("Arial", 12, XFontStyle.Italic);

        // Parcours de chaque bateau
        foreach (var bateau in bateaux)
        {
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            double posY = 30;

            // Titre de la page
            gfx.DrawString("BATEAUX", fontTitre, XBrushes.Black, new XRect(0, posY, page.Width, 30), XStringFormats.TopCenter);
            posY += 40;

            /*
             * Gestion de l'image du bateau
             * - Si l'image est une URL, elle est téléchargée temporairement
             * - Si c'est un chemin local, il est utilisé directement
             */
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

            // Affichage de l'image si elle est disponible
            if (!string.IsNullOrEmpty(localImagePath) && File.Exists(localImagePath))
            {
                using (XImage img = XImage.FromFile(localImagePath))
                {
                    double imgWidth = 250, imgHeight = 100;
                    gfx.DrawImage(img, (page.Width - imgWidth) / 2, posY, imgWidth, imgHeight);
                    posY += imgHeight + 20;
                }
            }

            // Suppression du fichier temporaire s’il a été créé
            if (isUrl && !string.IsNullOrEmpty(localImagePath) && File.Exists(localImagePath))
                File.Delete(localImagePath);

            // Affichage des informations textuelles du bateau
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

            // Liste des équipements
            foreach (var eq in bateau.LesEquipements)
            {
                gfx.DrawString($"- {eq}", fontInfos, XBrushes.Black, 70, posY);
                posY += 18;
            }
        }

        // Enregistrement et ouverture automatique du fichier PDF
        string filename = "BrochureMarieTeam.pdf";
        document.Save(filename);
        System.Diagnostics.Process.Start(filename);
    }
}
