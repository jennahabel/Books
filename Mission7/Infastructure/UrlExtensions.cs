using System;
using Microsoft.AspNetCore.Http;

//This page helps us go back to the same url that we were on before we added to our cart

namespace Bookstore.Infastructure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
              request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
