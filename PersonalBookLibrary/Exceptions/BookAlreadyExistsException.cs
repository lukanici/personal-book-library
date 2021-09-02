using System;
namespace PersonalBookLibrary.Exceptions
{
    public class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
