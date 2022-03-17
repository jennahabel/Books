using System;
using System.Linq;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

// own model - doesnt need to have the same naming convention of homecontroller

namespace Bookstore.Components
{
    public class TypesViewComponent: ViewComponent
    {
        private IBooksRepository repo { get; set; }

        public TypesViewComponent (IBooksRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values[ "category" ];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
