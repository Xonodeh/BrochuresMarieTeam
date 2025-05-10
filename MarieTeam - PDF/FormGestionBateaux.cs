using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    public partial class FormGestionBateaux : Form
    {
        private List<BateauVoyageur> bateaux;

        /*
         * Méthode pour trouver un équipement par son nom
         *
         * @param nom : nom de l'équipement à trouver
         * @return Equipement : l'équipement trouvé ou null si non trouvé
         */
        public Equipement TrouverEquipementParNom(string nom)
        {
            var tousLesEquipements = Passerelle.ChargerTousLesEquipements();
            return tousLesEquipements.FirstOrDefault(eq => eq.libEquip.Equals(nom, StringComparison.OrdinalIgnoreCase));
        }

        /*
         * Méthode pour afficher les équipements d'un bateau
         *
         * @param idBateau : identifiant du bateau
         */
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

        /*
         * Constructeur de la classe FormGestionBateaux
         */
        public FormGestionBateaux()
        {
            InitializeComponent();
        }

        /*
         * Méthode appelée lors du chargement du formulaire
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
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

        /*
         * Méthode appelée lors du changement de sélection dans la liste des bateaux
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
        private void lstBateaux_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBateaux.SelectedIndex >= 0)
            {
                // Récupère le bateau sélectionné dans la liste
                var bateau = bateaux[lstBateaux.SelectedIndex];

                // Met à jour les informations du bateau dans les champs de texte
                txtNomBateau.Text = bateau.nomBat;
                txtLongueur.Text = bateau.longueurBat.ToString();
                txtLargeur.Text = bateau.largeurBat.ToString();
                txtVitesse.Text = bateau.VitesseBatVoy.ToString();
                txtImageUrl.Text = bateau.GetImageBatVoy();

                // Afficher les équipements seulement du bateau sélectionné
                AfficherEquipementsDuBateau(bateau.idBat);

                // Récupère l'image du bateau
                string imagePath = bateau.GetImageBatVoy();
                bool isUrl = imagePath.StartsWith("http", StringComparison.OrdinalIgnoreCase);

                if (isUrl)
                {
                    // Si l'image est une URL, la télécharger et l'afficher
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            using (Stream stream = client.OpenRead(imagePath))
                            {
                                Image img = Image.FromStream(stream);
                                picBateau.Image = img;
                                picBateau.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("L'image n'a pas pu être téléchargée.");
                        picBateau.Image = null;
                    }
                }
                else
                {
                    // Si l'image est un chemin local, l'afficher directement
                    if (File.Exists(imagePath))
                    {
                        picBateau.Image = Image.FromFile(imagePath);
                        picBateau.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        picBateau.Image = null;
                    }
                }
            }
        }

        /*
         * Méthode appelée lors du clic sur le bouton de génération de PDF pour un bateau
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
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

        /*
         * Méthode appelée lors du clic sur le bouton de génération de PDF pour tous les bateaux
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
        private void btnGenererPDF_Click_1(object sender, EventArgs e)
        {
            // Recharger les équipements pour chaque bateau avant de générer le PDF
            foreach (var bateau in bateaux)
            {
                bateau.LesEquipements = Passerelle.ChargerEquipementsDuBateau(bateau.idBat);
            }

            BrochurePDF.GenererBrochure(bateaux);
            MessageBox.Show("PDF généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*
         * Méthode appelée lors du clic sur le bouton de modification d'un bateau
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
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

        /*
         * Méthode appelée lors du changement de sélection dans la liste de tous les équipements
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
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

        /*
         * Méthode appelée lors du changement de sélection dans la liste des équipements du bateau
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
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

        /*
         * Méthode appelée lors du clic sur le bouton d'ajout d'un équipement au bateau
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
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

        /*
         * Méthode appelée lors du clic sur le bouton de suppression d'un équipement du bateau
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
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

        /*
         * Méthode pour afficher tous les équipements
         */
        private void AfficherTousLesEquipements()
        {
            var equipements = Passerelle.ChargerTousLesEquipements();
            toutLesEquip.Items.Clear();
            foreach (var eq in equipements)
            {
                toutLesEquip.Items.Add(eq.libEquip);
            }
        }

        /*
         * Méthode appelée lors du clic sur l'image du bateau
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
        private void picBateau_Click(object sender, EventArgs e)
        {
            // Vérifie si l'image est déjà chargée
            if (picBateau.Image != null)
            {
                // Si l'image est déjà affichée, tu peux faire une action ici
                // Par exemple, afficher un message ou ouvrir une fenêtre de détails
                MessageBox.Show("L'image du bateau a été cliquée !");
            }
            else
            {
                MessageBox.Show("Aucune image disponible à afficher.");
            }
        }

        /*
         * Méthode appelée lors du changement de sélection dans la liste de tous les équipements
         *
         * @param sender : objet qui a déclenché l'événement
         * @param e : arguments de l'événement
         */
        private void toutLesEquip_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
