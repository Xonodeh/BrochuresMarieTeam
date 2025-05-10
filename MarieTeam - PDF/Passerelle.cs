using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    public static class Passerelle
    {
        public static string erreurDerniereModif = "";

        /*
         * Méthode pour charger la liste des bateaux voyageurs depuis la base de données
         *
         * @return List<BateauVoyageur> : liste des bateaux voyageurs
         */
        public static List<BateauVoyageur> ChargerLesBateauxVoyageurs()
        {
            List<BateauVoyageur> bateaux = new List<BateauVoyageur>();
            JeuEnregistrement jeu = new JeuEnregistrement("SELECT * FROM bateau");

            while (jeu.LireSuivant())
            {
                string idBat = jeu.GetValeur("IDBateau").ToString();
                string nomBat = jeu.GetValeur("nomBateau").ToString();
                double longueur = double.Parse(jeu.GetValeur("LongueurBateau").ToString());
                double largeur = double.Parse(jeu.GetValeur("largeurBat").ToString());
                double vitesse = double.Parse(jeu.GetValeur("VitesseBateau").ToString());
                string image = jeu.GetValeur("imageBat").ToString();

                // 💡 Récupération des équipements du bateau
                List<Equipement> equipements = Passerelle.ChargerEquipementsDuBateau(idBat);

                bateaux.Add(new BateauVoyageur(idBat, nomBat, longueur, largeur, vitesse, image, equipements));
            }

            jeu.Fermer();
            return bateaux;
        }

        /*
         * Méthode pour charger les équipements d'un bateau spécifique
         *
         * @param idBateau : identifiant du bateau
         * @return List<Equipement> : liste des équipements du bateau
         */
        public static List<Equipement> ChargerLesEquipementsDuBateau(string idBateau)
        {
            List<Equipement> equipements = new List<Equipement>();

            // On échappe l'ID pour éviter les injections SQL
            string requete = $@"
                SELECT e.idEquipement, e.libEquipement
                FROM equipement e
                JOIN bateau_equipement be ON e.idEquipement = be.idEquipement
                WHERE be.idBateau = '{MySqlHelper.EscapeString(idBateau)}'";

            JeuEnregistrement jeu = new JeuEnregistrement(requete);

            while (jeu.LireSuivant())
            {
                string idEquip = jeu.GetValeur("idEquipement").ToString();
                string libEquip = jeu.GetValeur("libEquipement").ToString();
                equipements.Add(new Equipement(idEquip, libEquip));
            }

            jeu.Fermer();
            return equipements;
        }

        /*
         * Méthode pour ajouter des équipements à un bateau
         *
         * @param idBateau : identifiant du bateau
         * @param equipements : liste des équipements à ajouter
         * @return bool : vrai si l'opération a réussi, faux sinon
         */
        public static bool AjouterEquipementsAuBateau(string idBateau, List<Equipement> equipements)
        {
            try
            {
                // On commence une transaction pour être sûr que tout se passe bien
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=mariteam;uid=root;pwd=;"))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    // Suppression des anciennes associations pour ce bateau
                    string deleteSql = "DELETE FROM bateau_equipement WHERE idBateau = @idBateau";
                    using (MySqlCommand cmdDelete = new MySqlCommand(deleteSql, conn, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("@idBateau", idBateau);
                        cmdDelete.ExecuteNonQuery();
                    }

                    // Ajout des nouveaux équipements
                    string insertSql = "INSERT INTO bateau_equipement (idBateau, idEquipement) VALUES (@idBateau, @idEquipement)";
                    foreach (var equip in equipements)
                    {
                        using (MySqlCommand cmdInsert = new MySqlCommand(insertSql, conn, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("@idBateau", idBateau);
                            cmdInsert.Parameters.AddWithValue("@idEquipement", equip.IdEquip);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    // Si tout va bien, on valide la transaction
                    transaction.Commit();
                }
                return true;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, on annule la transaction et on affiche l'erreur
                MessageBox.Show("Erreur SQL : " + ex.Message + "\n\n" + ex.StackTrace);
                return false;
            }
        }

        /*
         * Méthode pour modifier les informations d'un bateau
         *
         * @param bateau : objet BateauVoyageur contenant les nouvelles informations
         * @return bool : vrai si la modification a réussi, faux sinon
         */
        public static bool ModifierBateau(BateauVoyageur bateau)
        {
            try
            {
                string sql = "UPDATE bateau SET nomBateau=@nom, LongueurBateau=@longueur, VitesseBateau=@vitesse, largeurBat=@largeur, imageBat=@image WHERE IDBateau=@id";
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=mariteam;uid=root;pwd=;"))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nom", bateau.nomBat);
                        cmd.Parameters.AddWithValue("@longueur", bateau.longueurBat);
                        cmd.Parameters.AddWithValue("@largeur", bateau.largeurBat);
                        cmd.Parameters.AddWithValue("@vitesse", bateau.VitesseBatVoy);
                        cmd.Parameters.AddWithValue("@image", bateau.GetImageBatVoy());
                        cmd.Parameters.AddWithValue("@id", bateau.idBat); // Il te faut une propriété idBat
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur SQL : " + ex.Message + "\n\n" + ex.StackTrace);
                return false;
            }
        }

        /*
         * Méthode pour charger tous les équipements depuis la base de données
         *
         * @return List<Equipement> : liste de tous les équipements
         */
        public static List<Equipement> ChargerTousLesEquipements()
        {
            List<Equipement> equipements = new List<Equipement>();
            JeuEnregistrement jeu = new JeuEnregistrement("SELECT * FROM equipement");

            while (jeu.LireSuivant())
            {
                string id = jeu.GetValeur("idEquipement").ToString();
                string lib = jeu.GetValeur("libEquipement").ToString();
                equipements.Add(new Equipement(id, lib));
            }

            jeu.Fermer();
            return equipements;
        }

        /*
         * Méthode pour charger les équipements d'un bateau spécifique
         *
         * @param idBateau : identifiant du bateau
         * @return List<Equipement> : liste des équipements du bateau
         */
        public static List<Equipement> ChargerEquipementsDuBateau(string idBateau)
        {
            List<Equipement> equipements = new List<Equipement>();
            string requete = $@"
            SELECT e.idEquipement, e.libEquipement
            FROM equipement e
            INNER JOIN bateau_equipement be ON e.idEquipement = be.idEquipement
            WHERE be.idBateau = '{idBateau}'";

            JeuEnregistrement jeu = new JeuEnregistrement(requete);

            while (jeu.LireSuivant())
            {
                string id = jeu.GetValeur("idEquipement").ToString();
                string lib = jeu.GetValeur("libEquipement").ToString();
                equipements.Add(new Equipement(id, lib));
            }

            jeu.Fermer();
            return equipements;
        }

        /*
         * Méthode pour ajouter un équipement à un bateau
         *
         * @param idBateau : identifiant du bateau
         * @param idEquipement : identifiant de l'équipement
         * @return bool : vrai si l'ajout a réussi, faux sinon
         */
        public static bool AjouterEquipementAuBateau(string idBateau, string idEquipement)
        {
            try
            {
                string sql = "INSERT INTO bateau_equipement (idBateau, idEquipement) VALUES (@idBat, @idEquip)";
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=mariteam;uid=root;pwd=;"))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idBat", idBateau);
                        cmd.Parameters.AddWithValue("@idEquip", idEquipement);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /*
         * Méthode pour supprimer un équipement d'un bateau
         *
         * @param idBateau : identifiant du bateau
         * @param idEquipement : identifiant de l'équipement
         * @return bool : vrai si la suppression a réussi, faux sinon
         */
        public static bool SupprimerEquipementDuBateau(string idBateau, string idEquipement)
        {
            try
            {
                string sql = "DELETE FROM bateau_equipement WHERE idBateau = @idBat AND idEquipement = @idEquip";
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=mariteam;uid=root;pwd=;"))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@idBat", idBateau);
                        cmd.Parameters.AddWithValue("@idEquip", idEquipement);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /*
         * Méthode pour récupérer tous les équipements depuis la base de données
         *
         * @return List<Equipement> : liste de tous les équipements
         */
        public static List<Equipement> GetTousLesEquipements()
        {
            List<Equipement> liste = new List<Equipement>();
            try
            {
                string sql = "SELECT idEquipement, libEquipement FROM equipement";
                using (MySqlConnection conn = new MySqlConnection("server=127.0.0.1;database=mariteam;uid=root;pwd=;"))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader.GetString("idEquipement");
                                string lib = reader.GetString("libEquipement");
                                liste.Add(new Equipement(id, lib));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des équipements : " + ex.Message);
            }

            return liste;
        }
    }
}
