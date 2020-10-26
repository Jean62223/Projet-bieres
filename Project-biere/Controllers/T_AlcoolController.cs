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
    public class T_AlcoolController : Controller
    {
        private Entities db = new Entities();

        // GET: T_Alcool
        public ActionResult Index()
        {
            return View(db.T_Alcool.ToList());
        }

        // GET: T_Alcool/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Alcool t_Alcool = db.T_Alcool.Find(id);
            if (t_Alcool == null)
            {
                return HttpNotFound();
            }
            return View(t_Alcool);
        }

        // GET: T_Alcool/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_Alcool/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Alcool")] T_Alcool t_Alcool)
        {
            if (ModelState.IsValid)
            {
                db.T_Alcool.Add(t_Alcool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Alcool);
        }

        // GET: T_Alcool/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Alcool t_Alcool = db.T_Alcool.Find(id);
            if (t_Alcool == null)
            {
                return HttpNotFound();
            }
            return View(t_Alcool);
        }

        // POST: T_Alcool/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Alcool")] T_Alcool t_Alcool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Alcool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Alcool);
        }

        // GET: T_Alcool/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Alcool t_Alcool = db.T_Alcool.Find(id);
            if (t_Alcool == null)
            {
                return HttpNotFound();
            }
            return View(t_Alcool);
        }

        // POST: T_Alcool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Alcool t_Alcool = db.T_Alcool.Find(id);
            db.T_Alcool.Remove(t_Alcool);
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
