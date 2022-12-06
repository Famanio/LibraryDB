using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Edition : IDBObject
    {
        public int ID { get; set; }
        public string editionType { get; set; }
    }
}
