using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Noliktava2.Models;

namespace Noliktava2.Controllers
{
    public class SalesController : Controller
    {
        private NoliktavaDataContext db = new NoliktavaDataContext();

        //
        // GET: /Sales/

        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Client);
            return View(sales.ToList());
        }

        //
        // GET: /Sales/Details/5

        public ActionResult Details(int id = 0)
        {
            SalesModel salesmodel = db.Sales.Find(id);
            if (salesmodel == null)
            {
                return HttpNotFound();
            }
            return View(salesmodel);
        }

        //
        // GET: /Sales/Create

        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "TelephoneNumber");
            return View();
        }

        //
        // POST: /Sales/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesModel salesmodel)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(salesmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "TelephoneNumber", salesmodel.ClientId);
            return View(salesmodel);
        }

        //
        // GET: /Sales/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SalesModel salesmodel = db.Sales.Find(id);
            if (salesmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "TelephoneNumber", salesmodel.ClientId);
            return View(salesmodel);
        }

        //
        // POST: /Sales/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesModel salesmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "TelephoneNumber", salesmodel.ClientId);
            return View(salesmodel);
        }

        //
        // GET: /Sales/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SalesModel salesmodel = db.Sales.Find(id);
            if (salesmodel == null)
            {
                return HttpNotFound();
            }
            return View(salesmodel);
        }

        //
        // POST: /Sales/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesModel salesmodel = db.Sales.Find(id);
            db.Sales.Remove(salesmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}