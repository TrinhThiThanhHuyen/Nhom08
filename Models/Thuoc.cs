using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLPKDKTN.Models
{
    public class Thuoc
    {
        [Key]
        public int id { get; set; }
        public string TenThuoc { get; set; }
        public string NhaCC { get; set; }
        public string MoTaTP { get; set; }
        public int Benh_id { get; set; }
        [ForeignKey("Benh_id")]
        public virtual Benh Benh { get; set; }
        public ICollection<HoaDonThuoc> HoaDonThuocs { get; set; }
    }
}