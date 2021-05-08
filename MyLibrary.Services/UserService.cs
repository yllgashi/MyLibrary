using MyLibrary.Access;
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

        public List<User> GetList()
        {
            return userAccess.GetList();
        }

        public User Get(int id)
        {
            return userAccess.Get(id);
        }

        public bool Create(User book)
        {
            return userAccess.Create(book);
        }

        public bool Update(int id, User book)
        {
            return userAccess.Update(id, book);
        }

        public bool Delete(int id)
        {
            return userAccess.Delete(id);
        }
    }
}
