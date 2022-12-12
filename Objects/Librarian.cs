using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Librarian : IHuman, IDBObject<Librarian>
    {
        public int ID { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = { ID.ToString(), surname, name, patronymic };
            return arr;
        }

        public Librarian convertStrArrToObj(string[] obj, bool convert)
        {
            Librarian LB = new Librarian();
            LB.ID = Convert.ToInt32(obj[0]);
            LB.surname = obj[1];
            LB.name = obj[2];
            LB.patronymic = obj[3];
            return LB;
        }
    }
}
