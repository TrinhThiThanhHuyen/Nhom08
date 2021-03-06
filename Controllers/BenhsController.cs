﻿using System;
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
    public class BenhsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Benhs
        public ActionResult Index()
        {
            if (Session["idBacSi"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View(db.Benhs.ToList());
        }

        // GET: Benhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benh benh = db.Benhs.Find(id);
            if (benh == null)
            {
                return HttpNotFound();
            }
            return View(benh);
        }

        // GET: Benhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Benhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TenBenh,TrieuChung")] Benh benh)
        {
            if (ModelState.IsValid)
            {
                db.Benhs.Add(benh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benh);
        }

        // GET: Benhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benh benh = db.Benhs.Find(id);
            if (benh == null)
            {
                return HttpNotFound();
            }
            return View(benh);
        }

        // POST: Benhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TenBenh,TrieuChung")] Benh benh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benh);
        }

        // GET: Benhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benh benh = db.Benhs.Find(id);
            if (benh == null)
            {
                return HttpNotFound();
            }
            return View(benh);
        }

        // POST: Benhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Benh benh = db.Benhs.Find(id);
            db.Benhs.Remove(benh);
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
