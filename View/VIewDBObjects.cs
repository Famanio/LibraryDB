using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDB.Objects;
using LibraryDB.DB;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryDB.View
{
    internal class VIewDBObjects
    {
        public int choosenTableID;

        public DataTable chooseTable(string table)
        {     
            DataTable dt = new DataTable();
            switch (table)
            {
                case "Выдача книг":
                    choosenTableID = 1;
                    DBInteractionBookLending BookLendingsDB = new DBInteractionBookLending();
                    dt = BookLendingsDB.getAll();
                    break;
                case "Книги":
                    choosenTableID = 2;
                    DBInteractionBooks BooksDB = new DBInteractionBooks();
                    dt = BooksDB.getAll();
                    break;
                case "Читатели":
                    choosenTableID = 3;
                    DBInteractionReader ReadersDB = new DBInteractionReader();
                    dt = ReadersDB.getAll();
                    break;
                case "Библиотекари":
                    choosenTableID = 4;
                    DBInteractionLibrarian LibrariansDB = new DBInteractionLibrarian();
                    dt = LibrariansDB.getAll();
                    break;
                case "Жанры":
                    choosenTableID = 5;
                    DBInteractionGenre GenresDB = new DBInteractionGenre();
                    dt = GenresDB.getAll();
                    break;
                case "Издания":
                    choosenTableID = 6;
                    DBInteractionEdition EditionsDB = new DBInteractionEdition();
                    dt = EditionsDB.getAll();
                    break;
                case "Возрастной рейтинг":
                    choosenTableID = 7;
                    DBInteractionRating RatingsDB = new DBInteractionRating();
                    dt = RatingsDB.getAll();
                    break;
                case "Размещение":
                    choosenTableID = 8;
                    DBIntegrationStorage StorageDB = new DBIntegrationStorage();
                    dt = StorageDB.getAll();
                    break;
                default:
                    MessageBox.Show($"Возникла ошибка загрузки таблицы:\nНе удалось загрузить таблицу. Возможно, отсутствует подключение к серверу", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            return dt;
        }
    }
}
