using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Genre : IDBObject<Genre>
    {
        public int ID { get; set; }
        public string genreName { get; set; }


        public string[] convertToStrArr()
        {
            string[] arr = {ID.ToString(), genreName};
            return arr;
        }

        public Genre convertStrArrToObj(string[] obj, bool convert)
        {
            try
            {
                Genre GN = new Genre();
                GN.ID = Convert.ToInt32(obj[0]);
                GN.genreName = obj[1];
                return GN;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
