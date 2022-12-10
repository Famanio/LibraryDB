using LibraryDB.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryDB.DB
{
    abstract class DBInteraction<T> where T : IDBObject //все, ко осуществляет интерфейс IDBObject
    {
        public static string connString = "server=localhost;port=3306;username=root;password=root;database=Library";

        public abstract DataTable getAll();
        public abstract T getRow(int ID);
        public abstract DataTable search (string query);
        public abstract void add (T item);
        public abstract void update (int currentID, T item);
        public abstract void delete(int ID);
    }
}
