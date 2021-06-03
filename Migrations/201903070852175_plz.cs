namespace HMS_ITI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plz : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Roles", new[] { "RoleNameAr" });
            AlterColumn("dbo.Roles", "RoleNameAr", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Roles", "RoleNameEn", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Roles", "RoleNameAr", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Roles", new[] { "RoleNameAr" });
            AlterColumn("dbo.Roles", "RoleNameEn", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Roles", "RoleNameAr", c => c.String(nullable: false, maxLength: 15));
            CreateIndex("dbo.Roles", "RoleNameAr", unique: true);
        }
    }
}
