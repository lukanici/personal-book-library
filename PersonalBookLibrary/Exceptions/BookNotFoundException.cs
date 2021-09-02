using System;
namespace PersonalBookLibrary.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message) : base(message)
        {
        }
    }
}
