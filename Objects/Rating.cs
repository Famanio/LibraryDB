using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Rating : IDBObject<Rating>
    {
        public int ID { get; set; }
        public string ageRating { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = {ID.ToString(), ageRating};
            return arr;
        }

        public Rating convertStrArrToObj(string[] obj, bool convert)
        {
            try
            {
                Rating RT = new Rating();
                RT.ID = Convert.ToInt32(obj[0]);
                RT.ageRating = obj[1];
                return RT;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
