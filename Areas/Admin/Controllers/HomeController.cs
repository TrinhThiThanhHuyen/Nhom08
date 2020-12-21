using QLPKDKTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QLPKDKTN.Utility;

namespace QLPKDKTN.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DBConnect db = new DBConnect();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var ma_hoa_du_lieu = GETMD5(password);
                var kiem_tra_tai_khoan = db.BacSis.Where(s => s.Email.Equals(email) && s.Password.Equals(ma_hoa_du_lieu)).ToList();
                if (kiem_tra_tai_khoan != null)
                {
                    Session["idBacSi"] = kiem_tra_tai_khoan.FirstOrDefault().id;
                    
                    Session["tenBS"] = Helper.getName(kiem_tra_tai_khoan.FirstOrDefault().HoTen);//cắt lấy mỗi tên của BS
                    var checkAdmin = kiem_tra_tai_khoan.FirstOrDefault().role;
                    if (checkAdmin == "admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });

                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    ViewBag.LoginError = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(BacSi bs)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.BacSis.FirstOrDefault(m => m.Email == bs.Email);
                if (checkEmail == null)
                {
                    bs.Password = GETMD5(bs.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.BacSis.Add(bs);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return RedirectToAction("Register");
                }
            }
            return View();
        }
        public static string GETMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string mk_da_ma_hoa = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                mk_da_ma_hoa += targetData[i].ToString("x2");
            }
            return mk_da_ma_hoa;

        }
    }
}