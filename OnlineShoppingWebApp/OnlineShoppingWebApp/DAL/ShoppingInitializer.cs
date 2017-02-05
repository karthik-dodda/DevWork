using OnlineShoppingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingWebApp.DAL
{
    public class ShoppingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ShoppingContext>
    {
        protected override void Seed(ShoppingContext context)
        {
            var products = new List<Product>
            {
                new Product { Name = "Yellow Skirt", Description = "This is a description for the skirt.", ImageURL = "../Images/Test.jpg", SKU = "123456"},
                new Product { Name = "Blue Top", Description = "This is a description for the Top.", ImageURL = "../Images/Test.jpg", SKU = "321321"},
                new Product { Name = "Blue Tank", Description = "This is a description for the Tank.", ImageURL = "../Images/Test.jpg", SKU = null},
                new Product { Name = "Green Shirt", Description = "This is a description for the Shirt.", ImageURL = "../Images/Test.jpg", SKU = "567432"},
                new Product { Name = "Yellow Top", Description = "This is a description for the Top.", ImageURL = null, SKU = "223334"},
                new Product { Name = "Blue Jeans", Description = "This is a description for the Jeans.", ImageURL = "../Images/Test.jpg", SKU = "132212"},
                new Product { Name = "White Top", Description = "This is a description for the Top.", ImageURL = null, SKU = null},
                new Product { Name = "Green Tank", Description = "This is a description for the Tank.", ImageURL = "../Images/Test.jpg", SKU = "556567"}
            };

            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();
        }
    }
}