using System;
using System.Linq;

//This is a template - this grabs the Book database so we can use it

namespace Bookstore.Models
{
    public interface IBooksRepository
    {
        public IQueryable<Book> Books { get; }

        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}

