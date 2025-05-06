using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    public partial class FormGestionBateaux : Form
    {
        private List<BateauVoyageur> bateaux;

        private Equipement TrouverEquipementParNom(string nom)
        {
            var tousLesEquipements = Passerelle.ChargerTousLesEquipements();
            return tousLesEquipements.FirstOrDefault(eq => eq.libEquip.Equals(nom, StringComparison.OrdinalIgnoreCase));
        }

        private void AfficherEquipementsDuBateau(string idBateau)
        {
            // Récupérer les équipements du bateau
            var equipements = Passerelle.ChargerEquipementsDuBateau(idBateau);
            equipDuBateau.Items.Clear();
            foreach (var eq in equipements)
            {
                equipDuBateau.Items.Add(eq.libEquip);
            }
        }

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

            // Afficher tous les équipements
            AfficherTousLesEquipements();
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

                // Afficher les équipements seulement du bateau sélectionné
                AfficherEquipementsDuBateau(bateau.idBat);

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

        private void toutLesEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toutLesEquip.SelectedIndex >= 0)
            {
                // Récupérer l'équipement sélectionné
                string equipementSelectionne = toutLesEquip.SelectedItem.ToString();

                // Trouver l'équipement dans la base de données
                Equipement eq = TrouverEquipementParNom(equipementSelectionne);
                if (eq != null)
                {
                    // Action à faire, par exemple ajouter cet équipement au bateau
                    MessageBox.Show($"Équipement {eq.libEquip} sélectionné!");
                }
            }
        }

        private void equipDuBateau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (equipDuBateau.SelectedIndex >= 0)
            {
                // Récupérer l'équipement sélectionné
                string equipementSelectionne = equipDuBateau.SelectedItem.ToString();

                // Trouver l'équipement dans la base de données
                Equipement eq = TrouverEquipementParNom(equipementSelectionne);
                if (eq != null)
                {
                    // Action à faire, par exemple supprimer cet équipement du bateau
                    MessageBox.Show($"Équipement {eq.libEquip} sélectionné !");
                }
            }
        }

        private void addEquipement_Click(object sender, EventArgs e)
        {
            if (lstBateaux.SelectedIndex < 0) return;

            var bateau = bateaux[lstBateaux.SelectedIndex];
            string selectedEquipement = toutLesEquip.SelectedItem?.ToString().Trim();

            if (string.IsNullOrEmpty(selectedEquipement))
            {
                MessageBox.Show("Sélectionnez un équipement dans la liste.");
                return;
            }

            Equipement eq = TrouverEquipementParNom(selectedEquipement);
            if (eq == null)
            {
                MessageBox.Show("Équipement introuvable.");
                return;
            }

            bool result = Passerelle.AjouterEquipementAuBateau(bateau.idBat, eq.IdEquip);

            if (result)
            {
                MessageBox.Show("Équipement ajouté.");
                AfficherEquipementsDuBateau(bateau.idBat); // Rafraîchir
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout.");
            }
        }

        private void supprEquipement_Click(object sender, EventArgs e)
        {
            if (lstBateaux.SelectedIndex < 0) return;

            var bateau = bateaux[lstBateaux.SelectedIndex];
            string selectedEquipement = equipDuBateau.SelectedItem?.ToString().Trim();

            if (string.IsNullOrEmpty(selectedEquipement))
            {
                MessageBox.Show("Sélectionnez un équipement à supprimer.");
                return;
            }

            Equipement eq = TrouverEquipementParNom(selectedEquipement);
            if (eq == null)
            {
                MessageBox.Show("Équipement introuvable.");
                return;
            }

            bool result = Passerelle.SupprimerEquipementDuBateau(bateau.idBat, eq.IdEquip);

            if (result)
            {
                MessageBox.Show("Équipement supprimé.");
                AfficherEquipementsDuBateau(bateau.idBat); // Rafraîchir
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression.");
            }
        }

        private void AfficherTousLesEquipements()
        {
            var equipements = Passerelle.ChargerTousLesEquipements();
            toutLesEquip.Items.Clear();
            foreach (var eq in equipements)
            {
                toutLesEquip.Items.Add(eq.libEquip);
            }
        }
    }
}
