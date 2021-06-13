using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Models.Exceptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException()
    : base("Authorization has failed!") { }

        public AuthorizationException(string message)
            : base(message) { }

        public AuthorizationException(string message, Exception inner)
            : base(message, inner) { }
    }
}
