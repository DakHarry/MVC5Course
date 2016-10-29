using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    //宣告抽象類別，繼承才能使用
    public abstract class BaseController : Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
          //  base.HandleUnknownAction(actionName);
            this.RedirectToAction("Index").ExecuteResult(this.ControllerContext);
        }

    }
}