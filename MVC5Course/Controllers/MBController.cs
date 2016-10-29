using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: MB
        public ActionResult Index()
        {
            ViewData["ViewDataTemp1"] = "暫存資料 ViewDataTemp1 以Object 弱型別Model Binding";
            var b = new ClientLoginViewModel()
            {
                FirstName = "Harry",
                LastName = "Chan",
                Gender="M",
                MiddleName="DK"
                   
            };
            ViewData["Temp2"] = b;
            ViewBag.Temp4 = b;
            ViewBag.Temp3 = "動態型別";
            return View();
        }

        public ActionResult MyForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyForm(ClientLoginViewModel c)
        {
           
            if (ModelState.IsValid)
            {
                TempData["MyFormResult"] = c;
                return RedirectToAction("MyFormResult");
            }
            return View();
        }

        public ActionResult MyFormResult()
        {
            return View();
        }


        public ActionResult ProductList()
        {

            var data = db.Product.Take(20).ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult BatchUpdate(ProductBatchUpdateViewModel[] items)
        {
            /*
             * item.ProductId
             * item[0].ProductId
             * 
             * */
            if (ModelState.IsValid)
            {
                foreach (var item in items)
                {
                    var product = db.Product.Find(item.ProductId);
                    product.ProductName = item.ProductName;
                    product.Active = item.Active;
                    product.Price = item.Price;
                    product.Stock = item.Stock;
                }
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }

            return View();
        }
    }
}