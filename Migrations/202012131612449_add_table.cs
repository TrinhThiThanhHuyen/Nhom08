namespace QLPKDKTN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BacSis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        SDT = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.BenhNhans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TenBN = c.String(),
                        Tuoi = c.Int(nullable: false),
                        DiaChi = c.String(),
                        SDT = c.String(),
                        BacSi_id = c.Int(nullable: false),
                        Benh_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BacSis", t => t.BacSi_id, cascadeDelete: true)
                .ForeignKey("dbo.Benhs", t => t.Benh_id, cascadeDelete: true)
                .Index(t => t.BacSi_id)
                .Index(t => t.Benh_id);
            
            CreateTable(
                "dbo.Benhs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TenBenh = c.String(),
                        TrieuChung = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Thuocs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TenThuoc = c.String(),
                        NhaCC = c.String(),
                        MoTaTP = c.String(),
                        Benh_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Benhs", t => t.Benh_id, cascadeDelete: true)
                .Index(t => t.Benh_id);
            
            CreateTable(
                "dbo.HoaDonThuocs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NgayThu = c.DateTime(nullable: false),
                        DonVi = c.String(),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                        ThanhTien = c.Double(nullable: false),
                        Thuoc_id = c.Int(nullable: false),
                        BenhNhan_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BenhNhans", t => t.BenhNhan_id, cascadeDelete: false)
                .ForeignKey("dbo.Thuocs", t => t.Thuoc_id, cascadeDelete: false)
                .Index(t => t.Thuoc_id)
                .Index(t => t.BenhNhan_id);
            
            CreateTable(
                "dbo.HoSoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NgayTao = c.DateTime(nullable: false),
                        DichVu = c.String(),
                        GhiChu = c.String(),
                        BenhNhan_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BenhNhans", t => t.BenhNhan_id, cascadeDelete: true)
                .Index(t => t.BenhNhan_id);
            
            CreateTable(
                "dbo.PhieuThuTiens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NgayThu = c.DateTime(nullable: false),
                        DichVu = c.String(),
                        ThanhTien = c.Double(nullable: false),
                        BenhNhan_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.BenhNhans", t => t.BenhNhan_id, cascadeDelete: true)
                .Index(t => t.BenhNhan_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuThuTiens", "BenhNhan_id", "dbo.BenhNhans");
            DropForeignKey("dbo.HoSoes", "BenhNhan_id", "dbo.BenhNhans");
            DropForeignKey("dbo.HoaDonThuocs", "Thuoc_id", "dbo.Thuocs");
            DropForeignKey("dbo.HoaDonThuocs", "BenhNhan_id", "dbo.BenhNhans");
            DropForeignKey("dbo.Thuocs", "Benh_id", "dbo.Benhs");
            DropForeignKey("dbo.BenhNhans", "Benh_id", "dbo.Benhs");
            DropForeignKey("dbo.BenhNhans", "BacSi_id", "dbo.BacSis");
            DropIndex("dbo.PhieuThuTiens", new[] { "BenhNhan_id" });
            DropIndex("dbo.HoSoes", new[] { "BenhNhan_id" });
            DropIndex("dbo.HoaDonThuocs", new[] { "BenhNhan_id" });
            DropIndex("dbo.HoaDonThuocs", new[] { "Thuoc_id" });
            DropIndex("dbo.Thuocs", new[] { "Benh_id" });
            DropIndex("dbo.BenhNhans", new[] { "Benh_id" });
            DropIndex("dbo.BenhNhans", new[] { "BacSi_id" });
            DropTable("dbo.PhieuThuTiens");
            DropTable("dbo.HoSoes");
            DropTable("dbo.HoaDonThuocs");
            DropTable("dbo.Thuocs");
            DropTable("dbo.Benhs");
            DropTable("dbo.BenhNhans");
            DropTable("dbo.BacSis");
        }
    }
}
