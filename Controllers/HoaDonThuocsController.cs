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
    public class HoaDonThuocsController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: HoaDonThuocs
        public ActionResult Index()
        {
            if (Session["idBacSi"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var hoaDonThuocs = db.HoaDonThuocs.Include(h => h.BenhNhan).Include(h => h.Thuoc);
            return View(hoaDonThuocs.ToList());
        }

        // GET: HoaDonThuocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonThuoc hoaDonThuoc = db.HoaDonThuocs.Find(id);
            if (hoaDonThuoc == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonThuoc);
        }

        // GET: HoaDonThuocs/Create
        public ActionResult Create()
        {
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN");
            ViewBag.Thuoc_id = new SelectList(db.Thuocs, "id", "TenThuoc");
            return View();
        }

        // POST: HoaDonThuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NgayThu,DonVi,SoLuong,DonGia,ThanhTien,Thuoc_id,BenhNhan_id")] HoaDonThuoc hoaDonThuoc)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonThuocs.Add(hoaDonThuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", hoaDonThuoc.BenhNhan_id);
            ViewBag.Thuoc_id = new SelectList(db.Thuocs, "id", "TenThuoc", hoaDonThuoc.Thuoc_id);
            return View(hoaDonThuoc);
        }

        // GET: HoaDonThuocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonThuoc hoaDonThuoc = db.HoaDonThuocs.Find(id);
            if (hoaDonThuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", hoaDonThuoc.BenhNhan_id);
            ViewBag.Thuoc_id = new SelectList(db.Thuocs, "id", "TenThuoc", hoaDonThuoc.Thuoc_id);
            return View(hoaDonThuoc);
        }

        // POST: HoaDonThuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NgayThu,DonVi,SoLuong,DonGia,ThanhTien,Thuoc_id,BenhNhan_id")] HoaDonThuoc hoaDonThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", hoaDonThuoc.BenhNhan_id);
            ViewBag.Thuoc_id = new SelectList(db.Thuocs, "id", "TenThuoc", hoaDonThuoc.Thuoc_id);
            return View(hoaDonThuoc);
        }

        // GET: HoaDonThuocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonThuoc hoaDonThuoc = db.HoaDonThuocs.Find(id);
            if (hoaDonThuoc == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonThuoc);
        }

        // POST: HoaDonThuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonThuoc hoaDonThuoc = db.HoaDonThuocs.Find(id);
            db.HoaDonThuocs.Remove(hoaDonThuoc);
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
