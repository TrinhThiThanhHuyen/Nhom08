using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLPKDKTN.Models
{
    public class BenhNhan
    {
        [Key]
        public int id { get; set; }
        public string TenBN { get; set; }
        public int Tuoi { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string role { get; set; }
        public virtual BacSi BacSi { get; set; }
        public ICollection<HoaDonThuoc> HoaDonThuocs { get; set; }
        public ICollection<HoSo> HoSos { get; set; }
        public ICollection<PhieuThuTien> PhieuThuTiens { get; set; }

    }
}