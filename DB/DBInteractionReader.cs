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
    internal class DBInteractionReader : DBInteraction<Reader>
    {
        //в эти классы DateTime попадает в нужной форме (задача вьюшек - преобразовать из дд.мм.гггг в гггг-мм-дд)
        public override DataTable getAll()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = "SELECT reader_id AS 'ID читателя', surname AS 'Фамилия', name AS 'Имя', patronymic AS 'Отчество', DATE_FORMAT(date_of_birth, '%d.%m.%Y') AS 'Дата рождения', home_address AS 'Адрес проживания', phone_num AS 'Номер телефона', DATE_FORMAT(reg_date, '%d.%m.%Y') AS 'Дата регистрации' FROM Reader"; 
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

        public override Reader getRow(int ID)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"SELECT * FROM Reader WHERE reader_id = {ID}";
                MySqlCommand sqlcmd = new MySqlCommand(sqlcmdString, connection);
                using (MySqlDataReader reader = sqlcmd.ExecuteReader())
                {
                    Reader DBRow = new Reader
                    {
                        ID = reader.GetInt32(0),
                        surname = reader.GetString(1),
                        name = reader.GetString(2),
                        patronymic = reader.GetString(3),
                        dateOfBirth = reader.GetDateTime(4).ToString(),
                        homeAddress = reader.GetString(5),
                        phoneNumber = reader.GetString(6),
                        regDate = reader.GetString(7)
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
                query = System.Text.RegularExpressions.Regex.Replace(query, @"\s+", " ");
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"SELECT SELECT reader_id AS 'ID читателя', surname AS 'Фамилия', name AS 'Имя', patronymic AS 'Отчество', DATE_FORMAT(date_of_birth, '%d.%m.%Y') AS 'Дата рождения', home_address AS 'Адрес проживания', phone_num AS 'Номер телефона', DATE_FORMAT(reg_date, '%d.%m.%Y') AS 'Дата регистрации' FROM Reader WHERE LOCATE(\"{query}\", CONCAT_WS(\" \", reader_id, surname, name, patronymic, DATE_FORMAT(date_of_birth, '%d.%m.%Y'), home_address, phone_num, DATE_FORMAT(reg_date, '%d.%m.%Y'))) >= 1"; //запрос поиска или соотв процдура
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

        public override void add(Reader item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"INSERT INTO Reader (reader_id, surname, name, patronymic, date_of_birth, home_address, phone_num, reg_date) VALUES ('{item.ID}', '{item.surname}', '{item.name}', '{item.patronymic}', '{item.dateOfBirth}', '{item.homeAddress}', '{item.phoneNumber}', '{item.regDate}')";
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

        public override void update(int currentID, Reader item)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connString);
                connection.Open();
                string sqlcmdString = $"UPDATE Reader SET reader_id = '{item.ID}', surname = '{item.surname}', name = '{item.name}', patronymic = '{item.patronymic}', date_of_birth = '{item.dateOfBirth}', home_address = '{item.homeAddress}', phone_num = '{item.phoneNumber}', reg_date = '{item.regDate}' WHERE Reader.reader_id = {currentID}";
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
                string sqlcmdString = $"DELETE FROM Reader WHERE Reader.reader_id = {ID}";
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
