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
    public class DarbiniekiController : Controller
    {
        private NoliktavaDataContext db = new NoliktavaDataContext();

        //
        // GET: /Darbinieki/

        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Position);
            return View(employees.ToList());
        }

        //
        // GET: /Darbinieki/Details/5

        public ActionResult Details(int id = 0)
        {
            EmployeeModel employeemodel = db.Employees.Find(id);
            if (employeemodel == null)
            {
                return HttpNotFound();
            }
            return View(employeemodel);
        }

        //
        // GET: /Darbinieki/Create
        [Authorize(Roles = "VAD")]
        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Code");
            return View();
        }

        //
        // POST: /Darbinieki/Create

        [HttpPost]
        [Authorize(Roles="VAD")]
        public ActionResult Create(EmployeeModel employeemodel)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employeemodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Code", employeemodel.PositionId);
            return View(employeemodel);
        }

        //
        // GET: /Darbinieki/Edit/5
        [Authorize(Roles = "VAD")]
        public ActionResult Edit(int id = 0)
        {
            EmployeeModel employeemodel = db.Employees.Find(id);
            if (employeemodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Code", employeemodel.PositionId);
            return View(employeemodel);
        }

        //
        // POST: /Darbinieki/Edit/5

        [HttpPost]
        [Authorize(Roles = "VAD")]
        public ActionResult Edit(EmployeeModel employeemodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeemodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Code", employeemodel.PositionId);
            return View(employeemodel);
        }

        //
        // GET: /Darbinieki/Delete/5
        [Authorize(Roles = "VAD")]
        public ActionResult Delete(int id = 0)
        {
            EmployeeModel employeemodel = db.Employees.Find(id);
            if (employeemodel == null)
            {
                return HttpNotFound();
            }
            return View(employeemodel);
        }

        //
        // POST: /Darbinieki/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "VAD")]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeModel employeemodel = db.Employees.Find(id);
            db.Employees.Remove(employeemodel);
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