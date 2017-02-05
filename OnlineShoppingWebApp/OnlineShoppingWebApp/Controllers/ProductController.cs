using OnlineShoppingWebApp.Models;
using OnlineShoppingWebApp.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingWebApp.Controllers
{
    public class ProductController : Controller
    {
        private const int PAGE_SIZE = 3;
        private IProductServices _productServices;

        public ProductController()
        {
            _productServices = LocateService.GetService();                
        }

        // GET: Product
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                page = 1;
            }

            int pageNumber = (page ?? 1);
            return View(_productServices.GetProducts().OrderBy(s => s.Id).ToPagedList(pageNumber, PAGE_SIZE));
        }
        
        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,SKU,ImageURL")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productServices.AddProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            Product p = new Product();
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    ViewBag.ImgUrl = "../Images/" + file.FileName;
                    p.ImageURL = "../Images/" + file.FileName;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View("Create", p);
        }

        
    }
}
