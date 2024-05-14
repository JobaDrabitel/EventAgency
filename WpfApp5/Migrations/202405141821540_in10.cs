namespace WpfApp5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class in10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "CityId", "dbo.City");
            DropForeignKey("dbo.Activity", "ModeratorId", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge1Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge2Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge3Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge4Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge5Id", "dbo.User");
            DropForeignKey("dbo.Activity", "WinnerId", "dbo.User");
            DropForeignKey("dbo.Event", "OrganizerId", "dbo.User");
            DropForeignKey("dbo.User", "CountryId", "dbo.Country");
            DropPrimaryKey("dbo.Activity");
            DropPrimaryKey("dbo.Event");
            DropPrimaryKey("dbo.City");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.Country");
            DropPrimaryKey("dbo.Specialization");
            AlterColumn("dbo.Activity", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Event", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.City", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Country", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Specialization", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Activity", "Id");
            AddPrimaryKey("dbo.Event", "Id");
            AddPrimaryKey("dbo.City", "Id");
            AddPrimaryKey("dbo.User", "Id");
            AddPrimaryKey("dbo.Country", "Id");
            AddPrimaryKey("dbo.Specialization", "Id");
            AddForeignKey("dbo.Activity", "EventId", "dbo.Event", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Event", "CityId", "dbo.City", "Id");
            AddForeignKey("dbo.Activity", "ModeratorId", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge1Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge2Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge3Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge4Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge5Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "WinnerId", "dbo.User", "Id");
            AddForeignKey("dbo.Event", "OrganizerId", "dbo.User", "Id");
            AddForeignKey("dbo.User", "CountryId", "dbo.Country", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Event", "OrganizerId", "dbo.User");
            DropForeignKey("dbo.Activity", "WinnerId", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge5Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge4Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge3Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge2Id", "dbo.User");
            DropForeignKey("dbo.Activity", "Judge1Id", "dbo.User");
            DropForeignKey("dbo.Activity", "ModeratorId", "dbo.User");
            DropForeignKey("dbo.Event", "CityId", "dbo.City");
            DropForeignKey("dbo.Activity", "EventId", "dbo.Event");
            DropPrimaryKey("dbo.Specialization");
            DropPrimaryKey("dbo.Country");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.City");
            DropPrimaryKey("dbo.Event");
            DropPrimaryKey("dbo.Activity");
            AlterColumn("dbo.Specialization", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Country", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.City", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Event", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Activity", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Specialization", "Id");
            AddPrimaryKey("dbo.Country", "Id");
            AddPrimaryKey("dbo.User", "Id");
            AddPrimaryKey("dbo.City", "Id");
            AddPrimaryKey("dbo.Event", "Id");
            AddPrimaryKey("dbo.Activity", "Id");
            AddForeignKey("dbo.User", "CountryId", "dbo.Country", "Id");
            AddForeignKey("dbo.Event", "OrganizerId", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "WinnerId", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge5Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge4Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge3Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge2Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "Judge1Id", "dbo.User", "Id");
            AddForeignKey("dbo.Activity", "ModeratorId", "dbo.User", "Id");
            AddForeignKey("dbo.Event", "CityId", "dbo.City", "Id");
            AddForeignKey("dbo.Activity", "EventId", "dbo.Event", "Id", cascadeDelete: true);
        }
    }
}
