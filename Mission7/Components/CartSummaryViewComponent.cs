using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
namespace SportsStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket cart { get; set; }

        public CartSummaryViewComponent(Basket temp)
        {
            cart = temp;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
