using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class BookLending : IDBObject<BookLending>
    {
        public int ID { get; set; }
        public string librarian { get; set; }
        public string reader { get; set; }
        public string book { get; set; }
        public int lendAmount { get; set; }
        public string dateOfIssue { get; set; }
        public string returnDate { get; set; }

        public string[] convertToStrArr()
        {
            string[] arr = { ID.ToString(), librarian, reader, book, lendAmount.ToString(), dateOfIssue, returnDate };
            return arr;
        }

        public BookLending convertStrArrToObj(string[] obj, bool convert)
        {
            BookLending BL = new BookLending();
            BL.ID = Convert.ToInt32(obj[0]);
            BL.librarian = obj[1];
            BL.reader = obj[2];
            BL.book = obj[3];
            BL.lendAmount = Convert.ToInt32(obj[4]);
            if (convert == false)
            {
                if(DateTime.TryParse(obj[5], out DateTime date5) && DateTime.TryParse(obj[6], out DateTime date6))
                {
                    BL.dateOfIssue = date5.ToString("dd.MM.yyyy");
                    BL.returnDate = date6.ToString("dd.MM.yyyy");
                }
            }
            else
            {
                if (DateTime.TryParse(obj[5], out DateTime date5) && DateTime.TryParse(obj[6], out DateTime date6))
                {
                    BL.dateOfIssue = date5.ToString("yyyy-MM-dd");
                    BL.returnDate = date6.ToString("yyyy-MM-dd");
                }
            }
            return BL;
        }
    }
}
