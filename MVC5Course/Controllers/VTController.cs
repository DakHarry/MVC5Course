﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class VTController : Controller
    {
        // GET: VT
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewIndex()
        {
            return View();
        }

        public ActionResult Clalendar()
        {
            return View();
        }
        public ActionResult Messages()
        {
            return View();
        }
        public ActionResult Tasks()
        {
            return View();
        }
        public ActionResult UIFeatures()
        {
            return View();
        }
    }
}