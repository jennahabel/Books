using System;
using System.Linq;

//This is the implementation of the template

namespace Bookstore.Models
{
    public class EFBooksRepository : IBooksRepository
    {
        private BookstoreContext context { get; set; }

        public EFBooksRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
