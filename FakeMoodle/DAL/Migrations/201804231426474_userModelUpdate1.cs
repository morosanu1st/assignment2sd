namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userModelUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
        }
    }
}
