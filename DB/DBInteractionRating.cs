using LibraryDB.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibraryDB.DB
{
    internal class DBInteractionRating : DBInteraction<Rating>
    {
        public override DataTable getAll()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = "SELECT rating_id AS 'ID записи', age_rating AS 'Возрастной рейтинг' FROM Rating ORDER BY rating_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmdString, connection);
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                connection.Close();
                return table;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override Rating getRow(int ID)
        {
            try
            {
                Rating DBRow = new Rating();
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"SELECT * FROM Rating WHERE rating_id = {ID}";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DBRow.ID = reader.GetInt32(0);
                        DBRow.ageRating = reader.GetString(1);
                    }
                    return DBRow;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        public override DataTable search(string query)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"SELECT rating_id AS 'ID записи', age_rating AS 'Возрастной рейтинг' FROM Rating WHERE LOCATE(\"{query}\", CONCAT_WS(\" \", rating_id, age_rating)) >= 1 ORDER BY rating_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmdString, connection);
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                connection.Close();
                return table;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void add(Rating item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"INSERT INTO Rating (rating_id, age_rating) VALUES ('{item.ID}', '{item.ageRating}')";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void update(int currentID, Rating item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"UPDATE Rating SET rating_id = '{item.ID}', age_rating = '{item.ageRating}' WHERE Rating.rating_id = {currentID}";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void delete(int ID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"DELETE FROM Rating WHERE Rating.rating_id = {ID}";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
