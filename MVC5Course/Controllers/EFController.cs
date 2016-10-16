using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index()
        {
            //var db = new FabricsEntities();
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            return View(data);
        }

        public ActionResult Create()
        {
            var Product = new Product
            {
                ProductName = "White DK",
                Price = 500,
                Stock = 1210,
                Active = true
            };
            db.Product.Add(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) 
        {
            var product = db.Product.Find(id);
            db.OrderLine.RemoveRange(product.OrderLine);
            db.Product.Remove(product);
           // product.IdDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = db.Product.Find(id);
            return View(product);
        }
        //預設Details,少加s會產生畫面無法顯示,必須改template?
        public ActionResult Details(int id)
        {
            var productDetail = db.Product.Find(id);
            return View(productDetail);
        }
        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);
            product.ProductName += "!";
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityError in ex.EntityValidationErrors)
                {
                    foreach (var vError in entityError.ValidationErrors)
                    {
                        throw new DbEntityValidationException(vError.PropertyName + " 發生錯誤:" + vError.ErrorMessage);
                    }
                }
              //throw;
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult Update20percent()
        {
            var product = db.Product.Where(p => p.ProductName.Contains("White"));
            foreach (var item in product)
            {
                if (item.Price.HasValue)
                {
                    item.Price = item.Price.Value * 1.2m;
                }
                
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}