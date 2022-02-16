using System;
using System.Linq;

namespace Bookstore.Models
{
    public interface IBooksRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
