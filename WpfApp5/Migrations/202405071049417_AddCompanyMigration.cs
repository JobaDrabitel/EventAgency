namespace WpfApp5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ActivityName = c.String(maxLength: 250),
                        DayNumber = c.Int(),
                        StartTime = c.Time(precision: 7),
                        ModeratorId = c.Int(),
                        Judge1Id = c.Int(),
                        Judge2Id = c.Int(),
                        Judge3Id = c.Int(),
                        Judge4Id = c.Int(),
                        Judge5Id = c.Int(),
                        WinnerId = c.Int(),
                        EventId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.ModeratorId)
                .ForeignKey("dbo.User", t => t.Judge1Id)
                .ForeignKey("dbo.User", t => t.Judge2Id)
                .ForeignKey("dbo.User", t => t.Judge3Id)
                .ForeignKey("dbo.User", t => t.Judge4Id)
                .ForeignKey("dbo.User", t => t.Judge5Id)
                .ForeignKey("dbo.User", t => t.WinnerId)
                .Index(t => t.ModeratorId)
                .Index(t => t.Judge1Id)
                .Index(t => t.Judge2Id)
                .Index(t => t.Judge3Id)
                .Index(t => t.Judge4Id)
                .Index(t => t.Judge5Id)
                .Index(t => t.WinnerId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        EventName = c.String(maxLength: 250),
                        StartDate = c.DateTime(storeType: "date"),
                        DaysCount = c.Int(),
                        CityId = c.Int(),
                        OrganizerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.User", t => t.OrganizerId)
                .Index(t => t.CityId)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CityImage = c.Binary(storeType: "image"),
                        CityName = c.String(maxLength: 180),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity:true),
                        LastName = c.String(maxLength: 120),
                        FirstName = c.String(maxLength: 120),
                        Patronymic = c.String(maxLength: 120),
                        Email = c.String(maxLength: 120),
                        Password = c.String(maxLength: 120),
                        Phone = c.String(maxLength: 20),
                        Gender = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        BirthDate = c.DateTime(storeType: "date"),
                        UserImage = c.Binary(storeType: "image"),
                        Specialization = c.String(maxLength: 120),
                        Role = c.Int(),
                        CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CountryNameRU = c.String(maxLength: 180),
                        CountryNameEN = c.String(maxLength: 180),
                        Code1 = c.String(maxLength: 10),
                        Code2 = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialization",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SpecializationName = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "OrganizerId", "dbo.User");
            DropForeignKey("dbo.User", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Activity", "WinnerId", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge5Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge4Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge3Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge2Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge1Id", "dbo.User");
            DropForeignKey("dbo.Activity", "ModeratorId", "dbo.User");
            DropForeignKey("dbo.Event", "CityId", "dbo.City");
            DropForeignKey("dbo.Activity", "EventId", "dbo.Event");
            DropIndex("dbo.User", new[] { "CountryId" });
            DropIndex("dbo.Event", new[] { "OrganizerId" });
            DropIndex("dbo.Event", new[] { "CityId" });
            DropIndex("dbo.Activity", new[] { "EventId" });
            DropIndex("dbo.Activity", new[] { "WinnerId" });
            DropIndex("dbo.Activity", new[] { "Judge5Id" });
            DropIndex("dbo.Activity", new[] { "Judge4Id" });
            DropIndex("dbo.Activity", new[] { "Judge3Id" });
            DropIndex("dbo.Activity", new[] { "Judge2Id" });
            DropIndex("dbo.Activity", new[] { "Judge1Id" });
            DropIndex("dbo.Activity", new[] { "ModeratorId" });
            DropTable("dbo.Specialization");
            DropTable("dbo.Country");
            DropTable("dbo.User");
            DropTable("dbo.City");
            DropTable("dbo.Event");
            DropTable("dbo.Activity");
        }
    }
}
