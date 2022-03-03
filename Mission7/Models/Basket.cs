using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

//this creates the basket that totals up the prices and books

namespace Bookstore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        //Add an item to the basket for our cart
        //Virtual allows this method to be overriden when we inherit from it
        //Template that we will inherit from for a particular session

        public virtual void AddItem(Book books, int qty)
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

        
        public virtual void RemoveItem (Book books)
        {
            Items.RemoveAll(x => x.Book.BookId == books.BookId);
        }

        public virtual void ClearBasket()
        {
            Items.Clear();
        }

        //This will calculate the total inside our cart
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

  
    public class BasketLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
