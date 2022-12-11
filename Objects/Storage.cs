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
        public string storageLocation { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = {ID.ToString(), storageLocation};
            return arr;
        }
    }
}
