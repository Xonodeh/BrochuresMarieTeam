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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGenererPDF_Click_1(object sender, EventArgs e)
        {
            // Ici, on passe toute la liste de bateaux pour générer la brochure complète
            BrochurePDF.GenererBrochure(bateaux);
            MessageBox.Show("PDF généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (lstBateaux.SelectedIndex < 0)
            {
                MessageBox.Show("Sélectionnez un bateau à modifier.");
                return;
            }

            var bateau = bateaux[lstBateaux.SelectedIndex];

            // Met à jour l'objet bateau avec les nouvelles valeurs des TextBox
            bateau.nomBat = txtNomBateau.Text;
            bateau.longueurBat = double.TryParse(txtLongueur.Text, out double l) ? l : 0;
            bateau.largeurBat = double.TryParse(txtLargeur.Text, out double la) ? la : 0;
            bateau.VitesseBatVoy = double.TryParse(txtVitesse.Text, out double v) ? v : 0;
            bateau.SetImageBatVoy(txtImageUrl.Text);

            // Mets à jour dans la base (méthode à créer dans Passerelle)
            bool res = Passerelle.ModifierBateau(bateau);

            if (res)
            {
                MessageBox.Show("Bateau modifié avec succès !");
                // Recharge la liste pour afficher la modif
                lstBateaux.Items[lstBateaux.SelectedIndex] = bateau.nomBat;
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification.\n\n" + Passerelle.erreurDerniereModif);
            }
        }

        private void rtbEquipements_TextChanged(object sender, EventArgs e)
        {
            // Récupérer le texte de la RichTextBox
            string texteEquipements = rtbEquipements.Text;

            // Séparer les équipements, supposons qu'ils sont séparés par des virgules ou des retours à la ligne
            string[] equipementsNoms = texteEquipements.Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Liste pour stocker les objets Equipement
            List<Equipement> equipementsSelectionnes = new List<Equipement>();

            foreach (string nomEquip in equipementsNoms)
            {
                // Ici, on suppose que les équipements existent déjà dans la base de données
                // Et que tu as déjà leur ID ou que tu les ajoutes manuellement
                // Par exemple, ajout d'un équipement par son nom ou ID
                // Cela dépend de ton application et de ta logique

                // Exemple d'ajout d'un équipement fictif
                equipementsSelectionnes.Add(new Equipement("id123", nomEquip.Trim()));
            }

            // Si des équipements sont sélectionnés, on les ajoute au bateau
            if (equipementsSelectionnes.Count > 0)
            {
                string idBateau = "1";  // Remplace cela par l'ID du bateau sélectionné
                bool succes = Passerelle.AjouterEquipementsAuBateau(idBateau, equipementsSelectionnes);

                if (succes)
                {
                    MessageBox.Show("Les équipements ont été ajoutés avec succès !");
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue.");
                }
            }
        }

    }
}
