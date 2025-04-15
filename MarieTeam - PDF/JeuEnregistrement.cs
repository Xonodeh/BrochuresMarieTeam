using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;


namespace MarieTeam___PDF
{
    public class JeuEnregistrement
    {
        private MySqlConnection connexion;
        private MySqlCommand commande;
        private MySqlDataReader lecteur;

        public JeuEnregistrement(string requeteSQL)
        {
            string chaineConnexion = "server=localhost;uid=root;pwd=;database=marieteam;";
            connexion = new MySqlConnection(chaineConnexion);
            commande = new MySqlCommand(requeteSQL, connexion);

            try
            {
                connexion.Open();
                lecteur = commande.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur de connexion : " + ex.Message);
            }
        }

        public void Suivant()
        {
            if (!lecteur.IsClosed) lecteur.Read();
        }

        public bool Fin()
        {
            return lecteur == null || !lecteur.HasRows || lecteur.IsClosed || lecteur.IsDBNull(0);
        }

        public object GetValeur(string nomChamp)
        {
            return lecteur[nomChamp];
        }

        public void Fermer()
        {
            if (lecteur != null && !lecteur.IsClosed) lecteur.Close();
            if (connexion.State == ConnectionState.Open) connexion.Close();
        }
    }
}
