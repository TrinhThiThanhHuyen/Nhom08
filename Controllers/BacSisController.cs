using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLPKDKTN.Models;

namespace QLPKDKTN.Controllers
{
    public class BacSisController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: BacSis
        public ActionResult Index()
        {
            if(Session["idBacSi"] == null)
            {
                return RedirectToAction("Login", "Home");
            }    
            return View(db.BacSis.ToList());
        }

        // GET: BacSis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // GET: BacSis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BacSis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,HoTen,SDT")] BacSi bacSi)
        {
            if (ModelState.IsValid)
            {
                db.BacSis.Add(bacSi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bacSi);
        }

        // GET: BacSis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // POST: BacSis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,HoTen,SDT")] BacSi bacSi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bacSi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bacSi);
        }

        // GET: BacSis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSis.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            return View(bacSi);
        }

        // POST: BacSis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BacSi bacSi = db.BacSis.Find(id);
            db.BacSis.Remove(bacSi);
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
