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
        // GET: MB
        public ActionResult Index()
        {
            ViewData["ViewDataTemp1"] = "暫存資料 ViewDataTemp1 以Object 弱型別Model Binding";
            var b = new ClientLoginViewModel()
            {
                FirstName = "Harry",
                LastName = "Chan",
                Gender="Man",
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
    }
}