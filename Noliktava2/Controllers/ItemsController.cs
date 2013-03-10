using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Noliktava2.Models;
using System.Threading;
using System.Globalization;

namespace Noliktava2.Controllers
{
    public class ItemsController : Controller
    {
        public ItemsController()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        private NoliktavaDataContext db = new NoliktavaDataContext();

        //
        // GET: /Items/

        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        //
        // GET: /Items/Details/5

        public ActionResult Details(int id = 0)
        {
            ItemModel itemmodel = db.Items.Find(id);
            if (itemmodel == null)
            {
                return HttpNotFound();
            }
            return View(itemmodel);
        }

        //
        // GET: /Items/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Items/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemModel itemmodel)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(itemmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemmodel);
        }

        //
        // GET: /Items/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ItemModel itemmodel = db.Items.Find(id);
            if (itemmodel == null)
            {
                return HttpNotFound();
            }
            return View(itemmodel);
        }

        //
        // POST: /Items/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemModel itemmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemmodel);
        }

        //
        // GET: /Items/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ItemModel itemmodel = db.Items.Find(id);
            if (itemmodel == null)
            {
                return HttpNotFound();
            }
            return View(itemmodel);
        }

        //
        // POST: /Items/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemModel itemmodel = db.Items.Find(id);
            db.Items.Remove(itemmodel);
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