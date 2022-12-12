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
    internal class DBInteractionGenre : DBInteraction<Genre>
    {
        public override DataTable getAll()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = "SELECT genre_id AS 'ID записи', genre AS 'Жанр' FROM Genre ORDER BY genre_id";
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

        public override Genre getRow(int ID)
        {
            try
            {
                Genre DBRow = new Genre();
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"SELECT * FROM Genre WHERE genre_id = {ID}";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DBRow.ID = reader.GetInt32(0);
                        DBRow.genreName = reader.GetString(1);
                    }
                    connection.Close();
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
                string sqlcmdString = $"SELECT genre_id AS 'ID записи', genre AS 'Жанр' FROM Genre WHERE LOCATE(\"{query}\", CONCAT_WS(\" \", genre_id, genre)) >= 1 ORDER BY genre_id";
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

        public override void add(Genre item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"INSERT INTO Genre (genre_id, genre) VALUES (NULL, '{item.genreName}')";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void update(int currentID, Genre item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"UPDATE Genre SET genre_id = '{item.ID}', genre = '{item.genreName}' WHERE Genre.genre_id = {currentID}"; 
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
                string sqlcmdString = $"DELETE FROM Genre WHERE Genre.genre_id = {ID}";
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
