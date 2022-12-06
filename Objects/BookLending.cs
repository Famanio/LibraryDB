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
        public int librarianID { get; set; }
        public int readerID { get; set; }
        public string dateOfIssue { get; set; }
        public string returnDate { get; set; }
    }
}
