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
    public class T_biereController : Controller
    {
        private Entities db = new Entities();

        // GET: T_biere
        public ActionResult Index()
        {
            var t_biere = db.T_biere.Include(t => t.T_type);
            return View(t_biere.ToList());
        }

        // GET: T_biere/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_biere t_biere = db.T_biere.Find(id);
            if (t_biere == null)
            {
                return HttpNotFound();
            }
            return View(t_biere);
        }

        // GET: T_biere/Create
        public ActionResult Create()
        {
            ViewBag.Id_type = new SelectList(db.T_type, "Id", "TypeBiere");
            ViewBag.Id_Alcool = new SelectList(db.T_Alcool, "Id", "Alcool");
            return View();
        }

        // POST: T_biere/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Id_type")] T_biere t_biere)
        {
            if (ModelState.IsValid)
            {
                db.T_biere.Add(t_biere);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_type = new SelectList(db.T_type, "Id", "TypeBiere", t_biere.Id_type);
            return View(t_biere);
        }

        // GET: T_biere/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_biere t_biere = db.T_biere.Find(id);
            if (t_biere == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_type = new SelectList(db.T_type, "Id", "TypeBiere", t_biere.Id_type);
            return View(t_biere);
        }

        // POST: T_biere/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Id_type")] T_biere t_biere)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_biere).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_type = new SelectList(db.T_type, "Id", "TypeBiere", t_biere.Id_type);
            return View(t_biere);
        }

        // GET: T_biere/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_biere t_biere = db.T_biere.Find(id);
            if (t_biere == null)
            {
                return HttpNotFound();
            }
            return View(t_biere);
        }

        // POST: T_biere/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_biere t_biere = db.T_biere.Find(id);
            db.T_biere.Remove(t_biere);
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
