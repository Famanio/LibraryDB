using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal interface IHuman
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
    }
}
