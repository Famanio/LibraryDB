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
    internal class DBInteractionBookLending : DBInteraction<BookLending>
    {
        public override DataTable getAll()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = "CALL SelectBookLending()";
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

        public override BookLending getRow(int ID)
        {
            try
            {
                BookLending DBRow = new BookLending();
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"CALL SelectBookLendingByID({ID})";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        DBRow.ID = reader.GetInt32(0);
                        DBRow.librarian = reader.GetString(1);
                        DBRow.reader = reader.GetString(2);
                        DBRow.book = reader.GetString(3);
                        DBRow.lendAmount = reader.GetInt32(4);
                        DBRow.dateOfIssue = reader.GetString(5);
                        DBRow.returnDate = reader.GetString(6);
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
                string sqlcmdString = $"CALL BookLendingSearch('{query}')"; 
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

        public override void add(BookLending item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $" CALL BookLendingInsert('{item.librarian}', '{item.reader}', '{item.book}', '{item.lendAmount}', '{item.returnDate}')";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public override void update(int currentID, BookLending item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"CALL BookLendingChange('{currentID}', '{item.ID}', '{item.librarian}', '{item.reader}', '{item.book}', '{item.lendAmount}', '{item.dateOfIssue}', '{item.returnDate}')"; 
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
                string sqlcmdString = $"DELETE FROM Book_lending WHERE Book_lending.lending_id = {ID}";
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
