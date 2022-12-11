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
                string sqlcmdString = $"CALL SelectBooks()";
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

        public override Books getRow(int ID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"CALL SelectBookByID({ID})";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    Books DBRow = new Books
                    {
                        ID = reader.GetInt32(0),
                        bookName = reader.GetString(1),
                        author = reader.GetString(2),
                        genre = reader.GetString(3),
                        edition = reader.GetString(4),
                        rating = reader.GetString(5),
                        storage = reader.GetString(6),
                        ISBN = reader.GetString(7),
                        publisher = reader.GetString(8),
                        pubDate = reader.GetDateTime(9),
                        numOfPages = reader.GetInt32(10),
                        cost = reader.GetFloat(11),
                        amount = reader.GetInt32(12)
                    };
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
                string sqlcmdString = $"CALL BookSearch('{query}')";
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

        public override void add(Books item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"CALL BookInsert('{item.ID}', '{item.genre}', '{item.edition}', '{item.rating}', '{item.storage}', '{item.ISBN}', '{item.publisher}', '{item.author}', '{item.bookName}', '{item.pubDate}', '{item.numOfPages}', '{item.cost}', '{item.amount}')";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void update(int currentID, Books item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"CALL BookChange('{currentID}', '{item.ID}', '{item.genre}', '{item.edition}', '{item.rating}', '{item.storage}', '{item.ISBN}', '{item.publisher}', '{item.author}', '{item.bookName}', '{item.pubDate}', '{item.numOfPages}', '{item.cost}', '{item.amount}')"; 
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
                string sqlcmdString = $"DELETE FROM Books WHERE Books.book_id = {ID}"; 
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
