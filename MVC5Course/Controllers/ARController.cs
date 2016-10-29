using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialViewTest()
        {
            return PartialView();
        }

        public ActionResult FileTest()
        {
            //C:\Users\USER\Desktop\MVC5Course\MVC5Course\Content\GodDameCat.jpg
            var filepath = Server.MapPath("~/Content/GodDameCat.jpg");
            return File(filepath,"image/jpeg");
        }


        public ActionResult FileTest2()
        {
            //C:\Users\USER\Desktop\MVC5Course\MVC5Course\Content\GodDameCat.jpg
            var filepath = Server.MapPath("~/Content/GodDameCat.jpg");
            return File(filepath, "image/jpeg","GodDameCat.jpg");
        }

        public ActionResult JSonTest()
        {
            ProductRepository repo = RepositoryHelper.GetProductRepository();
           
            // db.Configuration.LazyLoadingEnabled = false; 設定不延遲載入
            repo.UnitOfWork.LazyLoadingEnabled = false;
            var data =repo.All().Take(50);
           
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}