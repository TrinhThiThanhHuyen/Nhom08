﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLPKDKTN.Models;

namespace QLPKDKTN.Areas.Admin.Controllers
{
    public class ThuocsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Admin/Thuocs
        public ActionResult Index()
        {
            var thuocs = db.Thuocs.Include(t => t.Benh);
            return View(thuocs.ToList());
        }

        // GET: Admin/Thuocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // GET: Admin/Thuocs/Create
        public ActionResult Create()
        {
            ViewBag.Benh_id = new SelectList(db.Benhs, "id", "TenBenh");
            return View();
        }

        // POST: Admin/Thuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TenThuoc,NhaCC,MoTaTP,Benh_id")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Thuocs.Add(thuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Benh_id = new SelectList(db.Benhs, "id", "TenBenh", thuoc.Benh_id);
            return View(thuoc);
        }

        // GET: Admin/Thuocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.Benh_id = new SelectList(db.Benhs, "id", "TenBenh", thuoc.Benh_id);
            return View(thuoc);
        }

        // POST: Admin/Thuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TenThuoc,NhaCC,MoTaTP,Benh_id")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Benh_id = new SelectList(db.Benhs, "id", "TenBenh", thuoc.Benh_id);
            return View(thuoc);
        }

        // GET: Admin/Thuocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Admin/Thuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thuoc thuoc = db.Thuocs.Find(id);
            db.Thuocs.Remove(thuoc);
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
