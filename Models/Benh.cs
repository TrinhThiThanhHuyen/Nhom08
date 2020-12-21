using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLPKDKTN.Models
{
    public class Benh
    {
        [Key]
        public int id { get; set; }
        public string TenBenh { get; set; }
        public string TrieuChung { get; set; }
        public ICollection<BenhNhan> BenhNhans { get; set; }
        public ICollection<Thuoc> Thuocs { get; set; }
    }
}