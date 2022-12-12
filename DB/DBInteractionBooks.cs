using LibraryDB.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace LibraryDB.DB
{
    //базовый класс, методы гет переделать как тут, сделать все даты стрингами, все равно нормально их получать я не могу
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
                Books DBRow = new Books();
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"CALL SelectBookByID({ID})";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DBRow.ID = reader.GetInt32(0);
                        DBRow.bookName = reader.GetString(1);
                        DBRow.author = reader.GetString(2);
                        DBRow.genre = reader.GetString(3);
                        DBRow.edition = reader.GetString(4);
                        DBRow.rating = reader.GetString(5);
                        DBRow.storage = reader.GetString(6);
                        DBRow.ISBN = reader.GetString(7);
                        DBRow.publisher = reader.GetString(8);
                        DBRow.pubDate = reader.GetString(9);
                        DBRow.numOfPages = reader.GetInt32(10);
                        DBRow.cost = reader.GetFloat(11);
                        DBRow.amount = reader.GetInt32(12);
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
                string sqlcmdString = $"CALL BookInsert( '{item.genre}', '{item.edition}', '{item.rating}', '{item.storage}', '{item.ISBN}', '{item.publisher}', '{item.author}', '{item.bookName}', '{item.pubDate}', '{item.numOfPages}', '{item.cost}', '{item.amount}')";
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
