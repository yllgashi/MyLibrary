using MyLibrary.Models;
using MyLibrary.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibrary.Models.Exceptions;

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
            return bookRentaccess.GetList();
        }

        public BookRent Get(int id)
        {
            return bookRentaccess.Get(id);
        }

        public bool Create(BookRent bookRent)
        {
            // validation
            List<BookRent> bookRents = bookRentaccess.GetList();
            int exists = bookRents.FindIndex(x => x.BookId == bookRent.BookId && 
                x.ClientId == bookRent.ClientId && x.RentDate == bookRent.RentDate);
            if (exists != -1) throw new ObjectCreationException();
            return bookRentaccess.Create(bookRent);
        }

        public bool Update(int id, BookRent bookRent)
        {
            return bookRentaccess.Update(id, bookRent);
        }

        public bool Delete(int id)
        {
            return bookRentaccess.Delete(id);
        }
    }
}
