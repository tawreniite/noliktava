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
    public class VendorController : Controller
    {
        private NoliktavaDataContext db = new NoliktavaDataContext();

        //
        // GET: /Vendor/

        public ActionResult Index()
        {
            var vendors = db.Vendors.Include(v => v.Responsible);
            return View(vendors.ToList());
        }

        //
        // GET: /Vendor/Details/5

        public ActionResult Details(int id = 0)
        {
            VendorModel vendormodel = db.Vendors.Find(id);
            if (vendormodel == null)
            {
                return HttpNotFound();
            }
            return View(vendormodel);
        }

        //
        // GET: /Vendor/Create

        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "UserName");
            return View();
        }

        //
        // POST: /Vendor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendorModel vendormodel)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendormodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "UserName", vendormodel.EmployeeId);
            return View(vendormodel);
        }

        //
        // GET: /Vendor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VendorModel vendormodel = db.Vendors.Find(id);
            if (vendormodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "UserName", vendormodel.EmployeeId);
            return View(vendormodel);
        }

        //
        // POST: /Vendor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VendorModel vendormodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendormodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "UserName", vendormodel.EmployeeId);
            return View(vendormodel);
        }

        //
        // GET: /Vendor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VendorModel vendormodel = db.Vendors.Find(id);
            if (vendormodel == null)
            {
                return HttpNotFound();
            }
            return View(vendormodel);
        }

        //
        // POST: /Vendor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendorModel vendormodel = db.Vendors.Find(id);
            db.Vendors.Remove(vendormodel);
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