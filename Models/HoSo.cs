using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLPKDKTN.Models
{
    public class HoSo
    {
        [Key]
        public int id { get; set; }
        public DateTime NgayTao { get; set; }
        public string DichVu { get; set; }
        public string GhiChu { get; set; }
        public int BenhNhan_id { get; set; }
        [ForeignKey("BenhNhan_id")]
        public virtual BenhNhan BenhNhan { get; set; }
    }
}