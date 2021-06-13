using MyLibrary.Access;
using MyLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Repositories
{
    public static class UserRepository
    {
        public static User Get(string email, string password)
        {
            UserAccess userAccess = new UserAccess();
            User user = new User()
            {
                Email = email,
                Password = password
            };
            return userAccess.Login(user);
        }
    }
}
