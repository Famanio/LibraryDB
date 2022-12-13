using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryDB.Objects
{
    internal class Books : IDBObject<Books>
    {
        public int ID { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public string edition { get; set; }
        public string rating { get; set; }
        public string storage { get; set; }
        public string ISBN { get; set; }
        public string publisher { get; set; }
        public string pubDate { get; set; }
        public int numOfPages { get; set; }
        public float cost { get; set; }
        public int amount { get; set; }

        Regex euroDate = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](15|20)[0-9]{2}$");
        Regex onlyYear = new Regex(@"^(15|20)[0-9]{2}$");

        public string[] convertToStrArr()
        {
            string[] arr = { ID.ToString(), bookName, author, genre, edition, rating, storage, ISBN, publisher, pubDate, numOfPages.ToString(), cost.ToString(), amount.ToString() };
            return arr;
        }

        public Books convertStrArrToObj(string[] obj, bool convert)
        {
            try
            {
                Books BK = new Books();
                BK.ID = Convert.ToInt32(obj[0]);
                BK.bookName = obj[1];
                BK.author = obj[2];
                BK.genre = obj[3];
                BK.edition = obj[4];
                BK.rating = obj[5];
                BK.storage = obj[6];
                BK.ISBN = obj[7];
                BK.publisher = obj[8];
                if (euroDate.IsMatch(obj[9]))
                {
                    if (convert == false)
                    {
                        DateTime.TryParse(obj[9], out DateTime date);
                        BK.pubDate = date.ToString("dd.MM.yyyy");
                    }
                    else
                    {
                        DateTime.TryParse(obj[9], out DateTime date);
                        BK.pubDate = date.ToString("yyyy-MM-dd");
                    }
                }
                else if (onlyYear.IsMatch(obj[9]))
                {
                    string compileDate = obj[9] + "-01-01";

                    if (convert == false)
                    {
                        DateTime.TryParse(compileDate, out DateTime date);
                        BK.pubDate = date.ToString("dd.MM.yyyy");
                    }
                    else
                    {
                        DateTime.TryParse(compileDate, out DateTime date);
                        BK.pubDate = date.ToString("yyyy-MM-dd");
                    }
                }
                BK.numOfPages = Convert.ToInt32(obj[10]);
                BK.cost = (float)Convert.ToDouble(obj[11]);
                BK.amount = Convert.ToInt32(obj[12]);
                return BK;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
