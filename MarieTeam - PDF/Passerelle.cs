using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    public static class Passerelle
    {
        public static string erreurDerniereModif = "";
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

                List<Equipement> equipements = new List<Equipement>(); // Si tu ne gères pas encore les équipements
                bateaux.Add(new BateauVoyageur(idBat, nomBat, longueur, largeur, vitesse, image, equipements));
            }

            jeu.Fermer();
            return bateaux;
        }


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

    }
}
