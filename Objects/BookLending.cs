﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Objects
{
    internal class BookLending : IDBObject
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
    }
}
