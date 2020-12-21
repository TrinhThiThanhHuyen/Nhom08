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
    public class HoSoesController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: HoSoes
        public ActionResult Index()
        {
            if (Session["idBacSi"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var hoSos = db.HoSos.Include(h => h.BenhNhan);
            return View(hoSos.ToList());
        }

        // GET: HoSoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSos.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            return View(hoSo);
        }

        // GET: HoSoes/Create
        public ActionResult Create()
        {
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN");
            return View();
        }

        // POST: HoSoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NgayTao,DichVu,GhiChu,BenhNhan_id")] HoSo hoSo)
        {
            if (ModelState.IsValid)
            {
                db.HoSos.Add(hoSo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", hoSo.BenhNhan_id);
            return View(hoSo);
        }

        // GET: HoSoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSos.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", hoSo.BenhNhan_id);
            return View(hoSo);
        }

        // POST: HoSoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NgayTao,DichVu,GhiChu,BenhNhan_id")] HoSo hoSo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoSo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", hoSo.BenhNhan_id);
            return View(hoSo);
        }

        // GET: HoSoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSos.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            return View(hoSo);
        }

        // POST: HoSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoSo hoSo = db.HoSos.Find(id);
            db.HoSos.Remove(hoSo);
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
