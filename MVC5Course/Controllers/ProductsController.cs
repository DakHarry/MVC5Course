using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: Products
        //public ActionResult Index()
        //{
        //    return View(db.Product.ToList());
        //}
          public ActionResult Index(String sortOrder, string currentFilter,String keyword,int? Page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            //if(keyword != null)
            //{
            //    Page = 1;
            //}else
            //{
            //    keyword = currentFilter;
            //}
            //ViewBag.CurrentFilter = keyword;
            var Result = from r in db.Product
                         select r;
            if (!String.IsNullOrEmpty(keyword))
            {
                Result = Result.Where(r => r.ProductName.Contains(keyword));
            }
            if (ViewBag.NameSortParm != "")
            {
                Result = Result.OrderByDescending(s => s.ProductName);
            }

            //model.getIndex(p, show_number)
            return View(Result.Take(30));
        }
        //public List<Product> Get_Page(IQueryable<Product> result,int p=1,int show_number=10)
        //{
        //    return Get_Page1(Get_Count(), p, show_number);
        //}
        //public static Paging Get_Page1(int total, int current_page = 1, int page_count = 10, int pages = 5)
        //{
        //    Paging page = new Paging();

        //    int count = pages;
        //    int count_com = Convert.ToInt32(Math.Ceiling((double)count / 2));

        //    page.First = 1;
        //    int last = Convert.ToInt32(Math.Ceiling((double)total / (double)page_count));
        //    page.Last = last <= 0 ? 1 : last;
        //    page.Total = total;
        //    page.Now = current_page;

        //    page.Back = (current_page > 1) ? current_page - 1 : current_page;
        //    page.Next = (current_page < last) ? current_page + 1 : current_page;

        //    int start = current_page - count_com;
        //    page.Start = (start < 1) ? 1 : start;

        //    int end = page.Start + count - 1;
        //    end = (end >= last) ? last : end;
        //    page.End = (end == 0) ? 1 : end;

        //    return page;
        //}
        //public class Paging
        //{
        //    public int First = 1;
        //    public int Last = 1;
        //    public int Total = 1;
        //    public int Now = 1;
        //    public int Back = 1;
        //    public int Next = 1;
        //    public int Start = 1;
        //    public int End = 1;
        //}
        //public int Get_Count()
        //{
        //    return Get().Count();
        //}
        //private IQueryable<Product> Get()
        //{             
        //    IQueryable<Product> item = db.Product;          
        //    return item;
        //}

        //public ActionResult ProductSort(string sortOrder)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    var Products = from p in db.Product
        //                   select p;
        //    if (ViewBag.NameSortParm != "")
        //    {
        //        Products = Products.OrderByDescending(s => s.ProductName);
        //    }
        //    return View(Products.ToList());
        //}

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
