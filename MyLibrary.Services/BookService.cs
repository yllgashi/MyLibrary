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

        public List<Book> GetList()
        {
            return bookAccess.GetAll();
        }

        public Book Get(int id)
        {
            //usp_Book_Get
            //usp_Book_Get_Category
            return bookAccess.Get(id);
        }

        public bool Create(Book book)
        {
            // usp_Book_Create
            //usp_Category_Add_Book_Category
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
