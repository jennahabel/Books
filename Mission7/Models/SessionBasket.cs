using System;
using System.Text.Json.Serialization;
using Bookstore.Infastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            //Where do we know were to put this??
            basket.Session = session;

            return basket;
        }

        [JsonIgnore]

        public ISession Session { get; set; }

        public override void AddItem(Book books, int qty)
        {
            base.AddItem(books, qty);
            //uses this specific instance of the object
            Session.SetJson("Basket", this);

        }

        public override void RemoveItem(Book books)
        {
            base.RemoveItem(books);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }

    }

}
