using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Infastructure;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//this for the cart Razor Page

namespace Bookstore.Pages
{
    public class CartModel : PageModel
    {
        private IBooksRepository repo { get; set; }

        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }

        public CartModel (IBooksRepository temp, Basket b)
        {
            basket = b;
            repo = temp;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            //basket = HttpContext.Session.GetJson<Basket>("basket")?? new Basket();
        }

        //What does this do?
        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(b, 1);

            //HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
