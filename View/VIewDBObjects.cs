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

        public string[] bookLendingLabels = { "ID выдачи (не используется в добавлении)", "Библиотекарь", "Читатель", "Книга (ISBN/Название)", "Кол-во",
        "Дата выдачи (автоопределение при добавлении)", "Дата возврата" };
        public string[] bookLabels = { "ID книги (не используется в добавлении)", "Название книги", "Автор", "Жанр", "Издание", "Возрастной рейтинг",
        "Расположение", "ISBN", "Издатель", "Дата издания", "Кол-во стр.", "Стоимость (руб.)", "Кол-во" };
        public string[] readerLabels = { "ID читателя", "Фамилия", "Имя", "Отчество", "Дата рождения", "Адрес проживания", "Номер телефона", "Дата регистрации" };
        public string[] librarianLabels = { "ID библиотекаря", "Фамилия", "Имя", "Отчество" };
        public string[] genreLabels = { "ID записи (не используется в добавлении)", "Жанр" };
        public string[] editionLabels = { "ID записи (не используется в добавлении)", "Тип" };
        public string[] ratingLabels = { "ID записи (не используется в добавлении)", "Возрастной рейтинг" };
        public string[] storageLabels = { "ID записи (не используется в добавлении)", "Расположение" };

        public enum mode
        {
            add,
            upd,
            del
        }

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

       public void viewModeRowDB(string[] obj, int ID, mode mode)
       {
            try
            {
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i] = System.Text.RegularExpressions.Regex.Replace(obj[i], @"\s+", " ");
                }
                switch (choosenTableID)
                {
                    case 1:
                        DBInteractionBookLending BookLendingsDB = new DBInteractionBookLending();
                        BookLending BL = new BookLending();
                        switch (mode)
                        {
                            case mode.add:
                                obj[0] = "-1";
                                BL = BL.convertStrArrToObj(obj, true);
                                BookLendingsDB.add(BL);
                                break;
                            case mode.upd:
                                BL = BL.convertStrArrToObj(obj, true);
                                BookLendingsDB.update(ID, BL);
                                break;
                            case mode.del:
                                BookLendingsDB.delete(ID);
                                break;
                        }
                        break;
                    case 2:
                        DBInteractionBooks BooksDB = new DBInteractionBooks();
                        Books BK = new Books();
                        switch (mode)
                        {
                            case mode.add:
                                obj[0] = "-1";
                                BK = BK.convertStrArrToObj(obj, true);
                                BooksDB.add(BK);
                                break;
                            case mode.upd:
                                BK = BK.convertStrArrToObj(obj, true);
                                BooksDB.update(ID, BK);
                                break;
                            case mode.del:
                                BooksDB.delete(ID);
                                break;
                        }
                        break;
                    case 3:
                        DBInteractionReader ReadersDB = new DBInteractionReader();
                        Reader RD = new Reader();
                        switch (mode)
                        {
                            case mode.add:
                                RD = RD.convertStrArrToObj(obj, true);
                                ReadersDB.add(RD);
                                break;
                            case mode.upd:
                                RD = RD.convertStrArrToObj(obj, true);
                                ReadersDB.update(ID, RD);
                                break;
                            case mode.del:
                                ReadersDB.delete(ID);
                                break;
                        }
                        break;
                    case 4:
                        DBInteractionLibrarian LibrariansDB = new DBInteractionLibrarian();
                        Librarian LB = new Librarian();
                        switch (mode)
                        {
                            case mode.add:
                                LB = LB.convertStrArrToObj(obj, true);
                                LibrariansDB.add(LB);
                                break;
                            case mode.upd:
                                LB = LB.convertStrArrToObj(obj, true);
                                LibrariansDB.update(ID, LB);
                                break;
                            case mode.del:
                                LibrariansDB.delete(ID);
                                break;
                        }
                        break;
                    case 5:
                        DBInteractionGenre GenresDB = new DBInteractionGenre();
                        Genre GN = new Genre();
                        switch (mode)
                        {
                            case mode.add:
                                obj[0] = "-1";
                                GN = GN.convertStrArrToObj(obj, true);
                                GenresDB.add(GN);
                                break;
                            case mode.upd:
                                GN = GN.convertStrArrToObj(obj, true);
                                GenresDB.update(ID, GN);
                                break;
                            case mode.del:
                                GenresDB.delete(ID);
                                break;
                        }
                        break;
                    case 6:
                        DBInteractionEdition EditionsDB = new DBInteractionEdition();
                        Edition ED = new Edition();
                        switch (mode)
                        {
                            case mode.add:
                                obj[0] = "-1";
                                ED = ED.convertStrArrToObj(obj, true);
                                EditionsDB.add(ED);
                                break;
                            case mode.upd:
                                ED = ED.convertStrArrToObj(obj, true);
                                EditionsDB.update(ID, ED);
                                break;
                            case mode.del:
                                EditionsDB.delete(ID);
                                break;
                        }
                        break;
                    case 7:
                        DBInteractionRating RatingsDB = new DBInteractionRating();
                        Rating RT = new Rating();
                        switch (mode)
                        {
                            case mode.add:
                                obj[0] = "-1";
                                RT = RT.convertStrArrToObj(obj, true);
                                RatingsDB.add(RT);
                                break;
                            case mode.upd:
                                RT = RT.convertStrArrToObj(obj, true);
                                RatingsDB.update(ID, RT);
                                break;
                            case mode.del:
                                RatingsDB.delete(ID);
                                break;
                        }
                        break;
                    case 8:
                        DBIntegrationStorage StorageDB = new DBIntegrationStorage();
                        Storage ST = new Storage();
                        switch (mode)
                        {
                            case mode.add:
                                obj[0] = "-1";
                                ST = ST.convertStrArrToObj(obj, true);
                                StorageDB.add(ST);
                                break;
                            case mode.upd:
                                ST = ST.convertStrArrToObj(obj, true);
                                StorageDB.update(ID, ST);
                                break;
                            case mode.del:
                                StorageDB.delete(ID);
                                break;
                        }
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Возникла ошибка интерпретации данных\nПроверьте введённые данные", "Ошибка приложения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //я знаю, что это зло, но это необходимое зло, когда 2 часа тратишь, чтобы сделать уведомления
            }
            MessageBox.Show("Соответствующий запрос успешно обработан", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
