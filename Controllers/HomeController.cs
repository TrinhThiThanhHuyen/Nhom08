using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using QLPKDKTN.Models;
using PagedList;


namespace QLPKDKTN.Controllers
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
       
        public ActionResult Infor()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
          if(ModelState.IsValid)
            {
                var ma_hoa_du_lieu = GETMD5(password);
                var kiem_tra_tai_khoan = db.BenhNhans.Where(s => s.Email.Equals(email)&& s.Password.Equals(ma_hoa_du_lieu)).ToList();
                if(kiem_tra_tai_khoan !=null)
                {
                    Session["idBenhNhan"] = kiem_tra_tai_khoan.FirstOrDefault().id;
                    Session["tenBN"] = kiem_tra_tai_khoan.FirstOrDefault().TenBN;
                    var checkAdmin = kiem_tra_tai_khoan.FirstOrDefault().role;
                   
                        return RedirectToAction("Index");
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
        public ActionResult Register(BenhNhan bn)
        {
           if(ModelState.IsValid)
            {
                var checkEmail = db.BenhNhans.FirstOrDefault(m => m.Email == bn.Email);
                if(checkEmail == null)
                {
                    bn.Password = GETMD5(bn.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.BenhNhans.Add(bn);
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
            for (int i=0;i<targetData.Length;i++)
            {
                mk_da_ma_hoa += targetData[i].ToString("x2");
            }
            return mk_da_ma_hoa;

        }
    }
}