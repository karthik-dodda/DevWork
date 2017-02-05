using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingWebApp.Services
{
    public static class LocateService
    {
        public static IProductServices _Service { get; set; }

        public static IProductServices GetService()
        {
            if (_Service == null)
                _Service = new ProductServices();

            return _Service;
        }
    }
}