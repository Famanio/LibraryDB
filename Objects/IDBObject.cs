using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal interface IDBObject<out T>
    {
        public int ID { get; set; }
        public string[] convertToStrArr();
        public T convertStrArrToObj(string[] obj, bool convert);
    }
}
