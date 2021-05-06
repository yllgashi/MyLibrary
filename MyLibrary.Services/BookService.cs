using MyLibrary.Models;
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

        public List<Book> GetAll()
        {
            return bookAccess.GetAll();
        }

        public Book Get (string id)
        {
            return bookAccess.Get(id);
        }

        public bool Create (Book book)
        {
            return bookAccess.Create(book);
        }

        public bool Update(string id,Book book)
        {
            return bookAccess.Update(id, book);
        }

        public bool Delete(string id)
        {
            return bookAccess.Delete(id);
        }
    }
}
