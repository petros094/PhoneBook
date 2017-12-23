namespace PhoneBook.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactFields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Field = c.String(nullable: false, maxLength: 100),
                        Value = c.String(nullable: false, maxLength: 100),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactFields", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactFields", new[] { "ContactId" });
            DropTable("dbo.ContactFields");
            DropTable("dbo.Contacts");
        }
    }
}
