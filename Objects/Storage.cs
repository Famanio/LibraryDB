using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Storage : IDBObject<Storage>
    {
        public int ID { get; set; }
        public string storageLocation { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = {ID.ToString(), storageLocation};
            return arr;
        }

        public Storage convertStrArrToObj(string[] obj, bool convert)
        {
            Storage ST = new Storage();
            ST.ID = Convert.ToInt32(obj[0]);
            ST.storageLocation = obj[1];
            return ST;
        }
    }
}
