namespace WpfApp5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class in3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserName", c => c.String(maxLength: 120));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserName");
        }
    }
}
