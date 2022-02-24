using System;
using System.Collections.Generic;
using System.Linq;

//this creates the basket that totals up the prices and books

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem(Book books, int qty)
        {
            BasketLineItem Line = Items
                .Where(b => b.Book.BookId == books.BookId)
                .FirstOrDefault();

            if(Line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = books,
                    Quantity = qty
                });
            }
            else
            {
                Line.Quantity += qty;
            }
        }

        //This will calculate the total
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

  

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
