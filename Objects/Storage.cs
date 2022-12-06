using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Storage : IDBObject
    {
        public int ID { get; set; }
        public string storageRack { get; set; }
        public string storageRow { get; set; }
        public string storageShelf { get; set; }
        public string storageStock { get; set; }
    }
}
