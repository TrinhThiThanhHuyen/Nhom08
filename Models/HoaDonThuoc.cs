using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLPKDKTN.Models
{
    public class HoaDonThuoc
    {
        [Key]
        public int id { get; set; }
        public DateTime NgayThu { get; set; }
        public string DonVi { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public double ThanhTien { get; set; }
        public int Thuoc_id { get; set; }
        [ForeignKey("Thuoc_id")]
        public virtual Thuoc Thuoc { get; set; }
        public int BenhNhan_id { get; set; }
        [ForeignKey("BenhNhan_id")]
        public virtual BenhNhan BenhNhan { get; set; }
    }
}