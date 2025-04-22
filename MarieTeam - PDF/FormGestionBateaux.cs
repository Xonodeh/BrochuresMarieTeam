using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    public partial class FormGestionBateaux : Form
    {
        private List<BateauVoyageur> bateaux;

        public FormGestionBateaux()
        {
            InitializeComponent();
        }

        private void FormGestionBateaux_Load(object sender, EventArgs e)
        {
            bateaux = Passerelle.ChargerLesBateauxVoyageurs();

            lstBateaux.Items.Clear();
            foreach (var bateau in bateaux)
            {
                lstBateaux.Items.Add(bateau.nomBat);
            }
        }

        private void lstBateaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBateaux.SelectedIndex >= 0)
            {
                var bateau = bateaux[lstBateaux.SelectedIndex];

                txtNomBateau.Text = bateau.nomBat;
                txtLongueur.Text = bateau.longueurBat.ToString();
                txtLargeur.Text = bateau.largeurBat.ToString();
                txtVitesse.Text = bateau.VitesseBatVoy.ToString();
                txtImageUrl.Text = bateau.GetImageBatVoy();

                rtbEquipements.Clear();
                foreach (var eq in bateau.LesEquipements)
                {
                    rtbEquipements.AppendText($"- {eq}\n");
                }

                if (File.Exists(bateau.GetImageBatVoy()))
                {
                    picBateau.Image = Image.FromFile(bateau.GetImageBatVoy());
                    picBateau.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    picBateau.Image = null;
                }
            }
        }

        private void btnGenererPDF_Click(object sender, EventArgs e)
        {
            if (lstBateaux.SelectedIndex >= 0)
            {
                var bateau = bateaux[lstBateaux.SelectedIndex];
                BrochurePDF.GenererBrochure(new List<BateauVoyageur> { bateau });
                MessageBox.Show("PDF généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un bateau dans la liste !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
