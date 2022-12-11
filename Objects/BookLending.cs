using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class BookLending : IDBObject
    {
        public int ID { get; set; }
        public string librarian { get; set; }
        public string reader { get; set; }
        public string book { get; set; }
        public DateTime dateOfIssue { get; set; }
        public DateTime returnDate { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = { ID.ToString(), librarian, reader, book, dateOfIssue.ToString(), returnDate.ToString() };
            return arr;
        }
    }
}
