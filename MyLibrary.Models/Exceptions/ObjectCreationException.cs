using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Models.Exceptions
{
    public class ObjectCreationException : Exception
    {
        public ObjectCreationException()
            : base("Object already exists!") { }

        public ObjectCreationException(string message)
            : base(message) { }

        public ObjectCreationException(string message, Exception inner)
            : base(message, inner) { }
    }
}
