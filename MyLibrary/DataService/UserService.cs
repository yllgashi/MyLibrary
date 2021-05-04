using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.DataService
{
    public class UserService
    {
        UserAccess userAccess;

        public UserService()
        {
            userAccess = new UserAccess();
        }

        public List<User> GetAll()
        {
            return userAccess.GetAll();
        }

        public User Get(string id)
        {
            return userAccess.Get(id);
        }

        public bool Create(User book)
        {
            return userAccess.Create(book);
        }

        public bool Update(string id, User book)
        {
            return userAccess.Update(id, book);
        }

        public bool Delete(string id)
        {
            return userAccess.Delete(id);
        }
    }
}
