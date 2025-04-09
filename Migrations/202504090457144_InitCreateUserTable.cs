namespace QLDN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreateUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        FailedLoginCount = c.Int(nullable: false),
                        LockedUntil = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
