using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Task1BooksLibrary
{
    public class BookListService : IList<Book>
    {
        private Book[] arrayBooks;
        private readonly string path;
        public BookListService(string path)
        {
            this.path = path;
            ReadBooksList();
        }

        public void Insert(int index, Book item)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentException("Задна недопустимый инекс");

            Add(item);
            for (int i = Count - 1; i > index; i--)
                arrayBooks[i] = arrayBooks[i - 1];
            arrayBooks[index] = item;
        }
        
        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentException();

                return arrayBooks[index];
            }
            set
            {
                Insert(index, value);
            }
        }

        public void Add(Book item)
        {
            if (IndexOf(item) != -1)
                throw new Exception("Повторное добавление книги!");

            if (arrayBooks.Length + 1 == Count)
            {
                Book[] array = new Book[Count * 2];
                Array.Copy(arrayBooks, array, Count);
                arrayBooks = array;
            }

            arrayBooks[Count++] = item;
        }

        public void RemoveBook(Book book)
        {
            int j = IndexOf(book);

            if (j < 0)
                throw new Exception("Книга для удаления не  найдена");

            RemoveAt(j);
        }

        public bool Remove(Book item)
        {
            int j = IndexOf(item);

            if (j < 0)
                return false;

            RemoveAt(j);
            return true;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                arrayBooks[i] = arrayBooks[i + 1];
            Count--;
        }

        public void Clear()
        {
            arrayBooks = new Book[10];
            Count = 0;
        }

        public int IndexOf(Book item)
        {
            for (int i = 0; i < Count; i++)
                if (arrayBooks[i].Equals(item))
                    return i;

            return -1;
        }

        public bool Contains(Book item)
        {
            if (IndexOf(item) >= 0)
                return true;

            return false;
        }

        public void CopyTo(Book[] array, int arrayIndex)
        {
            array = new Book[Count - arrayIndex];
            for (int i = arrayIndex; i < Count; i++)
                array[i - arrayIndex] = arrayBooks[i].Clone();
        }

        public int Count
        {
            get;
            private set;
        }

        public bool IsReadOnly
        {
            get{return false;}
        }
        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return arrayBooks[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Book[] FindByTag(IBookISTag bookTag, string tag)
        {
            Book[] booksIsTag = new Book[10];
            int ind = 0;
            for (int i = 0; i < Count; i++)
                if (bookTag.IsTag(arrayBooks[i], tag))
                {
                    if (ind >= booksIsTag.Length)
                    {
                        Book[] newBooksList = new Book[booksIsTag.Length * 2];
                        Array.Copy(booksIsTag, newBooksList, ind);
                        booksIsTag = newBooksList;
                    }
                    booksIsTag[ind++] = arrayBooks[i];
                }

            Book[] n = new Book[ind];
            Array.Copy(booksIsTag, n, ind);
            return n;
        }

        public void SortBooksByTag(IComparer<Book> c)
        {
            if (c == null)
                throw new ArgumentNullException();

            int end = Count - 1;
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < end; j++)
                    if (c.Compare(arrayBooks[j], arrayBooks[j + 1]) > 0)
                    {
                        Book b = arrayBooks[j];
                        arrayBooks[j] = arrayBooks[j + 1];
                        arrayBooks[j + 1] = b;
                    }
                end--;
            }
        }

        public void ReadBooksList()
        {
            Count = 0;
            arrayBooks = new Book[10];

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string autor = reader.ReadString();
                    string title = reader.ReadString();
                    int year = reader.ReadInt32();
                    string genre = reader.ReadString();

                    Add(new Book() { Author = autor, Title = title, Year = year, Genre = genre });
                }

                reader.Close();
            }
        }

        public void WriteBooksList()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Book b in this)
                {
                    writer.Write(b.Author);
                    writer.Write(b.Title);
                    writer.Write(b.Year);
                    writer.Write(b.Genre);
                }
            }
        }
    }
}
