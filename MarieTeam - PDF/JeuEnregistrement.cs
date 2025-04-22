using MySql.Data.MySqlClient;

namespace MarieTeam___PDF
{
    public class JeuEnregistrement
    {
        private MySqlDataReader reader;
        private MySqlConnection connection;
        private MySqlCommand command;

        public JeuEnregistrement(string chaineSQL)
        {
            connection = new MySqlConnection("server=localhost;database=mariteam;uid=mariteam;pwd=root;");
            connection.Open();
            command = new MySqlCommand(chaineSQL, connection);
            reader = command.ExecuteReader();
        }

        public bool LireSuivant()
        {
            return reader.Read();
        }

        public object GetValeur(string nomChamp)
        {
            return reader[nomChamp];
        }

        public void Fermer()
        {
            reader.Close();
            connection.Close();
        }
    }
}
