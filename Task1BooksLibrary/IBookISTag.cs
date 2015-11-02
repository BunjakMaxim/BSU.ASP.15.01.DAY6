using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1BooksLibrary
{
    public interface IBookISTag
    {
        bool IsTag(Book b, string tag);
    }
}
