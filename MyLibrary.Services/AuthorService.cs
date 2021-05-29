using MyLibrary.DataAccess;
using MyLibrary.Models;
using MyLibrary.Models.Exceptions;
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

        public List<Author> GetList()
        {
            return authorAccess.GetList();
        }

        public Author Get(int id)
        {
            // usp_Author_Get
            // usp_Author_Books_Get
            return authorAccess.Get(id);
        }

        public bool Create(Author author)
        {
            // validation
            List<Author> authors = authorAccess.GetList();
            int exists = authors.FindIndex(x => x.FirstName == author.FirstName && x.LastName == author.LastName);
            if (exists == -1) throw new ObjectCreationException();
            return authorAccess.Create(author);
        }

        public bool Update(int id, Author author)
        {
            return authorAccess.Update(id, author);
        }

        public bool Delete(int id)
        {
            return authorAccess.Delete(id);
        }
    }
}
