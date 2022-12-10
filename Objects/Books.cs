using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Books : IDBObject
    {
        public int ID { get; set; }
        public string genre { get; set; }
        public string edition { get; set; }
        public string rating { get; set; }
        public string storage { get; set; }
        public string ISBN { get; set; }
        public string publisher { get; set; }
        public string author { get; set; }
        public string bookName { get; set; }
        public DateTime pubDate { get; set; }
        public int numOfPages { get; set; }
        public float cost { get; set; }
        public int amount { get; set; }
    }
}
