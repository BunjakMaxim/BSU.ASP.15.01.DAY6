using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Task1BooksLibrary;
using System.IO;
using NLog;

namespace Task1BooksLibraryTest
{
    class Program
    {
        public static Logger log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            string path = @"BooksList.dat";

            try
            {
                BookListService books = new BookListService(path);
                ShowBooksList(books, "Спосок книг");
                
             /*
                     // Пример списка книг для работы 
              
                books.Add(new Book() { Author = "Лев Толстой", Title = "Война и мир", Genre = "Роман", Year = 1869 });
                books.Add(new Book() { Author = "Алан Александр Милн",Title ="Вини-Пух", Genre = "Детский рассказ", Year = 1926});
                books.Add(new Book() { Author = "Мари Шелли", Title="Франкенштейн", Genre = "Научная фантастика", Year = 1818}); 
                books.Add(new Book() { Author = "Михаил Булгаков", Title ="Мастер и Маргарита", Genre="Роман", Year = 1966});
                books.Add(new Book() { Author = "Федор Достоевский", Title = "Преступление и наказание" , Genre = "Роман" , Year = 1866});
                books.Add(new Book() { Author = "Николай Гоголь", Title = "Мёртвые души", Genre = "Сатира", Year = 1842 });
                books.Add(new Book() { Author = "Александр Пушкин", Title = "Евгений Онегин", Genre = "Роман", Year = 1825 });

                books.WriteBooksList();
              */
                
                books.SortBooksByTag(new ComparableBook());
                ShowBooksList(books, "Отсортированный список");

                books.Add(new Book() { Author = "Николай Гоголь", Title = "Вечера на хуторе близ Диканьки", Year = 1832, Genre = "Проза" });
                ShowBooksList(books, "Список книг с добавленной книгой");
                
                books.RemoveBook(new Book() { Author = "Николай Гоголь", Title = "Вечера на хуторе близ Диканьки", Year = 1832, Genre = "Проза" });
                ShowBooksList(books, "Список книг с удаленной книгой");

                Console.WriteLine("Спосок книг выбранны по тегу \"Жанр = Роман\"");
                foreach (Book b in books.FindByTag(new TagGanre(), "Роман"))
                    Console.WriteLine(b);
            }
            catch (FileNotFoundException ex)
            {
                log.Fatal(ex.Message, ex);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private static void ShowBooksList(BookListService books, string massege)
        {
            Console.WriteLine(massege);
            foreach (Book b in books)
                Console.WriteLine(b);

            Console.WriteLine();
        }
    }
}
