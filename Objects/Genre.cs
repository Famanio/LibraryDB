using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Genre : IDBObject
    {
        public int ID { get; set; }
        public string genreName { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = {ID.ToString(), genreName};
            return arr;
        }
    }
}
