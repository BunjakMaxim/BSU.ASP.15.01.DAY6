﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1BooksLibrary;

namespace Task1BooksLibraryTest
{
    class ComparableBook : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (String.Compare(x.Author, y.Author) == 0)
                return (String.Compare(x.Title, y.Title));

            return String.Compare(x.Author, y.Author);
        }
    }
}
