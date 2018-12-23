using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    public class BookShopsController : Controller
    {
        private BookstoreContext db = new BookstoreContext();

        // GET: BookShops
        public ActionResult Index()
        {
            return View(db.BookShops.ToList());
        }

        // GET: BookShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookShop bookShop = db.BookShops.Find(id);
            if (bookShop == null)
            {
                return HttpNotFound();
            }
            return View(bookShop);
        }

        // GET: BookShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address")] BookShop bookShop)
        {
            if (ModelState.IsValid)
            {
                db.BookShops.Add(bookShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookShop);
        }

        // GET: BookShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookShop bookShop = db.BookShops.Find(id);
            if (bookShop == null)
            {
                return HttpNotFound();
            }
            return View(bookShop);
        }

        // POST: BookShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address")] BookShop bookShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookShop);
        }

        // GET: BookShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookShop bookShop = db.BookShops.Find(id);
            if (bookShop == null)
            {
                return HttpNotFound();
            }
            return View(bookShop);
        }

        // POST: BookShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookShop bookShop = db.BookShops.Find(id);
            db.BookShops.Remove(bookShop);
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
