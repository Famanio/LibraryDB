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

        public string[] bookLendingLabels = { "ID выдачи", "Библиотекарь", "Читатель", "Книга", "Кол-во", "Дата выдачи", "Дата возврата" };
        public string[] bookLabels = { "ID книги", "Название книги", "Автор", "Жанр", "Издание", "Возрастной рейтинг",
        "Расположение", "ISBN", "Издатель", "Дата издания", "Кол-во стр.", "Стоимость (руб.)", "Кол-во" };
        public string[] readerLabels = { "ID читателя", "Фамилия", "Имя", "Отчество", "Дата рождения", "Адрес проживания", "Номер телефона", "Дата регистрации" };
        public string[] librarianLabels = { "ID библиотекаря", "Фамилия", "Имя", "Отчество" };
        public string[] genreLabels = { "ID записи", "Жанр" };
        public string[] editionLabels = { "ID записи", "Тип" };
        public string[] ratingLabels = { "ID записи", "Возрастной рейтинг" };
        public string[] storageLabels = { "ID записи", "Расположение" };

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

        public DataTable searchRows(string query)
        {
            DataTable dt = new DataTable();
            switch (choosenTableID)
            {
                case 1:
                    DBInteractionBookLending BookLendingsDB = new DBInteractionBookLending();
                    dt = BookLendingsDB.search(query);
                    break;
                case 2:
                    DBInteractionBooks BooksDB = new DBInteractionBooks();
                    dt = BooksDB.search(query);
                    break;
                case 3:
                    DBInteractionReader ReadersDB = new DBInteractionReader();
                    dt = ReadersDB.search(query);
                    break;
                case 4:
                    DBInteractionLibrarian LibrariansDB = new DBInteractionLibrarian();
                    dt = LibrariansDB.search(query);
                    break;
                case 5:
                    DBInteractionGenre GenresDB = new DBInteractionGenre();
                    dt = GenresDB.search(query);
                    break;
                case 6:
                    DBInteractionEdition EditionsDB = new DBInteractionEdition();
                    dt = EditionsDB.search(query);
                    break;
                case 7:
                    DBInteractionRating RatingsDB = new DBInteractionRating();
                    dt = RatingsDB.search(query);
                    break;
                case 8:
                    DBIntegrationStorage StorageDB = new DBIntegrationStorage();
                    dt = StorageDB.search(query);
                    break;
                default:
                    MessageBox.Show($"Возникла ошибка загрузки таблицы:\nНе удалось найти данные. Возможно, отсутствует подключение к серверу", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            return dt;
        }

        public string[] getStringRow(int ID)
        {
            switch (choosenTableID)
            {
                case 1:
                    DBInteractionBookLending BookLendingsDB = new DBInteractionBookLending();
                    BookLending BL = BookLendingsDB.getRow(ID);
                    string[] strBL = BL.convertToStrArr();
                    return strBL;
                case 2:
                    DBInteractionBooks BooksDB = new DBInteractionBooks();
                    Books BK = BooksDB.getRow(ID);
                    string[] strBK = BK.convertToStrArr();
                    return strBK;
                case 3:
                    DBInteractionReader ReadersDB = new DBInteractionReader();
                    Reader RD = ReadersDB.getRow(ID);
                    string[] strRD = RD.convertToStrArr();
                    return strRD;
                case 4:
                    DBInteractionLibrarian LibrariansDB = new DBInteractionLibrarian();
                    Librarian LB = LibrariansDB.getRow(ID);
                    string[] strLB = LB.convertToStrArr();
                    return strLB;
                case 5:
                    DBInteractionGenre GenresDB = new DBInteractionGenre();
                    Genre GN = GenresDB.getRow(ID);
                    string[] strGN = GN.convertToStrArr();
                    return strGN;
                case 6:
                    DBInteractionEdition EditionsDB = new DBInteractionEdition();
                    Edition ED = EditionsDB.getRow(ID);
                    string[] strED = ED.convertToStrArr();
                    return strED;
                case 7:
                    DBInteractionRating RatingsDB = new DBInteractionRating();
                    Rating RT = RatingsDB.getRow(ID);
                    string[] strRT = RT.convertToStrArr();
                    return strRT;
                case 8:
                    DBIntegrationStorage StorageDB = new DBIntegrationStorage();
                    Storage ST = StorageDB.getRow(ID);
                    string[] strST = ST.convertToStrArr();
                    return strST;
                default:
                    MessageBox.Show($"Возникла ошибка загрузки таблицы:\nНе удалось найти данные. Возможно, отсутствует подключение к серверу", "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string[] empty = new string[0];
                    return empty;
            }
        }
    }
}
