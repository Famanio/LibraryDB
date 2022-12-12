using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Edition : IDBObject<Edition>
    {
        public int ID { get; set; }
        public string editionType { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = { ID.ToString(), editionType };
            return arr;
        }

        public Edition convertStrArrToObj(string[] obj, bool convert)
        {
            try
            {
                Edition ED = new Edition();
                ED.ID = Convert.ToInt32(obj[0]);
                ED.editionType = obj[1];
                return ED;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
