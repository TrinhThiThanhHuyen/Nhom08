namespace QLPKDKTN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BenhNhans", "BacSi_id", "dbo.BacSis");
            DropForeignKey("dbo.BenhNhans", "Benh_id", "dbo.Benhs");
            DropIndex("dbo.BenhNhans", new[] { "BacSi_id" });
            DropIndex("dbo.BenhNhans", new[] { "Benh_id" });
            AlterColumn("dbo.BenhNhans", "BacSi_id", c => c.Int());
            AlterColumn("dbo.BenhNhans", "Benh_id", c => c.Int());
            CreateIndex("dbo.BenhNhans", "BacSi_id");
            CreateIndex("dbo.BenhNhans", "Benh_id");
            AddForeignKey("dbo.BenhNhans", "BacSi_id", "dbo.BacSis", "id");
            AddForeignKey("dbo.BenhNhans", "Benh_id", "dbo.Benhs", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BenhNhans", "Benh_id", "dbo.Benhs");
            DropForeignKey("dbo.BenhNhans", "BacSi_id", "dbo.BacSis");
            DropIndex("dbo.BenhNhans", new[] { "Benh_id" });
            DropIndex("dbo.BenhNhans", new[] { "BacSi_id" });
            AlterColumn("dbo.BenhNhans", "Benh_id", c => c.Int(nullable: false));
            AlterColumn("dbo.BenhNhans", "BacSi_id", c => c.Int(nullable: false));
            CreateIndex("dbo.BenhNhans", "Benh_id");
            CreateIndex("dbo.BenhNhans", "BacSi_id");
            AddForeignKey("dbo.BenhNhans", "Benh_id", "dbo.Benhs", "id", cascadeDelete: true);
            AddForeignKey("dbo.BenhNhans", "BacSi_id", "dbo.BacSis", "id", cascadeDelete: true);
        }
    }
}
