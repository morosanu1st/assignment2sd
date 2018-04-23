namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
