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
    public class PurchaseController : Controller
    {
        private NoliktavaDataContext db = new NoliktavaDataContext();

        //
        // GET: /Purchase/

        public ActionResult Index()
        {
            var purchases = db.Purchases.Include(p => p.Vendor);
            return View(purchases.ToList());
        }

        //
        // GET: /Purchase/Details/5

        public ActionResult Details(int id = 0)
        {
            PurchaseModel purchasemodel = db.Purchases.Find(id);
            if (purchasemodel == null)
            {
                return HttpNotFound();
            }
            return View(purchasemodel);
        }

        //
        // GET: /Purchase/Create

        public ActionResult Create()
        {
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "TelephoneNumber");
            return View();
        }

        //
        // POST: /Purchase/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseModel purchasemodel)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchasemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "TelephoneNumber", purchasemodel.VendorId);
            return View(purchasemodel);
        }

        //
        // GET: /Purchase/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PurchaseModel purchasemodel = db.Purchases.Find(id);
            if (purchasemodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "TelephoneNumber", purchasemodel.VendorId);
            return View(purchasemodel);
        }

        //
        // POST: /Purchase/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseModel purchasemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchasemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "TelephoneNumber", purchasemodel.VendorId);
            return View(purchasemodel);
        }

        //
        // GET: /Purchase/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PurchaseModel purchasemodel = db.Purchases.Find(id);
            if (purchasemodel == null)
            {
                return HttpNotFound();
            }
            return View(purchasemodel);
        }

        //
        // POST: /Purchase/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseModel purchasemodel = db.Purchases.Find(id);
            db.Purchases.Remove(purchasemodel);
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