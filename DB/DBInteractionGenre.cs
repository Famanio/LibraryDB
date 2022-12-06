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
                string sqlcmdString = "";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlcmdString, connection);
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                connection.Close();
                return table;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex}","Ошибка загрузки",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw ex;
            }
        }

        public override Genre getRow(int ID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = "";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    Genre DBObject = new Genre
                    {
                        ID = reader.GetInt32(0),
                        genreName = reader.GetString(1)
                    };
                    return DBObject;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Возникла ошибка: {ex.ToString}", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

        }

        public override void search(string query)
        {
            throw new NotImplementedException();
        }

        public override void add(Genre item)
        {
            throw new NotImplementedException();
        }

        public override void update(Genre item)
        {
            throw new NotImplementedException();
        }

        public override void delete(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
