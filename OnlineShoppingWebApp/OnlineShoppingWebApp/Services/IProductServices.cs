using OnlineShoppingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingWebApp.Services
{
    public interface IProductServices
    {
        IQueryable<Product> GetProducts();
        void AddProduct(Product product);
    }
}
