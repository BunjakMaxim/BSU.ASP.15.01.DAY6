using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1BooksLibrary;

namespace Task1BooksLibraryTest
{
    class TagGanre : IBookISTag
    {
        public bool IsTag(Book b, string tag)
        {
            return b.Genre == tag;
        }
    }
}
