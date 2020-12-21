using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLPKDKTN.Models;
using QLPKDKTN.Utility;

namespace QLPKDKTN.Areas.Admin.Controllers
{
    public class PhieuThuTiensController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: Admin/PhieuThuTiens
        public ActionResult Index()
        {
            var phieuThuTiens = db.PhieuThuTiens.Include(p => p.BenhNhan);

            //Tính tổng tiền
            List<PhieuThuTien> ListHoaDonThuocs = phieuThuTiens.ToList();
            double sum = 0;
            for (int i = 0; i < ListHoaDonThuocs.Count; i++)
            {
                sum += ListHoaDonThuocs[i].ThanhTien;
            }
            string result = Helper.formatMoney(sum, "VND");
            ViewBag.totalMoney = result;
            return View(phieuThuTiens.ToList());
        }

        // GET: Admin/PhieuThuTiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTien phieuThuTien = db.PhieuThuTiens.Find(id);
            if (phieuThuTien == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuTien);
        }

        // GET: Admin/PhieuThuTiens/Create
        public ActionResult Create()
        {
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN");
            return View();
        }

        // POST: Admin/PhieuThuTiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,NgayThu,DichVu,ThanhTien,BenhNhan_id")] PhieuThuTien phieuThuTien)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThuTiens.Add(phieuThuTien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", phieuThuTien.BenhNhan_id);
            return View(phieuThuTien);
        }

        // GET: Admin/PhieuThuTiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTien phieuThuTien = db.PhieuThuTiens.Find(id);
            if (phieuThuTien == null)
            {
                return HttpNotFound();
            }
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", phieuThuTien.BenhNhan_id);
            return View(phieuThuTien);
        }

        // POST: Admin/PhieuThuTiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,NgayThu,DichVu,ThanhTien,BenhNhan_id")] PhieuThuTien phieuThuTien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThuTien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BenhNhan_id = new SelectList(db.BenhNhans, "id", "TenBN", phieuThuTien.BenhNhan_id);
            return View(phieuThuTien);
        }

        // GET: Admin/PhieuThuTiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuTien phieuThuTien = db.PhieuThuTiens.Find(id);
            if (phieuThuTien == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuTien);
        }

        // POST: Admin/PhieuThuTiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuThuTien phieuThuTien = db.PhieuThuTiens.Find(id);
            db.PhieuThuTiens.Remove(phieuThuTien);
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
