using MyLibrary.DataAccess;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class AuthorService
    {
        AuthorAccess authorAccess;

        // constructor
        public AuthorService()
        {
            authorAccess = new AuthorAccess();
        }

        public List<Author> GetAll()
        {
            return authorAccess.GetAll();
        }

        public Author Get(string id)
        {
            return authorAccess.Get(id);
        }

        public bool Create(Author author)
        {
            return authorAccess.Create(author);
        }

        public bool Update(string id, Author author)
        {
            return authorAccess.Update(id, author);
        }

        public bool Delete(string id)
        {
            return authorAccess.Delete(id);
        }
    }
}
