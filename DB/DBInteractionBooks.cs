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
    internal class DBInteractionBooks : DBInteraction<Books>
    {
        public override DataTable getAll()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = ""; //селект или call процедура
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmdString, connection);
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                connection.Close();
                return table;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка загрузки: {ex}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        public override Books getRow(int ID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = ""; //запрос на получение элемента по id
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    Books DBRow = new Books
                    {
                        ID = reader.GetInt32(0),
                        genre = reader.GetString(1),
                        edition = reader.GetString(2),
                        rating = reader.GetString(3),
                        storage = reader.GetString(4),
                        ISBN = reader.GetString(5),
                        publisher = reader.GetString(6),
                        author = reader.GetString(7),
                        bookName = reader.GetString(8),
                        pubDate = reader.GetDateTime(9).ToString(),
                        numOfPages = reader.GetInt32(10),
                        cost = reader.GetFloat(11),
                        amount = reader.GetInt32(12)
                    };
                    return DBRow;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка загрузки: {ex.ToString}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

        }

        public override DataTable search(string query)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = ""; //запрос поиска или соотв процдура
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmdString, connection);
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                connection.Close();
                return table;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при поиске: {ex.ToString}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        public override void add(Books item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = ""; // в запросе использовать $"{item.smthng}"
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при добавлении: {ex.ToString}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        public override void update(Books item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = ""; // в запросе использовать $"{item.smthng}"
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при изменении: {ex.ToString}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }

        public override void delete(int ID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = ""; // в запросе использовать $"{item.ID}"
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка при удалении: {ex.ToString}", "Ошибка сервера", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }
    }
}
