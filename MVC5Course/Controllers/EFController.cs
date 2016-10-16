using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
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
            string str = "%White%";
            db.Database.ExecuteSqlCommand("UPDATE dbo.Product SET Price = Price*1.2 WHERE ProductName LIKE @p0",str);
            //var product = db.Product.Where(p => p.ProductName.Contains("White"));
            //foreach (var item in product)
            //{
            //    if (item.Price.HasValue)
            //    {
            //        item.Price = item.Price.Value * 1.2m;
            //    }
                
            //}
            //db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ClientContribution()
        {
            //ViewModal方式顯示ClientContribution資料,新增View不需要選擇"資料內容類別"，不隸屬任何資料庫
            var data = db.vw_ClientContribution.Take(10);
            return View(data);
        }
        //執行原始查詢 (無回傳型別 ) (DDL/DML))
        /*
        public ActionResult ClientContribution2(string keyword = "Mary")
        {
            var data = db.Database.SqlQuery<vw_ClientContribution>(@"
        SELECT
   c.ClientId,
   c.FirstName,
   c.LastName, 
         (SELECT  SUM(o.OrderTotal) From [dbo].[Order] o WHERE o.ClientId = c.ClientId) as OrderTotal

              FROM 
                     [dbo].[Client] as c 
                 WHERE
                        c.FirstName LIKE @p0", "%" + keyword + "%");
            return View(data);
        }
*/

        // 建立原始查詢(帶有回傳型別 ) (SELECT/SP)) 
        public ActionResult ClientContribution2(string keyword = "Mary")
        {

            var data = db.Database.SqlQuery<ClientContributionViewModel>(@"
        SELECT
			c.ClientId,
			c.FirstName,
			c.LastName, 
	        (SELECT  SUM(o.OrderTotal) From [dbo].[Order] o WHERE o.ClientId = c.ClientId) as OrderTotal

	    FROM 
	           [dbo].[Client] as c 
        WHERE
               c.FirstName LIKE @p0", "%" + keyword + "%");
            return View(data);
        }
        public ActionResult ClientContribution3(string keyword="Mary")
        {
            //回傳型別:ObjectResult    Stored Procedure: 新增View不需要選擇"資料內容類別",EF預設不支援,所以將其視為ViewModel
            var data = db.usp_GetClientContribution(keyword);
            return View(data);
        }


    }
}