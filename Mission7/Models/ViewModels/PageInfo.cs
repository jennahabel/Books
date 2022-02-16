using System;
namespace Bookstore.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Figure out how many pages we need - allows the division to happen and then converts it back to a rounded int
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);

    }
}
