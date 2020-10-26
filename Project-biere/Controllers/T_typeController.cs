using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_biere.Models;

namespace Project_biere.Controllers
{
    public class T_typeController : Controller
    {
        private Entities db = new Entities();

        // GET: T_typeC:\Users\QUERSIN Laurent\Desktop\Cours\Project-biere\Project-biere\Controllers\T_typeController.cs
        public ActionResult Index()
        {
            return View(db.T_type.ToList());
        }

        // GET: T_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_type t_type = db.T_type.Find(id);
            if (t_type == null)
            {
                return HttpNotFound();
            }
            return View(t_type);
        }

        // GET: T_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_type/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeBiere,Malt")] T_type t_type)
        {
            if (ModelState.IsValid)
            {
                db.T_type.Add(t_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_type);
        }

        // GET: T_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_type t_type = db.T_type.Find(id);
            if (t_type == null)
            {
                return HttpNotFound();
            }
            return View(t_type);
        }

        // POST: T_type/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeBiere,Malt")] T_type t_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_type);
        }

        // GET: T_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_type t_type = db.T_type.Find(id);
            if (t_type == null)
            {
                return HttpNotFound();
            }
            return View(t_type);
        }

        // POST: T_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_type t_type = db.T_type.Find(id);
            db.T_type.Remove(t_type);
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
