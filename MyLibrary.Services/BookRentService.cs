using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class BookRentService
    {
        BookRentAccess bookRentaccess;

        public BookRentService()
        {
            bookRentaccess = new BookRentAccess();
        }

        public List<BookRent> GetList()
        {
            return bookRentaccess.GetAll();
        }

        public BookRent Get(int id)
        {
            return bookRentaccess.Get(id);
        }

        public bool Create(BookRent bookRent)
        {
            return bookRentaccess.Create(bookRent);
        }

        public bool Update(int id , BookRent bookRent)
        {
            return bookRentaccess.Update(id, bookRent);
        }

        public bool Delete(int id)
        {
            return bookRentaccess.Delete(id);
        }
    }
}
