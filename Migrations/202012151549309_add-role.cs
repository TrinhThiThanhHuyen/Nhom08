namespace QLPKDKTN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BenhNhans", "Email", c => c.String(nullable: false));
            AddColumn("dbo.BenhNhans", "Password", c => c.String(nullable: false));
            AddColumn("dbo.BenhNhans", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BenhNhans", "role");
            DropColumn("dbo.BenhNhans", "Password");
            DropColumn("dbo.BenhNhans", "Email");
        }
    }
}
