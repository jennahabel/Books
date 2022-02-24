using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Bookstore.Controllers
{
    public class HomeController : Controller
    {
        //now uses the repo to make testing easier
        private IBooksRepository repo;

        public HomeController(IBooksRepository temp)
        {
            repo = temp;
        }

        //if nothing else comes in set pageNum to 1
        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var variable = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == category || category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (category == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum

                }
            };


            return View(variable);
        }
    }
}
