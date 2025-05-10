using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    /*
     * Classe Form1
     * Formulaire principal de l'application - Interface de connexion pour accéder à la gestion des bateaux.
     */
    public partial class Form1 : Form
    {
        /*
         * Constructeur de Form1
         * Initialise les composants graphiques du formulaire.
         */
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Événement déclenché lors du clic sur le bouton de connexion.
         * Vérifie les identifiants saisis par l'utilisateur.
         * Si les identifiants sont corrects, ouvre le formulaire de gestion des bateaux.
         * Sinon, affiche un message d'erreur.
         *
         * @param sender : objet à l'origine de l'événement
         * @param e      : arguments de l'événement
         */
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (login == "admin" && password == "admin123") // Remplace par tes identifiants réels
            {
                FormGestionBateaux formGestion = new FormGestionBateaux();
                formGestion.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Identifiants incorrects !");
            }
        }

        /*
         * Événement déclenché au chargement du formulaire Form1.
         * Peut être utilisé pour initialiser des données ou configurer des éléments à l’ouverture du formulaire.
         *
         * @param sender : objet à l'origine de l'événement
         * @param e      : arguments de l'événement
         */
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
