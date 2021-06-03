using MyLibrary.Access;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class BookService
    {
        BookAccess bookAccess;

        public BookService()
        {
            bookAccess = new BookAccess();
        }

        public List<Book> GetList()
        {
            return bookAccess.GetList();
        }

        public Book Get(int id)
        {
            //usp_Book_Get
            //usp_Book_Get_Category
            return bookAccess.Get(id);
        }

        public bool Create(Book book)
        {
            // validation
            List<Book> books = bookAccess.GetList();
            int exists = books.FindIndex(x => x.Title == book.Title && x.PublishedYear == book.PublishedYear);
            if (exists != -1) throw new ObjectCreationException();
            return bookAccess.Create(book);
        }

        public bool Update(int id,Book book)
        {
            return bookAccess.Update(id, book);
        }

        public bool Delete(int id)
        {
            return bookAccess.Delete(id);
        }
    }
}
