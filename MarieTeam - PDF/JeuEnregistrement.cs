using MySql.Data.MySqlClient;

namespace MarieTeam___PDF
{
    /*
     * Classe pour gérer les enregistrements de la base de données
     */
    public class JeuEnregistrement
    {
        private MySqlDataReader reader;
        private MySqlConnection connection;
        private MySqlCommand command;

        /*
         * Constructeur de la classe JeuEnregistrement
         *
         * @param chaineSQL : chaîne SQL à exécuter
         */
        public JeuEnregistrement(string chaineSQL)
        {
            connection = new MySqlConnection("server=127.0.0.1;database=mariteam;uid=root;pwd=;");
            connection.Open();
            command = new MySqlCommand(chaineSQL, connection);
            reader = command.ExecuteReader();
        }

        /*
         * Méthode pour lire l'enregistrement suivant
         *
         * @return bool : vrai si un enregistrement a été lu, faux sinon
         */
        public bool LireSuivant()
        {
            return reader.Read();
        }

        /*
         * Méthode pour obtenir la valeur d'un champ
         *
         * @param nomChamp : nom du champ dont on veut obtenir la valeur
         * @return object : valeur du champ
         */
        public object GetValeur(string nomChamp)
        {
            return reader[nomChamp];
        }

        /*
         * Méthode pour fermer le lecteur et la connexion
         */
        public void Fermer()
        {
            reader.Close();
            connection.Close();
        }
    }
}
