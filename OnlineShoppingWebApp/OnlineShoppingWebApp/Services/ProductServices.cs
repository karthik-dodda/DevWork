using System.Data;
using System.Data.Entity;
using OnlineShoppingWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingWebApp.Models;

namespace OnlineShoppingWebApp.Services
{
    public class ProductServices : IProductServices
    {
        private ShoppingContext db = new ShoppingContext();
        
        public IQueryable<Product> GetProducts()
        {
            return db.Products.OrderBy(x => x.Id);
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

    }
}