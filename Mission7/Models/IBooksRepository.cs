using System;
using System.Linq;

//This is a template - this grabs the Book database so we can use it

namespace Bookstore.Models
{
    public interface IBooksRepository
    {
        public IQueryable<Book> Books { get; }
    }
}

