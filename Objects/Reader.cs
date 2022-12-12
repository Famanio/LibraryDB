using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class Reader : IHuman, IDBObject<Reader>
    {
        public int ID { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string dateOfBirth { get; set; }
        public string homeAddress { get; set; }
        public string phoneNumber { get; set; }
        public string regDate { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = { ID.ToString(), surname, name, patronymic, dateOfBirth, homeAddress, phoneNumber, regDate };
            return arr;
        }

        public Reader convertStrArrToObj(string[] obj, bool convert)
        {
            try
            {
                Reader RD = new Reader();
                RD.ID = Int32.Parse(obj[0]);
                RD.surname = obj[1];
                RD.name = obj[2];
                RD.patronymic = obj[3];
                RD.homeAddress = obj[5];
                RD.phoneNumber = obj[6];

                if (convert == false)
                {
                    if (DateTime.TryParse(obj[4], out DateTime date4) && DateTime.TryParse(obj[7], out DateTime date7))
                    {
                        RD.dateOfBirth = date4.ToString("dd.MM.yyyy");
                        RD.regDate = date7.ToString("dd.MM.yyyy");
                    }
                }
                else
                {
                    if (DateTime.TryParse(obj[4], out DateTime date4) && DateTime.TryParse(obj[7], out DateTime date7))
                    {
                        RD.dateOfBirth = date4.ToString("yyyy-MM-dd");
                        RD.regDate = date7.ToString("yyyy-MM-dd");
                    }
                }
                return RD;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
