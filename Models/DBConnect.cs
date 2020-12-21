namespace QLPKDKTN.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnect : DbContext
    {
        public virtual DbSet<BacSi> BacSis { get; set; }
        public virtual DbSet<Benh> Benhs { get; set; }
        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<HoaDonThuoc> HoaDonThuocs { get; set; }
        public virtual DbSet<HoSo> HoSos { get; set; }
        public virtual DbSet<PhieuThuTien> PhieuThuTiens { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }
        public DBConnect()
            : base("name=DBConnect")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
