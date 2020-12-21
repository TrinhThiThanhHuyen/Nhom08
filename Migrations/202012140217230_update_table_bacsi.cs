namespace QLPKDKTN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_bacsi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BacSis", "Email", c => c.String(nullable: false));
            AddColumn("dbo.BacSis", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BacSis", "Password");
            DropColumn("dbo.BacSis", "Email");
        }
    }
}
