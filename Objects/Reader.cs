using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Reader : IHuman, IDBObject
    {
        public int ID { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string dateOfBirth { get; set; }
        public string homeAddress { get; set; }
        public string phoneNumber { get; set; }
        public string regDate { get; set; }
    }
}
